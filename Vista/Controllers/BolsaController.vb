Imports BLL
Imports EE
Imports System.IO
Public Class BolsaController
    Inherits BaseController

    Private vBLL As ProductoBLL
    Private vImpresionBLL As ImpresionBLL
    Private vPolimeroBLL As PolimeroBLL
    Private vManijaBLL As ManijaBLL

    Sub New()
        Me.vBLL = New ProductoBLL()
        Me.vImpresionBLL = New ImpresionBLL()
        Me.vPolimeroBLL = New PolimeroBLL()
        Me.vManijaBLL = New ManijaBLL()
    End Sub

    '
    ' GET: /Producto
    <Autorizar(Roles:="ListarBolsas")>
    Function Index() As ActionResult
        Dim vLista As List(Of Bolsa) = Me.vBLL.ListarBolsas()
        Return View(vLista)
    End Function

    <Autorizar(Roles:="ConsultarBolsa")>
    Function Detalle(ByVal id As Integer) As ActionResult
        Dim vBolsa As EE.Bolsa = DirectCast(Me.vBLL.ConsultarPorId(id), Bolsa)
        Return View(vBolsa)
    End Function

    <Autorizar(Roles:="CrearBolsa")>
    Function Crear() As ActionResult
        ViewBag.Impresiones = Me.vImpresionBLL.Listar()
        ViewBag.Polimeros = Me.vPolimeroBLL.Listar()
        ViewBag.Manijas = Me.vManijaBLL.Listar()
        Return View()
    End Function

    <Autorizar(Roles:="CrearBolsa")>
    <HttpPost()>
    Function Crear(ByVal model As BolsaViewModel) As ActionResult
        ModelState.Item("ImpresionId").Errors.Clear()
        ModelState.Item("ManijaId").Errors.Clear()
        Dim listaTiposImagenes As New List(Of String)
        listaTiposImagenes.AddRange({"image/gif", "image/jpeg", "image/png"})
        If model.Imagen IsNot Nothing Then
            If listaTiposImagenes.Contains(model.Imagen.ContentType) = False Then
                ModelState.AddModelError("Imagen", "Tipo de archivo no permitido")
            End If
        End If
        If ModelState.IsValid Then
            Dim directorioSubidas As String = "~/Content/img"
            Dim urlSubidas As String = "/Content/img"
            Dim idImagen As String = Guid.NewGuid().ToString() + Path.GetExtension(model.Imagen.FileName)
            Dim rutaImagen As String = Path.Combine(Server.MapPath(directorioSubidas), idImagen)
            Dim urlImagen As String = urlSubidas + "/" + idImagen
            model.Imagen.SaveAs(rutaImagen)

            Dim b As New Bolsa
            b.Ancho = model.Ancho
            b.Largo = model.Largo
            b.Espesor = model.Espesor
            b.Soldadura = model.Soldadura
            b.Formato = model.Formato
            b.Impresion.Id = model.ImpresionId
            b.Polimero.Id = model.PolimeroId
            b.Manija.Id = model.ManijaId
            b.Imagen = urlImagen

            Me.vBLL.Crear(b)
            Return RedirectToAction("Index")
        End If
        ViewBag.Impresiones = Me.vImpresionBLL.Listar()
        ViewBag.Polimeros = Me.vPolimeroBLL.Listar()
        ViewBag.Manijas = Me.vManijaBLL.Listar()
        Return View(model)
    End Function

    <Autorizar(Roles:="EditarBolsa")>
    Function Editar(ByVal id As Integer) As ActionResult
        Dim vBolsa As EE.Bolsa = DirectCast(Me.vBLL.ConsultarPorId(id), Bolsa)
        Dim model As New BolsaViewModel
        model.Id = vBolsa.Id
        model.Ancho = vBolsa.Ancho
        model.Largo = vBolsa.Largo
        model.Espesor = vBolsa.Espesor
        model.Formato = vBolsa.Formato
        model.Soldadura = vBolsa.Soldadura
        model.ManijaId = vBolsa.Manija.Id
        model.ImpresionId = vBolsa.Impresion.Id
        model.PolimeroId = vBolsa.Polimero.Id

        ViewBag.Impresiones = Me.vImpresionBLL.Listar()
        ViewBag.Polimeros = Me.vPolimeroBLL.Listar()
        ViewBag.Manijas = Me.vManijaBLL.Listar()

        Return View(model)
    End Function

    <Autorizar(Roles:="EditarBolsa")>
    <HttpPost()> _
    Function Editar(ByVal id As Integer, ByVal model As BolsaViewModel) As ActionResult
        ModelState.Item("ImpresionId").Errors.Clear()
        ModelState.Item("ManijaId").Errors.Clear()
        If model.Imagen Is Nothing Then
            ModelState.Item("Imagen").Errors.Clear()
        Else
            Dim listaTiposImagenes As New List(Of String)
            listaTiposImagenes.AddRange({"image/gif", "image/jpeg", "image/png"})
            If listaTiposImagenes.Contains(model.Imagen.ContentType) = False Then
                ModelState.AddModelError("Imagen", "Tipo de archivo no permitido")
            End If
        End If
        If ModelState.IsValid Then
            Dim b As New Bolsa
            Dim vBolsaActual As EE.Bolsa = DirectCast(Me.vBLL.ConsultarPorId(id), Bolsa)
            If model.Imagen IsNot Nothing Then
                Dim rutaImagenActual As String = Server.MapPath("~" + vBolsaActual.Imagen)
                If IO.File.Exists(rutaImagenActual) Then
                    IO.File.Delete(rutaImagenActual)
                End If
                Dim directorioSubidas As String = "~/Content/img"
                Dim urlSubidas As String = "/Content/img"
                Dim idImagen As String = Guid.NewGuid().ToString() + Path.GetExtension(model.Imagen.FileName)
                Dim rutaImagen As String = Path.Combine(Server.MapPath(directorioSubidas), idImagen)
                Dim urlImagen As String = urlSubidas + "/" + idImagen
                model.Imagen.SaveAs(rutaImagen)
                b.Imagen = urlImagen
            Else
                b.Imagen = vBolsaActual.Imagen
            End If

            b.Id = model.Id
            b.Ancho = model.Ancho
            b.Largo = model.Largo
            b.Espesor = model.Espesor
            b.Soldadura = model.Soldadura
            b.Formato = model.Formato
            b.Impresion.Id = model.ImpresionId
            b.Polimero.Id = model.PolimeroId
            b.Manija.Id = model.ManijaId

            Me.vBLL.Editar(b)
            Return RedirectToAction("Index")
        End If
        ViewBag.Impresiones = Me.vImpresionBLL.Listar()
        ViewBag.Polimeros = Me.vPolimeroBLL.Listar()
        ViewBag.Manijas = Me.vManijaBLL.Listar()
        Return View(model)
    End Function

    <Autorizar(Roles:="EliminarBolsa")>
    Function Eliminar(ByVal id As Integer) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Eliminar(id)
        End If
        Return RedirectToAction("Index")
    End Function

    <Autorizar()>
    Function Comentar(ByVal productoId As Integer) As ActionResult
        Dim c As New Comentario
        c.Producto.Id = productoId
        Return View(c)
    End Function

    <Autorizar()>
    <HttpPost()>
    Function Comentar(ByVal c As Comentario) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Comentar(c)
        End If
        Return RedirectToAction("Agregar", "Pedido", New With {c.Producto.Id})
    End Function

    <HttpPost()>
    Function Comparar(ByVal form As FormCollection) As ActionResult
        Dim ids = form.Item("productosId")
        Dim listaProductos As List(Of Bolsa) = Me.vBLL.Comparar(ids)
        Return View(listaProductos)
    End Function

    Function ListarAjax() As JsonResult
        Dim draw = Request("draw")
        Dim inicio = Request("start")
        Dim cantidadPorPagina = Request("length")

        'Obtiene todos los registros
        Dim lista As List(Of Bolsa) = Me.vBLL.ListarBolsas()

        'Se aplican todos los filtros
        Dim listaFiltrada As List(Of Bolsa) = lista
        If Not [String].IsNullOrEmpty(Request("search[value]")) Then
            Dim busqueda As String = Request("search[value]").ToLower()
            listaFiltrada = listaFiltrada.Where(Function(x) x.ObtenerDescripcionMedidas.Contains(busqueda) Or _
                                                            x.Polimero.Nombre.ToLower().Contains(busqueda) Or _
                                                            x.Impresion.Nombre.ToLower().Contains(busqueda) Or _
                                                            x.Soldadura.ToLower().Contains(busqueda) Or _
                                                            x.Formato.ToLower().Contains(busqueda) Or _
                                                            x.Manija.Nombre.ToLower().Contains(busqueda) Or _
                                                            x.CalcularPrecioConIva().ToString("0.000").Contains(busqueda)).ToList()
        End If
        If Not [String].IsNullOrEmpty(Request("PolimeroId")) Then
            Dim PolimeroId As Integer = Convert.ToInt16(Request("PolimeroId"))
            listaFiltrada = listaFiltrada.Where(Function(x) x.Polimero.Id = PolimeroId).ToList()
        End If
        If Not [String].IsNullOrEmpty(Request("ImpresionId")) Then
            Dim ImpresionId As Integer = Convert.ToInt16(Request("ImpresionId"))
            listaFiltrada = listaFiltrada.Where(Function(x) x.Impresion.Id = ImpresionId).ToList()
        End If
        If Not [String].IsNullOrEmpty(Request("ManijaId")) Then
            Dim ManijaId As Integer = Convert.ToInt16(Request("ManijaId"))
            listaFiltrada = listaFiltrada.Where(Function(x) x.Manija.Id = ManijaId).ToList()
        End If

        'Se aplica el ordenamiento
        Dim sortColumnIndex = Convert.ToInt32(Request("order[0][column]"))
        Dim orderingFunction As Func(Of Bolsa, Object) = (Function(b) _
            If(sortColumnIndex = 0, b.Id, _
                If(sortColumnIndex = 1, b.Id, _
                    If(sortColumnIndex = 2, b.Id, _
                        If(sortColumnIndex = 3, b.Id, _
                            If(sortColumnIndex = 4, b.ObtenerDescripcionMedidas(), _
                                If(sortColumnIndex = 5, b.Polimero.Nombre, _
                                    If(sortColumnIndex = 7, b.Impresion.Nombre, _
                                        If(sortColumnIndex = 8, b.Soldadura, _
                                            If(sortColumnIndex = 9, b.Formato, _
                                                If(sortColumnIndex = 10, b.Manija.Nombre, b.CalcularPrecioConIva())
                                            )
                                        )
                                    )
                                )
                            )
                        )
                    )
                )
            )
        )
        Dim sortDirection = Request("order[0][dir]")
        If sortDirection = "asc" Then
            listaFiltrada = listaFiltrada.OrderBy(orderingFunction).ToList()
        Else
            listaFiltrada = listaFiltrada.OrderByDescending(orderingFunction).ToList()
        End If

        'Se aplica el paginado
        Dim listaModel As List(Of BolsaListAjaxViewModel) =
            listaFiltrada _
            .Select(Function(x) New BolsaListAjaxViewModel With {
                .Acciones = x.Id,
                .Seleccion = x.Id,
                .Valoracion = x.Valoracion,
                .Imagen = x.Imagen,
                .Medida = x.ObtenerDescripcionMedidas(),
                .Polimero = x.Polimero.Nombre,
                .Impresion = x.Impresion.Nombre,
                .Soldadura = x.Soldadura,
                .Formato = x.Formato,
                .Manija = x.Manija.Nombre,
                .PrecioUnitario = x.CalcularPrecioConIva().ToString("0.000")
            }) _
            .Skip(inicio) _
            .Take(cantidadPorPagina) _
            .ToList()

        'Se forma el json y se retorno por ajax
        Return Json(New With { _
            Key .draw = draw, _
            Key .recordsTotal = lista.Count.ToString, _
            Key .recordsFiltered = listaFiltrada.Count.ToString, _
            Key .data = listaModel _
        }, JsonRequestBehavior.AllowGet)
    End Function

End Class