Public Class Opcion

    Private vId As Integer
    Public Property Id() As Integer
        Get
            Return vId
        End Get
        Set(ByVal value As Integer)
            vId = value
        End Set
    End Property

    Private vValor As String
    Public Property Valor() As String
        Get
            Return vValor
        End Get
        Set(ByVal value As String)
            vValor = value
        End Set
    End Property

End Class
