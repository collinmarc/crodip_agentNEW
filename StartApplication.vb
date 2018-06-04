Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Module StartApplication
#Region "Variables de SESSION"
    ' StatusBar
    Public Statusbar As CSStatusbar
    ' Agent courant logguer
    Public agentCourant As Agent
    ' Client actuellement sélectionné
    Public clientCourant As Exploitation
    ' Pulvé actuellement sélectionné
    Public pulverisateurCourant As Pulverisateur
    ' Diagnostic courant
    Public diagnosticCourant As Diagnostic
    Public arrBusesUsed() As String
    '    Public arrManoUsed(2) As Object
    'DiagnosticInitial = ControleComplet

#End Region

#Region "Formulaires en SESSION"
    ' Form parent
    Public globFormParent As parentContener
    ' Form principal "Accueil"
    Public globFormAccueil As accueil
    ' Diagnostic - Contrôle préliminaire
    Public globFormControlePreliminaire As controle_preliminaire
    ' Diagnostic - Contrôle préliminaire
    Public globFormDiagnostic As frmDiagnostique
    Public globFormToolBuses As tool_diagBuses
    ' Flag de connexion
    Public globConnectFlagOk As Object
    Public globConnectFlagNok As Object
    ' Gestion des manomètres
    'Public globFormGestionMano As gestion_manometres
    ' Gestion des buses
    'Public globFormGestionBusesEtalons As gestion_busesEtalons
