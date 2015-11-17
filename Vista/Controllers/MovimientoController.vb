Imports BLL
Imports EE
Public Class MovimientoController
    Inherits BaseController

    Private vBLL As MovimientoBLL

    Sub New()
        Me.vBLL = New MovimientoBLL()
    End Sub

    <Autorizar(Roles:="ListarMovimientos")>
    Function Index() As ActionResult
        Return View()
    End Function

    <Autorizar(Roles:="ListarMovimientos")>
    Function ListarAjax() As JsonResult
        Dim draw = Request("draw")
        Dim inicio = Request("start")
        Dim cantidadPorPagina = Request("length")

        'Obtiene todos los registros
        Dim lista As List(Of Movimiento) = Me.vBLL.Listar()

        'Se aplican todos los filtros
        Dim listaFiltrada As List(Of Movimiento) = lista
        'If Not [String].IsNullOrEmpty(Request("search[value]")) Then
        '    Dim busqueda As String = Request("search[value]").ToLower()
        '    listaFiltrada = listaFiltrada.Where(Function(x) x.FechaHora.ToString("dd/MM/yyyy").Contains(busqueda) Or x.Tipo.ToString().ToLower().Contains(busqueda) Or x.Descripcion.ToLower().Contains(busqueda) Or x.Usuario.NombreUsuario.ToLower().Contains(busqueda)).ToList()
        'End If
        If Not [String].IsNullOrEmpty(Request("desde")) Then
            Dim desde As Date = Date.ParseExact(Request("desde"), "dd/MM/yyyy", Nothing)
            listaFiltrada = listaFiltrada.Where(Function(x) x.Fecha.Date >= desde).ToList()
        End If
        If Not [String].IsNullOrEmpty(Request("hasta")) Then
            Dim hasta As Date = Date.ParseExact(Request("hasta"), "dd/MM/yyyy", Nothing)
            listaFiltrada = listaFiltrada.Where(Function(x) x.Fecha.Date <= hasta).ToList()
        End If
        If Not [String].IsNullOrEmpty(Request("tipo[]")) Then
            Dim tipo As String = Request("tipo[]").ToLower()
            listaFiltrada = listaFiltrada.Where(Function(x) tipo.Contains(x.ObtenerTipo.ToLower())).ToList()
        End If

        Dim Total As Double = 0
        For Each m As Movimiento In listaFiltrada
            Total += (m.ObtenerImporte() * -1)
        Next

        'Se aplica el ordenamiento
        Dim sortColumnIndex = Convert.ToInt32(Request("order[0][column]"))
        Dim orderingFunction As Func(Of Movimiento, Object) = (Function(m) _
            If(sortColumnIndex = 0, m.Fecha, _
                If(sortColumnIndex = 1, m.ObtenerTipo, _
                    If(sortColumnIndex = 2, m.Numero, _
                        If(sortColumnIndex = 3, m.Observacion, _
                            If(sortColumnIndex = 4, (m.ObtenerImporte() * -1), m.Usuario.NombreUsuario)
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
        Dim listaModel As List(Of MovimientoListAjaxViewModel) =
            listaFiltrada _
            .Select(Function(x) New MovimientoListAjaxViewModel With {
                .Fecha = x.Fecha.ToString("dd/MM/yyyy"),
                .Tipo = x.ObtenerTipo(),
                .Numero = x.Numero,
                .Observacion = x.Observacion,
                .Importe = "$" + (x.ObtenerImporte() * -1).ToString("0.00"),
                .Usuario = x.Usuario.NombreUsuario,
                .Acciones = x.ObtenerTipoSinFormato().ToString() + " " + x.Numero.ToString()
            }) _
            .Skip(inicio) _
            .Take(cantidadPorPagina) _
            .ToList()

        'Se forma el json y se retorno por ajax
        Return Json(New With { _
            Key .total = Math.Round(Total, 2).ToString("0.00"), _
            Key .draw = draw, _
            Key .recordsTotal = lista.Count.ToString, _
            Key .recordsFiltered = listaFiltrada.Count.ToString, _
            Key .data = listaModel _
        }, JsonRequestBehavior.AllowGet)
    End Function

    Function GenerarPdf(ByVal tipo As String, ByVal numero As Integer, ByVal tipoComprobante As String) As ActionResult
        Return New Rotativa.ActionAsPdf("Detalle", New With {.tipo = tipo, .numero = numero, .tipoComprobante = tipoComprobante})
    End Function

    Function Detalle(ByVal tipo As String, ByVal numero As Integer, ByVal tipoComprobante As String) As ActionResult
        Dim vMovimiento As Movimiento = Me.vBLL.Consultar(tipo, numero, tipoComprobante)
        Return View(vMovimiento)
    End Function

End Class