Imports System.ComponentModel.DataAnnotations
Public MustInherit Class Producto

    Protected vImagen As String
    Public Property Imagen() As String
        Get
            Return vImagen
        End Get
        Set(ByVal value As String)
            vImagen = value
        End Set
    End Property

    Protected vId As Integer
    Public Property Id() As Integer
        Get
            Return vId
        End Get
        Set(ByVal value As Integer)
            vId = value
        End Set
    End Property

    Protected vAncho As Integer
    Public Property Ancho() As Integer
        Get
            Return vAncho
        End Get
        Set(ByVal value As Integer)
            vAncho = value
        End Set
    End Property

    Protected vLargo As Integer
    Public Property Largo() As Integer
        Get
            Return vLargo
        End Get
        Set(ByVal value As Integer)
            vLargo = value
        End Set
    End Property

    Protected vEspesor As Integer
    Public Property Espesor() As Integer
        Get
            Return vEspesor
        End Get
        Set(ByVal value As Integer)
            vEspesor = value
        End Set
    End Property

    Protected vSoldadura As String
    Public Property Soldadura() As String
        Get
            Return vSoldadura
        End Get
        Set(ByVal value As String)
            vSoldadura = value
        End Set
    End Property

    Protected vFormato As String
    Public Property Formato() As String
        Get
            Return vFormato
        End Get
        Set(ByVal value As String)
            vFormato = value
        End Set
    End Property

    Protected vPolimero As New Polimero
    Public Property Polimero() As Polimero
        Get
            Return vPolimero
        End Get
        Set(ByVal value As Polimero)
            vPolimero = value
        End Set
    End Property

    Protected vImpresion As New Impresion
    Public Property Impresion() As Impresion
        Get
            Return vImpresion
        End Get
        Set(ByVal value As Impresion)
            vImpresion = value
        End Set
    End Property

    Private vValoracion As Integer
    Public Property Valoracion() As Integer
        Get
            Return vValoracion
        End Get
        Set(ByVal value As Integer)
            vValoracion = value
        End Set
    End Property

    Private vListaComentarios As New List(Of Comentario)
    Public Property ListaComentarios() As List(Of Comentario)
        Get
            Return vListaComentarios
        End Get
        Set(ByVal value As List(Of Comentario))
            vListaComentarios = value
        End Set
    End Property

    Public MustOverride Function CalcularPrecio() As Double

    Public MustOverride Function CalcularIva() As Double

    Public MustOverride Function CalcularPrecioConIva() As Double

    Public MustOverride Function CalcularCosto() As Double

    Public MustOverride Function ObtenerDescripcionMedidas() As String

    Public MustOverride Function ObtenerNombre() As String

    Public Function ObtenerDescripcionImpresion() As String
        If Me.Impresion IsNot Nothing Then
            If Me.Impresion.Id <> 0 Then
                Return Me.Impresion.Nombre
            End If
        End If
        Return ""
    End Function

    Public MustOverride Function CrearOrdenesProduccion(ByVal cantidad As Integer) As List(Of OrdenProduccion)

End Class
