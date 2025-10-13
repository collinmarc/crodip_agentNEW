Imports System.Data.Common
Imports System.IO
Imports System.Threading
Imports System.Xml.Serialization

Public Class IdentifiantOTCManager
    Inherits RootManager
    Public Shared Function exists(ByVal pIdentOTC As String) As Boolean
        Dim bReturn As Boolean

        Try
            '## Préparation de la connexion
            Dim dbLink As New CSDb(True)
            Dim nIdent As Integer = dbLink.getValue("SELECT Count(*) From IdentifiantOTC where IdentifiantOTC.IdentOTC = '" & pIdentOTC & "'")
            '## Execution de la requete
            dbLink.free()
            bReturn = nIdent > 0
        Catch ex As Exception
            CSDebug.dispError("IdentOTCManager::exists() : ", ex)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Shared Function Count() As Integer
        Dim bReturn As Integer

        Try
            '## Préparation de la connexion
            Dim dbLink As New CSDb(True)
            Dim nIdent As Integer = dbLink.getValue("SELECT Count(*) From IdentifiantOTC ")
            '## Execution de la requete
            dbLink.free()
            bReturn = nIdent
        Catch ex As Exception
            CSDebug.dispError("IdentOTCManager::Count() : ", ex)
            bReturn = 0
        End Try
        Return bReturn
    End Function

    Public Shared Function SaveList(pList As List(Of IdentifiantOTC)) As Boolean
        Dim bReturn As Boolean

        Try
            '## Préparation de la connexion
            Dim dbLink As New CSDb(True)
            Using otransaction As DbTransaction = dbLink.getConnection().BeginTransaction()

                Dim strSQL As String = "INSERT INTO IdentifiantOTC (IdentOTC) VALUES($value) "
                Dim oCmd As DbCommand
                oCmd = dbLink.getConnection().CreateCommand()
                oCmd.CommandText = "DELETE FROM IdentifiantOTC"
                oCmd.ExecuteNonQuery()

                oCmd.CommandText = strSQL
                Dim oParam As DbParameter = oCmd.CreateParameter()
                oParam.ParameterName = "$value"
                oCmd.Parameters.Add(oParam)

                For Each oIdentOC As IdentifiantOTC In pList.Distinct()
                    Try
                        oParam.Value = oIdentOC.identifiant
                        oCmd.ExecuteNonQuery()
                    Catch ex As Exception
                        Console.WriteLine("IdentOTC = " & oIdentOC.identifiant)
                        CSDebug.dispError("IdentOTCManager::SaveList() : ", ex)

                    End Try
                Next

                otransaction.Commit()
            End Using
            dbLink.free()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("IdentOTCManager::SaveList() : ", ex)
            bReturn = False
        End Try
        Return bReturn

    End Function
    Public Shared Function Save(pIdentOTC As IdentifiantOTC)

        Dim bReturn As Boolean = False

        Try
            If Not exists(pIdentOTC.identifiant) Then
                Dim oCSDB As New CSDb(True)
                Dim strSQL As String = "INSERT INTO IdentifiantOTC (IdentOTC, chargement, type, active) VALUES "
                Dim oCmd As DbCommand
                strSQL = strSQL & "("
                strSQL = strSQL & "'" & pIdentOTC.identifiant & "'"
                strSQL = strSQL & ",'" & pIdentOTC.chargement & "'"
                strSQL = strSQL & ",'" & pIdentOTC.type & "'"
                strSQL = strSQL & ",'" & pIdentOTC.active & "'"
                strSQL = strSQL & ")"
                oCmd = oCSDB.getConnection().CreateCommand()
                oCmd.CommandText = strSQL

                oCmd.ExecuteNonQuery()
            End If
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("IdentifiantOTCManager.Save ERR ", ex)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Shared Function WSGetList() As List(Of IdentifiantOTC)
        Console.WriteLine("IdentifiantORCManager.WSGetList Debut " & DateTime.Now.ToLongTimeString)
        Dim oreturn As List(Of IdentifiantOTC) = Nothing
        Dim objWSCrodip As WSCRODIP.CrodipServer = WebServiceCRODIP.getWS()
        objWSCrodip.Timeout = Timeout.Infinite '100sec
        Dim strXml As String = ""
        Try
            oreturn = New List(Of IdentifiantOTC)()
            Dim tXmlnodes As Object = Nothing
            Dim pInfos As String = ""
            Dim codeResponse As Integer = 99 'Mehode non trouvée
            Dim oLst As Object()
            Console.WriteLine("AppelWS P " & DateTime.Now.ToLongTimeString)
            codeResponse = objWSCrodip.GetIdentifiantOTCList("json", "P", 0, pInfos, oLst)
            Console.WriteLine("ReTourWS P" & DateTime.Now.ToLongTimeString)
            '' déclarations
            Dim oNode As System.Xml.XmlNode() = oLst(0)
            Select Case codeResponse
                Case 0 ' OK
                    Dim str As String = oNode(0).InnerText.Replace("id", "")
                    str = str.Replace("{", "").Replace("[", "").Replace("""", "").Replace(":", "")
                    str = str.Replace("]}", "")
                    Dim tabstr As String() = str.Split(",")
                    For Each str In tabstr
                        Dim oIdent As New IdentifiantOTC(str)
                        oreturn.Add(oIdent)
                    Next
                    'Console.WriteLine(str)


                Case 1 ' NOK
                    CSDebug.dispError("IdentifiantOTCManager.WSGetList - Code 1 : Non-Trouvée")
                Case 9 ' BADREQUEST
                    CSDebug.dispError("IdentifiantOTCManager.WSGetList : Bad Request")
            End Select
            Console.WriteLine("AppelWS E " & DateTime.Now.ToLongTimeString)
            codeResponse = objWSCrodip.GetIdentifiantOTCList("json", "E", 0, pInfos, oLst)
            Console.WriteLine("ReTourWS P" & DateTime.Now.ToLongTimeString)
            '' déclarations
            oNode = oLst(0)
            Select Case codeResponse
                Case 0 ' OK
                    Dim str As String = oNode(0).InnerText.Replace("id", "")
                    str = str.Replace("{", "").Replace("[", "").Replace("""", "").Replace(":", "")
                    str = str.Replace("]}", "")
                    Dim tabstr As String() = str.Split(",")
                    For Each str In tabstr
                        Dim oIdent As New IdentifiantOTC(str)
                        oreturn.Add(oIdent)
                    Next
                    'Console.WriteLine(str)


                Case 1 ' NOK
                    CSDebug.dispError("IdentifiantOTCManager.WSGetList - Code 1 : Non-Trouvée")
                Case 9 ' BADREQUEST
                    CSDebug.dispError("IdentifiantOTCManager.WSGetList : Bad Request")
            End Select
        Catch ex As Exception
            CSDebug.dispError("IdentifiantOTCManager.WSGetList() ERR: ", ex)
        Finally
        End Try

        oreturn = oreturn.Distinct().ToList()
        Console.WriteLine("IdentifiantOTCManager.WSGetList Fin " & DateTime.Now.ToLongTimeString)
        Return oreturn

    End Function
    Public Shared Function WSgetById(ByVal puid As Integer, pIdentifiant As String, puidAgent As Integer) As IdentifiantOTC
        Dim oreturn As IdentifiantOTC = Nothing
        Dim objWSCrodip As WSCRODIP.CrodipServer = WebServiceCRODIP.getWS()
        Dim strXml As String = ""
        Try
            Dim tXmlnodes As Object = Nothing
            Dim pInfos As String = ""
            Dim codeResponse As Integer = 99 'Mehode non trouvée
            codeResponse = objWSCrodip.GetIdentifiantOTC(puid, pIdentifiant, puidAgent, pInfos, tXmlnodes)
            '' déclarations
            Select Case codeResponse
                Case 0 ' OK
                    Dim ser As New XmlSerializer(GetType(IdentifiantOTC))
                    strXml = tXmlnodes(0).ParentNode.OuterXml
                    Using reader As New StringReader(strXml)
                        oreturn = ser.Deserialize(reader)
                    End Using
                Case 1 ' NOK
                    CSDebug.dispError("IdentifiantOTCManager.WSGetById - Code 1 : Non-Trouvée")
                Case 9 ' BADREQUEST
                    CSDebug.dispError("IdentifiantOTCManager.WSGetById : Bad Request")
            End Select
        Catch ex As Exception
            CSDebug.dispError("IdentifiantOTCManager.WSGetById (" & puid & "," & pIdentifiant & ") ERR: ", ex)
        Finally
        End Try
        Return oreturn
    End Function
End Class
