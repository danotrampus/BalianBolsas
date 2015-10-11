Public Class IdiomaEditarViewModel

    Private vIdiomasId As New List(Of Integer)
    Public Property IdiomasId() As List(Of Integer)
        Get
            Return vIdiomasId
        End Get
        Set(ByVal value As List(Of Integer))
            vIdiomasId = value
        End Set
    End Property


End Class
