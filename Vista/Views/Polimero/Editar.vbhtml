﻿@ModelType EE.Polimero

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
            <a href="@Url.Action("Index", "Polimero")">Polímeros</a>
            <i class="fa fa-angle-right"></i>
        </li>
        <li>
            <a href="#">Editar</a>
        </li>
    </ul>
End Section

@Section stylesheets
    @Styles.Render("~/Content/select2/css")
End Section

@Section javascripts
    @Scripts.Render("~/Content/select2/js")
End Section

@Section javascript_codigo
    <script type="text/javascript">
        $(document).ready(function () {
            $("#Color_Id").select2();
        });
    </script>
End Section

<div class="row">
    <div class="col-md-12">
        <!-- BEGIN SAMPLE FORM PORTLET-->
        <div class="portlet box blue">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-object-ungroup"></i> Editar Polímero
                </div>
                <div class="tools">
                    <a href="" class="collapse">
                    </a>
                    <a href="" class="remove">
                    </a>
                </div>
            </div>
            <div class="portlet-body form">
                @Using Html.BeginForm()
                    @Html.AntiForgeryToken()
                    @Html.ValidationSummary(True)
                    
                    @Html.HiddenFor(Function(model) model.Id)
                    @<div class="form-body">
                        <div class="form-group @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Nombre))), Nothing, "has-error"))">
                            @Html.LabelFor(Function(model) model.Nombre, New With {.class = "control-label"})
                            @Html.TextBoxFor(Function(model) model.Nombre, New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(model) model.Nombre, Nothing, New With {.class = "help-block"})
                        </div>
                         <div class="form-group @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Densidad))), Nothing, "has-error"))">
                             @Html.LabelFor(Function(model) model.Densidad, New With {.class = "control-label"})
                             @Html.TextBoxFor(Function(model) model.Densidad, New With {.class = "form-control", .placeholder = "X,XXXXXX"})
                             @Html.ValidationMessageFor(Function(model) model.Densidad, Nothing, New With {.class = "help-block"})
                         </div>
                         <div class="form-group @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Color.Id))), Nothing, "has-error"))">
                             @Html.LabelFor(Function(model) model.Color.Id, New With {.class = "control-label"})
                             @Html.DropDownListFor(Function(model) model.Color.Id, New SelectList(ViewBag.Colores, "Id", "Nombre"), "", New With {.class = "form-control"})
                             @Html.ValidationMessageFor(Function(model) model.Color.Id, Nothing, New With {.class = "help-block"})
                         </div>
                         <div class="form-group @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Precio))), Nothing, "has-error"))">
                             <label class="control-label">Precio Kilogramo</label>
                             @Html.TextBoxFor(Function(model) model.Precio, New With {.class = "form-control", .placeholder = "XXXXXX,XXX"})
                             @Html.ValidationMessageFor(Function(model) model.Precio, Nothing, New With {.class = "help-block"})
                         </div>
                    </div>
                    @<div class="form-actions">
                        <button type="submit" class="btn blue">Grabar</button>
                        @Html.ActionLink("Volver", "Index", Nothing, New With {.class = "btn default"})
                    </div>
                End Using
            </div>
        </div>
        <!-- END SAMPLE FORM PORTLET-->
    </div>
</div>
