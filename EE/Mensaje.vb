Imports System.ComponentModel.DataAnnotations
Public Class Mensaje
    Sub New()

    End Sub

    Private vId As Integer
    Public Property Id() As Integer
        Get
            Return vId
        End Get
        Set(ByVal value As Integer)
            vId = value
        End Set
    End Property

    Private vEntradaSalida As String
    Public Property EntradaSalida() As String
        Get
            Return vEntradaSalida
        End Get
        Set(ByVal value As String)
            vEntradaSalida = value
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

    Private vFechaHoraFormateada As String
    Public Property FechaHoraFormateada() As String
        Get
            Return vFechaHoraFormateada
        End Get
        Set(ByVal value As String)
            vFechaHoraFormateada = value
        End Set
    End Property


    Private vMensaje As String
    Public Property Mensaje() As String
        Get
            Return vMensaje
        End Get
        Set(ByVal value As String)
            vMensaje = value
        End Set
    End Property

    Private vGrupo As String
    Public Property Grupo() As String
        Get
            Return vGrupo
        End Get
        Set(ByVal value As String)
            vGrupo = value
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