﻿@ModelType EE.Usuario

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
            <a href="#">Mi Cuenta</a>
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
            var table = $('#tablaMovimientos');
            var table2 = $('#tablaPedidos');
            var settings = {
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
            };
            table.dataTable(settings);
            table2.dataTable(settings);
        });
    </script>
End Section

<div class="row">
    <div class="col-md-12">
        <!-- BEGIN Portlet PORTLET-->
        <div class="portlet box blue">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-user"></i>Detalle de mi cuenta
                </div>
                <ul class="nav nav-tabs">
                    <li class="active">
                        <a href="#portlet_tab1" data-toggle="tab">
                            Información Básica
                        </a>
                    </li>
                    <li>
                        <a href="#portlet_tab2" data-toggle="tab">
                            Cuenta Corriente
                        </a>
                    </li>
                    <li>
                        <a href="#portlet_tab3" data-toggle="tab">
                            Pedidos
                        </a>
                    </li>
                </ul>
            </div>
            <div class="portlet-body">
                <div class="tab-content">
                    <div class="tab-pane active" id="portlet_tab1">
                        <p>
                            @Html.DisplayNameFor(Function(model) model.Nombre): @Html.DisplayFor(Function(model) model.Nombre)<br />
                            @Html.DisplayNameFor(Function(model) model.Apellido): @Html.DisplayFor(Function(model) model.Apellido)<br />
                            @Html.DisplayNameFor(Function(model) model.Email): @Html.DisplayFor(Function(model) model.Email)<br />
                            @Html.DisplayNameFor(Function(model) model.NombreUsuario): @Html.DisplayFor(Function(model) model.NombreUsuario)<br />
                        </p>
                    </div>
                    <div class="tab-pane" id="portlet_tab2">
                        <table class="table table-hover" id="tablaMovimientos">
                            <thead>
                                <tr>
                                    <th>Tipo</th>
                                    <th>Número</th>
                                    <th>Observación</th>
                                    <th>Importe</th>
                                    <th>Acciones</th>
                                </tr>
                            </thead>
                            <tbody>
                                @Code
                                    If Model IsNot Nothing Then
                                    @For Each item In Model.ListaMovimientos
                                        @<tr>
                                            <td>
                                                @item.ObtenerTipo
                                            </td>
                                            <td>
                                                @item.Numero
                                            </td>
                                            <td>
                                                @item.Observacion
                                            </td>
                                            <td>
                                                $@item.ObtenerImporte.ToString("0.00")
                                            </td>
                                             <td class="text-center">
                                                 @Html.ActionLink("Exportar", "GenerarPdf", "Movimiento", New With {.tipo = item.ObtenerSoloTipo().ToString(), .numero = item.Numero.ToString(), .tipoComprobante = item.TipoComprobante.ToString()}, New With {.class = "btn btn-xs default"})
                                             </td>
                                        </tr>
                                        Next
                                    End If
                                End Code
                            </tbody>
                        </table>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="pull-right">
                                    <h3>Total: $@Model.TotalMovimientos</h3>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="tab-pane" id="portlet_tab3">
                        <table class="table table-hover" id="tablaPedidos">
                            <thead>
                                <tr>
                                    <th>N° de orden</th>
                                    <th>Fecha Inicio</th>
                                    <th>Fecha Fin</th>
                                    <th>Importe</th>
                                    <th>Estado</th>
                                    <th>Acciones</th>
                                </tr>
                            </thead>
                            <tbody>
                                @Code
                                    If Model IsNot Nothing Then
                                @For Each item In Model.ListaPedidos
                                    @<tr>
                                        <td>
                                            @Html.DisplayFor(Function(modelItem) item.Id)
                                        </td>
                                        <td>
                                            @item.FechaInicio
                                        </td>
                                        <td>
                                            @IIf(item.FechaFin = Nothing, "", item.FechaFin)
                                        </td>
                                        <td>
                                            $@item.Importe.ToString("0.00")
                                        </td>
                                        <td>
                                            @Html.DisplayFor(Function(modelItem) item.Estado)
                                        </td>
                                        <td class="text-center">
                                            @Code
                                            If User.IsInRole("ConsultarPedido") Then
                                                    @Html.ActionLink("Ver", "Detalle", "Pedido", New With {.id = item.Id}, New With {.class = "btn btn-xs default"})
                                            End If
                                            End Code
                                        </td>
                                    </tr>
                                    Next
                                    End If
                                End Code
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="row">
    <div class="col-md-12">
        @Html.ActionLink("Cambiar Contraseña", "CambiarClave", Nothing, New With {.class = "btn blue"})
    </div>
</div>