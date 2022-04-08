Imports System.Threading
Imports System.IO
Imports System

Public Class mainForm
    Inherits System.Windows.Forms.Form

#Region " === CODES D'ERREURS === "
    '0x000001	=	Erreur lors du démarrage du Logiciel Agent après mise à jour.
    '0x000002	=	Erreur lors du redémarrage du Logiciel Agent après mise à jour.
    '0x000003	=	Erreur lors de la création du dossier de destination temporaire.
    '0x000004	=	Erreur lors de la récupération de la version courante.
    '0x000005	=	Erreur lors de l'appel au WS pour récupérer les mises à jour.
    '0x000006	=	Erreur lors de l'execution d'une mise à jour de BDD.
    '0x000007	=	Erreur générale lors de la mise à jour de la BDD.
    '0x000008	=	Erreur lors du téléchargement des mises à jour.
    '0x000009	=	Erreur lors de la copie des fichiers téléchargés.
    '0x000010	=	Erreur lors de la copie des fichiers d'un dossier.
    '0x000011	=	Erreur lors de la copie des sous-dossiers d'un répertoire.
    '0x000012	=	Erreur lors de la suppression des fichiers temporaires.
    '0x000013	=	Erreur lors de la fermeture du Logiciel Agent.
    '0x000014	=	Erreur CSDb survenue lors de l'execution de la requête.
    '0x000015	=	Erreur CSDb survenue lors de la sécurisation du query.
    '0x000016	=	Erreur lors de la suppression d'un fichier mis à jour.
    '0x000017	=	
    '0x000018	=	
    '0x000019	=	
    '0x000020	=	
#End Region

#Region " VARIABLES "

    'Dim iterations As Integer = 100000
    Dim curProgressbar As ProgressBar = progressBar_download

    Dim path_target As String = Environment.CurrentDirectory & "\"
    Dim path_tempTarget As String = Environment.CurrentDirectory & "\tmp\update\"

    Dim majFileSuffix_orig As String = ".updated.old"
    Dim majFileSuffix As String = majFileSuffix_orig

    Private _wsdl As Object
    Public infosUpdate As UpdateInfo
    Public returnCode As Integer

    Private m_curVersion As String = ""
    Private m_urlTest As String
    Private m_urlProd As String
    Friend WithEvents btn_OK As System.Windows.Forms.Button
    Friend WithEvents btn_Fermer As System.Windows.Forms.Button
    Friend WithEvents Lbl_Version As System.Windows.Forms.Label
    Private m_UseProd As Boolean
    Private m_Except100Continue As Boolean


