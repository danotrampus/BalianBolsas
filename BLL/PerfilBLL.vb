Imports MPP
Imports EE
Public Class PerfilBLL

    Private vMapper As PerfilMapper

    Sub New()
        Me.vMapper = New PerfilMapper()
    End Sub

    Public Function Crear(ByVal p As Perfil) As Boolean
        Return vMapper.Crear(p)
    End Function

    Public Function Editar(ByVal p As Perfil) As Boolean
        Return vMapper.Editar(p)
    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean
        Return vMapper.Eliminar(id)
    End Function

    Public Function Listar() As List(Of Perfil)
        Return vMapper.Listar()
    End Function

    Public Function ConsultarPorId(ByVal id As Integer) As Perfil
        Return vMapper.ConsultarPorId(id)
    End Function

    Public Function ConsultarPorNombre(ByVal nombre As Integer) As Perfil
        Return vMapper.ConsultarPorNombre(nombre)
    End Function

    Public Function ConsultarPermisos(Optional ByVal perfilId As Integer = 0, Optional ByVal usuarioId As Integer = 0) As List(Of Permiso)
        Return Me.vMapper.ConsultarPermisos(perfilId, usuarioId)
    End Function

    Public Function ConsultarPermisosStringPorUsuario(ByVal id As Integer) As String()
        Return Me.vMapper.ConsultarPermisosStringPorUsuario(id)
    End Function

    Public Function VerificarExistenciaPerfil(ByVal nombre As String) As Boolean
        Return Me.vMapper.VerificarExistenciaPerfil(nombre)
    End Function

End Class
