Imports EE
Imports BLL

Public Class ResguardoController
    Inherits BaseController

    Private vBll As ResguardoBLL
    Sub New()
        Me.vBll = New ResguardoBLL()
    End Sub

    <Autorizar(Roles:="ListarResguardos")>
    Function Index() As ActionResult
        Return View(Me.vBll.Listar())
    End Function

    <Autorizar(Roles:="AltaResguardo")>
    <HttpPost()>
    Function Crear() As ActionResult
        Dim r As New Resguardo()
        r.Tipo = "Resguardo"
        r.FechaHora = Now
        r.RutaNombre = Server.MapPath("~/Resguardos") + "\Resguardo (" + r.FechaHora.ToString("dd-MM-yyyy HH.mm.ss") + ").bak"
        r.Usuario = New Usuario()
        r.Usuario.Id = Me.UsuarioActual.UsuarioId
        Me.vBll.Crear(r)
        Return RedirectToAction("Index")
    End Function

    <Autorizar(Roles:="BajaResguardo")>
    <HttpPost()>
    Function Eliminar(ByVal id As Integer) As ActionResult
        If ModelState.IsValid Then
            If (System.IO.File.Exists(Request("rutaNombre").ToString())) Then
                System.IO.File.Delete(Request("rutaNombre").ToString())
            End If
            Me.vBll.Eliminar(Request("id"))
        End If
        Return RedirectToAction("Index")
    End Function

    <Autorizar(Roles:="RestaurarResguardo")>
    <HttpPost()>
    Function Restaurar(ByVal id As Integer) As ActionResult
        If ModelState.IsValid Then
            Dim rutaNombre As String = Request("rutaNombre").ToString()
            If (System.IO.File.Exists(rutaNombre)) Then
                Dim r As New Resguardo()
                r.Tipo = "Restauración"
                r.FechaHora = Now
                r.RutaNombre = rutaNombre
                r.Usuario = New Usuario()
                r.Usuario.Id = Me.UsuarioActual.UsuarioId
                Me.vBll.Restaurar(r)
            End If
        End If
        Return RedirectToAction("Index")
    End Function

End Class