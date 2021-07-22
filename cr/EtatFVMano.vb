Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class EtatFVMano
    Inherits EtatCrodip

    Private m_oControle As ControleMano
    Private m_ods As dsFvMano

    Public Sub New(pControle As ControleMano)
        m_Path = GlobalsCRODIP.CONST_PATH_EXP_MANOCONTROLE
        m_oControle = pControle
    End Sub

    Protected Overrides Function GenereEtatLocal(Optional pExportPDF As Boolean = True) As Boolean
        Dim bReturn As Boolean
        Dim strReportName As String
        Try
            bReturn = genereDS()
            If (bReturn) Then
                Using objReport As New ReportDocument
                    Using r1 As New cr_FicheVerifMano()
                        strReportName = r1.ResourceName
                        r1.Close()
                    End Using

                    objReport.Load(MySettings.Default.RepertoireParametres & "/" & strReportName)

                    objReport.SetDataSource(m_ods)
                    objReport.SetParameterValue("ModeSimplifie", GlobalsCRODIP.GLOB_ENV_MODESIMPLIFIE)
                    Dim CrExportOptions As ExportOptions
                    Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions
                    Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions
                    Dim oMano As ManometreControle
                    oMano = ManometreControleManager.getManometreControleByNumeroNational(m_oControle.idMano)
                    m_FileName = CSDiagPdf.makeFilename(oMano.idCrodip, CSDiagPdf.TYPE_FV_MANOCTRL) & ".pdf"
                    CrDiskFileDestinationOptions.DiskFileName = m_Path & m_FileName
                    CrExportOptions = objReport.ExportOptions
                    With CrExportOptions
                        .ExportDestinationType = ExportDestinationType.DiskFile
                        .ExportFormatType = ExportFormatType.PortableDocFormat
                        .DestinationOptions = CrDiskFileDestinationOptions
                        .FormatOptions = CrFormatTypeOptions
                    End With
                    objReport.Export()
                    objReport.Close()
                End Using

            End If
        Catch ex As Exception
            CSDebug.dispError("EtatRapportInspection.GenereEtat ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Private Function genereDS() As Boolean
        Dim bReturn As Boolean
        Try
            Dim oManoRef As ManometreEtalon
            oManoRef = ManometreEtalonManager.getManometreEtalonByNumeroNational(m_oControle.manoEtalon)
            Dim oMano As ManometreControle
            oMano = ManometreControleManager.getManometreControleByNumeroNational(m_oControle.idMano)
            ' Recupere la structure
            Dim objStructure As Structuree = StructureManager.getStructureById(m_oControle.idStructure)
            Dim PressionCroissante As String = "Pression croissante"
            Dim PressionDecroissante As String = "Pression décroissante"
            m_ods = New dsFvMano()
            m_ods.Verif.AddVerifRow(dateVerification:=CDate(m_oControle.DateVerif).ToShortDateString(), _
                                    agentVerif:=m_oControle.AgentVerif, _
                                     proprietaire:=objStructure.nom, _
                                     NumManoRef:=oManoRef.idCrodip,
                                     TypeManoRef:=oManoRef.type,
                                     MarqueManoRef:=oManoRef.marque,
                                     FondManoRef:=oManoRef.fondEchelle,
                                     ClasseManoRef:=oManoRef.classe,
                                     IncertitudeManoRef:=oManoRef.incertitudeEtalon,
                                     NumMano:=oMano.idCrodip,
                                     MarqueMano:=oMano.marque,
                                    ClasseMano:=oMano.classe,
                                    UniteMano:="bar",
                                    FondMano:=oMano.fondEchelle,
                                    ResolutionMano:=oMano.resolution,
                                    Temperature:=m_oControle.tempAir,
                                    Resultat:=m_oControle.resultat
                                    )
            m_ods.Pression.AddPressionRow(Type:=PressionCroissante, _
                                          PointEssai:="1", _
                                          PressionMano:=m_oControle.up_pt1_pres_manoCtrl, _
                                          PressionManoRef:=m_oControle.up_pt1_pres_manoEtalon, _
                                          ErreurAbsolue:=m_oControle.up_pt1_err_abs, _
                                          ErreurFond:=m_oControle.up_pt1_err_fondEchelle, _
                                          Incertitude:=m_oControle.up_pt1_incertitude, _
                                          EMT:=m_oControle.up_pt1_EMT, _
                                          Conformité:=m_oControle.up_pt1_conformite)

            m_ods.Pression.AddPressionRow(Type:=PressionCroissante, _
                                          PointEssai:="2", _
                                          PressionMano:=m_oControle.up_pt2_pres_manoCtrl, _
                                          PressionManoRef:=m_oControle.up_pt2_pres_manoEtalon, _
                                          ErreurAbsolue:=m_oControle.up_pt2_err_abs, _
                                          ErreurFond:=m_oControle.up_pt2_err_fondEchelle, _
                                          Incertitude:=m_oControle.up_pt2_incertitude, _
                                          EMT:=m_oControle.up_pt2_EMT, _
                                          Conformité:=m_oControle.up_pt2_conformite)
            m_ods.Pression.AddPressionRow(Type:=PressionCroissante, _
                                          PointEssai:="3", _
                                          PressionMano:=m_oControle.up_pt3_pres_manoCtrl, _
                                          PressionManoRef:=m_oControle.up_pt3_pres_manoEtalon, _
                                          ErreurAbsolue:=m_oControle.up_pt3_err_abs, _
                                          ErreurFond:=m_oControle.up_pt3_err_fondEchelle, _
                                          Incertitude:=m_oControle.up_pt3_incertitude, _
                                          EMT:=m_oControle.up_pt3_EMT, _
                                          Conformité:=m_oControle.up_pt3_conformite)
            m_ods.Pression.AddPressionRow(Type:=PressionCroissante, _
                                          PointEssai:="4", _
                                          PressionMano:=m_oControle.up_pt4_pres_manoCtrl, _
                                          PressionManoRef:=m_oControle.up_pt4_pres_manoEtalon, _
                                          ErreurAbsolue:=m_oControle.up_pt4_err_abs, _
                                          ErreurFond:=m_oControle.up_pt4_err_fondEchelle, _
                                          Incertitude:=m_oControle.up_pt4_incertitude, _
                                          EMT:=m_oControle.up_pt4_EMT, _
                                          Conformité:=m_oControle.up_pt4_conformite)
            m_ods.Pression.AddPressionRow(Type:=PressionCroissante, _
                                          PointEssai:="5", _
                                          PressionMano:=m_oControle.up_pt5_pres_manoCtrl, _
                                          PressionManoRef:=m_oControle.up_pt5_pres_manoEtalon, _
                                          ErreurAbsolue:=m_oControle.up_pt5_err_abs, _
                                          ErreurFond:=m_oControle.up_pt5_err_fondEchelle, _
                                          Incertitude:=m_oControle.up_pt5_incertitude, _
                                          EMT:=m_oControle.up_pt5_EMT, _
                                          Conformité:=m_oControle.up_pt5_conformite)
            m_ods.Pression.AddPressionRow(Type:=PressionCroissante, _
                                          PointEssai:="6", _
                                          PressionMano:=m_oControle.up_pt6_pres_manoCtrl, _
                                          PressionManoRef:=m_oControle.up_pt6_pres_manoEtalon, _
                                          ErreurAbsolue:=m_oControle.up_pt6_err_abs, _
                                          ErreurFond:=m_oControle.up_pt6_err_fondEchelle, _
                                          Incertitude:=m_oControle.up_pt6_incertitude, _
                                          EMT:=m_oControle.up_pt6_EMT, _
                                          Conformité:=m_oControle.up_pt6_conformite)

            m_ods.Pression.AddPressionRow(Type:=PressionDecroissante,
                                          PointEssai:="6",
                                          PressionMano:=m_oControle.down_pt6_pres_manoCtrl,
                                          PressionManoRef:=m_oControle.down_pt6_pres_manoEtalon,
                                          ErreurAbsolue:=m_oControle.down_pt6_err_abs,
                                          ErreurFond:=m_oControle.down_pt6_err_fondEchelle,
                                          Incertitude:=m_oControle.down_pt6_incertitude,
                                          EMT:=m_oControle.down_pt6_EMT,
                                          Conformité:=m_oControle.down_pt6_conformite)
            m_ods.Pression.AddPressionRow(Type:=PressionDecroissante,
                                          PointEssai:="5",
                                          PressionMano:=m_oControle.down_pt5_pres_manoCtrl,
                                          PressionManoRef:=m_oControle.down_pt5_pres_manoEtalon,
                                          ErreurAbsolue:=m_oControle.down_pt5_err_abs,
                                          ErreurFond:=m_oControle.down_pt5_err_fondEchelle,
                                          Incertitude:=m_oControle.down_pt5_incertitude,
                                          EMT:=m_oControle.down_pt5_EMT,
                                          Conformité:=m_oControle.down_pt5_conformite)
            m_ods.Pression.AddPressionRow(Type:=PressionDecroissante,
                                          PointEssai:="4",
                                          PressionMano:=m_oControle.down_pt4_pres_manoCtrl,
                                          PressionManoRef:=m_oControle.down_pt4_pres_manoEtalon,
                                          ErreurAbsolue:=m_oControle.down_pt4_err_abs,
                                          ErreurFond:=m_oControle.down_pt4_err_fondEchelle,
                                          Incertitude:=m_oControle.down_pt4_incertitude,
                                          EMT:=m_oControle.down_pt4_EMT,
                                          Conformité:=m_oControle.down_pt4_conformite)
            m_ods.Pression.AddPressionRow(Type:=PressionDecroissante,
                                          PointEssai:="3",
                                          PressionMano:=m_oControle.down_pt3_pres_manoCtrl,
                                          PressionManoRef:=m_oControle.down_pt3_pres_manoEtalon,
                                          ErreurAbsolue:=m_oControle.down_pt3_err_abs,
                                          ErreurFond:=m_oControle.down_pt3_err_fondEchelle,
                                          Incertitude:=m_oControle.down_pt3_incertitude,
                                          EMT:=m_oControle.down_pt3_EMT,
                                          Conformité:=m_oControle.down_pt3_conformite)
            m_ods.Pression.AddPressionRow(Type:=PressionDecroissante,
                                          PointEssai:="2",
                                          PressionMano:=m_oControle.down_pt2_pres_manoCtrl,
                                          PressionManoRef:=m_oControle.down_pt2_pres_manoEtalon,
                                          ErreurAbsolue:=m_oControle.down_pt2_err_abs,
                                          ErreurFond:=m_oControle.down_pt2_err_fondEchelle,
                                          Incertitude:=m_oControle.down_pt2_incertitude,
                                          EMT:=m_oControle.down_pt2_EMT,
                                          Conformité:=m_oControle.down_pt2_conformite)
            m_ods.Pression.AddPressionRow(Type:=PressionDecroissante,
                                          PointEssai:="1",
                                          PressionMano:=m_oControle.down_pt1_pres_manoCtrl,
                                          PressionManoRef:=m_oControle.down_pt1_pres_manoEtalon,
                                          ErreurAbsolue:=m_oControle.down_pt1_err_abs,
                                          ErreurFond:=m_oControle.down_pt1_err_fondEchelle,
                                          Incertitude:=m_oControle.down_pt1_incertitude,
                                          EMT:=m_oControle.down_pt1_EMT,
                                          Conformité:=m_oControle.down_pt1_conformite)

            'For Each oMesure As ControleBancBuse In m_oControle.lstMesures
            '    If Not String.IsNullOrEmpty(oMesure.Couleur) Then
            '        Dim sResult As String = IIf(oMesure.resultat_3bar, "1", "0")
            '        m_ods.Buse.AddBuseRow(couleur:=oMesure.Couleur, Numero:=oMesure.numero, PressionEtalonage:=oMesure.pressionEtal, debit3bars:=oMesure.debitEtal, Mesure1:=oMesure.m1_3bar, Mesure2:=oMesure.m2_3bar, Mesure3:=oMesure.m3_3bar, Moyenne:=oMesure.moy_3bar, Ecart:=oMesure.ecart_3bar, Resultat:=sResult, pctEcart3bar:=oMesure.pctEcart_3bar, pctEcartTolerance:=oMesure.pctTolerance_3bar)
            '    End If
            'Next
            bReturn = True

        Catch ex As Exception
            CSDebug.dispError("EtatRapportInspection.GenereEtat ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn

    End Function
    'Public Function buildPDF(ByVal curMano As ManometreControle)

    '    ' Init
    '    Dim pdfTemplate As String = GlobalsCRODIP.CONST_PATH_DOCS & GlobalsCRODIP.CONST_DOC_FV_MANOCTRL & ".pdf"
    '    Dim newFile As String = GlobalsCRODIP.CONST_PATH_EXP & CSDiagPdf.makeFilename(curMano.idCrodip, CSDiagPdf.TYPE_FV_MANOCTRL) & ".pdf"


    '    ' Récupère le mano étalon
    '    Dim manoEtalon As ManometreEtalon = ManometreEtalonManager.getManometreEtalonByNumeroNational(list_manometresEtalon.SelectedItem.id)
    '    pdfFormFields.SetField("manoEtalon_type", manoEtalon.type)
    '    pdfFormFields.SetField("manoEtalon_marque", manoEtalon.marque)
    '    pdfFormFields.SetField("manoEtalon_classe", manoEtalon.classe)
    '    pdfFormFields.SetField("manoEtalon_numero", manoEtalon.idCrodip)
    '    pdfFormFields.SetField("manoEtalon_fondEchelle", manoEtalon.fondEchelle)
    '    pdfFormFields.SetField("manoEtalon_incertitude", manoEtalon.incertitudeEtalon)

    '    ' Récupère le mano contrôle
    '    Dim manoControle As ManometreControle = curMano
    '    pdfFormFields.SetField("manoControle_marque", manoControle.marque)
    '    pdfFormFields.SetField("manoControle_classe", manoControle.classe)
    '    pdfFormFields.SetField("manoControle_fondEchelle", manoControle.fondEchelle)
    '    pdfFormFields.SetField("manoControle_temperature", Me.TextBox41.Text)
    '    pdfFormFields.SetField("manoControle_numero", manoControle.idCrodip)
    '    pdfFormFields.SetField("manoControle_unite", "bar")
    '    pdfFormFields.SetField("manoControle_resolution", manoControle.resolution)

    '    ' Recupere la structure
    '    Dim objStructure As Structuree = StructureManager.getStructureById(manoControle.idStructure)


    '    ' CONTENU
    '    pdfFormFields.SetField("dateVerification", manoControle.dateDernierControle)
    '    pdfFormFields.SetField("organisme", objStructure.nom)
    '    pdfFormFields.SetField("nomVerificateur", agentCourant.nom & " " & agentCourant.prenom)

    '    Dim tmpTab As TabPage = CSForm.getControlByName("tabPage_mano_" & curMano.numeroNational, ongletsManos)

    '    Dim up_ptEssai As String = ""
    '    Dim up_pression_mano As String = ""
    '    Dim up_pression_etalon As String = ""
    '    Dim up_erreur_absolue As String = ""
    '    Dim up_erreur_fondEchelle As String = ""
    '    Dim up_incertitude As String = ""
    '    Dim up_emt As String = ""
    '    Dim up_conformite As String = ""

    '    Dim down_ptEssai As String = ""
    '    Dim down_pression_mano As String = ""
    '    Dim down_pression_etalon As String = ""
    '    Dim down_erreur_absolue As String = ""
    '    Dim down_erreur_fondEchelle As String = ""
    '    Dim down_incertitude As String = ""
    '    Dim down_emt As String = ""
    '    Dim down_conformite As String = ""

    '    Dim global_conformite As Integer = 1

    '    ' MESURES
    '    For i As Integer = 1 To nbMesures
    '        Try
    '            Dim tmp_up_pression_capteurTeste As TextBox = CSForm.getControlByName("croissant_pression_capteurTeste_" & i & "_" & curMano.numeroNational, tmpTab)
    '            Dim tmp_up_pression_instrumentReference As TextBox = CSForm.getControlByName("croissant_pression_instrumentReference_" & i & "_" & curMano.numeroNational, tmpTab)
    '            Dim tmp_up_incertitude As TextBox = CSForm.getControlByName("croissant_incertitude_" & i & "_" & curMano.numeroNational, tmpTab)
    '            Dim tmp_up_EMT As TextBox = CSForm.getControlByName("croissant_EMT_" & i & "_" & curMano.numeroNational, tmpTab)
    '            Dim tmp_up_erreur_absolue As TextBox = CSForm.getControlByName("croissant_erreur_absolue_" & i & "_" & curMano.numeroNational, tmpTab)
    '            Dim tmp_up_erreur_fondEchelle As TextBox = CSForm.getControlByName("croissant_erreur_fondEchelle_" & i & "_" & curMano.numeroNational, tmpTab)


    '            Dim tmp_down_pression_capteurTeste As TextBox = CSForm.getControlByName("decroissant_pression_capteurTeste_" & i & "_" & curMano.numeroNational, tmpTab)
    '            Dim tmp_down_pression_instrumentReference As TextBox = CSForm.getControlByName("decroissant_pression_instrumentReference_" & i & "_" & curMano.numeroNational, tmpTab)
    '            Dim tmp_down_incertitude As TextBox = CSForm.getControlByName("decroissant_incertitude_" & i & "_" & curMano.numeroNational, tmpTab)
    '            Dim tmp_down_EMT As TextBox = CSForm.getControlByName("decroissant_EMT_" & i & "_" & curMano.numeroNational, tmpTab)
    '            Dim tmp_down_erreur_absolue As TextBox = CSForm.getControlByName("decroissant_erreur_absolue_" & i & "_" & curMano.numeroNational, tmpTab)
    '            Dim tmp_down_erreur_fondEchelle As TextBox = CSForm.getControlByName("decroissant_erreur_fondEchelle_" & i & "_" & curMano.numeroNational, tmpTab)

    '            'Points D'essai
    '            up_ptEssai = up_ptEssai & vbCrLf & i
    '            'Pression Mano à controler
    '            up_pression_mano = up_pression_mano & vbCrLf & tmp_up_pression_capteurTeste.Text
    '            'Pression Mano Etalon
    '            up_pression_etalon = up_pression_etalon & vbCrLf & FormatStringDecimal(tmp_up_pression_instrumentReference.Text, 3)
    '            'Erreur Absolue
    '            up_erreur_absolue = up_erreur_absolue & vbCrLf & FormatStringDecimal(tmp_up_erreur_absolue.Text, 2)
    '            'Erreur Fond d'échelle
    '            up_erreur_fondEchelle = up_erreur_fondEchelle & vbCrLf & FormatStringDecimal(tmp_up_erreur_fondEchelle.Text, 1)
    '            'Incertitude avec K=2
    '            up_incertitude = up_incertitude & vbCrLf & tmp_up_incertitude.Text
    '            'Emt
    '            up_emt = up_emt & vbCrLf & tmp_up_EMT.Text
    '            'Conformité
    '            If tmp_up_erreur_fondEchelle.ForeColor.Equals(System.Drawing.Color.Red) Then
    '                up_conformite = up_conformite & vbCrLf & 0
    '                global_conformite = 0
    '            Else
    '                up_conformite = up_conformite & vbCrLf & 1
    '            End If

    '            down_ptEssai = down_ptEssai & vbCrLf & i
    '            down_pression_mano = down_pression_mano & vbCrLf & tmp_down_pression_capteurTeste.Text
    '            down_pression_etalon = down_pression_etalon & vbCrLf & FormatStringDecimal(tmp_down_pression_instrumentReference.Text, 3)
    '            down_erreur_absolue = down_erreur_absolue & vbCrLf & FormatStringDecimal(tmp_down_erreur_absolue.Text, 2)
    '            down_erreur_fondEchelle = down_erreur_fondEchelle & vbCrLf & FormatStringDecimal(tmp_down_erreur_fondEchelle.Text, 1)
    '            down_incertitude = down_incertitude & vbCrLf & tmp_down_incertitude.Text
    '            down_emt = down_emt & vbCrLf & tmp_down_EMT.Text
    '            If tmp_down_erreur_fondEchelle.ForeColor.Equals(System.Drawing.Color.Red) Then
    '                down_conformite = down_conformite & vbCrLf & 0
    '                global_conformite = 0
    '            Else
    '                down_conformite = down_conformite & vbCrLf & 1
    '            End If

    '        Catch ex As Exception
    '            CSDebug.dispError("controle_mano::validation : " & ex.Message)
    '        End Try
    '    Next

    '    pdfFormFields.SetField("up_ptEssai", up_ptEssai)
    '    pdfFormFields.SetField("up_pression_mano", up_pression_mano)
    '    pdfFormFields.SetField("up_pression_etalon", up_pression_etalon)
    '    pdfFormFields.SetField("up_erreur_absolue", up_erreur_absolue)
    '    pdfFormFields.SetField("up_erreur_fondEchelle", up_erreur_fondEchelle)
    '    pdfFormFields.SetField("up_incertitude", up_incertitude)
    '    pdfFormFields.SetField("up_emt", up_emt)
    '    pdfFormFields.SetField("up_conformite", up_conformite)

    '    pdfFormFields.SetField("down_ptEssai", down_ptEssai)
    '    pdfFormFields.SetField("down_pression_mano", down_pression_mano)
    '    pdfFormFields.SetField("down_pression_etalon", down_pression_etalon)
    '    pdfFormFields.SetField("down_erreur_absolue", down_erreur_absolue)
    '    pdfFormFields.SetField("down_erreur_fondEchelle", down_erreur_fondEchelle)
    '    pdfFormFields.SetField("down_incertitude", down_incertitude)
    '    pdfFormFields.SetField("down_emt", down_emt)
    '    pdfFormFields.SetField("down_conformite", down_conformite)

    '    If global_conformite = 1 Then
    '        pdfFormFields.SetField("resultat", "Votre manomètre est fiable : il répond à sa classe de précision.")
    '    Else
    '        pdfFormFields.SetField("resultat", "Votre manomètre n'est pas fiable : il ne répond pas à sa classe de précision. Faites le remettre en état ou changez le.")
    '    End If

    '    ' On referme le PDF

    'End Function

End Class
