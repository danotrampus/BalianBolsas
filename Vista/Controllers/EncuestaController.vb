Imports BLL
Imports EE
Imports Newtonsoft.Json
Public Class EncuestaController
    Inherits BaseController

    Private vBLL As EncuestaBLL
    Sub New()
        Me.vBLL = New EncuestaBLL()
    End Sub

    '
    ' GET: /Novedad
    <Autorizar(Roles:="ListarEncuestas")>
    Function Index() As ActionResult
        Dim vLista As List(Of Encuesta) = Me.vBLL.Listar()
        Return View(vLista)
    End Function

    <Autorizar(Roles:="CrearEncuesta")>
    Function Crear() As ActionResult
        Return View(New Encuesta())
    End Function

    <Autorizar(Roles:="CrearEncuesta")>
    <HttpPost()>
    Function Crear(ByVal e As Encuesta) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Crear(e)
            Return RedirectToAction("Index")
        End If

        Return View(e)
    End Function

    <Autorizar(Roles:="ConsultarEncuesta")>
    Function Detalle(ByVal id As Integer) As ActionResult
        Dim vEncuesta As Encuesta = Me.vBLL.ConsultarPorId(id)
        Dim listaSelecciones As New List(Of FloatChartSerializableModel)
        For Each Opcion As Opcion In vEncuesta.ListaOpciones
            Dim model As New FloatChartSerializableModel
            model.label = Opcion.Valor
            model.data = Opcion.Selecciones
            listaSelecciones.Add(model)
        Next
        ViewBag.ListaSelecciones = JsonConvert.SerializeObject(listaSelecciones)
        Return View(vEncuesta)
    End Function

    <Autorizar(Roles:="EliminarEncuesta")>
    Function Eliminar(ByVal id As Integer) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Eliminar(id)
        End If
        Return RedirectToAction("Index")
    End Function

    <Autorizar(Roles:="EditarEncuesta")>
    Function Editar(ByVal id As Integer) As ActionResult
        Dim vEncuesta As EE.Encuesta = Me.vBLL.ConsultarPorId(id)
        Return View(vEncuesta)
    End Function

    <Autorizar(Roles:="EditarEncuesta")>
    <HttpPost()> _
    Function Editar(ByVal id As Integer, ByVal e As Encuesta) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Editar(e)
            Return RedirectToAction("Index")
        End If
        Return View(e)
    End Function

    Public Function Responder(ByVal tipo As String) As PartialViewResult
        Dim vEncuesta As Encuesta = Me.vBLL.ConsultarRandomPorTipo(tipo)
        Return PartialView(vEncuesta)
    End Function

    <HttpPost()>
    Function Responder(ByVal e As Encuesta) As PartialViewResult
        If e.Respuesta <> 0 And e.Respuesta IsNot Nothing Then
            Me.vBLL.Responder(e.Respuesta)
        End If
        ModelState.Clear()
        Return PartialView(Me.vBLL.ConsultarRandomPorTipo(e.Tipo))
    End Function

End Class