Imports System
Imports System.Net
Imports System.IO

Structure test1
    Public itemId As String
    Public itemValue As String
End Structure

Public Class test

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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents input_crypt As System.Windows.Forms.TextBox
    Friend WithEvents input_cryptResult As System.Windows.Forms.TextBox
    Friend WithEvents test_checkUpdate As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Button24 As System.Windows.Forms.Button
    Friend WithEvents Button26 As System.Windows.Forms.Button
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents Button27 As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents btnReferentiel_buse As System.Windows.Forms.Button
    Friend WithEvents btnReferentiel_territoire As System.Windows.Forms.Button
    Friend WithEvents btnReferentiel_manometre As System.Windows.Forms.Button
    Friend WithEvents btnReferentiel_pulverisateur As System.Windows.Forms.Button
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents btnWSPulve_send As System.Windows.Forms.Button
    Friend WithEvents btnWSPulve_load As System.Windows.Forms.Button
    Friend WithEvents btnVersion_getCur As System.Windows.Forms.Button
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents newDiagId As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(test))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.input_cryptResult = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.input_crypt = New System.Windows.Forms.TextBox()
        Me.test_checkUpdate = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button26 = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button27 = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Button24 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.btnReferentiel_buse = New System.Windows.Forms.Button()
        Me.btnReferentiel_territoire = New System.Windows.Forms.Button()
        Me.btnReferentiel_manometre = New System.Windows.Forms.Button()
        Me.btnReferentiel_pulverisateur = New System.Windows.Forms.Button()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.btnWSPulve_send = New System.Windows.Forms.Button()
        Me.btnWSPulve_load = New System.Windows.Forms.Button()
        Me.btnVersion_getCur = New System.Windows.Forms.Button()
        Me.newDiagId = New System.Windows.Forms.Button()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(8, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(96, 32)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Load WSProfil"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(112, 16)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(96, 32)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Send WSProfil"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.input_cryptResult)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.input_crypt)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 416)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(216, 80)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cryptage"
        '
        'input_cryptResult
        '
        Me.input_cryptResult.Location = New System.Drawing.Point(8, 48)
        Me.input_cryptResult.Name = "input_cryptResult"
        Me.input_cryptResult.Size = New System.Drawing.Size(200, 20)
        Me.input_cryptResult.TabIndex = 2
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(176, 22)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(32, 23)
        Me.Button3.TabIndex = 1
        Me.Button3.Text = "Ok"
        '
        'input_crypt
        '
        Me.input_crypt.Location = New System.Drawing.Point(8, 24)
        Me.input_crypt.Name = "input_crypt"
        Me.input_crypt.Size = New System.Drawing.Size(160, 20)
        Me.input_crypt.TabIndex = 0
        '
        'test_checkUpdate
        '
        Me.test_checkUpdate.Location = New System.Drawing.Point(8, 56)
        Me.test_checkUpdate.Name = "test_checkUpdate"
        Me.test_checkUpdate.Size = New System.Drawing.Size(96, 32)
        Me.test_checkUpdate.TabIndex = 3
        Me.test_checkUpdate.Text = "Check update"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(8, 16)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(96, 32)
        Me.Button4.TabIndex = 4
        Me.Button4.Text = "Load WSProfil"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button13)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.test_checkUpdate)
        Me.GroupBox2.Controls.Add(Me.Button26)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(216, 114)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Agent"
        '
        'Button26
        '
        Me.Button26.Location = New System.Drawing.Point(112, 56)
        Me.Button26.Name = "Button26"
        Me.Button26.Size = New System.Drawing.Size(96, 32)
        Me.Button26.TabIndex = 4
        Me.Button26.Text = "Load LocalItem"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button6)
        Me.GroupBox3.Controls.Add(Me.Button4)
        Me.GroupBox3.Controls.Add(Me.Button8)
        Me.GroupBox3.Controls.Add(Me.Button12)
        Me.GroupBox3.Location = New System.Drawing.Point(248, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(216, 96)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Client"
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(8, 56)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(96, 32)
        Me.Button6.TabIndex = 5
        Me.Button6.Text = "Manager"
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(112, 16)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(96, 32)
        Me.Button8.TabIndex = 5
        Me.Button8.Text = "Send WSProfil"
        '
        'Button12
        '
        Me.Button12.Location = New System.Drawing.Point(112, 56)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(96, 32)
        Me.Button12.TabIndex = 4
        Me.Button12.Text = "Load LocalItem"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Button10)
        Me.GroupBox4.Controls.Add(Me.Button5)
        Me.GroupBox4.Controls.Add(Me.Button27)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 120)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(216, 96)
        Me.GroupBox4.TabIndex = 7
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Structure"
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(112, 16)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(96, 32)
        Me.Button10.TabIndex = 5
        Me.Button10.Text = "Send WSProfil"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(8, 16)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(96, 32)
        Me.Button5.TabIndex = 4
        Me.Button5.Text = "Load WSProfil"
        '
        'Button27
        '
        Me.Button27.Location = New System.Drawing.Point(112, 56)
        Me.Button27.Name = "Button27"
        Me.Button27.Size = New System.Drawing.Size(96, 32)
        Me.Button27.TabIndex = 4
        Me.Button27.Text = "Load LocalItem"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Button24)
        Me.GroupBox5.Controls.Add(Me.Button7)
        Me.GroupBox5.Controls.Add(Me.Button9)
        Me.GroupBox5.Controls.Add(Me.Button11)
        Me.GroupBox5.Location = New System.Drawing.Point(248, 120)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(216, 96)
        Me.GroupBox5.TabIndex = 8
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Diagnostic"
        '
        'Button24
        '
        Me.Button24.Location = New System.Drawing.Point(8, 56)
        Me.Button24.Name = "Button24"
        Me.Button24.Size = New System.Drawing.Size(96, 32)
        Me.Button24.TabIndex = 6
        Me.Button24.Text = "Test send Array"
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(112, 56)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(96, 32)
        Me.Button7.TabIndex = 4
        Me.Button7.Text = "Load LocalItem"
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(112, 16)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(96, 32)
        Me.Button9.TabIndex = 5
        Me.Button9.Text = "Send WSProfil"
        '
        'Button11
        '
        Me.Button11.Location = New System.Drawing.Point(8, 16)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(96, 32)
        Me.Button11.TabIndex = 4
        Me.Button11.Text = "Load WSProfil"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        Me.ImageList1.Images.SetKeyName(2, "")
        Me.ImageList1.Images.SetKeyName(3, "")
        Me.ImageList1.Images.SetKeyName(4, "")
        Me.ImageList1.Images.SetKeyName(5, "")
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.btnReferentiel_buse)
        Me.GroupBox6.Controls.Add(Me.btnReferentiel_territoire)
        Me.GroupBox6.Controls.Add(Me.btnReferentiel_manometre)
        Me.GroupBox6.Controls.Add(Me.btnReferentiel_pulverisateur)
        Me.GroupBox6.Location = New System.Drawing.Point(8, 240)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(216, 96)
        Me.GroupBox6.TabIndex = 7
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Référentiel"
        '
        'btnReferentiel_buse
        '
        Me.btnReferentiel_buse.Location = New System.Drawing.Point(112, 16)
        Me.btnReferentiel_buse.Name = "btnReferentiel_buse"
        Me.btnReferentiel_buse.Size = New System.Drawing.Size(96, 32)
        Me.btnReferentiel_buse.TabIndex = 5
        Me.btnReferentiel_buse.Text = "Buse"
        '
        'btnReferentiel_territoire
        '
        Me.btnReferentiel_territoire.Location = New System.Drawing.Point(8, 16)
        Me.btnReferentiel_territoire.Name = "btnReferentiel_territoire"
        Me.btnReferentiel_territoire.Size = New System.Drawing.Size(96, 32)
        Me.btnReferentiel_territoire.TabIndex = 4
        Me.btnReferentiel_territoire.Text = "Territoire"
        '
        'btnReferentiel_manometre
        '
        Me.btnReferentiel_manometre.Location = New System.Drawing.Point(112, 56)
        Me.btnReferentiel_manometre.Name = "btnReferentiel_manometre"
        Me.btnReferentiel_manometre.Size = New System.Drawing.Size(96, 32)
        Me.btnReferentiel_manometre.TabIndex = 4
        Me.btnReferentiel_manometre.Text = "Manomètre"
        '
        'btnReferentiel_pulverisateur
        '
        Me.btnReferentiel_pulverisateur.Location = New System.Drawing.Point(8, 56)
        Me.btnReferentiel_pulverisateur.Name = "btnReferentiel_pulverisateur"
        Me.btnReferentiel_pulverisateur.Size = New System.Drawing.Size(96, 32)
        Me.btnReferentiel_pulverisateur.TabIndex = 4
        Me.btnReferentiel_pulverisateur.Text = "Pulverisateur"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.btnWSPulve_send)
        Me.GroupBox7.Controls.Add(Me.btnWSPulve_load)
        Me.GroupBox7.Location = New System.Drawing.Point(248, 240)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(216, 96)
        Me.GroupBox7.TabIndex = 7
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Pulverisateur"
        '
        'btnWSPulve_send
        '
        Me.btnWSPulve_send.Location = New System.Drawing.Point(112, 16)
        Me.btnWSPulve_send.Name = "btnWSPulve_send"
        Me.btnWSPulve_send.Size = New System.Drawing.Size(96, 32)
        Me.btnWSPulve_send.TabIndex = 5
        Me.btnWSPulve_send.Text = "Send WSProfil"
        '
        'btnWSPulve_load
        '
        Me.btnWSPulve_load.Location = New System.Drawing.Point(8, 16)
        Me.btnWSPulve_load.Name = "btnWSPulve_load"
        Me.btnWSPulve_load.Size = New System.Drawing.Size(96, 32)
        Me.btnWSPulve_load.TabIndex = 4
        Me.btnWSPulve_load.Text = "Load WSProfil"
        '
        'btnVersion_getCur
        '
        Me.btnVersion_getCur.Location = New System.Drawing.Point(16, 360)
        Me.btnVersion_getCur.Name = "btnVersion_getCur"
        Me.btnVersion_getCur.Size = New System.Drawing.Size(96, 32)
        Me.btnVersion_getCur.TabIndex = 4
        Me.btnVersion_getCur.Text = "Get curVersion"
        '
        'newDiagId
        '
        Me.newDiagId.Location = New System.Drawing.Point(120, 360)
        Me.newDiagId.Name = "newDiagId"
        Me.newDiagId.Size = New System.Drawing.Size(96, 32)
        Me.newDiagId.TabIndex = 4
        Me.newDiagId.Text = "New Diag Id"
        '
        'Button13
        '
        Me.Button13.Location = New System.Drawing.Point(10, 82)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(96, 32)
        Me.Button13.TabIndex = 5
        Me.Button13.Text = "SoftWareupdate"
        '
        'test
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(936, 500)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.btnVersion_getCur)
        Me.Controls.Add(Me.newDiagId)
        Me.Name = "test"
        Me.Text = "Panneau de tests"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region




