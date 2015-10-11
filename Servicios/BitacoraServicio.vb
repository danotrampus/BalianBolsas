Imports MPP
Imports EE
Public Class BitacoraServicio

    Public Shared Function Crear(ByVal queTipo As Integer, ByVal queMensaje As String)
        Dim b As New Bitacora
        Dim vMapper As New BitacoraMapper

        b.Tipo = queTipo
        b.Descripcion = queMensaje
        b.FechaHora = Now
        b.Usuario = SesionUsuario.Instance.UsuarioActual

        Return vMapper.Crear(b)
    End Function

End Class
