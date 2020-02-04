Imports System.Collections.Generic
Imports System.IO
Imports CsvHelper
Imports System.Linq

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
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
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
    Public Property dateProchainControle As String
    <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
    Public Property ControleEtat As String
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


    Public Shared Function import(pfileName As String, pAgent As Agent) As ImportCrodipResult
        Dim oresult As New ImportCrodipResult()
        Dim olstCrodipAtt As New List(Of importCrodipAtt)()

        'Initialisation du tableau des propriétés de importCROPIP
        Dim mytype As Type = GetType(importCRODIP)
        Dim oTabProp As Reflection.PropertyInfo() = mytype.GetProperties()
        For Each oProp As Reflection.PropertyInfo In oTabProp

            Dim otab As Attribute() = System.Attribute.GetCustomAttributes(oProp, GetType(importCrodipAtt))
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

            Dim olstExploit As New List(Of Exploitation)
            Using reader As StreamReader = New StreamReader(pfileName, System.Text.Encoding.GetEncoding(1252))
                Using csv As CsvReader = New CsvReader(reader, Globalization.CultureInfo.CurrentCulture)
                    csv.Configuration.HeaderValidated = Nothing
                    csv.Configuration.MissingFieldFound = Nothing
                    Dim lst As IEnumerable(Of importCRODIP)
                    lst = csv.GetRecords(Of importCRODIP)()
                    Dim oExploitation As Exploitation
                    Dim oPulve As Pulverisateur
                    Dim strValue As String
                    Dim strValueLargeurNbreRangs As String = ""
                    Dim bValueLargeurNbreRangs As Boolean
                    For Each obj As importCRODIP In lst
                        oExploitation = New Exploitation()
                        oPulve = New Pulverisateur()
                        oPulve.numeroNational = ""
                        'Parcours de la liste des propriétés
                        For Each oAtt As importCrodipAtt In olstCrodipAtt
                            'Récupération de la valeur
                            strValue = CStr(GetType(importCRODIP).GetProperty(oAtt.sourceProperty).GetValue(obj))
                            If Not String.IsNullOrEmpty(strValue) Then

                                'Affectation de la valeur à l'objet destinataire 
                                Select Case oAtt.targetClass
                                    Case importCrodipAtt.enumCRODIPClass.EXPLOITATION
                                        Dim oProperty As Reflection.PropertyInfo
                                        oProperty = GetType(Exploitation).GetProperty(oAtt.targetProperty)
                                        If oProperty IsNot Nothing Then
                                            oProperty.SetValue(oExploitation, strValue)
                                        End If
                                    Case importCrodipAtt.enumCRODIPClass.PULVERISATEUR
                                        Dim oProperty As Reflection.PropertyInfo
                                        oProperty = GetType(Pulverisateur).GetProperty(oAtt.targetProperty)
                                        If oProperty IsNot Nothing Then
                                            bValueLargeurNbreRangs = False
                                            If oProperty.Name = "largeur" And Not String.IsNullOrEmpty(strValue) Then
                                                strValueLargeurNbreRangs = strValue
                                                bValueLargeurNbreRangs = True
                                            End If
                                            If oProperty.Name = "nombrerangs" And strValue <> "0" Then
                                                strValueLargeurNbreRangs = strValue
                                                bValueLargeurNbreRangs = True
                                            End If

                                            If Not bValueLargeurNbreRangs Then

                                                If oProperty.PropertyType.Name = "Int32" Then
                                                    oProperty.SetValue(oPulve, CType(strValue, Integer))
                                                Else
                                                    If oProperty.PropertyType.Name = "Boolean" Then
                                                        If strValue = "FAUX" Then
                                                            oProperty.SetValue(oPulve, False)
                                                        Else
                                                            oProperty.SetValue(oPulve, True)
                                                        End If
                                                    Else
                                                        oProperty.SetValue(oPulve, strValue)
                                                    End If
                                                End If
                                            End If
                                        End If
                                End Select
                            End If
                        Next
                        If Not String.IsNullOrEmpty(strValueLargeurNbreRangs) Then
                            oPulve.setLargeurNbreRangs(strValueLargeurNbreRangs)
                        End If

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
                    Next
                End Using
            End Using
            Dim bReturn As Boolean
            For Each oExploit As Exploitation In olstExploit

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
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
            CSDebug.dispError("ImportCRODIP.import ERR " & ex.Message)

        End Try

        Return oresult
    End Function

    Private Shared Function isPulveOK(pPulve As Pulverisateur) As Boolean
        Dim breturn As Boolean = True

        If String.IsNullOrEmpty(pPulve.numeroNational) Then
            breturn = False
        End If
        Return breturn
    End Function

    Public Class ImportCrodipResult
        Public Property nClientimport As Integer
        Public Property nPulveimport As Integer

        Public Property nClientRejete As Integer
        Public Property nPulveRejete As Integer

    End Class


End Class
