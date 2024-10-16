Imports System.Collections.Generic
Imports System.Linq
Imports System.Xml.Serialization


<Serializable()>
Public Class Facture
    Inherits ContratCommercial

    Public Sub New()
        oExploit = New Exploitation()
        'oDiagnostic = New Diagnostic()
        idFacture = ""
    End Sub
    Public Sub New(pStructure As [Structure])
        Me.New()
        Me.idStructure = pStructure.id
        modeReglement = pStructure.modereglement
        msgEntetete = pStructure.Entete


        If String.IsNullOrEmpty(pStructure.txTVA) Then
            Me.TxTVA = 0
        Else
            Me.TxTVA = pStructure.txTVA
        End If
        Me.modeReglement = pStructure.modereglement

    End Sub
    Public Sub New(poDiag As Diagnostic, pStructure As [Structure])
        Me.New(pStructure)
        Me.Commentaire = poDiag.oContratCommercial.Commentaire
        Me.idDiag = poDiag.id
        Me.numNatPulve = poDiag.pulverisateurNumNational
        'Me.oDiagnostic = poDiag
        Me.oExploit = poDiag.oContratCommercial.oExploit
        Me.TxTVA = poDiag.oContratCommercial.TxTVA
        poDiag.oContratCommercial.Lignes.ForEach(Sub(lg) Lignes.Add(lg.Clone()))
        CalculTotaux()


    End Sub

    Public Function setNumeroFacture(pStructure As [Structure]) As Boolean
        Dim bReturn As Boolean
        Try

            Dim nLg As Integer = pStructure.DernierNumFact.Length()
            Dim n As Integer
            Try
                n = Convert.ToInt64(pStructure.DernierNumFact) + 1

            Catch ex As Exception
                n = 0
            End Try

            Me.idFacture = pStructure.RacineNumFact & n.ToString().PadLeft(nLg, "0")
            pStructure.DernierNumFact = n.ToString().PadLeft(nLg, "0")

            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("Facture.setnumeroFacture ERR : ", ex)
            bReturn = False
        End Try
        Return bReturn
    End Function
#Region "Properties"
    Private _numNatPulve As String
    Public Property numNatPulve() As String
        Get
            Return _numNatPulve
        End Get
        Set(ByVal value As String)
            _numNatPulve = value
        End Set
    End Property
    Private _DateFacture As DateTime
    Public Property dateFacture() As DateTime
        Get
            Return _DateFacture
        End Get
        Set(ByVal value As DateTime)
            If value <> _DateFacture Then
                _DateFacture = value
                dateEcheance = dateFacture
            End If
        End Set
    End Property
    Private _DateEchenance As DateTime
    Public Property dateEcheance() As DateTime
        Get
            Return _DateEchenance
        End Get
        Set(ByVal value As DateTime)
            _DateEchenance = value
        End Set
    End Property
    Private _ModeReglement As String
    Public Property modeReglement() As String
        Get
            Return _ModeReglement
        End Get
        Set(ByVal value As String)
            _ModeReglement = value
        End Set
    End Property
    Private _Reglee As Boolean
    Public Property isReglee() As Boolean
        Get
            Return _Reglee
        End Get
        Set(ByVal value As Boolean)
            _Reglee = value
        End Set
    End Property
    Private _refReglement As String = ""


    Public Property refReglement() As String
        Get
            Return _refReglement
        End Get
        Set(ByVal value As String)
            _refReglement = value
        End Set
    End Property
    Private _idFacture As String
    Public Property idFacture() As String
        Get
            Return _idFacture
        End Get
        Set(ByVal value As String)
            _idFacture = value
        End Set
    End Property
    Private _MsgEntete As String
    Public Property msgEntetete() As String
        Get
            Return _MsgEntete
        End Get
        Set(ByVal value As String)
            _MsgEntete = value
        End Set
    End Property
    Private _PathPDF As String = ""
    Public Property pathPDF() As String
        Get
            Return _PathPDF
        End Get
        Set(ByVal value As String)
            _PathPDF = value
        End Set
    End Property
    Private _idStructure As String
    Public Property idStructure() As String
        Get
            Return _idStructure
        End Get
        Set(ByVal value As String)
            _idStructure = value
        End Set
    End Property
    Public Property RaisonSocialeExploitant() As String
        Get
            Return oExploit.raisonSociale
        End Get
        Set(ByVal value As String)
            oExploit.raisonSociale = value
        End Set
    End Property
    Private _dateModificationAgent As DateTime
    <XmlIgnoreAttribute()>
    Public Property dateModificationAgent() As DateTime
        Get
            Return _dateModificationAgent
        End Get
        Set(ByVal Value As DateTime)
            _dateModificationAgent = Value
        End Set
    End Property
    <XmlElement("dateModificationAgent")>
    Public Property dateModificationAgentS() As String
        Get
            Return CSDate.GetDateForWS(_dateModificationAgent)
        End Get
        Set(ByVal Value As String)
            _dateModificationAgent = Value
        End Set
    End Property
    Private _dateModificationCrodip As DateTime
    <XmlIgnoreAttribute()>
    Public Property dateModificationCrodip() As DateTime
        Get
            Return _dateModificationCrodip
        End Get
        Set(ByVal Value As DateTime)
            _dateModificationCrodip = Value
        End Set
    End Property
    <XmlElement("dateModificationCrodip")>
    Public Property dateModificationCrodipS() As String
        Get
            Return CSDate.GetDateForWS(_dateModificationCrodip)
        End Get
        Set(ByVal Value As String)
            _dateModificationCrodip = Value
        End Set
    End Property
#End Region


    Public Function AjoutNouvelleLigne() As FactureItem
        Dim oLg As New FactureItem()
        oLg.txTVA = Me.TxTVA
        Lignes.Add(oLg)
        CalculTotaux()
        Return oLg
    End Function
    Public Function AjoutNouvelleLigne(pCategorie As String, pPrestation As String, pPU As Decimal, pQte As Decimal, pDiagId As String) As FactureItem

        Dim oLg As New FactureItem(pCategorie, pPrestation, pPU, pQte, Me.TxTVA, pDiagId)
        Lignes.Add(oLg)
        CalculTotaux()
        Return oLg

    End Function



End Class
