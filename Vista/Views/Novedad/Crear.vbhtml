@ModelType NovedadViewModel

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
            <a href="@Url.Action("Index", "Novedad")">Novedades</a>
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
            $("#CategoriaId").select2();
            $("#Tipo").select2();

            $('#summernote').summernote({
                height: 200,
                onfocus: function (e) {
                    $('body').addClass('overlay-disabled');
                },
                onblur: function (e) {
                    $('body').removeClass('overlay-disabled');
                }
            });
            $('#formNovedad').submit(function () {
                var sHTML = $('#summernote').code();
                $('#Contenido').val(sHTML);
            });
        });
    </script>
End Section

<div class="row">
    <div class="col-md-12">
        <!-- BEGIN SAMPLE FORM PORTLET-->
        <div class="portlet box blue">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-rss"></i> Nueva Novedad
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
                        <div class="form-group @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Tipo))), Nothing, "has-error"))">
                            @Html.LabelFor(Function(model) model.Tipo, New With {.class = "control-label"})
                            @Html.DropDownListFor(Function(model) model.Tipo, New List(Of SelectListItem)() From { _
                                New SelectListItem() With {.Text = "Noticia", .Value = "Noticia"},
                                New SelectListItem() With {.Text = "Novedad", .Value = "Novedad"}
                             }, "", New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(model) model.Tipo, Nothing, New With {.class = "help-block"})
                        </div>
                        <div class="form-group @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Titulo))), Nothing, "has-error")) ">
                            @Html.LabelFor(Function(model) model.Titulo, New With {.class = "control-label"})
                            @Html.TextBoxFor(Function(model) model.Titulo, New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(model) model.Titulo, Nothing, New With {.class = "help-block"})
                        </div>
                        <div class="form-group @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.CategoriaId))), Nothing, "has-error"))">
                            @Html.LabelFor(Function(model) model.CategoriaId, New With {.class = "control-label"})
                            @Html.DropDownListFor(Function(model) model.CategoriaId, New SelectList(ViewBag.Categorias, "Id", "Nombre"), "", New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(model) model.CategoriaId, Nothing, New With {.class = "help-block"})
                        </div>
                        <div class="form-group @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Contenido))), Nothing, "has-error")) ">
                            @Html.LabelFor(Function(model) model.Contenido, New With {.class = "control-label"})
                            <div class="summernote-wrapper">
                                <div id="summernote">
                                    @Html.Raw(Model.Contenido)
                                </div>
                            </div>
                            @Html.ValidationMessageFor(Function(model) model.Contenido, Nothing, New With {.class = "help-block"})
                        </div>
                        @Html.HiddenFor(Function(model) model.Contenido)
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
