Imports System.ComponentModel.DataAnnotations
Public Class Novedad

    Private vId As Integer
    Public Property Id() As Integer
        Get
            Return vId
        End Get
        Set(ByVal value As Integer)
            vId = value
        End Set
    End Property

    Private vFechaCreacion As Date
    <Required(ErrorMessage:="Campo requerido"), Display(Name:="Fecha Creación"), DisplayFormat(DataFormatString:="{0:dd/MM/yyyy}")>
    Public Property FechaCreacion() As Date
        Get
            Return vFechaCreacion
        End Get
        Set(ByVal value As Date)
            vFechaCreacion = value
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
    <Required(ErrorMessage:="Campo requerido"), Display(Name:="Contenido")>
    Public Property Contenido() As String
        Get
            Return vContenido
        End Get
        Set(ByVal value As String)
            vContenido = value
        End Set
    End Property

    Private vTipo As String
    Public Property Tipo() As String
        Get
            Return vTipo
        End Get
        Set(ByVal value As String)
            vTipo = value
        End Set
    End Property

    Private vCategoria As New Categoria
    Public Property Categoria() As Categoria
        Get
            Return vCategoria
        End Get
        Set(ByVal value As Categoria)
            vCategoria = value
        End Set
    End Property

End Class
