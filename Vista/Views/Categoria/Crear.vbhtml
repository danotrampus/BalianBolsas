@ModelType EE.Categoria

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
            <a href="@Url.Action("Index", "Categoria")">Categorias</a>
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

<div class="row">
    <div class="col-md-12">
        <!-- BEGIN SAMPLE FORM PORTLET-->
        <div class="portlet box blue">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-eyedropper"></i> Nueva Categoria
                    <div class="tools">
                        <a href="" class="collapse">
                        </a>
                        <a href="" class="remove">
                        </a>
                    </div>
                </div>
            </div>
            <div class="portlet-body form">
                    @Using Html.BeginForm()
                        @Html.AntiForgeryToken()
                        @Html.ValidationSummary(True)

                        @<div class="form-body">
                            <div class="form-group @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Nombre))), Nothing, "has-error"))">
                                @Html.LabelFor(Function(model) model.Nombre, New With {.class = "control-label"})
                                @Html.TextBoxFor(Function(model) model.Nombre, New With {.class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.Nombre, Nothing, New With {.class = "help-block"})
                            </div>
                        </div>
                        @<div class="form-actions">
                            <button type="submit" class="btn blue">Grabar</button>
                            @Html.ActionLink("Volver", "Index", Nothing, New With {.class = "btn default"})
                        </div>
                    End Using
                </div>
            <!-- END SAMPLE FORM PORTLET-->
        </div>
    </div>
</div>
