Imports DAL
Imports EE
Public Class CategoriaMapper

    Private vDatos As Datos

    Sub New()
        Me.vDatos = New Datos
    End Sub

    Public Function Crear(ByVal cat As Categoria) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Nombre", cat.Nombre)

        Return vDatos.Escribir("SP_Categoria_Crear", parametros)
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
End Class