#End Region

    Public Sub Main()
        ' Bancs
        Globals.GLOB_XML_MARQUES_BANC = New CSXml("." & "\config\bancs\marques.xml")
        ' Buses
        Globals.GLOB_XML_MARQUES_BUSES = New CSXml("." & "\config\buses\marques.xml")
        Globals.GLOB_XML_MODELES_BUSES = New CSXml("." & "\config\buses\modeles.xml")
        Globals.GLOB_XML_GENRES_BUSES = New CSXml("." & "\config\buses\genres.xml")
        Globals.GLOB_XML_COULEURS_BUSES = New CSXml("." & "\config\buses\couleurs.xml")
        Globals.GLOB_XML_TYPES_BUSES = New CSXml("." & "\config\buses\types.xml")
        Globals.GLOB_XML_ANGLES_BUSES = New CSXml("." & "\config\buses\angles.xml")
        Globals.GLOB_XML_REFER_BUSES = New CSXml("." & "\config\buses\buses.xml")
        Globals.GLOB_XML_FONCTIONNEMENTBUSES_BUSES = New CSXml("." & "\config\buses\fonctionnement.xml")

        ' Manometres
        Globals.GLOB_XML_MARQUES_MANO = New CSXml("." & "\config\manometres\marques.xml")
        Globals.GLOB_XML_MODELES_MANO = New CSXml("." & "\config\manometres\modeles.xml")
        Globals.GLOB_XML_CLASSES_MANO = New CSXml("." & "\config\manometres\classes.xml")
        Globals.GLOB_XML_FONDECHELLE_MANO = New CSXml("." & "\config\manometres\fondEchelle.xml")

        ' Manometres de contrôle
        Globals.GLOB_XML_MARQUES_MANOCONT = New CSXml("." & "\config\manometres-controle\marques.xml")
        Globals.GLOB_XML_MODELES_MANOCONT = New CSXml("." & "\config\manometres-controle\modeles.xml")
        Globals.GLOB_XML_CLASSES_MANOCONT = New CSXml("." & "\config\manometres-controle\classes.xml")
        Globals.GLOB_XML_FONDECHELLE_MANOCONT = New CSXml("." & "\config\manometres-controle\fondEchelle.xml")
        ' Manometres étalon
        Globals.GLOB_XML_MARQUES_MANOETA = New CSXml("." & "\config\manometres-etalon\marques.xml")
        Globals.GLOB_XML_MODELES_MANOETA = New CSXml("." & "\config\manometres-etalon\modeles.xml")
        Globals.GLOB_XML_CLASSES_MANOETA = New CSXml("." & "\config\manometres-etalon\classes.xml")
        Globals.GLOB_XML_FONDECHELLE_MANOETA = New CSXml("." & "\config\manometres-etalon\fondEchelle.xml")

        ' Pulvérisateurs
        Globals.GLOB_XML_MARQUES_MODELES_PULVE = New CSXml(My.Settings.RepertoireParametres & "\ReferentielPulverisateurMarquesModeles.xml")
        Globals.GLOB_XML_TYPES_CATEGORIES_PULVE = New CSXml(My.Settings.RepertoireParametres & "\ReferentielPulverisateurTypesCategories.xml")
        Globals.GLOB_XML_ATTELAGE_PULVE = New CSXml(My.Settings.RepertoireParametres & "\Attelage.xml")
        Globals.GLOB_XML_PULVERISATION_PULVE = New CSXml(My.Settings.RepertoireParametres & "\Pulverisation.xml")
        Globals.GLOB_XML_REGULATION_PULVE = New CSXml("." & "\" & My.Settings.RepertoireParametres & "\PulverisateurRegulation.xml")
        Globals.GLOB_XML_EMPLACEMENTIDENTIFICATION = New CSXml(My.Settings.RepertoireParametres & "\EmplacementIdentification.xml")
        Globals.GLOB_XML_MODEUTILISATION = New CSXml(My.Settings.RepertoireParametres & "\PulverisateurModeUtilisation.xml")


        ' Territoires
        Globals.GLOB_XML_TERRITOIRES = New CSXml("." & "\config\territoire.xml")
        Globals.GLOB_XML_CODESAPE = New CSXml(My.Settings.RepertoireParametres & "\ReferentielCodesAPE.xml")

        Globals.Init()
        If TestCrystalReport() Then
            Dim ofrm As Form
#If REGLAGEPULVE Then
        Dim args As String()
        args = Environment.GetCommandLineArgs()
        If args.Length = 3 Then
            'Arg0 = Nom de l'executable
            'Arg1 = Numero de controle
            'Arg3 = Id Agent
            '            System.IO.File.WriteAllText("ReglagePulve.log", "reglahePulve.exe[" & args(1) & " " & args(2) & "]")
            CSDebug.dispInfo("Démarage ReglagePulve(" & args(1) & " " & args(2) & ")")
            ofrm = New frmRPparentContener(args(1), args(2))
        Else
            ofrm = New frmRPparentContener()

        End If
#Else

            ofrm = New parentContener()
#End If
            ofrm.ShowDialog()
        Else
            CSDebug.dispFatal("Erreur en Génération de PDF, Vérifier Crystal Report")
        End If
    End Sub

    Public Function TestCrystalReport() As Boolean
        Globals.Init()
        Dim ocr As New crTest()
        Dim bReturn As Boolean
        Dim m_reportName As String
        Dim m_FileName As String
        Dim ods As dsTest


        Try
            m_reportName = My.Settings.RepertoireParametres & "/" & ocr.ResourceName
            ocr.Dispose()

            ods = New dsTest()
            ods.dtTest.AdddtTestRow(Date.Now.ToLongDateString())

            If System.IO.File.Exists("./test.pdf") Then
                System.IO.File.Delete("./test.pdf")
            End If
            If System.IO.File.Exists(m_reportName) Then


                Using objReport As crTest = New crTest()
                    CSDebug.dispInfo("StartApplication.TestCrystalReport Load")
                    objReport.Load(m_reportName)
                    CSDebug.dispInfo("StartApplication.TestCrystalReport SetDataSource")
                    objReport.SetDataSource(ods)

                    CSDebug.dispInfo("StartApplication.TestCrystalReport Params")
                    Dim CrExportOptions As ExportOptions
                    Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions
                    Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions
                    CrDiskFileDestinationOptions.DiskFileName = "./test.pdf"
                    CrExportOptions = objReport.ExportOptions
                    With CrExportOptions
                        .ExportDestinationType = ExportDestinationType.DiskFile
                        .ExportFormatType = ExportFormatType.PortableDocFormat
                        .DestinationOptions = CrDiskFileDestinationOptions
                        .FormatOptions = CrFormatTypeOptions
                    End With
                    CSDebug.dispInfo("StartApplication.TestCrystalReport Export")
                    objReport.Export()

                End Using
            Else

            End If
            ods.Dispose()
            bReturn = System.IO.File.Exists("./test.pdf")

        Catch ex As Exception
            CSDebug.dispError("StartApplication.TestCrystalReport ERR" & ex.Message)
            If ex.InnerException IsNot Nothing Then
                CSDebug.dispError("StartApplication.TestCrystalReport ERR" & ex.InnerException.Message)
                If ex.InnerException.InnerException IsNot Nothing Then
                    CSDebug.dispError("StartApplication.TestCrystalReport ERR" & ex.InnerException.InnerException.Message)

                End If

            End If
            bReturn = False
        End Try
        Return bReturn
    End Function

End Module
