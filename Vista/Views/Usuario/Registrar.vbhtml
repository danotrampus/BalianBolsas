@ModelType Vista.RegistrarViewModel

@Code
    Layout = "~/Views/Shared/_BackEnd.vbhtml"
End Code

@Section breadcrumbs
    <ul class="page-breadcrumb">
        <li>
            <i class="fa fa-home"></i>
            <a href="@Url.Action("Index", "Home")">Home</a>
            <i class="fa fa-angle-right"></i>
        </li>
        <li>
            <a href="#">Registrarse</a>
        </li>
    </ul>
End Section

@Section javascript_codigo
    <script type="text/javascript">
        $(document).ready(function () {
            $("form").validate();
        });
    </script>
End Section

<div class="row">
    <div class="col-md-12">
        <!-- BEGIN SAMPLE FORM PORTLET-->
        <div class="portlet box blue">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-user"></i> Nuevo Usuario
                </div>
                <div class="tools">
                    <a href="" class="collapse">
                    </a>
                    <a href="" class="remove">
                    </a>
                </div>
            </div>
            <div class="portlet-body form">
                @Using Html.BeginForm()
                    @Html.AntiForgeryToken()
                    @Html.ValidationSummary(True)

                    @<div class="form-body">
                        <div class="form-group @IIf(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Nombre))),Nothing,"has-error")">
                            @Html.LabelFor(Function(model) model.Nombre, New With {.class = "control-label"})
                            @Html.TextBoxFor(Function(model) model.Nombre, New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(model) model.Nombre, Nothing, New With {.class = "help-block"})
                        </div>
                        <div class="form-group @IIf(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Apellido))), Nothing, "has-error")">
                            @Html.LabelFor(Function(model) model.Apellido, New With {.class = "control-label"})
                            @Html.TextBoxFor(Function(model) model.Apellido, New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(model) model.Apellido, Nothing, New With {.class = "help-block"})
                        </div>
                        <div class="form-group @IIf(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Email))), Nothing, "has-error")">
                            @Html.LabelFor(Function(model) model.Email, New With {.class = "control-label"})
                            @Html.TextBoxFor(Function(model) model.Email, New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(model) model.Email, Nothing, New With {.class = "help-block"})
                        </div>
                        <div class="form-group @IIf(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.NombreUsuario))), Nothing, "has-error")">
                            @Html.LabelFor(Function(model) model.NombreUsuario, New With {.class = "control-label"})
                            @Html.TextBoxFor(Function(model) model.NombreUsuario, New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(model) model.NombreUsuario, Nothing, New With {.class = "help-block"})
                        </div>
                        <div class="form-group @IIf(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Clave))),Nothing,"has-error")">
                            @Html.LabelFor(Function(model) model.Clave, New With {.class = "control-label"})
                            @Html.PasswordFor(Function(model) model.Clave, New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(model) model.Clave, Nothing, New With {.class = "help-block"})
                        </div>
                        <div class="form-group @IIf(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.ConfirmaClave))), Nothing, "has-error")">
                            @Html.LabelFor(Function(model) model.ConfirmaClave, New With {.class = "control-label"})
                            @Html.PasswordFor(Function(model) model.ConfirmaClave, New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(model) model.ConfirmaClave, Nothing, New With {.class = "help-block"})
                        </div>
                    </div>
                    @<div class="form-actions">
                        <button type="submit" class="btn blue">Grabar</button>
                    </div>
                End Using
            </div>
        </div>
        <!-- END SAMPLE FORM PORTLET-->
    </div>
</div>
