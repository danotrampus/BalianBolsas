Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Public MustInherit Class BaseViewPage
    Inherits WebViewPage
    Public Overridable Shadows ReadOnly Property User() As CustomPrincipal
        Get
            Return TryCast(MyBase.User, CustomPrincipal)
        End Get
    End Property
End Class

Public MustInherit Class BaseViewPage(Of TModel)
    Inherits WebViewPage(Of TModel)
    Public Overridable Shadows ReadOnly Property User() As CustomPrincipal
        Get
            Return TryCast(MyBase.User, CustomPrincipal)
        End Get
    End Property
End Class