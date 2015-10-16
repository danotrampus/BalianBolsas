Imports MPP
Imports EE
Public Class IdiomaBLL

    Private vMapper As IdiomaMapper

    Sub New()
        Me.vMapper = New IdiomaMapper()
    End Sub

    Public Function Crear(ByVal id As Integer) As Boolean
        Return vMapper.Crear(id)
    End Function
    Public Function Editar(ByVal idiomasActivos As List(Of Integer)) As Boolean
        Return vMapper.Editar(idiomasActivos)
    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean
        Return Me.vMapper.Eliminar(id)
    End Function

    Public Function Listar() As List(Of Idioma)
        Return vMapper.Listar()
    End Function

    Public Function ListarIdiomasInactivos() As List(Of Idioma)
        Return vMapper.ListarIdiomasInactivos()
    End Function

End Class