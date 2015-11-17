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

    Public Function Consultar(ByVal tipo As String, ByVal numero As Integer, ByVal tipoComprobante As String) As Movimiento
        Return vMapper.Consultar(tipo, numero, tipoComprobante)
    End Function

    Public Function Listar() As List(Of Movimiento)
        Return vMapper.Listar()
    End Function

End Class