Imports System.ComponentModel.DataAnnotations
Imports EE
Public Class SuscribirseViewModel

    Private vEmail As String
    <Required(ErrorMessage:="Campo requerido"), Display(Name:="Email")>
    <StringLength(50, ErrorMessage:="Se ha superado la longitud permitida de 50 caracteres.")>
    <EmailAddress(ErrorMessage:="Formato incorrecto")>
    Public Property Email() As String
        Get
            Return vEmail
        End Get
        Set(ByVal value As String)
            vEmail = value
        End Set
    End Property

    Private vListaCategorias As New List(Of Integer)
    <ListRequired(ErrorMessage:="Campo requerido"), Display(Name:="Categorias de interés")>
    Public Property ListaCategoriasSeleccionadas() As List(Of Integer)
        Get
            Return vListaCategorias
        End Get
        Set(ByVal value As List(Of Integer))
            vListaCategorias = value
        End Set
    End Property

End Class