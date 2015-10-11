@ModelType EE.Usuario

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
            <a href="#">Mi Cuenta</a>
        </li>
    </ul>
End Section

<div class="row">
    <div class="col-md-12">
        <!-- BEGIN Portlet PORTLET-->
        <div class="portlet box blue">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-user"></i>Detalle de mi cuenta
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
                            @Html.DisplayNameFor(Function(model) model.Nombre): @Html.DisplayFor(Function(model) model.Nombre)<br />
                            @Html.DisplayNameFor(Function(model) model.Apellido): @Html.DisplayFor(Function(model) model.Apellido)<br />
                            @Html.DisplayNameFor(Function(model) model.Email): @Html.DisplayFor(Function(model) model.Email)<br />
                            @Html.DisplayNameFor(Function(model) model.NombreUsuario): @Html.DisplayFor(Function(model) model.NombreUsuario)<br />
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="row">
    <div class="col-md-12">
        @*@Html.ActionLink("Editar", "Edit", New With {.id = Model.Id}, New With {.class = "btn blue"})*@
        @Html.ActionLink("Cambiar Contraseña", "CambiarClave", Nothing, New With {.class = "btn blue"})
    </div>
</div>