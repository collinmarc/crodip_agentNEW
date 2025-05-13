Imports System.Collections.Generic
Imports System.Web.Services
Imports System.Xml.Serialization
Imports Microsoft.Win32

<Serializable(), XmlInclude(GetType(AgentPc))>
Public Class Pc
    Inherits AgentPc
End Class
Public Class AgentPc
    Inherits Materiel
    Public Property idPc() As String
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
    Public Property signatureElect() As String
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
    Private _dateDerniereSynchro As DateTime
    <XmlIgnore>
    Public Property dateDerniereSynchro() As DateTime
        Get
            Return _dateDerniereSynchro
        End Get
        Set(ByVal value As DateTime)
            _dateDerniereSynchro = value
        End Set
    End Property
    <XmlElement("dateDerniereSynchro")>
    Public Property dateDerniereSynchroS() As String
        Get
            Return CSDate.GetDateForWS(dateDerniereSynchro)
        End Get
        Set(ByVal Value As String)
            If Value <> "" And Value <> "0000-00-00 00:00:00" Then
                dateDerniereSynchro = Value
            End If
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
        AgentPcManager.Save(Me)
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
            AgentPcManager.Save(Me)
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("Buse.desactiver : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn


    End Function
    Public Function checkRegistry() As Boolean
        Dim bReturn As Boolean
        Try
            Const RegistryPath As String = "HKEY_CURRENT_USER\CRODIP"
            Const subkey1 As String = "CRODIP"
            Const subkey2 As String = "PC"

            Dim IDLu As String = Registry.GetValue(RegistryPath, subkey2, "VIDE")
            Dim cle As String = Registry.GetValue(RegistryPath, subkey1, "VIDE")
            If IDLu.Equals(Me.idPc) And cle.Equals(cleUtilisation) Then
                bReturn = True
            Else
                bReturn = False
#If DEBUG Then
                CSDebug.dispError("AgentPC.checkRegistry MauvaiseClé : (" & Me.cleUtilisation & "/" & IDLu)
#End If
            End If

        Catch ex As Exception
            CSDebug.dispError("AgentPC,CheckRegistry ERR", ex)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Function SaveRegistry() As Boolean
        Dim bReturn As Boolean
        Try
            Const RegistryPath As String = "HKEY_CURRENT_USER\CRODIP"
            Const subkey1 As String = "CRODIP"
            Const subkey2 As String = "PC"

            If String.IsNullOrEmpty(Me.cleUtilisation) Then
                Dim g As New Guid()
                g = Guid.NewGuid()
                Me.cleUtilisation = g.ToString()
            End If
            Registry.SetValue(RegistryPath, subkey1, Me.cleUtilisation)
            Registry.SetValue(RegistryPath, subkey2, Me.idPc)
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("AgentPC.SaveRegistry ERR", ex)
            bReturn = False
        End Try

        Return bReturn
    End Function
    Public Overrides Function Equals(pObj As Object) As Boolean
        Dim bReturn As Boolean = False

        If TypeOf pObj Is AgentPc Then
            bReturn = (Me.uid = CType(pObj, AgentPc).uid)
            bReturn = bReturn And (Me.aid = CType(pObj, AgentPc).aid)
            bReturn = bReturn And (Me.libelle = CType(pObj, AgentPc).libelle)
            bReturn = bReturn And (Me.agentSuppression = CType(pObj, AgentPc).agentSuppression)
            bReturn = bReturn And (Me.dateActivation = CType(pObj, AgentPc).dateActivation)
            bReturn = bReturn And (Me.dateDernierControle = CType(pObj, AgentPc).dateDernierControle)
            bReturn = bReturn And (Me.dateMiseEnService = CType(pObj, AgentPc).dateMiseEnService)
            bReturn = bReturn And (Me.dateSuppression = CType(pObj, AgentPc).dateSuppression)
            bReturn = bReturn And (Me.etat = CType(pObj, AgentPc).etat)
            bReturn = bReturn And (Me.idCrodip = CType(pObj, AgentPc).idCrodip)
            bReturn = bReturn And (Me.isSupprime = CType(pObj, AgentPc).isSupprime)
            bReturn = bReturn And (Me.jamaisServi = CType(pObj, AgentPc).jamaisServi)
            bReturn = bReturn And (Me.numeroNational = CType(pObj, AgentPc).numeroNational)
            bReturn = bReturn And (Me.raisonSuppression = CType(pObj, AgentPc).raisonSuppression)
            bReturn = bReturn And (Me.uidstructure = CType(pObj, AgentPc).uidstructure)
        End If
        Return bReturn
    End Function

End Class