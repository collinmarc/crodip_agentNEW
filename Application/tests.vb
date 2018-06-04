'Imports CrystalDecisions.CrystalReports.Engine
'Imports CrystalDecisions.Shared

Public Class tests
    Inherits System.Windows.Forms.Form

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()

    End Sub

    'La méthode substituée Dispose du formulaire pour nettoyer la liste des composants.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requis par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée en utilisant le Concepteur Windows Form.  
    'Ne la modifiez pas en utilisant l'éditeur de code.
    '    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents BtnOk As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        'Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.BtnOk = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'CrystalReportViewer1
        '
        'Me.CrystalReportViewer1.ActiveViewIndex = -1
        'Me.CrystalReportViewer1.DisplayGroupTree = False
        'Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        'Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 0)
        'Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        'Me.CrystalReportViewer1.ReportSource = Nothing
        'Me.CrystalReportViewer1.ShowCloseButton = False
        'Me.CrystalReportViewer1.ShowGotoPageButton = False
        'Me.CrystalReportViewer1.ShowGroupTreeButton = False
        'Me.CrystalReportViewer1.ShowPageNavigateButtons = False
        'Me.CrystalReportViewer1.ShowTextSearchButton = False
        'Me.CrystalReportViewer1.ShowZoomButton = False
        'Me.CrystalReportViewer1.Size = New System.Drawing.Size(832, 610)
        'Me.CrystalReportViewer1.TabIndex = 30
        '
        'BtnOk
        '
        Me.BtnOk.Location = New System.Drawing.Point(688, 0)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(136, 23)
        Me.BtnOk.TabIndex = 32
        Me.BtnOk.Text = "Génération graphique"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(544, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(136, 23)
        Me.Button1.TabIndex = 33
        Me.Button1.Text = "Chargement des buses"
        '
        'tests
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(832, 610)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.BtnOk)
        'Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Name = "tests"
        Me.Text = "tests"
        Me.ResumeLayout(False)

    End Sub

#End Region

    '    Dim MonEtat As cr_debitBuses_dev 'état crystal report

    Dim cn As OleDb.OleDbConnection
    Dim cmd As OleDb.OleDbCommand
    Dim myAdapter As OleDb.OleDbDataAdapter
    Dim rd As OleDb.OleDbDataReader
    Dim paramCmd As OleDb.OleDbParameter
    Dim DataMesProduits As ds_Etat_SM  'dataset que consommera l'état

    Private Sub tests_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'On remplis la liste déroulante
        cn = New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;" & _
        "User ID=Admin;Data Source=C:\Documents and Settings\morin_r\Mes documents\Visual Studio Projects\Crodip-Agent\trunk\bin\bdd\crodip_etats_dev.mdb")
        'cmd = New OleDb.OleDbCommand
        'cmd.Connection = cn
        'cmd.CommandText = "SELECT * FROM debitBuses"
        'cn.Open()
        'Try
        '    rd = cmd.ExecuteReader
        '    While rd.Read
        '        Me.DdlCategorie.Items.Add(rd.GetString(0))
        '    End While
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
        'cn.Close()
        'Me.DdlCategorie.SelectedIndex = 0


    End Sub

    'Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click

    '    'on récupère les données
    '    Me.DataMesProduits = New ds_etat_dev
    '    Me.myAdapter = New OleDb.OleDbDataAdapter("SELECT * FROM debitBuses ORDER BY debitBuses.numBuse", cn)
    '    myAdapter.Fill(DataMesProduits.debitBuses) 'Exception ici

    '    'On passe les données du dataset dans le report
    '    Me.MonEtat = New cr_debitBuses_dev
    '    Me.MonEtat.SetDataSource(Me.DataMesProduits)
    '    CrystalReportViewer1.ReportSource = Me.MonEtat
    '    CrystalReportViewer1.Refresh()
    '    Try
    '        Dim CrExportOptions As ExportOptions
    '        Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions
    '        Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions
    '        CrDiskFileDestinationOptions.DiskFileName = Globals.CONST_PATH_EXP & CSDiagPdf.makeFilename("2-1-1", "CR") & ".pdf"
    '        CrExportOptions = MonEtat.ExportOptions
    '        With CrExportOptions
    '            .ExportDestinationType = ExportDestinationType.DiskFile
    '            .ExportFormatType = ExportFormatType.PortableDocFormat
    '            .DestinationOptions = CrDiskFileDestinationOptions
    '            .FormatOptions = CrFormatTypeOptions
    '        End With
    '        MonEtat.Export()
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try
    '    Me.DataMesProduits.Clear()
    '    Me.DataMesProduits.Dispose()
    'End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim randObj As Random = New Random

        For buseId As Integer = 1 To 20

            ' Rand value
            Dim randVal As String

            ' On ajoute la buse a la table d'échange
            Dim oCSDB As New CSDb(True, DBTYPE.ETAT)
            Dim cmd As OleDb.OleDbCommand = oCSDB.getConnection().CreateCommand()
            Try
                cmd.CommandText = "INSERT INTO debitBuses (numBuse , ecartPourcentage) VALUES (" & buseId & ", " & CStr(randObj.Next(0, 15) + randObj.NextDouble()).Replace(",", ".") & ")"
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            oCSDB.free()

        Next

    End Sub
End Class
