Imports DAL
Imports EE
Public Class ManijaMapper

    Private vDatos As Datos

    Sub New()
        Me.vDatos = New Datos
    End Sub

    Public Function Crear(ByVal entidad As Manija) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Nombre", entidad.Nombre)
        parametros.Add("@Precio", entidad.Precio)
        parametros.Add("@Color_Id", entidad.Color.Id)

        Return vDatos.Escribir("SP_Manija_Crear", parametros)
    End Function

    Public Function Editar(ByVal entidad As Manija) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Id", entidad.Id)
        parametros.Add("@Nombre", entidad.Nombre)
        parametros.Add("@Precio", entidad.Precio)
        parametros.Add("@Color_Id", entidad.Color.Id)

        Return vDatos.Escribir("SP_Manija_Editar", parametros)
    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Id", id)

        Return vDatos.Escribir("SP_Manija_Eliminar", parametros)
    End Function

    Public Function Listar() As List(Of Manija)
        Dim ds As New DataSet
        Dim lista As New List(Of Manija)
        ds = vDatos.Leer("SP_Manija_Listar", Nothing)

        If ds.Tables(0).Rows.Count > 0 Then
            For Each Item As DataRow In ds.Tables(0).Rows
                Dim entidad As New Manija
                entidad.Id = Item("Id")
                entidad.Nombre = Item("Nombre")
                entidad.Precio = Item("Precio")
                entidad.Color.Id = Item("ColorId")
                entidad.Color.Nombre = Item("ColorNombre")
                entidad.Color.Codigo = Item("ColorCodigo")
                lista.Add(entidad)
            Next
        End If

        Return lista
    End Function

    Public Function ConsultarPorId(ByVal id As Integer) As Manija
        Dim parametros As New Hashtable
        Dim ds As New DataSet

        parametros.Add("@Id", id)
        ds = vDatos.Leer("SP_Manija_ConsultarPorId", parametros)

        If ds.Tables(0).Rows.Count > 0 Then
            Dim row As DataRow = ds.Tables(0).Rows(0)
            Dim entidad As New Manija
            entidad.Id = row.Item("Id")
            entidad.Nombre = row.Item("Nombre")
            entidad.Precio = row.Item("Precio")
            entidad.Color.Id = row.Item("ColorId")
            entidad.Color.Nombre = row.Item("ColorNombre")
            entidad.Color.Codigo = row.Item("ColorCodigo")
            Return entidad
        Else
            Return Nothing
        End If
    End Function

End Class
