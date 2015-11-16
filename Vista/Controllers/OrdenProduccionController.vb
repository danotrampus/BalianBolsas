Imports BLL
Imports EE

Public Class OrdenProduccionController
    Inherits BaseController

    Private vBLL As OrdenProduccionBLL

    Sub New()
        Me.vBLL = New OrdenProduccionBLL
    End Sub

    '
    ' GET: /OrdenProduccion
    <Autorizar(Roles:="ListarOrdenesProduccion")>
    Function Index() As ActionResult
        Dim vLista As List(Of OrdenProduccion) = Me.vBLL.Listar()
        Return View(vLista)
    End Function

    <Autorizar(Roles:="IniciarOrden")>
    Function Iniciar(ByVal id As Integer) As ActionResult
        Me.vBLL.Iniciar(id)
        Return RedirectToAction("Index")
    End Function

    <Autorizar(Roles:="TerminarOrden")>
    Function Terminar(ByVal id As Integer) As ActionResult
        Me.vBLL.Terminar(id)
        Return RedirectToAction("Index")
    End Function

End Class