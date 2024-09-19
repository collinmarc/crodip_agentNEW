Public Class CSDiagPdf

    Public Shared TYPE_SYNTHESE_MESURES As String = "SM"
    Public Shared TYPE_CONTRAT_COMMERCIAL As String = "CC"
    Public Shared TYPE_RAPPORT_INSPECTION As String = "RI"
    Public Shared TYPE_BON_LIVRAISON As String = "BL"
    Public Shared TYPE_FEUILLE_PEDAGOGIQUE As String = "FP"
    Public Shared TYPE_FEUILLE_ENQSAT As String = "ES"
    Public Shared TYPE_FACTURE As String = "FACTURE"
    Public Shared TYPE_FV_MANOCTRL As String = "FVMC"
    Public Shared TYPE_FV_BANCMESURE As String = "FVBM"
    Public Shared TYPE_FV_RP As String = "RP"
    Public Shared TYPE_DOC_COPROP As String = "CO"

    ' Retourne le nom du fichier � g�n�rer en fonction du pulve et du type de document
    ' FORMAT : [Ymd]_[idPulve]_[nomProprio]_[CC|RI|BL|FP].pdf
    Public Shared Function makeFilename(ByVal pulveId As String, ByVal typeDoc As String) As String
        Dim fileName As String = ""
        '##########################################################
        If typeDoc = TYPE_FV_MANOCTRL Or typeDoc = TYPE_FV_BANCMESURE Or typeDoc = TYPE_FV_RP Then

            ' On formatte le nom du fichier
            Dim midName As String = ""
            Select Case typeDoc
                Case TYPE_FV_MANOCTRL
                    midName = "MANOMETRECONTROLE"
                Case TYPE_FV_BANCMESURE
                    midName = "BANCMESURE"
                Case TYPE_FV_RP
                    midName = "REGLAGEPULVE"
            End Select
            fileName = Format(Date.Now, "yyyyMMddhhmmss") & "_" & midName & "_" & pulveId

        Else
            Dim PulveNumNat As String = ""
            Dim RSExploit As String = ""
            ' On r�cup�re le pulve
            Dim pulve As Pulverisateur = PulverisateurManager.getPulverisateurById(pulveId)
            If Not String.IsNullOrEmpty(pulve.id) Then
                PulveNumNat = pulve.numeroNational
                Dim oExploit As Exploitation
                oExploit = ExploitationManager.GetExploitationByPulverisateurId(pulveId)
                If Not String.IsNullOrEmpty(oExploit.id) Then
                    RSExploit = oExploit.raisonSociale
                End If
            End If
            ' On formatte le nom du fichier
            fileName = Format(Date.Now, "yyyyMMddhhmmss") & "_" & pulve.numeroNational & "_" & CSDiagPdf.cleanString(RSExploit) & "_" & typeDoc

        End If
        '##########################################################
        Return fileName
    End Function

    ' Nettoie une chaine pour etre utilis�e comme nom de fichier
    Public Shared Function cleanString(ByVal chaine As String) As String
        chaine = chaine.Replace("�", "e").Trim
        chaine = chaine.Replace("�", "e").Trim
        chaine = chaine.Replace("�", "a").Trim
        chaine = chaine.Replace("�", "i").Trim
        chaine = chaine.Replace("�", "e").Trim
        chaine = chaine.Replace("�", "o").Trim
        chaine = chaine.Replace("�", "c").Trim
        chaine = chaine.Replace("�", "u").Trim
        chaine = chaine.Replace("�", "u").Trim
        chaine = chaine.ToUpper.Replace("'", "").Trim
        chaine = chaine.ToUpper.Replace("/", "").Trim
        chaine = chaine.ToUpper.Replace("\", "").Trim
        chaine = chaine.ToUpper.Replace(" ", "_").Trim
        chaine = chaine.ToUpper.Replace("�", "e").Trim
        chaine = chaine.ToUpper.Replace("�", "e").Trim
        chaine = chaine.ToUpper.Replace("�", "a").Trim
        chaine = chaine.ToUpper.Replace("�", "i").Trim
        chaine = chaine.ToUpper.Replace("�", "e").Trim
        chaine = chaine.ToUpper.Replace("�", "o").Trim
        chaine = chaine.ToUpper.Replace("�", "c").Trim
        chaine = chaine.ToUpper.Replace("�", "u").Trim
        chaine = chaine.ToUpper.Replace("�", "u").Trim
        chaine = chaine.ToUpper.Replace("�", "u").Trim
        Dim aOctets As Byte() = System.Text.Encoding.GetEncoding(1251).GetBytes(chaine)
        chaine = System.Text.Encoding.ASCII.GetString(aOctets)
        Return chaine
    End Function

End Class