#End Region


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
    Friend WithEvents title_mesInfos As System.Windows.Forms.Label
    Friend WithEvents progressBar_download As System.Windows.Forms.ProgressBar
    Friend WithEvents lbl_progressBar_download As System.Windows.Forms.Label
    Friend WithEvents lbl_Files As System.Windows.Forms.Label
    Friend WithEvents progressBar_files As System.Windows.Forms.ProgressBar
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mainForm))
        Me.title_mesInfos = New System.Windows.Forms.Label()
        Me.progressBar_download = New System.Windows.Forms.ProgressBar()
        Me.lbl_progressBar_download = New System.Windows.Forms.Label()
        Me.lbl_Files = New System.Windows.Forms.Label()
        Me.progressBar_files = New System.Windows.Forms.ProgressBar()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btn_OK = New System.Windows.Forms.Button()
        Me.btn_Fermer = New System.Windows.Forms.Button()
        Me.Lbl_Version = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'title_mesInfos
        '
        Me.title_mesInfos.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title_mesInfos.ForeColor = System.Drawing.Color.White
        Me.title_mesInfos.Image = CType(resources.GetObject("title_mesInfos.Image"), System.Drawing.Image)
        Me.title_mesInfos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.title_mesInfos.Location = New System.Drawing.Point(104, 8)
        Me.title_mesInfos.Name = "title_mesInfos"
        Me.title_mesInfos.Size = New System.Drawing.Size(400, 24)
        Me.title_mesInfos.TabIndex = 1
        Me.title_mesInfos.Text = "     Gestionnaire de mises à jour"
        '
        'progressBar_download
        '
        Me.progressBar_download.Location = New System.Drawing.Point(104, 92)
        Me.progressBar_download.Maximum = 10
        Me.progressBar_download.Name = "progressBar_download"
        Me.progressBar_download.Size = New System.Drawing.Size(400, 23)
        Me.progressBar_download.TabIndex = 2
        '
        'lbl_progressBar_download
        '
        Me.lbl_progressBar_download.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_progressBar_download.ForeColor = System.Drawing.Color.White
        Me.lbl_progressBar_download.Location = New System.Drawing.Point(104, 76)
        Me.lbl_progressBar_download.Name = "lbl_progressBar_download"
        Me.lbl_progressBar_download.Size = New System.Drawing.Size(400, 16)
        Me.lbl_progressBar_download.TabIndex = 3
        Me.lbl_progressBar_download.Text = "Cliquer sur OK pour démarer la mise à jour"
        '
        'lbl_Files
        '
        Me.lbl_Files.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Files.ForeColor = System.Drawing.Color.White
        Me.lbl_Files.Location = New System.Drawing.Point(104, 127)
        Me.lbl_Files.Name = "lbl_Files"
        Me.lbl_Files.Size = New System.Drawing.Size(400, 16)
        Me.lbl_Files.TabIndex = 3
        '
        'progressBar_files
        '
        Me.progressBar_files.Location = New System.Drawing.Point(104, 146)
        Me.progressBar_files.Name = "progressBar_files"
        Me.progressBar_files.Size = New System.Drawing.Size(400, 23)
        Me.progressBar_files.TabIndex = 2
        Me.progressBar_files.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(8, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(76, 84)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 34
        Me.PictureBox1.TabStop = False
        '
        'btn_OK
        '
        Me.btn_OK.BackColor = System.Drawing.SystemColors.Control
        Me.btn_OK.Location = New System.Drawing.Point(346, 175)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(74, 26)
        Me.btn_OK.TabIndex = 35
        Me.btn_OK.Text = "OK"
        Me.btn_OK.UseVisualStyleBackColor = False
        '
        'btn_Fermer
        '
        Me.btn_Fermer.BackColor = System.Drawing.SystemColors.Control
        Me.btn_Fermer.Enabled = False
        Me.btn_Fermer.Location = New System.Drawing.Point(432, 175)
        Me.btn_Fermer.Name = "btn_Fermer"
        Me.btn_Fermer.Size = New System.Drawing.Size(72, 25)
        Me.btn_Fermer.TabIndex = 36
        Me.btn_Fermer.Text = "Poursuivre"
        Me.btn_Fermer.UseVisualStyleBackColor = False
        '
        'Lbl_Version
        '
        Me.Lbl_Version.AutoSize = True
        Me.Lbl_Version.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Lbl_Version.ForeColor = System.Drawing.Color.White
        Me.Lbl_Version.Location = New System.Drawing.Point(101, 40)
        Me.Lbl_Version.Name = "Lbl_Version"
        Me.Lbl_Version.Size = New System.Drawing.Size(45, 13)
        Me.Lbl_Version.TabIndex = 37
        Me.Lbl_Version.Text = "Label1"
        '
        'mainForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(512, 210)
        Me.ControlBox = False
        Me.Controls.Add(Me.Lbl_Version)
        Me.Controls.Add(Me.btn_Fermer)
        Me.Controls.Add(Me.btn_OK)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.progressBar_download)
        Me.Controls.Add(Me.title_mesInfos)
        Me.Controls.Add(Me.lbl_progressBar_download)
        Me.Controls.Add(Me.lbl_Files)
        Me.Controls.Add(Me.progressBar_files)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "mainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crodip - Gestionnaire de mises à jour"
        Me.TopMost = True
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region




