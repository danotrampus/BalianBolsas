Imports DAL
Imports EE
Public Class ProductoMapper

    Private vDatos As Datos

    Sub New()
        Me.vDatos = New Datos
    End Sub

    Public Function Crear(ByVal entidad As Producto) As Boolean
        Dim parametros As New Hashtable

        If entidad.GetType() = GetType(Bolsa) Then
            parametros.Add("@Tipo", "Bolsa")
        End If
        If entidad.GetType() = GetType(Bobina) Then
            parametros.Add("@Tipo", "Bobina")
        End If
        parametros.Add("@Ancho", entidad.Ancho)
        If entidad.GetType() = GetType(Bolsa) Then
            parametros.Add("@Largo", entidad.Largo)
        End If
        parametros.Add("@Espesor", entidad.Espesor)
        parametros.Add("@Formato", entidad.Formato)
        parametros.Add("@Imagen", entidad.Imagen)
        parametros.Add("@Soldadura", entidad.Soldadura)
        parametros.Add("@Polimero_Id", entidad.Polimero.Id)
        If entidad.Impresion IsNot Nothing Then
            parametros.Add("@Impresion_Id", entidad.Impresion.Id)
        End If

        Return vDatos.Escribir("SP_Producto_Crear", parametros)
    End Function

    Public Function Editar(ByVal entidad As Producto) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Id", entidad.Id)
        If entidad.GetType() = GetType(Bolsa) Then
            parametros.Add("@Tipo", "Bolsa")
        End If
        If entidad.GetType() = GetType(Bobina) Then
            parametros.Add("@Tipo", "Bobina")
        End If
        parametros.Add("@Ancho", entidad.Ancho)
        parametros.Add("@Largo", entidad.Largo)
        parametros.Add("@Espesor", entidad.Espesor)
        parametros.Add("@Formato", entidad.Formato)
        parametros.Add("@Soldadura", entidad.Soldadura)
        parametros.Add("@Polimero_Id", entidad.Polimero.Id)
        If entidad.Impresion IsNot Nothing Then
            parametros.Add("@Impresion_Id", entidad.Impresion.Id)
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
                entidad.Polimero.Id = Item("PolimeroId")
                entidad.Polimero.Nombre = Item("PolimeroNombre")
                entidad.Polimero.Densidad = Item("PolimeroDensidad")
                entidad.Polimero.Precio = Item("PolimeroPrecio")
                If Item("ImpresionId") IsNot Nothing Then
                    Dim imp As New Impresion
                    imp.Id = Item("ImpresionId")
                    imp.Tratado = Item("ImpresionTratado")
                    imp.CantidadColores = Item("ImpresionCantidadColores")
                    imp.Precio = Item("ImpresionPrecio")

                    entidad.Impresion = imp
                End If
                lista.Add(entidad)
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
            entidad.Polimero.Densidad = Item("PolimeroPrecio")
            entidad.Polimero.Precio = Item("PolimeroPrecio")
            If Item("ImpresionId") IsNot Nothing Then
                Dim imp As New Impresion
                imp.Id = Item("ImpresionId")
                imp.Tratado = Item("ImpresionTratado")
                imp.CantidadColores = Item("ImpresionCantidadColores")
                imp.Precio = Item("ImpresionPrecio")

                entidad.Impresion = imp
            End If
            Return entidad
        Else
            Return Nothing
        End If
    End Function

End Class
