Imports MPP
Imports EE
Public Class CategoriaBLL

    Private vMapper As CategoriaMapper

    Sub New()
        Me.vMapper = New CategoriaMapper
    End Sub

    Public Function Crear(ByVal cat As Categoria) As Boolean
        Return vMapper.Crear(cat)
    End Function

    Public Function Listar() As List(Of Categoria)
        Return vMapper.Listar()
    End Function

End Class
