Imports DAL
Imports EE
Public Class ColorMapper

    Private vDatos As Datos

    Sub New()
        Me.vDatos = New Datos
    End Sub

    Public Function Crear(ByVal entidad As Color) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Nombre", entidad.Nombre)
        parametros.Add("@Codigo", entidad.Codigo)

        Return vDatos.Escribir("SP_Color_Crear", parametros)
    End Function

    Public Function Editar(ByVal entidad As Color) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Id", entidad.Id)
        parametros.Add("@Nombre", entidad.Nombre)
        parametros.Add("@Codigo", entidad.Codigo)

        Return vDatos.Escribir("SP_Color_Editar", parametros)
    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Id", id)

        Return vDatos.Escribir("SP_Color_Eliminar", parametros)
    End Function

    Public Function Listar() As List(Of Color)
        Dim ds As New DataSet
        Dim lista As New List(Of Color)
        ds = vDatos.Leer("SP_Color_Listar", Nothing)

        If ds.Tables(0).Rows.Count > 0 Then
            For Each Item As DataRow In ds.Tables(0).Rows
                Dim entidad As New Color
                entidad.Id = Item("Id")
                entidad.Nombre = Item("Nombre")
                entidad.Codigo = Item("Codigo")
                lista.Add(entidad)
            Next
        End If

        Return lista
    End Function

    Public Function ConsultarPorId(ByVal id As Integer) As Color
        Dim parametros As New Hashtable
        Dim ds As New DataSet

        parametros.Add("@Id", id)
        ds = vDatos.Leer("SP_Color_ConsultarPorId", parametros)

        If ds.Tables(0).Rows.Count > 0 Then
            Dim row As DataRow = ds.Tables(0).Rows(0)
            Dim entidad As New Color
            entidad.Id = row.Item("Id")
            entidad.Nombre = row.Item("Nombre")
            entidad.Codigo = row.Item("Codigo")
            Return entidad
        Else
            Return Nothing
        End If
    End Function

End Class
