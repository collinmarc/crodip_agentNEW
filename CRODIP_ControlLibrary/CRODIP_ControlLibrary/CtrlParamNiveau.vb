<System.ComponentModel.DefaultEvent("CheckedChanged")>
Public Class CtrlParamNiveau
    Private _Label As String
    Public Property Label() As String
        Get
            Return _Label
        End Get
        Set(ByVal value As String)
            _Label = value
            lblBloc.Text = value
            If Not bMultiLine Then
                Me.Width = lblBloc.Width + 55
                Me.Height = lblBloc.Height
            Else
                lblBloc.AutoSize = False
                lblBloc.Text = value
            End If
            ckValidBloc.Top = (Me.Height - ckValidBloc.Height) / 2
            ckValidBloc.Left = Me.Width - ckValidBloc.Width
            pctBloc.Top = ckValidBloc.Top
        End Set
    End Property
    Public Property Text() As String
        Get
            Return Label
        End Get
        Set(ByVal value As String)
            Label = value
        End Set
    End Property
    Private _Niveau As Integer
    Public Property Niveau() As Integer
        Get
            Return _Niveau
        End Get
        Set(ByVal value As Integer)
            _Niveau = value
            If value = 1 Then
                pctBloc.Image = m_ImageList.Images(0)
                lblBloc.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                lblBloc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
            End If
            If value = 2 Then
                pctBloc.Image = m_ImageList.Images(1)
                lblBloc.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                lblBloc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
            End If
        End Set
    End Property
    Private _bValidBloc As Boolean
    Public Property bValidBloc() As Boolean
        Get
            Return _bValidBloc
        End Get
        Set(ByVal value As Boolean)
            _bValidBloc = value
            ckValidBloc.Visible = value
        End Set
    End Property
    Public Property Checked() As Boolean
        Get
            Return ckValidBloc.Checked
        End Get
        Set(ByVal value As Boolean)
            ckValidBloc.Checked = value
        End Set
    End Property
    Private _bmultiLine As Boolean
    Public Property bMultiLine() As Boolean
        Get
            Return _bmultiLine
        End Get
        Set(ByVal value As Boolean)
            _bmultiLine = value
            If _bmultiLine Then
                lblBloc.AutoSize = False
            Else
                lblBloc.AutoSize = True
            End If
        End Set
    End Property
    Public Shadows Event CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Private Sub ckValidBloc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckValidBloc.CheckedChanged
        RaiseEvent CheckedChanged(Me, e)
    End Sub


End Class
