Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports EE
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class PermisoConverter
    Inherits JsonConverter

    Public Overrides Function CanConvert(objectType As Type) As Boolean
        Dim type As Type = GetType(List(Of Permiso))
        If objectType = type Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Overrides Function ReadJson(reader As JsonReader, objectType As Type, existingValue As Object, serializer As JsonSerializer) As Object
        Dim itemArray = serializer.Deserialize(Of JArray)(reader)
        Dim result As New List(Of Permiso)

        For Each item As JObject In itemArray
            If item.Property("isParent").Value.ToObject(Of Boolean)() Then
                Dim permiso As New Familia()
                permiso.Id = item.Property("Id").Value.ToObject(Of Integer)()
                permiso.Descripcion = item.Property("Descripcion").Value.ToObject(Of String)()
                permiso.Habilitado = item.Property("Habilitado").Value.ToObject(Of Boolean)()
                permiso.ListaPermisos = Me.ObtenerHijos(DirectCast(item.Property("ListaPermisos").Value, JArray))
                result.Add(permiso)
            Else
                Dim permiso As New Patente()
                permiso.Id = item.Property("Id").Value.ToObject(Of Integer)()
                permiso.Descripcion = item.Property("Descripcion").Value.ToObject(Of String)()
                permiso.Habilitado = item.Property("Habilitado").Value.ToObject(Of Boolean)()
                result.Add(permiso)
            End If
        Next

        Return result
    End Function

    Private Function ObtenerHijos(ByVal array As JArray) As List(Of Permiso)
        Dim hijos As New List(Of Permiso)
        For Each item As JObject In array
            If item.Property("isParent").Value.ToObject(Of Boolean)() Then
                Dim permiso As New Familia()
                permiso.Id = item.Property("Id").Value.ToObject(Of Integer)()
                permiso.Descripcion = item.Property("Descripcion").Value.ToObject(Of String)()
                permiso.Habilitado = item.Property("Habilitado").Value.ToObject(Of Boolean)()
                permiso.ListaPermisos = Me.ObtenerHijos(DirectCast(item.Property("ListaPermisos").Value, JArray))
                hijos.Add(permiso)
            Else
                Dim permiso As New Patente()
                permiso.Id = item.Property("Id").Value.ToObject(Of Integer)()
                permiso.Descripcion = item.Property("Descripcion").Value.ToObject(Of String)()
                permiso.Habilitado = item.Property("Habilitado").Value.ToObject(Of Boolean)()
                hijos.Add(permiso)
            End If
        Next
        Return hijos
    End Function

    Public Overrides Sub WriteJson(writer As JsonWriter, value As Object, serializer As JsonSerializer)
        Throw New NotImplementedException()
    End Sub
End Class