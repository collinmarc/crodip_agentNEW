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
        CSDebug.dispInfo("StartApplication.Main")
        CSDebug.dispInfo("StartApplication.TestCrystalReport")

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
            CSDebug.dispInfo("StartApplication.Show ParenbtContainer")
            ofrm.ShowDialog()
        Else
            CSDebug.dispFatal("Erreur en Génération de PDF, Vérifier Crystal Report")
        End If
    End Sub

    Public Function TestCrystalReport() As Boolean
        Dim ocr As New crTest
        Dim bReturn As Boolean
        Dim m_reportName As String
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


                Using objReport As ReportDocument = New ReportDocument()
                    objReport.Load(m_reportName)
                    objReport.SetDataSource(ods)

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
                    objReport.Export()

                End Using
            Else
                CSDebug.dispError("StartApplication.TestCrystalReport Modele" & m_reportName & " introuvable")

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
