Imports DAL
Imports EE
Public Class ImpresionMapper

    Private vDatos As Datos

    Sub New()
        Me.vDatos = New Datos
    End Sub

    Public Function Crear(ByVal entidad As Impresion) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Tratado", entidad.Tratado)
        parametros.Add("@Precio", entidad.Precio)
        parametros.Add("@CantidadColores", entidad.CantidadColores)

        Return vDatos.Escribir("SP_Impresion_Crear", parametros)
    End Function

    Public Function Editar(ByVal entidad As Impresion) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Id", entidad.Id)
        parametros.Add("@Tratado", entidad.Tratado)
        parametros.Add("@Precio", entidad.Precio)
        parametros.Add("@CantidadColores", entidad.CantidadColores)

        Return vDatos.Escribir("SP_Impresion_Editar", parametros)
    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Id", id)

        Return vDatos.Escribir("SP_Impresion_Eliminar", parametros)
    End Function

    Public Function Listar() As List(Of Impresion)
        Dim ds As New DataSet
        Dim lista As New List(Of Impresion)
        ds = vDatos.Leer("SP_Impresion_Listar", Nothing)

        If ds.Tables(0).Rows.Count > 0 Then
            For Each Item As DataRow In ds.Tables(0).Rows
                Dim entidad As New Impresion
                entidad.Id = Item("Id")
                entidad.Tratado = Item("Tratado")
                entidad.Precio = Item("Precio")
                entidad.CantidadColores = Item("Cantidad_Colores")
                lista.Add(entidad)
            Next
        End If

        Return lista
    End Function

    Public Function ConsultarPorId(ByVal id As Integer) As Impresion
        Dim parametros As New Hashtable
        Dim ds As New DataSet

        parametros.Add("@Id", id)
        ds = vDatos.Leer("SP_Impresion_ConsultarPorId", parametros)

        If ds.Tables(0).Rows.Count > 0 Then
            Dim row As DataRow = ds.Tables(0).Rows(0)
            Dim entidad As New Impresion
            entidad.Id = row.Item("Id")
            entidad.Tratado = row.Item("Tratado")
            entidad.Precio = row.Item("Precio")
            entidad.CantidadColores = row.Item("Cantidad_Colores")
            Return entidad
        Else
            Return Nothing
        End If
    End Function

End Class
