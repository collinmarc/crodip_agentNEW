Public Class frmSaisieNumFact
    Private m_agent As Agent
    Public NUMFACT As String
    Private FACTURATION_XML_CONFIG As CSXml = New CSXml(GlobalsCRODIP.GLOB_STR_FACTURATIONCONFIG_FILENAME)

    Public Sub SetContext(pAgent As Agent)
        m_agent = pAgent
    End Sub

    Public Sub New(pAgent As Agent)
        InitializeComponent()
        SetContext(pAgent)

    End Sub

    Private Sub frmSaisieNumFact_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim x As Xml.XmlNode = Me.FACTURATION_XML_CONFIG.getXmlNode("/root/racinenumerotation")
        If x IsNot Nothing Then
            tbRacineFacturation.Text = x.InnerText
            x = Me.FACTURATION_XML_CONFIG.getXmlNode("/root/derniernumero")
            If x IsNot Nothing Then
                tbDernNumFact.Text = x.InnerText
                If IsNumeric(x.InnerText) Then
                    Dim nLg As Integer = x.InnerText.Length()
                    Dim n As Integer = Convert.ToInt64(x.InnerText) + 1
                    tbNumFact.Text = n.ToString().PadLeft(nLg, "0")
                End If
            End If
        End If



        '      Dim strDernRef As String = DiagnosticFactureManager.getDernReference(m_agent)
        '      tbDernNumFact.Text = strDernRef
        '      tbNumFact.Text = "FA" & Format(Date.Now, "yyyy") & m_agent.numeroNational
    End Sub

    Private Sub btn_facturation_suivant_Click(sender As Object, e As EventArgs) Handles btn_facturation_suivant.Click
        If tbNumFact.Text = "" Or tbDernNumFact.Text = tbNumFact.Text Then
            MsgBox("Numéro de facture incorrect")
        Else
            NUMFACT = Trim(tbRacineFacturation.Text) & Trim(tbNumFact.Text)
            Dim nElement As Integer
            nElement = Me.FACTURATION_XML_CONFIG.countElements("/root/*")
            If nElement = 7 Then
                Me.FACTURATION_XML_CONFIG.addElement("/root", "racinenumerotation", tbRacineFacturation.Text)
                Me.FACTURATION_XML_CONFIG.addElement("/root", "derniernumero", tbNumFact.Text)
            Else
                Me.FACTURATION_XML_CONFIG.setElementValue("/root/racinenumerotation", tbRacineFacturation.Text)
                Me.FACTURATION_XML_CONFIG.setElementValue("/root/derniernumero", tbNumFact.Text)
            End If

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class