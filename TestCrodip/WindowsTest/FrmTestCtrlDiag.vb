Public Class FrmTestCtrlDiag

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim param As CRODIP_ControlLibrary.ParamCtrlDiag

        param = New CRODIP_ControlLibrary.ParamCtrlDiag
        param.Actif = True
        param.Libelle = "Cause1"
        param.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        'param.NiveauCauseMax = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.TROIS
        param.Cause1 = True
        param.Cause2 = False
        param.Cause3 = False
        param.Affecte(Me.CtrlDiag21)

        param = New CRODIP_ControlLibrary.ParamCtrlDiag
        param.Actif = True
        param.Libelle = "Cause2"
        param.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        'param.NiveauCauseMax = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.TROIS
        param.Cause1 = False
        param.Cause2 = True
        param.Cause3 = False
        param.Affecte(Me.CtrlDiag22)

        param = New CRODIP_ControlLibrary.ParamCtrlDiag
        param.Actif = True
        param.Libelle = "Cause3"
        param.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        'param.NiveauCauseMax = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.TROIS
        param.Cause1 = False
        param.Cause2 = False
        param.Cause3 = True
        param.Affecte(Me.CtrlDiag23)

        param = New CRODIP_ControlLibrary.ParamCtrlDiag
        param.Actif = True
        param.Libelle = "Cause12"
        param.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        'param.NiveauCauseMax = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.TROIS
        param.Cause1 = True
        param.Cause2 = True
        param.Cause3 = False
        param.Affecte(Me.CtrlDiag212)

        param = New CRODIP_ControlLibrary.ParamCtrlDiag
        param.Actif = True
        param.Libelle = "Cause23"
        param.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        'param.NiveauCauseMax = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.TROIS
        param.Cause1 = False
        param.Cause2 = True
        param.Cause3 = True
        param.Affecte(Me.CtrlDiag223)

        param = New CRODIP_ControlLibrary.ParamCtrlDiag
        param.Actif = True
        param.Libelle = "Cause13"
        param.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        'param.NiveauCauseMax = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.TROIS
        param.Cause1 = True
        param.Cause2 = False
        param.Cause3 = True
        param.Affecte(Me.CtrlDiag213)

        param = New CRODIP_ControlLibrary.ParamCtrlDiag
        param.Actif = True
        param.Libelle = "Cause123(Mineur)"
        param.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        'param.NiveauCauseMax = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.TROIS
        param.Cause1 = True
        param.Cause2 = True
        param.Cause3 = True
        param.Affecte(Me.CtrlDiag2123)

        param = New CRODIP_ControlLibrary.ParamCtrlDiag
        param.Actif = True
        param.Libelle = "Cause0"
        param.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        'param.NiveauCauseMax = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.TROIS
        param.Cause1 = False
        param.Cause2 = False
        param.Cause3 = False
        param.Affecte(Me.CtrlDiag20)

        param = New CRODIP_ControlLibrary.ParamCtrlDiag
        param.Actif = True
        param.Libelle = "Cause123(Majeur)"
        param.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        'param.NiveauCauseMax = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.TROIS
        param.Cause1 = True
        param.Cause2 = True
        param.Cause3 = True
        param.Affecte(Me.CtrlDiag2123A)
    End Sub

    Private Sub btnCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheck.Click
        ListBox1.Items.Clear()

        ListBox1.Items.Add("Cause1: Checked = [" & CtrlDiag21.Checked & "],Cause = " & CtrlDiag21.Cause & ", Categorie = " & CtrlDiag21.Categorie)
        ListBox1.Items.Add("Cause2: Checked = [" & CtrlDiag22.Checked & "],Cause = " & CtrlDiag22.Cause & ", Categorie = " & CtrlDiag22.Categorie)
        ListBox1.Items.Add("Cause3: Checked = [" & CtrlDiag23.Checked & "],Cause = " & CtrlDiag23.Cause & ", Categorie = " & CtrlDiag23.Categorie)

        ListBox1.Items.Add("Cause12: Checked = [" & CtrlDiag212.Checked & "],Cause = " & CtrlDiag212.Cause & ", Categorie = " & CtrlDiag212.Categorie)
        ListBox1.Items.Add("Cause23: Checked = [" & CtrlDiag223.Checked & "],Cause = " & CtrlDiag223.Cause & ", Categorie = " & CtrlDiag223.Categorie)
        ListBox1.Items.Add("Cause13: Checked = [" & CtrlDiag213.Checked & "],Cause = " & CtrlDiag213.Cause & ", Categorie = " & CtrlDiag213.Categorie)

        ListBox1.Items.Add("Cause123(I): Checked = [" & CtrlDiag2123.Checked & "],Cause = " & CtrlDiag2123.Cause & ", Categorie = " & CtrlDiag2123.Categorie)
        ListBox1.Items.Add("Cause123(A): Checked = [" & CtrlDiag2123A.Checked & "],Cause = " & CtrlDiag2123A.Cause & ", Categorie = " & CtrlDiag2123A.Categorie)
        ListBox1.Items.Add("Cause0: Checked = [" & CtrlDiag20.Checked & "],Cause = " & CtrlDiag20.Cause & ", Categorie = " & CtrlDiag20.Categorie)
    End Sub
End Class