#Region " Agent (OK) "

    ' Agent getWSAgentById (OK)
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim objAgent As New Agent
        Try
            objAgent = AgentManager.getWSAgentById("agent-1")
            If objAgent.id <> 0 Then
                MsgBox("Ok, profil chargé :" & objAgent.nom & " " & objAgent.prenom)
            Else
                MsgBox("Erreur - Exeption Locale")
            End If
        Catch ex As Exception
            MsgBox("Aucun profil trouvé pour l'identifiant : 6")
        End Try
    End Sub

    ' Agent sendWSAgent (OK)
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim tmpAgent As New Agent
        tmpAgent.id = 1
        tmpAgent.numeroNational = "agent-1"
        tmpAgent.motDePasse = "9609787b46993655824d57573a9262d0ff7fa5a23bf4dcd88d3320bbc5e48b1b"
        tmpAgent.nom = "Matheu"
        tmpAgent.prenom = "Nicolas"
        tmpAgent.idStructure = 1
        tmpAgent.telephonePortable = "0677763357"
        tmpAgent.eMail = "nicolas@azriel.org"
        tmpAgent.statut = "testtatut"
        tmpAgent.dateCreation = "testateCreation"
        tmpAgent.dateDerniereConnexion = "2009-01-11 00:00:00"
        tmpAgent.dateDerniereSynchro = "2009-01-11 00:00:00"
        tmpAgent.dateModificationAgent = "2009-01-12 01:00:00"
        tmpAgent.dateModificationCrodip = "2009-01-11 00:00:00"
        tmpAgent.versionLogiciel = "v0.1b"
        tmpAgent.commentaire = "Aucun commentaire"
        tmpAgent.cleActivation = "testleActivation"
        tmpAgent.isActif = "1"

        Try
            Dim UpdatedObject As Object
            Dim response As Integer = AgentManager.sendWSAgent(tmpAgent, UpdatedObject)
            'MsgBox("Code retour : " & response.ToString)
            Select Case response
                Case 0 ' OK
                    MsgBox("Ok, profil envoyé")
                Case 1 ' NOK
                    MsgBox("Erreur - sendProfilAgent - Le web service a répondu : Non-Ok")
                Case 9 ' BADREQUEST
                    MsgBox("Erreur - sendProfilAgent - Le web service a répondu : BadRequest")
                Case 2 ' SENDPROFILAGENT_UPDATE
                    MsgBox("Ok, profil envoyé et mis à jour")
                Case 3 ' UPDATESAVAILABLE_NOAGENT pas d'agent pour la mise a jour demandée
                    MsgBox("Erreur - sendProfilAgent - Le web service a répondu : UPDATESAVAILABLE_NOAGENT")
                Case -1 ' EXCEPTION
                    MsgBox("Erreur - sendProfilAgent - Exception Locale")
            End Select

        Catch ex As Exception
            MsgBox("Erreur : " & ex.Message)
        End Try

    End Sub

    ' Agent  getWSUpdates (OK)
    Private Sub test_checkUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles test_checkUpdate.Click


    End Sub

    ' Agent Load Local item
    Private Sub Button26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button26.Click

        Dim tmpAgent As New Agent
        tmpAgent = AgentManager.getAgentByNumeroNational("agent-1")
        If tmpAgent.id <> 0 Then
            MsgBox("Agent n°" & tmpAgent.id & " (" & tmpAgent.numeroNational & ") Chargé.")
        Else
            MsgBox("Erreur lors du chargement de l'agent.")
        End If

    End Sub

