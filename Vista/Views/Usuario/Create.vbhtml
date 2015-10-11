@ModelType EE.Usuario

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
            <a href="@Url.Action("Index", "Usuario")">Usuarios</a>
            <i class="fa fa-angle-right"></i>
        </li>
        <li>
            <a href="#">Crear</a>
        </li>
    </ul>
End Section

@Section stylesheets
    @Styles.Render("~/Content/select2/css")
End Section

@Section javascripts
    @Scripts.Render("~/Content/select2/js")
End Section

@Section javascript_codigo
    <script type="text/javascript">
        $(document).ready(function () {
            $("form").validate();
            $("#PerfilesId").select2();
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
                         <div class="form-group @IIf(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.PerfilesId))), Nothing, "has-error")">
                             @Html.LabelFor(Function(model) model.PerfilesId, New With {.class = "control-label"})
                             @Html.ListBoxFor(Function(model) model.PerfilesId, New MultiSelectList(ViewBag.Perfiles, "Id", "Nombre"), New With {.style = "width: 100%"})
                             @Html.ValidationMessageFor(Function(model) model.PerfilesId, Nothing, New With {.class = "help-block"})
                         </div>
                    </div>
                    @<div class="form-actions">
                        <button type="submit" class="btn blue">Grabar</button>
                        @Html.ActionLink("Volver", "Index", Nothing, New With {.class = "btn default"})
                    </div>
                End Using
            </div>
        </div>
        <!-- END SAMPLE FORM PORTLET-->
    </div>    
</div>
