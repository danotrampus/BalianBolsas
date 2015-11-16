Imports BLL
Imports EE
Public Class MovimientoController
    Inherits BaseController

    Private vBLL As MovimientoBLL

    Sub New()
        Me.vBLL = New MovimientoBLL()
    End Sub

    'Function Index() As ActionResult
    '    Return View()
    'End Function

    Function GenerarPdf(ByVal tipo As String, ByVal numero As Integer, ByVal tipoComprobante As String) As ActionResult
        Return New Rotativa.ActionAsPdf("Detalle", New With {.tipo = tipo, .numero = numero, .tipoComprobante = tipoComprobante})
    End Function

    Function Detalle(ByVal tipo As String, ByVal numero As Integer, ByVal tipoComprobante As String) As ActionResult
        Dim vMovimiento As Movimiento = Me.vBLL.Consultar(tipo, numero, tipoComprobante)
        Return View(vMovimiento)
    End Function

End Class