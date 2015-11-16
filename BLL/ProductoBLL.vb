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
    Public Function ListarBolsas() As List(Of Bolsa)
        Return vMapper.ListarBolsas()
    End Function

    Public Function ConsultarPorId(ByVal id As Integer) As Producto
        Return vMapper.ConsultarPorId(id)
    End Function

    Public Function Comparar(ByVal ids As String) As List(Of Bolsa)
        Return Me.vMapper.Comparar(ids)
    End Function

    Public Function Comentar(ByVal entidad As Comentario) As Boolean
        Return Me.vMapper.Comentar(entidad)
    End Function

End Class
