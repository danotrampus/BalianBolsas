Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports Microsoft.AspNet.SignalR.Hubs
Imports Microsoft.AspNet.SignalR.Transports
Imports Microsoft.AspNet.SignalR.Infrastructure
Imports Microsoft.AspNet.SignalR
Imports System.Threading.Tasks
Imports System.Timers
Imports Vista
Imports BLL
Imports EE

<HubName("chatHub")> _
Public Class Chat
    Inherits Hub

    Private vMensajeBLL As MensajeBLL
    Sub New()
        MyBase.New()
        Me.vMensajeBLL = New MensajeBLL
    End Sub

    Protected Overridable ReadOnly Property CurrentUser() As CustomPrincipal
        Get
            Return TryCast(HttpContext.Current.User, CustomPrincipal)
        End Get
    End Property

    Public Overrides Function OnConnected() As Task
        If ConexionUsuario.listaUsuariosConectados.Where(Function(item) item.Id = Me.CurrentUser.UsuarioId).Count() > 0 Then
            ConexionUsuario.listaUsuariosConectados.Where(Function(item) item.Id = Me.CurrentUser.UsuarioId).FirstOrDefault().ConexionId = Context.ConnectionId
        Else
            Dim usuarioChat As New UsuarioChatModel()
            usuarioChat.ConexionId = Context.ConnectionId
            usuarioChat.Id = Me.CurrentUser.UsuarioId
            usuarioChat.NombreUsuario = Me.CurrentUser.NombreUsuario
            usuarioChat.Nombre = Me.CurrentUser.Nombre
            usuarioChat.Apellido = Me.CurrentUser.Apellido
            usuarioChat.Permisos = Me.CurrentUser.Permisos
            ConexionUsuario.AgregarUsuarioConectado(usuarioChat)
        End If
        Dim newUsers = ConexionUsuario.listaUsuariosConectados.ToList()
        Return Clients.All.joined(Context.ConnectionId, newUsers)
    End Function

    Public Overrides Function OnDisconnected(stopCalled As Boolean) As Task
        If ConexionUsuario.listaUsuariosConectados.Where(Function(item) item.ConexionId = Context.ConnectionId).Count() > 0 Then
            Dim u As UsuarioChatModel = ConexionUsuario.listaUsuariosConectados.Where(Function(item) item.ConexionId = Context.ConnectionId).FirstOrDefault()
            ConexionUsuario.QuitarUsuarioConectado(Context.ConnectionId)
        End If
        Dim newUsers = ConexionUsuario.listaUsuariosConectados.ToList()
        Return Clients.All.joined(Context.ConnectionId, newUsers)
    End Function

    Public Sub Send(message As String, groupName As String)
        If Clients IsNot Nothing Then
            Dim m As New Mensaje
            Dim u As New Usuario
            m.FechaHora = Now
            m.Mensaje = message
            m.Grupo = groupName
            u.Id = Me.CurrentUser.UsuarioId
            m.Usuario = u
            Me.vMensajeBLL.Crear(m)
            Clients.Group(groupName).addMessage(message, groupName, Me.CurrentUser.UsuarioId, Me.CurrentUser.NombreUsuario)
        End If
    End Sub

    Public Sub GetAllOnlineStatus()
        Clients.Caller.OnlineStatus(Context.ConnectionId, ConexionUsuario.listaUsuariosConectados.ToList())
    End Sub

    Public Sub CreateGroup(toConnectTo As String)
        Dim strGroupName As String = GetUniqueGroupName(Me.CurrentUser.UsuarioId, toConnectTo)
        Dim connectionId_To As String = ConexionUsuario.listaUsuariosConectados.Where(Function(item) item.Id = toConnectTo).[Select](Function(item) item.ConexionId).SingleOrDefault()
        If Not String.IsNullOrEmpty(connectionId_To) Then
            Groups.Add(Context.ConnectionId, strGroupName)
            Groups.Add(connectionId_To, strGroupName)
            Dim listaMensajes As List(Of Mensaje) = Me.vMensajeBLL.Listar(strGroupName)
            For Each m As Mensaje In listaMensajes
                If m.Usuario.Id = Me.CurrentUser.UsuarioId Then
                    m.EntradaSalida = "out"
                    m.Usuario.NombreUsuario = "Yo"
                Else
                    m.EntradaSalida = "in"
                End If
                m.FechaHoraFormateada = m.FechaHora.ToString("dd/MM/yyyy HH:mm")
            Next
            Clients.Caller.setChatWindow(strGroupName, toConnectTo, listaMensajes)
        End If
    End Sub

    Private Function GetUniqueGroupName(currentUserId As String, toConnectTo As String) As String
        Return (currentUserId.GetHashCode() Xor toConnectTo.GetHashCode()).ToString()
    End Function

End Class