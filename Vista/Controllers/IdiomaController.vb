Imports BLL
Imports EE

Public Class IdiomaController
    Inherits BaseController

    Private vBLL As IdiomaBLL
    Sub New()
        Me.vBLL = New IdiomaBLL()
    End Sub

    <Autorizar(Roles:="ListarIdiomas")>
    Function Index() As ActionResult
        Dim vLista As List(Of Idioma) = Me.vBLL.Listar()
        Return View(vLista)
    End Function

    <Autorizar(Roles:="CrearIdioma")>
    Function Crear() As ActionResult
        Dim vBLLIdioma As New IdiomaBLL
        ViewBag.Idiomas = vBLLIdioma.ListarIdiomasInactivos()
        Return View()
    End Function

    <Autorizar(Roles:="CrearIdioma")>
    <HttpPost()>
    Function Crear(ByVal i As Idioma) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Crear(i.Id)
            Return RedirectToAction("Index")
        End If

        Dim vBLLIdioma As New IdiomaBLL
        ViewBag.Idiomas = vBLLIdioma.ListarIdiomasInactivos()
        Return View(i)
    End Function

    '
    ' GET: /Idioma/Edit/5
    <Autorizar(Roles:="EditarIdioma")>
    Function Editar() As ActionResult
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
    Function Editar(ByVal modelo As IdiomaEditarViewModel) As ActionResult
        Me.vBLL.Editar(modelo.IdiomasId)
        Return RedirectToAction("Index", "Home")
    End Function

    <Autorizar(Roles:="EliminarIdioma")>
    Function Eliminar(ByVal id As Integer) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Eliminar(id)
        End If
        Return RedirectToAction("Index")
    End Function

End Class