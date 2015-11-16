Imports DAL
Imports EE
Public Class ProductoMapper

    Private vDatos As Datos

    Sub New()
        Me.vDatos = New Datos
    End Sub

    Public Function Crear(ByVal entidad As Producto) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Ancho", entidad.Ancho)
        If entidad.GetType() = GetType(Bolsa) Then
            Dim bolsa As Bolsa = DirectCast(entidad, EE.Bolsa)
            parametros.Add("@Tipo", "Bolsa")
            parametros.Add("@Largo", bolsa.Largo)
            If bolsa.Manija IsNot Nothing Then
                If bolsa.Manija.Id <> 0 Then
                    parametros.Add("@Manija_Id", bolsa.Manija.Id)
                End If
            End If
        End If
        If entidad.GetType() = GetType(Bobina) Then
            parametros.Add("@Tipo", "Bobina")
        End If
        parametros.Add("@Espesor", entidad.Espesor)
        parametros.Add("@Formato", entidad.Formato)
        parametros.Add("@Imagen", entidad.Imagen)
        parametros.Add("@Soldadura", entidad.Soldadura)
        parametros.Add("@Polimero_Id", entidad.Polimero.Id)
        If entidad.Impresion IsNot Nothing Then
            If entidad.Impresion.Id <> 0 Then
                parametros.Add("@Impresion_Id", entidad.Impresion.Id)
            End If
        End If

        Return vDatos.Escribir("SP_Producto_Crear", parametros)
    End Function

    Public Function Editar(ByVal entidad As Producto) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Id", entidad.Id)
        parametros.Add("@Ancho", entidad.Ancho)
        If entidad.GetType() = GetType(Bolsa) Then
            Dim bolsa As Bolsa = DirectCast(entidad, EE.Bolsa)
            parametros.Add("@Tipo", "Bolsa")
            parametros.Add("@Largo", bolsa.Largo)
            If bolsa.Manija IsNot Nothing Then
                If bolsa.Manija.Id <> 0 Then
                    parametros.Add("@Manija_Id", bolsa.Manija.Id)
                End If
            End If
        End If
        If entidad.GetType() = GetType(Bobina) Then
            parametros.Add("@Tipo", "Bobina")
        End If
        parametros.Add("@Espesor", entidad.Espesor)
        parametros.Add("@Formato", entidad.Formato)
        parametros.Add("@Imagen", entidad.Imagen)
        parametros.Add("@Soldadura", entidad.Soldadura)
        parametros.Add("@Polimero_Id", entidad.Polimero.Id)
        If entidad.Impresion IsNot Nothing Then
            If entidad.Impresion.Id <> 0 Then
                parametros.Add("@Impresion_Id", entidad.Impresion.Id)
            End If
        End If

        Return vDatos.Escribir("SP_Producto_Editar", parametros)
    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Id", id)

        Return vDatos.Escribir("SP_Producto_Eliminar", parametros)
    End Function

    Public Function Listar() As List(Of Producto)
        Dim ds As New DataSet
        Dim lista As New List(Of Producto)
        ds = vDatos.Leer("SP_Producto_Listar", Nothing)

        If ds.Tables(0).Rows.Count > 0 Then
            For Each Item As DataRow In ds.Tables(0).Rows
                Dim entidad As Producto = Nothing
                If Item("Tipo") = "Bolsa" Then
                    entidad = New Bolsa
                End If
                If Item("Tipo") = "Bobina" Then
                    entidad = New Bobina
                End If
                entidad.Id = Item("Id")
                entidad.Ancho = Item("Ancho")
                entidad.Largo = Item("Largo")
                entidad.Espesor = Item("Espesor")
                entidad.Formato = Item("Formato")
                entidad.Soldadura = Item("Soldadura")
                entidad.Imagen = Item("Imagen")
                entidad.Valoracion = Item("Valoracion")
                entidad.Polimero.Id = Item("PolimeroId")
                entidad.Polimero.Nombre = Item("PolimeroNombre")
                entidad.Polimero.Densidad = Item("PolimeroDensidad")
                entidad.Polimero.Precio = Item("PolimeroPrecio")
                Dim colorPolimero As New Color
                colorPolimero.Id = Item("PolimeroColorId")
                colorPolimero.Nombre = Item("PolimeroColorNombre")
                colorPolimero.Codigo = Item("PolimeroColorCodigo")
                entidad.Polimero.Color = colorPolimero
                If IsDBNull(Item("ImpresionId")) = False Then
                    Dim imp As New Impresion
                    imp.Id = Item("ImpresionId")
                    imp.Tratado = Item("ImpresionTratado")
                    imp.CantidadColores = Item("ImpresionCantidadColores")
                    imp.Precio = Item("ImpresionPrecio")

                    entidad.Impresion = imp
                End If
                If IsDBNull(Item("ManijaId")) = False Then
                    Dim m As New Manija
                    m.Id = Item("ManijaId")
                    m.Nombre = Item("ManijaNombre")
                    m.Precio = Item("ManijaPrecio")
                    Dim colorManija As New Color
                    colorManija.Id = Item("ManijaColorId")
                    colorManija.Nombre = Item("ManijaColorNombre")
                    colorManija.Codigo = Item("ManijaColorCodigo")
                    m.Color = colorManija

                    DirectCast(entidad, EE.Bolsa).Manija = m
                End If
                lista.Add(entidad)
            Next
        End If

        Return lista
    End Function

    Public Function ListarBolsas() As List(Of Bolsa)
        Dim ds As New DataSet
        Dim lista As New List(Of Bolsa)
        ds = vDatos.Leer("SP_Producto_Listar", Nothing)

        If ds.Tables(0).Rows.Count > 0 Then
            For Each Item As DataRow In ds.Tables(0).Rows
                If Item("Tipo") = "Bolsa" Then
                    Dim entidad As New Bolsa
                    entidad.Id = Item("Id")
                    entidad.Ancho = Item("Ancho")
                    entidad.Largo = Item("Largo")
                    entidad.Espesor = Item("Espesor")
                    entidad.Formato = Item("Formato")
                    entidad.Soldadura = Item("Soldadura")
                    entidad.Imagen = Item("Imagen")
                    entidad.Valoracion = Item("Valoracion")
                    entidad.Polimero.Id = Item("PolimeroId")
                    entidad.Polimero.Nombre = Item("PolimeroNombre")
                    entidad.Polimero.Densidad = Item("PolimeroDensidad")
                    entidad.Polimero.Precio = Item("PolimeroPrecio")
                    Dim colorPolimero As New Color
                    colorPolimero.Id = Item("PolimeroColorId")
                    colorPolimero.Nombre = Item("PolimeroColorNombre")
                    colorPolimero.Codigo = Item("PolimeroColorCodigo")
                    entidad.Polimero.Color = colorPolimero
                    If IsDBNull(Item("ImpresionId")) = False Then
                        Dim imp As New Impresion
                        imp.Id = Item("ImpresionId")
                        imp.Tratado = Item("ImpresionTratado")
                        imp.CantidadColores = Item("ImpresionCantidadColores")
                        imp.Precio = Item("ImpresionPrecio")

                        entidad.Impresion = imp
                    End If
                    If IsDBNull(Item("ManijaId")) = False Then
                        Dim m As New Manija
                        m.Id = Item("ManijaId")
                        m.Nombre = Item("ManijaNombre")
                        m.Precio = Item("ManijaPrecio")
                        Dim colorManija As New Color
                        colorManija.Id = Item("ManijaColorId")
                        colorManija.Nombre = Item("ManijaColorNombre")
                        colorManija.Codigo = Item("ManijaColorCodigo")
                        m.Color = colorManija

                        entidad.Manija = m
                    End If
                    lista.Add(entidad)
                End If
            Next
        End If

        Return lista
    End Function

    Public Function Comparar(ByVal ids As String) As List(Of Bolsa)
        Dim ds As New DataSet
        Dim lista As New List(Of Bolsa)
        Dim parametros As New Hashtable

        parametros.Add("@Ids", ids)
        ds = vDatos.Leer("SP_Producto_Comparar", parametros)

        If ds.Tables(0).Rows.Count > 0 Then
            For Each Item As DataRow In ds.Tables(0).Rows
                If Item("Tipo") = "Bolsa" Then
                    Dim entidad As New Bolsa
                    entidad.Id = Item("Id")
                    entidad.Ancho = Item("Ancho")
                    entidad.Largo = Item("Largo")
                    entidad.Espesor = Item("Espesor")
                    entidad.Formato = Item("Formato")
                    entidad.Soldadura = Item("Soldadura")
                    entidad.Imagen = Item("Imagen")
                    entidad.Valoracion = Item("Valoracion")
                    entidad.Polimero.Id = Item("PolimeroId")
                    entidad.Polimero.Nombre = Item("PolimeroNombre")
                    entidad.Polimero.Densidad = Item("PolimeroDensidad")
                    entidad.Polimero.Precio = Item("PolimeroPrecio")
                    Dim colorPolimero As New Color
                    colorPolimero.Id = Item("PolimeroColorId")
                    colorPolimero.Nombre = Item("PolimeroColorNombre")
                    colorPolimero.Codigo = Item("PolimeroColorCodigo")
                    entidad.Polimero.Color = colorPolimero
                    If IsDBNull(Item("ImpresionId")) = False Then
                        Dim imp As New Impresion
                        imp.Id = Item("ImpresionId")
                        imp.Tratado = Item("ImpresionTratado")
                        imp.CantidadColores = Item("ImpresionCantidadColores")
                        imp.Precio = Item("ImpresionPrecio")

                        entidad.Impresion = imp
                    End If
                    If IsDBNull(Item("ManijaId")) = False Then
                        Dim m As New Manija
                        m.Id = Item("ManijaId")
                        m.Nombre = Item("ManijaNombre")
                        m.Precio = Item("ManijaPrecio")
                        Dim colorManija As New Color
                        colorManija.Id = Item("ManijaColorId")
                        colorManija.Nombre = Item("ManijaColorNombre")
                        colorManija.Codigo = Item("ManijaColorCodigo")
                        m.Color = colorManija

                        entidad.Manija = m
                    End If
                    lista.Add(entidad)
                End If
            Next
        End If

        Return lista
    End Function

    Public Function ConsultarPorId(ByVal id As Integer) As Producto
        Dim parametros As New Hashtable
        Dim ds As New DataSet

        parametros.Add("@Id", id)
        ds = vDatos.Leer("SP_Producto_ConsultarPorId", parametros)

        If ds.Tables(0).Rows.Count > 0 Then
            Dim Item As DataRow = ds.Tables(0).Rows(0)
            Dim entidad As Producto = Nothing
            If Item("Tipo") = "Bolsa" Then
                entidad = New Bolsa
            End If
            If Item("Tipo") = "Bobina" Then
                entidad = New Bobina
            End If
            entidad.Id = Item("Id")
            entidad.Ancho = Item("Ancho")
            entidad.Largo = Item("Largo")
            entidad.Espesor = Item("Espesor")
            entidad.Formato = Item("Formato")
            entidad.Soldadura = Item("Soldadura")
            entidad.Imagen = Item("Imagen")
            entidad.Polimero.Id = Item("PolimeroId")
            entidad.Polimero.Nombre = Item("PolimeroNombre")
            entidad.Polimero.Densidad = Item("PolimeroDensidad")
            entidad.Polimero.Precio = Item("PolimeroPrecio")
            Dim colorPolimero As New Color
            colorPolimero.Id = Item("PolimeroColorId")
            colorPolimero.Nombre = Item("PolimeroColorNombre")
            colorPolimero.Codigo = Item("PolimeroColorCodigo")
            entidad.Polimero.Color = colorPolimero
            If IsDBNull(Item("ImpresionId")) = False Then
                Dim imp As New Impresion
                imp.Id = Item("ImpresionId")
                imp.Tratado = Item("ImpresionTratado")
                imp.CantidadColores = Item("ImpresionCantidadColores")
                imp.Precio = Item("ImpresionPrecio")

                entidad.Impresion = imp
            End If
            If IsDBNull(Item("ManijaId")) = False Then
                Dim m As New Manija
                m.Id = Item("ManijaId")
                m.Nombre = Item("ManijaNombre")
                m.Precio = Item("ManijaPrecio")
                Dim colorManija As New Color
                colorManija.Id = Item("ManijaColorId")
                colorManija.Nombre = Item("ManijaColorNombre")
                colorManija.Codigo = Item("ManijaColorCodigo")
                m.Color = colorManija
            End If
            Dim listaComentarios As New List(Of Comentario)
            If ds.Tables(1).Rows.Count > 0 Then
                For Each row2 As DataRow In ds.Tables(1).Rows
                    Dim c As New Comentario
                    c.Id = row2("Id")
                    c.Valoracion = row2("Valoracion")
                    c.Mensaje = row2("Mensaje")
                    c.Producto.Id = entidad.Id
                    listaComentarios.Add(c)
                Next
            End If
            entidad.ListaComentarios = listaComentarios
            Return entidad
        Else
            Return Nothing
        End If
    End Function

    Public Function Comentar(ByVal entidad As Comentario) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Valoracion", entidad.Valoracion)
        parametros.Add("@Mensaje", entidad.Mensaje)
        parametros.Add("@Producto_Id", entidad.Producto.Id)

        Return vDatos.Escribir("SP_Comentario_Crear", parametros)
    End Function

End Class
