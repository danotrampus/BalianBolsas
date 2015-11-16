@ModelType EE.Pedido

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
            <a href="@Url.Action("Index", "Pedido")">Pedidos</a>
            <i class="fa fa-angle-right"></i>
        </li>
        <li>
            <a href="#">Detalle</a>
        </li>
    </ul>
End Section

<div class="row">
    <div class="col-md-12">
        <!-- BEGIN Portlet PORTLET-->
        <div class="portlet box blue">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-rss"></i>Detalle de Pedido
                </div>
                <ul class="nav nav-tabs">
                    <li class="active">
                        <a href="#portlet_tab1" data-toggle="tab">
                            Información Básica
                        </a>
                    </li>
                </ul>
            </div>
            <div class="portlet-body">
                <div class="tab-content">
                    <div class="tab-pane active" id="portlet_tab1">
                        <p>
                            Número de orden: @Model.Id<br />
                            @Html.DisplayNameFor(Function(model) model.FechaInicio): @Html.DisplayFor(Function(model) model.FechaInicio)<br />
                            @Html.DisplayNameFor(Function(model) model.FechaFin): @IIf(Model.FechaInicio = Nothing, "", Model.FechaInicio)<br />
                            @Html.DisplayNameFor(Function(model) model.Importe): @Html.DisplayFor(Function(model) model.Importe)<br />
                            @Html.DisplayNameFor(Function(model) model.Estado): @Html.DisplayFor(Function(model) model.Estado)<br />
                            @Html.DisplayNameFor(Function(model) model.Direccion.Descripcion): @Html.DisplayFor(Function(model) model.Direccion.Descripcion)<br />
                            @Html.DisplayNameFor(Function(model) model.Usuario.Nombre): @Html.DisplayFor(Function(model) model.Usuario.Nombre)<br />
                            @Html.DisplayNameFor(Function(model) model.Usuario.Apellido): @Html.DisplayFor(Function(model) model.Usuario.Apellido)<br />
                            @Html.DisplayNameFor(Function(model) model.Usuario.NombreUsuario): @Html.DisplayFor(Function(model) model.Usuario.NombreUsuario)<br />
                            @Html.DisplayNameFor(Function(model) model.Usuario.Telefono): @Html.DisplayFor(Function(model) model.Usuario.Telefono)
                        </p>
                        <table class="table table-hover">
                            <thead>
                                <tr>
                                    <th>Cantidad</th>
                                    <th>Precio</th>
                                    <th>Producto</th>
                                    <th>Total</th>
                                </tr>
                            </thead>
                            <tbody>
                                @For Each item In Model.ListaDetalles
                                    @<tr>
                                        <td>
                                            @Html.DisplayFor(Function(modelItem) item.Cantidad)
                                        </td>
                                        <td>
                                            $@item.Precio.ToString("0.00")
                                        </td>
                                        <td>
                                            @Html.DisplayFor(Function(modelItem) item.Producto.ObtenerNombre())
                                        </td>
                                        <td>
                                            $@item.Total.ToString("0.00")
                                        </td>
                                    </tr>
                                Next
                            </tbody>
                        </table>
                        <h3>Total: $@Model.Importe.ToString("0.00")</h3>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="row">
    <div class="col-md-12">
        @Code
            If User.IsInRole("ListarPolimeros") Then
        @Html.ActionLink("Volver", "Index", Nothing, New With {.class = "btn default"})
            End If
            If User.IsInRole("EditarPolimero") Then
        @Html.ActionLink("Editar", "Editar", New With {.id = Model.Id}, New With {.class = "btn blue"})
            End If
            If User.IsInRole("EliminarPolimero") Then
        @<a class="btn red" data-toggle="modal" href="#delete-confirmation">Eliminar</a>
            End If
        End Code
    </div>
</div>

@Using Html.BeginForm("Eliminar", "Polimero", New With {.id = Model.Id}, FormMethod.Get)
    @Html.AntiForgeryToken()
    @<div class="modal fade" id="delete-confirmation" tabindex="-1" aria-hidden="true">
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