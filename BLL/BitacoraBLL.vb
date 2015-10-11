Imports MPP
Imports EE
Imports Servicios

Public Class BitacoraBLL

    Private vMapper As BitacoraMapper

    Sub New()
        Me.vMapper = New BitacoraMapper
    End Sub

    Public Function Listar() As List(Of Bitacora)
        BitacoraServicio.Crear(TipoEvento.Informacion, "Se listó la bitácora.")
        Return vMapper.Listar()
    End Function

End Class
