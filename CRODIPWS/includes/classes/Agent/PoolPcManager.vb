Imports System.Data.Common
Imports System.IO
Imports System.Linq
Imports System.Xml
Imports System.Xml.Serialization

Public Class PoolPcManager
    Inherits RootManager
    Public Shared Function WSgetById(ByVal p_uid As Integer, paid As String) As PoolPc
        Dim oreturn As PoolPc
        oreturn = RootWSGetById(Of PoolPc)(p_uid, paid)
        Return oreturn
    End Function


    Public Shared Function WSSend(ByVal pAgentIn As PoolPc, ByRef pReturn As PoolPc) As Integer
        Dim codeResponse As Integer = 99
        codeResponse = RootWSSend(Of PoolPc)(pAgentIn, pReturn)
        Select Case codeResponse
            Case 2 ' UPDATE OK
            Case 4 ' CREATE OK
            Case 1 ' NOK
                CSDebug.dispError("SendWS - Code 1 : Erreur Base de donn�es Serveur")
            Case 9 ' BADREQUEST
                CSDebug.dispError("SendWS - Code 9 : Mauvaise Requete")
            Case 0 ' PAS DE MAJ
        End Select
        Return codeResponse
    End Function

    Public Shared Function WSGetListByPC(pAgent As Agent, pagentPC As AgentPc) As List(Of PoolPc)
        Dim lstReturn As New List(Of PoolPc)
        Dim objWSCrodip As WSCRODIP.CrodipServer = WebServiceCRODIP.getWS()
        Dim strXml As String = ""
        Try
            Dim tXmlnodes As Object() = Nothing
            '' d�clarations
            '            Dim typeT As Type = GetType(T)
            Dim nomMethode As String = "GetPoolPcList"
            Dim methode = objWSCrodip.GetType().GetMethod(nomMethode)
            Dim codeResponse As Integer = 99 'Mehode non trouv�e
            Dim infos As String = ""
            If methode IsNot Nothing Then
                Dim Params As Object() = {pagentPC.uid, pagentPC.aid, pagentPC.uidstructure, tXmlnodes}
                SynchronisationManager.LogSynchroDebut(nomMethode)
                SynchronisationManager.LogSynchrodEMANDE(Params, nomMethode)
                codeResponse = objWSCrodip.GetPoolPcList(pAgent.uid, pagentPC.uid, pagentPC.aid, pagentPC.uidstructure, infos, tXmlnodes)
                SynchronisationManager.LogSynchroREPONSE(tXmlnodes, nomMethode)
                SynchronisationManager.LogSynchroFin()
            End If
            Select Case codeResponse
                Case 0 ' OK
                    Dim ser As New XmlSerializer(GetType(PoolPc))
                    For n As Integer = 0 To tXmlnodes.Length - 1

                        Dim xmlDocument As New XmlDocument()
                        ' Cr�er un �l�ment racine
                        Dim root As XmlElement = xmlDocument.CreateElement("PoolPc")
                        xmlDocument.AppendChild(root)

                        For Each oNode As XmlNode In tXmlnodes(n)


                            Dim importedNode As XmlNode = xmlDocument.ImportNode(oNode, True)
                            root.AppendChild(importedNode)
                        Next oNode

                        strXml = xmlDocument.OuterXml

                        Dim obj As PoolPc
                        Using reader As New StringReader(strXml)
                            obj = ser.Deserialize(reader)
                        End Using
                        lstReturn.Add(obj)
                    Next n
                Case 1 ' NOK
                    CSDebug.dispError("PoolPcManager.WSGetListByPc - Code 1 : Non-Trouv�e")
                Case 9 ' BADREQUEST
                    CSDebug.dispError("PoolPcManager.WSGetListByPc - Code 9 : Bad Request")
            End Select

        Catch ex As Exception
            lstReturn.Clear()
        End Try
        Return lstReturn
    End Function

    Public Shared Function GetByuid(puid As Integer) As PoolPc
        Dim oReturn As PoolPc

        oReturn = getBySQL(Of PoolPc)("Select * from PoolPc where uid = " & puid)
        Return oReturn
    End Function
    Public Shared Function getListeByStructure(puidStructure As Integer) As List(Of PoolPc)
        Dim lstReturn As List(Of PoolPc)
        lstReturn = getListe(Of PoolPc)("SELECT * FRom PoolPC where uidStructure = " & puidStructure)
        Return lstReturn
    End Function
    Friend Shared Function GetLstPcByPool(pPool As Pool) As List(Of AgentPc)
        Dim lstReturn As New List(Of AgentPc)
        Try
            Dim sql As String
            sql = "SELECT * FROM PoolPc where uidPool = " & pPool.uid
            Dim lstPoolPc As List(Of PoolPc)
            lstPoolPc = getListe(Of PoolPc)(sql)
            For Each oPoolPc As PoolPc In lstPoolPc
                Dim oPc As AgentPc
                oPc = AgentPcManager.getByKey(oPoolPc.uidpc)
                If oPc IsNot Nothing Then
                    lstReturn.Add(oPc)
                End If
            Next

        Catch ex As Exception
            CSDebug.dispError("PoolPcManager.getListePCByPool ERR", ex)
            lstReturn.Clear()
        End Try
        Return lstReturn
    End Function



    Public Shared Function Save(ByVal pObj As PoolPc, Optional bSynchro As Boolean = False) As Boolean

        Dim bReturn As Boolean

        Try
            bReturn = False
            create("PoolPc", pObj.uid)


            Dim paramsQuery As String
            paramsQuery = ""

            ' Mise a jour de la date de derniere modification
            If Not bSynchro Then
                pObj.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
            End If

            paramsQuery = paramsQuery & " uidpool=" & pObj.uidpool
            paramsQuery = paramsQuery & " ,namepool='" & pObj.namepool & "'"
            paramsQuery = paramsQuery & " ,uidpc=" & pObj.uidpc
            paramsQuery = paramsQuery & " ,idPC='" & pObj.idPc & "'"
            paramsQuery = paramsQuery & " ,uidstructure=" & pObj.uidstructure
            paramsQuery = paramsQuery & " ,dateAssociation='" & CSDate.ToCRODIPString(pObj.dateAssociation) & "'"

            bReturn = Update("PoolPc", pObj, paramsQuery)
        Catch ex As Exception
            CSDebug.dispFatal("PoolPcManager.save ERR : ", ex)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Shared Function DeleteFromPool(pPool As Pool) As Boolean
        Dim bReturn As Boolean
        Try
            Delete("PoolPc", "uidpool", pPool)
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("PoolPcManager.Delete ERR", ex)
            bReturn = False
        End Try
        Return bReturn
    End Function

End Class
