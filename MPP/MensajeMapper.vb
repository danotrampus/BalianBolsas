Imports DAL
Imports EE
Public Class MensajeMapper

    Private vDatos As Datos

    Sub New()
        Me.vDatos = New Datos
    End Sub

    Public Function Crear(ByVal m As Mensaje) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@FechaHora", m.FechaHora)
        parametros.Add("@Mensaje", m.Mensaje)
        parametros.Add("@Grupo", m.Grupo)
        parametros.Add("@Usuario_Id", m.Usuario.Id)

        Return vDatos.Escribir("SP_Mensaje_Crear", parametros)
    End Function

    Public Function Listar(ByVal grupo As String) As List(Of Mensaje)
        Dim ds As New DataSet
        Dim lista As New List(Of Mensaje)
        Dim parametros As New Hashtable

        parametros.Add("@Grupo", grupo)
        ds = vDatos.Leer("SP_Mensaje_Listar", parametros)

        If ds.Tables(0).Rows.Count > 0 Then
            For Each Item As DataRow In ds.Tables(0).Rows
                Dim m As Mensaje = New Mensaje
                Dim u As Usuario = New Usuario
                m.Id = Item("Id")
                m.FechaHora = Item("Fecha_Hora")
                m.Mensaje = Item("Mensaje")
                m.Grupo = Item("Grupo")
                u.Id = Item("Usuario_Id")
                u.NombreUsuario = Item("Nombre_Usuario")
                m.Usuario = u
                lista.Add(m)
            Next
        End If

        Return lista
    End Function

End Class