#End Region


#Region " Client (OK) "

    ' Client getWSClientById (OK)
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim objClient As New Exploitation
        Try
            objClient = ExploitationManager.getWSExploitationById("1-1-1")
            MsgBox("Ok, profil chargé : " & objClient.raisonSociale)
        Catch ex As Exception
            MsgBox("Aucun profil trouvé pour l'identifiant : struc-1-1")
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

 
    ' Client load local item
    Private Sub Button12_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Dim tmpExploitation As New Exploitation
        tmpExploitation = ExploitationManager.getExploitationById("struc-1-1")
        If tmpExploitation.id <> "0" Then
            MsgBox("Exploitation n°" & tmpExploitation.id & " (" & tmpExploitation.raisonSociale & ") Chargé.")
        Else
            MsgBox("Erreur lors du chargement de l'exploitation.")
        End If
    End Sub

    ' Client sendWSClient (OK)
    Private Sub Button8_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click

        Dim objClient As Exploitation = ExploitationManager.getExploitationById("1-1-1")

        Try
            Dim updatedObject As Object
            Dim response As Object = ExploitationManager.sendWSExploitation(objClient, updatedObject)
            'MsgBox("Code retour : " & response.ToString)
            Select Case response
                Case -1 ' ERREUR
                    MsgBox("Erreur - sendWSStructure - Erreur Locale")
                Case 0 ' OK
                    MsgBox("OK : Pas de mise à jour")
                    'Ici, mettre à jour avec le nouvel object
                Case 2 ' OK : MAJ
                    MsgBox("OK : Mise à jour")

                Case 1 ' NOK
                    MsgBox("Erreur - sendWSStructure - Le web service a répondu : Non-Ok")
                Case 9 ' BADREQUEST
                    MsgBox("Erreur - sendWSStructure - Le web service a répondu : BadRequest")
            End Select

        Catch ex As Exception
            MsgBox("Erreur lors de l'envoi")
        End Try

    End Sub

