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

<h1>Empresa</h1>
<p>Somos una empresa familiar dedicada a la fabricación de bolsas de polietileno, polipropileno y biodegradable.
   Como asumimos todo el proceso a partir de la transformación de las materias primas, podemos farbicar múltiples tipos de bolsas, incluída
    la impresión, de acuerdo a la necesidad puntual de su negocio.
    Contamos con los recursos técnicos y humanos para poder brindarle a cada cliente una alta calidad de productos como así también
    brindar el mejor servicio y trato personalizado.</p>
