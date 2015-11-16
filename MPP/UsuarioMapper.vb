Imports DAL
Imports EE
Public Class UsuarioMapper

    Private vDatos As Datos

    Sub New()
        Me.vDatos = New Datos()
    End Sub

    Public Function Crear(ByVal u As Usuario) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Nombre", u.Nombre)
        parametros.Add("@Apellido", u.Apellido)
        parametros.Add("@Email", u.Email)
        parametros.Add("@NombreUsuario", u.NombreUsuario)
        parametros.Add("@Clave", u.Clave)
        parametros.Add("@Activo", u.Activo)
        If u.TokenActivacion IsNot Nothing Then
            parametros.Add("@TokenActivacion", u.TokenActivacion)
        End If
        Dim dt As New DataTable()
        dt.Columns.Add("Perfil_Id")
        For Each id As Integer In u.PerfilesId
            dt.Rows.Add(id)
        Next
        parametros.Add("@Perfiles", dt)

        Return vDatos.Escribir("SP_Usuario_Crear", parametros)
    End Function

    Public Function Editar(ByVal u As Usuario) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Id", u.Id)
        parametros.Add("@Nombre", u.Nombre)
        parametros.Add("@Apellido", u.Apellido)
        parametros.Add("@Email", u.Email)
        parametros.Add("@NombreUsuario", u.NombreUsuario)
        If u.Telefono IsNot Nothing Then
            parametros.Add("@Telefono", u.Telefono)
        End If
        Dim dt As New DataTable()
        dt.Columns.Add("Perfil_Id")
        For Each id As Integer In u.PerfilesId
            dt.Rows.Add(id)
        Next
        parametros.Add("@Perfiles", dt)

        Return vDatos.Escribir("SP_Usuario_Editar", parametros)
    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Id", id)

        Return vDatos.Escribir("SP_Usuario_Eliminar", parametros)
    End Function

    Public Function Listar() As List(Of Usuario)
        Dim ds As New DataSet
        Dim lista As New List(Of Usuario)
        ds = vDatos.Leer("SP_Usuario_Listar", Nothing)

        If ds.Tables(0).Rows.Count > 0 Then
            For Each Item As DataRow In ds.Tables(0).Rows
                Dim u As Usuario = New Usuario
                u.Id = Item("Id")
                u.Nombre = Item("Nombre")
                u.Apellido = Item("Apellido")
                u.Email = Item("Email")
                u.NombreUsuario = Item("Nombre_Usuario")
                u.Activo = Item("Activo")
                lista.Add(u)
            Next
        End If

        Return lista
    End Function

    Public Function ConsultarPorId(ByVal id As Integer) As Usuario
        Dim parametros As New Hashtable
        Dim ds As New DataSet

        parametros.Add("@Id", id)
        ds = vDatos.Leer("SP_Usuario_ConsultarPorId", parametros)

        If ds.Tables(0).Rows.Count > 0 Then
            Dim row As DataRow = ds.Tables(0).Rows(0)
            Dim u As New Usuario
            u.Id = row.Item("Id")
            u.Nombre = row.Item("Nombre")
            u.Apellido = row.Item("Apellido")
            u.Email = row.Item("Email")
            u.Clave = row.Item("Clave")
            u.NombreUsuario = row.Item("Nombre_Usuario")
            u.Activo = row.Item("Activo")
            If ds.Tables(1).Rows.Count > 0 Then
                Dim lista As New List(Of Perfil)
                For Each row2 As DataRow In ds.Tables(1).Rows
                    Dim p As New Perfil()
                    p.Id = row2("Id")
                    p.Nombre = row2("Nombre")
                    lista.Add(p)

                    u.PerfilesId.Add(row2("Id"))
                Next
                u.ListaPerfiles = lista
            End If

            Dim listaMovimientos As New List(Of Movimiento)
            If ds.Tables(2).Rows.Count > 0 Then
                For Each row3 As DataRow In ds.Tables(2).Rows
                    Dim m As Movimiento = Nothing
                    Select Case row3("Tipo")
                        Case "Factura"
                            m = New Factura
                        Case "NotaCredito"
                            m = New NotaCredito
                        Case "NotaDebito"
                            m = New NotaDebito
                        Case "Pago"
                            m = New Pago
                    End Select

                    m.Numero = row3("Numero")
                    m.TipoComprobante = row3("TipoComprobante")
                    If IsDBNull(row3("Observacion")) = False Then
                        m.Observacion = row3("Observacion")
                    End If
                    m.Importe = row3("Importe")
                    listaMovimientos.Add(m)
                Next
            End If
            u.ListaMovimientos = listaMovimientos

            Dim listaPedidos As New List(Of Pedido)
            If ds.Tables(3).Rows.Count > 0 Then
                For Each row4 As DataRow In ds.Tables(3).Rows
                    Dim p As New Pedido
                    p.Id = row4("Id")
                    p.FechaInicio = row4("FechaInicio")
                    If IsDBNull(row4("FechaFin")) = False Then
                        p.FechaFin = row4("FechaFin")
                    End If
                    p.Estado = row4("Estado")
                    p.Importe = row4("Importe")
                    p.Direccion.Calle = row4("Direccion_Calle")
                    p.Direccion.Numero = row4("Direccion_Numero")
                    p.Direccion.DptoPiso = row4("Direccion_DptoPiso")
                    p.Direccion.Localidad = row4("Direccion_Localidad")
                    listaPedidos.Add(p)
                Next
            End If
            u.ListaPedidos = listaPedidos

            Return u
        Else
            Return Nothing
        End If
    End Function

    Public Function ConsultarPorNombreYClave(ByVal nombreUsuario As String, ByVal clave As String) As Usuario
        Dim parametros As New Hashtable
        Dim ds As New DataSet

        parametros.Add("@NombreUsuario", nombreUsuario)
        parametros.Add("@Clave", clave)
        ds = vDatos.Leer("SP_Usuario_ConsultarPorNombreYClave", parametros)

        If ds.Tables(0).Rows.Count > 0 Then
            Dim row As DataRow = ds.Tables(0).Rows(0)
            Dim u As New Usuario
            u.Id = row.Item("Id")
            u.Nombre = row.Item("Nombre")
            u.Apellido = row.Item("Apellido")
            u.Email = row.Item("Email")
            u.NombreUsuario = row.Item("Nombre_Usuario")
            u.Activo = row.Item("Activo")
            Return u
        Else
            Return Nothing
        End If
    End Function

    Public Function ConsultarPorEmail(ByVal email As String) As Usuario
        Dim parametros As New Hashtable
        Dim ds As New DataSet

        parametros.Add("@Email", email)
        ds = vDatos.Leer("SP_Usuario_ConsultarPorEmail", parametros)

        If ds.Tables(0).Rows.Count > 0 Then
            Dim row As DataRow = ds.Tables(0).Rows(0)
            Dim u As New Usuario
            u.Id = row.Item("Id")
            u.Nombre = row.Item("Nombre")
            u.Apellido = row.Item("Apellido")
            u.Email = row.Item("Email")
            u.NombreUsuario = row.Item("Nombre_Usuario")
            u.Clave = row.Item("Clave")
            u.Activo = row.Item("Activo")
            Return u
        Else
            Return Nothing
        End If
    End Function

    Public Function Activar(ByVal token As String) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Token", token)

        Return vDatos.Escribir("SP_Usuario_Activar", parametros)
    End Function

    Public Function CambiarClave(ByVal id As Integer, ByVal clave As String) As Boolean
        Dim parametros As New Hashtable
        Dim ds As New DataSet

        parametros.Add("@Id", id)
        parametros.Add("@Clave", clave)
        Return vDatos.Escribir("SP_Usuario_CambiarClave", parametros)
    End Function

    Public Function VerificarExistenciaPorNombreUsuario(ByVal nombreUsuario As String) As Boolean
        Dim parametros As New Hashtable
        Dim ds As New DataSet

        parametros.Add("@NombreUsuario", nombreUsuario)
        ds = vDatos.Leer("SP_Usuario_VerificarExistenciaPorNombreUsuario", parametros)

        If ds.Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function VerificarExistenciaPorEmail(ByVal email As String) As Boolean
        Dim parametros As New Hashtable
        Dim ds As New DataSet

        parametros.Add("@Email", email)
        ds = vDatos.Leer("SP_Usuario_VerificarExistenciaPorEmail", parametros)

        If ds.Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function ListarClientes() As List(Of Usuario)
        Dim ds As New DataSet
        Dim lista As New List(Of Usuario)
        ds = vDatos.Leer("SP_Usuario_ListarClientes", Nothing)

        If ds.Tables(0).Rows.Count > 0 Then
            For Each Item As DataRow In ds.Tables(0).Rows
                Dim u As Usuario = New Usuario
                u.Id = Item("Id")
                u.Nombre = Item("Nombre")
                u.Apellido = Item("Apellido")
                u.Email = Item("Email")
                u.NombreUsuario = Item("Nombre_Usuario")
                lista.Add(u)
            Next
        End If

        Return lista
    End Function

End Class
