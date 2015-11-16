Imports EE
Imports BLL

Public Class ClienteController
    Inherits BaseController

    Private vBLL As UsuarioBLL
    Sub New()
        Me.vBLL = New UsuarioBLL()
    End Sub

    '
    ' GET: /Cliente
    <Autorizar(Roles:="ListarClientes")>
    Function Index() As ActionResult
        Dim vLista As List(Of Usuario) = Me.vBLL.ListarClientes()
        Return View(vLista)
    End Function

    <Autorizar(Roles:="ConsultarCliente")>
    Function Detalle(ByVal id As Integer) As ActionResult
        Dim vCliente As Usuario = Me.vBLL.ConsultarPorId(id)
        Return View(vCliente)
    End Function

End Class