Imports DAL
Imports EE
Public Class EncuestaMapper

    Private vDatos As Datos

    Sub New()
        Me.vDatos = New Datos
    End Sub

    Public Function Crear(ByVal e As Encuesta) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Tipo", e.Tipo)
        parametros.Add("@FechaVigencia", e.FechaVigencia)
        parametros.Add("@Pregunta", e.Pregunta)

        Return vDatos.Escribir("SP_Encuesta_Crear", parametros)
    End Function

    Public Function Editar(ByVal e As Encuesta) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Id", e.Id)
        parametros.Add("@Tipo", e.Tipo)
        parametros.Add("@FechaVigencia", e.FechaVigencia)
        parametros.Add("@Pregunta", e.Pregunta)

        Return vDatos.Escribir("SP_Encuesta_Editar", parametros)
    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Id", id)

        Return vDatos.Escribir("SP_Encuesta_Eliminar", parametros)
    End Function

    Public Function Listar() As List(Of Encuesta)
        Dim ds As New DataSet
        Dim lista As New List(Of Encuesta)
        ds = vDatos.Leer("SP_Encuesta_Listar", Nothing)

        If ds.Tables(0).Rows.Count > 0 Then
            For Each Item As DataRow In ds.Tables(0).Rows
                Dim e As Encuesta = New Encuesta
                e.Id = Item("Id")
                e.FechaVigencia = Item("Fecha_Vigencia")
                e.Tipo = Item("Tipo")
                e.Pregunta = Item("Pregunta")
                lista.Add(e)
            Next
        End If

        Return lista
    End Function

    Public Function ConsultarPorId(ByVal id As Integer) As Encuesta
        Dim parametros As New Hashtable
        Dim ds As New DataSet

        parametros.Add("@Id", id)
        ds = vDatos.Leer("SP_Encuesta_ConsultarPorId", parametros)

        If ds.Tables(0).Rows.Count > 0 Then
            Dim row As DataRow = ds.Tables(0).Rows(0)
            Dim e As New Encuesta
            e.Id = row.Item("Id")
            e.FechaVigencia = row.Item("Fecha_Vigencia")
            e.Tipo = row.Item("Tipo")
            e.Pregunta = row.Item("Pregunta")
            If ds.Tables(1).Rows.Count > 0 Then
                Dim lista As New List(Of Opcion)
                For Each row2 As DataRow In ds.Tables(1).Rows
                    Dim o As New Opcion()
                    o.Id = row2("Id")
                    o.Valor = row2("Valor")
                    lista.Add(o)
                Next
                e.ListaOpciones = lista
            End If
            Return e
        Else
            Return Nothing
        End If
    End Function

End Class