#Region " Functions PUBLIQUES "

    ' Mise à jour du logiciel
    'Private _thread_majSoftware As Thread'
    Private Sub majVersion()
        Dim bReturn As Boolean

        Try
            'Initialisation
            Me.progressBar_download.Value = Me.progressBar_download.Minimum
            lbl_progressBar_download.Text = "Initialisation ..."
            Me.Refresh()
            If Not init() Then
                Exit Sub
            End If
            ' Préparation des mises à jour en cours...
            Me.progressBar_download.Value = Me.progressBar_download.Value + 1
            lbl_progressBar_download.Text = "Préparation des mises à jour en cours..."
            Me.Refresh()
            _majPrepare()



            Me.progressBar_download.Value = Me.progressBar_download.Value + 1
            ' Vérification des mises à jour en cours...
            lbl_progressBar_download.Text = "Vérification des mises à jour en cours..."
            Me.Refresh()
            Dim needToUpdate As Boolean = _majCheck()
            bReturn = False
            If needToUpdate Then
                If My.Settings.downloadUpdates Then
                    ' Téléchargement des mises à jour en cours...
                    lbl_progressBar_download.Text = "Téléchargement des mises à jour en cours..."
                    Me.progressBar_download.Value = Me.progressBar_download.Value + 1
                    Me.Refresh()
                    bReturn = _majDownload()
                Else
                    bReturn = True
                End If
                If bReturn Then
                    If My.Settings.installUpdates Then

                        ' Installation des mises à jour en cours...
                        lbl_progressBar_download.Text = "Installation des mises à jour en cours..."
                        Me.progressBar_download.Value = Me.progressBar_download.Value + 1
                        Me.Refresh()
                        _majSoftware()
                    End If
                    If My.Settings.DatabaseUpdates Then
                        ' Récupération des mises à jour de la BDD
                        lbl_progressBar_download.Text = "Mise à jour de la base de données..."
                        Me.progressBar_download.Value = Me.progressBar_download.Value + 1
                        Me.Refresh()
                        _majDatabase()
                    End If

                    ' Mise à jour terminée
                    lbl_progressBar_download.Text = "Mise à jour terminée. Cliquer sur Poursuivre pour démarer le logiciel"
                    Me.Refresh()
                Else
                    ' Mise à jour terminée
                    lbl_progressBar_download.Text = "Des erreurs sont survenues durant la mise à jour. Cliquer sur Poursuivre pour relancer la mise à jour et contacter le CRODIP si cela se reproduit"
                    Me.Refresh()
                End If


            Else

                ' Aucune mise à jour disponible
                lbl_progressBar_download.Text = "Aucune mise à jour disponible."

            End If
                Me.progressBar_download.Value = Me.progressBar_download.Maximum


        Catch ex As Exception
            MsgBox("majversion : Une erreur est survenue durant la tentative de mise à jour.  Veuillez recommencer." & ex.Message)
        End Try

    End Sub

#End Region


