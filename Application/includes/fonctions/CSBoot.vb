Module CSBoot

    ' On d�marre la s�quence d'initialisation du boot
    Public Sub init()
        Try

            setupEnv()
#If DEBUG Then
#Else
            If checkVersion() Then
                If checkPid() Then
                    globFormParent.notify_connexionStatus_nok.Visible = False
                    globFormParent.notify_connexionStatus_ok.Visible = True
                End If
            End If
#End If
        Catch ex As Exception
            CSDebug.dispError("CSBoot.init Err" & ex.Message)
        End Try

    End Sub

#Region " Boot Stages "

#Region " Tests "

    ' On test si l'appli a bien la version minimum requise
    Private Function checkVersion() As Boolean
        Dim bReturn As Boolean
        Try
            bReturn = True
            If Globals.GLOB_NETWORKAVAILABLE Then
                If CSEnvironnement.checkWebService Then
                    If CSEnvironnement.checkVersion = False Then
                        MsgBox(CSEnvironnement.versionMessage & vbNewLine & CSEnvironnement.versionUrl)
                        bReturn = False
                    End If
                End If
            Else
                bReturn = True
            End If
        Catch ex As Exception
            CSDebug.dispError("CSBoot.CheckVersion Err :" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    ' On test si l'appli n'est pas d�j� lanc�e
    Private Function checkPid() As Boolean

        If CSEnvironnement.existsPid() Then
            If MsgBox("Une instance de l'application est d�j� en cours sur cette machine. Voulez-vous vraiment continuer le d�marrage ?", MsgBoxStyle.YesNo, "Crodip .::. Attention !") = MsgBoxResult.Yes Then
                CSEnvironnement.forcePid()
                Return True
            Else
                globFormParent.Close()
                Return False
            End If
        Else
            CSEnvironnement.setPid()
            Return True
        End If
    End Function


#End Region

#Region " GUI "

    Private Function setupEnv() As Boolean
        Dim bReturn As Boolean
        Try

            ' On initialise le controlleur de la statusbar
            Statusbar = New CSStatusbar(globFormParent.parentContener_statusBar, globFormParent.statusBar_img_loader)
            ' On place les icone de la barre des t�ches en session
            globConnectFlagOk = globFormParent.notify_connexionStatus_ok
            globConnectFlagNok = globFormParent.notify_connexionStatus_nok
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("CSBoot.SetupEnv " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

#End Region

#End Region
End Module
