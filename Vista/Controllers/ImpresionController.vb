Imports BLL
Imports EE
Public Class ImpresionController
    Inherits BaseController

    Private vBLL As ImpresionBLL
    Private vColorBLL As ColorBLL
    Sub New()
        Me.vBLL = New ImpresionBLL()
        Me.vColorBLL = New ColorBLL()
    End Sub

    '
    ' GET: /Impresion
    <Autorizar(Roles:="ListarImpresiones")>
    Function Index() As ActionResult
        Dim vLista As List(Of Impresion) = Me.vBLL.Listar()
        Return View(vLista)
    End Function

    <Autorizar(Roles:="ConsultarImpresion")>
    Function Detalle(ByVal id As Integer) As ActionResult
        Dim vImpresion As EE.Impresion = Me.vBLL.ConsultarPorId(id)
        Return View(vImpresion)
    End Function

    <Autorizar(Roles:="CrearImpresion")>
    Function Crear() As ActionResult
        ViewBag.Colores = Me.vColorBLL.Listar()
        Return View()
    End Function

    <Autorizar(Roles:="CrearImpresion")>
    <HttpPost()>
    Function Crear(ByVal entidad As Impresion) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Crear(entidad)
            Return RedirectToAction("Index")
        End If
        ViewBag.Colores = Me.vColorBLL.Listar()
        Return View(entidad)
    End Function

    <Autorizar(Roles:="EditarImpresion")>
    Function Editar(ByVal id As Integer) As ActionResult
        Dim entidad As Impresion = Me.vBLL.ConsultarPorId(id)

        ViewBag.Colores = Me.vColorBLL.Listar()

        Return View(entidad)
    End Function

    <Autorizar(Roles:="EditarImpresion")>
    <HttpPost()> _
    Function Editar(ByVal id As Integer, ByVal entidad As Impresion) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Editar(entidad)
            Return RedirectToAction("Index")
        End If

        ViewBag.Colores = Me.vColorBLL.Listar()
        Return View(entidad)
    End Function

    <Autorizar(Roles:="EliminarImpresion")>
    Function Eliminar(ByVal id As Integer) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Eliminar(id)
        End If
        Return RedirectToAction("Index")
    End Function

End Class