#End Region


#Region " Structure (OK) "

    ' Structure getWSStructureById (OK)
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim objStructure As New Structuree
        Try
            objStructure = StructureManager.getWSStructureeById(1)
            If objStructure.id <> 0 Then
                MsgBox("Ok, profil chargé :" & objStructure.nom)
            Else
                MsgBox("Aucun profil trouvé pour l'identifiant : 1")
            End If
        Catch ex As Exception
            MsgBox("Aucun profil trouvé pour l'identifiant : 1")
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    ' Structure sendWSStructure (OK)
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click

        Dim objStructure As Structuree = StructureManager.getStructureById("1")
        'objStructure.id = "1"
        'objStructure.nom = "Cognix Systems"
        'objStructure.type = "SSII"
        'objStructure.nomResponsable = "Cremer Davy"
        'objStructure.adresse = "65 avenue aristide briand"
        'objStructure.codePostal = "35000"
        'objStructure.commune = "Rennes"
        'objStructure.codeInsee = "fguyk"
        'objStructure.telephoneFixe = "0299123456"
        'objStructure.telephonePortable = "0655512345"
        'objStructure.telephoneFax = "0245873594"
        'objStructure.eMail = "contact@cognix-systems.com"
        'objStructure.commentaire = "Aucun Commentaire"
        'objStructure.dateModificationCrodip = "2009-01-03 01:00:00"
        'objStructure.dateModificationAgent = "2009-06-25 14:50:01"

        Try
            Dim UpdatedObject As Object
            Dim response As Object = StructureManager.sendWSStructuree(objStructure, UpdatedObject)
            Select Case response
                Case -1 ' ERROR
                    MsgBox("Erreur - sendWSStructure - Erreur Locale")
                Case 0 ' OK
                    MsgBox("Déjà à jour OK")
                Case 2 ' SENDPROFILAGENT_UPDATE
                    MsgBox("Mise à jour effectuée")
                Case 1 ' NOK
                    MsgBox("Erreur - sendWSStructure - Le web service a répondu : Non-Ok")
                Case 9 ' BADREQUEST
                    MsgBox("Erreur - sendWSStructure - Le web service a répondu : BadRequest")
                Case 3 ' SENDPROFILAGENT_NOAGENT 
                    MsgBox("Erreur - sendWSStructure - Le web service a répondu : SENDPROFILAGENT_NOAGENT")
                Case 2 ' SENDSTRUCTURE_UPDATE 
                    MsgBox("Erreur - sendWSStructure - Le web service a répondu : SENDSTRUCTURE_UPDATE")
                Case 2 ' SENDCLIENT_UPDATE
                    MsgBox("Erreur - sendWSStructure - Le web service a répondu : SENDCLIENT_UPDATE")
                Case 3 ' UPDATESAVAILABLE_NOAGENT
                    MsgBox("Erreur - sendWSStructure - Le web service a répondu : UPDATESAVAILABLE_NOAGENT")
            End Select
        Catch ex As Exception
            MsgBox("Erreur lors de l'envoi")
        End Try


    End Sub

    ' Structure load local item
    Private Sub Button27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button27.Click
        Dim tmpStructuree As New Structuree
        tmpStructuree = StructureManager.getStructureById(1)
        If tmpStructuree.id <> 0 Then
            MsgBox("Structure n°" & tmpStructuree.id & " (" & tmpStructuree.nom & ") Chargée.")
        Else
            MsgBox("Erreur lors du chargement de la structure.")
        End If
    End Sub

#End Region


