Imports System.ComponentModel.DataAnnotations
Public Class Comentario

    Private vId As Integer
    Public Property Id() As Integer
        Get
            Return vId
        End Get
        Set(ByVal value As Integer)
            vId = value
        End Set
    End Property

    Private vValoracion As Integer
    <Required(ErrorMessage:="Campo requerido")>
    Public Property Valoracion() As Integer
        Get
            Return vValoracion
        End Get
        Set(ByVal value As Integer)
            vValoracion = value
        End Set
    End Property

    Private vMensaje As String
    <Required(ErrorMessage:="Campo requerido")>
    Public Property Mensaje() As String
        Get
            Return vMensaje
        End Get
        Set(ByVal value As String)
            vMensaje = value
        End Set
    End Property

    Private vProducto As New Bolsa
    Public Property Producto() As Bolsa
        Get
            Return vProducto
        End Get
        Set(ByVal value As Bolsa)
            vProducto = value
        End Set
    End Property

End Class
