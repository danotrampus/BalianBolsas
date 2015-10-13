Public Class HomeController
    Inherits BaseController

    '
    ' GET: /Home

    Function Index() As ActionResult
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

End Class