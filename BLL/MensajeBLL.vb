Imports MPP
Imports EE
Imports Servicios

Public Class MensajeBLL

    Private vMapper As MensajeMapper

    Sub New()
        Me.vMapper = New MensajeMapper
    End Sub

    Public Function Listar(ByVal grupo As String) As List(Of Mensaje)
        Return vMapper.Listar(grupo)
    End Function

    Public Function Crear(ByVal m As Mensaje) As Boolean
        Return vMapper.Crear(m)
    End Function

End Class
