Imports System.ComponentModel.DataAnnotations
Public Class NovedadViewModel

    Private vId As Integer
    Public Property Id() As Integer
        Get
            Return vId
        End Get
        Set(ByVal value As Integer)
            vId = value
        End Set
    End Property

    Private vTitulo As String
    <Required(ErrorMessage:="Campo requerido"), Display(Name:="Título")>
    <StringLength(50, ErrorMessage:="Se ha superado la longitud permitida de 50 caracteres.")>
    Public Property Titulo() As String
        Get
            Return vTitulo
        End Get
        Set(ByVal value As String)
            vTitulo = value
        End Set
    End Property

    Private vContenido As String
    <Required(ErrorMessage:="Campo requerido"), Display(Name:="Contenido"), AllowHtml()>
    Public Property Contenido() As String
        Get
            Return vContenido
        End Get
        Set(ByVal value As String)
            vContenido = value
        End Set
    End Property

    Private vCategoriaId As Integer
    <Required(ErrorMessage:="Campo requerido"), Display(Name:="Categoría")>
    Public Property CategoriaId() As Integer
        Get
            Return vCategoriaId
        End Get
        Set(ByVal value As Integer)
            vCategoriaId = value
        End Set
    End Property

    Private vTipo As String
    <Required(ErrorMessage:="Campo requerido")>
    Public Property Tipo() As String
        Get
            Return vTipo
        End Get
        Set(ByVal value As String)
            vTipo = value
        End Set
    End Property

End Class