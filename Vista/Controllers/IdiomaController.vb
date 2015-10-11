Imports BLL
Imports EE

Public Class IdiomaController
    Inherits BaseController

    Private vBLL As IdiomaBLL
    Sub New()
        Me.vBLL = New IdiomaBLL()
    End Sub

    '
    ' GET: /Idioma/Edit/5
    <Autorizar(Roles:="EditarIdioma")>
    Function Edit() As ActionResult
        Dim listaIdiomas As List(Of Idioma) = Me.vBLL.Listar()
        Dim modelo As New IdiomaEditarViewModel()
        For Each idioma As Idioma In listaIdiomas
            If idioma.Activo Then
                modelo.IdiomasId.Add(idioma.Id)
            End If
        Next
        ViewBag.ListaIdiomas = listaIdiomas
        Return View(modelo)
    End Function

    '
    ' POST: /Idioma/Edit/5
    <Autorizar(Roles:="EditarIdioma")>
    <HttpPost()> _
    Function Edit(ByVal modelo As IdiomaEditarViewModel) As ActionResult
        Me.vBLL.Editar(modelo.IdiomasId)
        Return RedirectToAction("Index", "Home")
    End Function

End Class