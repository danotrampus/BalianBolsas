Public Class HomeController
    Inherits BaseController

    Function Index() As ActionResult
        'Dim vProductoBLL As New BLL.ProductoBLL
        'Dim vListaProductos As List(Of EE.Bolsa) = vProductoBLL.ListarBolsas()
        'Return View(vListaProductos)
        Dim vPolimeroBLL As New BLL.PolimeroBLL()
        ViewBag.Polimeros = vPolimeroBLL.Listar()
        Dim vImpresionBLL As New BLL.ImpresionBLL()
        ViewBag.Impresiones = vImpresionBLL.Listar()
        Dim vManijaBLL As New BLL.ManijaBLL()
        ViewBag.Manijas = vManijaBLL.Listar()
        Return View()
    End Function

    Function Empresa() As ActionResult
        Return View()
    End Function

    Function Faq() As ActionResult
        Return View()
    End Function

    Function PoliticaPrivacidad() As ActionResult
        Return View()
    End Function

    Function TerminosCondiciones() As ActionResult
        Return PartialView()
    End Function

    Function PaginaNoEncontrada() As ActionResult
        Return View()
    End Function

End Class