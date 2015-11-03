Imports System.ComponentModel.DataAnnotations
Public MustInherit Class Producto

    Private vType As String
    Public Property Type() As String
        Get
            Return vType
        End Get
        Set(ByVal value As String)
            vType = value
        End Set
    End Property

    Private vImagen As String
    Public Property Imagen() As String
        Get
            Return vImagen
        End Get
        Set(ByVal value As String)
            vImagen = value
        End Set
    End Property

    Private vId As Integer
    Public Property Id() As Integer
        Get
            Return vId
        End Get
        Set(ByVal value As Integer)
            vId = value
        End Set
    End Property

    Private vAncho As Integer
    <Required(ErrorMessage:="Campo requerido")>
    Public Property Ancho() As Integer
        Get
            Return vAncho
        End Get
        Set(ByVal value As Integer)
            vAncho = value
        End Set
    End Property

    Private vLargo As Integer
    Public Property Largo() As Integer
        Get
            Return vLargo
        End Get
        Set(ByVal value As Integer)
            vLargo = value
        End Set
    End Property

    Private vEspesor As Integer
    <Required(ErrorMessage:="Campo requerido")>
    Public Property Espesor() As Integer
        Get
            Return vEspesor
        End Get
        Set(ByVal value As Integer)
            vEspesor = value
        End Set
    End Property

    Private vSoldadura As String
    <Required(ErrorMessage:="Campo requerido")>
    Public Property Soldadura() As String
        Get
            Return vSoldadura
        End Get
        Set(ByVal value As String)
            vSoldadura = value
        End Set
    End Property

    Private vFormato As String
    <Required(ErrorMessage:="Campo requerido")>
    Public Property Formato() As String
        Get
            Return vFormato
        End Get
        Set(ByVal value As String)
            vFormato = value
        End Set
    End Property

    Private vPolimero As New Polimero
    Public Property Polimero() As Polimero
        Get
            Return vPolimero
        End Get
        Set(ByVal value As Polimero)
            vPolimero = value
        End Set
    End Property

    Private vImpresion As Impresion
    Public Property Impresion() As Impresion
        Get
            Return vImpresion
        End Get
        Set(ByVal value As Impresion)
            vImpresion = value
        End Set
    End Property

    Public MustOverride Function CalcularPrecio() As Double

    Public MustOverride Function CalcularCosto() As Double

    Public MustOverride Function ObtenerDescripcionMedidas() As String

    Public Function ObtenerDescripcionImpresion() As String
        If Me.Impresion IsNot Nothing Then
            Return Me.Impresion.Nombre
        End If
        Return ""
    End Function

End Class
