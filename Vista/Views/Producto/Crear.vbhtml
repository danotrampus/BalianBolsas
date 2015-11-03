@ModelType EE.Producto

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
            <a href="@Url.Action("Index", "Producto")">Productos</a>
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
            $("#Impresion_Id").select2();
            $("#Polimero_Id").select2();
            $("#Soldadura").select2();
            $("#Formato").select2();
            $("input[type=radio][name=Type]").first().attr("checked", true).parents("span").addClass("checked");
        });
    </script>
End Section

<div class="row">
    <div class="col-md-12">
        <!-- BEGIN SAMPLE FORM PORTLET-->
        <div class="portlet box blue">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-eyedropper"></i> Nuevo Producto
                    <div class="tools">
                        <a href="" class="collapse">
                        </a>
                        <a href="" class="remove">
                        </a>
                    </div>
                </div>
            </div>
            <div class="portlet-body form">
                    @Using Html.BeginForm("Crear", "Producto", FormMethod.Post, New With {.enctype = "multipart/form-data"})
                        @Html.AntiForgeryToken()
                        @Html.ValidationSummary(True)

                        @<div class="form-body">
                             <div class="form-group">
                                 <label class="control-label">Tipo</label>
                                 <div class="radio-list">
                                     <label>
                                         @Html.RadioButtonFor(Function(model) model.Type, "Bolsa") Bolsa
                                     </label>
                                     <label>
                                         @Html.RadioButtonFor(Function(model) model.Type, "Bobina") Bobina
                                     </label>
                                 </div>
                             </div>
                            <div class="form-group @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Ancho))), Nothing, "has-error"))">
                                @Html.LabelFor(Function(model) model.Ancho, New With {.class = "control-label"})
                                @Html.TextBoxFor(Function(model) model.Ancho, New With {.class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.Ancho, Nothing, New With {.class = "help-block"})
                            </div>
                            <div class="form-group @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Largo))), Nothing, "has-error"))">
                                @Html.LabelFor(Function(model) model.Largo, New With {.class = "control-label"})
                                @Html.TextBoxFor(Function(model) model.Largo, New With {.class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.Largo, Nothing, New With {.class = "help-block"})
                            </div>
                             <div class="form-group @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Espesor))), Nothing, "has-error"))">
                                 @Html.LabelFor(Function(model) model.Espesor, New With {.class = "control-label"})
                                 @Html.TextBoxFor(Function(model) model.Espesor, New With {.class = "form-control"})
                                 @Html.ValidationMessageFor(Function(model) model.Espesor, Nothing, New With {.class = "help-block"})
                             </div>
                             <div class="form-group @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Soldadura))), Nothing, "has-error"))">
                                 @Html.LabelFor(Function(model) model.Soldadura, New With {.class = "control-label"})
                                 @Html.DropDownListFor(Function(model) model.Soldadura, New List(Of SelectListItem)() From { _
                                 New SelectListItem() With {.Text = "Lateral", .Value = "Lateral"},
                                 New SelectListItem() With {.Text = "Fondo", .Value = "Fondo"}
                                 }, "", New With {.class = "form-control"})
                                 @Html.ValidationMessageFor(Function(model) model.Soldadura, Nothing, New With {.class = "help-block"})
                             </div>
                             <div class="form-group @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Formato))), Nothing, "has-error"))">
                                 @Html.LabelFor(Function(model) model.Formato, New With {.class = "control-label"})
                                 @Html.DropDownListFor(Function(model) model.Formato, New List(Of SelectListItem)() From { _
                                 New SelectListItem() With {.Text = "Sobre", .Value = "Sobre"},
                                 New SelectListItem() With {.Text = "Fuelle Americano", .Value = "Fuelle Americano"},
                                 New SelectListItem() With {.Text = "Con Manija", .Value = "Con Manija"},
                                 New SelectListItem() With {.Text = "Camiseta", .Value = "Camiseta"},
                                 New SelectListItem() With {.Text = "Riñon", .Value = "Riñon"}
                                 }, "", New With {.class = "form-control"})
                                 @Html.ValidationMessageFor(Function(model) model.Formato, Nothing, New With {.class = "help-block"})
                             </div>
                             <div class="form-group @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Polimero.Id))), Nothing, "has-error"))">
                                 @Html.LabelFor(Function(model) model.Polimero.Id, New With {.class = "control-label"})
                                 @Html.DropDownListFor(Function(model) model.Polimero.Id, New SelectList(ViewBag.Polimeros, "Id", "Nombre"), "", New With {.class = "form-control"})
                                 @Html.ValidationMessageFor(Function(model) model.Polimero.Id, Nothing, New With {.class = "help-block"})
                             </div>
                             <div class="form-group @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Impresion.Id))), Nothing, "has-error"))">
                                 @Html.LabelFor(Function(model) model.Impresion.Id, New With {.class = "control-label"})
                                 @Html.DropDownListFor(Function(model) model.Impresion.Id, New SelectList(ViewBag.Impresiones, "Id", "Nombre"), "", New With {.class = "form-control"})
                                 @Html.ValidationMessageFor(Function(model) model.Impresion.Id, Nothing, New With {.class = "help-block"})
                             </div>
                             <div class="form-group">
                                 <label for="Archivo" class="control-label">Imagen</label>
                                 <input type="file" name="Archivo" />
                                 @Html.ValidationMessage("Archivo", New With {.class = "error"})
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
