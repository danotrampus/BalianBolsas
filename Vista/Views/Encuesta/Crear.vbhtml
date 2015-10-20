@ModelType EE.Encuesta

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
            <a href="@Url.Action("Index", "Encuesta")">Encuestas</a>
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
            $("#Tipo").select2();
        });
    </script>
End Section

<div class="row">
    <div class="col-md-12">
        <!-- BEGIN SAMPLE FORM PORTLET-->
        <div class="portlet box blue">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-user"></i> Nueva Encuesta
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
                                New SelectListItem() With {.Text = "Encuesta", .Value = "Encuesta"},
                                New SelectListItem() With {.Text = "Ficha Opinion", .Value = "Ficha Opinion"}
                             }, "", New With {.class = "form-control"})
                             @Html.ValidationMessageFor(Function(model) model.Tipo, Nothing, New With {.class = "help-block"})
                         </div>
                         <div class="form-group @IIf(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.FechaVigencia))), Nothing, "has-error")">
                             @Html.LabelFor(Function(model) model.FechaVigencia, New With {.class = "control-label"})
                             @Html.EditorFor(Function(model) model.FechaVigencia, New With {.class = "form-control"})
                             @Html.ValidationMessageFor(Function(model) model.FechaVigencia, Nothing, New With {.class = "help-block"})
                         </div>
                         <div class="form-group @IIf(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Pregunta))), Nothing, "has-error")">
                             @Html.LabelFor(Function(model) model.Pregunta, New With {.class = "control-label"})
                             @Html.TextBoxFor(Function(model) model.Pregunta, New With {.class = "form-control"})
                             @Html.ValidationMessageFor(Function(model) model.Pregunta, Nothing, New With {.class = "help-block"})
                         </div>
                         <div class="form-group @IIf(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.ListaOpciones))), Nothing, "has-error")">
                             @Code
                             For Each opcion As EE.Opcion In Model.ListaOpciones
                             Html.RenderPartial("OpcionFila", opcion)
                             Next
                             End Code
                             @Html.LabelFor(Function(model) model.ListaOpciones, New With {.class = "control-label"})
                             @Html.EditorFor(Function(model) model.ListaOpciones, New With {.class = "form-control"})
                             @Html.ValidationMessageFor(Function(model) model.ListaOpciones, Nothing, New With {.class = "help-block"})
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
