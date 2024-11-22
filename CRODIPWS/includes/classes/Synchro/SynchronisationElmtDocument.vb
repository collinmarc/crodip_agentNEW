Public Class SynchronisationElmtDocument
    Inherits SynchronisationElmt

    Public Shared Function getLabelGet() As String
        Return "GetDocument"
    End Function

    Public Sub New()

        MyBase.New(getLabelGet(), New SynchroBooleans)
    End Sub
    Public Sub New(pSynchroBoolean As SynchroBooleans)
        MyBase.New(getLabelGet(), pSynchroBoolean)
    End Sub
    Public Sub New(pNomFichier As String, purlDistante As String, pSynchroBoolean As SynchroBooleans)
        MyBase.New(getLabelGet(), pSynchroBoolean)
        identifiantEntier = 0
        identifiantChaine = pNomFichier
        valeurAuxiliaire = purlDistante
    End Sub
    ''' <summary>
    ''' Synchropnisation descendante d'un élément du module documentaire
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function SynchroDesc(pAgent As Agent) As Boolean
        Dim bReturn As Boolean
        Try
            'Le nom du fichier est stocké dans identifiantChaine
            'L'url dans ValeurAuxiliaire
            'Path de base du moduleDocumentaire
            Dim pathRoot As String = GlobalsCRODIP.GLOB_PARAM_ModuleDocumentaire
            Dim targetPath As String
            Dim strFilename As String ' only the filenaame
            If Me.identifiantChaine.StartsWith("/") Then
                targetPath = pathRoot & Me.identifiantChaine
            Else
                targetPath = pathRoot & "/" & Me.identifiantChaine
            End If
            If Me.identifiantChaine.LastIndexOf("/") > 0 Then
                strFilename = Me.identifiantChaine.Substring(Me.identifiantChaine.LastIndexOf("/") + 1)
            Else
                strFilename = Me.identifiantChaine
            End If
            'Suppression du Fichier de destination
            If System.IO.File.Exists(targetPath & ".temp") Then
                System.IO.File.Delete(targetPath & ".temp")
            End If
            '============
            'Telechargement du fichier si ce n'est pas un suppression et qu'il est marqué comme à télécharger
            '=============
            If Me.update And Not targetPath.ToUpper().Contains(".DLT") Then
                My.Computer.Network.DownloadFile(Me.valeurAuxiliaire, targetPath & ".temp")
                bReturn = True
                'Suppression du fichier .old
                If System.IO.File.Exists(targetPath) Then
                    If System.IO.File.Exists(targetPath & ".old") Then
                        System.IO.File.Delete(targetPath & ".old")
                    End If
                    'Renomer le fichier en .old
                    My.Computer.FileSystem.RenameFile(targetPath, strFilename & ".old")
                End If
                'Renomer le fichier .temp 
                If System.IO.File.Exists(targetPath & ".temp") Then
                    My.Computer.FileSystem.RenameFile(targetPath & ".temp", strFilename)
                End If
            End If
            '==========================
            'SUPPRESSION DES FICHIERS
            '==========================
            If targetPath.ToUpper().Contains(".DLT") Then
                'Suppression des elements
                Dim tabString As String()
                tabString = targetPath.Split("/")
                Dim strPathElement As String = ""
                For Each strElment As String In tabString
                    If strElment.ToUpper().EndsWith(".DLT") Then
                        Dim strElmentOrigin As String = strPathElement + "/" + strElment.ToUpper().Replace(".DLT", "")

                        'Suppression du fichier d'origine
                        If System.IO.File.Exists(strElmentOrigin) Then
                            System.IO.File.Delete(strElmentOrigin)
                            'Suppression du fichier .DLT
                            If System.IO.File.Exists(strFilename) Then
                                System.IO.File.Delete(strFilename)
                            End If
                            Exit For
                        End If
                        If System.IO.Directory.Exists(strElmentOrigin) Then
                            System.IO.Directory.Delete(strElmentOrigin, True)
                            Exit For
                        End If

                    End If
                    strPathElement = IIf(String.IsNullOrEmpty(strPathElement), "", strPathElement + "/") + strElment
                Next
            End If
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("SynchroElementDocument.synchroDesc ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Overloads Function synchroAsc() As Boolean
        Dim bReturn As Boolean
        Try
            CSDebug.dispError("Pas de synchro Ascendante des documents")
            bReturn = False
        Catch ex As Exception
            CSDebug.dispError("SynchroElementDocument.synchroAsc ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    ''' <summary>
    ''' Traitement particulier du Update pour le module documentaire
    ''' Si le fichier n'existe pas en Local => Update est True
    ''' </summary>
    ''' <param name="PNAme"></param>
    ''' <param name="pValue"></param>
    ''' <returns></returns>
    Public Overrides Function Fill(ByVal PNAme As String, ByVal pValue As String) As Boolean
        Dim bReturn As Boolean

        bReturn = MyBase.Fill(PNAme, pValue)

        If PNAme.ToUpper.Trim() = "update".ToUpper.Trim() Then
            'Le nom du fichier est stocké dans identifiantChaine
            'L'url dans ValeurAuxiliaire
            'Path de base du moduleDocumentaire
            Dim pathRoot As String = GlobalsCRODIP.GLOB_PARAM_ModuleDocumentaire
            Dim targetPath As String
            Dim strFilename As String ' only the filenaame
            If Me.identifiantChaine.StartsWith("/") Then
                targetPath = pathRoot & Me.identifiantChaine
            Else
                targetPath = pathRoot & "/" & Me.identifiantChaine
            End If
            If Me.identifiantChaine.LastIndexOf("/") > 0 Then
                strFilename = Me.identifiantChaine.Substring(Me.identifiantChaine.LastIndexOf("/") + 1)
            Else
                strFilename = Me.identifiantChaine
            End If
            'Si le fichier n'existe pas en local , il faut le télécharger
            If Not System.IO.File.Exists(targetPath) And Not targetPath.ToUpper().Contains(".DLT") Then
                Me.update = True
            End If
        End If
        Return bReturn
    End Function

End Class
