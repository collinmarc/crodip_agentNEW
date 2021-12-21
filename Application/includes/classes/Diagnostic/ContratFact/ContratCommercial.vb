Imports System.Collections.Generic
Imports System.Linq
<Serializable()>
Public Class ContratCommercial


    Private _DiagId As String = ""
    Public Property idDiag() As String
        Get
            Return _DiagId
        End Get
        Set(ByVal value As String)
            _DiagId = value
        End Set
    End Property
    Private _Exploit As Exploitation
    Public Property oExploit() As Exploitation
        Get
            Return _Exploit
        End Get
        Set(ByVal value As Exploitation)
            _Exploit = value
        End Set
    End Property
    Private _Diag As Diagnostic
    'Public Property oDiagnostic() As Diagnostic
    '    Get
    '        Return _Diag
    '    End Get
    '    Set(ByVal value As Diagnostic)
    '        _Diag = value
    '        If _Diag IsNot Nothing And Not String.IsNullOrEmpty(_Diag.proprietaireId) Then
    '            oExploit = ExploitationManager.getExploitationById(_Diag.proprietaireId)
    '        Else
    '            oExploit = New Exploitation()
    '        End If
    '    End Set
    'End Property

    Private _Lignes As List(Of FactureItem)
    Public Property Lignes() As List(Of FactureItem)
        Get
            Return _Lignes
        End Get
        Set(ByVal value As List(Of FactureItem))
            _Lignes = value
        End Set
    End Property

    Private _TxTVA As Decimal
    Public Property TxTVA() As Decimal
        Get
            Return _TxTVA
        End Get
        Set(ByVal value As Decimal)
            _TxTVA = value
        End Set
    End Property
    Private _TotalHT As Decimal
    Public Property TotalHT() As Decimal
        Get
            Return _TotalHT
            'Return Lignes.Select(Function(olg) olg.totalHT).Sum()
        End Get
        Set(ByVal value As Decimal)
            _TotalHT = value
        End Set
    End Property
    Private _TotalTVA As Decimal
    Public Property TotalTVA() As Decimal
        Get
            Return _TotalTVA
            'Return TotalHT * (TxTVA / 100)
        End Get
        Set(ByVal value As Decimal)
            _TotalTVA = value
        End Set
    End Property
    Private _TotalTTC As Decimal
    Public Property TotalTTC() As Decimal
        Get
            Return _TotalTTC
            '            Return TotalHT + TotalTVA
        End Get
        Set(ByVal value As Decimal)
            _TotalTTC = value
        End Set
    End Property
    <Xml.Serialization.XmlIgnore()>
    Public Property TotalTTCStr() As String
        Get
            If TotalTTC = 0 Then
                Return ""
            Else
                Return CStr(TotalTTC)
            End If
        End Get
        Set(ByVal value As String)
            If value = "" Then
                TotalTTC = 0
            Else
                If IsNumeric(value) Then
                    TotalTTC = CDec(value)
                End If
            End If
        End Set
    End Property
    Public Sub CalculTotaux()
        TotalHT = Lignes.Select(Function(olg) olg.totalHT).Sum()
        TotalTVA = TotalHT * (TxTVA / 100)
        TotalTTC = TotalHT + TotalTVA

    End Sub


    Public Sub New()
        Lignes = New List(Of FactureItem)()
    End Sub
    Private _Commentaire As String = ""
    Public Property Commentaire() As String
        Get
            Return _Commentaire
        End Get
        Set(ByVal value As String)
            _Commentaire = value
        End Set
    End Property

    Private _ResteAFacturer As Decimal
    Public Property ResteAFacturer() As Decimal
        Get
            Return _ResteAFacturer
        End Get
        Set(ByVal value As Decimal)
            _ResteAFacturer = value
        End Set
    End Property
End Class
