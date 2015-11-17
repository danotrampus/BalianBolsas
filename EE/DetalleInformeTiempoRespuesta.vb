Public Class DetalleInformeTiempoRespuesta

    Private vNOrden As Integer
    Public Property NOrden() As Integer
        Get
            Return vNOrden
        End Get
        Set(ByVal value As Integer)
            vNOrden = value
        End Set
    End Property

    Private vFechaInicio As Date
    Public Property FechaInicio() As Date
        Get
            Return vFechaInicio
        End Get
        Set(ByVal value As Date)
            vFechaInicio = value
        End Set
    End Property

    Private vFechaFin As Date
    Public Property FechaFin() As Date
        Get
            Return vFechaFin
        End Get
        Set(ByVal value As Date)
            vFechaFin = value
        End Set
    End Property

    Public ReadOnly Property Diferencia As Double
        Get
            Return (Me.FechaFin - Me.FechaInicio).TotalSeconds
        End Get
    End Property

    Public ReadOnly Property Tiempo As TimeSpan
        Get
            Return TimeSpan.FromSeconds(Me.Diferencia)
        End Get
    End Property

End Class
