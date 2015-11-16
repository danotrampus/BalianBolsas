Imports MPP
Imports EE
Public Class CategoriaBLL

    Private vMapper As CategoriaMapper

    Sub New()
        Me.vMapper = New CategoriaMapper
    End Sub

    Public Function Crear(ByVal entidad As Categoria) As Boolean
        Return Me.vMapper.Crear(entidad)
    End Function

    Public Function Editar(ByVal entidad As Categoria) As Boolean
        Return Me.vMapper.Editar(entidad)
    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean
        Return Me.vMapper.Eliminar(id)
    End Function

    Public Function ConsutarPorId(ByVal id As Integer) As Categoria
        Return Me.vMapper.ConsutarPorId(id)
    End Function
    Public Function Listar() As List(Of Categoria)
        Return vMapper.Listar()
    End Function

End Class
