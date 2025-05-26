Imports System.Xml.Serialization
Public Class Pool
    Inherits Materiel
    Private _libelle As String
    Public Overrides Property libelle() As String
        Get
            Return _libelle
        End Get
        Set(ByVal value As String)
            _libelle = value
        End Set
    End Property

    Public Property idPool() As String
        Get
            Return idCrodip
        End Get
        Set(ByVal value As String)
            idCrodip = value
        End Set
    End Property
    Private _nbPastillesVertes As Integer
    Public Property nbPastillesVertes() As Integer
        Get
            Return _nbPastillesVertes
        End Get
        Set(ByVal value As Integer)
            _nbPastillesVertes = value
        End Set
    End Property
    Private _aidBanc As String
    Public Property aidbanc() As String
        Get
            Return _aidBanc
        End Get
        Set(ByVal value As String)
            _aidBanc = value
        End Set
    End Property
    Private _uidbanc As Integer
    Public Property uidbanc() As Integer
        Get
            Return _uidbanc
        End Get
        Set(ByVal value As Integer)
            _uidbanc = value
        End Set
    End Property
    '' Pour cohérence avec le serveur
    Public Property dateMiseEnService() As String
        Get
            Return dateActivationS
        End Get
        Set(ByVal Value As String)
            dateActivationS = Value
        End Set
    End Property
    Public Sub New()
        libelle = ""
        nbPastillesVertes = 0
    End Sub

    Public Overrides Function Fill(pcolName As String, pValue As Object) As Boolean
        Dim bReturn As Boolean
        Try
            bReturn = MyBase.Fill(pcolName, pValue)
            If Not bReturn Then
                bReturn = True
                Select Case pcolName.Trim().ToUpper()
                    Case "libelle".Trim().ToUpper()
                        Me.libelle = pValue.ToString()
                    Case "idPool".Trim().ToUpper()
                        Me.idCrodip = pValue
                    Case "uidStructure".Trim().ToUpper()
                        Me.uidstructure = pValue
                    Case "nbPastillesVertes".Trim().ToUpper()
                        Me.nbPastillesVertes = pValue
                    Case "idbanc".Trim().ToUpper()
                        Me.aidbanc = pValue
                    Case "uidbanc".Trim().ToUpper()
                        Me.uidbanc = pValue
                    Case Else
                        bReturn = False
                End Select
            End If
        Catch ex As Exception
            CSDebug.dispError("Pool.Fill ERR : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function


    Public Overrides Function creerFichevieActivation(pAgent As Agent) As Boolean
        Return False
    End Function
    ''' <summary>
    ''' Rend le Premier PC du pool (normalement 1)
    ''' </summary>
    ''' <returns></returns>
    Public Function getPc() As AgentPc
        Dim oReturn As AgentPc = Nothing
        Try
            Dim lst As List(Of AgentPc)
            lst = PoolPcManager.GetLstPcByPool(Me)
            oReturn = lst(0)
        Catch ex As Exception

            CSDebug.dispError("Pool.getPC Err", ex)
            oReturn = Nothing
        End Try
        Return oReturn
    End Function

    Public Overrides Function Equals(pObj As Object) As Boolean
        Dim bReturn As Boolean = False

        If TypeOf pObj Is Pool Then
            bReturn = (Me.uid = CType(pObj, Pool).uid)
            bReturn = bReturn And (Me.aid = CType(pObj, Pool).aid)
            bReturn = bReturn And (Me.libelle = CType(pObj, Pool).libelle)
            bReturn = bReturn And (Me.agentSuppression = CType(pObj, Pool).agentSuppression)
            bReturn = bReturn And (Me.aidbanc = CType(pObj, Pool).aidbanc)
            bReturn = bReturn And (Me.dateActivation = CType(pObj, Pool).dateActivation)
            bReturn = bReturn And (Me.dateDernierControle = CType(pObj, Pool).dateDernierControle)
            bReturn = bReturn And (Me.dateMiseEnService = CType(pObj, Pool).dateMiseEnService)
            bReturn = bReturn And (Me.dateSuppression = CType(pObj, Pool).dateSuppression)
            bReturn = bReturn And (Me.etat = CType(pObj, Pool).etat)
            bReturn = bReturn And (Me.idCrodip = CType(pObj, Pool).idCrodip)
            bReturn = bReturn And (Me.idPool = CType(pObj, Pool).idPool)
            bReturn = bReturn And (Me.isSupprime = CType(pObj, Pool).isSupprime)
            bReturn = bReturn And (Me.jamaisServi = CType(pObj, Pool).jamaisServi)
            bReturn = bReturn And (Me.nbPastillesVertes = CType(pObj, Pool).nbPastillesVertes)
            bReturn = bReturn And (Me.numeroNational = CType(pObj, Pool).numeroNational)
            bReturn = bReturn And (Me.raisonSuppression = CType(pObj, Pool).raisonSuppression)
            bReturn = bReturn And (Me.uidbanc = CType(pObj, Pool).uidbanc)
            bReturn = bReturn And (Me.uidstructure = CType(pObj, Pool).uidstructure)
        End If
        Return bReturn
    End Function
    Public Function CheckPool(pagent As Agent) As Boolean
        Debug.Assert(pagent.oPCcourant IsNot Nothing, "Le PC doit être initialisé")
        Dim bReturn As Boolean = True
        If CSEnvironnement.checkWebService() Then
            'on va vérifier que ce pool contient toujours l'Agent et le PC
            Dim oLstP As List(Of PoolAgent)
            oLstP = PoolAgentManager.WSgetListeByAgent(pagent)
            'Y-a-il un PoolAgent pour Ce pool et l'agent Courrant?
            bReturn = oLstP.Exists(Function(p)
                                       Return p.uidpool = Me.uid
                                   End Function)
            If Not bReturn Then
                CSDebug.dispError("Pool.CheckPool : Le pool[" & Me.uid & "] ne contient pas l'agent[" & pagent.uid & "]")
            End If
        End If

        Return bReturn

    End Function
End Class
