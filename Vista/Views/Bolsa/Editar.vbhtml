@ModelType BolsaViewModel

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
            <a href="@Url.Action("Index", "Bolsa")">Bolsa</a>
            <i class="fa fa-angle-right"></i>
        </li>
        <li>
            <a href="#">Editar</a>
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
            $("#ImpresionId").select2();
            $("#PolimeroId").select2();
            $("#ManijaId").select2();
            $("#Soldadura").select2();
            $("#Formato").select2();
        });
    </script>
End Section

<div class="row">
    <div class="col-md-12">
        <!-- BEGIN SAMPLE FORM PORTLET-->
        <div class="portlet box blue">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-calendar-o"></i> Editar Bolsa
                    <div class="tools">
                        <a href="" class="collapse">
                        </a>
                        <a href="" class="remove">
                        </a>
                    </div>
                </div>
            </div>
            <div class="portlet-body form">
                @Using Html.BeginForm("Editar", "Bolsa", FormMethod.Post, New With {.enctype = "multipart/form-data"})
                    @Html.AntiForgeryToken()
                    @Html.ValidationSummary(True)
                    
                    @Html.HiddenFor(Function(model) model.Id)
                    
                    @<div class="form-body">
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Ancho))), Nothing, "has-error"))">
                                    @Html.LabelFor(Function(model) model.Ancho, New With {.class = "control-label"})
                                    @Html.TextBoxFor(Function(model) model.Ancho, New With {.class = "form-control"})
                                    @Html.ValidationMessageFor(Function(model) model.Ancho, Nothing, New With {.class = "help-block"})
                                </div>
                            </div>
                            <div class="col-md-4" id="campoLargo">
                                <div class="form-group @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Largo))), Nothing, "has-error"))">
                                    @Html.LabelFor(Function(model) model.Largo, New With {.class = "control-label"})
                                    @Html.TextBoxFor(Function(model) model.Largo, New With {.class = "form-control"})
                                    @Html.ValidationMessageFor(Function(model) model.Largo, Nothing, New With {.class = "help-block"})
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Espesor))), Nothing, "has-error"))">
                                    @Html.LabelFor(Function(model) model.Espesor, New With {.class = "control-label"})
                                    @Html.TextBoxFor(Function(model) model.Espesor, New With {.class = "form-control"})
                                    @Html.ValidationMessageFor(Function(model) model.Espesor, Nothing, New With {.class = "help-block"})
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Soldadura))), Nothing, "has-error"))">
                                    @Html.LabelFor(Function(model) model.Soldadura, New With {.class = "control-label"})
                                    @Html.DropDownListFor(Function(model) model.Soldadura, New List(Of SelectListItem)() From { _
                                         New SelectListItem() With {.Text = "Lateral", .Value = "Lateral"},
                                         New SelectListItem() With {.Text = "Fondo", .Value = "Fondo"}
                                         }, "", New With {.class = "form-control"})
                                    @Html.ValidationMessageFor(Function(model) model.Soldadura, Nothing, New With {.class = "help-block"})
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Formato))), Nothing, "has-error"))">
                                    @Html.LabelFor(Function(model) model.Formato, New With {.class = "control-label"})
                                    @Html.DropDownListFor(Function(model) model.Formato, New List(Of SelectListItem)() From { _
                                         New SelectListItem() With {.Text = "Sobre", .Value = "Sobre"},
                                         New SelectListItem() With {.Text = "Tubo", .Value = "Tubo"},
                                         New SelectListItem() With {.Text = "Fuelle Americano", .Value = "Fuelle Americano"}
                                         }, "", New With {.class = "form-control"})
                                    @Html.ValidationMessageFor(Function(model) model.Formato, Nothing, New With {.class = "help-block"})
                                </div>
                            </div>
                        </div>
                         <div class="form-group @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.PolimeroId))), Nothing, "has-error"))">
                             @Html.LabelFor(Function(model) model.PolimeroId, New With {.class = "control-label"})
                             @Html.DropDownListFor(Function(model) model.PolimeroId, New SelectList(ViewBag.Polimeros, "Id", "Nombre"), "", New With {.class = "form-control"})
                             @Html.ValidationMessageFor(Function(model) model.PolimeroId, Nothing, New With {.class = "help-block"})
                         </div>
                        <div class="form-group @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.ImpresionId))), Nothing, "has-error"))">
                            @Html.LabelFor(Function(model) model.ImpresionId, New With {.class = "control-label"})
                            @Html.DropDownListFor(Function(model) model.ImpresionId, New SelectList(ViewBag.Impresiones, "Id", "Nombre"), "", New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(model) model.ImpresionId, Nothing, New With {.class = "help-block"})
                        </div>
                         <div class="form-group @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.ManijaId))), Nothing, "has-error"))">
                             @Html.LabelFor(Function(model) model.ManijaId, New With {.class = "control-label"})
                             @Html.DropDownListFor(Function(model) model.ManijaId, New SelectList(ViewBag.Manijas, "Id", "Nombre"), "", New With {.class = "form-control"})
                             @Html.ValidationMessageFor(Function(model) model.ManijaId, Nothing, New With {.class = "help-block"})
                         </div>
                         <div class="form-group @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Imagen))), Nothing, "has-error"))">
                             @Html.LabelFor(Function(model) model.Imagen, New With {.class = "control-label"})
                             @Html.TextBoxFor(Function(model) model.Imagen, New With {.type = "file"})
                             @Html.ValidationMessageFor(Function(model) model.Imagen, Nothing, New With {.class = "help-block"})
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
