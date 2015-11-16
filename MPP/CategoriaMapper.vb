Imports DAL
Imports EE
Public Class CategoriaMapper

    Private vDatos As Datos

    Sub New()
        Me.vDatos = New Datos
    End Sub

    Public Function Crear(ByVal entidad As Categoria) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Nombre", entidad.Nombre)

        Return vDatos.Escribir("SP_Categoria_Crear", parametros)
    End Function

    Public Function Editar(ByVal entidad As Categoria) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Id", entidad.Id)
        parametros.Add("@Nombre", entidad.Nombre)

        Return vDatos.Escribir("SP_Categoria_Editar", parametros)
    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Id", id)

        Return vDatos.Escribir("SP_Categoria_Eliminar", parametros)
    End Function

    Public Function Listar() As List(Of Categoria)
        Dim ds As New DataSet
        Dim lista As New List(Of Categoria)
        ds = vDatos.Leer("SP_Categoria_Listar", Nothing)

        If ds.Tables(0).Rows.Count > 0 Then
            For Each Item As DataRow In ds.Tables(0).Rows
                Dim cat As Categoria = New Categoria
                cat.Id = Item("Id")
                cat.Nombre = Item("Nombre")
                lista.Add(cat)
            Next
        End If

        Return lista
    End Function

    Public Function ConsutarPorId(ByVal id As Integer) As Categoria
        Dim parametros As New Hashtable
        Dim ds As New DataSet

        parametros.Add("@Id", id)
        ds = vDatos.Leer("SP_Categoria_ConsultarPorId", parametros)

        If ds.Tables(0).Rows.Count > 0 Then
            Dim row As DataRow = ds.Tables(0).Rows(0)
            Dim c As New Categoria
            c.Id = row.Item("Id")
            c.Nombre = row.Item("Nombre")
            Return c
        Else
            Return Nothing
        End If
    End Function
End Class
