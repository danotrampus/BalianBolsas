Public Class NotaDebito
    Inherits Movimiento

    Private vDireccion As Direccion
    Public Property Direccion() As Direccion
        Get
            Return vDireccion
        End Get
        Set(ByVal value As Direccion)
            vDireccion = value
        End Set
    End Property

    Public Overrides Function ObtenerImporte() As Double
        Return Me.Importe * -1
    End Function

    Public Overrides Function ObtenerTipo() As String
        Return "Nota de Débito " + Me.TipoComprobante
    End Function

    Public Overrides Function ObtenerTipoSinFormato() As String
        Return "NotaDebito"
    End Function
End Class