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
    Function Detalles(ByVal id As Integer) As ActionResult
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

End Class