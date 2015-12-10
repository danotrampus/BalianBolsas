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

    Function ObtenerGanancias(ByVal desde As Date, ByVal hasta As Date) As List(Of InformeGanancias)
        Dim parametros As New Hashtable
        Dim ds As New DataSet
        Dim lista As New List(Of InformeGanancias)
        parametros.Add("@Desde", desde)
        parametros.Add("@Hasta", hasta)
        ds = vDatos.Leer("SP_Informe_ObtenerGanancias", parametros)
        If ds.Tables(0).Rows.Count > 0 Then
            For Each Item As DataRow In ds.Tables(0).Rows
                Dim g As New InformeGanancias()
                g.x = Item("x")
                g.y = Item("y")
                lista.Add(g)
            Next
        End If
        Return lista
    End Function
End Class
