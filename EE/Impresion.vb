Imports System.ComponentModel.DataAnnotations
Public Class Impresion

    Private vId As Integer
    <Display(Name:="Impresion")>
    Public Property Id() As Integer
        Get
            Return vId
        End Get
        Set(ByVal value As Integer)
            vId = value
        End Set
    End Property

    Private vPrecio As Double
    <Required(ErrorMessage:="Campo requerido")>
    Public Property Precio() As Double
        Get
            Return vPrecio
        End Get
        Set(ByVal value As Double)
            vPrecio = value
        End Set
    End Property

    Private vCantidadColores As Integer
    <Required(ErrorMessage:="Campo requerido")>
    Public Property CantidadColores() As Integer
        Get
            Return vCantidadColores
        End Get
        Set(ByVal value As Integer)
            vCantidadColores = value
        End Set
    End Property

    Private vTratado As String
    <Required(ErrorMessage:="Campo requerido")>
    Public Property Tratado() As String
        Get
            Return vTratado
        End Get
        Set(ByVal value As String)
            vTratado = value
        End Set
    End Property

    Public ReadOnly Property Nombre() As String
        Get
            Return Me.Tratado + " - " + Me.CantidadColores.ToString() + " color/es"
        End Get
    End Property

End Class
