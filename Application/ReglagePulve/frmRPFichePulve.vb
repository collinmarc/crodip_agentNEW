Public Class frmRPFichePulve
    Inherits ajout_pulve2
    Implements IfrmCRODIP


    Private m_oDiag As RPDiagnostic

    Public Overridable Sub setContexte(ByVal bModeAjout As MODE, pAgent As Agent, pPulverisateur As Pulverisateur, pDiagnostic As Diagnostic)
        m_oDiag = pDiagnostic
        MyBase.setContexte(bModeAjout, pAgent, pPulverisateur, pDiagnostic)
    End Sub

    Public Overrides Sub FormLoad()
        MyBase.formLoad()
        'En mode reglage Pulvé certains champs ne sont pas obigatoire => on enlève le soulignement
        lblIdentifiantPulve.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        'Id Non Indifo est active
        IDNonIndigo.Checked = True
        IDNonIndigo.Visible = False
        chkAncienIdentifiant.Visible = False
        tbAncienIdentifiant.Visible = False


        btn_fichePulve_annuler.Visible = False
        btn_fichePulve_valider.Visible = False
        btn_fichePulve_supprimer.Visible = False
        laProchainControle.Visible = False
        tbDateProchControle.Visible = False
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
    Protected Overrides Function validerLeNumeroNational(pNumNational As String) As ajout_pulve2.ValiderNumeroNationalResult
        Return ValiderNumeroNationalResult.OK
    End Function

End Class