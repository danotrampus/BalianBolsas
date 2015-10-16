Imports DAL
Imports EE
Public Class NovedadMapper

    Private vDatos As Datos

    Sub New()
        Me.vDatos = New Datos
    End Sub

    Public Function Crear(ByVal n As Novedad) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@FechaCreacion", n.FechaCreacion)
        parametros.Add("@Titulo", n.Titulo)
        parametros.Add("@Contenido", n.Contenido)
        parametros.Add("@Tipo", n.Tipo)
        parametros.Add("@Categoria_Id", n.Categoria.Id)

        Return vDatos.Escribir("SP_Novedad_Crear", parametros)
    End Function

    Public Function Editar(ByVal n As Novedad) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Id", n.Id)
        parametros.Add("@Titulo", n.Titulo)
        parametros.Add("@Contenido", n.Contenido)
        parametros.Add("@Tipo", n.Tipo)
        parametros.Add("@Categoria_Id", n.Categoria.Id)

        Return vDatos.Escribir("SP_Novedad_Editar", parametros)
    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Id", id)

        Return vDatos.Escribir("SP_Novedad_Eliminar", parametros)
    End Function

    Public Function Listar() As List(Of Novedad)
        Dim ds As New DataSet
        Dim lista As New List(Of Novedad)
        ds = vDatos.Leer("SP_Novedad_Listar", Nothing)

        If ds.Tables(0).Rows.Count > 0 Then
            For Each Item As DataRow In ds.Tables(0).Rows
                Dim n As Novedad = New Novedad
                n.Id = Item("Id")
                n.FechaCreacion = Item("FechaCreacion")
                n.Titulo = Item("Titulo")
                n.Contenido = Item("Contenido")
                n.Tipo = Item("Tipo")
                n.Categoria.Nombre = Item("Categoria")
                lista.Add(n)
            Next
        End If

        Return lista
    End Function

    Public Function ListarNovedades() As List(Of Novedad)
        Dim ds As New DataSet
        Dim lista As New List(Of Novedad)
        ds = vDatos.Leer("SP_Novedad_Listar", Nothing)

        If ds.Tables(0).Rows.Count > 0 Then
            For Each Item As DataRow In ds.Tables(0).Rows
                If Item("Tipo") = "Novedad" Then
                    Dim n As Novedad = New Novedad
                    n.Id = Item("Id")
                    n.FechaCreacion = Item("FechaCreacion")
                    n.Titulo = Item("Titulo")
                    n.Contenido = Item("Contenido")
                    n.Tipo = Item("Tipo")
                    n.Categoria.Nombre = Item("Categoria")
                    lista.Add(n)
                End If
            Next
        End If

        Return lista
    End Function

    Public Function ConsultarPorId(ByVal id As Integer) As Novedad
        Dim parametros As New Hashtable
        Dim ds As New DataSet

        parametros.Add("@Id", id)
        ds = vDatos.Leer("SP_Novedad_ConsultarPorId", parametros)

        If ds.Tables(0).Rows.Count > 0 Then
            Dim row As DataRow = ds.Tables(0).Rows(0)
            Dim n As New Novedad
            n.Id = row.Item("Id")
            n.FechaCreacion = row.Item("FechaCreacion")
            n.Titulo = row.Item("Titulo")
            n.Contenido = row.Item("Contenido")
            n.Tipo = row.Item("Tipo")
            n.Categoria.Id = row.Item("Categoria_Id")
            n.Categoria.Nombre = row.Item("Categoria_Nombre")
            Return n
        Else
            Return Nothing
        End If
    End Function

End Class
