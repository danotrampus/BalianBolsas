Public Class Idioma

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

    Private vLocale As String
    Public Property Locale() As String
        Get
            Return vLocale
        End Get
        Set(ByVal value As String)
            vLocale = value
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
