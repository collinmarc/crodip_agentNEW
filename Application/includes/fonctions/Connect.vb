Imports System.Collections.Generic
Imports CRODIPWS
Public Class Connect
    Public Enum enumReturn As Integer
        OK = 0
        AGENTINEXISTANT = -1
        AGENTDESACTIVE = -2
        MDPINCORRECT = -3
        PCINCORRECT = -4
        NOPOOL = -5
        PLUSDUNPOOL = -6
    End Enum
    Public Shared Function Connect(pIdAgent As Integer) As enumReturn
        Dim nReturn As enumReturn = enumReturn.OK
        Dim _LocalAgent As Agent
        Dim oPcRef As AgentPc
        _LocalAgent = AgentManager.getAgentById(pIdAgent)
        'Agent Existant en base
        If _LocalAgent.id <> pIdAgent Then
            nReturn = enumReturn.AGENTINEXISTANT
        End If
        If nReturn = enumReturn.OK Then
            If CSEnvironnement.checkWebService() = True Then
                'Mode Connecté => Verification de l'agent
                Dim oAgentSrv As New Agent
                oAgentSrv = AgentManager.WSgetByNumeroNational(_LocalAgent.numeroNational, True)
                If oAgentSrv.id > 0 Then
                    If oAgentSrv.isActif And Not oAgentSrv.isSupprime Then
                        _LocalAgent.duppliqueInfosAgent(oAgentSrv, False)
                        AgentManager.save(_LocalAgent, True)
                    Else
                        AgentManager.save(oAgentSrv)
                        nReturn = enumReturn.AGENTDESACTIVE
                    End If
                Else
                    nReturn = enumReturn.AGENTINEXISTANT
                End If
            End If
        End If
        If nReturn = enumReturn.OK Then
            If _LocalAgent.versionLogiciel <> GlobalsCRODIP.GLOB_APPLI_VERSION & "-" & GlobalsCRODIP.GLOB_APPLI_BUILD Then
                _LocalAgent.versionLogiciel = GlobalsCRODIP.GLOB_APPLI_VERSION & "-" & GlobalsCRODIP.GLOB_APPLI_BUILD
                CSDebug.dispInfo("Login.doLogin():: Save Agent Version : " & _LocalAgent.dateModificationAgent)
                AgentManager.save(_LocalAgent)
            End If
        End If
        oPcRef = Nothing
        If nReturn = enumReturn.OK Then
            ' Vérification du PC En base de registre
            oPcRef = AgentPcManager.GetAgentPCFromRegistry()
            If oPcRef Is Nothing Then
                'Création du PC en base de registre
                InitRegistry()
                'puis rechargement
                oPcRef = AgentPcManager.GetAgentPCFromRegistry()
                If oPcRef Is Nothing Then
                    nReturn = enumReturn.PCINCORRECT
                End If
            Else
                'controle de la clé en Registre si aqw<> zsx
                If My.Settings.aqw <> "zsx" Then
                    If Not oPcRef.checkRegistry() Then
                        nReturn = enumReturn.PCINCORRECT
                    End If
                End If
            End If
            If oPcRef.dateDerniereSynchro = DateTime.MinValue Then
                oPcRef.dateDerniereSynchro = _LocalAgent.dateDerniereSynchro
            End If
        End If
        Dim olstPoolPc As List(Of PoolPc) = New List(Of PoolPc)()
        If nReturn = enumReturn.OK Then
            olstPoolPc = PoolPcManager.getListeByStructure(_LocalAgent.uidstructure)
            If olstPoolPc.Count = 0 Then
                'Cas particulier : 1ere connexion , il y a un PC mais pas de poolpc
                'On récupère les poolPc et les pool depuis les WS
                olstPoolPc = PoolPcManager.WSGetListByPC(_LocalAgent, oPcRef)
                If olstPoolPc.Count > 0 Then
                    For Each oPoolPc As PoolPc In olstPoolPc
                        'On récupére les Pool depuis les PoolPc si nécessaire
                        Dim oPool As Pool
                        oPool = PoolManager.getPoolByuid(oPoolPc.uidpool)
                        If oPool Is Nothing Then
                            oPool = PoolManager.WSgetById(oPoolPc.uid, oPoolPc.aid)
                            PoolManager.Save(oPool)
                        End If
                        PoolPcManager.Save(oPoolPc)
                    Next
                Else
                    nReturn = enumReturn.NOPOOL
                End If
            End If
        End If

        If nReturn = enumReturn.OK Then
            _LocalAgent.oPCcourant = oPcRef 'Le PC Encours est celui en base de registre
            Dim lstPool As New List(Of Pool)()

            'Récupération de la liste des pools de l'agent relatif à ce pc
            If CSEnvironnement.checkWebService Then
                'Si on est connecté => Récupération sur le Serveur
                olstPoolPc = PoolPcManager.WSGetListByPC(_LocalAgent, oPcRef)
                For Each oPoolPc As PoolPc In olstPoolPc
                    Dim oPool As Pool
                    oPool = PoolManager.WSgetById(oPoolPc.uidpool, "")
                    If oPool IsNot Nothing Then
                        If oPool.CheckPool(_LocalAgent) Then
                            lstPool.Add(oPool)
                        End If
                    End If
                Next
            Else
                lstPool = _LocalAgent.getPoolList(oPcRef)
            End If

            If lstPool.Count() = 0 Then
                _LocalAgent.oPool = Nothing
                nReturn = enumReturn.NOPOOL
            End If

            If nReturn = enumReturn.OK Then
                agentCourant = _LocalAgent
            End If

            If lstPool.Count() = 1 Then   'C'est le cas normal
                _LocalAgent.oPool = lstPool(0)
                nReturn = enumReturn.OK
            Else
                nReturn = enumReturn.PLUSDUNPOOL
            End If
        End If

        Return nReturn
    End Function

    Public Shared Sub InitRegistry()
        Dim strNumPc As String = ""
        If AgentPcManager.IsRegistryVide Then
            'Pas de AgentPC de reference sur le PC = > PC à VIDE !!!!
            While (strNumPc.Length <> 5 Or Not IsNumeric(strNumPc))
                strNumPc = InputBox("Veuillez entrer le numéro CRODIP du PC (5 chiffres) ", "Saisie du numéro CRODIP du PC")
                If strNumPc.Length = 0 Then
                    'On sort si on click sur Annul
                    Exit Sub
                Else
                    'Récupération du PCRef sur le Serveur
                    Dim oPcRef As AgentPc = AgentPcManager.WSgetById(-1, strNumPc)
                    If oPcRef IsNot Nothing Then
                        If Not oPcRef.SaveRegistry() Then
                            Statusbar.display("ERREUR REGISTRY")
                            strNumPc = ""
                        End If
                        Dim oPCReturn As AgentPc = Nothing
                        AgentPcManager.WSSend(oPcRef, oPCReturn)
                        AgentPcManager.Save(oPcRef, True) 'on considère que c'est une synhcro
                    Else
                        Statusbar.display("PC non référencé")
                        strNumPc = ""
                    End If

                End If
            End While
        End If
    End Sub


End Class
