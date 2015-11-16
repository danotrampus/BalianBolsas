@ModelType IEnumerable(Of EE.Bolsa)

@Code
    Layout = "~/Views/Shared/_BackEnd.vbhtml"
End Code

@Section breadcrumbs
    <ul class="page-breadcrumb">
        <li>
            <i class="fa fa-home"></i>
            <a href="@Url.Action("Index")">Home</a>
        </li>
    </ul>
End Section

<div class="row">
    <div class="col col-lg-12">
        <div class="portlet box grey-cascade">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-calendar-o"></i>Listado de Productos
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
                            <form method="post" action="@Url.Action("Comparar", "Bolsa")" id="formComparar">
                                <input type="hidden" value="" id="productosId" name="productosId" />
                                <input type="submit" value="Comparar" class="btn default">
                            </form>
                        </div>
                    </div>
                    <div class="row margin-top-20">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Polimeros:</label>
                                @Html.DropDownList("PolimeroId", New SelectList(ViewBag.Polimeros, "Id", "Nombre"), "", New With {.class = "form-control filters"})
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Impresiones:</label>
                                @Html.DropDownList("ImpresionId", New SelectList(ViewBag.Impresiones, "Id", "Nombre"), "", New With {.class = "form-control filters"})
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Manijas:</label>
                                @Html.DropDownList("ManijaId", New SelectList(ViewBag.Manijas, "Id", "Nombre"), "", New With {.class = "form-control filters"})
                            </div>
                        </div>
                    </div>
                </div>
                <table class="table table-striped table-bordered table-hover" id="tablaBolsas">
                    <thead>
                        <tr>
                            <th>Acciones</th>
                            <th>Selección</th>
                            <th>Valoración</th>
                            <th>Imagen</th>
                            <th>Medida</th>
                            <th>Polímero</th>
                            <th>Impresión</th>
                            <th>Soldadura</th>
                            <th>Formato</th>
                            <th>Manija</th>
                            <th>Precio Unitario</th>
                        </tr>
                    </thead>
                </table>
            </div>
        </div>
    </div>
    <div class="col col-lg-3">
        @Code
            Html.RenderAction("Responder", "Encuesta", New With {.tipo = "Encuesta"})
        End Code
    </div>
</div>

@Section stylesheets
    @Styles.Render("~/Content/select2/css")
    @Styles.Render("~/Content/datatables/css")
    <style>
        .star-yellow {
            color: yellow;
        }

        .star-gray {
            color: gray;
        }
    </style>
End Section

@Section javascripts
    @Scripts.Render("~/Content/select2/js")
    @Scripts.Render("~/Content/datatables/js")
End Section

@Section javascript_codigo
<script type="text/javascript">
    $(document).ready(function () {
        $("#PolimeroId").select2({
            placeholder: "Seleccione...",
            allowClear: true
        });
        $("#ImpresionId").select2({
            placeholder: "Seleccione...",
            allowClear: true
        });
        $("#ManijaId").select2({
            placeholder: "Seleccione...",
            allowClear: true
        });

        var table = $('#tablaBolsas').DataTable({
            "processing": true,
            "serverSide": true,
            "ajax": {
                "url": "@Url.Action("ListarAjax", "Bolsa")",
                "type": "POST",
                "data": function ( d ) {
                    d.PolimeroId = $("#PolimeroId").val();
                    d.ImpresionId = $("#ImpresionId").val();
                    d.ManijaId = $("#ManijaId").val();
                }
            },
            "columns": [
                { "data": "Acciones", "searchable": false, "orderable": false, "className": "text-center", "render": function ( data, type, row ) {
                        return "<a class='btn default btn-xs' href='/Pedido/Agregar/"+data+"'>Agregar...</a>";
                    }
                },
                { "data": "Seleccion", "searchable": false, "orderable": false, "className": "text-center", "render": function (data, type, row) {
                        return "<input type='checkbox' class='comparar' value='"+data+"' />";
                    }
                },
                { "data": "Valoracion", "searchable": false, "orderable": false, "className": "text-center", "render": function (data, type, row) {
                        var dataInt = parseInt(data);
                        var output = "";
                        for (var i = 1; i <= 5; i++) {
                            if(i <= dataInt){
                                output = output + "<i class='fa fa-star star-yellow'></i>";
                            }else{
                                output = output + "<i class='fa fa-star star-gray'></i>";
                            }
                        }
                        return output;
                    }                    
                },
                { "data": "Imagen", "searchable": false, "orderable": false, "className": "text-center", "render": function (data, type, row) {
                        return "<img src='"+data+"' class='img-responsive' />";
                    }
                },
                { "data": "Medida" },
                { "data": "Polimero" },
                { "data": "Impresion" },
                { "data": "Soldadura" },
                { "data": "Formato" },
                { "data": "Manija" },
                { "data": "PrecioUnitario" }
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
            "bStateSave": true,
            "order": [[4,"asc"]]
        });

        $('#tablaBolsas').on('draw.dt', function () {
            Metronic.init();
        });

        $(".filters").change(function () {
            table.draw();
        });

        $("#formComparar").submit(function (e) {
            var selectedIds = [];

            $(":checked").each(function () {
                selectedIds.push($(this).val());
            });

            if (selectedIds.length > 0) {
                $("#productosId").val(selectedIds);
                return true;
            } else {
                e.preventDefault();
                return false;
            }
        });
    });
</script>
End Section

