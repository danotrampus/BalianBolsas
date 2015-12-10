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

    Function ListadoInformeGanancias() As ActionResult
        Return View()
    End Function

    Function ObtenerGananciasAjax() As ActionResult
        Dim desdeDate As Date = Date.ParseExact(Request("desde"), "dd/MM/yyyy", Nothing)
        Dim hastaDate As Date = Date.ParseExact(Request("hasta"), "dd/MM/yyyy", Nothing)
        Dim vLista As List(Of InformeGanancias) = Me.vBLL.ObtenerGanancias(desdeDate, hastaDate)
        Return Json(vLista.ToArray(), JsonRequestBehavior.AllowGet)
    End Function

End Class