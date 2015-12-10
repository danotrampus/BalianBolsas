@ModelType EE.Encuesta

@Code
    If Model IsNot Nothing Then
        If Model.Tipo = "Encuesta" Then
    @<div class="portlet box grey-cascade">
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
            @Model.Pregunta
            <br />
            <br />
            @Code
                        Dim total As Double = 0
                        For Each o As EE.Opcion In Model.ListaOpciones
                            total += o.Selecciones
                        Next
                        For Each o As EE.Opcion In Model.ListaOpciones
                            Dim porcentaje As Double = o.Selecciones * 100 / total
                @<p class="small hint-text">@o.Valor</p>
                @<div class="progress ">
                    <div class="progress-bar progress-bar-success" style="width: @Math.Round(porcentaje)%;"></div>
                </div>
                        Next
            End Code
        </div>
    </div>
Else
    @<a href="@Url.Action("Index", "Home")" class="btn blue margin-top-20">Volver al inicio</a>
End If
End If
End Code

