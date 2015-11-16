Imports System.ComponentModel.DataAnnotations
Public Class Categoria

    Private vId As Integer
    Public Property Id() As Integer
        Get
            Return vId
        End Get
        Set(ByVal value As Integer)
            vId = value
        End Set
    End Property

    Private vNombre As String
    <Required(ErrorMessage:="Campo requerido"), Display(Name:="Categoría")>
    <StringLength(50, ErrorMessage:="Se ha superado la longitud permitida de 50 caracteres.")>
    Public Property Nombre() As String
        Get
            Return vNombre
        End Get
        Set(ByVal value As String)
            vNombre = value
        End Set
    End Property

End Class