Imports MPP
Imports EE
Imports Servicios
Public Class PedidoBLL

    Private vMapper As PedidoMapper
    Sub New()
        Me.vMapper = New PedidoMapper()
    End Sub

    Public Function Listar() As List(Of Pedido)
        Return Me.vMapper.Listar()
    End Function

    Public Function ConsutarPorId(ByVal id As Integer) As Pedido
        Return Me.vMapper.ConsutarPorId(id)
    End Function

    Public Function Crear(ByVal entidad As Pedido) As Boolean
        Return vMapper.Crear(entidad)
    End Function

End Class
