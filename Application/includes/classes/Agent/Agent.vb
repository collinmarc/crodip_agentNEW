Imports System.Web.Services
Imports System.Xml.Serialization
Imports System.Collections.Generic
Imports System.Data.Common

Public Class AgentList

    Private _List As List(Of Agent)

    Sub New()
        _List = New List(Of Agent)
    End Sub

    Public ReadOnly Property items() As List(Of Agent)
        Get
            Return _List
        End Get
    End Property

End Class

<Serializable(), XmlInclude(GetType(Agent))>
Public Class Agent

    Private _id As Integer
    Private _numeroNational As String
    Private _motDePasse As String
    Private _nom As String
    Private _prenom As String
    Private _idStructure As Integer
    Private _telephonePortable As String
    Private _eMail As String
    Private _statut As String
    Private _dateCreation As String
    Private _dateDerniereConnexion As String
    Private _dateDerniereSynchro As String
    Private _dateModificationAgent As String
    Private _dateModificationCrodip As String
    Private _versionLogiciel As String
    Private _commentaire As String
    Private _cleActivation As String
    Private _isActif As Boolean
    Private _NomStructure As String
    Private _isSupprime As Boolean
    Private _droitsPulves As String
    Private _IsGestionnaire As Boolean
    Private _IsSignElecActive As Boolean
    Private _idCRODIPPool As String
    Private _oPool As Pool




    Sub New()
        _id = 0
        _numeroNational = ""
        _motDePasse = ""
        _nom = ""
        _prenom = ""
        _idStructure = 0
        _telephonePortable = ""
        _eMail = ""
        _statut = ""
        _dateCreation = ""
        _dateDerniereConnexion = ""
        _dateDerniereSynchro = ""
        _dateModificationAgent = ""
        _dateModificationCrodip = ""
        _versionLogiciel = ""
        _commentaire = ""
        _cleActivation = ""
        _isActif = False
        _isSupprime = False
        _droitsPulves = ""
        _IsGestionnaire = False
        _IsSignElecActive = False
        _idCRODIPPool = ""
    End Sub
    Sub New(pId As Integer, pNumeroNational As String, pnom As String, pidStructure As Integer)
        Me.New()
        _id = pId
        _numeroNational = pNumeroNational
        _nom = pnom
        _idStructure = pidStructure
        dateDerniereSynchro = CSDate.ToCRODIPString(AgentManager.GetDateDernSynchro(pidStructure))
    End Sub

    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal Value As Integer)
            _id = Value
        End Set
    End Property

    Public Property numeroNational() As String
        Get
            Return _numeroNational
        End Get
        Set(ByVal Value As String)
            _numeroNational = Value
        End Set
    End Property

    Public Property motDePasse() As String
        Get
            Return _motDePasse
        End Get
        Set(ByVal Value As String)
            _motDePasse = Value
        End Set
    End Property

    Public Property nom() As String
        Get
            Return _nom
        End Get
        Set(ByVal Value As String)
            _nom = Value
        End Set
    End Property

    Public Property prenom() As String
        Get
            Return _prenom
        End Get
        Set(ByVal Value As String)
            _prenom = Value
        End Set
    End Property

    Public Property idStructure() As Integer
        Get
            Return _idStructure
        End Get
        Set(ByVal Value As Integer)
            _idStructure = Value
        End Set
    End Property

    Public Property telephonePortable() As String
        Get
            Return _telephonePortable
        End Get
        Set(ByVal Value As String)
            _telephonePortable = Value
        End Set
    End Property

    Public Property eMail() As String
        Get
            Return _eMail
        End Get
        Set(ByVal Value As String)
            _eMail = Value
        End Set
    End Property

    Public Property statut() As String
        Get
            Return _statut
        End Get
        Set(ByVal Value As String)
            _statut = Value
        End Set
    End Property

    Public Property dateCreation() As String
        Get
            Return _dateCreation
        End Get
        Set(ByVal Value As String)
            _dateCreation = Value
        End Set
    End Property

    Public Property dateDerniereConnexion() As String
        Get
            Return _dateDerniereConnexion
        End Get
        Set(ByVal Value As String)
            _dateDerniereConnexion = Value
        End Set
    End Property

    Public Property dateDerniereSynchro() As String
        Get
            Return _dateDerniereSynchro
        End Get
        Set(ByVal Value As String)
            _dateDerniereSynchro = Value
        End Set
    End Property

    Public Property dateModificationAgent() As String
        Get
            Return _dateModificationAgent
        End Get
        Set(ByVal Value As String)
            _dateModificationAgent = Value
        End Set
    End Property

    Public Property dateModificationCrodip() As String
        Get
            Return _dateModificationCrodip
        End Get
        Set(ByVal Value As String)
            _dateModificationCrodip = Value
        End Set
    End Property

    Public Property versionLogiciel() As String
        Get
            Return _versionLogiciel
        End Get
        Set(ByVal Value As String)
            _versionLogiciel = Value
        End Set
    End Property

    Public Property commentaire() As String
        Get
            Return _commentaire
        End Get
        Set(ByVal Value As String)
            _commentaire = Value
        End Set
    End Property

    Public Property cleActivation() As String
        Get
            Return _cleActivation
        End Get
        Set(ByVal Value As String)
            _cleActivation = Value
        End Set
    End Property

    Public Property isActif() As Boolean
        Get
            Return _isActif
        End Get
        Set(ByVal Value As Boolean)
            _isActif = Value
        End Set
    End Property
    Public Property isSupprime() As Boolean
        Get
            Return _isSupprime
        End Get
        Set(ByVal Value As Boolean)
            _isSupprime = Value
        End Set
    End Property

    <XmlIgnoreAttribute()>
    Public Property NomStructure() As String
        Get
            Try

                Dim oStructure As Structuree
                oStructure = New Structuree
                oStructure = StructureManager.getStructureById(idStructure)
                Return oStructure.nom
            Catch ex As Exception
                Return ""
            End Try

        End Get
        Set(ByVal Value As String)
            '            _NomStructure = Value
        End Set
    End Property

    Public Property DroitsPulves As String
        Get
            If Not _droitsPulves.StartsWith("|") And Not String.IsNullOrEmpty(_droitsPulves) Then
                Return "|" & _droitsPulves & "|"
            Else
                Return _droitsPulves
            End If

        End Get
        Set(value As String)
            _droitsPulves = value
        End Set
    End Property

    Public Property isGestionnaire As Boolean
        Get
            Return _IsGestionnaire
        End Get
        Set(value As Boolean)
            _IsGestionnaire = value
        End Set
    End Property
    <XmlElement("SignatureElect")>
    Public Property isSignElecActive As Boolean
        Get
            Return _IsSignElecActive
        End Get
        Set(value As Boolean)
            _IsSignElecActive = value
        End Set
    End Property
    Public Property idCRODIPPool() As String
        Get
            Return _idCRODIPPool
        End Get
        Set(ByVal value As String)
            _idCRODIPPool = value
        End Set
    End Property
    <XmlIgnore()>
    Public Property oPool() As Pool
        Get
            Return _oPool
        End Get
        Set(ByVal value As Pool)
            _oPool = value
        End Set
    End Property
    ''' <summary>
    ''' Rend la liste des types et cat�gories de pulv�s disponibles. L'utilisation des droits des inspecteurs est facultative
    ''' </summary>
    ''' <param name="pbUtilisationDesDroits">Vrai=utilisation des droits</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getTypeCategoriePulveAutorise(pbUtilisationDesDroits As Boolean) As List(Of TypeCategoriePulve)
        'Parcours du fichier config pour remplir une Liste des types-categories
        Dim olstTypeCat As New List(Of TypeCategoriePulve)
        Dim oNodes As Xml.XmlNodeList
        oNodes = GlobalsCRODIP.GLOB_XML_TYPES_CATEGORIES_PULVE.getXmlNodes(MarquesManager.XPATH_TYPES_PULVE)
        For Each oNode As Xml.XmlNode In oNodes
            Dim xpath As String
            xpath = MarquesManager.XPATH_CATEGORIES_PULVE.Replace("%type%", oNode.InnerText)
            Dim oNodesCategorie As Xml.XmlNodeList = GlobalsCRODIP.GLOB_XML_TYPES_CATEGORIES_PULVE.getXmlNodes(xpath)
            For Each oNodeCategorie As Xml.XmlNode In oNodesCategorie
                Dim oItem As New TypeCategoriePulve
                oItem.type = oNode.InnerText
                oItem.categorie = oNodeCategorie.InnerText
                olstTypeCat.Add(oItem)
            Next
        Next
        'Parcours de la liste pour filtrer sur les droits (Si demand�)
        Dim oReturn As New List(Of TypeCategoriePulve)
        For Each oItem As TypeCategoriePulve In olstTypeCat
            If String.IsNullOrEmpty(DroitsPulves) Or Not pbUtilisationDesDroits Then
                oReturn.Add(oItem)
            Else
                If AleDroit(oItem.type & "." & oItem.categorie) Then
                    oReturn.Add(oItem)
                End If
            End If
        Next

        Return oReturn
    End Function
    ''' <summary>
    ''' Rend Vrai ou faux selon que l'utilisateur a le droit sur ce type ou cette cat�gorie
    ''' </summary>
    ''' <param name="pTypeOrCategorie"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function AleDroit(pTypeAndCategorie As String) As Boolean
        Dim bReturn As Boolean = True
        'Dim droits As String = DroitsPulves.Replace("|", "")
        Dim droits As String() = DroitsPulves.Split("|")
        '        If Not String.IsNullOrEmpty(DroitsPulves) Then
        bReturn = False
        For Each Str As String In droits
            If Trim(Str).ToUpper() = Trim(pTypeAndCategorie).ToUpper() Then
                bReturn = True
                Exit For
            End If
        Next
        'End If
        Return bReturn
    End Function
    Public Function AleDroit(pPulve As Pulverisateur) As Boolean
        Dim bReturn As Boolean
        bReturn = AleDroit(pPulve.type & "." & pPulve.categorie)
        Return bReturn
    End Function
    Public Function Fill(pcolName As String, pValue As Object) As Boolean
        Dim bReturn As Boolean
        Try
            Select Case pcolName.Trim().ToUpper()
                Case "id".Trim().ToUpper()
                    Me.id = pValue
                Case "numeroNational".Trim().ToUpper()
                    Me.numeroNational = pValue.ToString()
                Case "motDePasse".Trim().ToUpper()
                    Me.motDePasse = pValue.ToString()
                Case "nom".Trim().ToUpper()
                    Me.nom = pValue.ToString()
                Case "prenom".Trim().ToUpper()
                    Me.prenom = pValue.ToString()
                Case "idStructure".Trim().ToUpper()
                    Me.idStructure = pValue
                Case "telephonePortable".Trim().ToUpper()
                    Me.telephonePortable = pValue.ToString()
                Case "eMail".Trim().ToUpper()
                    Me.eMail = pValue.ToString()
                Case "statut".Trim().ToUpper()
                    Me.statut = pValue.ToString()
                Case "dateCreation".Trim().ToUpper()
                    Me.dateCreation = pValue.ToString()
                Case "dateDerniereConnexion".Trim().ToUpper()
                    Me.dateDerniereConnexion = pValue.ToString()
                Case "dateDerniereSynchro".Trim().ToUpper()
                    Me.dateDerniereSynchro = pValue.ToString()
                Case "dateModificationAgent".Trim().ToUpper()
                    Me.dateModificationAgent = pValue.ToString()
                Case "dateModificationCrodip".Trim().ToUpper()
                    Me.dateModificationCrodip = pValue.ToString()
                Case "versionLogiciel".Trim().ToUpper()
                    Me.versionLogiciel = pValue.ToString()
                Case "commentaire".Trim().ToUpper()
                    Me.commentaire = pValue.ToString()
                Case "cleActivation".Trim().ToUpper()
                    Me.cleActivation = pValue.ToString()
                Case "isActif".Trim().ToUpper()
                    Me.isActif = pValue
                Case "isSupprime".Trim().ToUpper()
                    Me.isSupprime = pValue
                Case "structureNom".Trim().ToUpper()
                    Me.NomStructure = pValue
                Case "DroitsPulves".Trim().ToUpper()
                    Me.DroitsPulves = pValue
                Case "isGestionnaire".Trim().ToUpper()
                    Me.isGestionnaire = pValue
                Case "SignatureElect".Trim().ToUpper()
                    Me.isSignElecActive = pValue
                Case "isSignElecActive".Trim().ToUpper()
                    Me.isSignElecActive = pValue
                Case "idCRODIPPool".Trim().ToUpper()
                    Me.idCRODIPPool = pValue
                    If idCRODIPPool <> "" Then
                        oPool = PoolManager.getPoolByIdCRODIP(idCRODIPPool)
                    End If
            End Select

            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("Agent.Fill ERR : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

#Region "Suppression d'un agent"
    Public Function deleteSubItems() As Boolean
        Dim bReturn As Boolean

        bReturn = deleteDiagnostic()
        If bReturn Then
            bReturn = deletePulverisateur()
        End If
        If bReturn Then
            bReturn = deleteExploitation()
        End If
        If bReturn Then
            bReturn = deleteMateriel()
        End If
        Return bReturn

    End Function
    ''' <summary>
    ''' Suppression des Diagnostic d'un Agent
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function deleteDiagnostic() As Boolean
        Debug.Assert(id > 0, " le param�tre AgentID doit �tre initialis�")
        CSDebug.dispError("Suppression des Diagnostiques de l'agent " & id)
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand
        Dim bReturn As Boolean
        Dim oDR As DbDataReader
        Dim idDiag As String
        Try
            oCsdb = New CSDb(True)

            bddCommande = oCsdb.getConnection.CreateCommand()
            bddCommande.CommandText = "SELECT id from Diagnostic WHERE inspecteurid=" & id.ToString() & ""
            oDR = bddCommande.ExecuteReader()
            While oDR.Read()
                idDiag = oDR.GetString(0)
                If Not String.IsNullOrEmpty(idDiag) Then
                    DiagnosticManager.delete(idDiag)
                    'Les factures ne sont pas attach�s � un agent , donc pas de suppression
                End If
            End While
            oDR.Close()

            bReturn = True
        Catch ex As Exception
            CSDebug.dispFatal("Agent.deleteDiagnostic (" & id.ToString() & ") Error: " & ex.Message.ToString)
            bReturn = False
        End Try
        If Not oCsdb Is Nothing Then
            oCsdb.free()
        End If
        Return bReturn
    End Function 'deleteDiagnostic
    ''' <summary>
    ''' Suppression des pulv�risateur d'un agent
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function deletePulverisateur() As Boolean
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand
        Dim bReturn As Boolean
        Dim oDR As DbDataReader
        Dim idPulve As String
        Try
            CSDebug.dispError("Suppression des Pulv�risateurs de l'agent " & id)
            oCsdb = New CSDb(True)

            bddCommande = oCsdb.getConnection.CreateCommand()
            bddCommande.CommandText = "SELECT id from pulverisateur WHERE id like " & ControlChars.Quote & "%-" & id.ToString() & "-%" & ControlChars.Quote
            oDR = bddCommande.ExecuteReader()
            While (oDR.Read())
                idPulve = oDR.GetString(0)
                If Not String.IsNullOrEmpty(idPulve) Then
                    PulverisateurManager.deletePulverisateurID(idPulve)
                End If
            End While
            oDR.Close()

            bReturn = True
        Catch ex As Exception
            CSDebug.dispFatal("Agent.deletePulverisateur (" & id.ToString() & ") Error: " & ex.Message.ToString)
            bReturn = False
        End Try
        If Not oCsdb Is Nothing Then
            oCsdb.free()
        End If
        Return bReturn
    End Function 'deletePulverisateur
    ''' <summary>
    ''' Suppression des pulv�risateurs d'un agent
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function deleteExploitation() As Boolean
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand
        Dim bReturn As Boolean
        Dim oDR As DbDataReader
        Dim idExploit As String
        Try
            CSDebug.dispError("Suppression des Exploitations de l'agent " & id)
            oCsdb = New CSDb(True)

            bddCommande = oCsdb.getConnection.CreateCommand()
            bddCommande.CommandText = "SELECT id from Exploitation WHERE id like " & ControlChars.Quote & "%-" & id.ToString() & "-%" & ControlChars.Quote
            oDR = bddCommande.ExecuteReader()
            While (oDR.Read())
                idExploit = oDR.GetString(0)
                If Not String.IsNullOrEmpty(idExploit) Then
                    ExploitationManager.delete(idExploit)
                End If
            End While
            oDR.Close()

            bReturn = True
        Catch ex As Exception
            CSDebug.dispFatal("Agent.deletePulverisateur (" & id.ToString() & ") Error: " & ex.Message.ToString)
            bReturn = False
        End Try
        If Not oCsdb Is Nothing Then
            oCsdb.free()
        End If
        Return bReturn
    End Function 'deleteExploitation
    ''' <summary>
    ''' suppression du materiel d'un agent
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function deleteMateriel() As Boolean
        Dim bReturn As Boolean
        Try
            CSDebug.dispError("Suppression du materiel  de l'agent " & id)
            bReturn = deleteBuse()
            If bReturn Then
                bReturn = deleteManoControle()
            End If
            If bReturn Then
                bReturn = deleteManoEtalon()
            End If
            If bReturn Then
                bReturn = deleteBancMesure()
            End If
            If bReturn Then
                bReturn = deleteControleRegulier()
            End If
        Catch ex As Exception
            CSDebug.dispFatal("AgentManager.deleteMateriel (" & id.ToString() & ") Error: " & ex.Message.ToString)
            bReturn = False
        End Try
        Return bReturn
    End Function 'deleteMateriel
    ''' <summary>
    ''' suppression des buses d'un agent
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function deleteBuse() As Boolean
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand
        Dim bReturn As Boolean
        Dim oDR As DbDataReader

        Try
            oCsdb = New CSDb(True)
            bddCommande = oCsdb.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT numeroNational from AgentBuseEtalon where numeroNational like " & ControlChars.Quote & "%-" & id & "-%" & ControlChars.Quote
            oDR = bddCommande.ExecuteReader()
            While oDR.Read()
                BuseManager.delete(oDR.GetString(0))
            End While
            oDR.Close()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispFatal("AgentManager.deleteBuse (" & id.ToString() & ") Error: " & ex.Message.ToString)
            bReturn = False
        End Try
        If Not oCsdb Is Nothing Then
            oCsdb.free()
        End If
        Return bReturn
    End Function 'deleteBuse

    ''' <summary>
    ''' suppression des Mano de controle d'un agent
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function deleteManoControle() As Boolean
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand
        Dim bReturn As Boolean
        Dim oDR As DbDataReader
        Try
            oCsdb = New CSDb(True)
            bddCommande = oCsdb.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT numeroNational from AgentMAnoControle where numeroNational like " & ControlChars.Quote & "%-" & id & "-%" & ControlChars.Quote
            oDR = bddCommande.ExecuteReader()
            While oDR.Read()

                ManometreControleManager.delete(oDR.GetString(0))
            End While
            oDR.Close()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispFatal("Agent.deleteManoControle () Error: " & ex.Message.ToString)
            bReturn = False
        End Try
        If Not oCsdb Is Nothing Then
            oCsdb.free()
        End If
        Return bReturn
    End Function 'deleteManoControle
    ''' <summary>
    ''' suppression des Mano Etalon d'un agent
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function deleteManoEtalon() As Boolean
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand
        Dim bReturn As Boolean
        Dim oDR As DbDataReader
        Try
            oCsdb = New CSDb(True)
            bddCommande = oCsdb.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT numeroNational from AgentMAnoEtalon where numeroNational like " & ControlChars.Quote & "%-" & id & "-%" & ControlChars.Quote
            oDR = bddCommande.ExecuteReader()
            While oDR.Read()
                'Suppression des ControleManoMesure
                Dim oDR2 As DbDataReader
                Dim bddCommande2 As DbCommand
                bddCommande2 = oCsdb.getConnection().CreateCommand()
                bddCommande2.CommandText = "SELECT id from ControleManoMesure where ManoEtalon = " & ControlChars.Quote & oDR.GetString(0) & ControlChars.Quote
                oDR2 = bddCommande2.ExecuteReader()
                'While oDR2.Read()
                '    ControleManoManager.delete(oDR2.GetString(0))
                'End While
                oDR2.Close()

                ManometreEtalonManager.delete(oDR.GetString(0))
            End While
            oDR.Close()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispFatal("Agent.deleteManoEtalon () Error: " & ex.Message.ToString)
            bReturn = False
        End Try
        If Not oCsdb Is Nothing Then
            oCsdb.free()
        End If
        Return bReturn
    End Function 'deleteManoEtalon

    ''' <summary>
    ''' suppression des BancMesures d'un agent
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function deleteBancMesure() As Boolean
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand
        Dim bReturn As Boolean
        Dim oDR As DbDataReader
        Try
            oCsdb = New CSDb(True)
            bddCommande = oCsdb.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT id from BancMesure where id like " & ControlChars.Quote & "%-" & id & "-%" & ControlChars.Quote
            oDR = bddCommande.ExecuteReader()
            While oDR.Read()
                BancManager.delete(oDR.GetString(0))
            End While
            oDR.Close()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispFatal("Agent.deleteBancMesure () Error: " & ex.Message.ToString)
            bReturn = False
        End Try
        If Not oCsdb Is Nothing Then
            oCsdb.free()
        End If
        Return bReturn
    End Function 'deleteBancMesure
    ''' <summary>
    ''' suppression des controlesRegulier effectu�s par un agent
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function deleteControleRegulier() As Boolean
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand
        Dim bReturn As Boolean
        Try
            oCsdb = New CSDb(True)
            bddCommande = oCsdb.getConnection().CreateCommand()
            bddCommande.CommandText = "DELETE FROM controle_regulier where ctrg_numagent ='" & id & "'"
            bddCommande.ExecuteNonQuery()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispFatal("Agent.deleteControleRegulier () Error: " & ex.Message.ToString)
            bReturn = False
        End Try
        If Not oCsdb Is Nothing Then
            oCsdb.free()
        End If
        Return bReturn
    End Function 'deleteControleRegulier
#End Region

    Public Function duppliqueInfosAgent(pAgent As Agent, pTouteslesInfos As Boolean) As Boolean
        Dim bReturn As Boolean
        Try

            If pTouteslesInfos Then
                Me.id = pAgent.id
                Me.numeroNational = pAgent.numeroNational
                Me.idStructure = pAgent.idStructure
                Me.telephonePortable = pAgent.telephonePortable
                Me.eMail = pAgent.eMail
                Me.statut = pAgent.statut
                Me.dateCreation = pAgent.dateCreation
                Me.dateDerniereConnexion = pAgent.dateDerniereConnexion
                Me.dateDerniereSynchro = pAgent.dateDerniereSynchro
                Me.dateModificationAgent = pAgent.dateModificationAgent
                Me.dateModificationCrodip = pAgent.dateModificationCrodip
                Me.cleActivation = pAgent.cleActivation
                Me.idCRODIPPool = pAgent.idCRODIPPool
            End If
            Me.nom = pAgent.nom
            Me.prenom = pAgent.prenom
            Me.motDePasse = pAgent.motDePasse
            Me.isActif = pAgent.isActif
            Me.isSupprime = pAgent.isSupprime
            Me.NomStructure = pAgent.NomStructure
            Me.DroitsPulves = pAgent.DroitsPulves
            Me.isGestionnaire = pAgent.isGestionnaire
            Me.versionLogiciel = pAgent.versionLogiciel
            Me.commentaire = pAgent.commentaire
            Me.isSignElecActive = pAgent.isSignElecActive
            bReturn = True
        Catch ex As Exception

            bReturn = False
        End Try
        Return bReturn

    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        Dim bReturn As Boolean = False
        If (obj IsNot Nothing) Then
            If obj.GetType().Equals(Me.GetType()) Then
                Dim oagent As Agent
                oagent = CType(obj, Agent)
                bReturn = (Me.id = oagent.id)

            End If
        End If
        Return bReturn
    End Function



    Public Function checkPC() As Boolean
        Dim oAgentPC As AgentPC
        Dim bReturn As Boolean
        Dim bCleARegenerer As Boolean = False
        bReturn = False
        If oPool IsNot Nothing And My.Settings.aqw <> "zsx" Then
            oAgentPC = AgentPCManager.RESTgetAgentPCByIDCrodip(Me, oPool.idCRODIPPC)
            If oAgentPC Is Nothing Then
                'La r�ception via le WS ne fonctionne pas, on charge celui qui est en base
                oAgentPC = oPool.getAgentPC()
            End If
            's'il y a un PC , on v�rifie la base de registre, sinon on arr�te
            If oAgentPC IsNot Nothing Then
                bCleARegenerer = String.IsNullOrEmpty(oAgentPC.numInterne)
                bReturn = oAgentPC.checkRegistry()
                If bCleARegenerer Then
                    AgentPCManager.save(oAgentPC)
                    AgentPCManager.RESTsetAgentPC(Me, oAgentPC)
                End If
            Else
                bReturn = False
            End If
        Else
            bReturn = True
        End If

        Return bReturn
    End Function
End Class