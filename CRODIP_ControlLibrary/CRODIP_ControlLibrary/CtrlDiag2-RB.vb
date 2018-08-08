Friend Class CtrlDiag2_RB
    Private m_NombreCauses As CRODIP_NIVEAUCAUSE = CRODIP_NIVEAUCAUSE.ZERO
    Private m_bCause1 As Boolean
    Private m_bCause2 As Boolean
    Private m_bCause3 As Boolean
    Private m_rb0Loc As System.Drawing.Point
    Private m_rb1Loc As System.Drawing.Point
    Private m_rb2Loc As System.Drawing.Point
    Private m_rb3Loc As System.Drawing.Point
    Public Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        m_rb0Loc = rb0.Location
        m_rb1Loc = rb1.Location
        m_rb2Loc = rb2.Location
        m_rb3Loc = rb3.Location
    End Sub

    Public Property bCause1 As Boolean
        Get
            Return m_bCause1
        End Get
        Set(ByVal value As Boolean)
            m_bCause1 = value

        End Set
    End Property
    Public Property bCause2 As Boolean
        Get
            Return m_bCause2
        End Get
        Set(ByVal value As Boolean)
            m_bCause2 = value

        End Set
    End Property
    Public Property bCause3 As Boolean
        Get
            Return m_bCause3
        End Get
        Set(ByVal value As Boolean)
            m_bCause3 = value

        End Set
    End Property

    Public Property NombreCauses As Integer
        Get
            Return m_NombreCauses
        End Get
        Set(ByVal value As Integer)
            m_NombreCauses = value
            Select Case m_NombreCauses
                Case 0
                    rb0.Visible = False
                    rb0.Enabled = False
                    rb1.Visible = False
                    rb1.Enabled = False
                    rb2.Visible = False
                    rb2.Enabled = False
                    rb3.Visible = False
                    rb3.Enabled = False
                    Me.Location = New Drawing.Point(51, 0)
                Case 1
                    rb0.Visible = True
                    rb0.Enabled = True
                    rb1.Visible = m_bCause1
                    rb1.Enabled = m_bCause1
                    rb2.Visible = m_bCause2
                    rb2.Enabled = m_bCause2
                    rb3.Visible = m_bCause3
                    rb3.Enabled = m_bCause3
                    'Il y a un niveau de cause 
                    'Lequel ?
                    If m_bCause1 Then
                        rb1.Location = m_rb1Loc
                    End If
                    If m_bCause2 Then
                        rb2.Location = m_rb1Loc
                    End If
                    If m_bCause3 Then
                        rb3.Location = m_rb1Loc
                    End If
                    Me.Width = rb0.Width + rb1.Width
                    Me.Location = New Drawing.Point(51 + rb0.Width + rb1.Width, Me.Location.Y)
                Case 2
                    rb0.Visible = True
                    rb0.Enabled = True
                    rb1.Visible = m_bCause1
                    rb1.Enabled = m_bCause1
                    rb2.Visible = m_bCause2
                    rb2.Enabled = m_bCause2
                    rb3.Visible = m_bCause3
                    rb3.Enabled = m_bCause3
                    'Il y a deux niveaux de cause  
                    'Lesquels ?
                    If Not m_bCause1 Then
                        rb2.Location = m_rb1Loc
                        rb3.Location = m_rb2Loc
                    End If
                    If Not m_bCause2 Then
                        rb1.Location = m_rb1Loc
                        rb3.Location = m_rb2Loc
                    End If
                    If Not m_bCause3 Then
                        rb1.Location = m_rb1Loc
                        rb2.Location = m_rb2Loc
                    End If
                    Me.Width = rb0.Width + rb1.Width + rb2.Width
                    Me.Location = New Drawing.Point(51 + rb0.Width, Me.Location.Y)

                Case 3
                    rb0.Visible = True
                    rb0.Enabled = True
                    rb1.Visible = m_bCause1
                    rb1.Enabled = m_bCause1
                    rb2.Visible = m_bCause2
                    rb2.Enabled = m_bCause2
                    rb3.Visible = m_bCause3
                    rb3.Enabled = m_bCause3
                    rb0.Location = m_rb0Loc
                    rb1.Location = m_rb1Loc
                    rb2.Location = m_rb2Loc
                    rb3.Location = m_rb3Loc
                    'Il y a 3 niveaux de cause
                    'Donc les RB restent dans leurs positions
                    Me.Width = rb0.Width + rb1.Width + rb2.Width + rb3.Width
                    Me.Location = New Drawing.Point(51, Me.Location.Y)
            End Select
        End Set
    End Property

    Public Property value As CRODIP_NIVEAUCAUSE
        Get
            Dim sValue As CRODIP_NIVEAUCAUSE
            sValue = CRODIP_NIVEAUCAUSE.ZERO
            If rb0.Checked Then
                sValue = CRODIP_NIVEAUCAUSE.ZERO
            End If
            If rb1.Checked Then
                sValue = CRODIP_NIVEAUCAUSE.UN
            End If
            If rb2.Checked Then
                sValue = CRODIP_NIVEAUCAUSE.DEUX
            End If
            If rb3.Checked Then
                sValue = CRODIP_NIVEAUCAUSE.TROIS
            End If
            Return sValue
        End Get
        Set(ByVal value As CRODIP_NIVEAUCAUSE)
            rb0.Checked = False
            rb1.Checked = False
            rb2.Checked = False
            rb3.Checked = False
            If value = CRODIP_NIVEAUCAUSE.ZERO Then
                rb0.Checked = True
            End If
            If value = CRODIP_NIVEAUCAUSE.UN Then
                rb1.Checked = True
            End If
            If value = CRODIP_NIVEAUCAUSE.DEUX Then
                rb2.Checked = True
            End If
            If value = CRODIP_NIVEAUCAUSE.TROIS Then
                rb3.Checked = True
            End If


        End Set
    End Property

    Public Event valuechanged(ByVal sender As System.Object, ByVal e As EventArgs)

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
