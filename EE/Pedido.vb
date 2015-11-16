Imports System.ComponentModel.DataAnnotations
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

    Private vFechaInicio As DateTime
    <Required(ErrorMessage:="Campo requerido"), Display(Name:="Fecha Inicio"), DisplayFormat(ApplyFormatInEditMode:=True, DataFormatString:="{0:dd/MM/yyyy HH:mm}")>
    Public Property FechaInicio() As DateTime
        Get
            Return vFechaInicio
        End Get
        Set(ByVal value As DateTime)
            vFechaInicio = value
        End Set
    End Property

    Private vFechaFin As DateTime
    <Required(ErrorMessage:="Campo requerido"), Display(Name:="Fecha Fin"), DisplayFormat(ApplyFormatInEditMode:=True, DataFormatString:="{0:dd/MM/yyyy}")>
    Public Property FechaFin() As DateTime
        Get
            Return vFechaFin
        End Get
        Set(ByVal value As DateTime)
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

    Private vUsuario As New Usuario
    Public Property Usuario() As Usuario
        Get
            Return vUsuario
        End Get
        Set(ByVal value As Usuario)
            vUsuario = value
        End Set
    End Property

    Private vDireccion As New Direccion
    Public Property Direccion() As Direccion
        Get
            Return vDireccion
        End Get
        Set(ByVal value As Direccion)
            vDireccion = value
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

    Public ReadOnly Property Iva() As Double
        Get
            Return Me.Importe * 0.21
        End Get
    End Property

    Public ReadOnly Property Subtotal() As Double
        Get
            Return Math.Round(Me.Importe - Me.Iva, 2)
        End Get
    End Property

End Class
