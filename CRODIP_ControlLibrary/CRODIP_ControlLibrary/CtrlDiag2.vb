Public Enum CRODIP_CATEGORIEDEFAUT
    DEFAUT_GROUPE = 99
    DEFAUT_ABSENCE = 4
    DEFAUT_MAJEURPRELIM = 3
    DEFAUT_MAJEUR = 2
    DEFAUT_MINEUR = 1
    DEFAUT_OK = 0
    DEFAUT_NONE = -1
End Enum
Public Enum CRODIP_NIVEAUCAUSEMAX
    NONE = -1
    ZERO = 0
    UN = 1
    DEUX = 2
    TROIS = 3
End Enum

<System.ComponentModel.DefaultEvent("CheckedChanged")>
Public Class CtrlDiag2
    Public Shared ITEMCOLORABSENCE As Color = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
    Public Shared ITEMCOLORMAJEURPRELIM As Color = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(23, Byte), Integer))
    Public Shared ITEMCOLORMAJEUR As Color = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(23, Byte), Integer))
    Public Shared ITEMCOLORMINEUR As Color = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(15, Byte), Integer))
    Public Shared ITEMCOLOROK As Color = System.Drawing.Color.Black

    Private m_Categorie As CRODIP_CATEGORIEDEFAUT
    Private m_DefaultCategorie As CRODIP_CATEGORIEDEFAUT
    Private m_Libelle As String
    Private m_LibelleLong As String
    Private m_Code As String
    Private m_NiveauCauseMax As CRODIP_NIVEAUCAUSEMAX
    Private m_bCause1 As Boolean
    Private m_bCause2 As Boolean
    Private m_bCause3 As Boolean

    Public Shadows Event Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Public Shadows Event CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Public Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        m_NiveauCauseMax = CRODIP_NIVEAUCAUSEMAX.ZERO
        Categorie = CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        DefaultCategorie = CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
    End Sub
    Public Property Checked As Boolean
        Get
            Return CheckBox1.Checked
        End Get
        Set(ByVal value As Boolean)
            CheckBox1.Checked = value
        End Set
    End Property
    Public Property CheckAlign As System.Drawing.ContentAlignment
        Get
            Return CheckBox1.CheckAlign
        End Get
        Set(ByVal value As System.Drawing.ContentAlignment)
            CheckBox1.CheckAlign = value
        End Set
    End Property
    Public Property ImageAlign As System.Drawing.ContentAlignment
        Get
            Return CheckBox1.ImageAlign
        End Get
        Set(ByVal value As System.Drawing.ContentAlignment)
            CheckBox1.ImageAlign = value
        End Set
    End Property
    ''' <summary>
    ''' couleur du libellé (Déterminé par CATEGORIE)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ForeColor As System.Drawing.Color
        Get
            Return CheckBox1.ForeColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            If value = CtrlDiag2.ITEMCOLORMAJEUR Then
                Me.DefaultCategorie = CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
            ElseIf value = CtrlDiag2.ITEMCOLORMINEUR Then
                Me.DefaultCategorie = CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
            ElseIf value = CtrlDiag2.ITEMCOLOROK Then
                Me.DefaultCategorie = CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
            Else
                CheckBox1.ForeColor = value
            End If
        End Set
    End Property
    ''' <summary>
    ''' Libellé du défaut
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Property Text As String
        Get
            Return m_Libelle
        End Get
        Set(ByVal value As String)
            m_Libelle = value
            CheckBox1.Text = m_Code & " " & m_Libelle
        End Set
    End Property
    ''' <summary>
    ''' Libellé du défaut
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Libelle As String
        Get
            Return m_Libelle
        End Get
        Set(ByVal value As String)
            m_Libelle = value
            If Categorie = CRODIP_CATEGORIEDEFAUT.DEFAUT_OK Then
                CheckBox1.Text = m_Libelle
            Else
                If Not String.IsNullOrEmpty(m_Code) Then
                    CheckBox1.Text = m_Code & " - " & m_Libelle
                Else
                    CheckBox1.Text = m_Libelle
                End If
            End If

        End Set
    End Property
    ''' <summary>
    ''' Libellé Long du défaut
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>pas utilisé pour l'instant dans l'interface</remarks>
    Public Property LibelleLong As String
        Get
            Return m_LibelleLong
        End Get
        Set(ByVal value As String)
            m_LibelleLong = value

        End Set
    End Property
    ''' <summary>
    ''' Code du defaut
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Code As String
        Get
            Return m_Code
        End Get
        Set(ByVal value As String)
            m_Code = value
            CheckBox1.Text = m_Code & " " & m_Libelle
        End Set
    End Property

    ''' <summary>
    ''' Catégorie courante du defaut
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Categorie As CRODIP_CATEGORIEDEFAUT
        Get
            Return m_Categorie
        End Get
        Set(ByVal value As CRODIP_CATEGORIEDEFAUT)
            m_Categorie = value
            If value = CRODIP_CATEGORIEDEFAUT.DEFAUT_ABSENCE Then
                '2; 129; 198
                CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                CheckBox1.ForeColor = CtrlDiag2.ITEMCOLORABSENCE
            End If
            If value = CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEURPRELIM Then
                'Idem DEFAUTMAJEUR
                CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                CheckBox1.ForeColor = CtrlDiag2.ITEMCOLORMAJEURPRELIM
            End If
            If value = CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR Then
                CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                CheckBox1.ForeColor = CtrlDiag2.ITEMCOLORMAJEUR
            End If
            If value = CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR Then
                CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                CheckBox1.ForeColor = CtrlDiag2.ITEMCOLORMINEUR
            End If
            If value = CRODIP_CATEGORIEDEFAUT.DEFAUT_OK Then
                CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                CheckBox1.ForeColor = CtrlDiag2.ITEMCOLOROK
            End If
        End Set
    End Property
    ''' <summary>
    ''' Catégorie par defaut du defaut
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DefaultCategorie As CRODIP_CATEGORIEDEFAUT
        Get
            Return m_DefaultCategorie
        End Get
        Set(ByVal value As CRODIP_CATEGORIEDEFAUT)
            m_DefaultCategorie = value
            'Si la catégorie n'est pas initialisée on la met à la valeur par defaut
            If Categorie = CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE Then
                Categorie = DefaultCategorie
            End If
        End Set
    End Property
    ''' <summary>
    ''' Niveau de cause courant
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Cause As CRODIP_NIVEAUCAUSEMAX
        Get
            Dim value As CRODIP_NIVEAUCAUSEMAX
            value = CRODIP_NIVEAUCAUSEMAX.NONE
            Select Case PictureBox1.Tag
                Case ""
                    value = CRODIP_NIVEAUCAUSEMAX.NONE
                Case "0"
                    value = CRODIP_NIVEAUCAUSEMAX.ZERO
                Case "1"
                    value = CRODIP_NIVEAUCAUSEMAX.UN
                Case "2"
                    value = CRODIP_NIVEAUCAUSEMAX.DEUX
                Case "3"
                    value = CRODIP_NIVEAUCAUSEMAX.TROIS

            End Select
            Return value

        End Get
        Set(ByVal value As CRODIP_NIVEAUCAUSEMAX)
            If value = CRODIP_NIVEAUCAUSEMAX.NONE Then
                PictureBox1.Image = Nothing
                PictureBox1.Tag = ""
                'CtrlDiag2_RB1.value = value
            End If
            If value = CRODIP_NIVEAUCAUSEMAX.ZERO And NiveauCause_max <> CRODIP_NIVEAUCAUSEMAX.ZERO Then
                PictureBox1.Image = ImageList1.Images(0)
                PictureBox1.Tag = "0"
                ToolTip1.SetToolTip(PictureBox1, CtrlDiag2_RB1.ToolTip1.GetToolTip(CtrlDiag2_RB1.rb0))
                'CtrlDiag2_RB1.value = value
            End If
            If value = CRODIP_NIVEAUCAUSEMAX.ZERO And NiveauCause_max = CRODIP_NIVEAUCAUSEMAX.ZERO Then
                PictureBox1.Image = Nothing
                PictureBox1.Tag = "0"
                ToolTip1.SetToolTip(PictureBox1, CtrlDiag2_RB1.ToolTip1.GetToolTip(CtrlDiag2_RB1.rb0))
                'CtrlDiag2_RB1.value = value
            End If
            If value = CRODIP_NIVEAUCAUSEMAX.UN Then
                PictureBox1.Image = ImageList1.Images(1)
                PictureBox1.Tag = "1"
                ToolTip1.SetToolTip(PictureBox1, CtrlDiag2_RB1.ToolTip1.GetToolTip(CtrlDiag2_RB1.rb1))
                'CtrlDiag2_RB1.value = value
            End If
            If value = CRODIP_NIVEAUCAUSEMAX.DEUX Then
                PictureBox1.Image = ImageList1.Images(2)
                PictureBox1.Tag = "2"
                'CtrlDiag2_RB1.value = value
                ToolTip1.SetToolTip(PictureBox1, CtrlDiag2_RB1.ToolTip1.GetToolTip(CtrlDiag2_RB1.rb2))
            End If
            If value = CRODIP_NIVEAUCAUSEMAX.TROIS Then
                PictureBox1.Image = ImageList1.Images(3)
                CheckBox1.CheckState = CheckState.Checked
                PictureBox1.Tag = "3"
                ToolTip1.SetToolTip(PictureBox1, CtrlDiag2_RB1.ToolTip1.GetToolTip(CtrlDiag2_RB1.rb3))
                'CtrlDiag2_RB1.value = value
            End If
            RaiseEvent CheckedChanged(Me, New EventArgs())
        End Set
    End Property
    ''' <summary>
    ''' Niveau maximum de Cause du défaut
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NiveauCause_max As CRODIP_NIVEAUCAUSEMAX
        Get
            Return m_NiveauCauseMax

        End Get
        Set(ByVal value As CRODIP_NIVEAUCAUSEMAX)
            m_NiveauCauseMax = value
            m_bCause1 = False
            m_bCause2 = False
            m_bCause3 = False
            If m_NiveauCauseMax = CRODIP_NIVEAUCAUSEMAX.TROIS Then
                m_bCause1 = True
                m_bCause2 = True
                m_bCause3 = True
            End If
            If m_NiveauCauseMax = CRODIP_NIVEAUCAUSEMAX.DEUX Then
                m_bCause1 = True
                m_bCause2 = True
            End If
            If m_NiveauCauseMax = CRODIP_NIVEAUCAUSEMAX.UN Then
                m_bCause1 = True
            End If
            CtrlDiag2_RB1.Defaut_niveauCause = value
            If value = CRODIP_NIVEAUCAUSEMAX.ZERO Or value = CRODIP_NIVEAUCAUSEMAX.NONE Then
                Cause = CRODIP_NIVEAUCAUSEMAX.NONE
                PictureBox1.Enabled = False
                PictureBox1.Visible = False
                PictureBox1.SendToBack()
            Else
                PictureBox1.Enabled = True
                PictureBox1.Visible = True
                PictureBox1.BringToFront()

            End If
        End Set
    End Property
    ''' <summary>
    ''' Boolean d'affichage de la Cause 1
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property cause1 As Boolean
        Get
            Return m_bCause1

        End Get
        Set(ByVal value As Boolean)
            m_bCause1 = value
            'If m_bCause1 = False And m_bCause2 = False And m_bCause3 = False Then
            'NiveauCause_max = CRODIP_NIVEAUCAUSEMAX.NONE
            'End If
        End Set
    End Property
    ''' <summary>
    ''' Boolean d'affichage de la Cause 2
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property cause2 As Boolean
        Get
            Return m_bCause2

        End Get
        Set(ByVal value As Boolean)
            m_bCause2 = value
            'If m_bCause1 = False And m_bCause2 = False And m_bCause3 = False Then
            'NiveauCause_max = CRODIP_NIVEAUCAUSEMAX.NONE
            'End If
        End Set
    End Property
    ''' <summary>
    ''' Boolean d'affichage de la Cause 3
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property cause3 As Boolean
        Get
            Return m_bCause3

        End Get
        Set(ByVal value As Boolean)
            m_bCause3 = value
            'If m_bCause3 = False And m_bCause2 = False And m_bCause3 = False Then
            'NiveauCause_max = CRODIP_NIVEAUCAUSEMAX.NONE
            'End If
        End Set
    End Property
    ''' <summary>
    ''' Rend vrai si le defaut déclenche un diag en Erreur
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function isError() As Boolean
        Dim bReturn As Boolean
        bReturn = False
        If Checked And Categorie = CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR Then
            bReturn = True
        End If
        Return bReturn
    End Function
