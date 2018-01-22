Public Class frmRPDiagnostique
    Inherits frmDiagnostique
    Implements IfrmCRODIP


    ''' <summary>
    ''' Formload pour le reglage Pulvé
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub Formload() Implements IfrmCRODIP.formLoad
        Try
            Me.ControlBox = False
            Me.WindowState = FormWindowState.Maximized
            MyBase.Formload()
            MinimizeBox = False
            MaximizeBox = False

            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
            tab_diagnostique.TabPages.RemoveByKey(tabPage_diagnostique_etatGeneral.Name)
            tab_diagnostique.TabPages.RemoveByKey(tabPage_diagnostique_pompeCuve.Name)
            tab_diagnostique.TabPages.RemoveByKey(tabPage_diagnostique_flexiblesFiltres.Name)
            tab_diagnostique.TabPages.RemoveByKey(tabPage_diagnostique_jetsSoufflerie.Name)
            tab_diagnostique.TabPages.RemoveByKey(tabPage_diagnostique_rampes.Name)
            tab_diagnostique.TabPages.RemoveByKey(tabPage_diagnostique_accessoires.Name)
            tab_diagnostique.TabPages.RemoveByKey(tabPage_diagnostique_mesureCommandesRegulation.Name)

            Me.btn_Valider.Visible = False
            Me.btn_annuler.Visible = False
            Me.btn_Poursuivre.Visible = False

            'Utilisation du manomètre
            'manoTroncon_listManoControle.Visible = False
            'Label65.Visible = False

            '542 imprecission
            'Label224.Visible = False
            'manopulvePressionImprecision_1.Visible = False
            'manopulvePressionImprecision_2.Visible = False
            'manopulvePressionImprecision_3.Visible = False
            'manopulvePressionImprecision_4.Visible = False
            'Panel46.Height = Panel46.Height + 10

            'Résultat 542 
            'Label226.Visible = False
            'manopulveResultat.Visible = False

            '833 General
            Label6.Visible = False
            lblp833DefautEcart.Visible = False
            Label221.Visible = False
            lblP833DefautHeterogeneite.Visible = False

            '833 Mesures1
            Label2.Visible = False
            pressionTronc_DefautEcart1.Visible = False
            Label1.Visible = False
            pressionTronc_heterogeniteAlimentation1.Visible = False
            '833 Mesures2
            Label7.Visible = False
            pressionTronc_DefautEcart2.Visible = False
            Label9.Visible = False
            pressionTronc_heterogeniteAlimentation2.Visible = False
            '833 Mesures3
            Label71.Visible = False
            pressionTronc_DefautEcart3.Visible = False
            Label73.Visible = False
            pressionTronc_heterogeniteAlimentation3.Visible = False
            '833 Mesures4
            Label90.Visible = False
            pressionTronc_DefautEcart4.Visible = False
            Label103.Visible = False
            pressionTronc_heterogeniteAlimentation4.Visible = False

            'Buses Choix du banc
            Label77.Visible = False
            Label76.Visible = False
            buses_listBancs.Visible = False

            'Modification des Labeles
            Lbl_diagnostic_542.Text = "     Contrôle du manomètre pulvérisateur"
            Lbl_diagnostic_833.Text = "     Pression aux sorties des tronçons"
            Lbl_diagnostic_922.Text = "     Mesure du débit"
            CSDebug.dispInfo("frmRPDiagnostique.FormLoad END")

        Catch ex As Exception
            CSDebug.dispError("diagnostique_Load ERR" & ex.Message)
            If ex.InnerException IsNot Nothing Then
                CSDebug.dispError("diagnostique_Load ERR" & ex.InnerException.Message)
            End If
        End Try
        m_bDuringLoad551 = False
        m_bDuringLoad552 = False

    End Sub

    Protected Overrides Sub getListeManoControle()

    End Sub

    Protected Overrides Sub getListeBancsMesures()

    End Sub
    Protected Overrides Function CheckIfBusesAreFilled() As Boolean
        Dim bAllFilled As Boolean
        bAllFilled = True
        Try
            bAllFilled = Not (String.IsNullOrEmpty(tbPressionMesure.Text))

            If Panel922.Enabled = True Then
                If IsNumeric(diagBuses_conf_nbCategories.Text) Then
                    Dim nbLots As Integer = CType(diagBuses_conf_nbCategories.Text, Integer)
                    For i As Integer = 1 To nbLots
                        Try
                            bAllFilled = bAllFilled And CheckIfBusesAreFilled(i)
                        Catch ex As Exception
                            CSDebug.dispWarn("diagnostique::CheckIfBusesAreFilled : " & ex.Message)
                        End Try
                    Next
                End If
            End If
            'If bAllFilled Then
            '    If buses_listBancs.Text = "" Then
            '        bAllFilled = False
            '    End If
            'End If
        Catch ex As Exception
            CSDebug.dispError("CheckIfBusesAreFilled() ERR : " & ex.Message.ToString)
        End Try
        Return bAllFilled
    End Function
    Protected Overrides Function CheckIfBusesAreFilled(ByVal pNiveau As Integer) As Boolean
        Return MyBase.CheckIfBusesAreFilled(pNiveau)
    End Function

    Protected Overrides Function Valider() As Boolean Implements IfrmCRODIP.Valider
        Dim bReturn As Boolean
        Try
            bReturn = validerDiagnostique()
        Catch ex As Exception
            CSDebug.dispError("frmRPDiagnostique.Valider Err" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Protected Overrides Sub Annuler() Implements IfrmCRODIP.Annuler
    End Sub
    ' Mise a jour du flag de l'onglet suivant les checkbox cochées
    Protected Overrides Function checkIsOk(ByVal ongletId As Integer) As Boolean

        Dim bIsOk As Boolean = False
        Try
            If Not m_bDuringLoad Then
                Select Case ongletId
                    Case 1
                        'Pour L'onglet 1 , on vérifie directement les CheckBox
                        '                    tab_diagnostique.TabPages("tabPage_diagnostique_etatGeneral").ImageIndex() = checkOnglet1()
                    Case 2
                        'Pour L'onglet 2 , on vérifie directement les CheckBox
                        '                   tab_diagnostique.TabPages("tabPage_diagnostique_pompeCuve").ImageIndex() = checkOnglet2()
                    Case 3
                        'Pour L'onglet 3 , on vérifie directement les CheckBox
                        '                  tab_diagnostique.TabPages("tabPage_diagnostique_flexiblesFiltres").ImageIndex() = checkOnglet3()
                    Case 4
                        'Pour L'onglet 4 , on vérifie directement les CheckBox
                        '                 tab_diagnostique.TabPages("tabPage_diagnostique_jetsSoufflerie").ImageIndex() = checkOnglet4()
                    Case 5
                        'Pour L'onglet 5 , on vérifie directement les CheckBox
                        '                tab_diagnostique.TabPages("tabPage_diagnostique_mesureCommandesRegulation").ImageIndex() = checkOnglet5()
                    Case 6
                        'Pour L'onglet 6 , on vérifie directement les CheckBox
                        '               tab_diagnostique.TabPages("tabPage_diagnostique_rampes").ImageIndex() = checkOnglet6()
                    Case 7
                        'Pour L'onglet 7 , on vérifie directement les Labels
                        tab_diagnostique.TabPages("tabPage_diagnostique_manoTroncon").ImageIndex() = CheckOnglet7()

                    Case 8
                        'Pour L'onglet 8 
                        tab_diagnostique.TabPages("tabPage_diagnostique_buses").ImageIndex() = CheckOnglet8()
                    Case 9
                        'Pour L'onglet Accessoires
                        '              tab_diagnostique.TabPages("tabPage_diagnostique_accessoires").ImageIndex() = checkOnglet9()
                    Case Else
                        tab_diagnostique.TabPages(ongletId - 1).ImageIndex() = 2 ' Vert
                End Select
                checkIsAllFilled()
            End If
        Catch ex As Exception
            CSDebug.dispError("frmRPDiagnostique.checkIsOk ERR : " & ex.Message)
        End Try
        Return bIsOk
    End Function
    Protected Overrides Function CheckOnglet7() As Integer
        Dim iReturn As Integer = 3 'Etat initial = 3 Gris
        iReturn = MyBase.CheckOnglet7()
        Return iReturn
    End Function

    ''' Calcul l'état de l'onglet Buses
    ''' si Tous les champs requis sont remplis
    '''     Test sur le label Résultat
    ''' =============================
    Protected Overrides Function CheckOnglet8() As Integer

        Dim iReturn As Integer = 3 'Etat initial = 3 Gris
        iReturn = MyBase.CheckOnglet8()
        Return iReturn
    End Function

    Private Sub frmRPDiagnostique_Leave(sender As Object, e As EventArgs) Handles Me.Leave
        Valider()
    End Sub

    Private Sub frmRPDiagnostique_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not DesignMode Then
            Formload()
        End If
    End Sub
End Class