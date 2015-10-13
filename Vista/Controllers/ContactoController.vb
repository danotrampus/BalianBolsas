Imports BLL
Imports EE
Public Class ContactoController
    Inherits BaseController

    Private vBLL As ContactoBLL
    Sub New()
        Me.vBLL = New ContactoBLL()
    End Sub

    '
    ' GET: /Contacto
    <Autorizar(Roles:="ListarContactos")>
    Function Index() As ActionResult
        Dim vLista As List(Of Contacto) = Me.vBLL.Listar()
        Return View(vLista)
    End Function

    Function Crear() As ActionResult
        Return View()
    End Function

    <HttpPost()> _
    Function Crear(ByVal c As Contacto) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Crear(c)
            Return RedirectToAction("Index", "Home")
        End If

        Return View(c)
    End Function

End Class