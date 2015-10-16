Imports MPP
Imports EE
Imports Servicios
Public Class NovedadBLL

    Private vMapper As NovedadMapper

    Sub New()
        Me.vMapper = New NovedadMapper
    End Sub

    Public Function Crear(ByVal n As Novedad) As Boolean
        n.FechaCreacion = Now.Date
        Return vMapper.Crear(n)
    End Function

    Public Function Editar(ByVal n As Novedad) As Boolean
        Return vMapper.Editar(n)
    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean
        Return vMapper.Eliminar(id)
    End Function

    Public Function Listar() As List(Of Novedad)
        Return vMapper.Listar()
    End Function

    Public Function ListarNovedades() As List(Of Novedad)
        Return vMapper.ListarNovedades()
    End Function

    Public Function ConsultarPorId(ByVal id As Integer) As Novedad
        Dim n As Novedad = vMapper.ConsultarPorId(id)
        Return n
    End Function

End Class
