Imports MPP
Imports EE
Imports Servicios
Public Class MovimientoBLL

    Private vMapper As MovimientoMapper
    Sub New()
        Me.vMapper = New MovimientoMapper()
    End Sub

    Public Function Crear(ByVal entidad As Movimiento) As Boolean
        Return vMapper.Crear(entidad)
    End Function

    Public Function SaldoAFavorPorCliente(ByVal clienteId As Integer) As Double
        Return vMapper.SaldoAFavorPorCliente(clienteId)
    End Function

    Public Function Compensar(ByVal clienteId As Integer, ByVal importe As Double) As Boolean
        Return vMapper.Compensar(clienteId, importe)
    End Function

End Class