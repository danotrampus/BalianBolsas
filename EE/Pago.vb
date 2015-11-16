Public Class Pago
    Inherits Movimiento

    Public Overrides Function ObtenerImporte() As Double
        Return Me.Importe
    End Function

    Public Overrides Function ObtenerTipo() As String
        Return "Pago " + Me.TipoComprobante
    End Function
End Class
