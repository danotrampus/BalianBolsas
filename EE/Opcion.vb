Imports System.ComponentModel.DataAnnotations
Public Class Opcion

    Private vId As Integer
    Public Property Id() As Integer
        Get
            Return vId
        End Get
        Set(ByVal value As Integer)
            vId = value
        End Set
    End Property

    Private vValor As String
    Public Property Valor() As String
        Get
            Return vValor
        End Get
        Set(ByVal value As String)
            vValor = value
        End Set
    End Property

    Private vSelecciones As Integer
    Public Property Selecciones() As Integer
        Get
            Return vSelecciones
        End Get
        Set(ByVal value As Integer)
            vSelecciones = value
        End Set
    End Property

End Class
