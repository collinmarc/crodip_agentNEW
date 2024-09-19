
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Reflection

Public Class PropertyComparer(Of T)
    Implements IComparer(Of T)
    Private ReadOnly comparer As IComparer
    Private propertyDescriptor As PropertyDescriptor
    Private reverse As Integer

    Public Sub New([property] As PropertyDescriptor, direction As ListSortDirection)
        Me.propertyDescriptor = [property]
        Dim comparerForPropertyType As Type = GetType(Comparer(Of )).MakeGenericType([property].PropertyType)
        Me.comparer = DirectCast(comparerForPropertyType.InvokeMember("Default", BindingFlags.[Static] Or BindingFlags.GetProperty Or BindingFlags.[Public], Nothing, Nothing, Nothing), IComparer)
        Me.SetListSortDirection(direction)
    End Sub

#Region "IComparer<T> Members"

    Public Function Compare(x As T, y As T) As Integer Implements IComparer(Of T).Compare
        Return Me.reverse * Me.comparer.Compare(Me.propertyDescriptor.GetValue(x), Me.propertyDescriptor.GetValue(y))
    End Function

#End Region

    Private Sub SetPropertyDescriptor(descriptor As PropertyDescriptor)
        Me.propertyDescriptor = descriptor
    End Sub

    Private Sub SetListSortDirection(direction As ListSortDirection)
        Me.reverse = If(direction = ListSortDirection.Ascending, 1, -1)
    End Sub

    Public Sub SetPropertyAndDirection(descriptor As PropertyDescriptor, direction As ListSortDirection)
        Me.SetPropertyDescriptor(descriptor)
        Me.SetListSortDirection(direction)
    End Sub
End Class