#Region " Diagnostic "

    ' Diagnostic getDiagnosticById (OK)
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim tmpDiagnostic As New Diagnostic
        tmpDiagnostic = DiagnosticManager.getDiagnosticById("1-1-1")
        If tmpDiagnostic.id <> "0" Then
            MsgBox("Diagnostic n°" & tmpDiagnostic.id & " (" & tmpDiagnostic.inspecteurId & ") Chargé.")
        Else
            MsgBox("Erreur lors du chargement du diagnostic.")
        End If
    End Sub

    ' Diagnostic getWSDiagnosticById
    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Dim objDiagnostic As New Diagnostic
        Try
            objDiagnostic = DiagnosticManager.getWSDiagnosticById(agentCourant.id, "1-1-1")
            MsgBox("Ok, Diagnostic chargé, id :" & objDiagnostic.id)
        Catch ex As Exception
            MsgBox("Aucun Diagnostic trouvé pour l'identifiant : 1")
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    ' Diagnostic sendWSDiagnostic
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Try
            Dim tmpDiagnostic As Diagnostic = DiagnosticManager.getDiagnosticById("1-1-55")
            ''tmpDiagnostic.id = "1-1-1"
            ''tmpDiagnostic.idAgent = 1
            ''tmpDiagnostic.nomAgent = "testomAgent"
            ''tmpDiagnostic.idPulverisateur = "testdPulverisateur"
            ''tmpDiagnostic.dateDebut = "17/12/2008"
            ''tmpDiagnostic.dateFin = "17/12/2008"
            ''tmpDiagnostic.etat = "testtat"
            ''tmpDiagnostic.dateDernierControle = "17/12/2008"
            ''tmpDiagnostic.structureId = 1
            ''tmpDiagnostic.structureNumero = "testtructureNumero"
            ''tmpDiagnostic.structureNom = "testtructureNom"
            ''tmpDiagnostic.exploitationNom = "testxploitationNom"
            ''tmpDiagnostic.exploitationNumeroSiren = "testxploitationNumeroSiren"
            ''tmpDiagnostic.exploitationRaisonSociale = "testxploitationRaisonSociale"
            ''tmpDiagnostic.exploitationCodeApe = "testxploitationCodeApe"
            ''tmpDiagnostic.exploitationAdresse = "testxploitationAdresse"
            ''tmpDiagnostic.exploitationCommune = "testxploitationCommune"
            ''tmpDiagnostic.exploitationCodePostal = "testxploitationCodePostal"
            ''tmpDiagnostic.exploitationEmail = "testxploitationEmail"
            ''tmpDiagnostic.exploitationTelephoneFixe = "testxploitationTelephoneFixe"
            ''tmpDiagnostic.exploitationTelephonePortable = "testxploitationTelephonePortable"
            ''tmpDiagnostic.pulverisateurType = "testulverisateurType"
            ''tmpDiagnostic.pulverisateurMarque = "testulverisateurMarque"
            ''tmpDiagnostic.pulverisateurModele = "testulverisateurModele"
            ''tmpDiagnostic.pulverisateurCapacite = "testulverisateurCapacite"
            ''tmpDiagnostic.pulverisateurLargeur = "testulverisateurLargeur"
            ''tmpDiagnostic.pulverisateurAge = "testulverisateurAge"
            ''tmpDiagnostic.pulverisateurSurface = "testulverisateurSurface"
            ''tmpDiagnostic.pulverisateurNombreUtilisateurs = "testulverisateurNombreUtilisateurs"
            ''tmpDiagnostic.pulverisateurIsCuveRincage = False
            ''tmpDiagnostic.pulverisateurCapaciteCuveRincage = "testulverisateurCapaciteCuveRincage"
            ''tmpDiagnostic.pulverisateurIsCuveIncorporation = False
            ''tmpDiagnostic.pulverisateurIsRinceBidon = False
            ''tmpDiagnostic.pulverisateurIsBidonLaveMaim = False
            ''tmpDiagnostic.pulverisateurIsLanceLavageExterieur = False
            ''tmpDiagnostic.pulverisateurIsRotobuse = False
            ''tmpDiagnostic.pulverisateurRegulationIsPressionConstante = False
            ''tmpDiagnostic.pulverisateurRegulationIsDpm = False
            ''tmpDiagnostic.pulverisateurRegulationIsDpa = False
            ''tmpDiagnostic.pulverisateurRegulationIsDpae = False
            ''tmpDiagnostic.pulverisateurRegulationIsPression = False
            ''tmpDiagnostic.pulverisateurRegulationIsDebit = False
            ''tmpDiagnostic.pulverisateurAutresAccessoires = "testulverisateurAutresAccessoires"
            ''tmpDiagnostic.buseMarque = "testuseMarque"
            ''tmpDiagnostic.buseCouleur = "testuseCouleur"
            ''tmpDiagnostic.buseGenre = "testuseGenre"
            ''tmpDiagnostic.buseTypeIsFente = False
            ''tmpDiagnostic.buseTypeIsTurbulence = False
            ''tmpDiagnostic.buseTypeIsBassePression = False
            ''tmpDiagnostic.buseTypeIsInjectionAir = False
            ''tmpDiagnostic.buseTypeIsAutre = "testuseTypeIsAutre"
            ''tmpDiagnostic.buseIsISO = False
            ''tmpDiagnostic.buseAge = "testuseAge"
            ''tmpDiagnostic.buseAngleIs110 = False
            ''tmpDiagnostic.buseAngleIs80 = False
            ''tmpDiagnostic.buseAngleIsAutre = "testuseAngleIsAutre"
            ''tmpDiagnostic.manometreMarque = "testanometreMarque"
            ''tmpDiagnostic.manometreModele = "testanometreModele"
            ''tmpDiagnostic.manometreDiametre = "testanometreDiametre"
            ''tmpDiagnostic.manometreTypeIsAiguille = False
            ''tmpDiagnostic.manometreTypeIsCapteur = False
            ''tmpDiagnostic.manometreFondEchelle = "testanometreFondEchelle"
            ''tmpDiagnostic.manometrePressionTravail = "testanometrePressionTravail"
            ''tmpDiagnostic.exploitationTypeCultureIsGrandeCulture = False
            ''tmpDiagnostic.exploitationTypeCultureIsLegume = False
            ''tmpDiagnostic.exploitationTypeCultureIsElevage = False
            ''tmpDiagnostic.exploitationTypeCultureIsArboriculture = False
            ''tmpDiagnostic.exploitationTypeCultureIsViticulture = False
            ''tmpDiagnostic.exploitationTypeCultureIsAutres = "testxploitationTypeCultureIsAutres"
            ''tmpDiagnostic.exploitationSau = "testxploitationSau"
            ''tmpDiagnostic.isSynchro = False
            ''tmpDiagnostic.dateModificationAgent = "2009-02-09 11:30:03"
            ''tmpDiagnostic.dateModificationCrodip = "2009-02-09 11:30:01"

            'Dim arrItems(2) As DiagnosticItem
            'Dim tmpDiagnosticItems As New DiagnosticItemsList
            'Dim tmpDiagnosticItem As New DiagnosticItem
            'tmpDiagnosticItem.idDiagnostic = tmpDiagnostic.id
            'tmpDiagnosticItem.idItem = "111"
            'tmpDiagnosticItem.itemValue = "1"
            'tmpDiagnosticItem.itemCodeEtat = "1"
            'tmpDiagnosticItem.dateModificationCrodip = tmpDiagnostic.dateModificationCrodip
            'tmpDiagnosticItem.dateModificationAgent = tmpDiagnostic.dateModificationAgent
            'arrItems(0) = tmpDiagnosticItem
            'tmpDiagnosticItem.idItem = "112"
            'arrItems(1) = tmpDiagnosticItem
            'tmpDiagnosticItem.idItem = "113"
            'arrItems(2) = tmpDiagnosticItem
            'tmpDiagnosticItems.diagnosticItem = arrItems
            'tmpDiagnostic.diagnosticItem = tmpDiagnosticItems

            Dim UpdatedObject As Object
            Dim response As Object = DiagnosticManager.sendWSDiagnostic(agentCourant, tmpDiagnostic, UpdatedObject)
            'DiagnosticManager.save(tmpDiagnostic)
            Select Case response
                Case -1 ' ERROR
                    MsgBox("Erreur - sendWSDiagnostic - Erreur Locale")
                Case 0 ' OK
                    MsgBox("Envoi OK : Déjà à jour")
                Case 2 ' SENDPROFILAGENT_UPDATE
                    MsgBox("Envoi OK : Mise à jour effectuée")
                Case 1 ' NOK
                    MsgBox("Erreur - sendWSDiagnostic - Le web service a répondu : Non-Ok")
                Case 9 ' BADREQUEST
                    MsgBox("Erreur - sendWSDiagnostic - Le web service a répondu : BadRequest")
            End Select

            'Dim UpdatedObjectItems As Object
            'Dim responseItems As Object = DiagnosticItemManager.sendWSDiagnosticItem(tmpDiagnostic.diagnosticItem, UpdatedObjectItems)
            'Select Case responseItems
            '    Case -1 ' ERROR
            '        MsgBox("Erreur - sendWSDiagnosticItem - Erreur Locale")
            '    Case 0 ' OK
            '        MsgBox("Envoi OK : Déjà à jour")
            '    Case 2 ' SENDPROFILAGENT_UPDATE
            '        MsgBox("Envoi OK : Mise à jour effectuée")
            '    Case 1 ' NOK
            '        MsgBox("Erreur - sendWSDiagnosticItem - Le web service a répondu : Non-Ok")
            '    Case 9 ' BADREQUEST
            '        MsgBox("Erreur - sendWSDiagnosticItem - Le web service a répondu : BadRequest")
            'End Select

        Catch ex As Exception
            Console.Write(ex.Message.ToString)
        End Try

    End Sub

    ' test send array
    Private Sub Button24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button24.Click
        'SendDiagnosticItems

        Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
        Dim response As Object

        Dim arrItems(2) As Object

        Dim tmpDiagnostic As Object = New Diagnostic
        Dim tmpDiagnosticItems As New DiagnosticItem
        tmpDiagnostic.id = "testd"
        tmpDiagnostic.agentId = "testgentId"
        tmpDiagnostic.agentNom = "testgentNom"
        tmpDiagnostic.pulverisateurId = "testulverisateurId"
        tmpDiagnostic.dateDebut = "testateDebut"
        tmpDiagnostic.dateFin = "testateFin"
        tmpDiagnostic.etat = "testtat"
        tmpDiagnostic.dateDernierControle = "testateDernierControle"
        tmpDiagnostic.structureNum = "testtructureNum"
        tmpDiagnostic.structureNom = "testtructureNom"
        tmpDiagnostic.proprioNom = "testroprioNom"
        tmpDiagnostic.proprioSiren = "testroprioSiren"
        tmpDiagnostic.proprioRaisonSociale = "testroprioRaisonSociale"
        tmpDiagnostic.proprioCodeApe = "testroprioCodeApe"
        tmpDiagnostic.proprioAdresse = "testroprioAdresse"
        tmpDiagnostic.proprioCommune = "testroprioCommune"
        tmpDiagnostic.proprioCodePostal = "testroprioCodePostal"
        tmpDiagnostic.proprioEmail = "testroprioEmail"
        tmpDiagnostic.proprioNumFixe = "testroprioNumFixe"
        tmpDiagnostic.proprioNumPortable = "testroprioNumPortable"
        tmpDiagnostic.pulverisateurType = "testulverisateurType"
        tmpDiagnostic.pulverisateurMarque = "testulverisateurMarque"
        tmpDiagnostic.pulverisateurModele = "testulverisateurModele"
        tmpDiagnostic.pulverisateurCapacite = "testulverisateurCapacite"
        tmpDiagnostic.pulverisateurLargeur = "testulverisateurLargeur"
        tmpDiagnostic.pulverisateurAge = "testulverisateurAge"
        tmpDiagnostic.pulverisateurSurface = "testulverisateurSurface"
        tmpDiagnostic.pulverisateurNbUtilisateurs = "testulverisateurNbUtilisateurs"
        tmpDiagnostic.pulverisateurIsCuveRincage = "testulverisateurIsCuveRincage"
        tmpDiagnostic.pulverisateurCapaciteCuveRincage = "testulverisateurCapaciteCuveRincage"
        tmpDiagnostic.pulverisateurIsRincageBidon = "testulverisateurIsRincageBidon"
        tmpDiagnostic.pulverisateurIsBidonLM = "testulverisateurIsBidonLM"
        tmpDiagnostic.pulverisateurIsBidonLE = "testulverisateurIsBidonLE"
        tmpDiagnostic.pulverisateurIsRotobuse = "testulverisateurIsRotobuse"
        tmpDiagnostic.pulverisateurIsCuveIncorporation = "testulverisateurIsCuveIncorporation"
        tmpDiagnostic.pulverisateurRegulationIsPressionConstante = "testulverisateurRegulationIsPressionConstante"
        tmpDiagnostic.pulverisateurRegulationIsDpm = "testulverisateurRegulationIsDpm"
        tmpDiagnostic.pulverisateurRegulationIsDpa = "testulverisateurRegulationIsDpa"
        tmpDiagnostic.pulverisateurRegulationIsDpae = "testulverisateurRegulationIsDpae"
        tmpDiagnostic.pulverisateurRegulationIsPression = "testulverisateurRegulationIsPression"
        tmpDiagnostic.pulverisateurRegulationIsDebit = "testulverisateurRegulationIsDebit"
        tmpDiagnostic.pulverisateurAutresAccessoires = "testulverisateurAutresAccessoires"
        tmpDiagnostic.busePulverisateurMarque = "testusePulverisateurMarque"
        tmpDiagnostic.busePulverisateurCouleur = "testusePulverisateurCouleur"
        tmpDiagnostic.busePulverisateurGenre = "testusePulverisateurGenre"
        tmpDiagnostic.busePulverisateurTypeIsFente = "testusePulverisateurTypeIsFente"
        tmpDiagnostic.busePulverisateurTypeIsTurbulence = "testusePulverisateurTypeIsTurbulence"
        tmpDiagnostic.busePulverisateurTypeIsBassePression = "testusePulverisateurTypeIsBassePression"
        tmpDiagnostic.busePulverisateurTypeIsInjectionAir = "testusePulverisateurTypeIsInjectionAir"
        tmpDiagnostic.busePulverisateurTypeIsAutre = "testusePulverisateurTypeIsAutre"
        tmpDiagnostic.busePulverisateurIsIso = "testusePulverisateurIsIso"
        tmpDiagnostic.busePulverisateurAge = "testusePulverisateurAge"
        tmpDiagnostic.busePulverisateurAngleIs110 = "testusePulverisateurAngleIs110"
        tmpDiagnostic.busePulverisateurAngleIs80 = "testusePulverisateurAngleIs80"
        tmpDiagnostic.busePulverisateurAngleIsAutre = "testusePulverisateurAngleIsAutre"
        tmpDiagnostic.manoPulverisateurMarque = "testanoPulverisateurMarque"
        tmpDiagnostic.manoPulverisateurModele = "testanoPulverisateurModele"
        tmpDiagnostic.manoPulverisateurDiametre = "testanoPulverisateurDiametre"
        tmpDiagnostic.manoPulverisateurTypeIsAiguille = "testanoPulverisateurTypeIsAiguille"
        tmpDiagnostic.manoPulverisateurTypeIsCapteur = "testanoPulverisateurTypeIsCapteur"
        tmpDiagnostic.manoPulverisateurFondEchelle = "testanoPulverisateurFondEchelle"
        tmpDiagnostic.manoPulverisateurPressionTravail = "testanoPulverisateurPressionTravail"
        tmpDiagnostic.exploitationTypeCultureIsGrandeCulture = "testxploitationTypeCultureIsGrandeCulture"
        tmpDiagnostic.exploitationTypeCultureIsLegume = "testxploitationTypeCultureIsLegume"
        tmpDiagnostic.exploitationTypeCultureIsElevage = "testxploitationTypeCultureIsElevage"
        tmpDiagnostic.exploitationTypeCultureIsArboriculture = "testxploitationTypeCultureIsArboriculture"
        tmpDiagnostic.exploitationTypeCultureIsViticulture = "testxploitationTypeCultureIsViticulture"
        tmpDiagnostic.exploitationTypeCultureIsAutre = "testxploitationTypeCultureIsAutre"
        tmpDiagnostic.exploitationSAU = "testxploitationSAU"
        tmpDiagnosticItems.idDiagnostic = "testdDiagnostic"
        tmpDiagnosticItems.idItem = "testdItem"
        tmpDiagnosticItems.itemValue = "testtemValue"
        tmpDiagnosticItems.itemCodeEtat = "testtemCodeEtat"

        arrItems(0) = tmpDiagnosticItems
        arrItems(1) = tmpDiagnosticItems
        arrItems(2) = tmpDiagnosticItems

        'objWSCrodip.SendDiagnostic(tmpDiagnostic)
        Dim updatedObject As Object
        objWSCrodip.SendDiagnosticItems(agentCourant.id, arrItems, updatedObject)

    End Sub

