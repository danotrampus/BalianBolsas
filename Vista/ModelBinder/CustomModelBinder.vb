Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Reflection
Imports System.Collections
Imports System.ComponentModel
Imports System.Globalization
Imports System.Diagnostics
Imports EE

Public Class CustomModelBinder
    Inherits DefaultModelBinder
    Protected Overrides Function CreateModel(controllerContext As ControllerContext, bindingContext As ModelBindingContext, modelType As Type) As Object
        Dim type As Type = modelType
        If modelType.IsGenericType Then
            Dim genericTypeDefinition As Type = modelType.GetGenericTypeDefinition()
            If genericTypeDefinition = GetType(IDictionary(Of ,)) Then
                type = GetType(Dictionary(Of ,)).MakeGenericType(modelType.GetGenericArguments())
            ElseIf ((genericTypeDefinition = GetType(IEnumerable(Of ))) OrElse (genericTypeDefinition = GetType(ICollection(Of )))) OrElse (genericTypeDefinition = GetType(IList(Of ))) Then
                type = GetType(List(Of )).MakeGenericType(modelType.GetGenericArguments())
            End If
            Return Activator.CreateInstance(type)
        ElseIf modelType.IsAbstract Then
            Dim concreteTypeName As String = bindingContext.ModelName + "Type"
            Dim concreteTypeResult = bindingContext.ValueProvider.GetValue(concreteTypeName)

            If concreteTypeResult Is Nothing Then
                Throw New Exception("Concrete type for abstract class not specified")
            End If

            type = Assembly.GetExecutingAssembly().GetTypes().SingleOrDefault(Function(t) t.IsSubclassOf(modelType) AndAlso t.Name = concreteTypeResult.AttemptedValue)

            If type Is Nothing Then
                'Attempt to load assembly from EE namespace
                For Each assemblyName As AssemblyName In assembly.GetExecutingAssembly().GetReferencedAssemblies()
                    If type Is Nothing Then
                        Dim assembly As Assembly = assembly.Load(assemblyName)
                        type = assembly.GetTypes().SingleOrDefault(Function(t) t.IsSubclassOf(modelType) AndAlso t.Name = concreteTypeResult.AttemptedValue)
                    End If
                Next
                If type Is Nothing Then
                    Throw New Exception([String].Format("Concrete model type {0} not found", concreteTypeResult.AttemptedValue))
                End If
            End If

            Dim instance = Activator.CreateInstance(type)
            bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(Function() instance, type)
            Return instance
        Else
            Return Activator.CreateInstance(modelType)
        End If
    End Function
End Class

