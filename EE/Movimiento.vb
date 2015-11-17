Public MustInherit Class Movimiento

    Private vNumero As Integer
    Public Property Numero() As Integer
        Get
            Return vNumero
        End Get
        Set(ByVal value As Integer)
            vNumero = value
        End Set
    End Property

    Private vTipoComprobante As String
    Public Property TipoComprobante() As String
        Get
            Return vTipoComprobante
        End Get
        Set(ByVal value As String)
            vTipoComprobante = value
        End Set
    End Property

    Private vObservacion As String
    Public Property Observacion() As String
        Get
            Return vObservacion
        End Get
        Set(ByVal value As String)
            vObservacion = value
        End Set
    End Property

    Private vImporte As Double
    Public Property Importe() As Double
        Get
            Return vImporte
        End Get
        Set(ByVal value As Double)
            vImporte = value
        End Set
    End Property

    Private vFecha As Date
    Public Property Fecha() As Date
        Get
            Return vFecha
        End Get
        Set(ByVal value As Date)
            vFecha = value
        End Set
    End Property

    Private vUsuario As New Usuario
    Public Property Usuario() As Usuario
        Get
            Return vUsuario
        End Get
        Set(ByVal value As Usuario)
            vUsuario = value
        End Set
    End Property

    Private vListaDetalles As New List(Of DetalleMovimiento)
    Public Property ListaDetalles() As List(Of DetalleMovimiento)
        Get
            Return vListaDetalles
        End Get
        Set(ByVal value As List(Of DetalleMovimiento))
            vListaDetalles = value
        End Set
    End Property

    Public ReadOnly Property Iva() As Double
        Get
            Return Me.Importe * 0.21
        End Get
    End Property

    Public ReadOnly Property Subtotal() As Double
        Get
            Return Me.Importe - Me.Iva
        End Get
    End Property

    Public MustOverride Function ObtenerImporte() As Double

    Public MustOverride Function ObtenerTipo() As String

    Public MustOverride Function ObtenerTipoSinFormato() As String

    Public MustOverride Function ObtenerSoloTipo() As String

End Class