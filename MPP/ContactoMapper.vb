Imports DAL
Imports EE
Public Class ContactoMapper

    Private vDatos As Datos

    Sub New()
        Me.vDatos = New Datos
    End Sub

    Public Function Crear(ByVal c As Contacto) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@FechaHora", c.FechaHora)
        parametros.Add("@NombreApellido", c.NombreApellido)
        parametros.Add("@Email", c.Email)
        parametros.Add("@Asunto", c.Asunto)
        parametros.Add("@Mensaje", c.Mensaje)

        Return vDatos.Escribir("SP_Contacto_Crear", parametros)
    End Function

    Public Function Listar() As List(Of Contacto)
        Dim ds As New DataSet
        Dim lista As New List(Of Contacto)
        ds = vDatos.Leer("SP_Contacto_Listar", Nothing)

        If ds.Tables(0).Rows.Count > 0 Then
            For Each Item As DataRow In ds.Tables(0).Rows
                Dim c As Contacto = New Contacto
                c.Id = Item("Id")
                c.FechaHora = Item("Fecha_Hora")
                c.NombreApellido = Item("Nombre_Apellido")
                c.Email = Item("Email")
                c.Asunto = Item("Asunto")
                c.Mensaje = Item("Mensaje")
                lista.Add(c)
            Next
        End If

        Return lista
    End Function

End Class
