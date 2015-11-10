Imports System.ComponentModel.DataAnnotations
Public Class BolsaViewModel

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
    <Required(ErrorMessage:="Campo requerido"), Display(Name:="Ancho (cm)")>
    Public Property Ancho() As Integer
        Get
            Return vAncho
        End Get
        Set(ByVal value As Integer)
            vAncho = value
        End Set
    End Property

    Private vLargo As Integer
    <Required(ErrorMessage:="Campo requerido"), Display(Name:="Largo (cm)")>
    Public Property Largo() As Integer
        Get
            Return vLargo
        End Get
        Set(ByVal value As Integer)
            vLargo = value
        End Set
    End Property

    Private vEspesor As Integer
    <Required(ErrorMessage:="Campo requerido"), Display(Name:="Espesor (µm)")>
    Public Property Espesor() As Integer
        Get
            Return vEspesor
        End Get
        Set(ByVal value As Integer)
            vEspesor = value
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

    Private vManijaId As Integer
    <Required(ErrorMessage:="Campo requerido"), Display(Name:="Manija")>
    Public Property ManijaId() As Integer
        Get
            Return vManijaId
        End Get
        Set(ByVal value As Integer)
            vManijaId = value
        End Set
    End Property

    Private vPolimeroId As Integer
    <Required(ErrorMessage:="Campo requerido"), Display(Name:="Polimero")>
    Public Property PolimeroId() As Integer
        Get
            Return vPolimeroId
        End Get
        Set(ByVal value As Integer)
            vPolimeroId = value
        End Set
    End Property

    Private vImpresionId As Integer
    <Display(Name:="Impresión")>
    Public Property ImpresionId() As Integer
        Get
            Return vImpresionId
        End Get
        Set(ByVal value As Integer)
            vImpresionId = value
        End Set
    End Property

    Private vImagen As HttpPostedFileBase
    <Required(ErrorMessage:="Campo requerido"), Display(Name:="Imagen")>
    Public Property Imagen() As HttpPostedFileBase
        Get
            Return vImagen
        End Get
        Set(ByVal value As HttpPostedFileBase)
            vImagen = value
        End Set
    End Property

End Class
