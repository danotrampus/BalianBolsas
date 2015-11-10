Imports EE
Imports BLL
Public Class PedidoController
    Inherits BaseController

    Private vProductoBLL As ProductoBLL

    Sub New()
        Me.vProductoBLL = New ProductoBLL()
    End Sub

    Function Index() As ActionResult
        Return View()
    End Function

    Function Agregar(ByVal form As FormCollection) As ActionResult
        Dim pd As New DetallePedido
        Dim vProducto As Producto = Me.vProductoBLL.ConsultarPorId(form.Item("Producto_Id"))
        pd.Cantidad = form.Item("Cantidad")
        pd.Precio = vProducto.CalcularPrecio()
        pd.Producto = vProducto
        Me.ObtenerCarro().Importe += pd.Total
        Me.ObtenerCarro().ListaDetalles.Add(pd)
        Return RedirectToAction("Index", "Home")
    End Function

    Function Quitar(ByVal id As Integer) As ActionResult
        Dim p As Pedido = Me.ObtenerCarro()
        If p IsNot Nothing Then
            For i = 0 To p.ListaDetalles.Count - 1
                Dim dp As DetallePedido = p.ListaDetalles(i)
                If dp.Producto.Id = id Then
                    p.ListaDetalles.RemoveAt(i)
                    p.Importe -= dp.Total
                    Exit For
                End If
            Next
        End If

        Return RedirectToAction("VerCarro")
    End Function

    Function VerCarro() As ActionResult
        Return View(Me.ObtenerCarro())
    End Function

    Private Function ObtenerCarro() As Pedido
        Dim sesionCarro = System.Web.HttpContext.Current.Session("Carro")
        If sesionCarro IsNot Nothing Then
            Return DirectCast(sesionCarro, Pedido)
        Else
            Dim p As New Pedido
            p.FechaInicio = Now.Date
            p.Estado = "Pendiente"
            p.Importe = 0
            System.Web.HttpContext.Current.Session("Carro") = p
            Return p
        End If
        Return Nothing
    End Function

End Class