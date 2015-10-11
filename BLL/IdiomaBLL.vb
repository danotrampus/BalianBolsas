Imports MPP
Imports EE
Public Class IdiomaBLL

    Private vMapper As IdiomaMapper

    Sub New()
        Me.vMapper = New IdiomaMapper()
    End Sub

    Public Function Editar(ByVal idiomasActivos As List(Of Integer)) As Boolean
        Return vMapper.Editar(idiomasActivos)
    End Function

    Public Function Listar() As List(Of Idioma)
        Return vMapper.Listar()
    End Function

End Class
