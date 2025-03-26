Imports System.Collections.Generic
Imports System.Web.Services
Imports System.Xml.Serialization

<Serializable(), XmlInclude(GetType(Pc))>
Public Class Pc
    Inherits Materiel
    Public Property idPC() As String
        Get
            Return numeroNational
        End Get
        Set(ByVal value As String)
            numeroNational = value
        End Set
    End Property
    Private _idRegistre As String
    Public Property idRegistre() As String
        Get
            Return _idRegistre
        End Get
        Set(ByVal value As String)
            _idRegistre = value
        End Set
    End Property
    Private _cleUtilisation As String
    Public Property cleUtilisation() As String
        Get
            Return _cleUtilisation
        End Get
        Set(ByVal value As String)
            _cleUtilisation = value
        End Set
    End Property

    Private _libelle As String
    Public Property libelle() As String
        Get
            Return _libelle
        End Get
        Set(ByVal value As String)
            _libelle = value
        End Set
    End Property
    Private _marque As String
    Public Property marque() As String
        Get
            Return _marque
        End Get
        Set(ByVal value As String)
            _marque = value
        End Set
    End Property

    Private _modele As String
    Public Property modele() As String
        Get
            Return _modele
        End Get
        Set(ByVal value As String)
            _modele = value
        End Set
    End Property
    Private _systeme As String
    Public Property systeme() As String
        Get
            Return _systeme
        End Get
        Set(ByVal value As String)
            _systeme = value
        End Set
    End Property
    Private _memoire As String
    Public Property memoire() As String
        Get
            Return _memoire
        End Get
        Set(ByVal value As String)
            _memoire = value
        End Set
    End Property
    Private _disque As String
    Public Property disque() As String
        Get
            Return _disque
        End Get
        Set(ByVal value As String)
            _disque = value
        End Set
    End Property
    Private _memo As String
    Public Property memo() As String
        Get
            Return _memo
        End Get
        Set(ByVal value As String)
            _memo = value
        End Set
    End Property
    Private _owc_etat As String
    Public Property owc_etat() As String
        Get
            Return _owc_etat
        End Get
        Set(ByVal value As String)
            _owc_etat = value
        End Set
    End Property
    Private _owc_folder As String
    Public Property owc_folder() As String
        Get
            Return _owc_folder
        End Get
        Set(ByVal value As String)
            _owc_folder = value
        End Set
    End Property
    Private _owc_commun As String
    Public Property owc_commun() As String
        Get
            Return _owc_commun
        End Get
        Set(ByVal value As String)
            _owc_commun = value
        End Set
    End Property
    Private _owc_parametres As String
    Public Property owc_parametres() As String
        Get
            Return _owc_parametres
        End Get
        Set(ByVal value As String)
            _owc_parametres = value
        End Set
    End Property
    Private _owc_organismes As String
    Public Property owc_organismes() As String
        Get
            Return _owc_organismes
        End Get
        Set(ByVal value As String)
            _owc_organismes = value
        End Set
    End Property
    Private _owc_user As String
    Public Property owc_user() As String
        Get
            Return _owc_user
        End Get
        Set(ByVal value As String)
            _owc_user = value
        End Set
    End Property
    Private _owc_password As String
    Public Property owc_password() As String
        Get
            Return _owc_password
        End Get
        Set(ByVal value As String)
            _owc_password = value
        End Set
    End Property
    Private _owc_version As String
    Public Property owc_version() As String
        Get
            Return _owc_version
        End Get
        Set(ByVal value As String)
            _owc_version = value
        End Set
    End Property
    Private _isSecours As String
    Public Property isSecours() As String
        Get
            Return _isSecours
        End Get
        Set(ByVal value As String)
            _isSecours = value
        End Set
    End Property
    Public Property dateMiseEnService() As String
        Get
            Return dateActivationS
        End Get
        Set(ByVal value As String)
            dateActivationS = value
        End Set
    End Property
    Private _SignatureElect As String
    Public Property SignatureElect() As String
        Get
            Return _SignatureElect
        End Get
        Set(ByVal value As String)
            _SignatureElect = value
        End Set
    End Property
    Private _isSignElecActive As String
    Public Property isSignElecActive() As String
        Get
            Return _isSignElecActive
        End Get
        Set(ByVal value As String)
            _isSignElecActive = value
        End Set
    End Property
    Private _modeSignature As String
    Public Property modeSignature() As String
        Get
            Return _modeSignature
        End Get
        Set(ByVal value As String)
            _modeSignature = value
        End Set
    End Property
    Private _versionLogiciel As String
    Public Property versionLogiciel() As String
        Get
            Return _versionLogiciel
        End Get
        Set(ByVal value As String)
            _versionLogiciel = value
        End Set
    End Property
    Private _isReinitialisationMode As String
    Public Property isReinitialisationMode() As String
        Get
            Return _isReinitialisationMode
        End Get
        Set(ByVal value As String)
            _isReinitialisationMode = value
        End Set
    End Property
    Private _isMasterMode As String
    Public Property isMasterMode() As String
        Get
            Return _isMasterMode
        End Get
        Set(ByVal value As String)
            _isMasterMode = value
        End Set
    End Property
    Private _isDownloadMetrologieMode As String
    Public Property isDownloadMetrologieMode() As String
        Get
            Return _isDownloadMetrologieMode
        End Get
        Set(ByVal value As String)
            _isDownloadMetrologieMode = value
        End Set
    End Property
    Private _isDownloadTarificationMode As String
    Public Property isDownloadTarificationMode() As String
        Get
            Return _isDownloadTarificationMode
        End Get
        Set(ByVal value As String)
            _isDownloadTarificationMode = value
        End Set
    End Property
    Private _isDownloadPulveExloitationMode As String
    Public Property isDownloadPulveExploitationMode() As String
        Get
            Return _isDownloadPulveExloitationMode
        End Get
        Set(ByVal value As String)
            _isDownloadPulveExloitationMode = value
        End Set
    End Property
    Private _isDownloadIdentifiantPulve As String
    Public Property isDownloadIdentifiantPulve() As String
        Get
            Return _isDownloadIdentifiantPulve
        End Get
        Set(ByVal value As String)
            _isDownloadIdentifiantPulve = value
        End Set
    End Property

    Public Overrides Function Fill(pColName As String, pValue As Object) As Boolean
        Dim breturn As Boolean = True
        If Not MyBase.Fill(pColName, pValue) Then
            Select Case pColName.ToUpper.Trim().ToUpper()
            End Select
        End If
        Return breturn
    End Function

    Public Overrides Function DeleteMateriel(ByVal pAgentSuppression As Agent, ByVal pRaison As String) As Boolean
        Me.agentSuppression = pAgentSuppression.nom
        Me.raisonSuppression = pRaison
        Me.dateSuppression = Now.ToString()
        Me.dateModificationAgent = Now()
        Me.isSupprime = True
        PcManager.save(Me)
        Return True
    End Function
    Public Overrides Function creerFicheVieActivation(ByVal pAgent As Agent) As Boolean
        'Il n'y a pas de fiches de vies pour les buses Etalon
        Return True
    End Function
    Public Overrides Function ActiverMateriel(ByVal pDateActivation As Date, ByVal pAgent As Agent) As Boolean
        Dim bReturn As Boolean
        bReturn = MyBase.ActiverMateriel(pDateActivation, pAgent)
        dateActivation = dateActivation
        Return bReturn
    End Function

    ''' <summary>
    ''' Renvoie le niveau d'alter concernant le materiel
    ''' ALERTE.NONE par defaut
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function getAlerte() As GlobalsCRODIP.ALERTE
        Dim bReturn As GlobalsCRODIP.ALERTE
        bReturn = GlobalsCRODIP.ALERTE.NONE

        'Dim oNiveau As NiveauAlerte

        'oNiveau = getNiveauAlerte(NiveauAlerte.Enum_typeMateriel.Buse)
        'bReturn = MyBase.getAlerte(dateAchat, oNiveau)
        Return bReturn
    End Function

    Public Function Desactiver() As Boolean
        Dim bReturn As Boolean

        Try
            ' On bloque la buse
            Me.etat = False
            PcManager.save(Me)
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("Buse.desactiver : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn


    End Function

End Class