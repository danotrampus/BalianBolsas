﻿@Code
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
            <div class="portlet-body">
                <!-- BEGIN FORM-->
                <form action="#">
                    <div class="form-group">
                        <div class="input-icon">
                            <i class="fa fa-check"></i>
                            <input type="text" class="form-control" placeholder="Subject">
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="input-icon">
                            <i class="fa fa-user"></i>
                            <input type="text" class="form-control" placeholder="Name">
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="input-icon">
                            <i class="fa fa-envelope"></i>
                            <input type="password" class="form-control" placeholder="Email">
                        </div>
                    </div>
                    <div class="form-group">
                        <textarea class="form-control" rows="3=6" placeholder="Feedback"></textarea>
                    </div>
                    <button type="submit" class="btn green">Submit</button>
                </form>
                <!-- END FORM-->
            </div>
        </div>
    </div>
</div>
