Imports System.ComponentModel.DataAnnotations
Public Class Polimero
    Inherits MateriaPrima

    Private vDensidad As Double
    <Required(ErrorMessage:="Campo requerido"), RegularExpression("^(\d{1}(\,\d{0,6})?)$", ErrorMessage:="Formato incorrecto")>
    Public Property Densidad() As Double
        Get
            Return vDensidad
        End Get
        Set(ByVal value As Double)
            vDensidad = value
        End Set
    End Property

End Class
