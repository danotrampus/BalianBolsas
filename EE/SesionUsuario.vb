Public Class SesionUsuario

    Private Shared instancia As SesionUsuario
    Private usuario As Usuario

    Private Sub New()
    End Sub

    Public Shared ReadOnly Property Instance() As SesionUsuario
        Get
            If IsNothing(instancia) Then
                instancia = New SesionUsuario()
            End If
            Return instancia
        End Get
    End Property

    Private vUsuarioActual As Usuario
    Public Property UsuarioActual() As Usuario
        Get
            Return vUsuarioActual
        End Get
        Set(ByVal value As Usuario)
            vUsuarioActual = value
        End Set
    End Property

End Class