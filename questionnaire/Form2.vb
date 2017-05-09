Public Class Form2

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim oQRow As DataSet1.QuestionnaireRow

        oQRow = DataSet1.Questionnaire.AddQuestionnaireRow("Q1", "Questionnaire")
        DataSet1.Client.AddClientRow("GAEC de Fournan", "Marcel Collin", "Locmaria", "56480", "Cléguérec", 85, "Ille et Illet", "MAE Tous phytos (en cours ou passée)", "Autre: GIE", "Exploitant", "No Comments")
        DataSet1.Reponse.AddReponseRow("Le siége de l'exploitation est-il sur un bassin versant ?", "Ille et Illet", "Q1", "Présentation succinte de l'exploitation", "", 0, 0)
        DataSet1.Reponse.AddReponseRow("L'exploitation a-t-elle une démarche spécifique?", "MAE Tous phytos (en cours ou passée)", "Q2", "Présentation succinte de l'exploitation", "", 0, 0)
        DataSet1.Reponse.AddReponseRow("Prise de décision relative à l'utilisation des produits phytopharmaceutiques", "Autre: GIE", "Q3", "Présentation succinte de l'exploitation", "", 0, 0)
        DataSet1.Reponse.AddReponseRow("Qui applique", "Exploitant", "Q4", "Présentation succinte de l'exploitation", "", 0, 0)
        DataSet1.Reponse.AddReponseRow("Remarques/Commentaires éventuels sur le chapitre", "", "Q5", "Présentation succinte de l'exploitation", "", 0, 0)

        DataSet1.Reponse.AddReponseRow("Cultures dans la rotation", "Choix1|Choix2|choix3", "Q1", "Rotation des cultures", "Reconception des systèmes", 1, 1)
        DataSet1.Reponse.AddReponseRow("Céréales concernées", "Blé|Orge|Avoine", "Q2", "Rotation des cultures", "Reconception des systèmes", 1, 1)
        DataSet1.Reponse.AddReponseRow("Légumes non concernées", "Pois|Carrottes", "Q3", "Rotation des cultures", "Reconception des systèmes", 1, 1)
        DataSet1.Reponse.AddReponseRow("Avant implantation, traitement chimique ?", "OUI", "Q4", "Gestion Intercultures", "Reconception des systèmes", 1, 2)
        DataSet1.Reponse.AddReponseRow("Quels couverts ?", "phacélie|moutarde", "Q5", "Gestion Intercultures", "Reconception des systèmes", 1, 2)
        Me.ReportViewer1.RefreshReport()
        'GENERATEpdf()
    End Sub

    Private Sub Form2_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        ReportViewer1.LocalReport.Dispose()
    End Sub

    Private Sub GENERATEpdf()

    
        Dim bytes As Byte()

        bytes = ReportViewer1.LocalReport.Render("PDF")
        Dim fs As System.IO.FileStream
        fs = System.IO.File.Create("sample.pdf")

        fs.Write(bytes, 0, bytes.Length)

        fs.Close()

    End Sub

    Private Sub ReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportViewer1.Load

    End Sub

    Private Sub QuestionnaireBindingSource_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuestionnaireBindingSource.CurrentChanged

    End Sub
End Class