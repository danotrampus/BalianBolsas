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
            <a href="@Url.Action("Index", "Usuario")">Usuarios</a>
            <i class="fa fa-angle-right"></i>
        </li>
        <li>
            <a href="#">Detalle</a>
        </li>
    </ul>
End Section

<div class="row">
    <div class="col-md-12">
        @Code
            If IsNothing(TempData.Item("error")) = False Then    
                @<div class="alert alert-danger alert-dismissable">
                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true"></button>
                    @Html.Encode(TempData.Item("error"))
                </div>
            End If
        End Code
        <!-- BEGIN Portlet PORTLET-->
        <div class="portlet box blue">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-user"></i>Detalle de usuario
                </div>
                <ul class="nav nav-tabs">
                    <li class="active">
                        <a href="#portlet_tab1" data-toggle="tab">
                            Información Básica
                        </a>
                    </li>
                    <li>
                        <a href="#portlet_tab2" data-toggle="tab">
                            Perfiles
                        </a>
                    </li>
                </ul>
            </div>
            <div class="portlet-body">
                <div class="tab-content">
                    <div class="tab-pane active" id="portlet_tab1">
                        <p>
                            @Html.DisplayNameFor(Function(model) model.Nombre): @Html.DisplayFor(Function(model) model.Nombre)<br/>
                            @Html.DisplayNameFor(Function(model) model.Apellido): @Html.DisplayFor(Function(model) model.Apellido)<br />
                            @Html.DisplayNameFor(Function(model) model.Email): @Html.DisplayFor(Function(model) model.Email)<br />
                            @Html.DisplayNameFor(Function(model) model.NombreUsuario): @Html.DisplayFor(Function(model) model.NombreUsuario)<br />
                            @Html.DisplayNameFor(Function(model) model.Activo): @Html.DisplayFor(Function(model) model.Activo)
                        </p>
                    </div>
                    <div class="tab-pane" id="portlet_tab2">
                        <p>
                            <div class="table-scrollable">
                                <table class="table table-hover">
                                    <thead>
                                        <tr>
                                            <th>
                                                Nombre
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                    @For Each item In Model.ListaPerfiles
                                        Dim currentItem = item

                                        @<tr>
                                            <td>
                                                @Html.ActionLink(item.Nombre, "Details", "Perfil", New With {.id = currentItem.Id}, Nothing)
                                            </td>
                                        </tr>
                                    Next
                                    </tbody>
                                </table>
                            </div>
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="row">
    <div class="col-md-12">
        @Code
            If User.IsInRole("ListarUsuarios") Then
                @Html.ActionLink("Volver", "Index", Nothing, New With {.class = "btn default"})
            End If
            If Model.NombreUsuario <> "admin" And User.IsInRole("EditarUsuario") Then
                @Html.ActionLink("Editar", "Edit", New With {.id = Model.Id}, New With {.class = "btn blue"})
            End If
            If Model.NombreUsuario <> "admin" And User.IsInRole("BajaUsuario") Then
                @<a class="btn red" data-toggle="modal" href="#delete-confirmation">Eliminar</a>
            End If
        End Code  
    </div>
</div>

@Using Html.BeginForm("Delete", "Usuario", New With {.id = Model.Id}, FormMethod.Get)
@Html.AntiForgeryToken()
@<div class="modal fade" id="delete-confirmation" tabindex="-1" role="basic" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                <h4 class="modal-title">Confirma que desea eliminar el registro?</h4>
            </div>
            <div class="modal-body">
                Esta operación no se puede deshacer.
            </div>
            <div class="modal-footer">
                <button type="button" class="btn default" data-dismiss="modal">Cerrar</button>
                <button type="submit" class="btn blue">Aceptar</button>    
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>
End Using