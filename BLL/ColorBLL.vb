Imports MPP
Imports EE
Imports Servicios
Public Class ColorBLL

    Private vMapper As ColorMapper
    Sub New()
        Me.vMapper = New ColorMapper()
    End Sub

    Public Function Crear(ByVal entidad As Color) As Boolean
        If vMapper.Crear(entidad) Then
            Servicios.BitacoraServicio.Crear(TipoEvento.Informacion, "Alta de Color")
        End If
        Return True
    End Function

    Public Function Editar(ByVal entidad As Color) As Boolean
        If vMapper.Editar(entidad) Then
            Servicios.BitacoraServicio.Crear(TipoEvento.Informacion, "Edición de Color")
        End If
        Return True
    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean
        If vMapper.Eliminar(id) Then
            Servicios.BitacoraServicio.Crear(TipoEvento.Informacion, "Baja de Color")
        End If
        Return True
    End Function

    Public Function Listar() As List(Of Color)
        Return vMapper.Listar()
    End Function

    Public Function ConsultarPorId(ByVal id As Integer) As Color
        Return vMapper.ConsultarPorId(id)
    End Function

End Class
