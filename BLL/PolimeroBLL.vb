Imports MPP
Imports EE
Imports Servicios
Public Class PolimeroBLL

    Private vMapper As PolimeroMapper
    Sub New()
        Me.vMapper = New PolimeroMapper()
    End Sub

    Public Function Crear(ByVal entidad As Polimero) As Boolean
        Return vMapper.Crear(entidad)
    End Function

    Public Function Editar(ByVal entidad As Polimero) As Boolean
        Return vMapper.Editar(entidad)
    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean
        Return vMapper.Eliminar(id)
    End Function

    Public Function Listar() As List(Of Polimero)
        Return vMapper.Listar()
    End Function

    Public Function ConsultarPorId(ByVal id As Integer) As Polimero
        Return vMapper.ConsultarPorId(id)
    End Function

End Class
