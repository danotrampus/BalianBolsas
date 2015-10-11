Imports System.ComponentModel.DataAnnotations
Public Class CambioClaveViewModel

    Private vClaveVieja As String
    <Required(ErrorMessage:="Campo requerido"), Display(Name:="Contraseña anterior")>
    <StringLength(50, ErrorMessage:="Se ha superado la longitud permitida de 50 caracteres.")>
    Public Property ClaveVieja() As String
        Get
            Return vClaveVieja
        End Get
        Set(ByVal value As String)
            vClaveVieja = value
        End Set
    End Property

    Private vClaveNueva As String
    <Required(ErrorMessage:="Campo requerido"), Display(Name:="Contraseña nueva")>
    <StringLength(50, ErrorMessage:="Se ha superado la longitud permitida de 50 caracteres.")>
    Public Property ClaveNueva() As String
        Get
            Return vClaveNueva
        End Get
        Set(ByVal value As String)
            vClaveNueva = value
        End Set
    End Property

    Private vRepetirClave As String
    <Compare("ClaveNueva", ErrorMessage:="Las contraseñas deben ser iguales."), Display(Name:="Repita la contraseña")>
    <StringLength(50, ErrorMessage:="Se ha superado la longitud permitida de 50 caracteres.")>
    Public Property RepetirClave() As String
        Get
            Return vRepetirClave
        End Get
        Set(ByVal value As String)
            vRepetirClave = value
        End Set
    End Property

End Class
