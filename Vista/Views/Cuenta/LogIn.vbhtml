@ModelType Vista.LogInViewModel

@Code
    Layout = Nothing
End Code

<!DOCTYPE html>
<!--[if IE 8]> <html lang="en" class="ie8 no-js"> <![endif]-->
<!--[if IE 9]> <html lang="en" class="ie9 no-js"> <![endif]-->
<!--[if !IE]><!-->
<html lang="en">
<!--<![endif]-->
<!-- BEGIN HEAD -->
<head>
    <meta charset="utf-8" />
    <title>Balian Bolsas</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta http-equiv="Content-type" content="text/html; charset=utf-8">
    <!-- BEGIN GLOBAL MANDATORY STYLES -->
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css" />
    @Styles.Render("~/Content/global/css")
    <!-- END GLOBAL MANDATORY STYLES -->
    <!-- BEGIN PAGE LEVEL STYLES -->
    @Styles.Render("~/Content/login/css")
    <!-- END PAGE LEVEL SCRIPTS -->
    <!-- BEGIN THEME STYLES -->
    @Styles.Render("~/Content/theme/css")
    <!-- END THEME STYLES -->
    <link rel="shortcut icon" href="favicon.ico" />
</head>
<!-- END HEAD -->
<!-- BEGIN BODY -->
<body class="page-md login">
    <!-- BEGIN SIDEBAR TOGGLER BUTTON -->
    <div class="menu-toggler sidebar-toggler">
    </div>
    <!-- END SIDEBAR TOGGLER BUTTON -->
    <!-- BEGIN LOGO -->
    <div class="logo">
        <a href="index.html">
            @*<img src="~/Content/admin/layout/img/logo-big-white.png" style="height: 17px;" alt="" />*@
        </a>
    </div>
    <!-- END LOGO -->
    <!-- BEGIN LOGIN -->
    <div class="content">
        <!-- BEGIN LOGIN FORM -->
        @Using (Html.BeginForm("LogIn", "Cuenta", Nothing, FormMethod.Post, New With {.class = "login-form"}))
            @Html.AntiForgeryToken()
            
            @*@<div class="form-title">
                <span class="form-title">Bienvenido!.</span>
                <span class="form-subtitle">Por favor ingrese.</span>
            </div>*@
            @Code
            If Html.ViewData.ModelState.IsValid = False Then
                @<div class="alert alert-danger">
                    <button class="close" data-close="alert"></button>
                    <span>
                        @Html.ValidationSummary(False)
                    </span>
                </div>
            End If
            End Code
            @<div class="form-group">
                @Html.LabelFor(Function(model) model.NombreUsuario, New With {.class = "control-label visible-ie8 visible-ie9"})
                @Html.TextBoxFor(Function(model) model.NombreUsuario, New With {.class = "form-control form-control-solid placeholder-no-fix", .autocomplete = "off", .placeholder = "Nombre de usuario"})
            </div>
            @<div class="form-group">
                @Html.LabelFor(Function(model) model.Clave, New With {.class = "control-label visible-ie8 visible-ie9"})
                @Html.PasswordFor(Function(model) model.Clave, New With {.class = "form-control form-control-solid placeholder-no-fix", .autocomplete = "off", .placeholder = "Contraseña"})
            </div>

            '<div class="form-group">
            '    <!--ie8, ie9 does not support html5 placeholder, so we just show field title for that-->
            '    <label class="control-label visible-ie8 visible-ie9">Username</label>
            '    <input class="form-control form-control-solid placeholder-no-fix" type="text" autocomplete="off" placeholder="Username" name="username" />
            '</div>
            '<div class="form-group">
            '    <label class="control-label visible-ie8 visible-ie9">Password</label>
            '    <input class="form-control form-control-solid placeholder-no-fix" type="password" autocomplete="off" placeholder="Password" name="password" />
            '</div>
            
            @<div class="form-actions">
                <button type="submit" class="btn btn-primary btn-block uppercase">Login</button>
            </div>
            @<div class="form-actions">
                <div class="pull-left">
                    <label class="rememberme check">
                        @Html.CheckBoxFor(Function(model) model.Recordarme, New With {.value = "1"})@Html.LabelFor(Function(model) model.Recordarme)
                        @*<input type="checkbox" name="remember" value="1" />Recordarme?*@
                    </label>
                </div>
                <div class="pull-right forget-password-block">
                    <a href="javascript:;" id="forget-password" class="forget-password">Olvidó contraseña?</a>
                </div>
            </div>
                                   '<div class="login-options">
                                   '    <h4 class="pull-left">Or login with</h4>
                                   '    <ul class="social-icons pull-right">
                                   '        <li>
                                   '            <a class="social-icon-color facebook" data-original-title="facebook" href="javascript:;"></a>
                                   '        </li>
                                   '        <li>
                                   '            <a class="social-icon-color twitter" data-original-title="Twitter" href="javascript:;"></a>
                                   '        </li>
                                   '        <li>
                                   '            <a class="social-icon-color googleplus" data-original-title="Goole Plus" href="javascript:;"></a>
                                   '        </li>
                                   '        <li>
                                   '            <a class="social-icon-color linkedin" data-original-title="Linkedin" href="javascript:;"></a>
                                   '        </li>
                                   '    </ul>
                                   '</div>
                                   '<div class="create-account">
                                   '    <p>
                                   '        <a href="javascript:;" id="register-btn">Create an account</a>
                                   '    </p>
            '</div>
        End Using

        <!-- END LOGIN FORM -->
        <!-- BEGIN FORGOT PASSWORD FORM -->
        @Using (Html.BeginForm("EnviarClave", "Usuario", Nothing, FormMethod.Post, New With {.class = "forget-form"}))
            @<div class="form-title">
                <span class="form-title">Olvidó Contraseña?</span>
                <span class="form-subtitle">Ingrese su email y se la enviaremos.</span>
            </div>
            @<div class="form-group">
                <input class="form-control placeholder-no-fix input-icon" type="text" autocomplete="off" placeholder="Email" name="email" />
            </div>
            @<div class="form-actions">
                <button type="button" id="back-btn" class="btn btn-default">Volver</button>
                <button type="submit" class="btn btn-primary uppercase pull-right">Aceptar</button>
            </div>   
        End Using
        <!-- END FORGOT PASSWORD FORM -->
    </div>
    <!-- END LOGIN -->
    <!-- BEGIN JAVASCRIPTS(Load javascripts at bottom, this will reduce page load time) -->
    <!-- BEGIN CORE PLUGINS -->
    @Scripts.Render("~/Content/global/js")
    <!-- END CORE PLUGINS -->
    <!-- BEGIN PAGE LEVEL SCRIPTS -->
    @Scripts.Render("~/Content/theme/js")
    @Scripts.Render("~/Content/login/js")
    <!-- END PAGE LEVEL SCRIPTS -->
    <script>
        jQuery(document).ready(function() {
            Metronic.init(); // init metronic core components
            Layout.init(); // init current layout
            Login.init();
        });
    </script>
    <!-- END JAVASCRIPTS -->
</body>
<!-- END BODY -->
</html>