#End Region


#Region " Pulvérisateur "

    Private Sub btnWSPulve_load_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWSPulve_load.Click
        Dim objPulverisateur As New Pulverisateur
        Try
            objPulverisateur = PulverisateurManager.getWSPulverisateurById(agentCourant, "1-1-1")
            If objPulverisateur.id <> "" Then
                MsgBox("Ok, pulvé chargé :" & objPulverisateur.marque)
            Else
                MsgBox("Aucun pulvé trouvé pour l'identifiant : 1-1-1")
            End If
        Catch ex As Exception
            CSDebug.dispError("Aucun pulvé trouvé pour l'identifiant : 1-1-1" & ex.Message.ToString)
        End Try
    End Sub

    Private Sub btnWSPulve_send_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWSPulve_send.Click
        Dim objPulverisateur As Pulverisateur = PulverisateurManager.getPulverisateurById("1-1-1")
        Try
            Dim UpdatedObject As Object
            Dim response As Object = PulverisateurManager.sendWSPulverisateur(agentCourant, objPulverisateur, UpdatedObject)
            Select Case response
                Case -1 ' ERROR
                    MsgBox("Erreur - sendWSPulverisateur - Erreur Locale")
                Case 0 ' OK
                    MsgBox("Déjà à jour OK")
                Case 2 ' SENDPROFILAGENT_UPDATE
                    MsgBox("Mise à jour effectuée")
                Case 1 ' NOK
                    MsgBox("Erreur - sendWSPulverisateur - Le web service a répondu : Non-Ok")
                Case 9 ' BADREQUEST
                    MsgBox("Erreur - sendWSPulverisateur - Le web service a répondu : BadRequest")
                Case 3 ' SENDPROFILAGENT_NOAGENT 
                    MsgBox("Erreur - sendWSPulverisateur - Le web service a répondu : SENDPROFILAGENT_NOAGENT")
                Case 2 ' SENDSTRUCTURE_UPDATE 
                    MsgBox("Erreur - sendWSPulverisateur - Le web service a répondu : SENDSTRUCTURE_UPDATE")
                Case 2 ' SENDCLIENT_UPDATE
                    MsgBox("Erreur - sendWSPulverisateur - Le web service a répondu : SENDCLIENT_UPDATE")
                Case 3 ' UPDATESAVAILABLE_NOAGENT
                    MsgBox("Erreur - sendWSPulverisateur - Le web service a répondu : UPDATESAVAILABLE_NOAGENT")
            End Select
        Catch ex As Exception
            MsgBox("Erreur lors de l'envoi")
        End Try
    End Sub

