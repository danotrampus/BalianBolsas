@ModelType EE.Impresion

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
            <a href="@Url.Action("Index", "Impresion")">Impresiones</a>
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
            $("#Tratado").select2();
            $("#CantidadColores").select2();
        });
    </script>
End Section

<div class="row">
    <div class="col-md-12">
        <!-- BEGIN SAMPLE FORM PORTLET-->
        <div class="portlet box blue">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-print"></i> Nueva Impresión
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
                         <div class="form-group @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Tratado))), Nothing, "has-error"))">
                             @Html.LabelFor(Function(model) model.Tratado, New With {.class = "control-label"})
                             @Html.DropDownListFor(Function(model) model.Tratado, New List(Of SelectListItem)() From { _
                                New SelectListItem() With {.Text = "Simple", .Value = "Simple"},
                                New SelectListItem() With {.Text = "Doble", .Value = "Doble"}
                             }, "", New With {.class = "form-control"})
                             @Html.ValidationMessageFor(Function(model) model.Tratado, Nothing, New With {.class = "help-block"})
                         </div>
                         <div class="form-group @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.CantidadColores))), Nothing, "has-error"))">
                             @Html.LabelFor(Function(model) model.CantidadColores, New With {.class = "control-label"})
                             @Html.DropDownListFor(Function(model) model.CantidadColores, New List(Of SelectListItem)() From { _
                                New SelectListItem() With {.Text = "1", .Value = "1"},
                                New SelectListItem() With {.Text = "2", .Value = "2"},
                                New SelectListItem() With {.Text = "3", .Value = "3"},
                                New SelectListItem() With {.Text = "4", .Value = "4"}
                             }, "", New With {.class = "form-control"})
                             @Html.ValidationMessageFor(Function(model) model.CantidadColores, Nothing, New With {.class = "help-block"})
                         </div>
                        <div class="form-group @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Precio))), Nothing, "has-error"))">
                            <label class="control-label">Precio x1000 Metros</label>
                            @Html.TextBoxFor(Function(model) model.Precio, New With {.class = "form-control", .placeholder = "XXXXXX,XXX"})
                            @Html.ValidationMessageFor(Function(model) model.Precio, Nothing, New With {.class = "help-block"})
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