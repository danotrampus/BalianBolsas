Imports System.ComponentModel.DataAnnotations
Public Class LogInViewModel

    Private vNombreUsuario As String
    <Required(ErrorMessage:="Nombre de usuario requerido"), Display(Name:="Nombre de usuario")>
    Public Property NombreUsuario() As String
        Get
            Return vNombreUsuario
        End Get
        Set(ByVal value As String)
            vNombreUsuario = value
        End Set
    End Property

    Private vClave As String
    <Required(ErrorMessage:="Clave requerida"), DataType(DataType.Password), Display(Name:="Contraseña")>
    Public Property Clave() As String
        Get
            Return vClave
        End Get
        Set(ByVal value As String)
            vClave = value
        End Set
    End Property

    Private vRecordarme As Boolean
    <Display(Name:="Recordarme?")>
    Public Property Recordarme() As Boolean
        Get
            Return vRecordarme
        End Get
        Set(ByVal value As Boolean)
            vRecordarme = value
        End Set
    End Property

End Class
