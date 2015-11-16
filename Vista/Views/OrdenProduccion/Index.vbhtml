@ModelType IEnumerable(Of EE.OrdenProduccion)

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
            <a href="#">Ordenes de Producción</a>
        </li>
    </ul>
End Section

@Section stylesheets
    @Styles.Render("~/Content/select2/css")
    @Styles.Render("~/Content/datatables/css")
End Section

@Section javascripts
    @Scripts.Render("~/Content/select2/js")
    @Scripts.Render("~/Content/datatables/js")
End Section

@Section javascript_codigo
    <script type="text/javascript">
        $(document).ready(function () {
            var table = $('#tablaOrdenes');

            table.dataTable({
                "language": {
                    "sProcessing": "Procesando...",
                    "sLengthMenu": "Mostrar _MENU_ registros",
                    "sZeroRecords": "No se encontraron resultados",
                    "sEmptyTable": "Ningún dato disponible en esta tabla",
                    "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                    "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                    "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                    "sInfoPostFix": "",
                    "sSearch": "Buscar:",
                    "sUrl": "",
                    "sInfoThousands": ",",
                    "sLoadingRecords": "Cargando...",
                    "oPaginate": {
                        "sFirst": "Primero",
                        "sLast": "Último",
                        "sNext": "Siguiente",
                        "sPrevious": "Anterior"
                    },
                    "oAria": {
                        "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                        "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                    }
                },
                "bStateSave": true
            });
        });
    </script>
End Section

<div class="row">
    <div class="col-md-12">
        <!-- BEGIN EXAMPLE TABLE PORTLET-->
        <div class="portlet box grey-cascade">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-user"></i>Listado de Ordenes
                </div>
                <div class="tools">
                    <a href="javascript:;" class="collapse">
                    </a>
                    <a href="javascript:;" class="remove">
                    </a>
                </div>
            </div>
            <div class="portlet-body">
                <table class="table table-striped table-bordered table-hover" id="tablaOrdenes">
                    <thead>
                        <tr>
                            <th>Tipo</th>
                            <th>Fecha Inicio</th>
                            <th>Fecha Fin</th>
                            <th>Cantidad</th>
                            <th>Observacion</th>
                            <th>Estado</th>
                            <th>Acciones</th>
                        </tr>
                    </thead>
                    <tbody>
                        @For Each item In Model
                            Dim currentItem = item

                            @<tr class="odd gradeX">
                                <td>
                                    @Html.DisplayFor(Function(modelItem) currentItem.Tipo)
                                </td>
                                <td>
                                    @IIf(currentItem.FechaInicio = Nothing, "", currentItem.FechaInicio)
                                </td>
                                <td>
                                    @IIf(currentItem.FechaFin = Nothing, "", currentItem.FechaFin)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) currentItem.Cantidad)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) currentItem.Observacion)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) currentItem.Estado)
                                </td>
                                 <td class="text-center">
                                     @Code
                                     If currentItem.Estado = "Pendiente" Then
                                     If User.IsInRole("IniciarOrden") Then
                                         @Html.ActionLink("Iniciar", "Iniciar", New With {.id = currentItem.Id}, New With {.class = "btn btn-primary btn-cons"})
                                     End If
                                     ElseIf currentItem.Estado = "En Proceso" Then
                                     If User.IsInRole("TerminarOrden") Then
                                         @Html.ActionLink("Terminar", "Terminar", New With {.id = currentItem.Id}, New With {.class = "btn btn-primary btn-cons"})
                                     End If
                                     End If
                                     End Code
                                 </td>
                            </tr>
                        Next
                    </tbody>
                </table>
            </div>
        </div>
        <!-- END EXAMPLE TABLE PORTLET-->
    </div>
</div>
