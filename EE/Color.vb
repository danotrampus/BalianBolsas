Imports System.ComponentModel.DataAnnotations
Public Class Color

    Private vId As Integer
    <Required(ErrorMessage:="Campo requerido"), Display(Name:="Color")>
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

    Private vCodigo As String
    <Required(ErrorMessage:="Campo requerido")>
    Public Property Codigo() As String
        Get
            Return vCodigo
        End Get
        Set(ByVal value As String)
            vCodigo = value
        End Set
    End Property

End Class
