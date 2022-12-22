﻿Public Class frmRPFicheExlpoitant
    Implements IfrmCRODIP

    Protected m_oDiag As RPDiagnostic
    Public Overloads Sub setContexte(pIsModediag As Boolean, pClient As Exploitation, pRPdiag As RPDiagnostic, pRPAgent As Agent)
        MyBase.setContexte(pIsModediag, pClient, pRPAgent, pRPdiag)
        m_bsExploitation.Clear()
        m_bsExploitation.Add(clientCourant)
        m_oDiag = pRPdiag
    End Sub

    Protected Overrides Sub formload()
        MyBase.formload()
        btn_Suppimer.Visible = False
        btnValider.Visible = False
        btnAnnuler.Visible = False
        stats_nbControles.Text = ""
        Label_diagnostic_61.Visible = False
        MinimizeBox = False
        MaximizeBox = False
        Me.Text = "Fiche Exploitant"

    End Sub
    Protected Overrides Function Valider() As Boolean Implements IfrmCRODIP.Valider
        ' On crée notre nouveau pulvé
        Dim isFormValid As Boolean = True
        Dim bReturn As Boolean = False

        Try
            bReturn = checkForm()
            If bReturn Then
                m_oDiag.oRPParam.bSectionEntete = True
                m_oDiag.SetProprietaire(m_oExploit)
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

    Private Sub frmRPFicheExlpoitant_Leave(sender As Object, e As EventArgs) Handles Me.Leave
        'Valider()
    End Sub

    Public Overrides Sub Refresh()
        m_bsExploitation.ResetBindings(False)
    End Sub
End Class