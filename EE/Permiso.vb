Public MustInherit Class Permiso

    Private vId As Integer
    Public Property Id() As Integer
        Get
            Return vId
        End Get
        Set(ByVal value As Integer)
            vId = value
        End Set
    End Property

    Private vNombre As String
    Public Property Nombre() As String
        Get
            Return vNombre
        End Get
        Set(ByVal value As String)
            vNombre = value
        End Set
    End Property

    Private vDescripcion As String
    Public Property Descripcion() As String
        Get
            Return vDescripcion
        End Get
        Set(ByVal value As String)
            vDescripcion = value
        End Set
    End Property

    Private vUrl As String
    Public Property Url() As String
        Get
            Return vUrl
        End Get
        Set(ByVal value As String)
            vUrl = value
        End Set
    End Property

    Private vHabilitado As Boolean
    Public Property Habilitado() As Boolean
        Get
            Return vHabilitado
        End Get
        Set(ByVal value As Boolean)
            vHabilitado = value
        End Set
    End Property

    Private vCss As String
    Public Property Css() As String
        Get
            Return vCss
        End Get
        Set(ByVal value As String)
            vCss = value
        End Set
    End Property

    Private vActivo As Boolean
    Public Property Activo() As Boolean
        Get
            Return vActivo
        End Get
        Set(ByVal value As Boolean)
            vActivo = value
        End Set
    End Property

End Class
