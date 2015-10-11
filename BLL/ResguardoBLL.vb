Imports MPP
Imports EE
Imports Servicios

Public Class ResguardoBLL

    Private vMapper As ResguardoMapper

    Sub New()
        Me.vMapper = New ResguardoMapper
    End Sub

    Public Function Listar() As List(Of Resguardo)
        Return vMapper.Listar()
    End Function

    Public Function Crear(ByVal r As Resguardo) As Boolean
        Return vMapper.Crear(r)
    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean
        Return vMapper.Eliminar(id)
    End Function

    Public Function Restaurar(ByVal r As Resguardo) As Boolean
        Return vMapper.Restaurar(r)
    End Function

End Class
