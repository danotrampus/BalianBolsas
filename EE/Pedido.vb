Public Class Pedido

    Private vId As Integer
    Public Property Id() As Integer
        Get
            Return vId
        End Get
        Set(ByVal value As Integer)
            vId = value
        End Set
    End Property

    Private vFechaInicio As Date
    Public Property FechaInicio() As Date
        Get
            Return vFechaInicio
        End Get
        Set(ByVal value As Date)
            vFechaInicio = value
        End Set
    End Property

    Private vFechaFin As Date
    Public Property FechaFin() As Date
        Get
            Return vFechaFin
        End Get
        Set(ByVal value As Date)
            vFechaFin = value
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

    Private vEstado As String
    Public Property Estado() As String
        Get
            Return vEstado
        End Get
        Set(ByVal value As String)
            vEstado = value
        End Set
    End Property

    Private vUsuario As Usuario
    Public Property Usuario() As Usuario
        Get
            Return vUsuario
        End Get
        Set(ByVal value As Usuario)
            vUsuario = value
        End Set
    End Property

    Private vListaDetalles As New List(Of DetallePedido)
    Public Property ListaDetalles() As List(Of DetallePedido)
        Get
            Return vListaDetalles
        End Get
        Set(ByVal value As List(Of DetallePedido))
            vListaDetalles = value
        End Set
    End Property

End Class
