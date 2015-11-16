Public Class Factura
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

    Private vCuit As String
    Public Property Cuit() As String
        Get
            Return vCuit
        End Get
        Set(ByVal value As String)
            vCuit = value
        End Set
    End Property

    Public Overrides Function ObtenerImporte() As Double
        Return Me.Importe * -1
    End Function

    Public Overrides Function ObtenerTipo() As String
        Return "Factura " + Me.TipoComprobante
    End Function

    Public Overrides Function ObtenerTipoSinFormato() As String
        Return "Factura"
    End Function
End Class