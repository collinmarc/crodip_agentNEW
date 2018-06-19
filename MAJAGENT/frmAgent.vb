Imports Crodip_agent
Public Class frmAgent
    Private m_Agent As Agent
    Private objWSCrodip As WSCrodip_prod.CrodipServer
    Private Sub btnRechercher_Click(sender As Object, e As EventArgs) Handles btnRechercher.Click
        GetAgent()

    End Sub

    Private Sub GetAgent()
        ' Récupération de la date de synchro à partir du serveur
        Dim synchroDateTime As Object = Nothing
        objWSCrodip.GetSynchroDateTime(synchroDateTime)
        Dim sDateFromSRV As String = synchroDateTime(0).InnerText().replace("/", "-")
        Dim dtSRV As Date
        Try
            dtSRV = New Date(sDateFromSRV)
        Catch Ex As Exception
            Try
                dtSRV = CSDate.FromCrodipString(sDateFromSRV)
            Catch Ex2 As Exception
                dtSRV = Date.Now
            End Try
        End Try

        'Récupération de l'agent
        Dim oResponse As Object = Nothing
        m_Agent = AgentManager.getWSAgentById(tbNumNationalAgent.Text)
        If m_Agent.id <> 0 Then
            ''Maj de l'agent 

            tbNomagent.Text = m_Agent.nom & "-" & m_Agent.prenom
            Try
                dtpDateSynchro.Value = CSDate.FromCrodipString(m_Agent.dateDerniereSynchro)

            Catch ex As Exception
                dtpDateSynchro.Value = dtpDateSynchro.MinDate
            End Try
            grpAgent.Visible = True
        End If
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub frmAgent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Globals.Init()
        grpAgent.Visible = False
        objWSCrodip = WSCrodip.getWS()
        lblURLServeur.Text = objWSCrodip.Url

    End Sub

    Private Sub btnMAJ_Click(sender As Object, e As EventArgs) Handles btnMAJ.Click
        If MessageBox.Show(Me, "Etes-vous sur de vouloir mettre à jour la date de dernière synhcro ?", "Mise à jour de la date de synhcronisation", vbYesNo) = DialogResult.Yes Then
            Dim strDate As String = CSDate.ToCRODIPString(dtpDateSynchro.Value)
            objWSCrodip.SetDateSynchroAgent(m_Agent.id, strDate)

        End If
    End Sub
End Class
