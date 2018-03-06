Public Class frmRPDlgHelp551
    Implements IfrmCRODIP

    Protected m_oDiag As RPDiagnostic
    Protected m_mode As DiagnosticHelp551.Help551Mode

    Protected Overrides Function Valider() As Boolean Implements IfrmCRODIP.Valider
        Dim bReturn As Boolean
        Try
            MyBase.Valider()
            'Activation de la section
            m_oDiag.oRPParam.bSectionSyntheseCapteurVitesse = True
            m_oDiag.syntheseErreurMoyenneCinemometre = m_oDiag.diagnosticHelp551.ErreurMoyenne
            createDiagItems() 'Création des diagItem corespondants
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("frmRPDlgHelp551.Valider Err" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Protected Overrides Sub Annuler() Implements IfrmCRODIP.Annuler
        MyBase.Annuler()
    End Sub
    Protected Overrides Sub formload() Implements IfrmCRODIP.formLoad
        '06/03/2018 : #110
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        'Me.ControlBox = True
        Me.MinimizeBox = False
        Me.MaximizeBox = False



        AjoutLabeltitre()

        btnValider.Visible = False
        btnAnnuler.Visible = False
    End Sub

    Private Sub AjoutLabeltitre()
        laTitre.Text = Me.Text
    End Sub

    Private Sub frmRPDlgHelp551_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        MyBase.setContexte(m_mode, m_oDiag, Me.Text, False)

    End Sub

    Private Sub frmRPDlgHelp551_Leave(sender As Object, e As EventArgs) Handles Me.Leave
        Valider()
    End Sub

    Private Sub frmRPDlgHelp551_Load(sender As Object, e As EventArgs) Handles Me.Load
        formload()
    End Sub


    Private Sub frmRPDlgHelp551_TextChanged(sender As Object, e As EventArgs) Handles Me.TextChanged
        laTitre.Text = Me.Text
    End Sub
    Public Sub Setcontexte(pMode As DiagnosticHelp551.Help551Mode, pDiag As RPDiagnostic, pTitre As String, pVisu As Boolean)
        m_oDiag = pDiag
        m_mode = pMode
        MyBase.setContexte(pMode, pDiag, pTitre, pVisu)
        Me.Text = pTitre

    End Sub
    ''' <summary>
    ''' Creation des diagItem correspondant au mode
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub createDiagItems()
        If m_oDiag.diagnosticHelp551.Resultat = "OK" Then
            m_oDiag.RemoveDiagItem(New DiagnosticItem(m_oDiag.id, "551", "2", "", "P"))
            m_oDiag.AddDiagItem(New DiagnosticItem(m_oDiag.id, "551", "3", "", "B"))
        Else
            m_oDiag.AddDiagItem(New DiagnosticItem(m_oDiag.id, "551", "2", "", "P"))
            m_oDiag.RemoveDiagItem(New DiagnosticItem(m_oDiag.id, "551", "3", "", "B"))
        End If
    End Sub
 
End Class