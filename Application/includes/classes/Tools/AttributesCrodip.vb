
<System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple:=True)>
Public Class importCrodipAtt
    Inherits System.Attribute
    Public Enum enumCRODIPClass As Integer
        EXPLOITATION
        PULVERISATEUR
        DIAGNOSTIC
    End Enum
    Public Property sourceProperty As String
    Public Property targetClass As enumCRODIPClass
    Public Property targetProperty As String

    Public Sub New(pTargetClass As enumCRODIPClass, pTargetProperty As String)
        Me.sourceProperty = ""
        Me.targetClass = pTargetClass
        Me.targetProperty = pTargetProperty
    End Sub
    Public Sub New(pTargetClass As enumCRODIPClass)
        Me.sourceProperty = ""
        Me.targetClass = pTargetClass
        Me.targetProperty = ""
    End Sub
End Class