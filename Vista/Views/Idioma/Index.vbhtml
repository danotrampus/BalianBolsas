@ModelType IEnumerable(Of EE.Idioma)

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
            <a href="#">Idiomas</a>
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
            var table = $('#tablaIdiomas');

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
                "bStateSave": true,
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
                    <i class="fa fa-globe"></i>Listado de Idiomas
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
                                If User.IsInRole("CrearIdioma") Then
                            @<div class="btn-group">
                                <a href="@Url.Action("Crear")" class="btn green">
                                    Nuevo <i class="fa fa-plus"></i>
                                </a>
                            </div>
                                End If
                            End Code
                        </div>
                    </div>
                </div>
                <table class="table table-striped table-bordered table-hover" id="tablaIdiomas">
                    <thead>
                        <tr>
                            <th>
                                Nombre
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
                                <td class="text-center">
                                    @Code
                                    If User.IsInRole("EliminarIdioma") Then
                                        @<a class="btn red btn-xs" data-toggle="modal" href="#delete-confirmation-@currentItem.Id">Eliminar</a>
                                        @Using Html.BeginForm("Eliminar", "Idioma", New With {currentItem.Id}, FormMethod.Get)
                                            @Html.AntiForgeryToken()
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
