Imports System.Runtime.CompilerServices
Imports System.Web.Http
Imports EE
Imports BLL

Public Module CarroExtensions
    <Extension()> _
    Public Function Carro(ByVal helper As HtmlHelper) As HtmlString
        Dim urlHelper As New UrlHelper(helper.ViewContext.RequestContext)
        Dim url = urlHelper.Action("VerCarro", "Pedido")
        Dim output As String = ""
        Dim badge As String = ""
        If ObtenerCarro().ListaDetalles.Count > 0 Then
            badge += "<span class='badge badge-default'>" + ObtenerCarro().ListaDetalles.Count.ToString()
        End If
        output = output +
            "<li class='dropdown dropdown-extended dropdown-notification'>" + _
                "<a href='" + url + "' class='dropdown-toggle' style='padding-right:10px !important'>" + _
                    "<i class='icon-basket'></i>" + _
                        badge + _
                    "</span>" +
                "</a>" + _
            "</li>"
        Return MvcHtmlString.Create(output)
    End Function

    Private Function ObtenerCarro() As Pedido
        Dim sesionCarro = System.Web.HttpContext.Current.Session("Carro")
        If sesionCarro IsNot Nothing Then
            Return DirectCast(sesionCarro, Pedido)
        Else
            Dim p As New Pedido
            p.FechaInicio = Now.Date
            p.Estado = "Pendiente"
            p.Importe = 0
            System.Web.HttpContext.Current.Session("Carro") = p
            Return p
        End If
        Return Nothing
    End Function

End Module