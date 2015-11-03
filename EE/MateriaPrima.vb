Imports System.ComponentModel.DataAnnotations
Public Class MateriaPrima

    Private vId As Integer
    <Display(Name:="Materia Prima")>
    Public Property Id() As Integer
        Get
            Return vId
        End Get
        Set(ByVal value As Integer)
            vId = value
        End Set
    End Property

    Private vNombre As String
    <Required(ErrorMessage:="Campo requerido")>
    Public Property Nombre() As String
        Get
            Return vNombre
        End Get
        Set(ByVal value As String)
            vNombre = value
        End Set
    End Property

    Private vPrecio As Double
    <Required(ErrorMessage:="Campo requerido"), RegularExpression("^(\d{1,16}(\,\d{0,3})?)$", ErrorMessage:="Formato incorrecto")>
    Public Property Precio() As Double
        Get
            Return vPrecio
        End Get
        Set(ByVal value As Double)
            vPrecio = value
        End Set
    End Property

    Private vColor As New Color
    <Required(ErrorMessage:="Campo requerido")>
    Public Property Color() As Color
        Get
            Return vColor
        End Get
        Set(ByVal value As Color)
            vColor = value
        End Set
    End Property

End Class
