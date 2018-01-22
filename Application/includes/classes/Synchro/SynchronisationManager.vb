Imports System.Collections.Generic
Imports System.Xml.Serialization
Imports System.IO.File
Imports NLog
Imports System.Xml

''' <summary>
''' 
''' </summary>
''' <remarks></remarks>
Public Class SynchronisationManager
    Private Shared logger As Logger = LogManager.GetCurrentClassLogger()

    Public Shared Function DBsaveSynchro(ByVal _sens As String, ByVal _log As String) As Boolean
        Dim bReturn As Boolean
        Try

            Dim CSDb As New CSDb(True)

            Dim bddCommande As OleDb.OleDbCommand
            bddCommande = CSDb.getConnection().CreateCommand()
            ' Création du nouveau log
            bddCommande.CommandText = "INSERT INTO `Synchronisation` (`idAgent`,`sensSynchronisation`,`dateSynchronisation`,`logSynchronisation`) VALUES (" & CSDb.secureString(agentCourant.idStructure) & ",'" & CSDb.secureString(_sens) & "','" & CSDate.mysql2access(Date.Now) & "','" & CSDb.secureString(_log) & "')"
            bddCommande.ExecuteNonQuery()


            CSDb.free()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("SynchronisationManager - logSynchro : " & ex.Message)
            CSDebug.dispError("SynchronisationManager - logSynchro : " & _sens)
            CSDebug.dispError("SynchronisationManager - logSynchro : " & _log)
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
        Dim oXS As New XmlSerializer(obj.GetType(), "")
        Dim oStreamWriter As New System.IO.StringWriter()
        oXS.Serialize(oStreamWriter, obj)
        oStreamWriter.Close()

        logger.Trace("<SynchroElmt type='" & obj.GetType().Name & "' comment ='" & pComm & "'>")
        logger.Trace(oStreamWriter.ToString().Replace("<?xml version=""1.0"" encoding=""utf-16""?>", ""))
        logger.Trace("</SynchroElmt>")


    End Sub
    Public Shared Function ReinitFichierLOGSynchro() As Boolean
        Dim bReturn As Boolean
        Try
            If System.IO.File.Exists(GLOB_ENV_SYNCHROLOGFILE) Then
                System.IO.File.Delete(GLOB_ENV_SYNCHROLOGFILE)

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
        Dim objWSUpdates As Object = Nothing
        'Récupération des infos depuis le SRV
        ' déclarations
        Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
        ' Appel au WS
        Dim isUpdateAvailable As Integer
        Dim isComplete As Integer
        logger.Trace("<SynchroElmt type='WS.UpdatesAvailable(" & pAgent.numeroNational & "," & CSDate.GetDateForWS(pAgent.dateDerniereSynchro) & ")'>")
        objWSCrodip.UpdatesAvailable(pAgent.numeroNational, CSDate.GetDateForWS(pAgent.dateDerniereSynchro), isUpdateAvailable, isComplete, objWSUpdates)
        Dim oSynchro As SynchronisationElmt
        'Parcours de la Liste des Objets à synchroniser
        For Each objWSUpdates_items As Object In objWSUpdates
            'création de l'objet de synhcronisation en fonction du type
            For Each objWSUpdates_item As System.Xml.XmlNode In objWSUpdates_items
                If objWSUpdates_item.Name().ToUpper.Trim() = "type".ToUpper.Trim() Then
                    oSynchro = SynchronisationElmt.createSynchronisationElmt(objWSUpdates_item.InnerText(), pSynchroBoolean)
                End If
            Next objWSUpdates_item
            'Initialisation de l'object avec les données issues du WS
            If oSynchro IsNot Nothing Then
                For Each objWSUpdates_item As System.Xml.XmlNode In objWSUpdates_items
                    oSynchro.Fill(objWSUpdates_item.Name(), objWSUpdates_item.InnerText())
                Next objWSUpdates_item
            End If

            LogSynchroElmt(oSynchro, "WS.UpdateAvailable")
            oLst.Add(oSynchro)
        Next objWSUpdates_items
        logger.Trace("</SynchroElmt>")

        Return oLst
    End Function
End Class
