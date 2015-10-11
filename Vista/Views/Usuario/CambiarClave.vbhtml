@ModelType Vista.CambioClaveViewModel

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
            <a href="@Url.Action("Mi Cuenta", "Usuario")">Mi Cuenta</a>
            <i class="fa fa-angle-right"></i>
        </li>
        <li>
            <a href="#">Cambiar Clave</a>
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
                        <div class="form-group @IIf(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.ClaveVieja))), Nothing, "has-error")">
                            @Html.LabelFor(Function(model) model.ClaveVieja, New With {.class = "control-label"})
                            @Html.TextBoxFor(Function(model) model.ClaveVieja, New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(model) model.ClaveVieja, Nothing, New With {.class = "help-block"})
                        </div>
                        <div class="form-group @IIf(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.ClaveNueva))), Nothing, "has-error")">
                            @Html.LabelFor(Function(model) model.ClaveNueva, New With {.class = "control-label"})
                            @Html.TextBoxFor(Function(model) model.ClaveNueva, New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(model) model.ClaveNueva, Nothing, New With {.class = "help-block"})
                        </div>
                        <div class="form-group @IIf(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.RepetirClave))), Nothing, "has-error")">
                            @Html.LabelFor(Function(model) model.RepetirClave, New With {.class = "control-label"})
                            @Html.TextBoxFor(Function(model) model.RepetirClave, New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(model) model.RepetirClave, Nothing, New With {.class = "help-block"})
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
