Imports System.Collections.Generic
Imports System.Linq
Imports System.Xml.Serialization

Public Class Facture
    Inherits ContratCommercial

    Public Sub New()

    End Sub
    Public Sub New(pContrat As ContratCommercial, pStructure As Structuree)
        Me.Commentaire = pContrat.Commentaire
        'Me.DiagId = pContrat.DiagId
        Me.oDiagnostic = pContrat.oDiagnostic
        Me.oExploit = pContrat.oExploit
        Me.TxTVA = pContrat.TxTVA
        pContrat.Lignes.ForEach(Sub(lg) Lignes.Add(lg.Clone()))

        Dim oStructure As Structuree
        If pStructure Is Nothing Then
            oStructure = StructureManager.getStructureById(oDiagnostic.organismePresId)
        Else
            oStructure = pStructure
        End If
        If oStructure IsNot Nothing Then
            Modereglement = oStructure.Modereglement
            MsgEntetete = oStructure.Entete
        End If

    End Sub
#Region "Properties"
    Private _DateFacture As DateTime
    Public Property DateFacture() As DateTime
        Get
            Return _DateFacture
        End Get
        Set(ByVal value As DateTime)
            _DateFacture = value
        End Set
    End Property
    Private _DateEchenance As DateTime
    Public Property DateEcheance() As DateTime
        Get
            Return _DateEchenance
        End Get
        Set(ByVal value As DateTime)
            _DateEchenance = value
        End Set
    End Property
    Private _ModeReglement As String
    Public Property Modereglement() As String
        Get
            Return _ModeReglement
        End Get
        Set(ByVal value As String)
            _ModeReglement = value
        End Set
    End Property
    Private _Reglee As Boolean
    Public Property Reglee() As Boolean
        Get
            Return _Reglee
        End Get
        Set(ByVal value As Boolean)
            _Reglee = value
        End Set
    End Property
    Private _RefPaiement As String


    Public Property RefPaiement() As String
        Get
            Return _RefPaiement
        End Get
        Set(ByVal value As String)
            _RefPaiement = value
        End Set
    End Property
    Private _RefFacture As String
    Public Property RefFacture() As String
        Get
            Return _RefFacture
        End Get
        Set(ByVal value As String)
            _RefFacture = value
        End Set
    End Property
    Private _MsgEntete As String
    Public Property MsgEntetete() As String
        Get
            Return _MsgEntete
        End Get
        Set(ByVal value As String)
            _MsgEntete = value
        End Set
    End Property
#End Region
End Class
