Imports System.Runtime.CompilerServices
Imports System.Web.Http
Imports EE
Imports BLL

Public Module MenuVerticalExtensions
    <Extension()> _
    Public Function MenuVertical(ByVal helper As HtmlHelper) As HtmlString
        Dim customPrincipal As CustomPrincipal = TryCast(HttpContext.Current.User, CustomPrincipal)
        Dim output As String = ""
        If Not IsNothing(customPrincipal) Then
            Dim vPerfilBll As New PerfilBLL()
            Dim listaPermisos As List(Of Permiso) = vPerfilBll.ConsultarPermisos(0, customPrincipal.UsuarioId)
            'output = output +
            '    "<li class='start'>" +
            '        "<a href='/Home/Index'>" +
            '            "<i class='icon-home'></i>" +
            '            "<span class='title'>" +
            '                "Inicio" +
            '            "</span>" +
            '        "</a>" +
            '    "</li>"
            For Each p As Permiso In listaPermisos
                If p.Habilitado And p.Activo Then
                    If TypeOf p Is Familia Then
                        output = output +
                            "<li>" +
                                "<a href='javascript:;'>" +
                                    "<i class='" + p.Css + "'></i>" +
                                    "<span class='title'>" + p.Descripcion + "</span>" +
                                    "<span class='arrow'></span>" +
                                "</a>" +
                                "<ul class='sub-menu'>"
                        ArmarMenu(output, p)
                        output = output +
                                "</ul>" +
                            "</li>"
                    Else
                        output = output +
                            "<li>" +
                                "<a href='" + p.Url + "'>" +
                                    "<i class='" + p.Css + "'></i>" +
                                    "<span class='title'> " +
                                        p.Descripcion +
                                    "</span>" +
                                "</a>" +
                            "</li>"
                    End If
                End If
            Next
        End If
        Return MvcHtmlString.Create(output)
    End Function

    Private Sub ArmarMenu(ByRef output As String, ByVal f As Familia)
        For Each p As Permiso In f.ListaPermisos
            If p.Habilitado And p.Activo Then
                If TypeOf p Is Familia Then
                    output = output +
                        "<li>" +
                            "<a href='javascript:;'>" +
                                "<i class='" + p.Css + "'></i>" +
                                "<span class='title'>" + p.Descripcion + "</span>" +
                                "<span class='arrow'></span>" +
                            "</a>" +
                            "<ul class='sub-menu'>"
                    ArmarMenu(output, p)
                    output = output +
                            "</ul>" +
                        "</li>"
                Else
                    output = output +
                        "<li>" +
                            "<a href='" + p.Url + "'>" +
                                "<i class='" + p.Css + "'></i>" +
                                "<span class='title'> " +
                                    p.Descripcion +
                                "</span>" +
                            "</a>" +
                        "</li>"
                End If
            End If
        Next
    End Sub

End Module