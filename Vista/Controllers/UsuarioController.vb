Imports BLL
Imports EE

Public Class UsuarioController
    Inherits BaseController

    Private vBLL As UsuarioBLL
    Sub New()
        Me.vBLL = New UsuarioBLL()
    End Sub

    '
    ' GET: /Usuario
    <Autorizar(Roles:="ListarUsuarios")>
    Function Index() As ActionResult
        Dim vLista As List(Of Usuario) = Me.vBLL.Listar()
        Return View(vLista)
    End Function

    '
    ' GET: /Usuario/Details/5
    <Autorizar(Roles:="ConsultarUsuario")>
    Function Details(ByVal id As Integer) As ActionResult
        Dim vUsuario As Usuario = Me.vBLL.ConsultarPorId(id)
        Return View(vUsuario)
    End Function

    '
    ' GET: /Usuario/Create
    <Autorizar(Roles:="AltaUsuario")>
    Function Create() As ActionResult
        Dim u As New Usuario()
        Dim PerfilBll As New BLL.PerfilBLL()
        ViewBag.Perfiles = PerfilBll.Listar()
        Return View(u)
    End Function

    ' POST: /Usuario/Create
    <Autorizar(Roles:="AltaUsuario")>
    <HttpPost()> _
    Function Create(ByVal u As Usuario) As ActionResult
        If ModelState.IsValid Then
            If Me.vBLL.VerificarExistenciaPorEmail(u.Email) = False Then
                If Me.vBLL.VerificarExistenciaPorNombreUsuario(u.NombreUsuario) = False Then
                    Me.vBLL.Crear(u)
                    Return RedirectToAction("Index")
                Else
                    ModelState.AddModelError("NombreUsuario", "El nombre de usuario está en uso")
                End If
            Else
                ModelState.AddModelError("Email", "El mail está en uso")
            End If
        End If

        Dim PerfilBll As New BLL.PerfilBLL()
        ViewBag.Perfiles = PerfilBll.Listar()

        Return View(u)
    End Function

    '
    ' GET: /Usuario/Edit/5
    <Autorizar(Roles:="EditarUsuario")>
    Function Edit(ByVal id As Integer) As ActionResult
        Dim vUsuario As EE.Usuario = Me.vBLL.ConsultarPorId(id)
        Dim PerfilBll As New BLL.PerfilBLL()
        ViewBag.Perfiles = PerfilBll.Listar()
        Return View(vUsuario)
    End Function

    '
    ' POST: /Usuario/Edit/5
    <Autorizar(Roles:="EditarUsuario")>
    <HttpPost()> _
    Function Edit(ByVal id As Integer, ByVal u As Usuario) As ActionResult
        Dim claveModelState = ModelState("Clave")
        claveModelState.Errors.Clear()
        If ModelState.IsValid Then
            Me.vBLL.Editar(u)
            Return RedirectToAction("Index")
        End If
        Dim vPerfilBll As New PerfilBLL()
        ViewBag.Perfiles = vPerfilBll.Listar()
        Return View(u)
    End Function

    '
    ' GET: /Usuario/Delete/5
    <Autorizar(Roles:="BajaUsuario")>
    Function Delete(ByVal id As Integer) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Eliminar(id)
        Else
            TempData.Add("error", "Se ha producido un error al intentar eliminar le registro.")
        End If
        Return RedirectToAction("Index")
    End Function

    <Autorizar()>
    Function MiCuenta() As ActionResult
        Dim u As Usuario = Me.vBLL.ConsultarPorId(Me.UsuarioActual.UsuarioId)
        Return View(u)
    End Function

    Function Registrar() As ActionResult
        Return View()
    End Function

    <HttpPost()> _
    Function Registrar(ByVal model As RegistrarViewModel) As ActionResult
        If ModelState.IsValid Then
            Dim u As New Usuario()
            u.Nombre = model.Nombre
            u.Apellido = model.Apellido
            u.NombreUsuario = model.NombreUsuario
            u.Clave = model.Clave
            u.Email = model.Email
            Dim uri As String = Request.Url.Scheme.ToString() + "://" + Request.Url.Host.ToString() + ":" + Request.Url.Port.ToString() + "/"
            Me.vBLL.Registrar(u, uri)
            Return RedirectToAction("Index", "Home")
        End If

        Return View(model)
    End Function

    Function Activar(ByVal id As String) As ActionResult
        Me.vBLL.Activar(id)
        Return View()
    End Function

    Function EnviarClave(ByVal form As FormCollection) As ActionResult
        Me.vBLL.EnviarClave(form("email"))
        Return View("~/Views/Cuenta/LogIn.vbhtml")
    End Function

    <Autorizar()>
    Function CambiarClave() As ActionResult
        Return View()
    End Function

    <Autorizar()>
    <HttpPost()>
    Function CambiarClave(ByVal model As CambioClaveViewModel) As ActionResult
        If ModelState.IsValid Then
            Dim u As Usuario = Me.vBLL.ConsultarPorId(UsuarioActual.UsuarioId)
            If u IsNot Nothing Then
                If model.ClaveVieja = u.Clave Then
                    Me.vBLL.CambiarClave(u.Id, u.Clave, u.Email)
                    Return RedirectToAction("MiCuenta")
                Else
                    ModelState.AddModelError("ClaveVieja", "Contraseña anterior incorrecta")
                End If
            End If
        End If
        Return View()
    End Function

End Class