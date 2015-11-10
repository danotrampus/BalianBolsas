@Code
    Layout = Nothing
End Code
<!DOCTYPE html>
<!--[if IE 8]> <html lang="en" class="ie8 no-js"> <![endif]-->
<!--[if IE 9]> <html lang="en" class="ie9 no-js"> <![endif]-->
<!--[if !IE]><!-->
<html lang="en" class="no-js">
<!--<![endif]-->
<!-- BEGIN HEAD -->
<head>
    <meta charset="utf-8" />
    <title>Balian Bolsas</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta content="width=device-width, initial-scale=1" name="viewport" />
    <!-- BEGIN GLOBAL MANDATORY STYLES -->
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css" />
    @Styles.Render("~/Content/global/css")
    <!-- END GLOBAL MANDATORY STYLES -->
    <!-- BEGIN PAGE LEVEL PLUGIN STYLES -->
    @RenderSection("stylesheets", required:=False)
    <!-- END PAGE LEVEL PLUGIN STYLES -->
    <!-- BEGIN THEME STYLES -->
    @Styles.Render("~/Content/theme/css")
    <!-- END THEME STYLES -->
    <link rel="shortcut icon" href="favicon.ico" />
</head>
<!-- END HEAD -->
<!-- BEGIN BODY -->
<!-- DOC: Apply "page-header-fixed-mobile" and "page-footer-fixed-mobile" class to body element to force fixed header or footer in mobile devices -->
<!-- DOC: Apply "page-sidebar-closed" class to the body and "page-sidebar-menu-closed" class to the sidebar menu element to hide the sidebar by default -->
<!-- DOC: Apply "page-sidebar-hide" class to the body to make the sidebar completely hidden on toggle -->
<!-- DOC: Apply "page-sidebar-closed-hide-logo" class to the body element to make the logo hidden on sidebar toggle -->
<!-- DOC: Apply "page-sidebar-hide" class to body element to completely hide the sidebar on sidebar toggle -->
<!-- DOC: Apply "page-sidebar-fixed" class to have fixed sidebar -->
<!-- DOC: Apply "page-footer-fixed" class to the body element to have fixed footer -->
<!-- DOC: Apply "page-sidebar-reversed" class to put the sidebar on the right side -->
<!-- DOC: Apply "page-full-width" class to the body element to have full width page without the sidebar menu -->
<body class="page-md page-header-fixed page-quick-sidebar-over-content page-sidebar-closed-hide-logo page-container-bg-solid">
    <!-- BEGIN HEADER -->
    <div class="page-header md-shadow-z-1-i navbar navbar-fixed-top">
        <!-- BEGIN HEADER INNER -->
        <div class="page-header-inner">
            <!-- BEGIN LOGO -->
            <div class="page-logo">
                <a href="@Url.Action("Index","Home")">
                    <img src="~/Content/admin/layout/img/Icono.png" alt="logo" class="logo-default" style="height:40px;margin-top:5px;" />
                </a>
                <div class="menu-toggler sidebar-toggler hide">
                </div>
            </div>
            <div class="hor-menu hor-menu-light hidden-sm hidden-xs">
                <ul class="nav navbar-nav">
                    <!-- DOC: Remove data-hover="megadropdown" and data-close-others="true" attributes below to disable the horizontal opening on mouse hover -->
                    <li class="classic-menu-dropdown">
                        <a href="@Url.Action("Empresa", "Home")">
                            Empresa
                        </a>
                    </li>
                    <li class="classic-menu-dropdown">
                        <a href="@Url.Action("Crear", "Contacto")">
                            Contacto
                        </a>
                    </li>
                    <li class="classic-menu-dropdown">
                        <a href="@Url.Action("Faq", "Home")">
                            Preguntas Frecuentes
                        </a>
                    </li>
                    <li class="classic-menu-dropdown">
                        <a href="@Url.Action("ListarNovedades", "Novedad")">
                            Novedades
                        </a>
                    </li>
                    <li class="classic-menu-dropdown">
                        <a href="@Url.Action("VerCarro", "Pedido")">
                            Compra Actual
                        </a>
                    </li>
                </ul>
            </div>
            <!-- END LOGO -->
            <!-- BEGIN RESPONSIVE MENU TOGGLER -->
            <a href="javascript:;" class="menu-toggler responsive-toggler" data-toggle="collapse" data-target=".navbar-collapse">
            </a>
            <!-- END RESPONSIVE MENU TOGGLER -->
            <!-- BEGIN TOP NAVIGATION MENU -->
            <div class="top-menu">
                <ul class="nav navbar-nav pull-right">
                    <!-- BEGIN LANGUAGE BAR -->
                    <!-- DOC: Apply "dropdown-dark" class after below "dropdown-extended" to change the dropdown styte -->
                    @Html.DropdownLenguaje()
                    <!-- END LANGUAGE BAR -->
                    <!-- BEGIN USER LOGIN DROPDOWN -->
                    <!-- DOC: Apply "dropdown-dark" class after below "dropdown-extended" to change the dropdown styte -->
                    @Code
                        If IsNothing(User) Then
                        @<li>
                            <a href="@Url.Action("Registrar", "Usuario")" class="btn btn-default btn-sm" style="margin-right: 5px; margin-top: 7px;">
                                Registrarse
                            </a>
                        </li>
                        @<li>
                            <a href="@Url.Action("LogIn", "Cuenta")" class="btn btn-default btn-sm" style="margin-top: 7px;">
                                Iniciar Sesión
                            </a>
                        </li>
                        Else
                        @<li class="dropdown dropdown-user" data-usuarioid="@User.UsuarioId">
                            <a href="javascript:;" class="dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-close-others="true">
                                <img alt="" class="img-circle" src="~/Content/admin/layout/img/avatar.png" />
                                <span class="username username-hide-on-mobile">
                                    @User.Nombre
                                </span>
                                <i class="fa fa-angle-down"></i>
                            </a>
                            <ul class="dropdown-menu dropdown-menu-default">
                                <li>
                                    <a href="@Url.Action("MiCuenta", "Usuario")">
                                        <i class="icon-user"></i> Mi Cuenta
                                    </a>
                                </li>
                                <li class="divider">
                                </li>
                                <li>
                                    <a href="@Url.Action("LogOut", "Cuenta")">
                                        <i class="icon-key"></i> Log Out
                                    </a>
                                </li>
                            </ul>
                        </li>
                        End If
                    End Code
                    <!-- END USER LOGIN DROPDOWN -->
                    <!-- BEGIN QUICK SIDEBAR TOGGLER -->
                    <!-- DOC: Apply "dropdown-dark" class after below "dropdown-extended" to change the dropdown styte -->
                    @Code
                        If User IsNot Nothing Then
                    End Code
                    <li class="dropdown dropdown-quick-sidebar-toggler">
                        <a href="javascript:;" class="dropdown-toggle">
                            <i class="icon-logout"></i>
                        </a>
                    </li>
                    @Code
                        End If
                    End Code
                    <!-- END QUICK SIDEBAR TOGGLER -->
                </ul>
            </div>
            <!-- END TOP NAVIGATION MENU -->
        </div>
        <!-- END HEADER INNER -->
    </div>
    <!-- END HEADER -->
    <div class="clearfix">
    </div>
    <!-- BEGIN CONTAINER -->
    <div class="page-container">
        <!-- BEGIN SIDEBAR -->
        <div class="page-sidebar-wrapper">
            <!-- DOC: Set data-auto-scroll="false" to disable the sidebar from auto scrolling/focusing -->
            <!-- DOC: Change data-auto-speed="200" to adjust the sub menu slide up/down speed -->
            <div class="page-sidebar navbar-collapse collapse">
                <!-- BEGIN SIDEBAR MENU -->
                <!-- DOC: Apply "page-sidebar-menu-light" class right after "page-sidebar-menu" to enable light sidebar menu style(without borders) -->
                <!-- DOC: Apply "page-sidebar-menu-hover-submenu" class right after "page-sidebar-menu" to enable hoverable(hover vs accordion) sub menu mode -->
                <!-- DOC: Apply "page-sidebar-menu-closed" class right after "page-sidebar-menu" to collapse("page-sidebar-closed" class must be applied to the body element) the sidebar sub menu mode -->
                <!-- DOC: Set data-auto-scroll="false" to disable the sidebar from auto scrolling/focusing -->
                <!-- DOC: Set data-keep-expand="true" to keep the submenues expanded -->
                <!-- DOC: Set data-auto-speed="200" to adjust the sub menu slide up/down speed -->
                <ul class="page-sidebar-menu page-sidebar-menu-light" data-keep-expanded="false" data-auto-scroll="true" data-slide-speed="200">
                    <!-- DOC: To remove the sidebar toggler from the sidebar you just need to completely remove the below "sidebar-toggler-wrapper" LI element -->
                    <li class="sidebar-toggler-wrapper">
                        <!-- BEGIN SIDEBAR TOGGLER BUTTON -->
                        <div class="sidebar-toggler">
                        </div>
                        <!-- END SIDEBAR TOGGLER BUTTON -->
                    </li>
                    <!-- DOC: To remove the search box from the sidebar you just need to completely remove the below "sidebar-search-wrapper" LI element -->
                    <li class="sidebar-search-wrapper">
                        <!-- BEGIN RESPONSIVE QUICK SEARCH FORM -->
                        <!-- DOC: Apply "sidebar-search-bordered" class the below search form to have bordered search box -->
                        <!-- DOC: Apply "sidebar-search-bordered sidebar-search-solid" class the below search form to have bordered & solid search box -->
                        <div class="sidebar-search">
                            @*<form class="sidebar-search " action="#" method="POST">*@
                            <a href="javascript:;" class="remove">
                                <i class="icon-close"></i>
                            </a>
                            <div class="input-group">
                                <input type="text" id="txtBuscarEnMenu" class="form-control" placeholder="Buscar...">
                                <span class="input-group-btn">
                                    <a href="javascript:;" class="btn submit"><i class="icon-magnifier"></i></a>
                                </span>
                            </div>
                            @*</form>*@
                        </div>
                        <!-- END RESPONSIVE QUICK SEARCH FORM -->
                    </li>
                    <li class="start">
                        <a href="@Url.Action("Index", "Home")">
                            <i class="icon-home"></i>
                            <span class="title">
                                Home
                            </span>
                        </a>
                    </li>
                    @Html.MenuVertical()
                </ul>
                <!-- END SIDEBAR MENU -->
            </div>
        </div>
        <!-- END SIDEBAR -->
        <!-- BEGIN CONTENT -->
        <div class="page-content-wrapper">
            <div class="page-content">
                <!-- BEGIN PAGE HEADER-->
                @RenderSection("title", required:=False)

                <div class="page-bar" style="margin-bottom: 25px !important;">
                    @RenderSection("breadcrumbs", required:=True)
                </div>
                <!-- END PAGE HEADER-->
                @RenderBody()
            </div>
        </div>
        <!-- END CONTENT -->
        <!-- BEGIN QUICK SIDEBAR -->
        @Code
            If User IsNot Nothing Then
        End Code
        <a href="javascript:;" class="page-quick-sidebar-toggler"><i class="icon-close"></i></a>
        <div class="page-quick-sidebar-wrapper">
            <div class="page-quick-sidebar">
                <div class="nav-justified">
                    <ul class="nav nav-tabs nav-justified">
                        <li class="active">
                            <a href="#quick_sidebar_tab_1" data-toggle="tab">
                                Chat @*<span class="badge badge-danger">2</span>*@
                            </a>
                        </li>
                    </ul>
                    <div class="tab-content">
                        <div class="tab-pane active page-quick-sidebar-chat" id="quick_sidebar_tab_1">
                            <div class="page-quick-sidebar-chat-users" data-rail-color="#ddd" data-wrapper-class="page-quick-sidebar-list">
                                <h3 class="list-heading">Usuarios Conectados</h3>
                                <ul id="ulOnlineUsers" class="media-list list-items"></ul>
                            </div>
                            <div class="page-quick-sidebar-item" data-nombregrupo="" data-usuarioid="">
                                <div class="page-quick-sidebar-chat-user">
                                    <div class="page-quick-sidebar-nav">
                                        <a href="javascript:;" class="page-quick-sidebar-back-to-list"><i class="icon-arrow-left"></i>Atras</a>
                                    </div>
                                    <div class="page-quick-sidebar-chat-user-messages">
                                    </div>
                                    <div class="page-quick-sidebar-chat-user-form">
                                        <div class="input-group">
                                            <input type="text" class="form-control" placeholder="Ingrese un mensaje...">
                                            <div class="input-group-btn">
                                                <button type="button" class="btn blue"><i class="icon-arrow-right"></i></button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        @Code
            End If
        End Code
        <!-- END QUICK SIDEBAR -->
    </div>
    <!-- END CONTAINER -->
    <!-- BEGIN FOOTER -->
    <div class="page-footer">
        <div class="page-footer-inner">
            2015 &copy; Balian Bolsas. <a href="@Url.Action("PoliticaPrivacidad", "Home")" title="Política de Privacidad" target="_blank" style="color: rgba(138, 148, 160, 1);">Política de Privacidad</a>
        </div>
        <div class="scroll-to-top">
            <i class="icon-arrow-up"></i>
        </div>
    </div>
    <!-- END FOOTER -->
    <!-- BEGIN JAVASCRIPTS(Load javascripts at bottom, this will reduce page load time) -->
    <!-- BEGIN CORE PLUGINS -->
    @Scripts.Render("~/Content/global/js")
    <!-- END CORE PLUGINS -->
    <!-- BEGIN PAGE LEVEL PLUGINS -->
    @RenderSection("javascripts", required:=False)
    <!-- END PAGE LEVEL PLUGINS -->
    <!-- BEGIN PAGE LEVEL SCRIPTS -->
    @Scripts.Render("~/Content/theme/js")
    @Code
        If User IsNot Nothing Then
    End Code
    @Scripts.Render("~/Content/signalr/js")
    <script src="/signalr/hubs" type="text/javascript"></script>
    @Scripts.Render("~/Content/chat/js")
    @Code
        End If
    End Code
    <!-- END PAGE LEVEL SCRIPTS -->
    <script>
        jQuery(document).ready(function () {
            Metronic.init(); // init metronic core componets
            Layout.init(); // init layout
            @Code
                If User IsNot Nothing Then
            End Code
            QuickSidebar.init(); // init quick sidebar
            @Code
                End If
            End Code

            //Buscador de opciones en el menu dinamico
            $("#txtBuscarEnMenu").keyup(function () {
                var that = this;
                $("ul.page-sidebar-menu").find("li").removeClass("hide")
                $("ul.page-sidebar-menu").find("li").removeClass("tomado");
                $("ul.page-sidebar-menu").find("span.title").each(function () {
                    if ($(this).text().toLowerCase().indexOf($(that).val().trim().toLowerCase()) >= 0) {
                        $(this).parents("li").removeClass("hide").addClass("tomado");
                    }
                    else {
                        $(this).parents("li").each(function () {
                            if ($(this).hasClass("tomado") == false) {
                                $(this).addClass("hide");
                            }
                        });
                    }
                });
            });

            //Multiidioma de google
            $('.translation-links').click(function () {
                var lang = $(this).data('lang');
                var $frame = $('.goog-te-menu-frame:first');
                if (!$frame.size()) {
                    alert("Error: Could not find Google translate frame.");
                    return false;
                }
                $frame.contents().find('.goog-te-menu2-item span.text').each(function () {
                    if ($(this).text().toLowerCase() == lang.toLowerCase()) {
                        $(this).get(0).click();
                    }
                });
                return false;
            });

            //Formulario de Encuestas
            $('input[type=radio][name=Respuesta]').change(function () {
                $("#btnResponderEncuesta").attr("disabled", false);
            });
        });
    </script>
    @RenderSection("javascript_codigo", required:=False)
    <!-- END JAVASCRIPTS -->
</body>

<!-- END BODY -->
</html>
