Public Class Bolsa
    Inherits Producto

    Private vManija As New Manija
    Public Property Manija() As Manija
        Get
            Return vManija
        End Get
        Set(ByVal value As Manija)
            vManija = value
        End Set
    End Property

    Public Overrides Function CalcularCosto() As Double
        Dim volumen, pesoEspecifico, costoMateriaPrima, costoImpresion, costoManija As Double
        volumen = Me.Ancho * Me.Largo * Me.Espesor
        pesoEspecifico = volumen * Me.Polimero.Densidad
        costoMateriaPrima = pesoEspecifico * Me.Polimero.Precio
        If Me.Impresion IsNot Nothing Then
            costoImpresion = Me.Impresion.Precio / (100 / Me.Largo)
        Else
            costoImpresion = 0
        End If
        If Me.Manija IsNot Nothing Then
            costoManija = Me.Manija.Precio * 1000
        Else
            costoManija = 0
        End If
        Return Math.Round((costoImpresion + costoMateriaPrima + costoManija) / 1000, 3)
    End Function

    Public Overrides Function CalcularPrecio() As Double
        Return Me.CalcularCosto() * 2
    End Function

    Public Overrides Function ObtenerDescripcionMedidas() As String
        Return Me.Ancho.ToString() + "*" + Me.Largo.ToString() + "/" + Me.Espesor.ToString()
    End Function

    Public Function ObtenerDescripcionManija() As String
        If Me.Manija IsNot Nothing Then
            If Me.Manija.Id <> 0 Then
                Return Me.Manija.Nombre
            End If
        End If
        Return ""
    End Function

    Public Overrides Function ObtenerNombre() As String
        Return Me.ObtenerDescripcionMedidas() + " - " + Me.Soldadura + " - " + Me.Formato + " - " + Me.Polimero.Nombre + " - " + Me.ObtenerDescripcionImpresion() + " - " + Me.ObtenerDescripcionManija()
    End Function

    Public Overrides Function CalcularPrecioConIva() As Double
        Return Math.Round(Me.CalcularPrecio() + Me.CalcularIva(), 3)
    End Function

    Public Overrides Function CalcularIva() As Double
        Return Math.Round(Me.CalcularPrecio() * 0.21, 3)
    End Function

    Public Overrides Function CrearOrdenesProduccion(ByVal cantidad As Integer) As List(Of OrdenProduccion)
        Dim listaOrdenes As New List(Of OrdenProduccion)

        Dim o1 As New OrdenProduccion
        o1.Tipo = "Material"
        o1.Cantidad = Me.Largo * cantidad / 100
        o1.Estado = "Pendiente"
        o1.Producto = Me

        Dim o2 As New OrdenProduccion
        o2.Tipo = "Impresión"
        o2.Cantidad = Me.Largo * cantidad / 100
        o2.Estado = "Pendiente"
        o2.Producto = Me

        Dim o3 As New OrdenProduccion
        o3.Tipo = "Corte y Confección"
        o3.Cantidad = cantidad
        o3.Estado = "Pendiente"
        o3.Producto = Me

        listaOrdenes.AddRange({o1, o2, o3})

        Return listaOrdenes
    End Function
End Class
