Imports System.Collections.Generic
Imports System.Linq
Imports System.Security.Principal
Imports EE
Public Class CustomPrincipal
    Implements IPrincipal

    Private identity_Renamed As IIdentity
    Public Sub New(ByVal nombreUsuario As String)
        Me.identity_Renamed = New GenericIdentity(nombreUsuario)
    End Sub

    Public Property UsuarioId() As String
        Get
            Return vUsuarioId
        End Get
        Set(value As String)
            vUsuarioId = value
        End Set
    End Property
    Private vUsuarioId As String
    Public Property Nombre() As String
        Get
            Return vNombre
        End Get
        Set(value As String)
            vNombre = value
        End Set
    End Property
    Private vNombre As String
    Public Property Apellido() As String
        Get
            Return vApellido
        End Get
        Set(value As String)
            vApellido = value
        End Set
    End Property
    Private vApellido As String
    Public Property Permisos() As String()
        Get
            Return vPermisos
        End Get
        Set(value As String())
            vPermisos = value
        End Set
    End Property
    Private vPermisos As String()

    Private vNombreUsuario As String
    Public Property NombreUsuario() As String
        Get
            Return vNombreUsuario
        End Get
        Set(ByVal value As String)
            vNombreUsuario = value
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

    Public Function IsInRole(permiso As String) As Boolean Implements IPrincipal.IsInRole
        If Permisos.Any(Function(r) permiso.Contains(r)) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public ReadOnly Property Identity() As IIdentity Implements IPrincipal.Identity
        Get
            Return Me.identity_Renamed
        End Get
    End Property

End Class