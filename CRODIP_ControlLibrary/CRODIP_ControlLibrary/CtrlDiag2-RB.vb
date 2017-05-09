Friend Class CtrlDiag2_RB
    Private m_NiveauCause As CRODIP_NIVEAUCAUSEMAX = CRODIP_NIVEAUCAUSEMAX.ZERO
    Private m_bCause1 As Boolean
    Private m_bCause2 As Boolean
    Private m_bCause3 As Boolean
    'Private m_rb0Loc As System.Drawing.Point
    'Private m_rb1Loc As System.Drawing.Point
    'Private m_rb2Loc As System.Drawing.Point
    'Private m_rb3Loc As System.Drawing.Point
    Public Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        'm_rb0Loc = rb0.Location
        'm_rb1Loc = rb1.Location
        'm_rb2Loc = rb2.Location
        'm_rb3Loc = rb3.Location
    End Sub

    Public Property bCause1 As Boolean
        Get
            Return m_bCause1
        End Get
        Set(ByVal value As Boolean)
            m_bCause1 = value
            setrb()
        End Set
    End Property
    Public Property bCause2 As Boolean
        Get
            Return m_bCause2
        End Get
        Set(ByVal value As Boolean)
            m_bCause2 = value
            setrb()
        End Set
    End Property
    Public Property bCause3 As Boolean
        Get
            Return m_bCause3
        End Get
        Set(ByVal value As Boolean)
            m_bCause3 = value
            setrb()
        End Set
    End Property
    Private Sub setrb()
        rb0.Visible = m_bCause1 Or m_bCause2 Or m_bCause3
        rb0.Enabled = m_bCause1 Or m_bCause2 Or m_bCause3
        rb1.Visible = m_bCause1
        rb1.Enabled = m_bCause1
        rb2.Visible = m_bCause2
        rb2.Enabled = m_bCause2
        rb3.Visible = m_bCause3
        rb3.Enabled = m_bCause3
        Me.Location = New Drawing.Point(51, 0)

    End Sub

    Public Property Defaut_niveauCause As String
        Get
            Return m_NiveauCause
        End Get
        Set(ByVal value As String)
            m_NiveauCause = value
            Select Case m_NiveauCause
                Case CRODIP_NIVEAUCAUSEMAX.ZERO
                    rb0.Visible = False
                    rb0.Enabled = False
                    rb1.Visible = False
                    rb1.Enabled = False
                    rb2.Visible = False
                    rb2.Enabled = False
                    rb3.Visible = False
                    rb3.Enabled = False
                    Me.Location = New Drawing.Point(51, 0)
                Case CRODIP_NIVEAUCAUSEMAX.UN
                    rb0.Visible = True
                    rb0.Enabled = True
                    rb1.Visible = True
                    rb1.Enabled = True
                    rb2.Visible = False
                    rb2.Enabled = False
                    rb3.Visible = False
                    rb3.Enabled = False
                    '                    rb0.Location = m_rb2Loc
                    '                   rb1.Location = m_rb3Loc
                    Me.Width = rb0.Width + rb1.Width
                    Me.Location = New Drawing.Point(51 + rb0.Width + rb1.Width, Me.Location.Y)
                Case CRODIP_NIVEAUCAUSEMAX.DEUX
                    rb0.Visible = True
                    rb0.Enabled = True
                    rb1.Visible = True
                    rb1.Enabled = True
                    rb2.Visible = True
                    rb2.Enabled = True
                    rb3.Visible = False
                    rb3.Enabled = False
                    'rb0.Location = m_rb1Loc
                    'rb1.Location = m_rb2Loc
                    'rb2.Location = m_rb3Loc
                    Me.Width = rb0.Width + rb1.Width + rb2.Width
                    Me.Location = New Drawing.Point(51 + rb0.Width, Me.Location.Y)

                Case CRODIP_NIVEAUCAUSEMAX.TROIS
                    rb0.Visible = True
                    rb0.Enabled = True
                    rb1.Visible = True
                    rb1.Enabled = True
                    rb2.Visible = True
                    rb2.Enabled = True
                    rb3.Visible = True
                    rb3.Enabled = True
                    'rb0.Location = m_rb0Loc
                    'rb1.Location = m_rb1Loc
                    'rb2.Location = m_rb2Loc
                    'rb3.Location = m_rb3Loc
                    Me.Width = rb0.Width + rb1.Width + rb2.Width + rb3.Width
                    Me.Location = New Drawing.Point(51, Me.Location.Y)
            End Select
        End Set
    End Property

    Public Property value As CRODIP_NIVEAUCAUSEMAX
        Get
            Dim sValue As CRODIP_NIVEAUCAUSEMAX
            sValue = CRODIP_NIVEAUCAUSEMAX.ZERO
            If rb0.Checked Then
                sValue = CRODIP_NIVEAUCAUSEMAX.ZERO
            End If
            If rb1.Checked Then
                sValue = CRODIP_NIVEAUCAUSEMAX.UN
            End If
            If rb2.Checked Then
                sValue = CRODIP_NIVEAUCAUSEMAX.DEUX
            End If
            If rb3.Checked Then
                sValue = CRODIP_NIVEAUCAUSEMAX.TROIS
            End If
            Return sValue
        End Get
        Set(ByVal value As CRODIP_NIVEAUCAUSEMAX)
            rb0.Checked = False
            rb1.Checked = False
            rb2.Checked = False
            rb3.Checked = False
            If value = CRODIP_NIVEAUCAUSEMAX.ZERO Then
                rb0.Checked = True
            End If
            If value = CRODIP_NIVEAUCAUSEMAX.UN Then
                rb1.Checked = True
            End If
            If value = CRODIP_NIVEAUCAUSEMAX.DEUX Then
                rb2.Checked = True
            End If
            If value = CRODIP_NIVEAUCAUSEMAX.TROIS Then
                rb3.Checked = True
            End If


        End Set
    End Property

    Public Event valuechanged(ByVal sender As System.Object, ByVal e As EventArgs)
    'Private Sub rb0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb0.CheckedChanged
    '    Me.Visible = False
    '    Me.SendToBack()
    '    If rb0.Checked Then
    '        RaiseEvent valuechanged(Me, e)
    '    End If
    'End Sub

    'Private Sub rb1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb1.CheckedChanged
    '    Me.Visible = False
    '    Me.SendToBack()
    '    If rb1.Checked Then
    '        RaiseEvent valuechanged(Me, e)
    '    End If
    'End Sub

    'Private Sub rb2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb2.CheckedChanged
    '    Me.Visible = False
    '    Me.SendToBack()
    '    If rb2.Checked Then
    '        RaiseEvent valuechanged(Me, e)
    '    End If
    'End Sub


    'Private Sub rb3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb3.CheckedChanged
    '    Me.Visible = False
    '    Me.SendToBack()
    '    If rb3.Checked Then
    '        RaiseEvent valuechanged(Me, e)
    '    End If
    'End Sub

    Private Sub rb0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb0.Click
        Me.Visible = False
        Me.SendToBack()
        RaiseEvent valuechanged(Me, e)
    End Sub

    Private Sub rb1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb1.Click
        Me.Visible = False
        Me.SendToBack()
        RaiseEvent valuechanged(Me, e)

    End Sub

    Private Sub rb2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rb2.Click
        Me.Visible = False
        Me.SendToBack()
        RaiseEvent valuechanged(Me, e)

    End Sub

    Private Sub rb3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb3.Click
        Me.Visible = False
        Me.SendToBack()
        RaiseEvent valuechanged(Me, e)
    End Sub

    Private Sub aaa(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PopupEventArgs) Handles ToolTip1.Popup

    End Sub
End Class
