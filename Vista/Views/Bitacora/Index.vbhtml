@ModelType IEnumerable(Of EE.Bitacora)

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
            <a href="#">Bitacora</a>
        </li>
    </ul>
End Section

@Section stylesheets
    @Styles.Render("~/Content/select2/css")
    @Styles.Render("~/Content/datepicker/css")
    @Styles.Render("~/Content/datatables/css")
End Section

@Section javascripts
    @Scripts.Render("~/Content/select2/js")
    @Scripts.Render("~/Content/datepicker/js")
    @Scripts.Render("~/Content/datatables/js")
End Section

@Section javascript_codigo
    <script type="text/javascript">
        $(document).ready(function () {
            var table = $('#tablaBitacora').DataTable({
                "processing": true,
                "serverSide": true,
                "ajax": {
                    "url": "@Url.Action("ListarAjax")",
                    "type": "POST",
                    "data": function ( d ) {
                        d.desde = $("#txtDesde").val();
                        d.hasta = $("#txtHasta").val();
                        d.tipoEvento = $("#cmbTipoEvento").val();
                        d.descripcion = $("#txtDescripcion").val();
                        d.usuario = $("#txtUsuario").val();
                    }
                },
                "columns": [
                    { "data": "FechaHora" },
                    { "data": "Tipo" },
                    { "data": "Descripcion" },
                    { "data": "Usuario" }
                ],
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
                "bStateSave": true, // save datatable state(pagination, sort, etc) in cookie.
                "dom": "<'row'<'col-md-6 col-sm-12'l><'col-md-6 col-sm-12'f>r>tr<'row'<'col-md-5 col-sm-12'i><'col-md-7 col-sm-12'p>>",
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
                rtl: Metronic.isRTL(),
                autoclose: true,
                language: "es"
            });

            $("#cmbTipoEvento").select2();

            $(".form-filter").change(function () {
                table.draw();
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
                    <i class="fa fa-book"></i>Listado de Eventos
                </div>
                <div class="tools">
                    <a href="javascript:;" class="collapse">
                    </a>
                    <a href="javascript:;" class="remove">
                    </a>
                </div>
            </div>
            <div class="portlet-body">
                <table class="table table-striped table-bordered table-hover" id="tablaBitacora">
                    <thead>
                        <tr role="row" class="filter">
                            <td>
                                <div class="input-group date date-picker margin-bottom-5" data-date-format="dd/mm/yyyy">
                                    <input type="text" class="form-control form-filter input-sm" readonly id="txtDesde" placeholder="Desde">
                                    <span class="input-group-btn">
                                        <button class="btn btn-sm default" type="button"><i class="fa fa-calendar"></i></button>
                                    </span>
                                </div>
                                <div class="input-group date date-picker" data-date-format="dd/mm/yyyy">
                                    <input type="text" class="form-control form-filter input-sm" readonly id="txtHasta" placeholder="Hasta">
                                    <span class="input-group-btn">
                                        <button class="btn btn-sm default" type="button"><i class="fa fa-calendar"></i></button>
                                    </span>
                                </div>
                            </td>
                            <td>
                                <select id="cmbTipoEvento" class="form-control form-filter input-sm">
                                    <option value=""></option>
                                    <option value="0">Advertencia</option>
                                    <option value="1">Fallo</option>
                                    <option value="2">Información</option>
                                </select>
                            </td>
                            <td>
                                <input type="text" class="form-control form-filter input-sm" id="txtDescripcion">
                            </td>
                            <td>
                                <input type="text" class="form-control form-filter input-sm" id="txtUsuario">
                            </td>
                        </tr>
                        <tr role="row" class="heading">
                            <th width="20%">
                                @Html.DisplayNameFor(Function(model) model.FechaHora)
                            </th>
                            <th width="20%">
                                @Html.DisplayNameFor(Function(model) model.Tipo)
                            </th>
                            <th width="50%">
                                @Html.DisplayNameFor(Function(model) model.Descripcion)
                            </th>
                            <th width="10%">
                                @Html.DisplayNameFor(Function(model) model.Usuario.NombreUsuario)
                            </th>
                        </tr>
                     </thead>
                    <tbody>
                        @*@For Each item In Model
                            Dim currentItem = item

                            @<tr class="odd gradeX">
                                <td>
                                    @Html.DisplayFor(Function(modelItem) currentItem.FechaHora)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) currentItem.Tipo)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) currentItem.Descripcion)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) currentItem.Usuario.NombreUsuario)
                                </td>
                            </tr>
                        Next*@
                    </tbody>
                </table>
            </div>
        </div>
        <!-- END EXAMPLE TABLE PORTLET-->
    </div>
</div>