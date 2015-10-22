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
            <a href="#">Detalle</a>
        </li>
    </ul>
End Section

@Section javascripts
    @Scripts.Render("~/Content/flotchart/js")
End Section

@Section javascript_codigo
    <script type="text/javascript">
        $(document).ready(function(){
            if ($('#pie_chart_1').size() !== 0) {
                var data = @Html.Raw(ViewBag.ListaSelecciones);
                $.plot($("#pie_chart_1"), data, {
                    series: {
                        pie: {
                            show: true
                        }
                    },
                    legend: {
                        show: false
                    }
                });
            }
        });
    </script>
End Section

<div class="row">
    <div class="col-md-12">
        <!-- BEGIN Portlet PORTLET-->
        <div class="portlet box blue">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-question"></i>Detalle de encuesta
                </div>
                <ul class="nav nav-tabs">
                    <li class="active">
                        <a href="#portlet_tab1" data-toggle="tab">
                            Información Básica
                        </a>
                    </li>
                    <li>
                        <a href="#portlet_tab2" data-toggle="tab">
                            Estadísticas
                        </a>
                    </li>
                </ul>
            </div>
            <div class="portlet-body">
                <div class="tab-content">
                    <div class="tab-pane active" id="portlet_tab1">
                        <p>
                            @Html.DisplayNameFor(Function(model) model.Tipo): @Html.DisplayFor(Function(model) model.Tipo)<br />
                            @Html.DisplayNameFor(Function(model) model.FechaVigencia): @Html.DisplayFor(Function(model) model.FechaVigencia)<br />
                            @Html.DisplayNameFor(Function(model) model.Pregunta): @Html.DisplayFor(Function(model) model.Pregunta)<br />
                            <label>Respuestas:</label>
                            <ul>
                                @Code
                                    For Each opcion As EE.Opcion In Model.ListaOpciones
                                @<li>@opcion.Valor</li>
                                    Next
                                End Code
                            </ul>
                        </p>
                    </div>
                    <div class="tab-pane" id="portlet_tab2">
                        <div id="pie_chart_1" class="chart">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="row">
    <div class="col-md-12">
        @Code
            If User.IsInRole("ListarEncuestas") Then
        @Html.ActionLink("Volver", "Index", Nothing, New With {.class = "btn default"})
            End If
            If User.IsInRole("EditarEncuesta") Then
        @Html.ActionLink("Editar", "Editar", New With {.id = Model.Id}, New With {.class = "btn blue"})
            End If
            If User.IsInRole("EliminarEncuesta") Then
        @<a class="btn red" data-toggle="modal" href="#delete-confirmation">Eliminar</a>
            End If
        End Code
    </div>
</div>

@Using Html.BeginForm("Eliminar", "Encuesta", New With {.id = Model.Id}, FormMethod.Get)
    @Html.AntiForgeryToken()
    @<div class="modal fade" id="delete-confirmation" tabindex="-1" role="basic" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h4 class="modal-title">Confirma que desea eliminar el registro?</h4>
                </div>
                <div class="modal-body">
                    Esta operación no se puede deshacer.
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn default" data-dismiss="modal">Cerrar</button>
                    <button type="submit" class="btn blue">Aceptar</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
End Using