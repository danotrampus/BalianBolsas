@ModelType IEnumerable(Of EE.Pedido)

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
            <a href="#">Pedidos</a>
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
            var table = $('#tablaPedidos');

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
                    <i class="fa fa-user"></i>Listado de Pedidos
                </div>
                <div class="tools">
                    <a href="javascript:;" class="collapse">
                    </a>
                    <a href="javascript:;" class="remove">
                    </a>
                </div>
            </div>
            <div class="portlet-body">
                <table class="table table-striped table-bordered table-hover" id="tablaPedidos">
                    <thead>
                        <tr>
                            <th>N° de orden</th>
                            <th>Fecha Inicio</th>
                            <th>Fecha Fin</th>
                            <th>Importe</th>
                            <th>Estado</th>
                            <th>Usuario</th>
                            <th>Acciones</th>
                        </tr>
                    </thead>
                    <tbody>
                        @For Each item In Model
                            Dim currentItem = item
                            
                        @<tr class="odd gradeX">
                             <td>
                                 @Html.DisplayFor(Function(modelItem) currentItem.Id)
                             </td>
                             <td>
                                 @Html.DisplayFor(Function(modelItem) currentItem.FechaInicio)
                             </td>
                             <td>
                                 @Html.DisplayFor(Function(modelItem) currentItem.FechaFin)
                             </td>
                             <td>
                                 @Html.DisplayFor(Function(modelItem) currentItem.Importe)
                             </td>
                             <td>
                                 @Html.DisplayFor(Function(modelItem) currentItem.Estado)
                             </td>
                             <td>
                                 @Html.DisplayFor(Function(modelItem) currentItem.Usuario.NombreUsuario)
                             </td>
                             <td class="text-center">
                                 @Code
                                 If User.IsInRole("ConsultarPedido") Then
                                     @Html.ActionLink("Ver", "Detalles", New With {.id = currentItem.Id}, New With {.class = "btn btn-primary btn-cons"})
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
