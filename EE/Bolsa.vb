Public Class Bolsa
    Inherits Producto

    Public Overrides Function CalcularCosto() As Double
        Dim volumen, pesoEspecifico, costoMateriaPrima, costoImpresion As Double
        volumen = Me.Ancho * Me.Largo * Me.Espesor
        pesoEspecifico = volumen * Me.Polimero.Densidad
        costoMateriaPrima = pesoEspecifico * Me.Polimero.Precio
        If Me.Impresion IsNot Nothing Then
            costoImpresion = Me.Impresion.Precio / (100 / Me.Largo)
        Else
            costoImpresion = 0
        End If
        Return Math.Round((costoImpresion + costoMateriaPrima) / 1000, 3)
    End Function

    Public Overrides Function CalcularPrecio() As Double
        Return Me.CalcularCosto() * 2
    End Function

    Public Overrides Function ObtenerDescripcionMedidas() As String
        Return Me.Ancho.ToString() + "*" + Me.Largo.ToString() + "/" + Me.Espesor.ToString()
    End Function

End Class
