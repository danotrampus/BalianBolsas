Imports System.ComponentModel.DataAnnotations
Public Class DetallePedido

    Private vId As Integer
    Public Property Id() As Integer
        Get
            Return vId
        End Get
        Set(ByVal value As Integer)
            vId = value
        End Set
    End Property

    Private vCantidad As Integer
    <Required(ErrorMessage:="Campo requerido"), RegularExpression("^\d{1,16}?$", ErrorMessage:="Formato incorrecto")>
    Public Property Cantidad() As Integer
        Get
            Return vCantidad
        End Get
        Set(ByVal value As Integer)
            vCantidad = value
        End Set
    End Property

    Private vPrecio As Double
    Public Property Precio() As Double
        Get
            Return vPrecio
        End Get
        Set(ByVal value As Double)
            vPrecio = value
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

    Public ReadOnly Property Total() As Double
        Get
            If Me.Producto IsNot Nothing Then
                Return Math.Round(Me.Cantidad * Me.Producto.CalcularPrecio(), 3)
            End If
            Return 0
        End Get
    End Property
End Class
