Public Class NotaCredito
    Inherits Movimiento

    Private vDireccion As New Direccion
    Public Property Direccion() As Direccion
        Get
            Return vDireccion
        End Get
        Set(ByVal value As Direccion)
            vDireccion = value
        End Set
    End Property

    Public Overrides Function ObtenerImporte() As Double
        Return Me.Importe
    End Function

    Public Overrides Function ObtenerTipo() As String
        Return "Nota de Crédito " + Me.TipoComprobante
    End Function

    Public Overrides Function ObtenerTipoSinFormato() As String
        Return "NotaCredito"
    End Function
End Class