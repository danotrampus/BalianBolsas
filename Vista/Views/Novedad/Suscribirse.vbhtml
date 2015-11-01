@ModelType SuscribirseViewModel

<div class="portlet box grey-cascade">
    <div class="portlet-title">
        <div class="caption">
            <i class="fa fa-question"></i>Noticias
        </div>
        <div class="tools">
            <a href="javascript:;" class="collapse">
            </a>
            <a href="javascript:;" class="remove">
            </a>
        </div>
    </div>
    <div class="portlet-body">
        @code
            If TempData.ContainsKey("Info") Then
            @<div class="alert alert-success" role="alert">
                <button class="close" data-dismiss="alert"></button>
                <strong>Éxito: </strong>@TempData("Info")
            </div>
            End If
        End Code
        @Code
            @Using Html.BeginForm()
                @<div class="form-group @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Email))), Nothing, "has-error")) ">
                    @Html.LabelFor(Function(model) model.Email)
                    @Html.TextBoxFor(Function(model) model.Email, New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(model) model.Email, Nothing, New With {.class = "help-block"})
                </div>
                @<div class="form-group @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.ListaCategoriasSeleccionadas))), Nothing, "has-error"))">
                    @Html.LabelFor(Function(model) model.ListaCategoriasSeleccionadas)
                    @Html.ListBoxFor(Function(model) model.ListaCategoriasSeleccionadas, New MultiSelectList(ViewBag.Categorias, "Id", "Nombre"), New With {.style = "width: 100%;"})
                    @Html.ValidationMessageFor(Function(model) model.ListaCategoriasSeleccionadas, Nothing, New With {.class = "help-block"})
                </div>
                @<button type="submit" class="btn blue">Votar</button>
            End Using
        End Code
    </div>
</div>