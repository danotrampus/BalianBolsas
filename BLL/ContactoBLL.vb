Imports MPP
Imports EE
Public Class ContactoBLL

    Private vMapper As ContactoMapper

    Sub New()
        Me.vMapper = New ContactoMapper
    End Sub

    Public Function Crear(ByVal c As Contacto) As Boolean
        c.FechaHora = Now
        Return vMapper.Crear(c)
    End Function

    Public Function Listar() As List(Of Contacto)
        Return vMapper.Listar()
    End Function

End Class
