Imports MPP
Imports EE
Imports Servicios
Public Class ProductoBLL

    Private vMapper As ProductoMapper
    Sub New()
        Me.vMapper = New ProductoMapper()
    End Sub

    Public Function Crear(ByVal entidad As Producto) As Boolean
        Return vMapper.Crear(entidad)
    End Function

    Public Function Editar(ByVal entidad As Producto) As Boolean
        Return vMapper.Editar(entidad)
    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean
        Return vMapper.Eliminar(id)
    End Function

    Public Function Listar() As List(Of Producto)
        Return vMapper.Listar()
    End Function

    Public Function ConsultarPorId(ByVal id As Integer) As Producto
        Return vMapper.ConsultarPorId(id)
    End Function

End Class
