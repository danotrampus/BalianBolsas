Imports BLL
Imports EE
Public Class NovedadController
    Inherits BaseController

    Private vBLL As NovedadBLL
    Sub New()
        Me.vBLL = New NovedadBLL()
    End Sub

    '
    ' GET: /Novedad
    <Autorizar(Roles:="ListarNovedades")>
    Function Index() As ActionResult
        Dim vLista As List(Of Novedad) = Me.vBLL.Listar()
        Return View(vLista)
    End Function

    <Autorizar(Roles:="ConsultarNovedad")>
    Function Detalle(ByVal id As Integer) As ActionResult
        Dim vNovedad As EE.Novedad = Me.vBLL.ConsultarPorId(id)
        Return View(vNovedad)
    End Function

    <Autorizar(Roles:="CrearNovedad")>
    Function Crear() As ActionResult
        Dim vBLLCat As New CategoriaBLL
        ViewBag.Categorias = vBLLCat.Listar()
        Return View(New NovedadViewModel)
    End Function

    <Autorizar(Roles:="CrearNovedad")>
    <HttpPost()>
    Function Crear(ByVal n As NovedadViewModel) As ActionResult
        If ModelState.IsValid Then
            Dim novedad As New Novedad
            novedad.Titulo = n.Titulo
            novedad.Contenido = n.Contenido
            novedad.Tipo = n.Tipo
            novedad.Categoria.Id = n.CategoriaId

            Me.vBLL.Crear(novedad)
            Return RedirectToAction("Index")
        End If

        Dim vBLLCat As New CategoriaBLL
        ViewBag.Categorias = vBLLCat.Listar()
        Return View(n)
    End Function

    <Autorizar(Roles:="EditarNovedad")>
    Function Editar(ByVal id As Integer) As ActionResult
        Dim vNovedad As EE.Novedad = Me.vBLL.ConsultarPorId(id)
        Dim n As New NovedadViewModel()
        n.Id = vNovedad.Id
        n.Titulo = vNovedad.Titulo
        n.Contenido = vNovedad.Contenido
        n.Tipo = vNovedad.Tipo
        n.CategoriaId = vNovedad.Categoria.Id

        Dim vBLLCat As New CategoriaBLL
        ViewBag.Categorias = vBLLCat.Listar()

        Return View(n)
    End Function

    <Autorizar(Roles:="EditarNovedad")>
    <HttpPost()> _
    Function Editar(ByVal id As Integer, ByVal n As NovedadViewModel) As ActionResult
        If ModelState.IsValid Then
            Dim novedad As New Novedad
            novedad.Id = n.Id
            novedad.Titulo = n.Titulo
            novedad.Contenido = n.Contenido
            novedad.Tipo = n.Tipo
            novedad.Categoria.Id = n.CategoriaId
            Me.vBLL.Editar(novedad)
            Return RedirectToAction("Index")
        End If

        Dim vBLLCat As New CategoriaBLL
        ViewBag.Categorias = vBLLCat.Listar()
        Return View(n)
    End Function

    <Autorizar(Roles:="EliminarNovedad")>
    Function Eliminar(ByVal id As Integer) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Eliminar(id)
        End If
        Return RedirectToAction("Index")
    End Function

    Function ListarNovedades() As ActionResult
        Dim vLista As List(Of Novedad) = Me.vBLL.ListarNovedades()
        Return View(vLista)
    End Function

    Public Function Suscribirse() As PartialViewResult
        Dim vBLLCat As New CategoriaBLL
        ViewBag.Categorias = vBLLCat.Listar()
        Return PartialView()
    End Function

    <HttpPost()>
    Function Suscribirse(ByVal s As SuscribirseViewModel) As PartialViewResult
        Dim vBLLCat As New CategoriaBLL
        ViewBag.Categorias = vBLLCat.Listar()

        If ModelState.IsValid Then
            Dim suscriptor As New Suscriptor
            suscriptor.Email = s.Email
            For Each id As Integer In s.ListaCategoriasSeleccionadas
                Dim c As New Categoria
                c.Id = id
                suscriptor.ListaCategorias.Add(c)
            Next
            Me.vBLL.Suscribirse(suscriptor)
            ModelState.Clear()
            TempData("Info") = "Se ha suscripto con éxito."
            Return PartialView(New SuscribirseViewModel)
        End If

        Return PartialView(s)
    End Function

    <Autorizar(Roles:="EnviarNovedad")>
    Public Function Enviar(ByVal id As Integer) As ActionResult
        Me.vBLL.Enviar(id)
        TempData("Info") = "Se ha enviado la noticia a los suscriptores."
        Return RedirectToAction("Index")
    End Function
End Class