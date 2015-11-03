Imports MPP
Imports EE
Imports Servicios
Public Class ColorBLL

    Private vMapper As ColorMapper
    Sub New()
        Me.vMapper = New ColorMapper()
    End Sub

    Public Function Crear(ByVal entidad As Color) As Boolean
        Return vMapper.Crear(entidad)
    End Function

    Public Function Editar(ByVal entidad As Color) As Boolean
        Return vMapper.Editar(entidad)
    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean
        Return vMapper.Eliminar(id)
    End Function

    Public Function Listar() As List(Of Color)
        Return vMapper.Listar()
    End Function

    Public Function ConsultarPorId(ByVal id As Integer) As Color
        Return vMapper.ConsultarPorId(id)
    End Function

End Class
