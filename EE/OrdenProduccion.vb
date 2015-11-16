Public Class OrdenProduccion

    Private vId As Integer
    Public Property Id() As Integer
        Get
            Return vId
        End Get
        Set(ByVal value As Integer)
            vId = value
        End Set
    End Property

    Private vTipo As String
    Public Property Tipo() As String
        Get
            Return vTipo
        End Get
        Set(ByVal value As String)
            vTipo = value
        End Set
    End Property

    Private vFechaInicio As DateTime
    Public Property FechaInicio() As DateTime
        Get
            Return vFechaInicio
        End Get
        Set(ByVal value As DateTime)
            vFechaInicio = value
        End Set
    End Property

    Private vFechaFin As DateTime
    Public Property FechaFin() As DateTime
        Get
            Return vFechaFin
        End Get
        Set(ByVal value As DateTime)
            vFechaFin = value
        End Set
    End Property

    Private vCantidad As Integer
    Public Property Cantidad() As Integer
        Get
            Return vCantidad
        End Get
        Set(ByVal value As Integer)
            vCantidad = value
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

    Private vEstado As String
    Public Property Estado() As String
        Get
            Return vEstado
        End Get
        Set(ByVal value As String)
            vEstado = value
        End Set
    End Property

    Private vPedido As New Pedido
    Public Property Pedido() As Pedido
        Get
            Return vPedido
        End Get
        Set(ByVal value As Pedido)
            vPedido = value
        End Set
    End Property

    Private vProducto As Producto
    Public Property Producto() As Producto
        Get
            Return vProducto
        End Get
        Set(ByVal value As Producto)
            vProducto = value
        End Set
    End Property

End Class
