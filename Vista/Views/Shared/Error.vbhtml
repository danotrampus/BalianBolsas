﻿@Code
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
            <a href="#">Error</a>
        </li>
    </ul>
End Section

@Section stylesheets
    @Styles.Render("~/Content/error/css")
End Section

<div class="row">
    <div class="col-md-12 page-500">
        <div class=" number">
            500
        </div>
        <div class=" details">
            <h3>Oops! Algo salió mal.</h3>
            <p>
                Estamos tratando de arreglarlo!<br>
                Por favor intente nuevamente en unos minutos.<br><br>
            </p>
        </div>
    </div>
</div>