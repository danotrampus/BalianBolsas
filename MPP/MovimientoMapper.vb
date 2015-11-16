Imports DAL
Imports EE
Public Class MovimientoMapper

    Private vDatos As Datos

    Sub New()
        Me.vDatos = New Datos
    End Sub

    Public Function Crear(ByVal entidad As Movimiento) As Boolean
        Dim parametros As New Hashtable

        If entidad.GetType() = GetType(Factura) Then
            Dim fc As Factura = DirectCast(entidad, Factura)
            parametros.Add("@Tipo", "Factura")
            parametros.Add("@Direccion_Calle", fc.Direccion.Calle)
            parametros.Add("@Direccion_Numero", fc.Direccion.Numero)
            parametros.Add("@Direccion_Dpto_Piso", fc.Direccion.DptoPiso)
            parametros.Add("@Direccion_Localidad", fc.Direccion.Localidad)
            If entidad.TipoComprobante = "A" Then
                parametros.Add("@Cuit", fc.Cuit)
            End If
        End If
        If entidad.GetType() = GetType(NotaCredito) Then
            Dim nc As NotaCredito = DirectCast(entidad, NotaCredito)
            parametros.Add("@Tipo", "NotaCredito")
            'parametros.Add("@Direccion_Calle", nc.Direccion.Calle)
            'parametros.Add("@Direccion_Numero", nc.Direccion.Numero)
            'parametros.Add("@Direccion_Dpto_Piso", nc.Direccion.DptoPiso)
            'parametros.Add("@Direccion_Localidad", nc.Direccion.Localidad)
        End If
        If entidad.GetType() = GetType(NotaDebito) Then
            Dim nd As NotaDebito = DirectCast(entidad, NotaDebito)
            parametros.Add("@Tipo", "NotaDebito")
            'parametros.Add("@Direccion_Calle", nd.Direccion.Calle)
            'parametros.Add("@Direccion_Numero", nd.Direccion.Numero)
            'parametros.Add("@Direccion_Dpto_Piso", nd.Direccion.DptoPiso)
            'parametros.Add("@Direccion_Localidad", nd.Direccion.Localidad)
        End If
        If entidad.GetType() = GetType(Pago) Then
            parametros.Add("@Tipo", "Pago")
        End If
        parametros.Add("@TipoComprobante", entidad.TipoComprobante)
        parametros.Add("@Observacion", entidad.Observacion)
        parametros.Add("@Importe", entidad.Importe)
        parametros.Add("@Usuario_Id", entidad.Usuario.Id)
        parametros.Add("@Fecha", entidad.Fecha)

        Dim dt As New DataTable()
        dt.Columns.Add("Producto_Id", System.Type.GetType("System.Int32"))
        dt.Columns.Add("Precio", System.Type.GetType("System.Decimal"))
        dt.Columns.Add("Cantidad", System.Type.GetType("System.Int32"))
        For Each dp As DetalleMovimiento In entidad.ListaDetalles
            Dim dr As DataRow = dt.NewRow
            dr.Item("Producto_Id") = dp.Producto.Id
            dr.Item("Precio") = dp.Precio
            dr.Item("Cantidad") = dp.Cantidad
            dt.Rows.Add(dr)
        Next
        parametros.Add("@Detalles", dt)

        Return vDatos.Escribir("SP_Movimiento_Crear", parametros)
    End Function

    Public Function SaldoAFavorPorCliente(ByVal clienteId As Integer) As Double
        Dim parametros As New Hashtable
        Dim ds As New DataSet

        parametros.Add("@Cliente_Id", clienteId)
        ds = vDatos.Leer("SP_Movimiento_SaldoAFavorPorCliente", parametros)

        If ds.Tables(0).Rows.Count > 0 Then
            Dim row As DataRow = ds.Tables(0).Rows(0)
            Return row.Item("Saldo")
        Else
            Return Nothing
        End If
    End Function

    Public Function Compensar(ByVal clienteId As Integer, ByVal importe As Double) As Boolean
        Dim parametros As New Hashtable
        parametros.Add("@Cliente_Id", clienteId)
        parametros.Add("@Importe", importe)
        Return vDatos.Escribir("SP_Movimiento_Compensar", parametros)
    End Function

End Class
