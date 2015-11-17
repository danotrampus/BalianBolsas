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

End Class
