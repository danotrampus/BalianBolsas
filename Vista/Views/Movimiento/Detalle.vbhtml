@ModelType EE.Movimiento

@Code
    Layout = Nothing
End Code

<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Sample Invoice</title>
    @Styles.Render("~/Content/global/plugins/font-awesome/css")
    @Styles.Render("~/Content/global/plugins/simple-line-icons")
    @Styles.Render("~/Content/global/plugins/bootstrap/css")
    @Styles.Render("~/Content/global/css")
</head>

<body>
    @Code
        If Model.GetType() = GetType(EE.Pago) Then
            @<div class="container">
                <div class="row">
                    <div class="col-xs-6">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4>@Model.ObtenerTipo #@Model.Numero</h4>
                            </div>
                            <div class="panel-body">
                                <p>
                                    Importe: $@Model.Importe.ToString("0.00") <br>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        Else
            @<div class="container">
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
                    <div class="col-xs-6">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4>De: <a href="#">Balian Bolsas</a></h4>
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
                    <div class="col-xs-6 text-right">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4>A: <a href="#">Cliente</a></h4>
                            </div>
                            <div class="panel-body">
                                <p>
                                    @If Model.GetType() = GetType(EE.Factura) Then
                                    @DirectCast(Model, EE.Factura).Cuit @<br />
                                    @DirectCast(Model, EE.Factura).Direccion.Descripcion
                                    End If
                                    @If Model.GetType() = GetType(EE.NotaCredito) Then
                                    @DirectCast(Model, EE.NotaCredito).Direccion.Descripcion
                                    End If
                                    @If Model.GetType() = GetType(EE.NotaDebito) Then
                                    @DirectCast(Model, EE.NotaDebito).Direccion.Descripcion
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
                                    $@item.Producto.CalcularPrecioConIva().ToString("0.000")
                                </td>
                                <td>
                                    $@item.Total.ToString("0.00")
                                </td>
                            </tr>
                                    Next
                                End If
                        End Code
                    </tbody>
                </table>
                <div class="row">
                    <div class="col-xs-8">
                        <p>
                            <strong>Observaciones:</strong>
                            <br>
                            @Model.Observacion
                        </p>
                    </div>
                    <div class="col-xs-2 text-right">
                        <p>
                            <strong>
                                Sub Total : <br>
                                IVA : <br>
                                Total : <br>
                            </strong>
                        </p>
                    </div>
                    <div class="col-xs-2 text-right">
                        <strong>
                            $@Model.Subtotal.ToString("0.00") <br>
                            $@Model.Iva.ToString("0.00") <br>
                            $@Model.Importe.ToString("0.00") <br>
                        </strong>
                    </div>
                </div>
            </div>
        End If
    End Code
    
</body>
</html>