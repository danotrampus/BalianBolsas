Imports MPP
Imports EE
Imports Servicios
Public Class ManijaBLL

    Private vMapper As ManijaMapper
    Sub New()
        Me.vMapper = New ManijaMapper()
    End Sub

    Public Function Crear(ByVal entidad As Manija) As Boolean
        Return vMapper.Crear(entidad)
    End Function

    Public Function Editar(ByVal entidad As Manija) As Boolean
        Return vMapper.Editar(entidad)
    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean
        Return vMapper.Eliminar(id)
    End Function

    Public Function Listar() As List(Of Manija)
        Return vMapper.Listar()
    End Function

    Public Function ConsultarPorId(ByVal id As Integer) As Manija
        Return vMapper.ConsultarPorId(id)
    End Function

End Class
