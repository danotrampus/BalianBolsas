@ModelType IEnumerable(Of EE.Bolsa)

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
            <a href="#">Bolsas</a>
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
            var table = $('#tablaBolsas');

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
        @code
            If TempData.ContainsKey("Info") Then
            @<div class="alert alert-success" role="alert">
                <button class="close" data-dismiss="alert"></button>
                <strong>Éxito: </strong>@TempData("Info")
            </div>
            End If
        End Code
        <!-- BEGIN EXAMPLE TABLE PORTLET-->
        <div class="portlet box grey-cascade">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-calendar-o"></i>Listado de Bolsas
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
                                If User.IsInRole("CrearBolsa") Then
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
                <table class="table table-striped table-bordered table-hover" id="tablaBolsas">
                    <thead>
                        <tr>
                            <th>Imagen</th>
                            <th>Medidas</th>
                            <th>Polímero</th>
                            <th>Impresión</th>
                            <th>Soldadura</th>
                            <th>Formato</th>
                            <th>Manija</th>
                            <th>Costo Unitario</th>
                            <th>Precio Unitario</th>
                            <th>Acciones</th>
                        </tr>
                    </thead>
                    <tbody>
                        @For Each item In Model
                            Dim currentItem = item

                            @<tr class="odd gradeX">
                                 <td>
                                     <img src="@item.Imagen" class="img-responsive" />
                                 </td>
                                <td>
                                    @item.ObtenerDescripcionMedidas()
                                </td>
                                 <td>
                                     @item.Polimero.Nombre
                                 </td>
                                 <td>
                                     @item.ObtenerDescripcionImpresion()
                                 </td>
                                 <td>
                                     @item.Soldadura
                                 </td>
                                 <td>
                                     @item.Formato
                                 </td>
                                 <td>
                                     @item.ObtenerDescripcionManija()
                                 </td>
                                <td>
                                    @item.CalcularCosto()
                                </td>
                                 <td>
                                     @item.CalcularPrecio()
                                 </td>
                                <td class="text-center">
                                    @Code
                                    If User.IsInRole("ConsultarBolsa") Then
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
