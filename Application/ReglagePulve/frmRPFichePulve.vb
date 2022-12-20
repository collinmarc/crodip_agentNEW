﻿Public Class frmRPFichePulve
    Inherits ajout_pulve2
    Implements IfrmCRODIP


    Private m_oRPDiag As RPDiagnostic

    Public Overridable Overloads Sub setContexte(ByVal bModeAjout As MODE, pAgent As Agent, pPulverisateur As Pulverisateur, pExploitation As Exploitation, pDiagnostic As Diagnostic)
        m_oRPDiag = pDiagnostic
        MyBase.setContexte(bModeAjout, pAgent, pPulverisateur, pExploitation, pDiagnostic)
        Me.Text = "Pulvérisateur"
    End Sub

    Public Overrides Sub FormLoad()
        MyBase.formLoad()
        MinimizeBox = False
        MaximizeBox = False
        'En mode reglage Pulvé certains champs ne sont pas obigatoire => on enlève le soulignement
        lblIdentifiantPulve.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        'Id Non Indifo est active
        IDNonIndigo.Checked = True
        IDNonIndigo.Visible = False
        ckAncienIdentifiant.Visible = False
        tbAncienIdentifiant.Visible = False


        btn_fichePulve_annuler.Visible = False
        btn_fichePulve_valider.Visible = False
        btn_fichePulve_supprimer.Visible = False
        laProchainControle.Visible = False
        dtDateProchainControle.Visible = False
        pbEtat.Visible = False

        cbxIdentPulve.DropDownStyle = ComboBoxStyle.Simple
    End Sub
    ''' <summary>
    ''' Fonction Valider en mode reglage Pulvé
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Function Valider() As Boolean
        ' On crée notre nouveau pulvé
        Dim bReturn As Boolean = True

        Try
            bReturn = checkForm()
            If bReturn = True Then
                SubmitForm()
                If m_oDiagnostic IsNot Nothing Then
                    m_oDiagnostic.setPulverisateur(m_oPulverisateur)
                    m_oDiagnostic.EncodageAuto()
                    Dim oParamDiag As CRODIP_ControlLibrary.ParamDiag = m_oDiagnostic.getParamDiag()
                    m_oDiagnostic.ParamDiag = oParamDiag
                    m_oRPDiag.RaiseEventParamDiagEvent()
                    m_oRPDiag.RaiseEventLstDiagItemUpdated()

                End If
                bReturn = True
            End If
        Catch ex As Exception
            CSDebug.dispError("Ajout_pulve.Valider ERR :" & ex.Message.ToString)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Protected Overrides Sub Annuler()

    End Sub
    ''' <summary>
    ''' Verification de la saisie
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function checkForm() As Boolean
        Dim bReturn As Boolean
        Try
            bReturn = True
            lblError.Text = ""

            'Pas de controle du numéro national
            If bReturn = True And cbxMarquePulve.Text = "" Then
                lblError.Text = ("Veuillez remplir le paramètre 'Marque'.")
                bReturn = False
            End If
            If bReturn = True And cbxModelesPulve.Text = "" Then
                lblError.Text = ("Veuillez remplir le paramètre 'Modèle'.")
                bReturn = False
            End If
            If bReturn = True And fichePulve_dateAchat.Text = "" Then
                lblError.Text = ("Veuillez remplir le paramètre 'Date de construction'.")
                bReturn = False
            End If
            If bReturn = True And cbxTypePulve.Text = "" Then
                lblError.Text = ("Veuillez remplir le paramètre 'Type de pulvérisateur'.")
                bReturn = False
            End If
            If bReturn = True And cbxCategorie_pulve.Text = "" Then
                lblError.Text = ("Veuillez remplir le paramètre 'Catégorie du pulvérisateur'.")
                bReturn = False
            End If
            If bReturn = True And cbxLargeur_rang_pulve.Text = "" Then
                lblError.Text = ("Veuillez remplir le paramètre 'Larg/nb rangs pulvérisateur'.")
                bReturn = False
            End If
            If bReturn = True And _
            String.IsNullOrEmpty(cbxAttelage.Text) Then
                lblError.Text = ("Veuillez remplir le paramètre 'Attelage'.")
                bReturn = False
            End If
            If bReturn And String.IsNullOrEmpty(cbxPulverisation.Text) Then
                lblError.Text = ("Veuillez remplir le paramètre 'Pulverisation'.")
                bReturn = False
            End If

            If bReturn = True And fichePulve_capacite.Text = "" Then
                lblError.Text = ("Veuillez remplir le paramètre 'Capacité'.")
                bReturn = False
            End If
            If bReturn = True And cbxRegulation.Text = "" Then
                lblError.Text = ("Veuillez remplir le paramètre 'Régulation'.")
                bReturn = False
            End If
            If bReturn = True And fichePulve_buses_type.Text = "" Then
                lblError.Text = ("Veuillez remplir le paramètre 'Type de buses'.")
                bReturn = False
            End If
            If bReturn = True And fichePulve_buses_fonctionnement.Text = "" Then
                lblError.Text = ("Veuillez remplir le paramètre 'Fonctionnement de buses'.")
                bReturn = False
            End If
        Catch ex As Exception
            CSDebug.dispError("frmRPFichePulve.checkForm ERR" + ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Protected Overrides Function validerLeNumeroNational() As ajout_pulve2.ValiderNumeroNationalResult
        Return ValiderNumeroNationalResult.OK
    End Function

    Private Sub frmRPFichePulve_Leave(sender As Object, e As EventArgs) Handles Me.Leave
        'Valider()
    End Sub

    Public Overrides Sub refresh()
        FillForm()
    End Sub
End Class