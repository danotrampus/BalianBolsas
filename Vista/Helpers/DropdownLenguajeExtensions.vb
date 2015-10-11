Imports System.Runtime.CompilerServices
Imports System.Web.Http
Imports EE
Imports BLL

Public Module DropdownLenguajeExtensions
    <Extension()> _
    Public Function DropdownLenguaje(ByVal helper As HtmlHelper) As HtmlString
        Dim vIdiomaBll As New IdiomaBLL()
        Dim listaIdiomas As List(Of Idioma) = vIdiomaBll.Listar()
        Dim output As String = ""
        output = output +
            "<div id='google_translate_element' style='display:none;'></div>" +
            "<script type='text/javascript'>" +
                "function googleTranslateElementInit() {" +
                    "new google.translate.TranslateElement({ pageLanguage: 'es', includedLanguages: '" + ObtenerLocales(listaIdiomas) + "', layout: google.translate.TranslateElement.InlineLayout.SIMPLE, autoDisplay: false }, 'google_translate_element');" +
                "}" +
            "</script>" +
            "<script type='text/javascript' src='//translate.google.com/translate_a/element.js?cb=googleTranslateElementInit'></script>" +
            "<li class='dropdown dropdown-language'>" +
                "<a href='javascript:;' class='dropdown-toggle' data-toggle='dropdown' data-hover='dropdown' data-close-others='true'>" +
                    "<span class='langname'>Cambiar Idioma</span><i class='fa fa-angle-down'></i>" +
                "</a>" +
                "<ul class='dropdown-menu dropdown-menu-default'>"
        For Each Idioma As Idioma In listaIdiomas
            If Idioma.Activo Then
                output = output +
                    "<li><a href='javascript:;' class='translation-links' data-lang='" + Idioma.Nombre + "'>" + Idioma.Nombre + "</a></li>"
            End If
        Next
        output = output +
                "</ul>" +
            "</li>"
        Return MvcHtmlString.Create(output)
    End Function

    Private Function ObtenerLocales(ByVal listaIdiomas As List(Of Idioma)) As String
        Dim output As String = ""
        Dim prefix As String = ""
        For Each Idioma As Idioma In listaIdiomas
            If Idioma.Activo Then
                output = output + prefix + Idioma.Locale
                prefix = ","
            End If
        Next
        Return output
    End Function

End Module