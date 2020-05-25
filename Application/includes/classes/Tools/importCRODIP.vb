Imports System.Collections.Generic
Imports System.IO
Imports CsvHelper
Imports System.Linq
Imports System.Reflection

Public Class importCRODIP
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.EXPLOITATION)>
    Public Property id As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.EXPLOITATION)>
    Public Property numeroSiren As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.EXPLOITATION)>
    Public Property codeApe As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.EXPLOITATION)>
    Public Property raisonSociale As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.EXPLOITATION)>
    Public Property nomExploitant As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.EXPLOITATION)>
    Public Property prenomExploitant As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.EXPLOITATION)>
    Public Property adresse As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.EXPLOITATION)>
    Public Property codePostal As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.EXPLOITATION)>
    Public Property commune As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.EXPLOITATION)>
    Public Property codeInsee As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.EXPLOITATION)>
    Public Property telephonePortable As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.EXPLOITATION)>
    Public Property telephoneFax As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.EXPLOITATION)>
    Public Property eMail As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property numeroNational As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property type As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property marque As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property modele As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property anneeAchat As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property attelage As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property capacite As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property largeur As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR, "nombreRangs")>
    Public Property nombrerangs As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property largeurPlantation As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property surfaceParAn As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property nombreUtilisateurs As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property isVentilateur As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property isDebrayage As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property isCuveRincage As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property capaciteCuveRincage As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property isRotobuse As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property isCuveIncorporation As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property isRinceBidon As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property isBidonLaveMain As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property isLanceLavage As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property nombreBuses As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property buseIsIso As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property buseMarque As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property buseType As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property buseFonctionnement As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property buseAge As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property buseAngle As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property manometreMarque As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property manometreType As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property manometreFondEchelle As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property manometreDiametre As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property manometrePressionTravail As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.DIAGNOSTIC)>
    Public Property controleEtat As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property dateProchainControle As String

    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.DIAGNOSTIC, "controleDateDebut")>
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.DIAGNOSTIC, "controleDateFin")>
    Public Property dateControle As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property emplacementIdentification As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property ancienIdentifiant As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property isEclairageRampe As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property isBarreGuidage As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property isCoupureAutoTroncons As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property isRincageAutoAssiste As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property buseModele As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property buseNbniveaux As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property manometreNbniveaux As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property manometreNbtroncons As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property buseCouleur As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property regulation As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property regulationOptions As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property modeUtilisation As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property nombreExploitants As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property categorie As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property pulverisation As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property isAspirationExt As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property isDispoAntiRetour As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property isReglageAutoHauteur As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property isFiltrationAspiration As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property isFiltrationRefoulement As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property isFiltrationTroncons As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property isFiltrationBuses As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property isPulveAdditionnel As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property pulvePrincipalNumNat As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property isRincagecircuit As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR, "IsPompesDoseuses")>
    Public Property isPompesDoseuses As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR, "nbPompesDoseuses")>
    Public Property nbPompesDoseuses As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property numChassis As String
    ''le numéro de chassis diagnostic est le même que le chassis pulve
    '<importCrodipAtt(importCrodipAtt.enumCRODIPClass.DIAGNOSTIC, "pulverisateurNumChassis")>
    'Public Property numchassisD() As String
    '    Get
    '        Return numchassis
    '    End Get
    '    Set(ByVal value As String)
    '        numchassis = value
    '    End Set
    'End Property
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.DIAGNOSTIC, "origineDiag")>
    Public Property OrigineDiag As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.DIAGNOSTIC)>
    Public Property isATGIP As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.DIAGNOSTIC)>
    Public Property isFacture As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.DIAGNOSTIC)>
    Public Property controleIsComplet As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.DIAGNOSTIC)>
    Public Property typeDiagnostic As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.EXPLOITATION)>
    Public Property telephoneFixe As String



    Public Shared Function import(pfileName As String, pAgent As Agent, Optional pBgwrk As System.ComponentModel.BackgroundWorker = Nothing) As ImportCrodipResult
        Dim oresult As New ImportCrodipResult()
        Dim olstCrodipAtt As New List(Of importCrodipAtt)()

        'Initialisation du tableau des propriétés de importCROPIP
        Dim mytype As Type = GetType(importCRODIP)
        Dim oTabProp As Reflection.PropertyInfo() = mytype.GetProperties()
        For Each oProp As Reflection.PropertyInfo In oTabProp

            Dim otab As Attribute() = System.Attribute.GetCustomAttributes(oProp, GetType(importCrodipAtt))
            For Each obj As Attribute In otab
                Dim oAtt As importCrodipAtt
                oAtt = CType(obj, importCrodipAtt)
                oAtt.sourceProperty = oProp.Name
                'Si la Propriété destination n'est pas définie => on prend la source
                If oAtt.targetProperty = "" Then
                    oAtt.targetProperty = oProp.Name
                End If
                olstCrodipAtt.Add(oAtt)

            Next

            If otab.Length > 0 Then
                Dim oAtt As importCrodipAtt
                oAtt = CType(otab(0), importCrodipAtt)
                oAtt.sourceProperty = oProp.Name
                'Si la Propriété destination n'est pas définie => on prend la source
                If oAtt.targetProperty = "" Then
                    oAtt.targetProperty = oProp.Name
                End If
                olstCrodipAtt.Add(oAtt)

            End If
        Next


        Try
            Dim nMax As Integer
            Dim nNum As Integer
            Dim olstExploit As New List(Of Exploitation)
            Using reader As StreamReader = New StreamReader(pfileName, System.Text.Encoding.GetEncoding(1252))
                Using csv As CsvReader = New CsvReader(reader, Globalization.CultureInfo.CurrentCulture)
                    csv.Configuration.HeaderValidated = Nothing
                    csv.Configuration.MissingFieldFound = Nothing
                    csv.Configuration.PrepareHeaderForMatch = Function(h As String, n As Integer) h.ToLower()
                    Dim lst As IEnumerable(Of importCRODIP)
                    lst = csv.GetRecords(Of importCRODIP).Where(Function(i) i.raisonSociale <> "" Or i.nomExploitant <> "").ToList()

                    Dim oExploitation As Exploitation = Nothing
                    Dim oPulve As Pulverisateur = Nothing
                    Dim oDiag As Diagnostic = Nothing
                    Dim strValue As String
                    Dim strValueLargeurNbreRangs As String = ""
                    Dim bValueLargeurNbreRangs As Boolean
                    nNum = 0
                    nMax = lst.Count
                    For Each obj As importCRODIP In lst
                        nNum = nNum + 1
                        oExploitation = New Exploitation()
                        oPulve = New Pulverisateur()
                        oPulve.numeroNational = ""
                        If (pBgwrk IsNot Nothing) Then
                            pBgwrk.ReportProgress((nNum / nMax) * 100)
                            If pBgwrk.CancellationPending = True Then
                                Exit For
                            End If
                        End If
                        'Parcours de la liste des propriétés
                        'on fait un premier parcours pour remplir les Pulvérisateurs et les exploitations car il faut les avoir pour construire un diag
                        For Each oAtt As importCrodipAtt In olstCrodipAtt
                            'Récupération de la valeur
                            strValue = CStr(GetType(importCRODIP).GetProperty(oAtt.sourceProperty).GetValue(obj))
                            If Not String.IsNullOrEmpty(strValue) Then

                                'Affectation de la valeur à l'objet destinataire 
                                Select Case oAtt.targetClass
                                    Case importCrodipAtt.enumCRODIPClass.EXPLOITATION
                                        Dim oProperty As Reflection.PropertyInfo
                                        oProperty = GetType(Exploitation).GetProperty(oAtt.targetProperty)

                                        SetProperty(oAtt, obj, oExploitation, oProperty)

                                    Case importCrodipAtt.enumCRODIPClass.PULVERISATEUR
                                        Dim oProperty As Reflection.PropertyInfo
                                        oProperty = GetType(Pulverisateur).GetProperty(oAtt.targetProperty)
                                        If oProperty IsNot Nothing Then
                                            bValueLargeurNbreRangs = False
                                            If oProperty.Name = "largeur" And Not String.IsNullOrEmpty(strValue) Then
                                                strValueLargeurNbreRangs = strValue
                                                bValueLargeurNbreRangs = True
                                            End If
                                            If oProperty.Name.ToUpper() = "NOMBRERANGS" And strValue <> "0" Then
                                                strValueLargeurNbreRangs = strValue
                                                bValueLargeurNbreRangs = True
                                            End If

                                            If Not bValueLargeurNbreRangs Then
                                                SetProperty(oAtt, obj, oPulve, oProperty)

                                            End If
                                        End If
                                End Select
                            End If
                        Next
                        If Not String.IsNullOrEmpty(strValueLargeurNbreRangs) Then
                            oPulve.setLargeurNbreRangs(strValueLargeurNbreRangs)
                        End If
                        'puis on créé un Diagnostic
                        oDiag = New Diagnostic(pAgent, oPulve, oExploitation)
                        'L'affectition du numero de diag se fait au moment de la Sauvegarde
                        'Et on reparcours la liste des Propriétés pour extraire les Prop DIAG
                        For Each oAtt As importCrodipAtt In olstCrodipAtt
                            Select Case oAtt.targetClass
                                Case importCrodipAtt.enumCRODIPClass.DIAGNOSTIC
                                    Dim oProperty As Reflection.PropertyInfo
                                    oProperty = GetType(Diagnostic).GetProperty(oAtt.targetProperty)
                                    SetProperty(oAtt, obj, oDiag, oProperty)
                            End Select
                        Next
                        oDiag.CalculDateProchainControle()
                        oPulve.dateProchainControle = oDiag.pulverisateurDateProchainControle

                        '1er Est-ce une nouvelle exploitation
                        Dim nExploita As Integer = olstExploit.Where(Function(o) o.nomExploitant = oExploitation.nomExploitant And o.numeroSiren = oExploitation.numeroSiren).Count()
                        If nExploita = 0 Then
                            olstExploit.Add(oExploitation)
                        Else
                            oExploitation = olstExploit.Where(Function(o) o.nomExploitant = oExploitation.nomExploitant And o.numeroSiren = oExploitation.numeroSiren).First()
                        End If
                        If isPulveOK(oPulve) Then
                            oExploitation.lstPulveImport.Add(oPulve)
                        End If
                        If isDiagOK(oDiag) Then
                            oExploitation.lstDiagImport.Add(oDiag)
                        End If
                    Next
                End Using
            End Using
            Dim bReturn As Boolean
            nNum = 0
            nMax = olstExploit.Count
            For Each oExploit As Exploitation In olstExploit
                nNum = nNum + 1
                If (pBgwrk IsNot Nothing) Then
                    pBgwrk.ReportProgress((nNum / nMax) * 100)
                    If pBgwrk.CancellationPending = True Then
                        Exit For
                    End If
                End If

                bReturn = ExploitationManager.save(oExploit, pAgent)
                If bReturn Then
                    oresult.nClientimport = oresult.nClientimport + 1
                Else
                    oresult.nClientRejete = oresult.nClientRejete + 1
                End If

                For Each oPulve As Pulverisateur In oExploit.lstPulveImport
                    bReturn = PulverisateurManager.save(oPulve, oExploit.id, pAgent)
                    If bReturn Then
                        oresult.nPulveimport = oresult.nPulveimport + 1

                    Else
                        oresult.nPulveRejete = oresult.nPulveRejete + 1

                    End If
                Next
                For Each oDiag As Diagnostic In oExploit.lstDiagImport
                    Dim strdiagId As String = DiagnosticManager.getNewId(pAgent)
                    oDiag.id = strdiagId
                    'Affecation du ProprietaireID et PulverisateurID
                    oDiag.proprietaireId = oExploit.id
                    Dim oPulve As Pulverisateur
                    oPulve = PulverisateurManager.getPulverisateurByNumNat(oDiag.pulverisateurNumNational, oExploit.id)
                    If oPulve IsNot Nothing Then
                        oDiag.pulverisateurId = oPulve.id
                    End If

                    bReturn = DiagnosticManager.save(oDiag)
                    If bReturn Then
                        oresult.nDiagimport = oresult.nDiagimport + 1
                    Else
                        oresult.nDiagRejete = oresult.nDiagRejete + 1
                    End If
                Next
            Next
            oresult.lstExploitationimport = olstExploit
        Catch ex As Exception
            MsgBox(ex.Message)
            CSDebug.dispError("ImportCRODIP.import ERR " & ex.Message)

        End Try

        Return oresult
    End Function
    Private Shared Function SetProperty(pAtt As importCrodipAtt, pSourceObj As importCRODIP, pTargetObj As Object, pProperty As PropertyInfo) As Boolean
        Dim bReturn As Boolean
        bReturn = False
        Try

            'Récupération de la valeur
            Dim strValue As String
            strValue = CStr(GetType(importCRODIP).GetProperty(pAtt.sourceProperty).GetValue(pSourceObj))
            If Not String.IsNullOrEmpty(strValue) Then
                'Affectation de la valeur à l'objet destinataire 
                If pProperty IsNot Nothing Then
                    If pProperty.PropertyType.Name = "Int32" Then
                        pProperty.SetValue(pTargetObj, CType(strValue, Integer))
                    Else
                        If pProperty.PropertyType.Name = "Boolean" Then
                            If strValue = "FAUX" Then
                                pProperty.SetValue(pTargetObj, False)
                            Else
                                pProperty.SetValue(pTargetObj, True)
                            End If
                        Else
                            pProperty.SetValue(pTargetObj, strValue)
                        End If
                    End If
                End If
            End If
            bReturn = True
        Catch ex As Exception
            bReturn = False
        End Try
        Return bReturn
    End Function

    Private Shared Function isPulveOK(pPulve As Pulverisateur) As Boolean
        Dim breturn As Boolean = True

        If String.IsNullOrEmpty(pPulve.numeroNational) Then
            breturn = False
        End If
        Return breturn
    End Function
    Private Shared Function isDiagOK(pdiag As Diagnostic) As Boolean
        Dim breturn As Boolean = True

        'If String.IsNullOrEmpty(pdiag.id) Then
        'breturn = False
        'End If
        Return breturn
    End Function

    Public Class ImportCrodipResult
        Public Property nClientimport As Integer
        Public Property nPulveimport As Integer
        Public Property nDiagimport As Integer

        Public Property nClientRejete As Integer
        Public Property nPulveRejete As Integer
        Public Property nDiagRejete As Integer

        Public Property lstExploitationimport As List(Of Exploitation)

    End Class


End Class
