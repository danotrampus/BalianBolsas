Imports System.ComponentModel.DataAnnotations

<AttributeUsage(AttributeTargets.[Property])> _
Public NotInheritable Class ListaOpcionesRequiredAttribute
    Inherits ValidationAttribute
    Private Const defaultError As String = "'{0}' debe completar alguna opción."
    Public Sub New()
        MyBase.New(defaultError)
    End Sub

    Public Overrides Function IsValid(value As Object) As Boolean
        Dim list As IList = TryCast(value, IList)
        For Each Opcion As EE.Opcion In list
            If Opcion Is Nothing Then
                Return False
            End If
            If Opcion.Valor Is Nothing Then
                Return False
            End If
            If Opcion.Valor.Trim() = "" Then
                Return False
            End If
        Next
        Return (list IsNot Nothing AndAlso list.Count > 0)
    End Function

    Public Overrides Function FormatErrorMessage(name As String) As String
        Return [String].Format(Me.ErrorMessageString, name)
    End Function
End Class
