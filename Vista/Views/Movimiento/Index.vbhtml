@ModelType IEnumerable(Of EE.Movimiento)

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
            <a href="#">Movimientos</a>
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
            var table = $('#tablaMovimientos').DataTable({
                "processing": true,
                "serverSide": true,
                "ajax": {
                    "url": "@Url.Action("ListarAjax")",
                    "type": "POST",
                    "data": function (d) {
                        d.desde = $("#txtDesde").val();
                        d.hasta = $("#txtHasta").val();
                        d.tipo = $("#txtTipo").val();
                    }
                },
                "columns": [
                    { "data": "Fecha" },
                    { "data": "Tipo" },
                    { "data": "Numero" },
                    { "data": "Observacion" },
                    { "data": "Importe" },
                    { "data": "Usuario" },
                    {
                        "data": "Acciones", "searchable": false, "orderable": false, "className": "text-center", "render": function (data, type, row) {
                            var parameters = data.split(" ");
                            return "<a href='/Movimiento/GenerarPdf?tipo=" + parameters[0] + "&numero=" + parameters[2] + "&tipoComprobante=" + parameters[1] + "' class='btn btn-xs default'>Exportar</a>"
                        }
                    }
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
                "bStateSave": true
            });

            table.on('xhr', function () {
                var json = table.ajax.json();
                $("#TotalMovimientos").html("Total: $" + json.total)
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

            $("#txtTipo").select2();

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
                    <i class="fa fa-user"></i>Listado de Movimientos
                </div>
                <div class="tools">
                    <a href="javascript:;" class="collapse">
                    </a>
                    <a href="javascript:;" class="remove">
                    </a>
                </div>
            </div>
            <div class="portlet-body">
                <table class="table table-striped table-bordered table-hover" id="tablaMovimientos">
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
                                <select id="txtTipo" class="form-control form-filter input-sm" multiple="multiple">
                                    <option value="Factura A">Factura A</option>
                                    <option value="Factura B">Factura B</option>
                                    <option value="Pago MasterCard">Pago MasterCard</option>
                                    <option value="Pago Visa">Pago Visa</option>
                                    <option value="Pago American Express">Pago American Express</option>
                                    <option value="Nota de Crédito A">Nota de Crédito A</option>
                                    <option value="Nota de Débito A">Nota de Débito A</option>
                                </select>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr role="row" class="heading">
                            <th>Fecha</th>
                            <th>Tipo</th>
                            <th>Número</th>
                            <th>Observación</th>
                            <th>Importe</th>
                            <th>Usuario</th>
                            <th>Acciones</th>
                        </tr>
                    </thead>
                </table>
                <div class="row">
                    <div class="col-md-12">
                        <div class="pull-right">
                            <h3 id="TotalMovimientos"></h3>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- END EXAMPLE TABLE PORTLET-->
    </div>
</div>
