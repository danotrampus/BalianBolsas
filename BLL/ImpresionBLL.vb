Imports MPP
Imports EE
Imports Servicios
Public Class ImpresionBLL

    Private vMapper As ImpresionMapper
    Sub New()
        Me.vMapper = New ImpresionMapper()
    End Sub

    Public Function Crear(ByVal entidad As Impresion) As Boolean
        Return vMapper.Crear(entidad)
    End Function

    Public Function Editar(ByVal entidad As Impresion) As Boolean
        Return vMapper.Editar(entidad)
    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean
        Return vMapper.Eliminar(id)
    End Function

    Public Function Listar() As List(Of Impresion)
        Return vMapper.Listar()
    End Function

    Public Function ConsultarPorId(ByVal id As Integer) As Impresion
        Return vMapper.ConsultarPorId(id)
    End Function

End Class
