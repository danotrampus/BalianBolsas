Imports BLL
Imports EE
Public Class EncuestaController
    Inherits BaseController

    Private vBLL As EncuestaBLL
    Sub New()
        Me.vBLL = New EncuestaBLL()
    End Sub

    '
    ' GET: /Novedad
    <Autorizar(Roles:="ListarEncuestas")>
    Function Index() As ActionResult
        Dim vLista As List(Of Encuesta) = Me.vBLL.Listar()
        Return View(vLista)
    End Function

    <Autorizar(Roles:="CrearEncuesta")>
    Function Crear() As ActionResult
        Return View()
    End Function

    <Autorizar(Roles:="CrearEncuesta")>
    <HttpPost()>
    Function Crear(ByVal e As Encuesta) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Crear(e)
            Return RedirectToAction("Index")
        End If

        Return View(e)
    End Function

End Class