#Region "Events"

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            If m_NiveauCauseMax <> CRODIP_CATEGORIEDEFAUT.DEFAUT_OK Then
                Cause = CRODIP_NIVEAUCAUSEMAX.ZERO
            End If
        Else
            CtrlDiag2_RB1.Visible = False
            CtrlDiag2_RB1.SendToBack()
            Cause = CRODIP_NIVEAUCAUSEMAX.NONE
            'Réinitialisation de la catégorie avec la catégorie par défaut
            Categorie = DefaultCategorie
        End If
        RaiseEvent CheckedChanged(Me, e)
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CtrlDiag2_RB1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CtrlDiag2_RB1.valuechanged
        'Validation des (1) (2) (3) :
        '   (1)	Fait toujours passer le défaut en vert
        '   (2)	Garde la même couleur que le défaut d’origine ( avoir dans un second temps lorsque l’on pourra agir dessus avec le logiciel CRODIP)
        '   (3)	Fait passer le défaut en vert

        If CtrlDiag2_RB1.value = CRODIP_NIVEAUCAUSEMAX.UN Or CtrlDiag2_RB1.value = CRODIP_NIVEAUCAUSEMAX.TROIS Then
            Categorie = CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        End If
        If CtrlDiag2_RB1.value = CRODIP_NIVEAUCAUSEMAX.DEUX Then
            Categorie = DefaultCategorie
        End If
        Me.Cause = CtrlDiag2_RB1.value
        '        RaiseEvent CheckedChanged(Me, e) Déclenché dans l'acesseur de cause
    End Sub


    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        If CheckBox1.Checked Then
            If NiveauCause_max <> CRODIP_NIVEAUCAUSEMAX.ZERO And NiveauCause_max <> CRODIP_NIVEAUCAUSEMAX.NONE Then
                CtrlDiag2_RB1.Visible = True
                CtrlDiag2_RB1.BringToFront()
            End If
        End If
    End Sub

#End Region
End Class