#Region " Functions PRIVEES "

    ' Vérifications pre-update
    Private Sub _majPrepare()
        ' On vérifie qu'on est bien dans le dossier du logiciel agent
        If Not File.Exists(My.Settings.logicielAgent_fileName) Then
            MsgBox("Logiciel Agent introuvable dans le dossier.", MsgBoxStyle.Critical)
            Close()
        End If

        ' On vérifie que le dossier temporaire existe bien
        Try
            If Not Directory.Exists(path_tempTarget) Then
                MkDir(path_tempTarget)
            End If
        Catch ex As Exception
            CSDebug.dispError("Err 0x000003 : " & ex.Message.ToString)
        End Try



    End Sub

    ' Vérification des mises à jour

    Private Function _majCheck() As Boolean
        Dim returnVal As Boolean = False
        '#########################################################

        Try
            If My.Settings.chekUpdates = "WS" Then
                'Si le paramètre est à WS on demande la réponse par WebServices
                Dim wsResponse As Object = Nothing
                ' Appel au WS
                Me.returnCode = Me._wsdl.GetSoftwareUpdate(Me.m_curVersion, wsResponse)

                If Me.returnCode = 2 Then
                    returnVal = True
                    Me.infosUpdate = New UpdateInfo(wsResponse)
                    Me.Lbl_Version.Text = "Version Cible : " & Me.infosUpdate.version
                    Me.Refresh()

                End If
            Else
                'Sinon on prend la réponse indiquée dans le fichier de conf
                returnVal = CBool(My.Settings.chekUpdates)
                If returnVal Then
                    Me.infosUpdate = New UpdateInfo()
                    Me.infosUpdate.hasSql = True
                    Me.Lbl_Version.Text = "Version Cible : " & Me.infosUpdate.version
                    Me.Refresh()

                End If
            End If

        Catch ex As Exception
            CSDebug.dispError("Err 0x000005 : " & ex.Message.ToString)
        End Try

        '#########################################################
        Return returnVal
    End Function

    ' Récupération et installation des mises à jour de la base de données
    Private Function _majDatabase() As Boolean
        Dim bReturn As Boolean
        Try
            If Me.infosUpdate.hasSql Then
                Dim Processus As New System.Diagnostics.Process
                Processus.StartInfo.FileName = "DBUpdate.exe"
                Processus.Start()
                Processus.WaitForExit()
            End If
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("Crodip_updater.Main._majDatabase ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    ' Téléchargement des mises à jour
    Private Function _majDownload() As Boolean
        Dim bReturn As Boolean

        lbl_Files.Visible = True
        progressBar_files.Visible = True
        '#########################################################
        Try
            ' On instancie le gestionnaire de downloads
            Dim downloader As New DownloadManager(Me.infosUpdate.files, path_tempTarget, Me.infosUpdate.baseUrl)

            ' Ajout des composants
            downloader.setControles(lbl_Files, progressBar_files)

            bReturn = downloader.doDownload()

        Catch ex As Exception
            CSDebug.dispError("MainForm._majDownload : " & ex.Message.ToString)
            bReturn = False
        End Try
        '#########################################################
        Return bReturn
    End Function

    ' Installation des mises à jour
    Private Sub _majSoftware()

        ' On parcourt le repertoire temporaire des fichiers téléchargés
        Dim nbElements As Integer = Directory.GetFiles(Me.path_tempTarget).Length() + Directory.GetDirectories(Me.path_tempTarget).Length
        progressBar_files.Value = 0
        progressBar_files.Maximum = Me.infosUpdate.files.Length

        ' Copie des fichiers/dossiers
        Try
            Me._majSoftware_copyDirContent(Me.path_tempTarget, Me.path_target, progressBar_download)
        Catch ex As Exception
            CSDebug.dispError("Crodip_Updater.Main._majSoftware : " & ex.Message.ToString)
        End Try

    End Sub
    Private Sub _majSoftware_copyDirContent(ByVal srcDir As String, ByVal targetDir As String, ByVal progressBar_download As ProgressBar)

        ' On commence par copier les fichiers
        'Try
        For Each tmpFile As String In Directory.GetFiles(srcDir)
            majFileSuffix = majFileSuffix_orig
            Dim newFile As String = tmpFile.Replace(srcDir, "")
            Dim hasMoved As Boolean = False
            Dim nbTentatives As Integer = 0
            Try
                File.OpenWrite(targetDir & newFile & majFileSuffix)
            Catch ex As Exception
                CSDebug.dispError("CrodipUpdater.Main._majSoftware_copyDirContent ERR : " & ex.Message.ToString)
            End Try
            If File.Exists(targetDir & newFile) Then
retryOldFile:
                If File.Exists(targetDir & newFile & majFileSuffix) Then
                    Try
                        File.Delete(targetDir & newFile & majFileSuffix)
                    Catch ex As Exception
                        nbTentatives += 1
                        If nbTentatives <= 10 Then
                            majFileSuffix &= nbTentatives
                            GoTo retryOldFile
                        End If
                    End Try
                End If
                File.Move(targetDir & newFile, targetDir & newFile & majFileSuffix)
                hasMoved = True
            End If
            Try

                CSDebug.dispInfo("CrodipUpdater.Main._majSoftware_copyDirContent : Copie de " & tmpFile & " vers" & targetDir & newFile)
                File.Move(tmpFile, targetDir & newFile)
            Catch ex As Exception
                CSDebug.dispError("CrodipUpdater.Main._majSoftware_copyDirContent MOVE : " & ex.Message.ToString)
            End Try

            If hasMoved Then
                Try
                    File.Delete(targetDir & newFile & majFileSuffix)
                Catch ex As Exception
                    CSDebug.dispError("CrodipUpdater.Main._majSoftware_copyDirContent 2 : " & ex.Message.ToString)
                End Try
            End If
            ' ProgressBar
            progressBar_files.Value += 1
        Next
        'Catch ex As Exception
        '    CSDebug.dispError("Err 0x0000010 : " & ex.Message.ToString)
        'End Try

        ' Puis on traite les dossiers
        For Each tmpDir As String In Directory.GetDirectories(srcDir)
            Try
                Dim newDir As String = tmpDir.Replace(srcDir, "")
                If Directory.Exists(targetDir & newDir) Then
                    Me._majSoftware_copyDirContent(tmpDir, targetDir & newDir, progressBar_download)
                Else
                    Directory.Move(tmpDir, targetDir & newDir)
                End If
            Catch ex As Exception
                CSDebug.dispError("CrodipUpdater.Main._majSoftware_copyDirContent 3 : (" & tmpDir & ")" & ex.Message.ToString)
            End Try
        Next

        ' On supprime le dossier vidé
        Try
            Directory.Delete(srcDir)
        Catch ex As Exception
            CSDebug.dispError("CrodipUpdater.Main._majSoftware_copyDirContent 4 : " & ex.Message.ToString)
        End Try

    End Sub

#End Region

    Private Sub btn_OK_Click(sender As System.Object, e As System.EventArgs) Handles btn_OK.Click
        ' Lancement du programme
        Try
            Me.Cursor = Cursors.WaitCursor
            btn_OK.Enabled = False
            majVersion()
            btn_OK.Enabled = False
            btn_Fermer.Enabled = True
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            MsgBox("btn_OK_Click:Une erreur est survenue durant la tentative de mise à jour.  Veuillez recommencez.")
        End Try

    End Sub

    Private Sub btn_Fermer_Click(sender As System.Object, e As System.EventArgs) Handles btn_Fermer.Click
        Me.Close()
    End Sub

    Private Function init() As Boolean

        Dim doc As New System.Xml.XmlDocument
        Dim oNode As Xml.XmlNode
        Dim MySettings1 As String = "Crodip_agent.MySettings"
        Dim MySettings2 As String = "Crodip_agent.My.MySettings"
        Dim strXPathModelMy As String = "/configuration/applicationSettings/[MYSETTINGS]"
        Dim strXPathModel As String = "/configuration/applicationSettings/[MYSETTINGS]/setting[@name='%value%']/value"
        Dim strXPathModelUser As String = "/configuration/userSettings/[MYSETTINGS]/setting[@name='%value%']/value"
        Dim strXpath As String
        Dim bReturn As Boolean
        Try

            'Récupération du fichier de config du logiciel Agent

            Me.Cursor = Cursors.WaitCursor
            Me.path_tempTarget = Environment.CurrentDirectory & My.Settings.path_target_tmp_path
            Me.majFileSuffix = My.Settings.file_suffixe
            doc.Load(Environment.CurrentDirectory & "/Logiciel Crodip Agent.exe.config")

            'Test du Nom de MySettings
            strXpath = strXPathModelMy.Replace("[MYSETTINGS]", MySettings1)
            oNode = doc.SelectSingleNode(strXpath)
            If oNode Is Nothing Then
                strXpath = strXPathModelMy.Replace("[MYSETTINGS]", MySettings2)
                oNode = doc.SelectSingleNode(strXpath)
                If oNode Is Nothing Then
                    'ERROR
                    Exit Function
                Else
                    'On Utilise le modèle 2
                    strXPathModel = strXPathModel.Replace("[MYSETTINGS]", MySettings2)
                    strXPathModelUser = strXPathModelUser.Replace("[MYSETTINGS]", MySettings2)

                End If
            Else
                'On Utilise le modèle 1
                strXPathModel = strXPathModel.Replace("[MYSETTINGS]", MySettings1)
                strXPathModelUser = strXPathModelUser.Replace("[MYSETTINGS]", MySettings1)
            End If

            strXpath = strXPathModel.Replace("%value%", "NumBuild")
            oNode = doc.SelectSingleNode(strXpath)
            m_curVersion = oNode.InnerText()
            If oNode Is Nothing Then

            End If

            strXpath = strXPathModel.Replace("%value%", "WSCrodipURLTEST")
            oNode = doc.SelectSingleNode(strXpath)
            m_urlTest = oNode.InnerText()

            strXpath = strXPathModel.Replace("%value%", "WSCrodipURL")
            oNode = doc.SelectSingleNode(strXpath)
            m_urlProd = oNode.InnerText()

            strXpath = strXPathModel.Replace("%value%", "WSCrodipProduction")
            oNode = doc.SelectSingleNode(strXpath)
            m_UseProd = True
            If Not oNode Is Nothing Then
                m_UseProd = oNode.InnerText().ToUpper().Trim().Equals("TRUE")
            End If
#If DEBUG Then
            'En Debug on Force à False => utilisation du serveur de PréProd
            m_UseProd = False
#End If

            strXpath = strXPathModelUser.Replace("%value%", "Expect100Continue")
            oNode = doc.SelectSingleNode(strXpath)
            m_Except100Continue = True
            If Not oNode Is Nothing Then
                m_Except100Continue = oNode.InnerText().ToUpper().Trim().Equals("TRUE")
            End If
            'Définition du Serveur (on ne peut pas appeller l'objet du logiciel Agent)
            Dim oWS As WSCrodip_dev.CrodipServer
            oWS = New WSCrodip_dev.CrodipServer
            If m_UseProd Then
                oWS.Url = m_urlProd
            Else
                oWS.Url = m_urlTest
            End If
            Me._wsdl = oWS
            System.Net.ServicePointManager.Expect100Continue = m_Except100Continue
            Me.Cursor = Cursors.Default
            bReturn = True
        Catch ex As Exception
            MsgBox("Init : Une erreur est survenue durant la tentative de mise à jour.  Veuillez recommencer." & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Private Sub mainForm_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.Lbl_Version.Text = ""
        Dim oAss As System.Reflection.Assembly
        oAss = System.Reflection.Assembly.GetExecutingAssembly()
        Dim fvi As FileVersionInfo = FileVersionInfo.GetVersionInfo(oAss.Location)
        Dim version As String = " v " & fvi.FileVersion
        Me.Text = Me.Text & version
    End Sub
End Class
