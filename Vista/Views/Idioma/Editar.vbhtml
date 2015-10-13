@ModelType IdiomaEditarViewModel

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
            <a href="#">Idiomas</a>
            <i class="fa fa-angle-right"></i>
        </li>
        <li>
            <a href="#">Editar</a>
        </li>
    </ul>
End Section

@Section stylesheets
    @Styles.Render("~/Content/multi-select/css")
End Section

@Section javascripts
    @Scripts.Render("~/Content/multi-select/js")
End Section

@Section javascript_codigo
    <script type="text/javascript">
        $(document).ready(function () {
            $('#IdiomasId').multiSelect();
        });
    </script>
End Section

<div class="row">
    <div class="col-md-12">
        <!-- BEGIN SAMPLE FORM PORTLET-->
        <div class="portlet box blue">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-globe"></i> Editar Idiomas
                </div>
                <div class="tools">
                    <a href="" class="collapse">
                    </a>
                    <a href="#portlet-config" data-toggle="modal" class="config">
                    </a>
                    <a href="" class="reload">
                    </a>
                    <a href="" class="remove">
                    </a>
                </div>
            </div>
            <div class="portlet-body form">
                @Using Html.BeginForm("Editar", "Idioma", Nothing, FormMethod.Post, New With {.class = "form-horizontal"})
                    @Html.AntiForgeryToken()
                    @Html.ValidationSummary(True)
                    
                    @<div class="form-body">
                         <div class="form-group">
                             <label class="control-label col-md-2">Idiomas Inactivos</label>
                             <div class="col-md-4">
                                 @Html.ListBoxFor(Function(model) model.IdiomasId, New MultiSelectList(ViewBag.ListaIdiomas, "Id", "Nombre", Model.IdiomasId), New With {.style = "width: 100%"})
                             </div>
                             <label class="control-label col-md-2">Idiomas Activos</label>
                         </div>
                    </div>
                    @<div class="form-actions">
                        <button type="submit" class="btn blue">Grabar</button>
                    </div>
                End Using
            </div>
        </div>
        <!-- END SAMPLE FORM PORTLET-->
    </div>
</div>
