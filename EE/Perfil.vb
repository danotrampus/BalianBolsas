Imports System.ComponentModel.DataAnnotations
Public Class Perfil

    Private vId As Integer
    Public Property Id() As Integer
        Get
            Return vId
        End Get
        Set(ByVal value As Integer)
            vId = value
        End Set
    End Property

    Private vNombre As String
    <Required(ErrorMessage:="Campo requerido"), Display(Name:="Nombre")>
    Public Property Nombre() As String
        Get
            Return vNombre
        End Get
        Set(ByVal value As String)
            vNombre = value
        End Set
    End Property

    Private vListaPermisos As List(Of Permiso)
    <Display(Name:="Lista de permisos")>
    Public Property ListaPermisos() As List(Of Permiso)
        Get
            Return vListaPermisos
        End Get
        Set(ByVal value As List(Of Permiso))
            vListaPermisos = value
        End Set
    End Property


End Class
