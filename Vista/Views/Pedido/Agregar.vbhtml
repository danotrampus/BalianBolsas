@ModelType EE.DetallePedido

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
            <a href="@Url.Action("VerCarro", "Pedido")">Pedido</a>
            <i class="fa fa-angle-right"></i>
        </li>
        <li>
            <a href="#">Agregar</a>
        </li>
    </ul>
End Section

<div class="row">
    <div class="col-md-12">
        <!-- BEGIN Portlet PORTLET-->
        <div class="portlet box blue">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-calendar-o"></i>Detalle de bolsa
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
                            <img class="img-responsive" src="@Model.Producto.Imagen" /><br />
                            Ancho (cm): @Model.Producto.Ancho<br />
                            Largo (cm): @Model.Producto.Largo<br />
                            Espesor (µm): @Model.Producto.Espesor<br />
                            Soldadura: @Model.Producto.Soldadura<br />
                            Formato: @Model.Producto.Formato<br />
                            Manija: @DirectCast(Model.Producto, EE.Bolsa).ObtenerDescripcionManija()<br />
                            Impresion: @Model.Producto.ObtenerDescripcionImpresion()<br />
                            Polímero: @Model.Producto.Polimero.Nombre<br />
                        </p>
                        @Using Html.BeginForm()
                            @Html.AntiForgeryToken()
                            @Html.HiddenFor(Function(model) model.Producto.Id)
                            @<input type="hidden" name="ProductoType" value="Bolsa" />
                            @<div class="form-group @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Cantidad))), Nothing, "has-error"))">
                                @Html.LabelFor(Function(model) model.Cantidad, New With {.class = "control-label"})
                                @Html.TextBoxFor(Function(model) model.Cantidad, New With {.class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.Cantidad, Nothing, New With {.class = "help-block"})
                            </div>
                            @<button type="submit" class="btn blue">Grabar</button>
                        End Using
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="row">
    <div class="col-md-12">
        @Code
            @Html.ActionLink("Volver", "Index", "Home", Nothing, New With {.class = "btn default"})
        End Code
    </div>
</div>
