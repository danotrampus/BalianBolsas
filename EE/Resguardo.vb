Imports System.ComponentModel.DataAnnotations
Public Class Resguardo

    Private vId As Integer
    Public Property Id() As Integer
        Get
            Return vId
        End Get
        Set(ByVal value As Integer)
            vId = value
        End Set
    End Property

    Private vTipo As String
    Public Property Tipo() As String
        Get
            Return vTipo
        End Get
        Set(ByVal value As String)
            vTipo = value
        End Set
    End Property


    Private vFechaHora As DateTime
    Public Property FechaHora() As DateTime
        Get
            Return vFechaHora
        End Get
        Set(ByVal value As DateTime)
            vFechaHora = value
        End Set
    End Property

    Private vRutaNombre As String
    <Required(ErrorMessage:="Campo requerido"), Display(Name:="Ruta")>
    Public Property RutaNombre() As String
        Get
            Return vRutaNombre
        End Get
        Set(ByVal value As String)
            vRutaNombre = value
        End Set
    End Property

    Private vUsuario As Usuario
    Public Property Usuario() As Usuario
        Get
            Return vUsuario
        End Get
        Set(ByVal value As Usuario)
            vUsuario = value
        End Set
    End Property

End Class
