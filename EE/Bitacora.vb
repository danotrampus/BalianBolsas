Imports System.ComponentModel.DataAnnotations
Public Class Bitacora
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

    Private vFechaHora As DateTime
    Public Property FechaHora() As DateTime
        Get
            Return vFechaHora
        End Get
        Set(ByVal value As DateTime)
            vFechaHora = value
        End Set
    End Property

    Private vTipo As TipoEvento
    Public Property Tipo() As TipoEvento
        Get
            Return vTipo
        End Get
        Set(ByVal value As TipoEvento)
            vTipo = value
        End Set
    End Property

    Private vDescripcion As String
    Public Property Descripcion() As String
        Get
            Return vDescripcion
        End Get
        Set(ByVal value As String)
            vDescripcion = value
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

Public Enum TipoEvento
    Advertencia = 0
    Fallo = 1
    Informacion = 2
End Enum