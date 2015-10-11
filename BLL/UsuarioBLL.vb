Imports MPP
Imports EE
Imports Servicios
Public Class UsuarioBLL

    Private vMapper As UsuarioMapper
    Private vCryptoServicio As CryptoServicio
    Sub New()
        Me.vMapper = New UsuarioMapper()
        Me.vCryptoServicio = New CryptoServicio()
    End Sub

    Public Function Crear(ByVal u As Usuario) As Boolean
        u.Activo = True
        u.Clave = Me.vCryptoServicio.EncryptData(u.Clave)
        Return vMapper.Crear(u)
    End Function

    Public Function Registrar(ByVal u As Usuario, ByVal uri As String) As Boolean
        Dim token As String = Guid.NewGuid.ToString()
        MailServicio.EnviarMail(u.Email, "Activación de Cuenta", "<html><head></head><body>Su cuenta ya ha sido creada.<br/>Solamente le queda hacer click en el siguiente link para activarla:<br/><a href='" + uri + "Usuario/Activar/" + token + "'>Haga click aquí</a></body>")
        u.Clave = Me.vCryptoServicio.EncryptData(u.Clave)
        u.Activo = False
        u.TokenActivacion = token
        Return vMapper.Crear(u)
    End Function

    Public Function Editar(ByVal u As Usuario) As Boolean
        Return vMapper.Editar(u)
    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean
        Return vMapper.Eliminar(id)
    End Function

    Public Function Listar() As List(Of Usuario)
        Return vMapper.Listar()
    End Function

    Public Function ConsultarPorId(ByVal id As Integer) As Usuario
        Dim u As Usuario = vMapper.ConsultarPorId(id)
        u.Clave = Me.vCryptoServicio.DecryptData(u.Clave)
        Return u
    End Function

    Public Function ConsultarPorNombreYClave(ByVal nombreUsuario As String, ByVal clave As String) As Usuario
        Return vMapper.ConsultarPorNombreYClave(nombreUsuario, Me.vCryptoServicio.EncryptData(clave))
    End Function

    Public Function Activar(ByVal token As String) As Boolean
        Return vMapper.Activar(token)
    End Function

    Public Function EnviarClave(ByVal email As String) As Boolean
        Dim u As Usuario = Me.vMapper.ConsultarPorEmail(email)
        If u IsNot Nothing Then
            u.Clave = Me.vCryptoServicio.DecryptData(u.Clave)
            MailServicio.EnviarMail(u.Email, "Recuperación de Clave", "<html><head></head><body>Su clave es la siguiente: " + u.Clave + "</body>")
            Return True
        End If
        Return False
    End Function

    Public Function CambiarClave(ByVal id As Integer, ByVal clave As String, ByVal mail As String) As Boolean
        clave = Me.vCryptoServicio.EncryptData(clave)
        If Me.vMapper.CambiarClave(id, clave) Then
            MailServicio.EnviarMail(mail, "Cambio de Clave", "<html><head></head><body>Se modificó la contraseña de su cuenta recientemente.</body>")
            Return True
        Else
            Return False
        End If
    End Function

    Public Function VerificarExistenciaPorNombreUsuario(ByVal nombreusuario As String) As Boolean
        Return Me.vMapper.VerificarExistenciaPorNombreUsuario(nombreusuario)
    End Function

    Public Function VerificarExistenciaPorEmail(ByVal email As String) As Boolean
        Return Me.vMapper.VerificarExistenciaPorEmail(email)
    End Function
End Class
