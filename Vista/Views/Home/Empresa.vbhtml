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
            <a href="#">Empresa</a>
        </li>
    </ul>
End Section

<div class="row">
    <div class="col-lg-6">
        <h1>Empresa</h1>
        <p>
            Somos una empresa familiar dedicada a la fabricación de bolsas de polietileno, polipropileno y biodegradable.
            Como asumimos todo el proceso a partir de la transformación de las materias primas, podemos farbicar múltiples tipos de bolsas, incluída
            la impresión, de acuerdo a la necesidad puntual de su negocio.
            Contamos con los recursos técnicos y humanos para poder brindarle a cada cliente una alta calidad de productos como así también
            brindar el mejor servicio y trato personalizado.
            Nuestro valores son los siguientes:
        </p>
        <ul class="list-unstyled margin-top-10 margin-bottom-10">
            <li>
                <i class="fa fa-check icon-default"></i> Compromiso
            </li>
            <li>
                <i class="fa fa-check icon-default"></i> Trabajo
            </li>
            <li>
                <i class="fa fa-check icon-default"></i> Honestidad
            </li>
            <li>
                <i class="fa fa-check icon-default"></i> Confiabilidad
            </li>
            <li>
                <i class="fa fa-check icon-default"></i> Calidad
            </li>
        </ul>
    </div>
    <div class="col-lg-6">
        <img src="~/Content/global/img/quienes-somos.jpg" alt="" class="img-responsive">
    </div>
</div>

