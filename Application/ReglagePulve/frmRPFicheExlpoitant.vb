Public Class frmRPFicheExlpoitant
    Implements IfrmCRODIP

    Protected m_oDiag As RPDiagnostic
    Public Sub setContexte(pIsModediag As Boolean, pClient As Exploitation, pRPdiag As RPDiagnostic)
        MyBase.setContexte(pIsModediag, pClient)
        m_oDiag = pRPdiag
    End Sub

    Protected Overrides Sub formload()
        MyBase.formload()
        btn_Suppimer.Visible = False
        btnValider.Visible = False
        btnAnnuler.Visible = False
        stats_nbControles.Text = ""
        Label_diagnostic_61.Visible = False
    End Sub
    Protected Overrides Function Valider() As Boolean Implements IfrmCRODIP.Valider
        ' On crée notre nouveau pulvé
        Dim isFormValid As Boolean = True
        Dim bReturn As Boolean = False

        Try
            bReturn = checkForm()
            If bReturn Then
                m_oDiag.oRPParam.bSectionEntete = True
                m_oDiag.SetProprietaire(m_clientCourant)
            End If

        Catch ex As Exception
            CSDebug.dispError("frmRPFicheExlpoitant.Valider ERR :" & ex.Message.ToString)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Protected Overrides Sub Annuler()
        Try

        Catch ex As Exception
            CSDebug.dispError("frmRPFicheExlpoitant.Annuler ERR :" & ex.Message.ToString)
        End Try


    End Sub

    Protected Overrides Sub loadStats()
        '        MyBase.loadStats()
    End Sub

End Class