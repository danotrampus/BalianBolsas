Imports System.ComponentModel.DataAnnotations
Public Class Contacto

    Private vId As Integer
    Public Property Id() As Integer
        Get
            Return vId
        End Get
        Set(ByVal value As Integer)
            vId = value
        End Set
    End Property

    Private vFechaHora As DateTime
    Public Property FechaHora() As DateTime
        Get
            Return vFechaHora
        End Get
        Set(ByVal value As DateTime)
            vFechaHora = value
        End Set
    End Property

    Private vNombreApellido As String
    <Required(ErrorMessage:="Campo requerido"), Display(Name:="Nombre y Apellido")>
    <StringLength(50, ErrorMessage:="Se ha superado la longitud permitida de 50 caracteres.")>
    Public Property NombreApellido() As String
        Get
            Return vNombreApellido
        End Get
        Set(ByVal value As String)
            vNombreApellido = value
        End Set
    End Property

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

    Private vAsunto As String
    <Required(ErrorMessage:="Campo requerido"), Display(Name:="Asunto")>
    <StringLength(50, ErrorMessage:="Se ha superado la longitud permitida de 50 caracteres.")>
    Public Property Asunto() As String
        Get
            Return vAsunto
        End Get
        Set(ByVal value As String)
            vAsunto = value
        End Set
    End Property

    Private vMensaje As String
    <Required(ErrorMessage:="Campo requerido"), Display(Name:="Mensaje")>
    Public Property Mensaje() As String
        Get
            Return vMensaje
        End Get
        Set(ByVal value As String)
            vMensaje = value
        End Set
    End Property

End Class
