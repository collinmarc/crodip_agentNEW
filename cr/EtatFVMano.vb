Imports System.Linq
Imports CRODIPWS
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
            CSDebug.dispInfo("etatFVMano.GenereEtatLocal() :  GenereDS")
            bReturn = genereDS()
            If (bReturn) Then
                CSDebug.dispInfo("etatFVMano.GenereEtatLocal() :  GenerePDF")
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
                    m_FileName = CSDiagPdf.makeFilename(m_oControle.idMano, CSDiagPdf.TYPE_FV_MANOCTRL) & ".pdf"
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
            Dim objStructure As [Structure] = StructureManager.getStructureById(m_oControle.idStructure)

            m_ods = New dsFvMano()
            m_ods.Verif.AddVerifRow(dateVerification:=CDate(m_oControle.DateVerif).ToShortDateString(),
                                    agentVerif:=m_oControle.AgentVerif,
                                     proprietaire:=objStructure.nom,
                                     NumManoRef:=oManoRef.numeroNational,
                                     TypeManoRef:=oManoRef.type,
                                     MarqueManoRef:=oManoRef.marque,
                                     FondManoRef:=oManoRef.fondEchelle,
                                     ClasseManoRef:=oManoRef.classe,
                                     IncertitudeManoRef:=oManoRef.incertitudeEtalon,
                                     NumMano:=oMano.numeroNational,
                                     MarqueMano:=oMano.marque,
                                    ClasseMano:=oMano.classe,
                                    UniteMano:="bar",
                                    FondMano:=oMano.fondEchelle,
                                    ResolutionMano:=oMano.resolution,
                                    Temperature:=m_oControle.tempAir,
                                    Resultat:=m_oControle.resultat
                                    )
            For Each oDetail As ControleManoDetail In m_oControle.lstControleManoDetail.Values
                m_ods.Pression.AddPressionRow(Type:=oDetail.type,
                                          PointEssai:=oDetail.point,
                                          PressionMano:=oDetail.pres_manoCtrl,
                                          PressionManoRef:=oDetail.pres_manoEtalon,
                                          ErreurAbsolue:=oDetail.err_abs,
                                          ErreurFond:=oDetail.err_fondEchelle,
                                          Incertitude:=oDetail.incertitude,
                                          EMT:=oDetail.EMT,
                                          Conformité:=oDetail.conformite)
            Next



            Dim nPC As Integer = m_oControle.lstControleManoDetail.Values.Where(Function(D)
                                                                                    Return D.type = "UP"
                                                                                End Function).Count()
            Dim nPD As Integer = m_oControle.lstControleManoDetail.Values.Where(Function(D)
                                                                                    Return D.type = "DOWN"
                                                                                End Function).Count()
            Dim nPR As Integer = m_oControle.lstControleManoDetail.Values.Where(Function(D)
                                                                                    Return D.type = "REPE"
                                                                                End Function).Count()
            Dim nMax As Integer = Math.Max(nPR, Math.Max(nPC, nPD))

            For nIndex As Integer = 0 To nMax - 1
                Dim oRow As dsFvMano.DiagrammeRow
                oRow = m_ods.Diagramme.NewDiagrammeRow()
                oRow.Numero = nIndex + 1
                If nIndex < nPC Then
                    oRow.PressionCroissante = m_oControle.lstControleManoDetail_pres_manoEtalon("UP" & m_oControle.lstControleManoDetailUp(nIndex).point)
                Else
                    oRow.SetPressionCroissanteNull()
                End If
                If nIndex < nPD Then
                    oRow.PressionDecroissante = m_oControle.lstControleManoDetail_pres_manoEtalon("DOWN" & m_oControle.lstControleManoDetailDown(nIndex).point)
                Else
                    oRow.SetPressionDecroissanteNull()
                End If
                If nIndex < nPR Then
                    oRow.PressionRepetition = m_oControle.lstControleManoDetail_pres_manoEtalon("REPE" & m_oControle.lstControleManoDetailREPE(nIndex).point)
                Else
                    oRow.SetPressionRepetitionNull()
                End If
                m_ods.Diagramme.AddDiagrammeRow(oRow)



            Next

            bReturn = True

        Catch ex As Exception
            CSDebug.dispError("EtatFVMAno.GenereDS ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn

    End Function
    Public Function buildPDF(ByVal pMano As ManometreControle, pAgent As Agent) As String
        Dim sReturn As String

        m_oControle.DateVerif = pMano.dateDernierControleS
        m_oControle.Proprietaire = pAgent.NomStructure
        m_oControle.AgentVerif = pAgent.nom & " " & pAgent.prenom
        m_oControle.idMano = pMano.numeroNational

        '        Dim oEtat As New EtatFVBanc(Me)
        Dim bReturn As Boolean = genereEtat()
        If bReturn Then
            sReturn = getFileName()
        Else
            sReturn = ""
        End If
        Return sReturn
    End Function 'BuildPDF

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
    '    Dim objStructure As [Structure] = StructureManager.getStructureById(manoControle.idStructure)


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
