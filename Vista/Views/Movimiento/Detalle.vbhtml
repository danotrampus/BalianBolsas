@ModelType EE.Movimiento

@Code
    Layout = Nothing
End Code
@*<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
</head>
<body>
    @Model.Fecha
    @Model.ObtenerTipo()
    @Model.Numero
    @Model.Importe
    @For Each dm As EE.DetalleMovimiento In Model.ListaDetalles
        @dm.Cantidad
        @dm.Precio
        @dm.Producto.ObtenerNombre()
    Next
</body>
</html>*@

<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Sample Invoice</title>
    @Styles.Render("~/Content/global/css")
</head>

<body>
    <div class="container">
        <div class="row">
            <div class="col-xs-6">
                @*<h1>
                    <a href="">
                        <img src="logo.png">
                        Logo here
                    </a>
                </h1>*@
            </div>
            <div class="col-xs-6 text-right">
                <h1>@Model.ObtenerTipo</h1>
                <h1><small>#@Model.Numero</small></h1>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-5">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4>From: <a href="#">Balian Bolsas</a></h4>
                    </div>
                    <div class="panel-body">
                        <p>
                            Av. Caseros 3335, Capital Federal <br>
                            Responsable Inscripto <br>
                            XX-XXXXXXXX-X <br>
                        </p>
                    </div>
                </div>
            </div>
            <div class="col-xs-5 col-xs-offset-2 text-right">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4>A : <a href="#">Cliente</a></h4>
                    </div>
                    <div class="panel-body">
                        <p>
                            @If Model.GetType() = GetType(EE.Factura) Then
                                @DirectCast(Model,EE.Factura).Cuit @<br/>
                                @DirectCast(Model, EE.Factura).Direccion.Descripcion
                            End If
                        </p>
                    </div>
                </div>
            </div>
        </div>
        <!-- / end client details section -->
        <table class="table table-striped table-bordered table-hover" id="tablaPedidos">
            <thead>
                <tr>
                    <th><h4>Producto</h4></th>
                    <th><h4>Cantidad</h4></th>
                    <th><h4>Precio Unitario</h4></th>
                    <th><h4>Total</h4></th>
                </tr>
            </thead>
            <tbody>
                @Code
                    If Model IsNot Nothing Then
                        For Each item In Model.ListaDetalles

                    @<tr class="odd gradeX">
                        <td>
                            @item.Producto.ObtenerNombre()
                        </td>
                        <td>
                            @item.Cantidad
                        </td>
                        <td>
                            @item.Producto.CalcularPrecioConIva()
                        </td>
                        <td>
                            @item.Total
                        </td>
                    </tr>
                        Next
                    End If
                End Code
            </tbody>
        </table>
        <div class="row text-right">
            <div class="col-xs-2 col-xs-offset-8">
                <p>
                    <strong>
                        Sub Total : <br>
                        IVA : <br>
                        Total : <br>
                    </strong>
                </p>
            </div>
            <div class="col-xs-2">
                <strong>
                    $@Model.Subtotal.toString("0.00") <br>
                    $@Model.Iva.toString("0.00") <br>
                    $@Model.Importe.ToString("0.00") <br>
                </strong>
            </div>
        </div>
    </div>
</body>
</html>