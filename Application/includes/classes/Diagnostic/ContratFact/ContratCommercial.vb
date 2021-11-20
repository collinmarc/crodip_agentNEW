Imports System.Collections.Generic
Imports System.Linq
<Serializable()>
Public Class ContratCommercial


    Private _DiagId As String
    Public Property DiagId() As String
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
    Public Property oDiagnostic() As Diagnostic
        Get
            Return _Diag
        End Get
        Set(ByVal value As Diagnostic)
            _Diag = value
            If _Diag IsNot Nothing Then
                oExploit = ExploitationManager.getExploitationById(_Diag.proprietaireId)
            End If
        End Set
    End Property

    Private _Lignes As List(Of lgPrestation)
    Public Property Lignes() As List(Of lgPrestation)
        Get
            Return _Lignes
        End Get
        Set(ByVal value As List(Of lgPrestation))
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
            Return Lignes.Select(Function(olg) olg.TotalHT).Sum()
        End Get
        Set(ByVal value As Decimal)
            _TotalHT = value
        End Set
    End Property
    Private _TotalTVA As Decimal
    Public Property TotalTVA() As Decimal
        Get
            Return TotalHT * (TxTVA / 100)
        End Get
        Set(ByVal value As Decimal)
            _TotalTVA = value
        End Set
    End Property
    Private _TotalTTC As Decimal
    Public Property TotalTTC() As Decimal
        Get
            Return TotalHT + TotalTVA
        End Get
        Set(ByVal value As Decimal)
            _TotalTTC = value
        End Set
    End Property

    Public Sub New()
        Lignes = New List(Of lgPrestation)()
    End Sub
    Private _Commentaire As String
    Public Property Commentaire() As String
        Get
            Return _Commentaire
        End Get
        Set(ByVal value As String)
            _Commentaire = value
        End Set
    End Property
End Class
