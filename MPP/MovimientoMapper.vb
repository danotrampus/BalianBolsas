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

    Public Function Consultar(ByVal tipo As String, ByVal numero As Integer, ByVal tipoComprobante As String) As Movimiento
        Dim parametros As New Hashtable
        Dim ds As New DataSet

        parametros.Add("@Tipo", tipo)
        parametros.Add("@Numero", numero)
        parametros.Add("@TipoComprobante", tipoComprobante)
        ds = vDatos.Leer("SP_Movimiento_Consultar", parametros)

        If ds.Tables(0).Rows.Count > 0 Then
            Dim row As DataRow = ds.Tables(0).Rows(0)
            Dim m As Movimiento = Nothing
            Select Case row("Tipo")
                Case "Factura"
                    m = New Factura

                    If IsDBNull(row.Item("Cuit")) = False Then
                        DirectCast(m, Factura).Cuit = row.Item("Cuit")
                    End If
                    DirectCast(m, Factura).Direccion.Calle = row.Item("Direccion_Calle")
                    DirectCast(m, Factura).Direccion.Numero = row.Item("Direccion_Numero")
                    If IsDBNull(row.Item("Direccion_DptoPiso")) = False Then
                        DirectCast(m, Factura).Direccion.DptoPiso = row.Item("Direccion_DptoPiso")
                    End If
                    DirectCast(m, Factura).Direccion.Localidad = row.Item("Direccion_Localidad")
                Case "NotaCredito"
                    m = New NotaCredito

                    DirectCast(m, NotaCredito).Direccion.Calle = row.Item("Direccion_Calle")
                    DirectCast(m, NotaCredito).Direccion.Numero = row.Item("Direccion_Numero")
                    If IsDBNull(row.Item("Direccion_DptoPiso")) = False Then
                        DirectCast(m, NotaCredito).Direccion.DptoPiso = row.Item("Direccion_DptoPiso")
                    End If
                    DirectCast(m, NotaCredito).Direccion.Localidad = row.Item("Direccion_Localidad")
                Case "NotaDebito"
                    m = New NotaDebito
                Case "Pago"
                    m = New Pago
            End Select

            m.Fecha = row("Fecha")
            m.Numero = row("Numero")
            m.TipoComprobante = row("TipoComprobante")
            If IsDBNull(row("Observacion")) = False Then
                m.Observacion = row("Observacion")
            End If
            m.Importe = row("Importe")

            Dim lista As New List(Of DetalleMovimiento)
            If ds.Tables(1).Rows.Count > 0 Then
                For Each row2 As DataRow In ds.Tables(1).Rows
                    Dim dm As New DetalleMovimiento
                    dm.Cantidad = row2.Item("Cantidad")
                    dm.Precio = row2.Item("Precio")

                    Dim entidad As Producto = Nothing
                    If row2.Item("Tipo") = "Bolsa" Then
                        entidad = New Bolsa
                    End If
                    If row2.Item("Tipo") = "Bobina" Then
                        entidad = New Bobina
                    End If
                    entidad.Id = row2.Item("Id")
                    entidad.Ancho = row2.Item("Ancho")
                    entidad.Largo = row2.Item("Largo")
                    entidad.Espesor = row2.Item("Espesor")
                    entidad.Formato = row2.Item("Formato")
                    entidad.Soldadura = row2.Item("Soldadura")
                    entidad.Imagen = row2.Item("Imagen")
                    entidad.Polimero.Id = row2.Item("PolimeroId")
                    entidad.Polimero.Nombre = row2.Item("PolimeroNombre")
                    entidad.Polimero.Densidad = row2.Item("PolimeroDensidad")
                    entidad.Polimero.Precio = row2.Item("PolimeroPrecio")
                    Dim colorPolimero As New Color
                    colorPolimero.Id = row2.Item("PolimeroColorId")
                    colorPolimero.Nombre = row2.Item("PolimeroColorNombre")
                    colorPolimero.Codigo = row2.Item("PolimeroColorCodigo")
                    entidad.Polimero.Color = colorPolimero
                    If IsDBNull(row2.Item("ImpresionId")) = False Then
                        Dim imp As New Impresion
                        imp.Id = row2.Item("ImpresionId")
                        imp.Tratado = row2.Item("ImpresionTratado")
                        imp.CantidadColores = row2.Item("ImpresionCantidadColores")
                        imp.Precio = row2.Item("ImpresionPrecio")

                        entidad.Impresion = imp
                    End If
                    If IsDBNull(row2.Item("ManijaId")) = False Then
                        Dim man As New Manija
                        man.Id = row2.Item("ManijaId")
                        man.Nombre = row2.Item("ManijaNombre")
                        man.Precio = row2.Item("ManijaPrecio")
                        Dim colorManija As New Color
                        colorManija.Id = row2.Item("ManijaColorId")
                        colorManija.Nombre = row2.Item("ManijaColorNombre")
                        colorManija.Codigo = row2.Item("ManijaColorCodigo")
                        man.Color = colorManija
                    End If
                    dm.Producto = entidad

                    lista.Add(dm)
                Next
                m.ListaDetalles = lista
            End If
            Return m
        Else
            Return Nothing
        End If
    End Function

    Public Function Listar() As List(Of Movimiento)
        Dim ds As New DataSet
        Dim lista As New List(Of Movimiento)
        ds = vDatos.Leer("SP_Movimiento_Listar", Nothing)

        If ds.Tables(0).Rows.Count > 0 Then
            For Each Item As DataRow In ds.Tables(0).Rows
                Dim m As Movimiento = Nothing
                Select Case Item("Tipo")
                    Case "Factura"
                        m = New Factura
                    Case "NotaCredito"
                        m = New NotaCredito
                    Case "NotaDebito"
                        m = New NotaDebito
                    Case "Pago"
                        m = New Pago
                End Select
                m.Numero = Item("Numero")
                m.TipoComprobante = Item("TipoComprobante")
                If IsDBNull(Item("Observacion")) = False Then
                    m.Observacion = Item("Observacion")
                End If
                m.Importe = Item("Importe")
                m.Usuario.NombreUsuario = Item("Nombre_Usuario")
                m.Fecha = Item("Fecha")
                lista.Add(m)
            Next
        End If

        Return lista
    End Function

End Class
