Imports EE
Imports BLL
Imports System.Web
Imports System.Web.Mvc
Imports System.Security
Imports System.Web.Script.Serialization
Imports Newtonsoft.Json

Public Class CuentaController
    Inherits System.Web.Mvc.Controller

    Private vBll As UsuarioBLL

    Sub New()
        Me.vBll = New UsuarioBLL()
    End Sub

    Function LogIn() As ActionResult
        Return View()
    End Function

    <HttpPost()>
    Function LogIn(ByVal modelo As LogInViewModel, Optional ByVal urlRetorno As String = "")
        If ModelState.IsValid Then
            Dim usuario As Usuario = Me.vBll.ConsultarPorNombreYClave(modelo.NombreUsuario, modelo.Clave)
            If IsNothing(usuario) = False Then
                Dim modeloSerializable As New UsuarioSerializableModel()
                modeloSerializable.UsuarioId = usuario.Id
                modeloSerializable.Nombre = usuario.Nombre
                modeloSerializable.Apellido = usuario.Apellido
                modeloSerializable.NombreUsuario = usuario.NombreUsuario
                modeloSerializable.Email = usuario.Email

                Dim usuarioDatos = JsonConvert.SerializeObject(modeloSerializable)
                Dim authTicket As New FormsAuthenticationTicket(1, usuario.Email, DateTime.Now, DateTime.Now.AddMinutes(30), modelo.Recordarme, usuarioDatos)
                Dim encTicket As String = FormsAuthentication.Encrypt(authTicket)
                Dim faCookie As New HttpCookie(FormsAuthentication.FormsCookieName, encTicket)
                Response.Cookies.Add(faCookie)
                Return RedirectToAction("Index", "Home")
            End If

            ModelState.AddModelError("", "Usuario o contraseña incorrecta")
        End If
        Return View(modelo)
    End Function

    <AllowAnonymous()>
    Function LogOut() As ActionResult
        FormsAuthentication.SignOut()
        Return RedirectToAction("Index", "Home", Nothing)
    End Function

End Class