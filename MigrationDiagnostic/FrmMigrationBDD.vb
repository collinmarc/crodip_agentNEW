Public Class FrmMigrationBDD
    Dim bFini As Boolean = False
    Dim oBDD As BDDTransfertDiag
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If bFini Then
            If Not BackgroundWorker1.CancellationPending Then
                Me.DialogResult = DialogResult.OK
                Me.Close()
            Else
                Me.DialogResult = DialogResult.Abort
            End If
        Else
            Me.Cursor = Cursors.WaitCursor
            Button1.Enabled = False
            BackgroundWorker1.RunWorkerAsync()
        End If

    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        oBDD = New BDDTransfertDiag() With {.bgw = BackgroundWorker1}

        CSDebug.dispInfo("BDDTransfert Start" & My.Settings.DBMSACESS & ";" & My.Settings.DBMSACESS2 & ";" & My.Settings.DBSQLITE)
        'If Not BackgroundWorker1.CancellationPending Then
        '    CSDebug.dispInfo("RAZ")
        '    BackgroundWorker1.ReportProgress(101, "RAZ Base destination")
        '    CSDb._DBTYPE = CSDb.EnumDBTYPE.SQLITE
        '    Dim oCSDB As New CSDb(True)
        '    oCSDB.RAZ_BASE_DONNEES()
        '    oCSDB.free()
        'End If
        'If Not BackgroundWorker1.CancellationPending Then
        '    CSDebug.dispInfo("Structure-Agent")
        '    BackgroundWorker1.ReportProgress(110, "Structure-Agent")
        '    oBDD.TransfertStructureAgent()
        'End If
        'If Not BackgroundWorker1.CancellationPending Then
        '    CSDebug.dispInfo("ExploitPulve")
        '    BackgroundWorker1.ReportProgress(120, "ExploitationPulverisateur")
        '    oBDD.TransfertExploitationPulve()
        'End If
        'If Not BackgroundWorker1.CancellationPending Then
        '    CSDebug.dispInfo("Equipement")
        '    BackgroundWorker1.ReportProgress(130, "Equipement agent")
        '    oBDD.TransfertAgentEquipement()
        'End If
        'If Not BackgroundWorker1.CancellationPending Then
        '    CSDebug.dispInfo("Controle Equipement")
        '    BackgroundWorker1.ReportProgress(140, "Controle Equipement agent")
        '    oBDD.TransfertAgentEquipementControle()
        'End If
        'If Not BackgroundWorker1.CancellationPending Then
        '    CSDebug.dispInfo("Fiche de vie")
        '    BackgroundWorker1.ReportProgress(150, "FicheVie")
        '    oBDD.transfertFicheVie()
        'End If
        'If Not BackgroundWorker1.CancellationPending Then
        '    CSDebug.dispInfo("Prestation")
        '    BackgroundWorker1.ReportProgress(160, "Prestation")
        '    oBDD.TransfertPrestation()
        'End If
        If Not BackgroundWorker1.CancellationPending Then
            CSDebug.dispInfo("Diagnostic")
            BackgroundWorker1.ReportProgress(170, "Diagnostic")
            oBDD.TransfertDiagnosticALL()
        End If
        'If Not BackgroundWorker1.CancellationPending Then
        '    CSDebug.dispInfo("Factures")
        '    BackgroundWorker1.ReportProgress(180, "Factures")
        '    oBDD.TransfertFactures()
        'End If
        'CSDebug.dispInfo("BDDTransfert End")
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        Try

            If e.ProgressPercentage <= 100 Then
                Me.ProgressBarN2.Value = e.ProgressPercentage
                lblProgressN2.Text = e.UserState
                oBDD.ListMsg.ForEach(Sub(msg) lbMsg.Items.Add(msg))
                oBDD.ListMsg.Clear()
                lbMsg.Refresh()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Try
            Me.ProgressBarN2.Value = Me.ProgressBarN2.Maximum
            lblProgressN2.Text = "Transfert Terminé"
            Me.Button1.Enabled = True
            Me.Button1.Text = "Quitter"
            Me.Cursor = Cursors.Default
            bFini = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAnnuler_Click(sender As Object, e As EventArgs) Handles btnAnnuler.Click
        If BackgroundWorker1.IsBusy Then
            BackgroundWorker1.CancelAsync()
        End If

    End Sub

    Private Sub FrmMigrationBDD_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not System.IO.File.Exists(My.Settings.DBMSACESS) Or
           Not System.IO.File.Exists(My.Settings.DBMSACESS2) Then
            CSDebug.dispInfo("La base de données ACCESS n'est pas présente")
            Application.Exit()
        Else
            Button1.PerformClick()
        End If
    End Sub
End Class
