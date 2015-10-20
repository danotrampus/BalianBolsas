Imports MPP
Imports EE
Imports Servicios
Public Class EncuestaBLL

    Private vMapper As EncuestaMapper

    Sub New()
        Me.vMapper = New EncuestaMapper
    End Sub

    Public Function Crear(ByVal e As Encuesta) As Boolean
        Return vMapper.Crear(e)
    End Function

    Public Function Editar(ByVal e As Encuesta) As Boolean
        Return vMapper.Editar(e)
    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean
        Return vMapper.Eliminar(id)
    End Function

    Public Function Listar() As List(Of Encuesta)
        Return vMapper.Listar()
    End Function

    Public Function ConsultarPorId(ByVal id As Integer) As Encuesta
        Return vMapper.ConsultarPorId(id)
    End Function

End Class
