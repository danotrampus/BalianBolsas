Imports EE
Imports MPP

Public Class OrdenProduccionBLL

    Private vMapper As OrdenProduccionMapper
    Sub New()
        Me.vMapper = New OrdenProduccionMapper
    End Sub

    Public Function Listar() As List(Of OrdenProduccion)
        Return vMapper.Listar()
    End Function

    Public Function Crear(ByVal entidad As OrdenProduccion) As Boolean
        Return vMapper.Crear(entidad)
    End Function

    Public Function Iniciar(ByVal id As Integer) As Boolean
        Return Me.vMapper.Iniciar(id)
    End Function

    Public Function Terminar(ByVal id As Integer) As Boolean
        Return Me.vMapper.Terminar(id)
    End Function

End Class
