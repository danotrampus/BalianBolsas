Imports EE
Public Class UsuarioSerializableModel

    Private vUsuarioId As Integer
    Public Property UsuarioId() As Integer
        Get
            Return vUsuarioId
        End Get
        Set(ByVal value As Integer)
            vUsuarioId = value
        End Set
    End Property

    Private vNombre As String
    Public Property Nombre() As String
        Get
            Return vNombre
        End Get
        Set(ByVal value As String)
            vNombre = value
        End Set
    End Property

    Private vApellido As String
    Public Property Apellido() As String
        Get
            Return vApellido
        End Get
        Set(ByVal value As String)
            vApellido = value
        End Set
    End Property

    Private vNombreUsuario As String
    Public Property NombreUsuario() As String
        Get
            Return vNombreUsuario
        End Get
        Set(ByVal value As String)
            vNombreUsuario = value
        End Set
    End Property

    Private vConexionId As String
    Public Property ConexionId() As String
        Get
            Return vConexionId
        End Get
        Set(ByVal value As String)
            vConexionId = value
        End Set
    End Property

End Class
