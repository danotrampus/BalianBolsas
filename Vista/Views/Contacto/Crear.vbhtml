@ModelType EE.Contacto

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
            <a href="#">Contacto</a>
        </li>
    </ul>
End Section

@Section javascripts
    <script src="http://maps.google.com/maps/api/js?sensor=false" type="text/javascript"></script>
    @Scripts.Render("~/Content/gmaps/js")
End Section

@Section javascript_codigo
    <script type="text/javascript">
        $(document).ready(function () {
            var map = new GMaps({
                div: '#gmap_marker',
                lat: -34.638054,
                lng: -58.412185
            });
            var marker = map.addMarker({
                lat: -34.638054,
                lng: -58.412185,
                title: 'Balian Bolsas',
                infoWindow: {
                    content: '<b>Balian Bolsas.</b> Caseros 3335, CABA<br>Buenos Aires, CP 1260'
                }
            });
            marker.infoWindow.open(map, marker);
        });
    </script>
End Section

<div class="portlet solid">
    <div class="portlet-title">
        <div class="caption">
            <i class="fa fa-map-marker"></i>Ubicación
        </div>
        <div class="tools">
            <a href="javascript:;" class="collapse">
            </a>
            <a href="javascript:;" class="remove">
            </a>
        </div>
    </div>
    <div class="portlet-body">
        <div id="gmap_marker" class="gmaps">
        </div>
    </div>
</div>

<div class="row margin-bottom-20">
    <div class="col-md-6">
        <div class="portlet solid">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-info"></i>Información de Contacto
                </div>
                <div class="tools">
                    <a href="javascript:;" class="collapse">
                    </a>
                    <a href="javascript:;" class="remove">
                    </a>
                </div>
            </div>
            <div class="portlet-body">
                <div class="well">
                    <h4>Dirección</h4>
                    <address>
                        <strong>Balian Bolsas.</strong><br>
                        Caseros 3335, CABA<br>
                        Buenos Aires, CP 1260<br>
                        Telefono: (011) 4911-4108
                    </address>
                    <address>
                        <strong>Email</strong><br>
                        <a href="mailto:#">
                            info@balianbolsas.com.ar
                        </a>
                    </address>
                    <ul class="social-icons margin-bottom-10">
                        <li>
                            <a href="javascript:;" data-original-title="facebook" class="facebook">
                            </a>
                        </li>
                        <li>
                            <a href="javascript:;" data-original-title="github" class="github">
                            </a>
                        </li>
                        <li>
                            <a href="javascript:;" data-original-title="Goole Plus" class="googleplus">
                            </a>
                        </li>
                        <li>
                            <a href="javascript:;" data-original-title="linkedin" class="linkedin">
                            </a>
                        </li>
                        <li>
                            <a href="javascript:;" data-original-title="rss" class="rss">
                            </a>
                        </li>
                        <li>
                            <a href="javascript:;" data-original-title="skype" class="skype">
                            </a>
                        </li>
                        <li>
                            <a href="javascript:;" data-original-title="twitter" class="twitter">
                            </a>
                        </li>
                        <li>
                            <a href="javascript:;" data-original-title="youtube" class="youtube">
                            </a>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <div class="col-md-6">
        <div class="portlet solid">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-comment-o"></i>Formulario de Contacto
                </div>
                <div class="tools">
                    <a href="javascript:;" class="collapse">
                    </a>
                    <a href="javascript:;" class="remove">
                    </a>
                </div>
            </div>
            <div class="portlet-body form">
                <!-- BEGIN FORM-->
                @Using Html.BeginForm()
                    @Html.AntiForgeryToken()
                    @Html.ValidationSummary(True)

                    @<div class="form-body">
                        <div class="form-group @IIf(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Asunto))), Nothing, "has-error")">
                            <div class="input-icon">
                                <i class="fa fa-check"></i>
                                @Html.TextBoxFor(Function(model) model.Asunto, New With {.class = "form-control", .placeholder = Html.DisplayNameFor(Function(model) model.Asunto)})
                            </div>
                            @Html.ValidationMessageFor(Function(model) model.Asunto, Nothing, New With {.class = "help-block"})
                        </div>
                        <div class="form-group @IIf(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.NombreApellido))), Nothing, "has-error")">
                            <div class="input-icon">
                                <i class="fa fa-user"></i>
                                @Html.TextBoxFor(Function(model) model.NombreApellido, New With {.class = "form-control", .placeholder = Html.DisplayNameFor(Function(model) model.NombreApellido)})
                            </div>
                            @Html.ValidationMessageFor(Function(model) model.NombreApellido, Nothing, New With {.class = "help-block"})
                        </div>
                        <div class="form-group @IIf(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Email))), Nothing, "has-error")">
                            <div class="input-icon">
                                <i class="fa fa-envelope"></i>
                                @Html.TextBoxFor(Function(model) model.Email, New With {.class = "form-control", .placeholder = Html.DisplayNameFor(Function(model) model.Email)})
                            </div>
                            @Html.ValidationMessageFor(Function(model) model.Email, Nothing, New With {.class = "help-block"})
                        </div>
                        <div class="form-group @IIf(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Mensaje))), Nothing, "has-error")">
                            @Html.TextAreaFor(Function(model) model.Mensaje, New With {.class = "form-control", .placeholder = Html.DisplayNameFor(Function(model) model.Mensaje), .rows = "3=6"})
                            @Html.ValidationMessageFor(Function(model) model.Mensaje, Nothing, New With {.class = "help-block"})
                        </div>
                    </div>
                    @<button type="submit" class="btn green">Enviar</button>
                End Using
                <!-- END FORM-->
            </div>
        </div>
    </div>
</div>
