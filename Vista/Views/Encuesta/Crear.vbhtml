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
    @Styles.Render("~/Content/datepicker/css")
End Section

@Section javascripts
    @Scripts.Render("~/Content/select2/js")
    @Scripts.Render("~/Content/datepicker/js")
End Section

@Section javascript_codigo
    <script type="text/javascript">
        $(document).ready(function () {
            $("form").validate();
            $("#Tipo").select2();

            $("#agregarOpcion").click(function () {
                var id = guidGenerator();
                $("#respuestas").append(
                    "<div class='form-group'>" +
                        "<input type='hidden' name='ListaOpciones.Index' value='opcion-" + id + "' />" +
                        "<label class='control-label'>Opción</label>" +
                        "<div class='input-group'>" +
                            "<input type='text' class='form-control' name='ListaOpciones[opcion-" + id + "].Valor'>" +
                            "<span class='input-group-btn'>" +
                                "<button type='button' class='btn red eliminarOpcion' type='button'>Quitar</button>" +
                            "</span>" +
                        "</div>" +
                    "</div>"
                );
                $(".eliminarOpcion").click(function () {
                    $(this).parents(".form-group:first").remove();
                });
            });

            $.fn.datepicker.dates['es'] = {
                days: ["Domingo", "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado"],
                daysShort: ["Dom", "Lun", "Mar", "Mié", "Jue", "Vie", "Sáb"],
                daysMin: ["Do", "Lu", "Ma", "Mi", "Ju", "Vi", "Sa"],
                months: ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"],
                monthsShort: ["Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic"],
                today: "Hoy",
                clear: "Borrar",
                weekStart: 1,
                format: "dd/mm/yyyy"
            };

            $('.date-picker').datepicker({
                language: "es",
                autoclose: true
            });

            $(".eliminarOpcion").click(function () {
                $(this).parents(".form-group:first").remove();
            });
        });

        function guidGenerator() {
            var S4 = function () {
                return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
            };
            return (S4() + S4() + "-" + S4() + "-" + S4() + "-" + S4() + "-" + S4() + S4() + S4());
        }
    </script>
End Section

<div class="row">
    <div class="col-md-12">
        <!-- BEGIN SAMPLE FORM PORTLET-->
        <div class="portlet box blue">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-question"></i> Nueva Encuesta
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
                            <div class="input-group date date-picker" data-date-format="dd/mm/yyyy" data-date-start-date="+0d">
                                @Html.TextBoxFor(Function(model) model.FechaVigencia, New With {.class = "form-control", .readonly = "readonly", .Value = Model.FechaVigencia.ToString("dd/MM/yyyy")})
                                <span class="input-group-btn">
                                    <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                </span>
                            </div>

                            @Html.ValidationMessageFor(Function(model) model.FechaVigencia, Nothing, New With {.class = "help-block"})
                        </div>
                        <div class="form-group @IIf(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Pregunta))), Nothing, "has-error")">
                            @Html.LabelFor(Function(model) model.Pregunta, New With {.class = "control-label"})
                            @Html.TextBoxFor(Function(model) model.Pregunta, New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(model) model.Pregunta, Nothing, New With {.class = "help-block"})
                        </div>
                         <div class="form-group @IIf(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.ListaOpciones))), Nothing, "has-error")" id="respuestas">
                             <label class="control-label">Respuestas:</label>
                             @Code
                             For index = 0 To Model.ListaOpciones.Count() - 1
                             Dim id As String = Guid.NewGuid().ToString()
                                 @<div class='form-group'>
                                     <input type='hidden' name='ListaOpciones.Index' value='opcion-@id' />
                                     <label class='control-label'>Opción</label>
                                     <div class='input-group'>
                                         <input type='text' class='form-control' name='ListaOpciones[opcion-@id].Valor' value="@Model.ListaOpciones(index).Valor">
                                         <span class='input-group-btn'>
                                             <button type='button' class='btn red eliminarOpcion'>Quitar</button>
                                         </span>
                                     </div>
                                 </div>
                             Next
                             End Code
                        @Html.ValidationMessageFor(Function(model) model.ListaOpciones, Nothing, New With {.class = "help-block"}) 
                        </div>
                        <button type="button" class="btn default" id="agregarOpcion">Agregar Opción...</button>
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
