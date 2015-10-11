Imports System.ComponentModel.DataAnnotations

<AttributeUsage(AttributeTargets.[Property])> _
Public NotInheritable Class ListRequiredAttribute
    Inherits ValidationAttribute
    Private Const defaultError As String = "'{0}' debe seleccionar al menos un elemento."
    Public Sub New()
        MyBase.New(defaultError)
    End Sub

    Public Overrides Function IsValid(value As Object) As Boolean
        Dim list As IList = TryCast(value, IList)
        Return (list IsNot Nothing AndAlso list.Count > 0)
    End Function

    Public Overrides Function FormatErrorMessage(name As String) As String
        Return [String].Format(Me.ErrorMessageString, name)
    End Function
End Class
