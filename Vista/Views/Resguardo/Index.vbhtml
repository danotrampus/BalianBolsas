@ModelType IEnumerable(Of EE.Resguardo)

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
            <a href="#">Resguardo</a>
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
            var table = $('#tablaResguardos');

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

                // Uncomment below line("dom" parameter) to fix the dropdown overflow issue in the datatable cells. The default datatable layout
                // setup uses scrollable div(table-scrollable) with overflow:auto to enable vertical scroll(see: assets/global/plugins/datatables/plugins/bootstrap/dataTables.bootstrap.js).
                // So when dropdowns used the scrollable div should be removed.
                //"dom": "<'row'<'col-md-6 col-sm-12'l><'col-md-6 col-sm-12'f>r>t<'row'<'col-md-5 col-sm-12'i><'col-md-7 col-sm-12'p>>",

                "bStateSave": true, // save datatable state(pagination, sort, etc) in cookie.
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
                    <i class="fa fa-database"></i>Listado de Resguardos
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
                                If User.IsInRole("CrearResguardo") Then
                                    @<div class="btn-group">
                                         <a class="btn green" data-toggle="modal" href="#create-confirmation">
                                             Nuevo <i class="fa fa-plus"></i>
                                         </a>
                                    </div>
                                End If
                            End Code
                        </div>
                    </div>
                </div>
                <table class="table table-striped table-bordered table-hover" id="tablaResguardos">
                    <thead>
                        <tr>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.FechaHora)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Tipo)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.RutaNombre)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Usuario)
                            </th>
                            <th>Acciones</th>
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
                                     @Html.DisplayFor(Function(modelItem) currentItem.Tipo)
                                 </td>
                                 <td>
                                     @Html.DisplayFor(Function(modelItem) currentItem.RutaNombre)
                                 </td>
                                 <td>
                                     @Html.DisplayFor(Function(modelItem) currentItem.Usuario.NombreUsuario)
                                 </td>
                                <td class="text-center">
                                    @Code
                                    If User.IsInRole("RestaurarResguardo") And currentItem.Tipo <> "Restauración" Then
                                        @<a class="btn default btn-xs" data-toggle="modal" href="#restore-confirmation-@currentItem.Id">Restaurar</a>
                                        @Using Html.BeginForm("Restaurar", "Resguardo")
                                            @Html.AntiForgeryToken()
                                            @Html.Hidden("id", currentItem.Id)
                                            @Html.Hidden("rutaNombre", currentItem.RutaNombre)
                                            @<div class="modal fade" id="restore-confirmation-@currentItem.Id" tabindex="-1" role="basic" aria-hidden="true">
                                                <div class="modal-dialog">
                                                    <div class="modal-content">
                                                        <div class="modal-header">
                                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                                                            <h4 class="modal-title">Confirma que desea restaurar el resguardo?</h4>
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
                                    End If
                                    If User.IsInRole("EliminarResguardo") And currentItem.Tipo <> "Restauración" Then
                                        @<a class="btn red btn-xs" data-toggle="modal" href="#delete-confirmation-@currentItem.Id">Eliminar</a>
                                        @Using Html.BeginForm("Eliminar", "Resguardo")
                                        @Html.AntiForgeryToken()
                                            @Html.Hidden("id", currentItem.Id)
                                            @Html.Hidden("rutaNombre", currentItem.RutaNombre)
                                            @<div class="modal fade" id="delete-confirmation-@currentItem.Id" tabindex="-1" role="basic" aria-hidden="true">
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

@Using Html.BeginForm("Crear", "Resguardo")
    @Html.AntiForgeryToken()
    @<div class="modal fade" id="create-confirmation" tabindex="-1" role="basic" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h4 class="modal-title">Confirma que desea crear un resguardo?</h4>
                </div>
                <div class="modal-body">
                    Éste realizará un resguardo completo de toda la base de datos.
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