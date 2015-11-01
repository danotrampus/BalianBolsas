Imports System.ComponentModel.DataAnnotations
Public Class Suscriptor

    Private vId As Integer
    Public Property Id() As Integer
        Get
            Return vId
        End Get
        Set(ByVal value As Integer)
            vId = value
        End Set
    End Property

    Private vEmail As String
    Public Property Email() As String
        Get
            Return vEmail
        End Get
        Set(ByVal value As String)
            vEmail = value
        End Set
    End Property

    Private vListaCategorias As New List(Of Categoria)
    Public Property ListaCategorias() As List(Of Categoria)
        Get
            Return vListaCategorias
        End Get
        Set(ByVal value As List(Of Categoria))
            vListaCategorias = value
        End Set
    End Property

End Class
