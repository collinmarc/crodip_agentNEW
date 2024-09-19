
Imports System.Collections.Generic
Imports System.ComponentModel

Public Class SortableBindingList(Of T)
    Inherits BindingList(Of T)
    Private ReadOnly comparers As Dictionary(Of Type, PropertyComparer(Of T))
    Private isSorted As Boolean
    Private listSortDirection As ListSortDirection
    Private propertyDescriptor As PropertyDescriptor

    Public Sub New()
        MyBase.New(New List(Of T)())
        Me.comparers = New Dictionary(Of Type, PropertyComparer(Of T))()
    End Sub

    Public Sub New(enumeration As IEnumerable(Of T))
        MyBase.New(New List(Of T)(enumeration))
        Me.comparers = New Dictionary(Of Type, PropertyComparer(Of T))()
    End Sub

    ''' <summary>
    ''' Ajout d'une liste d'item
    ''' </summary>
    ''' <param name="pList"></param>
    ''' <remarks></remarks>
    Public Sub AddList(pList As List(Of T))
        For Each oItem As T In pList
            Add(oItem)
        Next
    End Sub
    Protected Overrides ReadOnly Property SupportsSortingCore() As Boolean
        Get
            Return True
        End Get
    End Property

    Protected Overrides ReadOnly Property IsSortedCore() As Boolean
        Get
            Return Me.isSorted
        End Get
    End Property

    Protected Overrides ReadOnly Property SortPropertyCore() As PropertyDescriptor
        Get
            Return Me.propertyDescriptor
        End Get
    End Property

    Protected Overrides ReadOnly Property SortDirectionCore() As ListSortDirection
        Get
            Return Me.listSortDirection
        End Get
    End Property

    Protected Overrides ReadOnly Property SupportsSearchingCore() As Boolean
        Get
            Return True
        End Get
    End Property

    Protected Overrides Sub ApplySortCore([property] As PropertyDescriptor, direction As ListSortDirection)
        Dim itemsList As List(Of T) = DirectCast(Me.Items, List(Of T))

        Dim propertyType As Type = [property].PropertyType
        Dim comparer As PropertyComparer(Of T) = Nothing
        If Not Me.comparers.TryGetValue(propertyType, comparer) Then
            comparer = New PropertyComparer(Of T)([property], direction)
            Me.comparers.Add(propertyType, comparer)
        End If

        comparer.SetPropertyAndDirection([property], direction)
        itemsList.Sort(comparer)

        Me.propertyDescriptor = [property]
        Me.listSortDirection = direction
        Me.isSorted = True

        Me.OnListChanged(New ListChangedEventArgs(ListChangedType.Reset, -1))
    End Sub

    Protected Overrides Sub RemoveSortCore()
        Me.isSorted = False
        Me.propertyDescriptor = MyBase.SortPropertyCore
        Me.listSortDirection = MyBase.SortDirectionCore

        Me.OnListChanged(New ListChangedEventArgs(ListChangedType.Reset, -1))
    End Sub

    Protected Overrides Function FindCore([property] As PropertyDescriptor, key As Object) As Integer
        Dim count As Integer = Me.Count
        For i As Integer = 0 To count - 1
            Dim element As T = Me(i)
            If [property].GetValue(element).Equals(key) Then
                Return i
            End If
        Next

        Return -1
    End Function
End Class

