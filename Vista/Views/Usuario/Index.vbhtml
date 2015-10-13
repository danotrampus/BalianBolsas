@ModelType IEnumerable(Of EE.Usuario)

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
            <a href="#">Usuarios</a>
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
            var table = $('#tablaUsuarios');

            // begin first table
            table.dataTable({

                // Internationalisation. For more info refer to http://datatables.net/manual/i18n
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

                // Or you can use remote translation file
                //"language": {
                //   url: '//cdn.datatables.net/plug-ins/3cfcc339e89/i18n/Portuguese.json'
                //},

                // Uncomment below line("dom" parameter) to fix the dropdown overflow issue in the datatable cells. The default datatable layout
                // setup uses scrollable div(table-scrollable) with overflow:auto to enable vertical scroll(see: assets/global/plugins/datatables/plugins/bootstrap/dataTables.bootstrap.js). 
                // So when dropdowns used the scrollable div should be removed. 
                //"dom": "<'row'<'col-md-6 col-sm-12'l><'col-md-6 col-sm-12'f>r>t<'row'<'col-md-5 col-sm-12'i><'col-md-7 col-sm-12'p>>",

                "bStateSave": true, // save datatable state(pagination, sort, etc) in cookie.

                //"columns": [{
                //    "orderable": false
                //}, {
                //    "orderable": true
                //}, {
                //    "orderable": false
                //}, {
                //    "orderable": false
                //}, {
                //    "orderable": true
                //}, {
                //    "orderable": false
                //}],
                //"lengthMenu": [
                //    [5, 15, 20, -1],
                //    [5, 15, 20, "All"] // change per page values here
                //],
                //// set the initial value
                //"pageLength": 5,
                //"pagingType": "bootstrap_full_number",
                //"language": {
                //    "search": "My search: ",
                //    "lengthMenu": "  _MENU_ records",
                //    "paginate": {
                //        "previous": "Prev",
                //        "next": "Next",
                //        "last": "Last",
                //        "first": "First"
                //    }
                //},
                //"columnDefs": [{  // set default column settings
                //    'orderable': false,
                //    'targets': [0]
                //}, {
                //    "searchable": false,
                //    "targets": [0]
                //}],
                //"order": [
                //    [1, "asc"]
                //] // set first column as a default sort by asc
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
                    <i class="fa fa-user"></i>Listado de Usuarios
                </div>
                <div class="tools">
                    <a href="javascript:;" class="collapse">
                    </a>
                    <a href="javascript:;" class="remove">
                    </a>
                </div>
            </div>
            <div class="portlet-body">
                <div class="table-toolbar">
                    <div class="row">
                        <div class="col-md-6">
                            @Code
                                If User.IsInRole("CrearUsuario") Then
                                @<div class="btn-group">
                                    <a href="@Url.Action("Crear")" class="btn green">
                                        Nuevo <i class="fa fa-plus"></i>
                                    </a>
                                </div>
                                End If
                            End Code
                        </div>
                        @*<div class="col-md-6">
                            <div class="btn-group pull-right">
                                <button class="btn dropdown-toggle" data-toggle="dropdown">
                                    Exportar <i class="fa fa-angle-down"></i>
                                </button>
                                <ul class="dropdown-menu pull-right">
                                    <li>
                                        <a href="javascript:;">
                                            Imprimir
                                        </a>
                                    </li>
                                    <li>
                                        <a href="javascript:;">
                                            PDF
                                        </a>
                                    </li>
                                    <li>
                                        <a href="javascript:;">
                                            Excel
                                        </a>
                                    </li>
                                </ul>
                            </div>
                        </div>*@
                    </div>
                </div>
                <table class="table table-striped table-bordered table-hover" id="tablaUsuarios">
                    <thead>
                        <tr>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Nombre)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Apellido)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Email)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.NombreUsuario)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Activo)
                            </th>
                            <th>Acciones</th>
                        </tr>
                    </thead>
                    <tbody>
                        @For Each item In Model
                            Dim currentItem = item
                            
                        @<tr class="odd gradeX">
                            <td>
                                @Html.DisplayFor(Function(modelItem) currentItem.Nombre)
                            </td>
                            <td>
                                @Html.DisplayFor(Function(modelItem) currentItem.Apellido)
                            </td>
                            <td>
                                @Html.DisplayFor(Function(modelItem) currentItem.Email)
                            </td>
                            <td>
                                @Html.DisplayFor(Function(modelItem) currentItem.NombreUsuario)
                            </td>
                            <td>
                                @Html.DisplayFor(Function(modelItem) currentItem.Activo)
                            </td>
                            <td class="text-center">
                                @Code
                                    If User.IsInRole("ConsultarUsuario") Then
                                        @Html.ActionLink("Ver", "Detalle", New With {.id = currentItem.Id}, New With {.class = "btn default btn-xs"})
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
