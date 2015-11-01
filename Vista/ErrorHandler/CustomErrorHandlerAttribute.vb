Public Class CustomErrorHandlerAttribute
    Inherits HandleErrorAttribute

    Private Function IsAjax(filterContext As ExceptionContext) As Boolean
        Return filterContext.HttpContext.Request.Headers("X-Requested-With") = "XMLHttpRequest"
    End Function

    Public Overrides Sub OnException(filterContext As ExceptionContext)
        If filterContext.ExceptionHandled OrElse Not filterContext.HttpContext.IsCustomErrorEnabled Then
            Return
        End If

        ' if the request is AJAX return JSON else view.
        If IsAjax(filterContext) Then
            'Because its a exception raised after ajax invocation
            'Lets return Json
            filterContext.Result = New JsonResult() With { _
                .Data = filterContext.Exception.Message, _
                .JsonRequestBehavior = JsonRequestBehavior.AllowGet _
            }

            filterContext.ExceptionHandled = True
            filterContext.HttpContext.Response.Clear()
        Else
            'Normal Exception
            'So let it handle by its default ways.

            MyBase.OnException(filterContext)
        End If

        ' Write error logging code here if you wish.
        Servicios.BitacoraServicio.Crear(EE.TipoEvento.Fallo, filterContext.Exception.Message)

        'if want to get different of the request
        'var currentController = (string)filterContext.RouteData.Values["controller"];
        'var currentActionName = (string)filterContext.RouteData.Values["action"];
    End Sub

End Class
