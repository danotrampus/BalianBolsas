Imports BLL
Imports EE
Imports System.IO
Public Class BolsaController
    Inherits BaseController

    Private vBLL As ProductoBLL
    Private vImpresionBLL As ImpresionBLL
    Private vPolimeroBLL As PolimeroBLL
    Private vManijaBLL As ManijaBLL

    Sub New()
        Me.vBLL = New ProductoBLL()
        Me.vImpresionBLL = New ImpresionBLL()
        Me.vPolimeroBLL = New PolimeroBLL()
        Me.vManijaBLL = New ManijaBLL()
    End Sub

    '
    ' GET: /Producto
    <Autorizar(Roles:="ListarBolsas")>
    Function Index() As ActionResult
        Dim vLista As List(Of Bolsa) = Me.vBLL.ListarBolsas()
        Return View(vLista)
    End Function

    <Autorizar(Roles:="ConsultarBolsa")>
    Function Detalle(ByVal id As Integer) As ActionResult
        Dim vBolsa As EE.Bolsa = DirectCast(Me.vBLL.ConsultarPorId(id), Bolsa)
        Return View(vBolsa)
    End Function

    <Autorizar(Roles:="CrearBolsa")>
    Function Crear() As ActionResult
        ViewBag.Impresiones = Me.vImpresionBLL.Listar()
        ViewBag.Polimeros = Me.vPolimeroBLL.Listar()
        ViewBag.Manijas = Me.vManijaBLL.Listar()
        Return View()
    End Function

    <Autorizar(Roles:="CrearBolsa")>
    <HttpPost()>
    Function Crear(ByVal model As BolsaViewModel) As ActionResult
        ModelState.Item("ImpresionId").Errors.Clear()
        ModelState.Item("ManijaId").Errors.Clear()
        If ModelState.IsValid Then
            Dim directorioSubidas As String = "~/Content/img"
            Dim urlSubidas As String = "/Content/img"
            Dim idImagen As String = Guid.NewGuid().ToString() + Path.GetExtension(model.Imagen.FileName)
            Dim rutaImagen As String = Path.Combine(Server.MapPath(directorioSubidas), idImagen)
            Dim urlImagen As String = urlSubidas + "/" + idImagen
            model.Imagen.SaveAs(rutaImagen)

            Dim b As New Bolsa
            b.Ancho = model.Ancho
            b.Largo = model.Largo
            b.Espesor = model.Espesor
            b.Soldadura = model.Soldadura
            b.Formato = model.Formato
            b.Impresion.Id = model.ImpresionId
            b.Polimero.Id = model.PolimeroId
            b.Manija.Id = model.ManijaId
            b.Imagen = urlImagen

            Me.vBLL.Crear(b)
            Return RedirectToAction("Index")
        End If
        ViewBag.Impresiones = Me.vImpresionBLL.Listar()
        ViewBag.Polimeros = Me.vPolimeroBLL.Listar()
        ViewBag.Manijas = Me.vManijaBLL.Listar()
        Return View(model)
    End Function

    <Autorizar(Roles:="EditarBolsa")>
    Function Editar(ByVal id As Integer) As ActionResult
        Dim vBolsa As EE.Bolsa = DirectCast(Me.vBLL.ConsultarPorId(id), Bolsa)
        Dim model As New BolsaViewModel
        model.Id = vBolsa.Id
        model.Ancho = vBolsa.Ancho
        model.Largo = vBolsa.Largo
        model.Espesor = vBolsa.Espesor
        model.Formato = vBolsa.Formato
        model.Soldadura = vBolsa.Soldadura
        model.ManijaId = vBolsa.Manija.Id
        model.ImpresionId = vBolsa.Impresion.Id
        model.PolimeroId = vBolsa.Polimero.Id

        ViewBag.Impresiones = Me.vImpresionBLL.Listar()
        ViewBag.Polimeros = Me.vPolimeroBLL.Listar()
        ViewBag.Manijas = Me.vManijaBLL.Listar()

        Return View(model)
    End Function

    <Autorizar(Roles:="EditarBolsa")>
    <HttpPost()> _
    Function Editar(ByVal id As Integer, ByVal model As BolsaViewModel) As ActionResult
        ModelState.Item("ImpresionId").Errors.Clear()
        ModelState.Item("ManijaId").Errors.Clear()
        If model.Imagen Is Nothing Then
            ModelState.Item("Imagen").Errors.Clear()
        End If
        If ModelState.IsValid Then
            Dim b As New Bolsa
            Dim vBolsaActual As EE.Bolsa = DirectCast(Me.vBLL.ConsultarPorId(id), Bolsa)
            If model.Imagen IsNot Nothing Then
                Dim rutaImagenActual As String = Server.MapPath("~" + vBolsaActual.Imagen)
                If IO.File.Exists(rutaImagenActual) Then
                    IO.File.Delete(rutaImagenActual)
                End If
                Dim directorioSubidas As String = "~/Content/img"
                Dim urlSubidas As String = "/Content/img"
                Dim idImagen As String = Guid.NewGuid().ToString() + Path.GetExtension(model.Imagen.FileName)
                Dim rutaImagen As String = Path.Combine(Server.MapPath(directorioSubidas), idImagen)
                Dim urlImagen As String = urlSubidas + "/" + idImagen
                model.Imagen.SaveAs(rutaImagen)
                b.Imagen = urlImagen
            Else
                b.Imagen = vBolsaActual.Imagen
            End If

            b.Id = model.Id
            b.Ancho = model.Ancho
            b.Largo = model.Largo
            b.Espesor = model.Espesor
            b.Soldadura = model.Soldadura
            b.Formato = model.Formato
            b.Impresion.Id = model.ImpresionId
            b.Polimero.Id = model.PolimeroId
            b.Manija.Id = model.ManijaId

            Me.vBLL.Editar(b)
            Return RedirectToAction("Index")
        End If
        ViewBag.Impresiones = Me.vImpresionBLL.Listar()
        ViewBag.Polimeros = Me.vPolimeroBLL.Listar()
        ViewBag.Manijas = Me.vManijaBLL.Listar()
        Return View(model)
    End Function

    <Autorizar(Roles:="EliminarBolsa")>
    Function Eliminar(ByVal id As Integer) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Eliminar(id)
        End If
        Return RedirectToAction("Index")
    End Function

End Class