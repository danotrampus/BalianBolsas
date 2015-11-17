Imports DAL
Imports EE
Public Class PedidoMapper

    Private vDatos As Datos

    Sub New()
        Me.vDatos = New Datos
    End Sub

    Public Function Crear(ByVal entidad As Pedido) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Estado", entidad.Estado)
        parametros.Add("@Fecha_Inicio", entidad.FechaInicio)
        parametros.Add("@Importe", entidad.Importe)
        parametros.Add("@Usuario_Id", entidad.Usuario.Id)
        parametros.Add("@Direccion_Calle", entidad.Direccion.Calle)
        parametros.Add("@Direccion_Numero", entidad.Direccion.Numero)
        parametros.Add("@Direccion_Dpto_Piso", entidad.Direccion.DptoPiso)
        parametros.Add("@Direccion_Localidad", entidad.Direccion.Localidad)

        Dim dt As New DataTable()
        dt.Columns.Add("Producto_Id", System.Type.GetType("System.Int32"))
        dt.Columns.Add("Precio", System.Type.GetType("System.Decimal"))
        dt.Columns.Add("Cantidad", System.Type.GetType("System.Int32"))
        For Each dp As DetallePedido In entidad.ListaDetalles
            Dim dr As DataRow = dt.NewRow
            dr.Item("Producto_Id") = dp.Producto.Id
            dr.Item("Precio") = dp.Precio
            dr.Item("Cantidad") = dp.Cantidad
            dt.Rows.Add(dr)
        Next
        parametros.Add("@Detalles", dt)

        Return vDatos.Escribir("SP_Pedido_Crear", parametros)
    End Function

    Public Function Listar() As List(Of Pedido)
        Dim ds As New DataSet
        Dim lista As New List(Of Pedido)
        ds = vDatos.Leer("SP_Pedido_Listar", Nothing)

        If ds.Tables(0).Rows.Count > 0 Then
            For Each Item As DataRow In ds.Tables(0).Rows
                Dim p As Pedido = New Pedido
                p.Id = Item("Id")
                p.FechaInicio = Item("FechaInicio")
                If IsDBNull(Item("FechaFin")) = False Then
                    p.FechaFin = Item("FechaFin")
                End If
                p.Importe = Item("Importe")
                p.Estado = Item("Estado")
                p.Usuario.NombreUsuario = Item("Nombre_Usuario")
                lista.Add(p)
            Next
        End If

        Return lista
    End Function

    Public Function ConsutarPorId(ByVal id As Integer) As Pedido
        Dim parametros As New Hashtable
        Dim ds As New DataSet

        parametros.Add("@Id", id)
        ds = vDatos.Leer("SP_Pedido_ConsultarPorId", parametros)

        If ds.Tables(0).Rows.Count > 0 Then
            Dim row As DataRow = ds.Tables(0).Rows(0)
            Dim p As New Pedido
            p.Id = row.Item("Id")
            p.FechaInicio = row.Item("FechaInicio")
            If IsDBNull(row.Item("FechaFin")) = False Then
                p.FechaFin = row.Item("FechaFin")
            End If
            p.Importe = row.Item("Importe")
            p.Estado = row.Item("Estado")
            p.Direccion.Calle = row.Item("Calle")
            p.Direccion.Numero = row.Item("Numero")
            If IsDBNull(row.Item("Dpto_Piso")) = False Then
                p.Direccion.DptoPiso = row.Item("Dpto_Piso")
            End If
            p.Direccion.Localidad = row.Item("Localidad")
            p.Usuario.Id = row.Item("Usuario_Id")
            p.Usuario.Nombre = row.Item("Nombre")
            p.Usuario.Apellido = row.Item("Apellido")
            p.Usuario.NombreUsuario = row.Item("Nombre_Usuario")
            If IsDBNull(row.Item("Telefono")) = False Then
                p.Usuario.Telefono = row.Item("Telefono")
            End If
            Dim lista As New List(Of DetallePedido)
            If ds.Tables(1).Rows.Count > 0 Then
                For Each row2 As DataRow In ds.Tables(1).Rows
                    Dim dp As New DetallePedido
                    dp.Cantidad = row2.Item("Cantidad")
                    dp.Precio = row2.Item("Precio")

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
                        Dim m As New Manija
                        m.Id = row2.Item("ManijaId")
                        m.Nombre = row2.Item("ManijaNombre")
                        m.Precio = row2.Item("ManijaPrecio")
                        Dim colorManija As New Color
                        colorManija.Id = row2.Item("ManijaColorId")
                        colorManija.Nombre = row2.Item("ManijaColorNombre")
                        colorManija.Codigo = row2.Item("ManijaColorCodigo")
                        m.Color = colorManija
                    End If
                    dp.Producto = entidad

                    lista.Add(dp)
                Next
                p.ListaDetalles = lista
            End If
            Return p
        Else
            Return Nothing
        End If
    End Function

    Public Function Anular(ByVal id As Integer) As Boolean
        Dim parametros As New Hashtable
        parametros.Add("@Id", id)
        Return vDatos.Escribir("SP_Pedido_Anular", parametros)
    End Function

End Class
