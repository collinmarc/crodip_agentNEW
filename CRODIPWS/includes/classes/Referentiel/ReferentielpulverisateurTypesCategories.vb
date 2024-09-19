Imports System.Web.Services
Imports System.Xml.Serialization
Imports System.IO
Imports System.Net

<Serializable(), XmlInclude(GetType(ReferentielPulverisateurTypesCategories))> _
Public Class ReferentielPulverisateurTypesCategories
    Inherits Referentiel


    Private _libelle As String
    Private _dateDerniereMAJ As String


    Sub New()

    End Sub

    Public Shared ReadOnly Property NomFichier As String
        Get
            Return Environment.CurrentDirectory & "\config\pulverisateurs\types-categories.xml"
        End Get
    End Property
    Public Shared ReadOnly Property DateDerniereModif As Date
        Get
            Try

                Dim infoReader As System.IO.FileInfo
                Dim dateLastWrite As Date
                If File.Exists(NomFichier) Then
                    infoReader = My.Computer.FileSystem.GetFileInfo(NomFichier)
                    dateLastWrite = infoReader.LastWriteTime
                Else
                    dateLastWrite = CDate("01/01/1970")
                End If

                Return dateLastWrite
            Catch ex As Exception
                Return CDate("01/01/1970")
            End Try

        End Get
    End Property

    Public Shared Function SynchroDesc(Optional pDateDerniereModif As String = "", Optional pNomFichier As String = "") As RETOURSYNCHRO
        'Try

        '    Dim strDateDernierModif As String
        '    strDateDernierModif = pDateDerniereModif
        '    If String.IsNullOrEmpty(strDateDernierModif) Then
        '        strDateDernierModif = CSDate.GetDateForWS(DateDerniereModif)
        '    End If
        '    Dim strNomfichier As String
        '    strNomfichier = pNomFichier
        '    If String.IsNullOrEmpty(strNomfichier) Then
        '        strNomfichier = NomFichier
        '    End If
        '    ' déclarations
        '    Dim objWSCrodip As WSCrodip2.CrodipServerClient
        '    objWSCrodip = WebServiceCRODIP.getWS2()

        '    ' Appel au WS
        '    Dim ajour As Integer
        '    Dim pUrl As String
        '    objWSCrodip.GetReferentielPulverisateurTypesCategories(strDateDernierModif, ajour, pUrl)

        '    Select Case ajour
        '        Case 0
        '            ' Récupération du fichier sous forme de tableau de bytes
        '            Dim returnArray() As Byte = GetURLDataBin(pUrl)

        '            bReturn = WriteFile(returnArray, strNomfichier)
        '            If bReturn Then
        '                bReturn = RETOURSYNCHRO.SYNCHRO_EFFECTUEE
        '            Else
        '                bReturn = RETOURSYNCHRO.ERREUR
        '            End If
        '        Case 1
        '            bReturn = RETOURSYNCHRO.PAS_DE_SYNCHRO
        '            'Pas de MAJ , on ne fait Rien
        '    End Select
        'Catch ex As Exception
        '    CSDebug.dispFatal("Erreur - ReferentielPulveristaeurTypesCategories.Synhcrodesc: " & ex.Message)
        '    bReturn = RETOURSYNCHRO.ERREUR
        'End Try
        'Return bReturn
    End Function

End Class