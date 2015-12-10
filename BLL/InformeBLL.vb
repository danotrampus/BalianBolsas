Imports EE
Imports MPP
Public Class InformeBLL

    Private vMapper As InformeMapper

    Sub New()
        Me.vMapper = New InformeMapper
    End Sub

    Public Function ListarInformeTiempoRespuesta() As InformeTiempoRespuesta
        Return Me.vMapper.ListarInformeTiempoRespuesta()
    End Function

    Function ObtenerGanancias(ByVal desde As Date, ByVal hasta As Date) As List(Of InformeGanancias)
        Return Me.vMapper.ObtenerGanancias(desde, hasta)
    End Function

End Class
