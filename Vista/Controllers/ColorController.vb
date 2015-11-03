Imports BLL
Imports EE
Public Class ColorController
    Inherits BaseController

    Private vBLL As ColorBLL
    Private vColorBLL As ColorBLL
    Sub New()
        Me.vBLL = New ColorBLL()
        Me.vColorBLL = New ColorBLL()
    End Sub

    '
    ' GET: /Color
    <Autorizar(Roles:="ListarColores")>
    Function Index() As ActionResult
        Dim vLista As List(Of Color) = Me.vBLL.Listar()
        Return View(vLista)
    End Function

    <Autorizar(Roles:="ConsultarColor")>
    Function Detalle(ByVal id As Integer) As ActionResult
        Dim vColor As EE.Color = Me.vBLL.ConsultarPorId(id)
        Return View(vColor)
    End Function

    <Autorizar(Roles:="CrearColor")>
    Function Crear() As ActionResult
        ViewBag.Colores = Me.vColorBLL.Listar()
        Return View()
    End Function

    <Autorizar(Roles:="CrearColor")>
    <HttpPost()>
    Function Crear(ByVal entidad As Color) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Crear(entidad)
            Return RedirectToAction("Index")
        End If
        ViewBag.Colores = Me.vColorBLL.Listar()
        Return View(entidad)
    End Function

    <Autorizar(Roles:="EditarColor")>
    Function Editar(ByVal id As Integer) As ActionResult
        Dim entidad As Color = Me.vBLL.ConsultarPorId(id)

        ViewBag.Colores = Me.vColorBLL.Listar()

        Return View(entidad)
    End Function

    <Autorizar(Roles:="EditarColor")>
    <HttpPost()> _
    Function Editar(ByVal id As Integer, ByVal entidad As Color) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Editar(entidad)
            Return RedirectToAction("Index")
        End If

        ViewBag.Colores = Me.vColorBLL.Listar()
        Return View(entidad)
    End Function

    <Autorizar(Roles:="EliminarColor")>
    Function Eliminar(ByVal id As Integer) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Eliminar(id)
        End If
        Return RedirectToAction("Index")
    End Function

End Class