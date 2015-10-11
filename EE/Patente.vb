Public Class Patente
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

End Class
