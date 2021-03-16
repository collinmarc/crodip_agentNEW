Imports System.IO

Public Class frmSignClient
    Inherits System.Windows.Forms.Form
    Private m_odiag As Diagnostic
    Protected m_Mode As SignMode
    Private m_Agent As Agent
    Protected img As Image = Nothing
    Protected ms As MemoryStream
    Private _bSignVide As Boolean

    Protected pctSignatureWidth As Integer
    Protected pctSignatureHeight As Integer

    Public Sub New()
        m_odiag = Nothing
        m_Mode = Nothing
        m_Agent = Nothing

    End Sub
    Public Sub New(pDiag As Diagnostic, psignMode As SignMode, pAgent As Agent)
        m_odiag = pDiag
        m_Mode = psignMode
        m_Agent = pAgent

    End Sub
    Public Property bSignVide() As Boolean
        Get
            Return _bSignVide
        End Get
        Set(ByVal value As Boolean)
            _bSignVide = value
            Try
                Controls("btnValider").Enabled = Not bSignVide
            Catch ex As Exception

            End Try
        End Set
    End Property


    Protected Sub SetImgSignature()
        img = New Bitmap(pctSignatureWidth, pctSignatureHeight)
        Using graphics As Graphics = Graphics.FromImage(img)
            graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High
            graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
            Using Brush As New SolidBrush(Color.White)

                graphics.FillRectangle(Brush, 0, 0, pctSignatureWidth, pctSignatureHeight)
            End Using
        End Using

        Select Case m_Mode
            Case SignMode.RIAGENT
                Me.Text = "Signature Rapport Inspecteur"
                If m_odiag.SignRIAgent IsNot Nothing Then
                    Try
                        ms = New MemoryStream(m_odiag.SignRIAgent)
                        img = Image.FromStream(ms)
                        bSignVide = False
                    Catch ex As Exception
                    End Try
                Else
                    If System.IO.File.Exists("config/" & m_Agent.nom & ".sign") Then
                        Using bmpTemp As New Bitmap("config/" & m_Agent.nom & ".sign")
                            img = New Bitmap(bmpTemp)
                        End Using
                        bSignVide = False
                    Else
                    End If
                End If
            Case SignMode.RICLIENT
                Me.Text = "Signature Rapport CLIENT"
                If m_odiag.SignRIClient IsNot Nothing Then
                    Try
                        ms = New MemoryStream(m_odiag.SignRIClient)
                        img = Image.FromStream(ms)
                        bSignVide = False
                    Catch ex As Exception
                    End Try
                End If
            Case SignMode.CCAGENT
                Me.Text = "Signature Contrat AGENT"
                If m_odiag.SignCCAgent IsNot Nothing Then
                    Try
                        ms = New MemoryStream(m_odiag.SignCCAgent)
                        img = Image.FromStream(ms)
                        bSignVide = False
                    Catch ex As Exception
                    End Try
                Else
                    If System.IO.File.Exists("config/" & m_Agent.nom & ".sign") Then
                        Using bmpTemp As New Bitmap("config/" & m_Agent.nom & ".sign")
                            img = New Bitmap(bmpTemp)
                        End Using
                        bSignVide = False
                    End If
                End If
            Case SignMode.CCCLIENT
                Me.Text = "Signature Contrat CLIENT"
                If m_odiag.SignCCClient IsNot Nothing Then
                    Try
                        ms = New MemoryStream(m_odiag.SignCCClient)
                        img = Image.FromStream(ms)
                        bSignVide = False
                    Catch ex As Exception
                    End Try
                End If
        End Select
    End Sub

    Protected Sub RecupereSignature(pImage As Image, pDateSign As Date)
        Dim ms2 As New MemoryStream
        pImage.Save(ms2, Imaging.ImageFormat.Bmp)
        Select Case m_Mode
            Case SignMode.RICLIENT
                m_odiag.SignRIClient = ms2.ToArray()
                m_odiag.isSignRIClient = True
                Try
                    m_odiag.dateSignRIClient = pDateSign
                Catch ex As Exception

                End Try
 '               End If
            Case SignMode.RIAGENT
                m_odiag.SignRIAgent = ms2.ToArray()
                m_odiag.isSignRIAgent = True
                Try

                    m_odiag.dateSignRIAgent = pDateSign
                Catch ex As Exception

                End Try
            Case SignMode.CCCLIENT
                m_odiag.SignCCClient = ms2.ToArray()
                m_odiag.isSignCCClient = True
                Try
                    m_odiag.dateSignCCClient = pDateSign
                Catch ex As Exception

                End Try
            Case SignMode.CCAGENT
                m_odiag.SignCCAgent = ms2.ToArray()
                m_odiag.isSignCCAgent = True
                Try
                    m_odiag.dateSignCCAgent = pDateSign
                Catch ex As Exception

                End Try

        End Select


    End Sub
    Protected Sub AnnuleSignature()
        Select Case m_Mode
            Case SignMode.RICLIENT
                m_odiag.SignRIClient = Nothing
                m_odiag.isSignRIClient = False
                m_odiag.dateSignRIClient = Nothing
            Case SignMode.RIAGENT
                m_odiag.SignRIAgent = Nothing
                m_odiag.isSignRIAgent = False
                m_odiag.dateSignRIAgent = Nothing
            Case SignMode.CCCLIENT
                m_odiag.SignCCClient = Nothing
                m_odiag.isSignCCClient = False
                m_odiag.dateSignCCClient = Nothing
            Case SignMode.CCAGENT
                m_odiag.SignCCAgent = Nothing
                m_odiag.isSignCCAgent = False
                m_odiag.dateSignCCAgent = Nothing
        End Select

    End Sub
    Public Overridable Sub Disconnect()

    End Sub

    Public Sub Conserverlasignature()
        If (m_Mode = SignMode.RIAGENT Or m_Mode = SignMode.CCAGENT) Then
            If File.Exists("config/" & m_Agent.nom & ".sign") Then
                File.Delete("config/" & m_Agent.nom & ".sign")
            End If
            img.Save("config/" & m_Agent.nom & ".sign")
        End If
    End Sub

    Shared Function getfrmSignature(pDiag As Diagnostic, psignMode As SignMode, pAgent As Agent) As frmSignClient

        Dim ofrm As frmSignClient = Nothing
        If My.Settings.ModeSignature = "Téléphone" Then
            ofrm = New frmSignClientTelephone(pDiag, psignMode, pAgent)
        End If
        If My.Settings.ModeSignature = "Tablette" Then
            ofrm = New frmSignClientTablette(pDiag, psignMode, pAgent)
        End If
        If My.Settings.ModeSignature = "wacom" Then
            Dim usbDevices As wgssSTU.UsbDevices = New wgssSTU.UsbDevices()
            Dim usbDevice As wgssSTU.IUsbDevice

            If usbDevices.Count <> 0 Then
                usbDevice = usbDevices(0)
                ofrm = New frmSignClientWacom(pDiag, psignMode, pAgent, usbDevice)
            End If

        End If

        Return ofrm
    End Function

    Public Overridable Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSignClient))
        Me.SuspendLayout()
        '
        'frmSignClient
        '
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSignClient"
        Me.ResumeLayout(False)

    End Sub

    Private Sub frmSignClient_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
    End Sub

    Private Sub frmSignClient_Load(sender As Object, e As EventArgs) Handles Me.Load
    End Sub
End Class
