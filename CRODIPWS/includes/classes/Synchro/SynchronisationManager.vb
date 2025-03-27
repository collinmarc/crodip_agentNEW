Imports System.Collections.Generic
Imports System.Xml.Serialization
Imports System.IO.File
Imports NLog
Imports System.Xml
Imports System.Linq
Imports System.Data.Common

''' <summary>
''' 
''' </summary>
''' <remarks></remarks>
Public Class SynchronisationManager
    Private Shared logger As Logger = LogManager.GetCurrentClassLogger()

    Public Shared Function DBsaveSynchro(pagent As Agent, ByVal _sens As String, ByVal _log As String) As Boolean
        Dim bReturn As Boolean
        Try

            Dim CSDb As New CSDb(True)

            Dim bddCommande As DbCommand
            bddCommande = CSDb.getConnection().CreateCommand()
            ' Création du nouveau log
            bddCommande.CommandText = "INSERT INTO `Synchronisation` (`idAgent`,`sensSynchronisation`,`dateSynchronisation`,`logSynchronisation`) VALUES (" & CSDb.secureString(pagent.uidStructure) & ",'" & CSDb.secureString(_sens) & "','" & CSDate.ToCRODIPString(Date.Now) & "','" & CSDb.secureString(_log) & "')"
            bddCommande.ExecuteNonQuery()


            CSDb.free()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("SynchronisationManager - DBsaveSynchro : " & ex.Message)
            CSDebug.dispError("SynchronisationManager - DBsaveSynchro : " & _sens)
            CSDebug.dispError("SynchronisationManager - DBsaveSynchro : " & _log)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Shared Sub LogSynchroStart(ByVal pSens As String)
        logger.Trace("<synchro Sens = " & ControlChars.Quote & pSens & ControlChars.Quote & " date = " & ControlChars.Quote & System.DateTime.Now() & ControlChars.Quote & ">")

    End Sub
    Public Shared Sub LogSynchroEnd()
        logger.Trace("</synchro>")

    End Sub
    ''' <summary>
    ''' Cette methode est appellée par le WS
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <remarks></remarks>
    Public Shared Sub LogSynchroElmt(ByVal obj As Object, Optional pComm As String = "")
        Try

            Dim oXS As New XmlSerializer(obj.GetType(), "")
            Dim oStreamWriter As New System.IO.StringWriter()
            oXS.Serialize(oStreamWriter, obj)
            oStreamWriter.Close()

            logger.Trace("<SynchroElmt type='" & obj.GetType().Name & "' comment ='" & pComm & "'>")
            logger.Trace(oStreamWriter.ToString().Replace("<?xml version=""1.0"" encoding=""utf-16""?>", ""))
            logger.Trace("</SynchroElmt>")
        Catch ex As Exception

        End Try


    End Sub
    Public Shared Sub LogSynchroDebut(pContext As String)
        logger.Trace("<WS Nom='" & pContext & "' date ='" & DateTime.Now.ToShortDateString() & " " & DateTime.Now.ToLongTimeString() & "' >")
    End Sub
    Public Shared Sub LogSynchroFin()
        logger.Trace("</WS>")
    End Sub
    Public Shared Sub LogSynchrodEMANDE(ByVal obj As Object, Optional pContext As String = "")
        LogSynchro("DEMANDE", obj, pContext)
    End Sub
    Public Shared Sub LogSynchroREPONSE(ByVal obj As Object, Optional pContext As String = "")
        LogSynchro("REPONSE", obj, pContext)
    End Sub
    Private Shared Sub LogSynchro(pType As String, ByVal obj As Object, Optional pContext As String = "")
        Try

            Dim oXS As New XmlSerializer(obj.GetType(), "")
            Dim oStreamWriter As New System.IO.StringWriter()
            oXS.Serialize(oStreamWriter, obj)
            oStreamWriter.Close()

            logger.Trace("<WS" & pType & " context='" & pContext & "'>")
            logger.Trace(oStreamWriter.ToString().Replace("<?xml version=""1.0"" encoding=""utf-16""?>", ""))
            logger.Trace("</WS" & pType & ">")
        Catch ex As Exception

        End Try


    End Sub
    Public Shared Function ReinitFichierLOGSynchro() As Boolean
        Dim bReturn As Boolean
        Try
            If System.IO.File.Exists(GlobalsCRODIP.GLOB_ENV_SYNCHROLOGFILE) Then
                System.IO.File.Delete(GlobalsCRODIP.GLOB_ENV_SYNCHROLOGFILE)

            End If

            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("SynchronisationManager.ReinitFichierSynchro ERR:" & ex.Message
                              )
            bReturn = False
        End Try
        Return bReturn
    End Function

    Public Shared Function getWSlstElementsASynchroniser(ByVal pAgent As Agent, pSynchroBoolean As SynchroBooleans) As List(Of SynchronisationElmt)
        Dim oLst As New List(Of SynchronisationElmt)()
        Dim objWSUpdates As Object() = Nothing
        Dim availablerPools As Object() = Nothing
        Dim availablePcs As Object() = Nothing
        '= Nothing
        'Récupération des infos depuis le SRV
        ' déclarations
        Dim objWSCrodip As WSCRODIP.CrodipServer = WebServiceCRODIP.getWS()
        CSDebug.dispInfo("WS URL = " & objWSCrodip.Url)
        ' Appel au WS
        Dim isUpdateAvailable As Integer
        Dim isComplete As Integer

        Dim DateDernSynhcro As DateTime
        CSDebug.dispInfo("Demande de la dernière date de synchro de  " & pAgent.uidstructure)
        DateDernSynhcro = AgentManager.GetDateDernSynchro(pAgent.uidstructure)
        CSDebug.dispInfo("Dernière date de synchro =   " & DateDernSynhcro.ToShortDateString())
        'If CSDate.FromCrodipString(pAgent.dateDerniereSynchro) < DateDernSynhcro Then
        '    DateDernSynhcro = CSDate.FromCrodipString(pAgent.dateDerniereSynchro)
        'End If
        logger.Trace("<SynchroElmt type='WS.UpdatesAvailable(" & pAgent.numeroNational & "," & CSDate.GetDateForWS(DateDernSynhcro) & ")'>")
        CSDebug.dispInfo("<SynchroElmt type='WS.UpdatesAvailable(" & pAgent.numeroNational & "," & CSDate.GetDateForWS(DateDernSynhcro) & ")'>")
        Try
            Dim infod As String
            If pAgent.oPool Is Nothing Then
                objWSCrodip.UpdatesAvailable(pAgent.idProfilAgent, "", "", "GT8CT-4WN7D-XJBVT-3CGWK-CDK2J", CSDate.GetDateForWS(DateDernSynhcro), infod, isUpdateAvailable, isComplete, objWSUpdates, availablerPools, availablePcs)
            Else
                objWSCrodip.UpdatesAvailable(pAgent.idProfilAgent, pAgent.oPool.idPool, "", "", CSDate.GetDateForWS(DateDernSynhcro), infod, isUpdateAvailable, isComplete, objWSUpdates, availablerPools, availablePcs)
            End If
        Catch ex As Exception
            CSDebug.dispError("SynchronisationManager.getWSlstElementsASynchroniser ERR" & ex.Message)
        End Try
        ''l 'obejt objWSupdates est en fait un tableau de XMLNode
        'Dim oTabXml As List(Of XmlNode())
        'oTabXml = (From obj In objWSUpdates Select CType(obj, XmlNode())).ToList()
        'logger.Trace("<FROMWS>")
        'For Each otabNode As XmlNode() In oTabXml
        '    CSDebug.dispInfo("<xmlNode>")
        '    For Each oNode As XmlNode In otabNode
        '        CSDebug.dispInfo(oNode.OuterXml)
        '    Next
        '    CSDebug.dispInfo("</xmlNode>")
        'Next
        'logger.Trace("</FROMWS>")
        Dim oSynchro As SynchronisationElmt = Nothing
        'Parcours de la Liste des Objets à synchroniser
        CSDebug.dispInfo("Parcours des " & objWSUpdates.Count & " objets rendus")
        For Each objWSUpdates_items As Object In objWSUpdates
            'création de l'objet de synhcronisation en fonction du type
            For Each objWSUpdates_item As System.Xml.XmlNode In objWSUpdates_items
                If objWSUpdates_item.Name().ToUpper.Trim() = "type".ToUpper.Trim() Then
                    oSynchro = SynchronisationElmt.CreateSynchronisationElmt(objWSUpdates_item.InnerText(), pSynchroBoolean)
                End If
            Next objWSUpdates_item
            'Initialisation de l'object avec les données issues du WS
            If oSynchro IsNot Nothing Then
                For Each objWSUpdates_item As System.Xml.XmlNode In objWSUpdates_items
                    oSynchro.Fill(objWSUpdates_item.Name(), objWSUpdates_item.InnerText())
                Next objWSUpdates_item

                ' LogSynchroElmt(oSynchro, "WS.UpdateAvailable")
                If GlobalsCRODIP.GLOB_ENV_MODESIMPLIFIE Then
                    'En mode simplifié on ne synchronise pas les Elements communs et Organisme du Module documentaire
                    If TypeOf oSynchro Is SynchronisationElmtDocument And oSynchro.Update Then
                        If oSynchro.IdentifiantChaine.Contains("/Commun/") Or oSynchro.IdentifiantChaine.Contains("/Organismes/") Then
                            oSynchro.Update = False
                        End If
                    End If
                End If
                If oSynchro.Update Then
                    oLst.Add(oSynchro)
                End If
            End If
        Next objWSUpdates_items
        logger.Trace("</SynchroElmt>")
        CSDebug.dispInfo("Fin du Parcours des elements")

        Return oLst
    End Function
End Class
