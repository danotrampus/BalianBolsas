Imports BLL
Imports EE
Imports Newtonsoft.Json

Public Class PerfilController
    Inherits BaseController

    Private vBLL As PerfilBLL
    Sub New()
        Me.vBLL = New PerfilBLL()
    End Sub

    '
    ' GET: /Perfil

    <Autorizar(Roles:="ListarPerfiles")>
    Function Index() As ActionResult
        Dim vLista As List(Of Perfil) = Me.vBLL.Listar()
        Return View(vLista)
    End Function

    '
    ' GET: /Perfil/Details/5
    <Autorizar(Roles:="ConsultarPerfil")>
    Function Detalle(ByVal id As Integer) As ActionResult
        Dim vPerfil As Perfil = Me.vBLL.ConsultarPorId(id)
        Dim json As String = JsonConvert.SerializeObject(vPerfil.ListaPermisos)
        ViewBag.ListaPermisos = json
        Return View(vPerfil)
    End Function

    '
    ' GET: /Perfil/Create
    <Autorizar(Roles:="CrearPerfil")>
    Function Crear() As ActionResult
        Dim json As String = JsonConvert.SerializeObject(Me.vBLL.ConsultarPermisos())
        ViewBag.ListaPermisos = json
        Return View()
    End Function

    '
    ' POST: /Perfil/Create
    <Autorizar(Roles:="CrearPerfil")>
    <HttpPost()> _
    Function Crear(ByVal p As Perfil) As ActionResult
        p.ListaPermisos = JsonConvert.DeserializeObject(Of List(Of Permiso))(Request("ListaPermisos"), New PermisoConverter())
        Dim claveModelState = ModelState("ListaPermisos")
        claveModelState.Errors.Clear()
        If ModelState.IsValid Then
            If Me.vBLL.VerificarExistenciaPerfil(p.Nombre) = False Then
                Me.vBLL.Crear(p)
                Return RedirectToAction("Index")
            Else
                ModelState.AddModelError("Nombre", "El nombre del perfil ya existe")
            End If

        End If
        ViewBag.ListaPermisos = Request("ListaPermisos")
        Return View()
    End Function

    '
    ' GET: /Perfil/Edit/5
    <Autorizar(Roles:="EditarPerfil")>
    Function Editar(ByVal id As Integer) As ActionResult
        Dim vPerfil As EE.Perfil = Me.vBLL.ConsultarPorId(id)
        Dim json As String = JsonConvert.SerializeObject(Me.vBLL.ConsultarPermisos(vPerfil.Id))
        ViewBag.ListaPermisos = json
        Return View(vPerfil)
    End Function

    '
    ' POST: /Perfil/Edit/5
    <Autorizar(Roles:="EditarPerfil")>
    <HttpPost()> _
    Function Editar(ByVal id As Integer, ByVal p As Perfil) As ActionResult
        p.ListaPermisos = JsonConvert.DeserializeObject(Of List(Of Permiso))(Request("ListaPermisos"), New PermisoConverter())
        Dim listaPermisosModelState = ModelState("ListaPermisos")
        listaPermisosModelState.Errors.Clear()
        If ModelState.IsValid Then
            Me.vBLL.Editar(p)
            Return RedirectToAction("Index")
        End If
        ViewBag.ListaPermisos = Request("ListaPermisos")
        Return View(p)
    End Function

    '
    ' GET: /Perfil/Delete/5
    <Autorizar(Roles:="EiminarPerfil")>
    Function Eliminar(ByVal id As Integer) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Eliminar(id)
        Else
            TempData.Add("error", "Se ha producido un error al intentar eliminar le registro.")
        End If
        Return RedirectToAction("Index")
    End Function

End Class