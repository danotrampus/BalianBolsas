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
            <a href="#">Ubicación</a>
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
            map.addMarker({
                lat: -34.638054,
                lng: -58.412185,
                title: 'Balian Bolsas',
                infoWindow: {
                    content: '<span style="color:#000">Balian Bolsas</span>'
                }
            });
        });
    </script>
End Section

<!-- BEGIN MARKERS PORTLET-->
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
<!-- END MARKERS PORTLET-->
