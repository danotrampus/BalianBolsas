Imports EE
Imports DAL
Public Class InformeMapper

    Private vDatos As Datos

    Sub New()
        Me.vDatos = New Datos
    End Sub
    Public Function ListarInformeTiempoRespuesta() As InformeTiempoRespuesta
        Dim ds As New DataSet
        Dim i As New InformeTiempoRespuesta
        Dim lista As New List(Of DetalleInformeTiempoRespuesta)
        ds = vDatos.Leer("SP_Informe_ListarTiempoRespuesta", Nothing)

        If ds.Tables(0).Rows.Count > 0 Then
            For Each Item As DataRow In ds.Tables(0).Rows
                Dim d As DetalleInformeTiempoRespuesta = New DetalleInformeTiempoRespuesta
                d.NOrden = Item("Id")
                d.FechaInicio = Item("FechaInicio")
                d.FechaFin = Item("FechaFin")
                lista.Add(d)
            Next
        End If
        i.ListaDetalles = lista
        Return i
    End Function

End Class
