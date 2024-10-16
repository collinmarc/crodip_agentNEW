
Imports System.Data.Common

Public Class StatsCrodip

    Private _NCtrlCCInspecteurAnnee As Integer
    Private _NCtrlCCStructureAnnee As Integer
    Private _NCtrlCCInspecteurTotal As Integer
    Private _NCtrlCCStructureTotal As Integer

    Private _NCtrlCC_OK_InspecteurAnnee As Integer
    Private _NCtrlCC_OK_StructureAnnee As Integer
    Private _NCtrlCC_OK_InspecteurTotal As Integer
    Private _NCtrlCC_OK_StructureTotal As Integer
    Private _NCtrlCC_CP_InspecteurAnnee As Integer
    Private _NCtrlCC_CP_StructureAnnee As Integer
    Private _NCtrlCC_CP_InspecteurTotal As Integer
    Private _NCtrlCC_CP_StructureTotal As Integer
    Private _NCtrlCC_ReparAvant_InspecteurAnnee As Integer
    Private _NCtrlCC_ReparAvant_StructureAnnee As Integer
    Private _NCtrlCC_ReparAvant_InspecteurTotal As Integer
    Private _NCtrlCC_ReparAvant_StructureTotal As Integer
    Private _NCtrlCC_AutoControle_InspecteurAnnee As Integer
    Private _NCtrlCC_AutoControle_StructureAnnee As Integer
    Private _NCtrlCC_AutoControle_InspecteurTotal As Integer
    Private _NCtrlCC_AutoControle_StructureTotal As Integer
    Private _NCtrlCC_PreControle_InspecteurAnnee As Integer
    Private _NCtrlCC_PreControle_StructureAnnee As Integer
    Private _NCtrlCC_PreControle_InspecteurTotal As Integer
    Private _NCtrlCC_PreControle_StructureTotal As Integer

    Private _NCtrlCVInspecteurAnnee As Integer
    Private _NCtrlCVStructureAnnee As Integer
    Private _NCtrlCVInspecteurTotal As Integer
    Private _NCtrlCVStructureTotal As Integer

    Private _NCtrlCV_OK_InspecteurAnnee As Integer
    Private _NCtrlCV_OK_StructureAnnee As Integer
    Private _NCtrlCV_OK_InspecteurTotal As Integer
    Private _NCtrlCV_OK_StructureTotal As Integer
    Private _NCtrlCV_CP_InspecteurAnnee As Integer
    Private _NCtrlCV_CP_StructureAnnee As Integer
    Private _NCtrlCV_CP_InspecteurTotal As Integer
    Private _NCtrlCV_CP_StructureTotal As Integer
    Private _NCtrlCV_ReparAvant_InspecteurAnnee As Integer
    Private _NCtrlCV_ReparAvant_StructureAnnee As Integer
    Private _NCtrlCV_ReparAvant_InspecteurTotal As Integer
    Private _NCtrlCV_ReparAvant_StructureTotal As Integer
    Private _NCtrlCV_AutoControle_InspecteurAnnee As Integer
    Private _NCtrlCV_AutoControle_StructureAnnee As Integer
    Private _NCtrlCV_AutoControle_InspecteurTotal As Integer
    Private _NCtrlCV_AutoControle_StructureTotal As Integer
    Private _NCtrlCV_PreControle_InspecteurAnnee As Integer
    Private _NCtrlCV_PreControle_StructureAnnee As Integer
    Private _NCtrlCV_PreControle_InspecteurTotal As Integer
    Private _NCtrlCV_PreControle_StructureTotal As Integer



    Sub New()

    End Sub

    Public Property NCtrlCCInspecteurAnnee As Integer

        Get
            Return _NCtrlCCInspecteurAnnee

        End Get
        Set(ByVal value As Integer)
            _NCtrlCCInspecteurAnnee = value

        End Set
    End Property
    Public Property NCtrlCCInspecteurTotal As Integer

        Get
            Return _NCtrlCCInspecteurTotal

        End Get
        Set(ByVal value As Integer)
            _NCtrlCCInspecteurTotal = value

        End Set
    End Property
    Public Property NCtrlCC_OK_InspecteurAnnee As Integer

        Get
            Return _NCtrlCC_OK_InspecteurAnnee

        End Get
        Set(ByVal value As Integer)
            _NCtrlCC_OK_InspecteurAnnee = value

        End Set
    End Property
    Public Property NCtrlCC_OK_InspecteurTotal As Integer

        Get
            Return _NCtrlCC_OK_InspecteurTotal

        End Get
        Set(ByVal value As Integer)
            _NCtrlCC_OK_InspecteurTotal = value

        End Set
    End Property
    Public Property NCtrlCC_CP_InspecteurAnnee As Integer

        Get
            Return _NCtrlCC_CP_InspecteurAnnee

        End Get
        Set(ByVal value As Integer)
            _NCtrlCC_CP_InspecteurAnnee = value

        End Set
    End Property
    Public Property NCtrlCC_CP_InspecteurTotal As Integer

        Get
            Return _NCtrlCC_CP_InspecteurTotal

        End Get
        Set(ByVal value As Integer)
            _NCtrlCC_CP_InspecteurTotal = value

        End Set
    End Property
    Public Property NCtrlCC_ReparAvant_InspecteurAnnee As Integer

        Get
            Return _NCtrlCC_ReparAvant_InspecteurAnnee

        End Get
        Set(ByVal value As Integer)
            _NCtrlCC_ReparAvant_InspecteurAnnee = value

        End Set
    End Property
    Public Property NCtrlCC_ReparAvant_InspecteurTotal As Integer

        Get
            Return _NCtrlCC_ReparAvant_InspecteurTotal

        End Get
        Set(ByVal value As Integer)
            _NCtrlCC_ReparAvant_InspecteurTotal = value

        End Set
    End Property
    Public Property NCtrlCC_AutoControle_InspecteurAnnee As Integer

        Get
            Return _NCtrlCC_AutoControle_InspecteurAnnee

        End Get
        Set(ByVal value As Integer)
            _NCtrlCC_AutoControle_InspecteurAnnee = value

        End Set
    End Property
    Public Property NCtrlCC_AutoControle_InspecteurTotal As Integer

        Get
            Return _NCtrlCC_AutoControle_InspecteurTotal

        End Get
        Set(ByVal value As Integer)
            _NCtrlCC_AutoControle_InspecteurTotal = value

        End Set
    End Property
    Public Property NCtrlCC_PreControle_InspecteurAnnee As Integer

        Get
            Return _NCtrlCC_PreControle_InspecteurAnnee

        End Get
        Set(ByVal value As Integer)
            _NCtrlCC_PreControle_InspecteurAnnee = value

        End Set
    End Property
    Public Property NCtrlCC_PreControle_InspecteurTotal As Integer

        Get
            Return _NCtrlCC_PreControle_InspecteurTotal

        End Get
        Set(ByVal value As Integer)
            _NCtrlCC_PreControle_InspecteurTotal = value

        End Set
    End Property

    Public Property NCtrlCCStructureAnnee As Integer

        Get
            Return _NCtrlCCStructureAnnee

        End Get
        Set(ByVal value As Integer)
            _NCtrlCCStructureAnnee = value

        End Set
    End Property
    Public Property NCtrlCCStructureTotal As Integer

        Get
            Return _NCtrlCCStructureTotal

        End Get
        Set(ByVal value As Integer)
            _NCtrlCCStructureTotal = value

        End Set
    End Property
    Public Property NCtrlCC_OK_StructureAnnee As Integer

        Get
            Return _NCtrlCC_OK_StructureAnnee

        End Get
        Set(ByVal value As Integer)
            _NCtrlCC_OK_StructureAnnee = value

        End Set
    End Property
    Public Property NCtrlCC_OK_StructureTotal As Integer

        Get
            Return _NCtrlCC_OK_StructureTotal

        End Get
        Set(ByVal value As Integer)
            _NCtrlCC_OK_StructureTotal = value

        End Set
    End Property
    Public Property NCtrlCC_CP_StructureAnnee As Integer

        Get
            Return _NCtrlCC_CP_StructureAnnee

        End Get
        Set(ByVal value As Integer)
            _NCtrlCC_CP_StructureAnnee = value

        End Set
    End Property
    Public Property NCtrlCC_CP_StructureTotal As Integer

        Get
            Return _NCtrlCC_CP_StructureTotal

        End Get
        Set(ByVal value As Integer)
            _NCtrlCC_CP_StructureTotal = value

        End Set
    End Property
    Public Property NCtrlCC_ReparAvant_StructureAnnee As Integer

        Get
            Return _NCtrlCC_ReparAvant_StructureAnnee

        End Get
        Set(ByVal value As Integer)
            _NCtrlCC_ReparAvant_StructureAnnee = value

        End Set
    End Property
    Public Property NCtrlCC_ReparAvant_StructureTotal As Integer

        Get
            Return _NCtrlCC_ReparAvant_StructureTotal

        End Get
        Set(ByVal value As Integer)
            _NCtrlCC_ReparAvant_StructureTotal = value

        End Set
    End Property
    Public Property NCtrlCC_AutoControle_StructureAnnee As Integer

        Get
            Return _NCtrlCC_AutoControle_StructureAnnee

        End Get
        Set(ByVal value As Integer)
            _NCtrlCC_AutoControle_StructureAnnee = value

        End Set
    End Property
    Public Property NCtrlCC_AutoControle_StructureTotal As Integer

        Get
            Return _NCtrlCC_AutoControle_StructureTotal

        End Get
        Set(ByVal value As Integer)
            _NCtrlCC_AutoControle_StructureTotal = value

        End Set
    End Property
    Public Property NCtrlCC_PreControle_StructureAnnee As Integer

        Get
            Return _NCtrlCC_PreControle_StructureAnnee

        End Get
        Set(ByVal value As Integer)
            _NCtrlCC_PreControle_StructureAnnee = value

        End Set
    End Property
    Public Property NCtrlCC_PreControle_StructureTotal As Integer

        Get
            Return _NCtrlCC_PreControle_StructureTotal

        End Get
        Set(ByVal value As Integer)
            _NCtrlCC_PreControle_StructureTotal = value

        End Set
    End Property
    Public ReadOnly Property PctCtrlCC_OK_InspecteurAnnee As String

        Get
            If _NCtrlCCInspecteurAnnee = 0 Then
                Return ""
            Else
                Return Math.Round((_NCtrlCC_OK_InspecteurAnnee / _NCtrlCCInspecteurAnnee) * 100, 2) & " %"
            End If
        End Get
    End Property
    Public ReadOnly Property PctCtrlCC_OK_InspecteurTotal As String

        Get
            If _NCtrlCCInspecteurTotal = 0 Then
                Return ""
            Else
                Return Math.Round((_NCtrlCC_OK_InspecteurTotal / _NCtrlCCInspecteurTotal) * 100, 2) & " %"
            End If
        End Get
    End Property
    Public ReadOnly Property PctCtrlCC_CP_InspecteurAnnee As String

        Get
            If _NCtrlCCInspecteurAnnee = 0 Then
                Return ""
            Else
                Return Math.Round((_NCtrlCC_CP_InspecteurAnnee / _NCtrlCCInspecteurAnnee) * 100, 2) & " %"
            End If
        End Get
    End Property
    Public ReadOnly Property PctCtrlCC_CP_InspecteurTotal As String

        Get
            If _NCtrlCCInspecteurTotal = 0 Then
                Return ""
            Else
                Return Math.Round((_NCtrlCC_CP_InspecteurTotal / _NCtrlCCInspecteurTotal) * 100, 2) & " %"
            End If

        End Get
    End Property
    Public ReadOnly Property PctCtrlCC_ReparAvant_InspecteurAnnee As String

        Get
            If _NCtrlCCInspecteurAnnee = 0 Then
                Return ""
            Else
                Return Math.Round((_NCtrlCC_ReparAvant_InspecteurAnnee / _NCtrlCCInspecteurAnnee) * 100, 2) & " %"
            End If

        End Get
    End Property
    Public ReadOnly Property PctCtrlCC_ReparAvant_InspecteurTotal As String

        Get
            If _NCtrlCCInspecteurTotal = 0 Then
                Return ""
            Else
                Return Math.Round((_NCtrlCC_ReparAvant_InspecteurTotal / _NCtrlCCInspecteurTotal) * 100, 2) & " %"
            End If

        End Get
    End Property
    Public ReadOnly Property PctCtrlCC_AutoControle_InspecteurAnnee As String

        Get
            If _NCtrlCCInspecteurAnnee = 0 Then
                Return ""
            Else
                Return Math.Round((_NCtrlCC_AutoControle_InspecteurAnnee / _NCtrlCCInspecteurAnnee) * 100, 2) & " %"
            End If

        End Get
    End Property
    Public ReadOnly Property PctCtrlCC_AutoControle_InspecteurTotal As String

        Get
            If _NCtrlCCInspecteurTotal = 0 Then
                Return ""
            Else
                Return Math.Round((_NCtrlCC_AutoControle_InspecteurTotal / _NCtrlCCInspecteurTotal) * 100, 2) & " %"
            End If

        End Get
    End Property
    Public ReadOnly Property PctCtrlCC_PreControle_InspecteurAnnee As String

        Get
            If _NCtrlCCInspecteurAnnee = 0 Then
                Return ""
            Else
                Return Math.Round((_NCtrlCC_PreControle_InspecteurAnnee / _NCtrlCCInspecteurAnnee) * 100, 2) & " %"
            End If
        End Get
    End Property
    Public ReadOnly Property PctCtrlCC_PreControle_InspecteurTotal As String

        Get
            If _NCtrlCCInspecteurTotal = 0 Then
                Return ""
            Else
                Return Math.Round((_NCtrlCC_PreControle_InspecteurTotal / _NCtrlCCInspecteurTotal) * 100, 2) & " %"
            End If


        End Get
    End Property
    Public ReadOnly Property PctCtrlCC_OK_StructureAnnee As String

        Get
            If _NCtrlCCStructureAnnee = 0 Then
                Return ""
            Else
                Return Math.Round((_NCtrlCC_OK_StructureAnnee / _NCtrlCCStructureAnnee) * 100, 2) & " %"
            End If
        End Get
    End Property
    Public ReadOnly Property PctCtrlCC_OK_StructureTotal As String

        Get
            If _NCtrlCCStructureTotal = 0 Then
                Return ""
            Else
                Return Math.Round((_NCtrlCC_OK_StructureTotal / _NCtrlCCStructureTotal) * 100, 2) & " %"
            End If
        End Get
    End Property
    Public ReadOnly Property PctCtrlCC_CP_StructureAnnee As String

        Get
            If _NCtrlCCStructureAnnee = 0 Then
                Return ""
            Else
                Return Math.Round((_NCtrlCC_CP_StructureAnnee / _NCtrlCCStructureAnnee) * 100, 2) & " %"
            End If
        End Get
    End Property
    Public ReadOnly Property PctCtrlCC_CP_StructureTotal As String

        Get
            If _NCtrlCCStructureTotal = 0 Then
                Return ""
            Else
                Return Math.Round((_NCtrlCC_CP_StructureTotal / _NCtrlCCStructureTotal) * 100, 2) & " %"
            End If
        End Get
    End Property
    Public ReadOnly Property PctCtrlCC_ReparAvant_StructureAnnee As String

        Get
            If _NCtrlCCStructureAnnee = 0 Then
                Return ""
            Else
                Return Math.Round((_NCtrlCC_ReparAvant_StructureAnnee / _NCtrlCCStructureAnnee) * 100, 2) & " %"
            End If
        End Get
    End Property
    Public ReadOnly Property PctCtrlCC_ReparAvant_StructureTotal As String

        Get
            If _NCtrlCCStructureTotal = 0 Then
                Return ""
            Else
                Return Math.Round((_NCtrlCC_ReparAvant_StructureTotal / _NCtrlCCStructureTotal) * 100, 2) & " %"
            End If

        End Get
    End Property
    Public ReadOnly Property PctCtrlCC_AutoControle_StructureAnnee As String

        Get
            If _NCtrlCCStructureAnnee = 0 Then
                Return ""
            Else
                Return Math.Round((_NCtrlCC_AutoControle_StructureAnnee / _NCtrlCCStructureAnnee) * 100, 2) & " %"
            End If
        End Get
    End Property
    Public ReadOnly Property PctCtrlCC_AutoControle_StructureTotal As String

        Get
            If _NCtrlCCStructureTotal = 0 Then
                Return ""
            Else
                Return Math.Round((_NCtrlCC_AutoControle_StructureTotal / _NCtrlCCStructureTotal) * 100, 2) & " %"
            End If
        End Get
    End Property
    Public ReadOnly Property PctCtrlCC_PreControle_StructureAnnee As String

        Get
            If _NCtrlCCStructureAnnee = 0 Then
                Return ""
            Else
                Return Math.Round((_NCtrlCC_PreControle_StructureAnnee / _NCtrlCCStructureAnnee) * 100, 2) & " %"
            End If
        End Get
    End Property
    Public ReadOnly Property PctCtrlCC_PreControle_StructureTotal As String

        Get
            If _NCtrlCCStructureTotal = 0 Then
                Return ""
            Else
                Return Math.Round((_NCtrlCC_PreControle_StructureTotal / _NCtrlCCStructureTotal) * 100, 2) & " %"
            End If
        End Get
    End Property
    Public Property NCtrlCVInspecteurAnnee As Integer

        Get
            Return _NCtrlCVInspecteurAnnee

        End Get
        Set(ByVal value As Integer)
            _NCtrlCVInspecteurAnnee = value

        End Set
    End Property
    Public Property NCtrlCVInspecteurTotal As Integer

        Get
            Return _NCtrlCVInspecteurTotal

        End Get
        Set(ByVal value As Integer)
            _NCtrlCVInspecteurTotal = value

        End Set
    End Property
    Public Property NCtrlCV_OK_InspecteurAnnee As Integer

        Get
            Return _NCtrlCV_OK_InspecteurAnnee

        End Get
        Set(ByVal value As Integer)
            _NCtrlCV_OK_InspecteurAnnee = value

        End Set
    End Property
    Public Property NCtrlCV_OK_InspecteurTotal As Integer

        Get
            Return _NCtrlCV_OK_InspecteurTotal

        End Get
        Set(ByVal value As Integer)
            _NCtrlCV_OK_InspecteurTotal = value

        End Set
    End Property
    Public Property NCtrlCV_CP_InspecteurAnnee As Integer

        Get
            Return _NCtrlCV_CP_InspecteurAnnee

        End Get
        Set(ByVal value As Integer)
            _NCtrlCV_CP_InspecteurAnnee = value

        End Set
    End Property
    Public Property NCtrlCV_CP_InspecteurTotal As Integer

        Get
            Return _NCtrlCV_CP_InspecteurTotal

        End Get
        Set(ByVal value As Integer)
            _NCtrlCV_CP_InspecteurTotal = value

        End Set
    End Property
    Public Property NCtrlCV_ReparAvant_InspecteurAnnee As Integer

        Get
            Return _NCtrlCV_ReparAvant_InspecteurAnnee

        End Get
        Set(ByVal value As Integer)
            _NCtrlCV_ReparAvant_InspecteurAnnee = value

        End Set
    End Property
    Public Property NCtrlCV_ReparAvant_InspecteurTotal As Integer

        Get
            Return _NCtrlCV_ReparAvant_InspecteurTotal

        End Get
        Set(ByVal value As Integer)
            _NCtrlCV_ReparAvant_InspecteurTotal = value

        End Set
    End Property
    Public Property NCtrlCV_AutoControle_InspecteurAnnee As Integer

        Get
            Return _NCtrlCV_AutoControle_InspecteurAnnee

        End Get
        Set(ByVal value As Integer)
            _NCtrlCV_AutoControle_InspecteurAnnee = value

        End Set
    End Property
    Public Property NCtrlCV_AutoControle_InspecteurTotal As Integer

        Get
            Return _NCtrlCV_AutoControle_InspecteurTotal

        End Get
        Set(ByVal value As Integer)
            _NCtrlCV_AutoControle_InspecteurTotal = value

        End Set
    End Property
    Public Property NCtrlCV_PreControle_InspecteurAnnee As Integer

        Get
            Return _NCtrlCV_PreControle_InspecteurAnnee

        End Get
        Set(ByVal value As Integer)
            _NCtrlCV_PreControle_InspecteurAnnee = value

        End Set
    End Property
    Public Property NCtrlCV_PreControle_InspecteurTotal As Integer

        Get
            Return _NCtrlCV_PreControle_InspecteurTotal

        End Get
        Set(ByVal value As Integer)
            _NCtrlCV_PreControle_InspecteurTotal = value

        End Set
    End Property

    Public Property NCtrlCVStructureAnnee As Integer

        Get
            Return _NCtrlCVStructureAnnee

        End Get
        Set(ByVal value As Integer)
            _NCtrlCVStructureAnnee = value

        End Set
    End Property
    Public Property NCtrlCVStructureTotal As Integer

        Get
            Return _NCtrlCVStructureTotal

        End Get
        Set(ByVal value As Integer)
            _NCtrlCVStructureTotal = value

        End Set
    End Property
    Public Property NCtrlCV_OK_StructureAnnee As Integer

        Get
            Return _NCtrlCV_OK_StructureAnnee

        End Get
        Set(ByVal value As Integer)
            _NCtrlCV_OK_StructureAnnee = value

        End Set
    End Property
    Public Property NCtrlCV_OK_StructureTotal As Integer

        Get
            Return _NCtrlCV_OK_StructureTotal

        End Get
        Set(ByVal value As Integer)
            _NCtrlCV_OK_StructureTotal = value

        End Set
    End Property
    Public Property NCtrlCV_CP_StructureAnnee As Integer

        Get
            Return _NCtrlCV_CP_StructureAnnee

        End Get
        Set(ByVal value As Integer)
            _NCtrlCV_CP_StructureAnnee = value

        End Set
    End Property
    Public Property NCtrlCV_CP_StructureTotal As Integer

        Get
            Return _NCtrlCV_CP_StructureTotal

        End Get
        Set(ByVal value As Integer)
            _NCtrlCV_CP_StructureTotal = value

        End Set
    End Property
    Public Property NCtrlCV_ReparAvant_StructureAnnee As Integer

        Get
            Return _NCtrlCV_ReparAvant_StructureAnnee

        End Get
        Set(ByVal value As Integer)
            _NCtrlCV_ReparAvant_StructureAnnee = value

        End Set
    End Property
    Public Property NCtrlCV_ReparAvant_StructureTotal As Integer

        Get
            Return _NCtrlCV_ReparAvant_StructureTotal

        End Get
        Set(ByVal value As Integer)
            _NCtrlCV_ReparAvant_StructureTotal = value

        End Set
    End Property
    Public Property NCtrlCV_AutoControle_StructureAnnee As Integer

        Get
            Return _NCtrlCV_AutoControle_StructureAnnee

        End Get
        Set(ByVal value As Integer)
            _NCtrlCV_AutoControle_StructureAnnee = value

        End Set
    End Property
    Public Property NCtrlCV_AutoControle_StructureTotal As Integer

        Get
            Return _NCtrlCV_AutoControle_StructureTotal

        End Get
        Set(ByVal value As Integer)
            _NCtrlCV_AutoControle_StructureTotal = value

        End Set
    End Property
    Public Property NCtrlCV_PreControle_StructureAnnee As Integer

        Get
            Return _NCtrlCV_PreControle_StructureAnnee

        End Get
        Set(ByVal value As Integer)
            _NCtrlCV_PreControle_StructureAnnee = value

        End Set
    End Property
    Public Property NCtrlCV_PreControle_StructureTotal As Integer

        Get
            Return _NCtrlCV_PreControle_StructureTotal

        End Get
        Set(ByVal value As Integer)
            _NCtrlCV_PreControle_StructureTotal = value

        End Set
    End Property
    Public ReadOnly Property PctCtrlCV_OK_InspecteurAnnee As String

        Get
            If _NCtrlCVInspecteurAnnee = 0 Then
                Return ""
            Else
                Return Math.Round((_NCtrlCV_OK_InspecteurAnnee / _NCtrlCVInspecteurAnnee) * 100, 2) & " %"
            End If
        End Get
    End Property
    Public ReadOnly Property PctCtrlCV_OK_InspecteurTotal As String

        Get
            If _NCtrlCVInspecteurTotal = 0 Then
                Return ""
            Else
                Return Math.Round((_NCtrlCV_OK_InspecteurTotal / _NCtrlCVInspecteurTotal) * 100, 2) & " %"
            End If
        End Get
    End Property
    Public ReadOnly Property PctCtrlCV_CP_InspecteurAnnee As String

        Get
            If _NCtrlCVInspecteurAnnee = 0 Then
                Return ""
            Else
                Return Math.Round((_NCtrlCV_CP_InspecteurAnnee / _NCtrlCVInspecteurAnnee) * 100, 2) & " %"
            End If
        End Get
    End Property
    Public ReadOnly Property PctCtrlCV_CP_InspecteurTotal As String

        Get
            If _NCtrlCVInspecteurTotal = 0 Then
                Return ""
            Else
                Return Math.Round((_NCtrlCV_CP_InspecteurTotal / _NCtrlCVInspecteurTotal) * 100, 2) & " %"
            End If

        End Get
    End Property
    Public ReadOnly Property PctCtrlCV_ReparAvant_InspecteurAnnee As String

        Get
            If _NCtrlCVInspecteurAnnee = 0 Then
                Return ""
            Else
                Return Math.Round((_NCtrlCV_ReparAvant_InspecteurAnnee / _NCtrlCVInspecteurAnnee) * 100, 2) & " %"
            End If

        End Get
    End Property
    Public ReadOnly Property PctCtrlCV_ReparAvant_InspecteurTotal As String

        Get
            If _NCtrlCVInspecteurTotal = 0 Then
                Return ""
            Else
                Return Math.Round((_NCtrlCV_ReparAvant_InspecteurTotal / _NCtrlCVInspecteurTotal) * 100, 2) & " %"
            End If

        End Get
    End Property
    Public ReadOnly Property PctCtrlCV_AutoControle_InspecteurAnnee As String

        Get
            If _NCtrlCVInspecteurAnnee = 0 Then
                Return ""
            Else
                Return Math.Round((_NCtrlCV_AutoControle_InspecteurAnnee / _NCtrlCVInspecteurAnnee) * 100, 2) & " %"
            End If

        End Get
    End Property
    Public ReadOnly Property PctCtrlCV_AutoControle_InspecteurTotal As String

        Get
            If _NCtrlCVInspecteurTotal = 0 Then
                Return ""
            Else
                Return Math.Round((_NCtrlCV_AutoControle_InspecteurTotal / _NCtrlCVInspecteurTotal) * 100, 2) & " %"
            End If

        End Get
    End Property
    Public ReadOnly Property PctCtrlCV_PreControle_InspecteurAnnee As String

        Get
            If _NCtrlCVInspecteurAnnee = 0 Then
                Return ""
            Else
                Return Math.Round((_NCtrlCV_PreControle_InspecteurAnnee / _NCtrlCVInspecteurAnnee) * 100, 2) & " %"
            End If
        End Get
    End Property
    Public ReadOnly Property PctCtrlCV_PreControle_InspecteurTotal As String

        Get
            If _NCtrlCVInspecteurTotal = 0 Then
                Return ""
            Else
                Return Math.Round((_NCtrlCV_PreControle_InspecteurTotal / _NCtrlCVInspecteurTotal) * 100, 2) & " %"
            End If


        End Get
    End Property
    Public ReadOnly Property PctCtrlCV_OK_StructureAnnee As String

        Get
            If _NCtrlCVStructureAnnee = 0 Then
                Return ""
            Else
                Return Math.Round((_NCtrlCV_OK_StructureAnnee / _NCtrlCVStructureAnnee) * 100, 2) & " %"
            End If
        End Get
    End Property
    Public ReadOnly Property PctCtrlCV_OK_StructureTotal As String

        Get
            If _NCtrlCVStructureTotal = 0 Then
                Return ""
            Else
                Return Math.Round((_NCtrlCV_OK_StructureTotal / _NCtrlCVStructureTotal) * 100, 2) & " %"
            End If
        End Get
    End Property
    Public ReadOnly Property PctCtrlCV_CP_StructureAnnee As String

        Get
            If _NCtrlCVStructureAnnee = 0 Then
                Return ""
            Else
                Return Math.Round((_NCtrlCV_CP_StructureAnnee / _NCtrlCVStructureAnnee) * 100, 2) & " %"
            End If
        End Get
    End Property
    Public ReadOnly Property PctCtrlCV_CP_StructureTotal As String

        Get
            If _NCtrlCVStructureTotal = 0 Then
                Return ""
            Else
                Return Math.Round((_NCtrlCV_CP_StructureTotal / _NCtrlCVStructureTotal) * 100, 2) & " %"
            End If
        End Get
    End Property
    Public ReadOnly Property PctCtrlCV_ReparAvant_StructureAnnee As String

        Get
            If _NCtrlCVStructureAnnee = 0 Then
                Return ""
            Else
                Return Math.Round((_NCtrlCV_ReparAvant_StructureAnnee / _NCtrlCVStructureAnnee) * 100, 2) & " %"
            End If
        End Get
    End Property
    Public ReadOnly Property PctCtrlCV_ReparAvant_StructureTotal As String

        Get
            If _NCtrlCVStructureTotal = 0 Then
                Return ""
            Else
                Return Math.Round((_NCtrlCV_ReparAvant_StructureTotal / _NCtrlCVStructureTotal) * 100, 2) & " %"
            End If

        End Get
    End Property
    Public ReadOnly Property PctCtrlCV_AutoControle_StructureAnnee As String

        Get
            If _NCtrlCVStructureAnnee = 0 Then
                Return ""
            Else
                Return Math.Round((_NCtrlCV_AutoControle_StructureAnnee / _NCtrlCVStructureAnnee) * 100, 2) & " %"
            End If
        End Get
    End Property
    Public ReadOnly Property PctCtrlCV_AutoControle_StructureTotal As String

        Get
            If _NCtrlCVStructureTotal = 0 Then
                Return ""
            Else
                Return Math.Round((_NCtrlCV_AutoControle_StructureTotal / _NCtrlCVStructureTotal) * 100, 2) & " %"
            End If
        End Get
    End Property
    Public ReadOnly Property PctCtrlCV_PreControle_StructureAnnee As String

        Get
            If _NCtrlCVStructureAnnee = 0 Then
                Return ""
            Else
                Return Math.Round((_NCtrlCV_PreControle_StructureAnnee / _NCtrlCVStructureAnnee) * 100, 2) & " %"
            End If
        End Get
    End Property
    Public ReadOnly Property PctCtrlCV_PreControle_StructureTotal As String

        Get
            If _NCtrlCVStructureTotal = 0 Then
                Return ""
            Else
                Return Math.Round((_NCtrlCV_PreControle_StructureTotal / _NCtrlCVStructureTotal) * 100, 2) & " %"
            End If
        End Get
    End Property

    Public Function Fill(ByVal pAgent As Agent, ByVal pAnneeReference As Integer) As Boolean
        Dim bReturn As Boolean
        Try
            Dim oCSDb As New CSDb(True)
            If CSDb._DBTYPE = CSDb.EnumDBTYPE.SQLITE Then
                NCtrlCCStructureTotal = oCSDb.getValue("SELECT count(*) from diagnostic where ControleisComplet and OrganismePresId = " & pAgent.uidStructure & "")
                NCtrlCCInspecteurTotal = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and inspecteurId = " & pAgent.id & "")

                NCtrlCCStructureAnnee = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and OrganismePresId = " & pAgent.uidStructure & " and strftime('%Y',controleDateDebut) = '" & pAnneeReference & "'")
                NCtrlCCInspecteurAnnee = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and inspecteurId = " & pAgent.id & " and strftime('%Y',controleDateDebut) = '" & pAnneeReference & "'")

                NCtrlCC_OK_StructureTotal = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and ControleEtat = '1' and OrganismePresId = " & pAgent.uidStructure & "")
                NCtrlCC_OK_InspecteurTotal = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and ControleEtat = '1' and inspecteurId = " & pAgent.id & "")

                NCtrlCC_OK_StructureAnnee = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and ControleEtat = '1' and OrganismePresId = " & pAgent.uidStructure & " and strftime('%Y',controleDateDebut) = '" & pAnneeReference & "'")
                NCtrlCC_OK_InspecteurAnnee = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and ControleEtat = '1' and inspecteurId = " & pAgent.id & " and strftime('%Y',controleDateDebut) = '" & pAnneeReference & "'")

                NCtrlCC_CP_StructureTotal = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and ControleEtat <> '1' and OrganismePresId = " & pAgent.uidStructure & "")
                NCtrlCC_CP_InspecteurTotal = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and ControleEtat <> '1' and inspecteurId = " & pAgent.id & "")

                NCtrlCC_CP_StructureAnnee = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and ControleEtat <> '1' and OrganismePresId = " & pAgent.uidStructure & " and strftime('%Y',controleDateDebut) = '" & pAnneeReference & "'")
                NCtrlCC_CP_InspecteurAnnee = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and ControleEtat <> '1' and inspecteurId = " & pAgent.id & " and strftime('%Y',controleDateDebut) = '" & pAnneeReference & "'")

                NCtrlCC_ReparAvant_StructureTotal = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and controleIsPulveRepare  = TRUE and OrganismePresId = " & pAgent.uidStructure & "")
                NCtrlCC_ReparAvant_InspecteurTotal = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and controleIsPulveRepare  = TRUE and inspecteurId = " & pAgent.id & "")

                NCtrlCC_ReparAvant_StructureAnnee = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and controleIsPulveRepare  = TRUE and OrganismePresId = " & pAgent.uidStructure & " and strftime('%Y',controleDateDebut) = '" & pAnneeReference & "'")
                NCtrlCC_ReparAvant_InspecteurAnnee = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and controleIsPulveRepare  = TRUE and inspecteurId = " & pAgent.id & " and strftime('%Y',controleDateDebut) = '" & pAnneeReference & "'")

                NCtrlCC_AutoControle_StructureTotal = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and controleIsAutoControle  = TRUE and OrganismePresId = " & pAgent.uidStructure & "")
                NCtrlCC_AutoControle_InspecteurTotal = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and controleIsAutoControle  = TRUE and inspecteurId = " & pAgent.id & "")

                NCtrlCC_AutoControle_StructureAnnee = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and controleIsAutoControle  = TRUE and OrganismePresId = " & pAgent.uidStructure & " and strftime('%Y',controleDateDebut) = '" & pAnneeReference & "'")
                NCtrlCC_AutoControle_InspecteurAnnee = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and controleIsAutoControle  = TRUE and inspecteurId = " & pAgent.id & " and strftime('%Y',controleDateDebut) = '" & pAnneeReference & "'")

                NCtrlCC_PreControle_StructureTotal = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and controleIsPreControleProfessionel  = TRUE and OrganismePresId = " & pAgent.uidStructure & "")
                NCtrlCC_PreControle_InspecteurTotal = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and controleIsPreControleProfessionel  = TRUE and inspecteurId = " & pAgent.id & "")

                NCtrlCC_PreControle_StructureAnnee = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and controleIsPreControleProfessionel  = TRUE and OrganismePresId = " & pAgent.uidStructure & " and strftime('%Y',controleDateDebut) = '" & pAnneeReference & "'")
                NCtrlCC_PreControle_InspecteurAnnee = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and controleIsPreControleProfessionel  = TRUE and inspecteurId = " & pAgent.id & " and strftime('%Y',controleDateDebut) = '" & pAnneeReference & "'")
                '=====
                ' CONTROLE PARTIEL
                '======
                NCtrlCVStructureTotal = oCSDb.getValue("SELECT count(*) from diagnostic where Not ControleIsComplet  and OrganismePresId = " & pAgent.uidStructure & "")
                NCtrlCVInspecteurTotal = oCSDb.getValue("SELECT count(*) from diagnostic  where Not ControleIsComplet  and inspecteurId = " & pAgent.id & "")

                NCtrlCVStructureAnnee = oCSDb.getValue("SELECT count(*) from diagnostic  where Not ControleIsComplet  and OrganismePresId = " & pAgent.uidStructure & " and strftime('%Y',controleDateDebut) = '" & pAnneeReference & "'")
                NCtrlCVInspecteurAnnee = oCSDb.getValue("SELECT count(*) from diagnostic  where Not ControleIsComplet  and inspecteurId = " & pAgent.id & " and strftime('%Y',controleDateDebut) = '" & pAnneeReference & "'")

                NCtrlCV_OK_StructureTotal = oCSDb.getValue("SELECT count(*) from diagnostic  where Not ControleIsComplet  and ControleEtat = '1' and OrganismePresId = " & pAgent.uidStructure & "")
                NCtrlCV_OK_InspecteurTotal = oCSDb.getValue("SELECT count(*) from diagnostic  where Not ControleIsComplet  and ControleEtat = '1' and inspecteurId = " & pAgent.id & "")

                NCtrlCV_OK_StructureAnnee = oCSDb.getValue("SELECT count(*) from diagnostic  where Not ControleIsComplet  and ControleEtat = '1' and OrganismePresId = " & pAgent.uidStructure & " and strftime('%Y',controleDateDebut) = '" & pAnneeReference & "'")
                NCtrlCV_OK_InspecteurAnnee = oCSDb.getValue("SELECT count(*) from diagnostic  where Not ControleIsComplet  and ControleEtat = '1' and inspecteurId = " & pAgent.id & " and strftime('%Y',controleDateDebut) = '" & pAnneeReference & "'")

                NCtrlCV_CP_StructureTotal = oCSDb.getValue("SELECT count(*) from diagnostic  where Not ControleIsComplet  and ControleEtat <> '1' and OrganismePresId = " & pAgent.uidStructure & "")
                NCtrlCV_CP_InspecteurTotal = oCSDb.getValue("SELECT count(*) from diagnostic  where Not ControleIsComplet  and ControleEtat <> '1' and inspecteurId = " & pAgent.id & "")

                NCtrlCV_CP_StructureAnnee = oCSDb.getValue("SELECT count(*) from diagnostic  where Not ControleIsComplet  and ControleEtat <> '1' and OrganismePresId = " & pAgent.uidStructure & " and strftime('%Y',controleDateDebut) = '" & pAnneeReference & "'")
                NCtrlCV_CP_InspecteurAnnee = oCSDb.getValue("SELECT count(*) from diagnostic  where Not ControleIsComplet  and ControleEtat <> '1' and inspecteurId = " & pAgent.id & " and strftime('%Y',controleDateDebut) = '" & pAnneeReference & "'")

                NCtrlCV_ReparAvant_StructureTotal = oCSDb.getValue("SELECT count(*) from diagnostic  where Not ControleIsComplet  and controleIsPulveRepare  = TRUE and OrganismePresId = " & pAgent.uidStructure & "")
                NCtrlCV_ReparAvant_InspecteurTotal = oCSDb.getValue("SELECT count(*) from diagnostic  where Not ControleIsComplet  and controleIsPulveRepare  = TRUE and inspecteurId = " & pAgent.id & "")

                NCtrlCV_ReparAvant_StructureAnnee = oCSDb.getValue("SELECT count(*) from diagnostic  where Not ControleIsComplet  and controleIsPulveRepare  = TRUE and OrganismePresId = " & pAgent.uidStructure & " and strftime('%Y',controleDateDebut) = '" & pAnneeReference & "'")
                NCtrlCV_ReparAvant_InspecteurAnnee = oCSDb.getValue("SELECT count(*) from diagnostic  where Not ControleIsComplet  and controleIsPulveRepare  = TRUE and inspecteurId = " & pAgent.id & " and strftime('%Y',controleDateDebut) = '" & pAnneeReference & "'")

                NCtrlCV_AutoControle_StructureTotal = oCSDb.getValue("SELECT count(*) from diagnostic  where Not ControleIsComplet  and controleIsAutoControle  = TRUE and OrganismePresId = " & pAgent.uidStructure & "")
                NCtrlCV_AutoControle_InspecteurTotal = oCSDb.getValue("SELECT count(*) from diagnostic  where Not ControleIsComplet  and controleIsAutoControle  = TRUE and inspecteurId = " & pAgent.id & "")

                NCtrlCV_AutoControle_StructureAnnee = oCSDb.getValue("SELECT count(*) from diagnostic  where Not ControleIsComplet  and controleIsAutoControle  = TRUE and OrganismePresId = " & pAgent.uidStructure & " and strftime('%Y',controleDateDebut) = '" & pAnneeReference & "'")
                NCtrlCV_AutoControle_InspecteurAnnee = oCSDb.getValue("SELECT count(*) from diagnostic  where Not ControleIsComplet  and controleIsAutoControle  = TRUE and inspecteurId = " & pAgent.id & " and strftime('%Y',controleDateDebut) = '" & pAnneeReference & "'")

                NCtrlCV_PreControle_StructureTotal = oCSDb.getValue("SELECT count(*) from diagnostic  where Not ControleIsComplet  and controleIsPreControleProfessionel  = TRUE and OrganismePresId = " & pAgent.uidStructure & "")
                NCtrlCV_PreControle_InspecteurTotal = oCSDb.getValue("SELECT count(*) from diagnostic  where Not ControleIsComplet  and controleIsPreControleProfessionel  = TRUE and inspecteurId = " & pAgent.id & "")

                NCtrlCV_PreControle_StructureAnnee = oCSDb.getValue("SELECT count(*) from diagnostic  where Not ControleIsComplet  and controleIsPreControleProfessionel  = TRUE and OrganismePresId = " & pAgent.uidStructure & " and strftime('%Y',controleDateDebut) = '" & pAnneeReference & "'")
                NCtrlCV_PreControle_InspecteurAnnee = oCSDb.getValue("SELECT count(*) from diagnostic  where Not ControleIsComplet  and controleIsPreControleProfessionel  = TRUE and inspecteurId = " & pAgent.id & " and strftime('%Y',controleDateDebut) = '" & pAnneeReference & "'")



            Else
                NCtrlCCStructureTotal = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and OrganismePresId = " & pAgent.uidStructure & "")
                NCtrlCCInspecteurTotal = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and inspecteurId = " & pAgent.id & "")

                NCtrlCCStructureAnnee = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and OrganismePresId = " & pAgent.uidStructure & " and YEAR(controleDateDebut) = '" & pAnneeReference & "'")
                NCtrlCCInspecteurAnnee = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and inspecteurId = " & pAgent.id & " and YEAR(controleDateDebut) = '" & pAnneeReference & "'")

                NCtrlCC_OK_StructureTotal = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and ControleEtat = '1' and OrganismePresId = " & pAgent.uidStructure & "")
                NCtrlCC_OK_InspecteurTotal = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and ControleEtat = '1' and inspecteurId = " & pAgent.id & "")

                NCtrlCC_OK_StructureAnnee = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and ControleEtat = '1' and OrganismePresId = " & pAgent.uidStructure & " and YEAR(controleDateDebut) = '" & pAnneeReference & "'")
                NCtrlCC_OK_InspecteurAnnee = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and ControleEtat = '1' and inspecteurId = " & pAgent.id & " and YEAR(controleDateDebut) = '" & pAnneeReference & "'")

                NCtrlCC_CP_StructureTotal = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and ControleEtat <> '1' and OrganismePresId = " & pAgent.uidStructure & "")
                NCtrlCC_CP_InspecteurTotal = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and ControleEtat <> '1' and inspecteurId = " & pAgent.id & "")

                NCtrlCC_CP_StructureAnnee = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and ControleEtat <> '1' and OrganismePresId = " & pAgent.uidStructure & " and YEAR(controleDateDebut) = '" & pAnneeReference & "'")
                NCtrlCC_CP_InspecteurAnnee = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and ControleEtat <> '1' and inspecteurId = " & pAgent.id & " and YEAR(controleDateDebut) = '" & pAnneeReference & "'")

                NCtrlCC_ReparAvant_StructureTotal = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and controleIsPulveRepare  = TRUE and OrganismePresId = " & pAgent.uidStructure & "")
                NCtrlCC_ReparAvant_InspecteurTotal = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and controleIsPulveRepare  = TRUE and inspecteurId = " & pAgent.id & "")

                NCtrlCC_ReparAvant_StructureAnnee = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and controleIsPulveRepare  = TRUE and OrganismePresId = " & pAgent.uidStructure & " and YEAR(controleDateDebut) = '" & pAnneeReference & "'")
                NCtrlCC_ReparAvant_InspecteurAnnee = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and controleIsPulveRepare  = TRUE and inspecteurId = " & pAgent.id & " and YEAR(controleDateDebut) = '" & pAnneeReference & "'")

                NCtrlCC_AutoControle_StructureTotal = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and controleIsAutoControle  = TRUE and OrganismePresId = " & pAgent.uidStructure & "")
                NCtrlCC_AutoControle_InspecteurTotal = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and controleIsAutoControle  = TRUE and inspecteurId = " & pAgent.id & "")

                NCtrlCC_AutoControle_StructureAnnee = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and controleIsAutoControle  = TRUE and OrganismePresId = " & pAgent.uidStructure & " and YEAR(controleDateDebut) = '" & pAnneeReference & "'")
                NCtrlCC_AutoControle_InspecteurAnnee = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and controleIsAutoControle  = TRUE and inspecteurId = " & pAgent.id & " and YEAR(controleDateDebut) = '" & pAnneeReference & "'")

                NCtrlCC_PreControle_StructureTotal = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and controleIsPreControleProfessionel  = TRUE and OrganismePresId = " & pAgent.uidStructure & "")
                NCtrlCC_PreControle_InspecteurTotal = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and controleIsPreControleProfessionel  = TRUE and inspecteurId = " & pAgent.id & "")

                NCtrlCC_PreControle_StructureAnnee = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and controleIsPreControleProfessionel  = TRUE and OrganismePresId = " & pAgent.uidStructure & " and YEAR(controleDateDebut) = '" & pAnneeReference & "'")
                NCtrlCC_PreControle_InspecteurAnnee = oCSDb.getValue("SELECT count(*) from diagnostic  where ControleisComplet and controleIsPreControleProfessionel  = TRUE and inspecteurId = " & pAgent.id & " and YEAR(controleDateDebut) = '" & pAnneeReference & "'")
            End If
            oCSDb.free()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("StatCrodip.Fill Error : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

End Class