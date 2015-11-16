Imports System.ComponentModel.DataAnnotations
Public Class Usuario

    Private vId As Integer
    Public Property Id() As Integer
        Get
            Return vId
        End Get
        Set(ByVal value As Integer)
            vId = value
        End Set
    End Property

    Private vNombre As String
    <Required(ErrorMessage:="Campo requerido"), Display(Name:="Nombre")>
    <StringLength(50, ErrorMessage:="Longitud máxima de 50 caracteres")>
    Public Property Nombre() As String
        Get
            Return vNombre
        End Get
        Set(ByVal value As String)
            vNombre = value
        End Set
    End Property

    Private vApellido As String
    <Required(ErrorMessage:="Campo requerido"), Display(Name:="Apellido")>
    <StringLength(50, ErrorMessage:="Longitud máxima de 50 caracteres")>
    Public Property Apellido() As String
        Get
            Return vApellido
        End Get
        Set(ByVal value As String)
            vApellido = value
        End Set
    End Property

    Private vEmail As String
    <Required(ErrorMessage:="Campo requerido"), Display(Name:="Email")>
    <StringLength(50, ErrorMessage:="Longitud máxima de 50 caracteres")>
    <EmailAddress(ErrorMessage:="Formato incorrecto")>
    Public Property Email() As String
        Get
            Return vEmail
        End Get
        Set(ByVal value As String)
            vEmail = value
        End Set
    End Property

    Private vNombreUsuario As String
    <Required(ErrorMessage:="Campo requerido"), Display(Name:="Nombre de usuario")>
    <StringLength(50, ErrorMessage:="Longitud máxima de 50 caracteres")>
    Public Property NombreUsuario() As String
        Get
            Return vNombreUsuario
        End Get
        Set(ByVal value As String)
            vNombreUsuario = value
        End Set
    End Property

    Private vClave As String
    <Required(ErrorMessage:="Campo requerido"), Display(Name:="Contraseña")>
    <StringLength(50, ErrorMessage:="Longitud máxima de 50 caracteres")>
    Public Property Clave() As String
        Get
            Return vClave
        End Get
        Set(ByVal value As String)
            vClave = value
        End Set
    End Property

    Private vActivo As Boolean
    Public Property Activo() As Boolean
        Get
            Return vActivo
        End Get
        Set(ByVal value As Boolean)
            vActivo = value
        End Set
    End Property

    Private vTelefono As String
    Public Property Telefono() As String
        Get
            Return vTelefono
        End Get
        Set(ByVal value As String)
            vTelefono = value
        End Set
    End Property


    Private vPerfilesId As New List(Of Integer)
    <ListRequired(ErrorMessage:="Campo requerido"), Display(Name:="Perfiles")>
    Public Property PerfilesId() As List(Of Integer)
        Get
            Return vPerfilesId
        End Get
        Set(ByVal value As List(Of Integer))
            vPerfilesId = value
        End Set
    End Property

    Private vListaPerfiles As New List(Of Perfil)
    Public Property ListaPerfiles() As List(Of Perfil)
        Get
            Return vListaPerfiles
        End Get
        Set(ByVal value As List(Of Perfil))
            vListaPerfiles = value
        End Set
    End Property

    Private vTokenActivacion As String
    Public Property TokenActivacion() As String
        Get
            Return vTokenActivacion
        End Get
        Set(ByVal value As String)
            vTokenActivacion = value
        End Set
    End Property

    Private vListaMovimientos As New List(Of Movimiento)
    Public Property ListaMovimientos() As List(Of Movimiento)
        Get
            Return vListaMovimientos
        End Get
        Set(ByVal value As List(Of Movimiento))
            vListaMovimientos = value
        End Set
    End Property

    Private vListaPedidos As New List(Of Pedido)
    Public Property ListaPedidos() As List(Of Pedido)
        Get
            Return vListaPedidos
        End Get
        Set(ByVal value As List(Of Pedido))
            vListaPedidos = value
        End Set
    End Property

    Public ReadOnly Property TotalMovimientos() As Double
        Get
            Dim valor As Double = 0
            For Each m As Movimiento In Me.ListaMovimientos
                valor += m.ObtenerImporte()
            Next
            Return valor
        End Get
    End Property

End Class
