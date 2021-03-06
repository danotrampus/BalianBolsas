﻿@ModelType IEnumerable(Of EE.Impresion)

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
            <a href="#">Impresiones</a>
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
            var table = $('#tablaImpresiones');

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
                    <i class="fa fa-print"></i>Listado de Impresiones
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
                                If User.IsInRole("CrearImpresion") Then
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
                <table class="table table-striped table-bordered table-hover" id="tablaImpresiones">
                    <thead>
                        <tr>
                            <th>Tratado</th>
                            <th>Cantidad Colores</th>
                            <th>Precio x1000 Metros</th>
                            <th>Acciones</th>
                        </tr>
                    </thead>
                    <tbody>
                        @For Each item In Model
                            Dim currentItem = item

                            @<tr class="odd gradeX">
                                <td>
                                    @Html.DisplayFor(Function(modelItem) currentItem.Tratado)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) currentItem.CantidadColores)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) currentItem.Precio)
                                </td>
                                <td class="text-center">
                                    @Code
                                    If User.IsInRole("ConsultarImpresion") Then
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
