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

@Section stylesheets
    @Styles.Render("~/Content/star-rating/css")
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
    @Scripts.Render("~/Content/star-rating/js")
End Section

@Section javascript_codigo
    <script type="text/javascript">
        $(document).ready(function () {
            $("#Valoracion").rating();
        });
    </script>
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
                    <li>
                        <a href="#portlet_tab2" data-toggle="tab">
                            Comentarios
                        </a>
                    </li>
                </ul>
            </div>
            <div class="portlet-body">
                <div class="tab-content">
                    <div class="tab-pane active" id="portlet_tab1">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="row">
                                    <div class="col-md-3">
                                        <p>
                                            <img class="img-responsive" src="@Model.Producto.Imagen" />
                                        </p>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <p>
                                            Ancho (cm): @Model.Producto.Ancho<br />
                                            Largo (cm): @Model.Producto.Largo<br />
                                            Espesor (µm): @Model.Producto.Espesor<br />
                                            Soldadura: @Model.Producto.Soldadura<br />
                                            Formato: @Model.Producto.Formato<br />
                                            Manija: @DirectCast(Model.Producto, EE.Bolsa).ObtenerDescripcionManija()<br />
                                            Impresion: @Model.Producto.ObtenerDescripcionImpresion()<br />
                                            Polímero: @Model.Producto.Polimero.Nombre<br />
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        @Using Html.BeginForm()
                        @Html.AntiForgeryToken()
                        @Html.HiddenFor(Function(model) model.Producto.Id)
                        @<input type="hidden" name="ProductoType" value="Bolsa" />
                        @<div class="form-group @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Cantidad))), Nothing, "has-error"))">
                            @Html.LabelFor(Function(model) model.Cantidad, New With {.class = "control-label"})
                            @Html.TextBoxFor(Function(model) model.Cantidad, New With {.class = "form-control input-small"})
                            @Html.ValidationMessageFor(Function(model) model.Cantidad, Nothing, New With {.class = "help-block"})
                        </div>
                        @<button type="submit" class="btn blue">Grabar</button>
                                End Using
                    </div>
                    <div class="tab-pane" id="portlet_tab2">
                        <div class="list-group">
                            @code

                                @For Each item In Model.Producto.ListaComentarios

								    @<a href="javascript:;" class="list-group-item">
								        <h4 class="list-group-item-heading">
                                            @For index = 1 To 5
                                            If index <= item.Valoracion Then
                                                @<i class="fa fa-star star-yellow"></i>
                                            Else
                                                @<i class="fa fa-star star-gray"></i>
                                            End If
                                            Next
                                        </h4>
								        <p class="list-group-item-text">
									         @item.Mensaje
								        </p>
								    </a>
                                Next
                            End Code
                        </div>
                            <div class="row">
                                <div class="col-md-12">
                                    @Code
                                        If User IsNot Nothing Then
                                            If Request.HttpMethod.ToLower() = "post" Then
                                                If Request.RawUrl.Contains("Bolsa") Then
                                                    Html.RenderAction("Comentar", "Bolsa", New With {.productoId = Model.Producto.Id})
                                                End If
                                            Else
                                                Html.RenderAction("Comentar", "Bolsa", New With {.productoId = Model.Producto.Id})
                                            End If
                                        End If
                                    End Code
                                </div>
                            </div>
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
