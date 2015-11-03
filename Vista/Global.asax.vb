' Nota: para obtener instrucciones sobre cómo habilitar el modo clásico de IIS6 o IIS7, 
' visite http://go.microsoft.com/?LinkId=9394802
Imports System.Web.Http
Imports System.Web.Optimization
Imports Newtonsoft.Json
Imports BLL

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Sub Application_Start()
        ModelBinders.Binders.DefaultBinder = New CustomModelBinder()
        AreaRegistration.RegisterAllAreas()

        WebApiConfig.Register(GlobalConfiguration.Configuration)
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)
    End Sub

    Protected Sub Application_PostAuthenticateRequest(sender As [Object], e As EventArgs)
        Dim authCookie As HttpCookie = Request.Cookies(FormsAuthentication.FormsCookieName)
        If authCookie IsNot Nothing Then
            Dim authTicket As FormsAuthenticationTicket = FormsAuthentication.Decrypt(authCookie.Value)
            Dim serializeModel As UsuarioSerializableModel = JsonConvert.DeserializeObject(Of UsuarioSerializableModel)(authTicket.UserData)
            Dim newUser As New CustomPrincipal(authTicket.Name)
            newUser.UsuarioId = serializeModel.UsuarioId
            newUser.Nombre = serializeModel.Nombre
            newUser.Apellido = serializeModel.Apellido
            newUser.NombreUsuario = serializeModel.NombreUsuario
            Dim vPerfilBll As New PerfilBLL()
            newUser.Permisos = vPerfilBll.ConsultarPermisosStringPorUsuario(serializeModel.UsuarioId)
            Dim vUsuarioBll As New UsuarioBLL()
            EE.SesionUsuario.Instance.UsuarioActual = vUsuarioBll.ConsultarPorId(serializeModel.UsuarioId)
            HttpContext.Current.User = newUser
        End If
    End Sub

End Class
