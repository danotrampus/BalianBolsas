Imports BLL
Imports EE
Public Class ManijaController
    Inherits BaseController

    Private vBLL As ManijaBLL
    Private vColorBLL As ColorBLL
    Sub New()
        Me.vBLL = New ManijaBLL()
        Me.vColorBLL = New ColorBLL()
    End Sub

    '
    ' GET: /Manija
    <Autorizar(Roles:="ListarManijas")>
    Function Index() As ActionResult
        Dim vLista As List(Of Manija) = Me.vBLL.Listar()
        Return View(vLista)
    End Function

    <Autorizar(Roles:="ConsultarManija")>
    Function Detalle(ByVal id As Integer) As ActionResult
        Dim vManija As EE.Manija = Me.vBLL.ConsultarPorId(id)
        Return View(vManija)
    End Function

    <Autorizar(Roles:="CrearManija")>
    Function Crear() As ActionResult
        ViewBag.Colores = Me.vColorBLL.Listar()
        Return View()
    End Function

    <Autorizar(Roles:="CrearManija")>
    <HttpPost()>
    Function Crear(ByVal entidad As Manija) As ActionResult
        ModelState.Item("Color.Nombre").Errors.Clear()
        ModelState.Item("Color.Codigo").Errors.Clear()
        If ModelState.IsValid Then
            Me.vBLL.Crear(entidad)
            Return RedirectToAction("Index")
        End If
        ViewBag.Colores = Me.vColorBLL.Listar()
        Return View(entidad)
    End Function

    <Autorizar(Roles:="EditarManija")>
    Function Editar(ByVal id As Integer) As ActionResult
        Dim entidad As Manija = Me.vBLL.ConsultarPorId(id)

        ViewBag.Colores = Me.vColorBLL.Listar()

        Return View(entidad)
    End Function

    <Autorizar(Roles:="EditarManija")>
    <HttpPost()> _
    Function Editar(ByVal id As Integer, ByVal entidad As Manija) As ActionResult
        ModelState.Item("Color.Nombre").Errors.Clear()
        ModelState.Item("Color.Codigo").Errors.Clear()
        If ModelState.IsValid Then
            Me.vBLL.Editar(entidad)
            Return RedirectToAction("Index")
        End If

        ViewBag.Colores = Me.vColorBLL.Listar()
        Return View(entidad)
    End Function

    <Autorizar(Roles:="EliminarManija")>
    Function Eliminar(ByVal id As Integer) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Eliminar(id)
        End If
        Return RedirectToAction("Index")
    End Function

End Class