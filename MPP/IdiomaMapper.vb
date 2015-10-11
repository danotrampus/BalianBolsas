Imports DAL
Imports EE
Public Class IdiomaMapper

    Private vDatos As Datos

    Sub New()
        Me.vDatos = New Datos()
    End Sub

    Public Function Editar(ByVal idiomasActivos As List(Of Integer)) As Boolean
        Dim parametros As New Hashtable

        Dim dt As New DataTable()
        'Dim columna As New DataColumn()
        'columna.ColumnName = "Id"
        'columna.DataType = System.Type.GetType("System.Int32")
        'columna.AutoIncrement = True
        'columna.AutoIncrementSeed = 1
        'columna.AutoIncrementStep = 1
        'dt.Columns.Add(columna)
        dt.Columns.Add("Idioma_Id")
        'dt.PrimaryKey = New DataColumn() {columna}
        For Each id As Integer In idiomasActivos
            Dim row As DataRow = dt.NewRow
            row("Idioma_Id") = id
            dt.Rows.Add(row)
        Next

        parametros.Add("@IdiomasActivos", dt)

        Return vDatos.Escribir("SP_Idioma_Editar", parametros)
    End Function

    Public Function Listar() As List(Of Idioma)
        Dim ds As New DataSet
        Dim lista As New List(Of Idioma)
        ds = vDatos.Leer("SP_Idioma_Listar", Nothing)

        If ds.Tables(0).Rows.Count > 0 Then
            For Each Item As DataRow In ds.Tables(0).Rows
                Dim i As Idioma = New Idioma
                i.Id = Item("Id")
                i.Nombre = Item("Nombre")
                i.Locale = Item("Locale")
                i.Activo = Item("Activo")
                lista.Add(i)
            Next
        End If

        Return lista
    End Function

End Class
