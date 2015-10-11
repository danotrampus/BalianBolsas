Imports DAL
Imports EE
Public Class BitacoraMapper

    Private vDatos As Datos

    Sub New()
        Me.vDatos = New Datos
    End Sub

    Public Function Crear(ByVal b As Bitacora) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@FechaHora", b.FechaHora)
        parametros.Add("@Tipo", b.Tipo)
        parametros.Add("@Descripcion", b.Descripcion)
        If b.Usuario IsNot Nothing Then
            parametros.Add("@Usuario_Id", b.Usuario.Id)
        End If

        Return vDatos.Escribir("SP_Bitacora_Crear", parametros)
    End Function

    Public Function Listar() As List(Of Bitacora)
        Dim ds As New DataSet
        Dim lista As New List(Of Bitacora)
        ds = vDatos.Leer("SP_Bitacora_Listar", Nothing)

        If ds.Tables(0).Rows.Count > 0 Then
            For Each Item As DataRow In ds.Tables(0).Rows
                Dim b As Bitacora = New Bitacora
                Dim u As Usuario = New Usuario
                b.Id = Item("Id")
                b.FechaHora = Item("Fecha_Hora")
                b.Tipo = Item("Tipo")
                b.Descripcion = Item("Descripcion")
                u.NombreUsuario = Item("Nombre_Usuario")
                b.Usuario = u
                lista.Add(b)
            Next
        End If

        Return lista
    End Function

End Class
