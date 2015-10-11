Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Configuration
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.Routing
Public Class AutorizarAttribute
    Inherits AuthorizeAttribute

    Protected Overridable ReadOnly Property CurrentUser() As CustomPrincipal
        Get
            Return TryCast(HttpContext.Current.User, CustomPrincipal)
        End Get
    End Property

    Public Overrides Sub OnAuthorization(filterContext As AuthorizationContext)
        If filterContext.HttpContext.Request.IsAuthenticated Then
            If Not [String].IsNullOrEmpty(Roles) Then
                If Not CurrentUser.IsInRole(Roles) Then
                    '   filterContext.Result = new RedirectToRouteResult(new
                    'RouteValueDictionary(new { controller = "Error", action = "AccessDenied" }));

                    'returns to login url
                    MyBase.OnAuthorization(filterContext)
                End If
            End If

            If Not [String].IsNullOrEmpty(Users) Then
                If Not Users.Contains(CurrentUser.UsuarioId.ToString()) Then
                    '   filterContext.Result = new RedirectToRouteResult(new
                    'RouteValueDictionary(new { controller = "Error", action = "AccessDenied" }));

                    'returns to login url
                    MyBase.OnAuthorization(filterContext)
                End If
            End If
        Else
            'Redireccionar a la pantalla de login ~/Cuenta/LogIn esta se setea en el Web.config
            MyBase.OnAuthorization(filterContext)
        End If
    End Sub
End Class
