Public Class InformeTiempoRespuesta

    Private vListaDetalles As New List(Of DetalleInformeTiempoRespuesta)
    Public Property ListaDetalles() As List(Of DetalleInformeTiempoRespuesta)
        Get
            Return vListaDetalles
        End Get
        Set(ByVal value As List(Of DetalleInformeTiempoRespuesta))
            vListaDetalles = value
        End Set
    End Property

    Public ReadOnly Property Promedio As TimeSpan
        Get
            Dim valor As Double = 0
            For Each detalle As DetalleInformeTiempoRespuesta In Me.ListaDetalles
                valor += detalle.Diferencia
            Next
            valor = valor / Me.ListaDetalles.Count
            If valor > 0 Then
                Return TimeSpan.FromSeconds(Convert.ToInt32(valor / Me.ListaDetalles.Count))
            Else
                Return TimeSpan.FromSeconds(0)
            End If
        End Get
    End Property

End Class
