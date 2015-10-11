@ModelType EE.Perfil

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
            <a href="@Url.Action("Index", "Perfil")">Perfiles</a>
            <i class="fa fa-angle-right"></i>
        </li>
        <li>
            <a href="#">Editar</a>
        </li>
    </ul>
End Section

@Section stylesheets
    @Styles.Render("~/Content/ztree/css")
End Section

@Section javascripts
    @Scripts.Render("~/Content/ztree/js")
End Section

@Section javascript_codigo
    <script type="text/javascript">
        $(document).ready(function () {
            var setting = {
                check: {
                    enable: true
                },
                data: {
                    key: {
                        children: "ListaPermisos",
                        name: "Descripcion",
                        checked: "Habilitado"
                    },
                    simpleData: {
                        idKey: "Id"
                    }
                }
            };
            var Nodes = @Html.Raw(ViewBag.ListaPermisos);
            $.fn.zTree.init($("#tree"), setting, Nodes);
            var treeObj = $.fn.zTree.getZTreeObj("tree");
            treeObj.expandAll(true);

            $("#btnSubmit").click(function () {
                var nodes = $.fn.zTree.getZTreeObj("tree").getNodes();
                var permissions = JSON.stringify(getPermissions(nodes));
                $("#ListaPermisos").val(permissions);
            });

            function getPermissions(nodes) {
                var permissions = [];
                for (var node in nodes) {
                    var zNode = nodes[node];
                    var permission = {};
                    permission.Id = zNode.Id;
                    permission.Descripcion = zNode.Descripcion;
                    permission.Habilitado = zNode.Habilitado;
                    permission.isParent = zNode.isParent;
                    if(zNode.isParent){
                        permission.ListaPermisos = getPermissions(zNode.ListaPermisos);
                    }
                    permissions.push(permission);
                }
                return permissions;
            }
        });
    </script>
End Section

<div class="row">
    <div class="col-md-12">
        <!-- BEGIN SAMPLE FORM PORTLET-->
        <div class="portlet box blue">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-users"></i> Nuevo Perfil
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
                        <div class="form-group @IIf(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Nombre))),Nothing,"has-error")">
                            @Html.LabelFor(Function(model) model.Nombre, New With {.class = "control-label"})
                            @Html.TextBoxFor(Function(model) model.Nombre, New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(model) model.Nombre, Nothing, New With {.class = "help-block"})
                        </div>
                        <div class="form-group">
                            @Html.LabelFor(Function(model) model.ListaPermisos, New With {.class = "control-label"})
                            <ul id="tree" class="ztree"></ul>
                            <input type="hidden" id="ListaPermisos" name="ListaPermisos" />
                        </div>
                    </div>
                    @<div class="form-actions">
                        <button type="submit" id="btnSubmit" class="btn blue">Grabar</button>
                        @Html.ActionLink("Volver", "Index", Nothing, New With {.class = "btn default"})
                    </div>
                End Using
            </div>
        </div>
        <!-- END SAMPLE FORM PORTLET-->
    </div>
</div>