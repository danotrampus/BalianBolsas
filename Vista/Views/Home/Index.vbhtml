@Code
    Layout = "~/Views/Shared/_BackEnd.vbhtml"
End Code

@Section breadcrumbs
    <ul class="page-breadcrumb">
        <li>
            <i class="fa fa-home"></i>
            <a href="@Url.Action("Index")">Home</a>
        </li>
    </ul>
End Section

<h2>Bienvenidos!</h2>
<div class="row">
    <div class="col col-lg-9">

    </div>
    <div class="col col-lg-3">
        @Code
            Html.RenderAction("Responder", "Encuesta")
        End Code
    </div>
</div>
