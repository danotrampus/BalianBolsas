Public Class Familia
    Inherits Permiso

    Sub New()

    End Sub

    Sub New(ByVal id As Integer, ByVal nombre As String, ByVal descripcion As String, ByVal url As String, ByVal habilitado As Boolean, ByVal Css As String, ByVal Activo As Boolean)
        Me.Id = id
        Me.Nombre = nombre
        Me.Descripcion = descripcion
        Me.Url = url
        Me.Habilitado = habilitado
        Me.Css = Css
        Me.Activo = Activo
    End Sub

    Private vListaPermisos As New List(Of Permiso)

    Public Sub AgregarPermiso(ByVal permiso As Permiso)
        Me.vListaPermisos.Add(permiso)
    End Sub

    Public Sub EliminarPermiso(ByVal permiso As Permiso)
        Me.vListaPermisos.Remove(permiso)
    End Sub

    Public Function ObtenerPermisos() As List(Of Permiso)
        Return Me.vListaPermisos
    End Function

    Public Property ListaPermisos() As List(Of Permiso)
        Get
            Return vListaPermisos
        End Get
        Set(ByVal value As List(Of Permiso))
            vListaPermisos = value
        End Set
    End Property

End Class
