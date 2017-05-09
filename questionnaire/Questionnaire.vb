Imports System.Xml.Serialization
Imports System.IO
Public Class Questionnaire
    Inherits Element
    Private m_name As String

    Public Function getNewName() As String
        Dim rsClient As String
        Dim NomAgent As String
        Dim oQClient As QIdent = Find("QCLIENT")
        If oQClient IsNot Nothing Then
            rsClient = oQClient.RaisonSociale
        End If
        Dim oQAgent As QIdent = Find("QAGENT")
        If oQAgent IsNot Nothing Then
            NomAgent = oQAgent.Nom
        End If
        Return Now.ToString("yyyyMMdd") & "-" & rsClient & "-" & NomAgent
    End Function
    Public Function getClient() As QIdent
        Dim oReturn As QIdent
        oReturn = Nothing
        Dim oQClient As QIdent = Find("QCLIENT")
        If oQClient IsNot Nothing Then
            oReturn = oQClient
        End If
        Return oReturn
    End Function
    Public Function getAgent() As QIdent
        Dim oReturn As QIdent
        oReturn = Nothing
        Dim oQClient As QIdent = Find("QAGENT")
        If oQClient IsNot Nothing Then
            oReturn = oQClient
        End If
        Return oReturn
    End Function
    Public Function writeXml(ByVal strFileName As String) As Boolean
        Dim bReturn As Boolean
        Dim objStreamWriter As StreamWriter = Nothing
        Try

            objStreamWriter = New StreamWriter(strFileName)
            Dim x As New XmlSerializer(Me.GetType)
            x.Serialize(objStreamWriter, Me)
            objStreamWriter.Close()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("Questionnaire.WriteXML: " & ex.Message)
            If ex.InnerException IsNot Nothing Then
                CSDebug.dispError("Questionnaire.WriteXML: " & ex.InnerException.Message)
            End If
            bReturn = False
            If objStreamWriter IsNot Nothing Then
                objStreamWriter.Close()
            End If


        End Try
        Return bReturn
    End Function
    Public Function readXML(ByVal strFileName As String) As Boolean
        Dim bReturn As Boolean
        Try
            Dim olst As New Questionnaire()
            Dim objStreamReader As New StreamReader(strFileName)
            Dim x As New XmlSerializer(Me.GetType)
            olst = x.Deserialize(objStreamReader)
            objStreamReader.Close()
            Me.Code = olst.Code
            Me.Libelle = olst.Libelle
            lstElements.Clear()
            For Each oParam As Element In olst.lstElements
                lstElements.Add(oParam)
            Next
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("Questionnaire.readXML: " & ex.Message)
            If ex.InnerException IsNot Nothing Then
                CSDebug.dispError("Questionnaire.readXML: " & ex.InnerException.Message)
            End If
        End Try
        Return bReturn
    End Function

    Public Function GenerateDataSet() As DataSet1
        Dim oDS As New DataSet1()
        Try

            Dim oQRow As DataSet1.QuestionnaireRow
            Dim nN1 As Integer
            Dim nN2 As Integer
            Dim LibN1 As String
            Dim LibN2 As String
            oQRow = oDS.Questionnaire.AddQuestionnaireRow("Q1", Libelle)
            Dim oClient As QIdent
            oClient = Me.getClient()
            oDS.Client.AddClientRow(oClient.RaisonSociale, oClient.Nom, oClient.Adresse, oClient.CodePostal, oClient.Commune, oClient.sau, "Ille et Illet", "MAE Tous phytos (en cours ou passée)", "Autre: GIE", "Exploitant", "No Comments")
            nN1 = 0
            nN2 = 0
            LibN1 = ""
            LibN2 = ""
            For Each oElement As Element In Me.lstElements
                LibN1 = oElement.Libelle
                nN1 = nN1 + 1
                nN2 = 0
                For Each oElementN2 As Element In oElement.lstElements
                    LibN2 = oElementN2.Libelle
                    nN2 = nN2 + 1
                    For Each oElementN3 As Element In oElementN2.lstElements
                        If TypeOf oElementN3 Is Question Then
                            Dim oQuestion As Question = oElementN3
                            CSDebug.dispInfo(oQuestion.Libelle)
                            oDS.Reponse.AddReponseRow(oQuestion.Libelle, oQuestion.GetReponsecomplete(), oQuestion.Code, LibN2, LibN1, nN1, nN2)
                        Else
                            For Each oElementN4 As Element In oElementN3.lstElements
                                If TypeOf oElementN4 Is Question Then
                                    Dim oQuestion As Question = oElementN4
                                    CSDebug.dispInfo(oQuestion.Libelle)
                                    oDS.Reponse.AddReponseRow(oQuestion.Libelle, oQuestion.GetReponsecomplete(), oQuestion.Code, LibN2, LibN1, nN1, nN2)

                                End If

                            Next

                        End If
                    Next
                Next
            Next
        Catch ex As Exception
            CSDebug.dispInfo("Questionnaire.GenerateDataset ERR" & ex.Message)
            oDS = New DataSet1()
        End Try

        Return oDS
    End Function
End Class
