Public Class Direccion

    Private vCalle As String
    Public Property Calle() As String
        Get
            Return vCalle
        End Get
        Set(ByVal value As String)
            vCalle = value
        End Set
    End Property

    Private vNumero As String
    Public Property Numero() As String
        Get
            Return vNumero
        End Get
        Set(ByVal value As String)
            vNumero = value
        End Set
    End Property

    Private vDptoPiso As String
    Public Property DptoPiso() As String
        Get
            Return vDptoPiso
        End Get
        Set(ByVal value As String)
            vDptoPiso = value
        End Set
    End Property

    Private vLocalidad As String
    Public Property Localidad() As String
        Get
            Return vLocalidad
        End Get
        Set(ByVal value As String)
            vLocalidad = value
        End Set
    End Property

    Public ReadOnly Property Descripcion As String
        Get
            Return Me.Calle + " " + Me.Numero + " " + Me.DptoPiso + ", " + Me.Localidad
        End Get
    End Property

End Class
