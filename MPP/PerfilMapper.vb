Imports DAL
Imports EE
Imports System
Imports System.Reflection
Public Class PerfilMapper

    Private vDatos As Datos

    Sub New()
        Me.vDatos = New Datos()
    End Sub

    Public Function Crear(ByVal p As Perfil) As Boolean
        Dim parametros As New Hashtable
        parametros.Add("@Nombre", p.Nombre)
        Dim dt As New DataTable()
        dt.Columns.Add("Permiso_Id")
        Me.AgregarPermisosHijos(dt, p.ListaPermisos)
        parametros.Add("@Permisos", dt)

        Return vDatos.Escribir("SP_Perfil_Crear", parametros)
    End Function

    Private Sub AgregarPermisosHijos(ByRef dt As DataTable, ByVal lista As List(Of Permiso))
        For Each p As Permiso In lista
            If p.Habilitado Then
                dt.Rows.Add(p.Id)
            End If
            If TypeOf p Is Familia Then
                Me.AgregarPermisosHijos(dt, DirectCast(p, Familia).ListaPermisos)
            End If
        Next
    End Sub

    Public Function ConsultarPermisosStringPorUsuario(ByVal id As Integer) As String()
        Dim listaPermisos As List(Of Permiso) = Me.ConsultarPermisos(0, id)
        Dim lista As New List(Of String)
        For Each p As Permiso In listaPermisos
            If p.Habilitado Then
                lista.Add(p.Nombre)
            End If
            If TypeOf p Is Familia Then
                Me.ConsultarPermisosHijosString(p, lista)
            End If
        Next
        Return lista.ToArray()
    End Function

    Private Sub ConsultarPermisosHijosString(ByVal f As Familia, ByRef lista As List(Of String))
        For Each p As Permiso In f.ListaPermisos
            If p.Habilitado Then
                lista.Add(p.Nombre)
            End If
            If TypeOf p Is Familia Then
                Me.ConsultarPermisosHijosString(p, lista)
            End If
        Next
    End Sub

    Public Function Editar(ByVal p As Perfil) As Boolean
        Dim parametros As New Hashtable
        parametros.Add("@Id", p.Id)
        parametros.Add("@Nombre", p.Nombre)

        Dim dt As New DataTable()
        dt.Columns.Add("Permiso_Id")
        Me.AgregarPermisosHijos(dt, p.ListaPermisos)
        parametros.Add("@Permisos", dt)

        Return vDatos.Escribir("SP_Perfil_Editar", parametros)
    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Id", id)

        Return vDatos.Escribir("SP_Perfil_Eliminar", parametros)
    End Function

    Public Function Listar() As List(Of Perfil)
        Dim ds As New DataSet
        Dim lista As New List(Of Perfil)
        ds = vDatos.Leer("SP_Perfil_Listar", Nothing)

        If ds.Tables(0).Rows.Count > 0 Then
            For Each Item As DataRow In ds.Tables(0).Rows
                Dim u As Perfil = New Perfil
                u.Id = Item("Id")
                u.Nombre = Item("Nombre")
                lista.Add(u)
            Next
        End If

        Return lista
    End Function

    Public Function ConsultarPorId(ByVal id As Integer) As Perfil
        Dim parametros As New Hashtable
        Dim ds As New DataSet

        parametros.Add("@Id", id)
        ds = vDatos.Leer("SP_Perfil_ConsultarPorId", parametros)

        If ds.Tables(0).Rows.Count > 0 Then
            Dim row As DataRow = ds.Tables(0).Rows(0)
            Dim p As New Perfil
            p.Id = row.Item("Id")
            p.Nombre = row.Item("Nombre")
            p.ListaPermisos = Me.ConsultarPermisos(id)
            Return p
        Else
            Return Nothing
        End If
    End Function

    Public Function ConsultarPorNombre(ByVal nombre As String) As Perfil
        Dim parametros As New Hashtable
        Dim ds As New DataSet

        parametros.Add("@Nombre", nombre)
        ds = vDatos.Leer("SP_Perfil_ConsultarPorNombre", parametros)

        If ds.Tables(0).Rows.Count > 0 Then
            Dim row As DataRow = ds.Tables(0).Rows(0)
            Dim p As New Perfil
            p.Id = row.Item("Id")
            p.Nombre = row.Item("Nombre")
            p.ListaPermisos = Me.ConsultarPermisos(p.Id)
            Return p
        Else
            Return Nothing
        End If
    End Function

    Public Function ConsultarPermisos(Optional ByVal perfilId As Integer = 0, Optional ByVal usuarioId As Integer = 0) As List(Of Permiso)
        Dim ds As New DataSet
        Dim parametros As New Hashtable
        parametros.Add("@Perfil_Id", perfilId)
        parametros.Add("@Usuario_Id", usuarioId)

        ds = vDatos.Leer("SP_Permiso_Listar", parametros)

        Dim lista As New List(Of Permiso)
        If ds.Tables(0).Rows.Count > 0 Then
            For Each Item As DataRow In ds.Tables(0).Rows
                If (IsDBNull(Item("Permiso_Id"))) Then
                    If Item("Discriminador") = "Familia" Then
                        Dim f As New Familia(Item("Id"), Item("Nombre"), Item("Descripcion"), Item("Url"), Item("Habilitado"), Item("Css"), Item("Activo"))
                        lista.Add(ArmarPermisosHijo(f, ds.Tables(0)))
                    Else
                        lista.Add(New Patente(Item("Id"), Item("Nombre"), Item("Descripcion"), Item("Url"), Item("Habilitado"), Item("Css"), Item("Activo")))
                    End If
                End If
            Next
        End If

        Return lista
    End Function

    Private Function ArmarPermisosHijo(ByVal f As Familia, ByVal permisos As DataTable) As Permiso
        For Each Item As DataRow In permisos.Rows
            If (Not IsDBNull(Item("Permiso_Id"))) Then
                If Item("Permiso_Id") = f.Id Then
                    If Item("Discriminador") = "Familia" Then
                        Dim fa As New Familia(Item("Id"), Item("Nombre"), Item("Descripcion"), Item("Url"), Item("Habilitado"), Item("Css"), Item("Activo"))
                        f.AgregarPermiso(ArmarPermisosHijo(fa, permisos))
                    Else
                        f.AgregarPermiso(New Patente(Item("Id"), Item("Nombre"), Item("Descripcion"), Item("Url"), Item("Habilitado"), Item("Css"), Item("Activo")))
                    End If
                End If
            End If
        Next
        Return f
    End Function

    Public Function VerificarExistenciaPerfil(ByVal nombre As String) As Boolean
        Dim parametros As New Hashtable
        Dim ds As New DataSet

        parametros.Add("@Nombre", nombre)
        ds = vDatos.Leer("SP_Perfil_VerificarExistencia", parametros)

        If ds.Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

End Class
