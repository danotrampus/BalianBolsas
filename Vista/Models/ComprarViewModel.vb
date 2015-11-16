Imports System.ComponentModel.DataAnnotations
Public Class ComprarViewModel

    Private vDireccionCalle As String
    <Required(ErrorMessage:="Campo requerido"), StringLength(50, ErrorMessage:="Se ha superado la longitud permitida de 50 caracteres.")>
    Public Property DireccionCalle() As String
        Get
            Return vDireccionCalle
        End Get
        Set(ByVal value As String)
            vDireccionCalle = value
        End Set
    End Property

    Private vDireccionNumero As String
    <Required(ErrorMessage:="Campo requerido"), StringLength(50, ErrorMessage:="Se ha superado la longitud permitida de 50 caracteres.")>
    Public Property DireccionNumero() As String
        Get
            Return vDireccionNumero
        End Get
        Set(ByVal value As String)
            vDireccionNumero = value
        End Set
    End Property

    Private vDireccionLocalidad As String
    <Required(ErrorMessage:="Campo requerido"), StringLength(50, ErrorMessage:="Se ha superado la longitud permitida de 50 caracteres.")>
    Public Property DireccionLocalidad() As String
        Get
            Return vDireccionLocalidad
        End Get
        Set(ByVal value As String)
            vDireccionLocalidad = value
        End Set
    End Property

    Private vDireccionDptoPiso As String
    <Required(ErrorMessage:="Campo requerido"), StringLength(50, ErrorMessage:="Se ha superado la longitud permitida de 50 caracteres.")>
    Public Property DireccionDptoPiso() As String
        Get
            Return vDireccionDptoPiso
        End Get
        Set(ByVal value As String)
            vDireccionDptoPiso = value
        End Set
    End Property

    Private vClienteCondicion As String
    <Required(ErrorMessage:="Campo requerido")>
    Public Property ClienteCondicion() As String
        Get
            Return vClienteCondicion
        End Get
        Set(ByVal value As String)
            vClienteCondicion = value
        End Set
    End Property

    Private vClienteCuit As String
    <Required(ErrorMessage:="Campo requerido"), RegularExpression("^\d{2}\-\d{8}\-\d{1}$", ErrorMessage:="Formato incorrecto")>
    Public Property ClienteCuit() As String
        Get
            Return vClienteCuit
        End Get
        Set(ByVal value As String)
            vClienteCuit = value
        End Set
    End Property

    Private vClienteNombre As String
    <Required(ErrorMessage:="Campo requerido"), StringLength(50, ErrorMessage:="Se ha superado la longitud permitida de 50 caracteres.")>
    Public Property ClienteNombre() As String
        Get
            Return vClienteNombre
        End Get
        Set(ByVal value As String)
            vClienteNombre = value
        End Set
    End Property

    Private vClienteTelefono As String
    <Required(ErrorMessage:="Campo requerido"), StringLength(50, ErrorMessage:="Se ha superado la longitud permitida de 50 caracteres.")>
    Public Property ClienteTelefono() As String
        Get
            Return vClienteTelefono
        End Get
        Set(ByVal value As String)
            vClienteTelefono = value
        End Set
    End Property

    Private vTarjetaTitular As String
    <Required(ErrorMessage:="Campo requerido")>
    Public Property TarjetaTitular() As String
        Get
            Return vTarjetaTitular
        End Get
        Set(ByVal value As String)
            vTarjetaTitular = value
        End Set
    End Property

    Private vTarjetaNombre As String
    <Required(ErrorMessage:="Campo requerido")>
    Public Property TarjetaNombre() As String
        Get
            Return vTarjetaNombre
        End Get
        Set(ByVal value As String)
            vTarjetaNombre = value
        End Set
    End Property

    Private vTarjetaCuotas As String
    <Required(ErrorMessage:="Campo requerido")>
    Public Property TarjetaCuotas() As String
        Get
            Return vTarjetaCuotas
        End Get
        Set(ByVal value As String)
            vTarjetaCuotas = value
        End Set
    End Property

    Private vTarjetaNumero As String
    <Required(ErrorMessage:="Campo requerido"), RegularExpression("^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14}|3[47][0-9]{13})$", ErrorMessage:="Formato incorrecto")>
    Public Property TarjetaNumero() As String
        Get
            Return vTarjetaNumero
        End Get
        Set(ByVal value As String)
            vTarjetaNumero = value
        End Set
    End Property

    Private vTarjetaCodigoSeguridad As String
    <Required(ErrorMessage:="Campo requerido"), RegularExpression("^\d{3}$", ErrorMessage:="Formato incorrecto")>
    Public Property TarjetaCodigoSeguridad() As String
        Get
            Return vTarjetaCodigoSeguridad
        End Get
        Set(ByVal value As String)
            vTarjetaCodigoSeguridad = value
        End Set
    End Property

    Private vTarjetaFechaVencimiento As Date = Now.Date
    <Required(ErrorMessage:="Campo requerido"), DisplayFormat(DataFormatString:="{0:MM/yyyy}")>
    Public Property TarjetaFechaVencimiento() As Date
        Get
            Return vTarjetaFechaVencimiento
        End Get
        Set(ByVal value As Date)
            vTarjetaFechaVencimiento = value
        End Set
    End Property

    Private vFacturacionTipoComprobante As String
    Public Property FacturacionTipoComprobante() As String
        Get
            Return vFacturacionTipoComprobante
        End Get
        Set(ByVal value As String)
            vFacturacionTipoComprobante = value
        End Set
    End Property

    Private vPedido As EE.Pedido
    Public Property Pedido() As EE.Pedido
        Get
            Return vPedido
        End Get
        Set(ByVal value As EE.Pedido)
            vPedido = value
        End Set
    End Property

    Private vSaldoAFavor As Double
    Public Property SaldoAFavor() As Double
        Get
            Return vSaldoAFavor
        End Get
        Set(ByVal value As Double)
            vSaldoAFavor = value
        End Set
    End Property

    Private vPagoConNC As Boolean
    Public Property PagoConNC() As Boolean
        Get
            Return vPagoConNC
        End Get
        Set(ByVal value As Boolean)
            vPagoConNC = value
        End Set
    End Property

    Private vTarjetaImporte As Double
    Public Property TarjetaImporte() As Double
        Get
            Return vTarjetaImporte
        End Get
        Set(ByVal value As Double)
            vTarjetaImporte = value
        End Set
    End Property

End Class
