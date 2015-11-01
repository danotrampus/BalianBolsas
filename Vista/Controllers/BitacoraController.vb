Imports EE
Imports BLL

Public Class BitacoraController
    Inherits BaseController

    Private vBll As BitacoraBLL
    Sub New()
        Me.vBll = New BitacoraBLL()
    End Sub

    <Autorizar(Roles:="ListarBitacoras")>
    Function Index() As ActionResult
        Return View()
    End Function

    Function ListarAjax() As JsonResult
        Dim draw = Request("draw")
        Dim inicio = Request("start")
        Dim cantidadPorPagina = Request("length")

        'Obtiene todos los registros
        Dim listaBitacora As List(Of Bitacora) = Me.vBll.Listar()

        'Se aplican todos los filtros
        Dim listaBitacoraFiltrada As List(Of Bitacora) = listaBitacora
        If Not [String].IsNullOrEmpty(Request("search[value]")) Then
            Dim busqueda As String = Request("search[value]").ToLower()
            listaBitacoraFiltrada = listaBitacoraFiltrada.Where(Function(x) x.FechaHora.ToString("dd/MM/yyyy").Contains(busqueda) Or x.Tipo.ToString().ToLower().Contains(busqueda) Or x.Descripcion.ToLower().Contains(busqueda) Or x.Usuario.NombreUsuario.ToLower().Contains(busqueda)).ToList()
        End If
        If Not [String].IsNullOrEmpty(Request("desde")) Then
            Dim desde As Date = Date.ParseExact(Request("desde"), "dd/MM/yyyy", Nothing)
            listaBitacoraFiltrada = listaBitacoraFiltrada.Where(Function(x) x.FechaHora.Date >= desde).ToList()
        End If
        If Not [String].IsNullOrEmpty(Request("hasta")) Then
            Dim hasta As Date = Date.ParseExact(Request("hasta"), "dd/MM/yyyy", Nothing)
            listaBitacoraFiltrada = listaBitacoraFiltrada.Where(Function(x) x.FechaHora.Date <= hasta).ToList()
        End If
        If Not [String].IsNullOrEmpty(Request("descripcion")) Then
            Dim descripcion As String = Request("descripcion").ToLower()
            listaBitacoraFiltrada = listaBitacoraFiltrada.Where(Function(x) x.Descripcion.ToLower().Contains(descripcion)).ToList()
        End If
        If Not [String].IsNullOrEmpty(Request("usuario")) Then
            Dim usuario As String = Request("usuario").ToLower()
            listaBitacoraFiltrada = listaBitacoraFiltrada.Where(Function(x) x.Usuario.NombreUsuario.ToLower().Contains(usuario)).ToList()
        End If
        If Not [String].IsNullOrEmpty(Request("tipoEvento")) Then
            Dim tipoEvento As Integer = Request("tipoEvento")
            listaBitacoraFiltrada = listaBitacoraFiltrada.Where(Function(x) x.Tipo = tipoEvento).ToList()
        End If

        'Se aplica el ordenamiento
        Dim sortColumnIndex = Convert.ToInt32(Request("order[0][column]"))
        Dim orderingFunction As Func(Of Bitacora, Object) = (Function(c) If(sortColumnIndex = 0, c.FechaHora, If(sortColumnIndex = 1, c.Tipo, If(sortColumnIndex = 2, c.Descripcion, c.Usuario.NombreUsuario))))
        Dim sortDirection = Request("order[0][dir]")
        If sortDirection = "asc" Then
            listaBitacoraFiltrada = listaBitacoraFiltrada.OrderBy(orderingFunction).ToList()
        Else
            listaBitacoraFiltrada = listaBitacoraFiltrada.OrderByDescending(orderingFunction).ToList()
        End If

        'Se aplica el paginado
        Dim listaModel As List(Of BitacoraListAjaxViewModel) =
            listaBitacoraFiltrada _
            .Select(Function(x) New BitacoraListAjaxViewModel With {
                .FechaHora = x.FechaHora.ToString("dd/MM/yyyy HH:mm:ss"),
                .Tipo = x.Tipo.ToString(),
                .Descripcion = x.Descripcion,
                .Usuario = x.Usuario.NombreUsuario
            }) _
            .Skip(inicio) _
            .Take(cantidadPorPagina) _
            .ToList()

        'Se forma el json y se retorno por ajax
        Return Json(New With { _
            Key .draw = draw, _
            Key .recordsTotal = listaBitacora.Count.ToString, _
            Key .recordsFiltered = listaBitacoraFiltrada.Count.ToString, _
            Key .data = listaModel _
        }, JsonRequestBehavior.AllowGet)
    End Function

End Class