Imports System.Data.SqlClient
Imports System.Configuration
Public Class Datos

    Private Str As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
    Private Str2 As String = ConfigurationManager.ConnectionStrings("MasterConnection").ConnectionString

    Private Cnn As New SqlConnection(Str)
    Private CnnMaster As New SqlConnection(Str2)
    Private Tranx As SqlTransaction
    Private Cmd As SqlCommand


    Public Function Leer(ByVal consulta As String, ByVal hdatos As Hashtable) As DataSet

        Dim Ds As New DataSet
        Cmd = New SqlCommand

        Cmd.Connection = Cnn
        Cmd.CommandText = consulta
        Cmd.CommandType = CommandType.StoredProcedure

        If Not hdatos Is Nothing Then

            'si la hashtable no esta vacia, y tiene el dato q busco 
            For Each dato As String In hdatos.Keys
                'cargo los parametros que le estoy pasando con la Hash
                Cmd.Parameters.AddWithValue(dato, hdatos(dato))
            Next
        End If

        Dim Adaptador As New SqlDataAdapter(Cmd)
        Adaptador.Fill(Ds)
        Return Ds


    End Function

    Public Function Escribir(ByVal consulta As String, ByVal hdatos As Hashtable, Optional ByVal conTransaccion As Boolean = True) As Boolean

        If Cnn.State = ConnectionState.Closed Then
            Cnn.ConnectionString = Str
            Cnn.Open()
        End If

        Try
            Cmd = New SqlCommand
            Cmd.Connection = Cnn
            Cmd.CommandText = consulta
            Cmd.CommandType = CommandType.StoredProcedure

            If conTransaccion Then
                Tranx = Cnn.BeginTransaction
                Cmd.Transaction = Tranx
            End If

            If Not hdatos Is Nothing Then
                For Each dato As String In hdatos.Keys
                    'cargo los parametros que le estoy pasando con la Hash
                    Cmd.Parameters.AddWithValue(dato, hdatos(dato))
                Next
            End If

            Dim respuesta As Integer = Cmd.ExecuteNonQuery

            If conTransaccion Then
                Tranx.Commit()
            End If

            Return True
        Catch ex As Exception
            If conTransaccion Then
                Tranx.Rollback()
            End If

            Throw New Exception(ex.Message)
        Finally
            Cnn.Close()
        End Try

    End Function

    Public Function BackupBase(ByVal rutaNombre As String) As Boolean
        Try
            If CnnMaster.State = ConnectionState.Closed Then
                CnnMaster.ConnectionString = Str2
                CnnMaster.Open()
            End If

            Dim consulta As String = "BACKUP DATABASE BalianBolsas " &
                                     "TO DISK = '" & rutaNombre & "'"

            Cmd = New SqlCommand
            Cmd.Connection = CnnMaster
            Cmd.CommandText = consulta
            Cmd.CommandType = CommandType.Text

            Dim respuesta As Integer = Cmd.ExecuteNonQuery

            Return True
        Catch ex As Exception
            Return False
        Finally
            CnnMaster.Close()
        End Try
    End Function

    Public Function RestaurarBase(ByVal rutaNombre As String) As Boolean
        Try
            If CnnMaster.State = ConnectionState.Closed Then
                CnnMaster.ConnectionString = Str2
                CnnMaster.Open()
            End If

            Dim consulta As String = "Alter Database BalianBolsas SET SINGLE_USER With ROLLBACK IMMEDIATE" & vbCrLf &
                                     "RESTORE DATABASE BalianBolsas " &
                                     "FROM DISK = '" & rutaNombre & "'" & " WITH REPLACE"

            Cmd = New SqlCommand
            Cmd.Connection = CnnMaster
            Cmd.CommandText = consulta
            Cmd.CommandType = CommandType.Text

            Dim respuesta As Integer = Cmd.ExecuteNonQuery

            Return True
        Catch ex As Exception
            Return False
        Finally
            CnnMaster.Close()
        End Try
    End Function
End Class
