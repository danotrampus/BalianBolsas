@ModelType EE.Encuesta

<style>
    .radio input[type="radio"] {
        margin-left: 0px !important;
    }
</style>
<div class="portlet box grey-cascade">
    <div class="portlet-title">
        <div class="caption">
            <i class="fa fa-question"></i>@Model.Tipo
        </div>
        <div class="tools">
            <a href="javascript:;" class="collapse">
            </a>
            <a href="javascript:;" class="remove">
            </a>
        </div>
    </div>
    <div class="portlet-body">
        @Code
            @Using Html.BeginForm()
                @Html.HiddenFor(Function(model) model.Id)
                @Model.Pregunta
                @<br />
                @<br />
                @For index = 0 To Model.ListaOpciones.Count() - 1
                    Dim i As Integer = index
                    @Html.RadioButtonFor(Function(model) model.Respuesta, Model.ListaOpciones(i).Id) @Model.ListaOpciones(i).Valor
                    @<br />
                Next
                @<br />
                @<button type="submit" class="btn blue" id="btnResponderEncuesta" disabled>Votar</button>
            End Using
        End Code
    </div>
</div>