#End Region


#Region " Referentiel "

    Private Sub btnReferentiel_territoire_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReferentiel_territoire.Click
        ReferentielTerritoireManager.getWSReferentielTerritoire()
    End Sub

 
    Private Sub btnReferentiel_pulverisateur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReferentiel_pulverisateur.Click
        ReferentielPulverisateurManager.getWSReferentielPulverisateur()
    End Sub

    Private Sub btnReferentiel_manometre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReferentiel_manometre.Click
        ReferentielManometreManager.getWSReferentielManometre()
    End Sub

#End Region


#Region " Version "

    Private Sub btnVersion_getCur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVersion_getCur.Click
        CSVersion.getWSVersion()
    End Sub

#End Region




#Region " Cryptage / Divers "

    'Cryptage
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        input_cryptResult.Text = CSCrypt.encode(input_crypt.Text, "sha256")
    End Sub

#End Region

    Private Sub newDiagId_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles newDiagId.Click

        'Dim objWSCrodip As WSCrodip1.CrodipServer = New WSCrodip1.CrodipServer
        'Dim curIncrement As Object
        'Dim objWSCrodip_response As Object
        'objWSCrodip_response = objWSCrodip.GetIncrementDiagnostic("agent-1", curIncrement)

        'agentCourant = AgentManager.getAgentById("E001000002")
        agentCourant = AgentManager.getAgentByNumeroNational("agent-1")
        Dim test As String = DiagnosticManager.getNewId(agentCourant)

    End Sub

    Private Sub Button13_Click(sender As System.Object, e As System.EventArgs) Handles Button13.Click
        Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()

        Dim wsResponse As Object
        ' Appel au WS
        Dim codeResponse As Integer = objWSCrodip.GetSoftwareUpdate("201201010000", wsResponse)
        MsgBox("CodeReponse=" & codeResponse)

    End Sub
End Class
