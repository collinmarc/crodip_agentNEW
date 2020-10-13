Partial Class SignatureForm
    Inherits Form
    Private components As System.ComponentModel.IContainer = Nothing

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (m_tablet IsNot Nothing) Then
            'RemoveHandler m_tablet.onPenData, AddressOf New wgssSTU.ITabletEvents2_onPenDataEventHandler(Me.onPenData)
            '            m_tablet.onPenData -= New wgssSTU.ITabletEvents2_onPenDataEventHandler(onPenData)
            m_tablet.disconnect()
            m_tablet = Nothing
        End If

        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If

        MyBase.Dispose(disposing)
    End Sub

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SignatureForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Signature"
        AddHandler FormClosed, AddressOf Form2_FormClosed
        AddHandler Paint, AddressOf Form2_Paint
        AddHandler MouseClick, AddressOf Form2_MouseClick
        'Me.FormClosed += New System.Windows.Forms.FormClosedEventHandler(Me.Form2_FormClosed)
        'Me.Paint += New System.Windows.Forms.PaintEventHandler(Me.Form2_Paint)
        'Me.MouseClick += New System.Windows.Forms.MouseEventHandler(Me.Form2_MouseClick)
        Me.ResumeLayout(False)
    End Sub
End Class
