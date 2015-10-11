Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports EE

Public NotInheritable Class ConexionUsuario
    Private Sub New()
    End Sub

    Public Shared listaUsuariosConectados As New List(Of UsuarioChatModel)()

    Public Shared Sub AgregarUsuarioConectado(usuario As UsuarioChatModel)
        listaUsuariosConectados.Add(usuario)
    End Sub

    Public Shared Sub QuitarUsuarioConectado(strConnectionId As String)
        Dim userRemove = DirectCast(listaUsuariosConectados.Where(Function(item) item.ConexionId = strConnectionId).FirstOrDefault(), UsuarioChatModel)
        listaUsuariosConectados.Remove(userRemove)
    End Sub
End Class
