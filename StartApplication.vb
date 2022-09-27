Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Windows.Forms
Imports System.IO.Compression
Imports Ionic.Zip

Module StartApplication
#Region "Variables de SESSION"
    ' StatusBar
    Public Statusbar As CSStatusbar
    ' Agent courant logguer
    Public agentCourant As Agent
    ' Agent courant logguer
    'Public BancCourant As Banc = Nothing 'Banc du Pool

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
    ' Diagnostic - Contrôle préliminaire
    Public globFormControlePreliminaire As controle_preliminaire
    Public globFormAccueil As accueil
    ' Diagnostic - Contrôle préliminaire
    Public globFormDiagnostic As FrmDiagnostique
    Public globFormToolBuses As tool_diagBuses
    ' Flag de connexion
    Public globConnectFlagOk As Object
    Public globConnectFlagNok As Object
    ' Gestion des manomètres
    'Public globFormGestionMano As gestion_manometres
    ' Gestion des buses
    'Public globFormGestionBusesEtalons As gestion_busesEtalons
#End Region
    Private splashScreen As splash

    Public Sub Main()
        'Application.UseWaitCursor = True

        CSDebug.dispInfo("StartApplication.Main")
        ''        CSDebug.dispInfo("StartApplication.TestCrystalReport")
        '        If TestCrystalReport() Then

        Dim ofrm As Form
        Dim bLoginFailed As Boolean = True

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
            bLoginFailed = false
#Else
        If Not System.IO.File.Exists(GlobalsCRODIP.GLOB_STR_FACTURATIONCONFIG_FILENAME) Then
            FacturationConfig.WriteXml()
        End If

        If GlobalsCRODIP.GLOB_ENV_MODESIMPLIFIE Or GlobalsCRODIP.GLOB_ENV_MODEFORMATION Then

            'Test de la validité 
            ParamReglagePulve.XMLFileName = "zsxedc.crodip"
            Dim objParamRP As ParamReglagePulve = ParamReglagePulve.ReadXML(".")
            If objParamRP.coluser.Count = 1 Then
                Dim objRPUser As RPUser = objParamRP.coluser(0)
                If objRPUser.TestDateExp(Now) Then
                    bLoginFailed = False
                End If
            End If
            If bLoginFailed Then
                MsgBox(GlobalsCRODIP.CONST_STATUTMSG_LOGIN_FAILED & " : Votre version simplifiée a expirée , contactez le CRODIP")
                Application.Exit()
            End If
        Else
            bLoginFailed = False
        End If

        ofrm = New parentContener()
#End If
        If File.Exists("./TransfertBDD") Then
            Dim oFrmBDD As New FrmMigrationBDD()
            If oFrmBDD.ShowDialog() = DialogResult.OK Then
                '                File.Delete("./TransfertBDD")
                ' Le fichier sera détruit dans la page d'accueil
            End If
        End If

        CSDebug.dispInfo("StartApplication.Show ParentContainer")
        If Not bLoginFailed Then
            ofrm.ShowDialog()
        End If
        ''        Else
        ''       MsgBox("Erreur en Génération de PDF, Vérifier votre version de Crystal Report")
        ''     End If
    End Sub

    Public Function TestCrystalReport() As Boolean
        Dim ocr As New crTest
        Dim bReturn As Boolean
        Dim m_reportName As String
        Dim ods As dsTest

        CSDebug.dispInfo("StartApplication.TestCrystalReport")

        Try
            If System.IO.File.Exists("./test.pdf") Then
                System.IO.File.Delete("./test.pdf")
            End If

            m_reportName = My.Settings.RepertoireParametres & "/" & ocr.ResourceName
            ocr.Dispose()

            ods = New dsTest()
            ods.dtTest.AdddtTestRow(Date.Now.ToLongDateString())

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

    Public Sub ExecuteCMD()
        If System.IO.File.Exists("cmd.txt") Then
            Dim ocmd As New Cmd
            ocmd.execute("cmd.txt")
            If System.IO.File.Exists("Cmd.txt.old") Then
                System.IO.File.Delete("cmd.txt.old")
            End If
            System.IO.File.Move("cmd.txt", "cmd.txt.old")
        End If

    End Sub

    Public Sub loadSplash()
        splashScreen = New splash
        splashScreen.Show()
    End Sub
    Public Sub unloadSplash()
        splashScreen.Close()
    End Sub

End Module
