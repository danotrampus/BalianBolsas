@ModelType EE.Comentario

@Code
    Layout = Nothing
End Code

<div class="panel panel-primary">
    <div class="panel-heading">
        <h3 class="panel-title">Comentar</h3>
    </div>
    <div class="panel-body">
        @Using Html.BeginForm("Comentar", "Bolsa", FormMethod.Post)
            @<div class="form-body">
                @Html.HiddenFor(Function(model) model.Producto.Id)
                <div class="form-group @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Valoracion))), Nothing, "has-error"))">
                    <label>Valoración</label>
                    @Html.TextBoxFor(Function(model) model.Valoracion, New With {.type = "number", .class = "rating", .min = "0", .max = "5", .step = "1", .data_glyphicon = "false", .data_size = "xs", .data_show_caption = "false"})
                    @Html.ValidationMessageFor(Function(model) model.Valoracion, Nothing, New With {.class = "help-block"})
                </div>
                <div class="form-group @(If(Html.ViewData.ModelState.IsValidField(Convert.ToString(Html.IdFor(Function(model) model.Mensaje))), Nothing, "has-error"))">
                    <label>Mensaje</label>
                    @Html.TextAreaFor(Function(model) model.Mensaje, New With {.class = "form-control", .rows = 8, .style = "height:auto;"})
                    @Html.ValidationMessageFor(Function(model) model.Mensaje, Nothing, New With {.class = "help-block"})
                </div>
            </div>
            @<div class="form-actions">
                <button type="submit" class="btn default pull-right">Comentar</button>
            </div>
        End Using
    </div>
</div>


