Imports System.Collections.Generic
Imports System.Web.Services
Imports System.Xml.Serialization

<Serializable(), XmlInclude(GetType(Buse))>
Public Class Buse
    Inherits Materiel

    Private _couleur As String = ""
    Private _pressionEtalonnage As Double = 0.0
    Private _debitEtalonnage As Double = 0.0
    Private _isSynchro As Boolean = False
    Private _dateAchat As String = ""
    Private _isUtilise As Boolean = False


    Sub New()
        _lstPools = New List(Of Pool)
    End Sub
    Private _lstPools As List(Of Pool)
    Public Property lstPools() As List(Of Pool)
        Get
            Return _lstPools
        End Get
        Set(ByVal value As List(Of Pool))
            _lstPools = value
        End Set
    End Property


    Public Property couleur() As String
        Get
            Return _couleur
        End Get
        Set(ByVal Value As String)
            _couleur = Value
        End Set
    End Property

    Public Property pressionEtalonnage() As Double
        Get
            Return _pressionEtalonnage
        End Get
        Set(ByVal Value As Double)
            _pressionEtalonnage = Value
        End Set
    End Property

    Public Property debitEtalonnage() As Double
        Get
            Return _debitEtalonnage
        End Get
        Set(ByVal Value As Double)
            _debitEtalonnage = Value
        End Set
    End Property

    Public Property isSynchro() As Boolean
        Get
            Return _isSynchro
        End Get
        Set(ByVal Value As Boolean)
            _isSynchro = Value
        End Set
    End Property

    Public Property dateAchat() As String
        Get
            Return _dateAchat
        End Get
        Set(ByVal Value As String)
            _dateAchat = Value
        End Set
    End Property
    Public Property isUtilise() As Boolean
        Get
            Return _isUtilise
        End Get
        Set(ByVal Value As Boolean)
            _isUtilise = Value
        End Set
    End Property

    Public Overrides Property Libelle() As String
        Get
            Return idCrodip + " (" & Me.couleur & ")"
        End Get
        Set(value As String)

        End Set
    End Property



    Public Overrides Function Fill(pColName As String, pValue As Object) As Boolean
        Select Case pColName.ToUpper.Trim().ToUpper()
            Case "numeroNational".Trim().ToUpper()
                Me.numeroNational = pValue.ToString()
            Case "idCrodip".Trim().ToUpper()
                Me.idCrodip = pValue.ToString()
            Case "idStructure".Trim().ToUpper()
                Me.idStructure = pValue.ToString()
            Case "couleur".Trim().ToUpper()
                Me.couleur = pValue.ToString()
            Case "pressionEtalonnage".Trim().ToUpper()
                Me.pressionEtalonnage = GlobalsCRODIP.StringToDouble(pValue.ToString())
            Case "debitEtalonnage".Trim().ToUpper()
                Me.debitEtalonnage = GlobalsCRODIP.StringToDouble(pValue.ToString())
            Case "isSynchro".Trim().ToUpper()
                Me.isSynchro = pValue
            Case "dateAchat".Trim().ToUpper()
                Me.dateAchat = CSDate.ToCRODIPString(pValue.ToString())
            Case "dateModificationAgent".Trim().ToUpper()
                Me.dateModificationAgent = CSDate.ToCRODIPString(pValue.ToString())
            Case "dateModificationCrodip".Trim().ToUpper()
                Me.dateModificationCrodip = CSDate.ToCRODIPString(pValue.ToString())
            Case "etat".Trim().ToUpper()
                Me.etat = CType(pValue, Boolean)
            Case "isSupprime".Trim().ToUpper()
                Me.isSupprime = CType(pValue, Boolean)
            Case "isUtilise".Trim().ToUpper()
                Me.isUtilise = CType(pValue, Boolean)
            Case "agentsuppression".Trim().ToUpper()
                Me.AgentSuppression = pValue.ToString()
            Case "raisonsuppression".Trim().ToUpper()
                Me.RaisonSuppression = pValue.ToString()
            Case "datesuppression".Trim().ToUpper()
                Me.DateSuppression = CSDate.ToCRODIPString(pValue).ToString()
            Case "jamaisServi".Trim().ToUpper()
                Me.JamaisServi = pValue
            Case "dateActivation".Trim().ToUpper()
                Me.DateActivation = pValue
        End Select

    End Function

    Public Overrides Function DeleteMateriel(ByVal pAgentSuppression As Agent, ByVal pRaison As String) As Boolean
        Me.AgentSuppression = pAgentSuppression.nom
        Me.RaisonSuppression = pRaison
        Me.DateSuppression = Now.ToString()
        Me.dateModificationAgent = Now()
        Me.isSupprime = True
        BuseManager.save(Me)
    End Function
    Public Overrides Function creerFicheVieActivation(ByVal pAgent As Agent) As Boolean
        'Il n'y a pas de fiches de vies pour les buses Etalon
        Return True
    End Function
    Public Overrides Function ActiverMateriel(ByVal pDateActivation As Date, ByVal pAgent As Agent) As Boolean
        Dim bReturn As Boolean
        bReturn = MyBase.ActiverMateriel(pDateActivation, pAgent)
        DateActivation = DateActivation
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

        Dim oNiveau As NiveauAlerte

        oNiveau = getNiveauAlerte(NiveauAlerte.Enum_typeMateriel.Buse)
        bReturn = MyBase.getAlerte(dateAchat, oNiveau)
        Return bReturn
    End Function

    Public Function Desactiver() As Boolean
        Dim bReturn As Boolean

        Try
            ' On bloque la buse
            Me.etat = False
            BuseManager.save(Me)
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("Buse.desactiver : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn


    End Function

End Class