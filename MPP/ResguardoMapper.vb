Imports DAL
Imports EE
Public Class ResguardoMapper

    Private vDatos As Datos

    Sub New()
        Me.vDatos = New Datos
    End Sub

    Public Function Crear(ByVal r As Resguardo) As Boolean
        If Me.vDatos.BackupBase(r.RutaNombre) Then
            Dim parametros As New Hashtable

            parametros.Add("@Tipo", r.Tipo)
            parametros.Add("@FechaHora", r.FechaHora)
            parametros.Add("@RutaNombre", r.RutaNombre)
            parametros.Add("@Usuario_Id", r.Usuario.Id)

            Return vDatos.Escribir("SP_Resguardo_Crear", parametros)
        End If
        Return False
    End Function

    Public Function Listar() As List(Of Resguardo)
        Dim ds As New DataSet
        Dim lista As New List(Of Resguardo)
        ds = vDatos.Leer("SP_Resguardo_Listar", Nothing)

        If ds.Tables(0).Rows.Count > 0 Then
            For Each Item As DataRow In ds.Tables(0).Rows
                Dim r As New Resguardo()
                Dim u As New Usuario()
                r.Id = Item("Id")
                r.FechaHora = Item("Fecha_Hora")
                r.RutaNombre = Item("Ruta_Nombre")
                r.Tipo = Item("Tipo")
                u.NombreUsuario = Item("Nombre_Usuario")
                r.Usuario = u
                lista.Add(r)
            Next
        End If

        Return lista
    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Id", id)

        Return vDatos.Escribir("SP_Resguardo_Eliminar", parametros)
    End Function

    Public Function Restaurar(ByVal r As Resguardo) As Boolean
        If Me.vDatos.RestaurarBase(r.RutaNombre) Then
            Dim parametros As New Hashtable

            parametros.Add("@Tipo", r.Tipo)
            parametros.Add("@FechaHora", r.FechaHora)
            parametros.Add("@RutaNombre", r.RutaNombre)
            parametros.Add("@Usuario_Id", r.Usuario.Id)

            Return vDatos.Escribir("SP_Resguardo_Crear", parametros)
        End If
        Return False
    End Function

End Class
