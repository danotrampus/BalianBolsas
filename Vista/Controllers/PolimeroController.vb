Imports BLL
Imports EE
Public Class PolimeroController
    Inherits BaseController

    Private vBLL As PolimeroBLL
    Private vColorBLL As ColorBLL
    Sub New()
        Me.vBLL = New PolimeroBLL()
        Me.vColorBLL = New ColorBLL()
    End Sub

    '
    ' GET: /Polimero
    <Autorizar(Roles:="ListarPolimeros")>
    Function Index() As ActionResult
        Dim vLista As List(Of Polimero) = Me.vBLL.Listar()
        Return View(vLista)
    End Function

    <Autorizar(Roles:="ConsultarPolimero")>
    Function Detalle(ByVal id As Integer) As ActionResult
        Dim vPolimero As EE.Polimero = Me.vBLL.ConsultarPorId(id)
        Return View(vPolimero)
    End Function

    <Autorizar(Roles:="CrearPolimero")>
    Function Crear() As ActionResult
        ViewBag.Colores = Me.vColorBLL.Listar()
        Return View()
    End Function

    <Autorizar(Roles:="CrearPolimero")>
    <HttpPost()>
    Function Crear(ByVal entidad As Polimero) As ActionResult
        ModelState.Item("Color.Nombre").Errors.Clear()
        ModelState.Item("Color.Codigo").Errors.Clear()
        If ModelState.IsValid Then
            Me.vBLL.Crear(entidad)
            Return RedirectToAction("Index")
        End If
        ViewBag.Colores = Me.vColorBLL.Listar()
        Return View(entidad)
    End Function

    <Autorizar(Roles:="EditarPolimero")>
    Function Editar(ByVal id As Integer) As ActionResult
        Dim entidad As Polimero = Me.vBLL.ConsultarPorId(id)

        ViewBag.Colores = Me.vColorBLL.Listar()

        Return View(entidad)
    End Function

    <Autorizar(Roles:="EditarPolimero")>
    <HttpPost()> _
    Function Editar(ByVal id As Integer, ByVal entidad As Polimero) As ActionResult
        ModelState.Item("Color.Nombre").Errors.Clear()
        ModelState.Item("Color.Codigo").Errors.Clear()
        If ModelState.IsValid Then
            Me.vBLL.Editar(entidad)
            Return RedirectToAction("Index")
        End If

        ViewBag.Colores = Me.vColorBLL.Listar()
        Return View(entidad)
    End Function

    <Autorizar(Roles:="EliminarPolimero")>
    Function Eliminar(ByVal id As Integer) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Eliminar(id)
        End If
        Return RedirectToAction("Index")
    End Function

End Class