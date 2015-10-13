@ModelType IEnumerable(Of EE.Contacto)

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
            <a href="#">Contacto</a>
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
            var table = $('#tablaContactos');
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
                "bStateSave": true // save datatable state(pagination, sort, etc) in cookie.
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
                    <i class="fa fa-book"></i>Listado de Contactos
                </div>
                <div class="tools">
                    <a href="javascript:;" class="collapse">
                    </a>
                    <a href="javascript:;" class="remove">
                    </a>
                </div>
            </div>
            <div class="portlet-body">
                <div class="table-container">
                    <table class="table table-striped table-bordered table-hover" id="tablaContactos">
                        <thead>
                            <tr role="row" class="heading">
                                <th width="10%">
                                    @Html.DisplayNameFor(Function(model) model.FechaHora)
                                </th>
                                <th width="10%">
                                    @Html.DisplayNameFor(Function(model) model.NombreApellido)
                                </th>
                                <th width="10%">
                                    @Html.DisplayNameFor(Function(model) model.Email)
                                </th>
                                <th width="10%">
                                    @Html.DisplayNameFor(Function(model) model.Asunto)
                                </th>
                                <th width="60%">
                                    @Html.DisplayNameFor(Function(model) model.Mensaje)
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            @For Each item In Model
                                Dim currentItem = item

                                @<tr class="odd gradeX">
                                    <td>
                                        @Html.DisplayFor(Function(modelItem) currentItem.FechaHora)
                                    </td>
                                    <td>
                                        @Html.DisplayFor(Function(modelItem) currentItem.NombreApellido)
                                    </td>
                                    <td>
                                        @Html.DisplayFor(Function(modelItem) currentItem.Email)
                                    </td>
                                    <td>
                                        @Html.DisplayFor(Function(modelItem) currentItem.Asunto)
                                    </td>
                                     <td>
                                         @Html.DisplayFor(Function(modelItem) currentItem.Mensaje)
                                     </td>
                                </tr>
                            Next
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <!-- END EXAMPLE TABLE PORTLET-->
    </div>
</div>