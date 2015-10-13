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
        Return View(Me.vBll.Listar())
    End Function

End Class