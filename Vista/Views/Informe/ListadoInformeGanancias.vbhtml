@ModelType  EE.InformeTiempoRespuesta

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
            <a href="#">Informes</a>
        </li>
    </ul>
End Section

@Section stylesheets
    @Styles.Render("~/Content/datepicker/css")
    <link href="~/Content/global/plugins/morris/morris.css" rel="stylesheet" type="text/css" />
End Section

@Section javascripts
    @Scripts.Render("~/Content/datepicker/js")
    <script src="~/Content/global/plugins/morris/raphael-min.js"></script>
    <script src="~/Content/global/plugins/morris/morris.js"></script>
End Section

@Section javascript_codigo
    <script type="text/javascript">
        $(document).ready(function () {
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

            //Date Pickers
            $('.date-picker').datepicker({
                rtl: Metronic.isRTL(),
                autoclose: true,
                language: "es"
            });

            $("#btnGenerar").click(function () {
                var desde = $("#desde").val(),
                    hasta = $("#hasta").val();
                if (desde != "" && typeof desde != "undefined" && hasta != "" && typeof hasta != "undefined") {
                    $.ajax({
                        data: { desde: $("#desde").val(), hasta: $("#hasta").val() },
                        url: '@Url.Action("ObtenerGananciasAjax")',
                        type: 'post',
                        success: function (data) {
                            $("#graficoGanancias").html("");
                            var total = 0;
                            for (var index in data) {
                                var obj = data[index];
                                total += parseFloat(obj.y.replace(",", "."));
                            }
                            $("#totalGanancias").html("Total General: "+total.toFixed(2));
                            Morris.Bar({
                                element: 'graficoGanancias',
                                data: data,
                                // The name of the data record attribute that contains x-values.
                                xkey: 'x',
                                // A list of names of data record attributes that contain y-values.
                                ykeys: ['y'],
                                // Labels for the ykeys -- will be displayed when you hover over the
                                // chart.
                                labels: ['Importe']
                            });
                        }
                    });
                }
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
                    <i class="fa fa-user"></i>Informe de Ganancias
                </div>
                <div class="tools">
                    <a href="javascript:;" class="collapse">
                    </a>
                    <a href="javascript:;" class="remove">
                    </a>
                </div>
            </div>
            <div class="portlet-body">
                <div class="row">
                    <div class="col-lg-3">
                        <div class="form-group">
                            <div class="input-group date date-picker margin-bottom-5" data-date-format="dd/mm/yyyy">
                                <input type="text" class="form-control form-filter input-sm datepicker-range" readonly id="desde" placeholder="Desde">
                                <span class="input-group-btn">
                                    <button class="btn btn-sm default" type="button"><i class="fa fa-calendar"></i></button>
                                </span>
                            </div>
                            <div class="input-group date date-picker" data-date-format="dd/mm/yyyy">
                                <input type="text" class="form-control form-filter input-sm datepicker-range" readonly id="hasta" placeholder="Hasta">
                                <span class="input-group-btn">
                                    <button class="btn btn-sm default" type="button"><i class="fa fa-calendar"></i></button>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="form-group">
                            <input type="button" class="btn blue" value="Generar Gráfico" style="margin-top:26px;" id="btnGenerar" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div id="graficoGanancias"></div>
                    </div>
                    <div class="col-md-12">
                        <h3 id="totalGanancias"></h3>
                    </div>
                </div>
            </div>
        </div>
        <!-- END EXAMPLE TABLE PORTLET-->
    </div>
</div>

