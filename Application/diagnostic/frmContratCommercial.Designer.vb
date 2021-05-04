<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmContratCommercial
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmContratCommercial))
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.btnSignAgent = New System.Windows.Forms.Label()
        Me.btnSignClient = New System.Windows.Forms.Label()
        Me.btn_Quitter = New System.Windows.Forms.Label()
        Me.m_bsrcAgent = New System.Windows.Forms.BindingSource(Me.components)
        Me.m_bsrcDiag = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.m_bsrcAgent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_bsrcDiag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.DisplayStatusBar = False
        Me.CrystalReportViewer1.DisplayToolbar = False
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(13, 12)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.ShowCloseButton = False
        Me.CrystalReportViewer1.ShowCopyButton = False
        Me.CrystalReportViewer1.ShowExportButton = False
        Me.CrystalReportViewer1.ShowGotoPageButton = False
        Me.CrystalReportViewer1.ShowGroupTreeButton = False
        Me.CrystalReportViewer1.ShowLogo = False
        Me.CrystalReportViewer1.ShowPageNavigateButtons = False
        Me.CrystalReportViewer1.ShowParameterPanelButton = False
        Me.CrystalReportViewer1.ShowTextSearchButton = False
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(585, 426)
        Me.CrystalReportViewer1.TabIndex = 0
        Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'btnSignAgent
        '
        Me.btnSignAgent.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSignAgent.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSignAgent.DataBindings.Add(New System.Windows.Forms.Binding("Visible", Me.m_bsrcAgent, "isSignElecActive", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.btnSignAgent.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSignAgent.ForeColor = System.Drawing.Color.White
        Me.btnSignAgent.Image = Global.Crodip_agent.Resources.btn_Signture
        Me.btnSignAgent.Location = New System.Drawing.Point(650, 302)
        Me.btnSignAgent.Name = "btnSignAgent"
        Me.btnSignAgent.Size = New System.Drawing.Size(144, 24)
        Me.btnSignAgent.TabIndex = 49
        Me.btnSignAgent.Text = "      Signature inspecteur"
        Me.btnSignAgent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnSignClient
        '
        Me.btnSignClient.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSignClient.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSignClient.DataBindings.Add(New System.Windows.Forms.Binding("Visible", Me.m_bsrcAgent, "isSignElecActive", True))
        Me.btnSignClient.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSignClient.ForeColor = System.Drawing.Color.White
        Me.btnSignClient.Image = Global.Crodip_agent.Resources.btn_Signture
        Me.btnSignClient.Location = New System.Drawing.Point(653, 339)
        Me.btnSignClient.Name = "btnSignClient"
        Me.btnSignClient.Size = New System.Drawing.Size(141, 24)
        Me.btnSignClient.TabIndex = 48
        Me.btnSignClient.Text = "      Signature client"
        Me.btnSignClient.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_Quitter
        '
        Me.btn_Quitter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Quitter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Quitter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Quitter.ForeColor = System.Drawing.Color.White
        Me.btn_Quitter.Image = CType(resources.GetObject("btn_Quitter.Image"), System.Drawing.Image)
        Me.btn_Quitter.Location = New System.Drawing.Point(666, 414)
        Me.btn_Quitter.Name = "btn_Quitter"
        Me.btn_Quitter.Size = New System.Drawing.Size(128, 24)
        Me.btn_Quitter.TabIndex = 52
        Me.btn_Quitter.Text = "    Retour"
        Me.btn_Quitter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'm_bsrcAgent
        '
        Me.m_bsrcAgent.DataSource = GetType(Crodip_agent.Agent)
        '
        'm_bsrcDiag
        '
        Me.m_bsrcDiag.DataSource = GetType(Crodip_agent.Diagnostic)
        '
        'frmContratCommercial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btn_Quitter)
        Me.Controls.Add(Me.btnSignAgent)
        Me.Controls.Add(Me.btnSignClient)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Name = "frmContratCommercial"
        Me.Text = "Contrat Commercial"
        CType(Me.m_bsrcAgent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_bsrcDiag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents btnSignAgent As Label
    Friend WithEvents btnSignClient As Label
    Friend WithEvents btn_Quitter As Label
    Friend WithEvents m_bsrcDiag As BindingSource
    Friend WithEvents m_bsrcAgent As BindingSource
End Class
