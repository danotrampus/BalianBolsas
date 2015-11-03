Imports BLL
Imports EE
Imports System.IO
Public Class ProductoController
    Inherits BaseController

    Private vBLL As ProductoBLL
    Private vImpresionBLL As ImpresionBLL
    Private vPolimeroBLL As PolimeroBLL
    Sub New()
        Me.vBLL = New ProductoBLL()
        Me.vImpresionBLL = New ImpresionBLL()
        Me.vPolimeroBLL = New PolimeroBLL()
    End Sub

    '
    ' GET: /Producto
    <Autorizar(Roles:="ListarProductos")>
    Function Index() As ActionResult
        Dim vLista As List(Of Producto) = Me.vBLL.Listar()
        Return View(vLista)
    End Function

    <Autorizar(Roles:="ConsultarProducto")>
    Function Detalle(ByVal id As Integer) As ActionResult
        Dim vProducto As EE.Producto = Me.vBLL.ConsultarPorId(id)
        Return View(vProducto)
    End Function

    <Autorizar(Roles:="CrearProducto")>
    Function Crear() As ActionResult
        ViewBag.Impresiones = Me.vImpresionBLL.Listar()
        ViewBag.Polimeros = Me.vPolimeroBLL.Listar()
        Return View()
    End Function

    <Autorizar(Roles:="CrearProducto")>
    <HttpPost()>
    Function Crear(ByVal entidad As Producto, ByVal Archivo As HttpPostedFileBase) As ActionResult
        Dim listaTiposImagenes As New List(Of String)
        listaTiposImagenes.AddRange({"image/gif", "image/jpeg", "image/png"})
        If archivo Is Nothing Or archivo.ContentLength = 0 Then
            ModelState.AddModelError("Archivo", "Campo requerido")
        ElseIf listaTiposImagenes.Contains(Archivo.ContentType) = False Then
            ModelState.AddModelError("Archivo", "Tipo de archivo no permitido")
        End If
        ModelState("Impresion.Tratado").Errors.Clear()
        ModelState("Polimero.Nombre").Errors.Clear()
        If ModelState.IsValid Then
            Dim directorioSubidas As String = "~/Content/img"
            Dim urlSubidas As String = "/Content/img"
            Dim idImagen As String = Guid.NewGuid().ToString() + Path.GetExtension(Archivo.FileName)
            Dim rutaImagen As String = Path.Combine(Server.MapPath(directorioSubidas), idImagen)
            Dim urlImagen As String = urlSubidas + "/" + idImagen
            archivo.SaveAs(rutaImagen)
            entidad.Imagen = urlImagen

            Me.vBLL.Crear(entidad)
            Return RedirectToAction("Index")
        End If
        ViewBag.Impresiones = Me.vImpresionBLL.Listar()
        ViewBag.Polimeros = Me.vPolimeroBLL.Listar()
        Return View(entidad)
    End Function

    <Autorizar(Roles:="EditarProducto")>
    Function Editar(ByVal id As Integer) As ActionResult
        Dim entidad As Producto = Me.vBLL.ConsultarPorId(id)

        ViewBag.Impresiones = Me.vImpresionBLL.Listar()
        ViewBag.Polimeros = Me.vPolimeroBLL.Listar()

        Return View(entidad)
    End Function

    <Autorizar(Roles:="EditarProducto")>
    <HttpPost()> _
    Function Editar(ByVal id As Integer, ByVal entidad As Producto) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Editar(entidad)
            Return RedirectToAction("Index")
        End If

        ViewBag.Impresiones = Me.vImpresionBLL.Listar()
        ViewBag.Polimeros = Me.vPolimeroBLL.Listar()
        Return View(entidad)
    End Function

    <Autorizar(Roles:="EliminarProducto")>
    Function Eliminar(ByVal id As Integer) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Eliminar(id)
        End If
        Return RedirectToAction("Index")
    End Function

End Class