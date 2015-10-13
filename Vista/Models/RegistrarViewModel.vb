Imports System.ComponentModel.DataAnnotations
Public Class RegistrarViewModel

    Private vNombre As String
    <Required(ErrorMessage:="Campo requerido"), Display(Name:="Nombre")>
    <StringLength(50, ErrorMessage:="Longitud máxima de 50 caracteres")>
    Public Property Nombre() As String
        Get
            Return vNombre
        End Get
        Set(ByVal value As String)
            vNombre = value
        End Set
    End Property

    Private vApellido As String
    <Required(ErrorMessage:="Campo requerido"), Display(Name:="Apellido")>
    <StringLength(50, ErrorMessage:="Longitud máxima de 50 caracteres")>
    Public Property Apellido() As String
        Get
            Return vApellido
        End Get
        Set(ByVal value As String)
            vApellido = value
        End Set
    End Property

    Private vClave As String
    <Required(ErrorMessage:="Campo requerido"), Display(Name:="Contraseña")>
    <StringLength(50, ErrorMessage:="Longitud máxima de 50 caracteres")>
    Public Property Clave() As String
        Get
            Return vClave
        End Get
        Set(ByVal value As String)
            vClave = value
        End Set
    End Property

    Private vConfirmaClave As String
    <Compare("Clave", ErrorMessage:="Las contraseñas deben coincidir"), Display(Name:="Repetir Contraseña")>
    Public Property ConfirmaClave() As String
        Get
            Return vConfirmaClave
        End Get
        Set(ByVal value As String)
            vConfirmaClave = value
        End Set
    End Property

    Private vEmail As String
    <Required(ErrorMessage:="Campo requerido"), Display(Name:="Email")>
    <StringLength(50, ErrorMessage:="Longitud máxima de 50 caracteres")>
    <EmailAddress(ErrorMessage:="Formato incorrecto")>
    Public Property Email() As String
        Get
            Return vEmail
        End Get
        Set(ByVal value As String)
            vEmail = value
        End Set
    End Property

    Private vNombreUsuario As String
    <Required(ErrorMessage:="Campo requerido"), Display(Name:="Nombre de usuario")>
    <StringLength(50, ErrorMessage:="Longitud máxima de 50 caracteres")>
    Public Property NombreUsuario() As String
        Get
            Return vNombreUsuario
        End Get
        Set(ByVal value As String)
            vNombreUsuario = value
        End Set
    End Property

    Private vAceptar As Boolean
    <Range(GetType(Boolean), "true", "true", ErrorMessage:="Debe aceptar para continuar")>
    Public Property Aceptar() As Boolean
        Get
            Return vAceptar
        End Get
        Set(ByVal value As Boolean)
            vAceptar = value
        End Set
    End Property

End Class
