﻿@ModelType IEnumerable(Of EE.Novedad)

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
            <a href="#">Novedades</a>
        </li>
    </ul>
End Section

@Section stylesheets
    @Styles.Render("~/Content/select2/css")
End Section

@Section javascripts
    @Scripts.Render("~/Content/select2/js")
End Section

@section javascript_codigo
    <script type="text/javascript">
        $(document).ready(function () {
            $("#ListaCategoriasSeleccionadas").select2();
        });
    </script>
End Section

<div class="row">
    <div class="col col-lg-9">
        <div class="portlet box green">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-rss"></i>Listado de Novedades
                </div>
                <div class="tools">
                    <a href="javascript:;" class="collapse">
                    </a>
                    <a href="javascript:;" class="remove">
                    </a>
                </div>
            </div>
            <div class="portlet-body">
                <div class="panel-group accordion" id="accordion1">
                    @For Each item In Model
                        Dim currentItem = item
                        @<div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion_@item.Id" href="#collapse_@item.Id">
                                        @item.Titulo
                                    </a>
                                </h4>
                            </div>
                            <div id="collapse_@item.Id" class="panel-collapse collapse">
                                <div class="panel-body">
                                    @Html.Raw(item.Contenido)
                                </div>
                            </div>
                        </div>
                    Next
                </div>
            </div>
        </div>
    </div>
    <div class="col col-lg-3">
        @Code
            Html.RenderAction("Suscribirse", "Novedad")
        End Code
    </div>
</div>