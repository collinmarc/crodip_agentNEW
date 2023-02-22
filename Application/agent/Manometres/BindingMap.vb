Imports System.Reflection

' Allow binding of controls to indexed properties.
Public Class BindingMap

  ' Keep track of our target object and the parameters
  ' that we want to bind to.
  private _mappedObject   as Object
  private _mappedProperty as String
  private _mappedIndexVal as Object

  public sub new(MappedObject as Object, _
                 PropertyName as string, _
                 IndexValue   as Object )
  
    _mappedObject   = MappedObject
    _mappedProperty = PropertyName
    _mappedIndexVal = IndexValue

  end sub

  ' Provide a non-indexed property for our binding map object.
  ' This will act as the intermediary between the control and
  ' the target object's indexed property.
  public property MapValue as Object
    Get
            Dim pi As PropertyInfo = _mappedObject.GetType.GetProperty(_mappedProperty)
            If pi IsNot Nothing Then
                Dim mi As MethodInfo = pi.GetGetMethod()
                Return mi.Invoke(_mappedObject, New Object() {_mappedIndexVal})
            Else
                Return Nothing
            End If
        End get
    set (Value as Object)
            Dim     pi As PropertyInfo = _mappedObject.GetType.GetProperty(_mappedProperty)
            If pi IsNot Nothing Then
                Dim mi As MethodInfo = pi.GetSetMethod()
                mi.Invoke(_mappedObject, New Object() {_mappedIndexVal, Value})
            End If
        End set
  end property
  
    
End Class

'' Simple test class with a 'simple' property an a couple of indexex properties.
'Public Class test

'    ' Underlying property values .
'    private _a        as string
'    ' And here's why we might want an indexed property. We have 
'    ' an underlying property represented in an array or other set.
'    private _group()  as string
'    private _t0       as Date
'    private _t1       as Date

'    ' Provide the event handlers for the binding round trip.
'    public event UnadornedChanged as EventHandler
'    public event SelectableChanged as EventHandler
'    public event DateChanged as EventHandler

'    public sub new()
'        ' Initialise the members for the sake of example.
'        _a = "EYY"
'        _group = new String() {"BEE", "KAY"}
'        _t0 = Date.Now
'        _t1 = _t0.AddYears(1)
'    end sub

'    ' An indexer for our 'fancy' string property...
'    Public Enum Index
'        Beta
'        Kappa
'    End Enum


'    ' Penny plain...
'    public property Unadorned as String
'      get
'        return _a
'      end get
'      set(Value as String)
'        _a = Value
'      end set
'    end property

'    '... and twopence coloured.
'    Public Property Selectable(ByVal pick As Index) As String
'        Get

'            If pick = Index.Kappa Then
'                Return _group(1)
'            Else
'                Return _group(0)
'            End If

'        End Get
'        Set(ByVal Value As String)

'            If pick = Index.Kappa Then
'                _group(1) = Value
'            Else
'                _group(0) = Value
'            End If

'        End Set
'    End Property

'    ' Just to reinforce the point we'll have another indexed property.
'    public property [Date](startDate as Boolean)  as Date
'      get
'        if startDate 
'          return _t0
'        else
'          return _t1
'        end if
'      end get
'      set(Value as Date)
'        if startDate
'          _t0 = Value
'        else
'          _t1 = Value
'        end if
'      end set
'    end property

'    End Class