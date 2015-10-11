Public Class BaseController
    Inherits System.Web.Mvc.Controller

    Protected ReadOnly Property UsuarioActual() As CustomPrincipal
        Get
            Return TryCast(HttpContext.User, CustomPrincipal)
        End Get
    End Property

End Class