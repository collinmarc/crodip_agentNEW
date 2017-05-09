Public Class Form3
    Private m_Questionnaire As Questionnaire
    Private Sub Form3_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim oDS As New DataSet1()
        Dim oQRow As DataSet1.QuestionnaireRow
        Dim nN1 As Integer
        Dim nN2 As Integer
        Dim LibN1 As String
        Dim LibN2 As String
        oQRow = oDS.Questionnaire.AddQuestionnaireRow("Q1", m_Questionnaire.Libelle)
        Dim oClient As QIdent
        oClient = m_Questionnaire.getClient()
        oDS.Client.AddClientRow(oClient.RaisonSociale, oClient.Nom, oClient.Adresse, oClient.CodePostal, oClient.Commune, oClient.sau, "Ille et Illet", "MAE Tous phytos (en cours ou passée)", "Autre: GIE", "Exploitant", "No Comments")
        nN1 = 0
        nN2 = 0
        LibN1 = ""
        LibN2 = ""
        For Each oElement As Element In m_Questionnaire.lstElements
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
        crQuestionnaire1.SetDataSource(oDS)
        crQuestionnaire1.SetParameterValue("Organisme", m_Questionnaire.getAgent().RaisonSociale)
        crQuestionnaire1.SetParameterValue("NomAgent", m_Questionnaire.getAgent().Nom)
        CrystalReportViewer1.Refresh()
    End Sub

    Public Sub SetQuestionnaire(ByVal pQuestionnaire As Questionnaire)
        m_Questionnaire = pQuestionnaire
    End Sub
End Class