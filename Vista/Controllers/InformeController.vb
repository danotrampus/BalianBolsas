Imports EE
Imports BLL
Public Class InformeController
    Inherits BaseController

    Private vBLL As InformeBLL

    Sub New()
        Me.vBLL = New InformeBLL
    End Sub

    Function ListadoInformeTiempoRespuesta() As ActionResult
        Return View(Me.vBLL.ListarInformeTiempoRespuesta())
    End Function

End Class