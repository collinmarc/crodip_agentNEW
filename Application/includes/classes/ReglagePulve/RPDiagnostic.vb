Imports System.Collections.Generic
Imports System.IO
Imports System.Xml.Serialization

'<XmlInclude(GetType(List(Of RPInfosBuses)))>
'<XmlInclude(GetType(RPInfosBuses))>
<Serializable()>
Public Class RPDiagnostic
    Inherits Diagnostic

    Private m_Commentaires As String
    Private m_oRPParam As RPParam
    Private m_FileName As String
    Private m_Calculs As New CalcVolumeHa()

    Public oClientCourant As Exploitation
    Public oPulverisateurCourant As Pulverisateur


    Public Property xmldiagnosticHelp551() As DiagnosticHelp551
        Get
            Return m_diagnostichelp551
        End Get
        Set(ByVal Value As DiagnosticHelp551)
            m_diagnostichelp551 = Value
        End Set
    End Property
    Public Property xmldiagnosticHelp552() As DiagnosticHelp552
        Get
            Return m_diagnostichelp552
        End Get
        Set(ByVal Value As DiagnosticHelp552)
            m_diagnostichelp552 = Value
        End Set
    End Property
    Public Property xmldiagnosticMano542List() As DiagnosticMano542List
        Get
            Return m_diagnosticMano542List
        End Get
        Set(ByVal Value As DiagnosticMano542List)
            m_diagnosticMano542List = Value
        End Set
    End Property
    Public Property xmldiagnosticMano833List() As DiagnosticTroncons833List
        Get
            Return m_diagnosticTroncons833
        End Get
        Set(ByVal Value As DiagnosticTroncons833List)
            m_diagnosticTroncons833 = Value
        End Set
    End Property
    Public Property xmlcontroleUseCalibrateur() As Boolean
        Get
            Return m_controleUseCalibrateur
        End Get
        Set(ByVal Value As Boolean)
            m_controleUseCalibrateur = Value
        End Set
    End Property
    Public Property xmlcontroleNbreNiveaux() As Integer
        Get
            Return m_controleNbreNiveaux
        End Get
        Set(ByVal Value As Integer)
            m_controleNbreNiveaux = Value
        End Set
    End Property
    Public Property xmlcontroleNbreTroncons() As Integer
        Get
            Return m_controleNbreTroncons
        End Get
        Set(ByVal Value As Integer)
            m_controleNbreTroncons = Value
        End Set
    End Property

    Public Property xml_relevePression833_1() As RelevePression833
        Get
            Return m_relevePression833_1
        End Get
        Set(ByVal Value As RelevePression833)
            m_relevePression833_1 = Value
        End Set
    End Property

    Public Property xml_relevePression833_2() As RelevePression833
        Get
            Return m_relevePression833_2
        End Get
        Set(ByVal Value As RelevePression833)
            m_relevePression833_2 = Value
        End Set
    End Property
    Public Property xml_relevePression833_3() As RelevePression833
        Get
            Return m_relevePression833_3
        End Get
        Set(ByVal Value As RelevePression833)
            m_relevePression833_3 = Value
        End Set
    End Property
    Public Property xml_relevePression833_4() As RelevePression833
        Get
            Return m_relevePression833_4
        End Get
        Set(ByVal Value As RelevePression833)
            m_relevePression833_4 = Value
        End Set
    End Property
    Public Property xml_SyntheseImprecision542() As String
        Get
            Return m_SyntheseImprecision542
        End Get
        Set(ByVal Value As String)
            m_SyntheseImprecision542 = Value
        End Set
    End Property



    Public Property XMLbuseDebitMoyenPM() As Decimal
        Get
            Return m_buseDebitMoyenPM
        End Get
        Set(ByVal Value As Decimal)
            m_buseDebitMoyenPM = Value
        End Set
    End Property



    Public Property bSectionEntete As Boolean
        Get
            Return m_oRPParam.bSectionEntete
        End Get
        Set(ByVal value As Boolean)
            m_oRPParam.bSectionEntete = value
        End Set
    End Property
    Public Property bSectionDefauts As Boolean
        Get
            Return m_oRPParam.bSectionDefauts
        End Get
        Set(ByVal value As Boolean)
            m_oRPParam.bSectionDefauts = value
        End Set
    End Property
    Public Property bSectionCommentaires As Boolean
        Get
            Return m_oRPParam.bSectionCommentaires
        End Get
        Set(ByVal value As Boolean)
            m_oRPParam.bSectionCommentaires = value
        End Set
    End Property
    Public Property bSectionCalculs As Boolean
        Get
            Return m_oRPParam.bSectionCalculs
        End Get
        Set(ByVal value As Boolean)
            m_oRPParam.bSectionCalculs = value
        End Set
    End Property
    Public Property bSectionSyntheseMesures As Boolean
        Get
            Return m_oRPParam.bSectionSyntheseMesures
        End Get
        Set(ByVal value As Boolean)
            m_oRPParam.bSectionSyntheseMesures = value
        End Set
    End Property
    Public Property bSectionSyntheseBuses As Boolean
        Get
            Return m_oRPParam.bSectionSyntheseBuses
        End Get
        Set(ByVal value As Boolean)
            m_oRPParam.bSectionSyntheseBuses = value
        End Set
    End Property
    Public Property bSectionSynthese833 As Boolean
        Get
            Return m_oRPParam.bSectionSynthese833
        End Get
        Set(ByVal value As Boolean)
            m_oRPParam.bSectionSynthese833 = value
        End Set
    End Property
    Public Property bSectionSynthese542 As Boolean
        Get
            Return m_oRPParam.bSectionSynthese542
        End Get
        Set(ByVal value As Boolean)
            m_oRPParam.bSectionSynthese542 = value
        End Set
    End Property
    Public Property bSectionSyntheseCapteurVitesse As Boolean
        Get
            Return m_oRPParam.bSectionSyntheseCapteurVitesse
        End Get
        Set(ByVal value As Boolean)
            m_oRPParam.bSectionSyntheseCapteurVitesse = value
        End Set
    End Property
    Public Property bSectionSyntheseCapteurDebit As Boolean
        Get
            Return m_oRPParam.bSectionSyntheseCapteurDebit
        End Get
        Set(ByVal value As Boolean)
            m_oRPParam.bSectionSyntheseCapteurDebit = value
        End Set
    End Property
    ''' <summary>
    ''' Reference de l'agent sous forme d'un tabelau de String
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Reference As String
        Get
            Return m_oRPParam.ReferenceAgent
        End Get
        Set(value As String)
            m_oRPParam.ReferenceAgent = value
        End Set
    End Property
    ''' <summary>
    ''' Path complet de l'image à intégrer dans le rapport
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property imagePath As String
        Get
            Return m_oRPParam.ImagePath
        End Get
        Set(value As String)
            m_oRPParam.ImagePath = value
        End Set
    End Property
    ''' <summary>
    ''' Emplacement de sauvegarde du rapport
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ReportFilePath As String
        Get
            Return m_oRPParam.ReportPath
        End Get
        Set(value As String)
            m_oRPParam.ReportPath = value
        End Set
    End Property
    ''' <summary>
    ''' Nom du fichier final
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ReportFileName As String
        Get
            Return m_FileName
        End Get
        Set(value As String)
            m_FileName = value
        End Set
    End Property

    Public Function createReportFileName() As String
        Return "Rapport" & Format(Date.Now, "yyyyMMddhhmmss") & ".pdf"
    End Function
    Public Function createXMLFileName() As String
        Return "RP" & Me.proprietaireRaisonSociale & Format(Date.Now, "yyyyMMdd") & ".CRODIP"
    End Function

    Public Property Commentaires As String
        Get
            Return m_Commentaires
        End Get
        Set(value As String)
            m_Commentaires = value
        End Set
    End Property


    Public Sub New()
        ListInfosBuses = New Generic.List(Of RPInfosBuses)
        ListInfosBuses.Add(New RPInfosBuses(0))
        m_oRPParam = RPParam.readXML()

    End Sub
    Public Sub New(ByVal pPulve As Pulverisateur, ByVal pClient As Exploitation)
        MyClass.New()
        setPulverisateur(pPulve)
        SetProprietaire(pClient)
    End Sub
    Public Sub saveParam()

        m_oRPParam.writeXML()

    End Sub

    Public Property oRPParam As RPParam
        Get
            Return m_oRPParam
        End Get
        Set(value As RPParam)
        End Set
    End Property

    Public Property CalcLargeurPlantation As Decimal
        Get
            Return m_Calculs.LargeurPlantation
        End Get
        Set(value As Decimal)
            m_Calculs.LargeurPlantation = value

        End Set
    End Property
    Public Property CalcVitesseRotation As Decimal
        Get
            Return m_Calculs.VitesseRotation

        End Get
        Set(value As Decimal)
            m_Calculs.VitesseRotation = value
        End Set
    End Property
    Public Property CalcRegimeMoteur As Decimal
        Get
            Return m_Calculs.RegimeMoteur

        End Get
        Set(value As Decimal)
            m_Calculs.RegimeMoteur = value
        End Set
    End Property
    Public Property CalcEmplacementPriseAir As Boolean
        Get
            Return m_Calculs.EmplacementPriseAir

        End Get
        Set(value As Boolean)
            m_Calculs.EmplacementPriseAir = value

        End Set
    End Property
    Public Property CalcNbreDescentes As Integer
        Get
            Return m_Calculs.NbreDescentes
        End Get
        Set(value As Integer)
            m_Calculs.NbreDescentes = value
            updateListeInfosBuses()
        End Set
    End Property
    Public Property CalcNbreBusesParDescente As Integer
        Get
            Return m_Calculs.NbreBusesParDescente
        End Get
        Set(value As Integer)
            m_Calculs.NbreBusesParDescente = value

        End Set
    End Property
    <XmlIgnore>
    Public Property CalcNbreNiveauParDescente As Integer
        Get
            Return m_Calculs.NbreNiveauParDescente
        End Get
        Set(value As Integer)
            If value <> m_Calculs.NbreNiveauParDescente Then
                m_Calculs.NbreNiveauParDescente = value
                updateListeInfosBuses()
            End If
        End Set
    End Property
    <XmlElement("CalcNbreNiveauParDescente")>
    Public Property CalcNbreNiveauParDescenteOnlyForXML As Integer
        Get
            Return m_Calculs.NbreNiveauParDescente
        End Get
        Set(value As Integer)
            '           If value <> m_Calculs.NbreNiveauParDescente Then
            m_Calculs.NbreNiveauParDescente = value
            '                updateListeInfosBuses()
            '          End If
        End Set
    End Property
    Public Property CalcPressionDeMesure As Decimal
        Get
            Return m_Calculs.PressionDeMesure

        End Get
        Set(value As Decimal)
            m_Calculs.PressionDeMesure = value
        End Set
    End Property
    Public Property CalcDebitMoyenPM As Decimal
        Get
            Return m_Calculs.DebitMoyenPM

        End Get
        Set(value As Decimal)
            m_Calculs.DebitMoyenPM = value

        End Set
    End Property
    Public Property CalcNombreBuses As Integer
        Get
            Return m_Calculs.NombreBuses
        End Get
        Set(value As Integer)
            m_Calculs.NombreBuses = value

        End Set
    End Property
    Public Property CalcPressionTravail As Decimal
        Get
            Return m_Calculs.PressionTravail
        End Get
        Set(value As Decimal)
            m_Calculs.PressionTravail = value
            If value <> 0 And CalcPression1 = 0 Then
                CalcPression1 = value
            End If
            If value <> 0 And CalcPression2 = 0 Then
                CalcPression2 = value
            End If
        End Set
    End Property
    Public Property CalcPressionTravailMoinsPC As Decimal
        Get
            Return m_Calculs.PressionTravailMoinsPC
        End Get
        Set(value As Decimal)
            m_Calculs.PressionTravailMoinsPC = value

        End Set
    End Property
    Public Property CalcDebitPTlMoinsPC As Decimal
        Get
            Return Math.Round(m_Calculs.DebitPressionTravailMoinsPerteCharge, 3)
        End Get
        Set(value As Decimal)
            m_Calculs.DebitPressionTravailMoinsPerteCharge = value

        End Set
    End Property
    Public Property CalcVolHaPMV1 As Decimal
        Get
            Return Math.Round(m_Calculs.VolHaPMV1, 3)

        End Get
        Set(value As Decimal)
            m_Calculs.VolHaPMV1 = value

        End Set
    End Property
    Public Property CalcVolHaPMV2 As Decimal
        Get
            Return Math.Round(m_Calculs.VolHaPMV2, 3)

        End Get
        Set(value As Decimal)
            m_Calculs.VolHaPMV2 = value

        End Set
    End Property
    Public Property CalcVolHaPTV1 As Decimal
        Get
            Return Math.Round(m_Calculs.VolHaPTV1, 3)

        End Get
        Set(value As Decimal)
            m_Calculs.VolHaPTV1 = value

        End Set
    End Property
    Public Property CalcVolHaPTV2 As Decimal
        Get
            Return Math.Round(m_Calculs.VolHaPTV2, 3)

        End Get
        Set(value As Decimal)
            m_Calculs.VolHaPTV2 = value

        End Set
    End Property
    Public Property CalcNombreNiveauxBuses As Decimal
        Get
            Return m_Calculs.NombreNiveauxBuses
        End Get
        Set(value As Decimal)
            m_Calculs.NombreNiveauxBuses = value

        End Set
    End Property
    Public Property CalcVitesseReelle1 As Decimal
        Get
            Return Math.Round(m_Calculs.VitesseReelle1, 3)
        End Get
        Set(value As Decimal)
            m_Calculs.VitesseReelle1 = value

        End Set
    End Property
    Public Property CalcVitesseReelle2 As Decimal
        Get
            Return Math.Round(m_Calculs.VitesseReelle2, 3)
        End Get
        Set(value As Decimal)
            m_Calculs.VitesseReelle2 = value

        End Set
    End Property
    Public Property CalcLargeurApp As Decimal
        Get
            Return m_Calculs.LargeurApp
        End Get
        Set(value As Decimal)
            m_Calculs.LargeurApp = value
            If CalcLargeur1 = 0 And value <> 0 Then
                CalcLargeur1 = value
            End If
            If CalcLargeur2 = 0 And value <> 0 Then
                CalcLargeur2 = value
            End If

        End Set
    End Property
    Public Property CalclstBuseUsees As String
        Get
            Return m_Calculs.lstBuseUsees
        End Get
        Set(value As String)
            m_Calculs.lstBuseUsees = value

        End Set
    End Property
    Public Property CalcPression1 As Decimal
        Get
            Return m_Calculs.Pression1
        End Get
        Set(value As Decimal)
            m_Calculs.Pression1 = value

        End Set
    End Property
    Public Property CalcDebit1 As Decimal
        Get
            Return Math.Round(m_Calculs.Debit1, 3)
        End Get
        Set(value As Decimal)
            m_Calculs.Debit1 = value

        End Set
    End Property
    Public Property CalcVitesse1 As Decimal
        Get
            Return Math.Round(m_Calculs.Vitesse1, 3)
        End Get
        Set(value As Decimal)
            m_Calculs.Vitesse1 = value

        End Set
    End Property
    Public Property CalcLargeur1 As Decimal
        Get
            Return Math.Round(m_Calculs.Ecartement1, 3)
        End Get
        Set(value As Decimal)
            m_Calculs.Ecartement1 = value

        End Set
    End Property
    Public Property CalcVolEauHa1 As Decimal
        Get
            Return Math.Round(m_Calculs.VolEauHa1, 3)
        End Get
        Set(value As Decimal)

            m_Calculs.VolEauHa1 = value
        End Set
    End Property
    Public Property CalcPression2 As Decimal
        Get
            Return Math.Round(m_Calculs.Pression2, 3)

        End Get
        Set(value As Decimal)

            m_Calculs.Pression2 = value
        End Set
    End Property
    Public Property CalcDebit2 As Decimal
        Get
            Return Math.Round(m_Calculs.Debit2, 3)
        End Get
        Set(value As Decimal)

            m_Calculs.Debit2 = value
        End Set
    End Property
    Public Property CalcVitesse2 As Decimal
        Get
            Return Math.Round(m_Calculs.Vitesse2, 3)

        End Get
        Set(value As Decimal)
            m_Calculs.Vitesse2 = value

        End Set
    End Property
    Public Property CalcLargeur2 As Decimal
        Get
            Return Math.Round(m_Calculs.Ecartement2, 3)
        End Get
        Set(value As Decimal)
            m_Calculs.Ecartement2 = value

        End Set
    End Property
    Public Property CalcVolEauHa2 As Decimal
        Get
            Return Math.Round(m_Calculs.VolEauHa2, 3)
        End Get
        Set(value As Decimal)
            m_Calculs.VolEauHa2 = value

        End Set
    End Property

    Public Sub CalcVolumeHa()
        Try

            m_Calculs.Calcul()
        Catch ex As Exception

        End Try

    End Sub

    Private _ListInfosBuses As Generic.List(Of RPInfosBuses)
    Public Property ListInfosBuses() As Generic.List(Of RPInfosBuses)
        Get
            Return _ListInfosBuses
        End Get
        Set(ByVal value As Generic.List(Of RPInfosBuses))
            _ListInfosBuses = value
        End Set
    End Property

    Public Sub CreerListeInfosBuses()
        ListInfosBuses = New Generic.List(Of RPInfosBuses)
        For n As Integer = 1 To CalcNbreNiveauParDescente
            ListInfosBuses.Add(New RPInfosBuses(CalcNbreDescentes))
        Next
        Dim oRPinfoBuses As RPInfosBuses
        oRPinfoBuses = New RPInfosBuses(CalcNbreDescentes)
        For n As Integer = 1 To CalcNbreDescentes
            oRPinfoBuses.Infos(n) = "0"
        Next
        ListInfosBuses.Add(oRPinfoBuses)

    End Sub

    Public Sub updateListeInfosBuses()
        ''Vérification du nbre de descentes
        For Each oRPInfo As RPInfosBuses In ListInfosBuses
            oRPInfo.NbDescentes = CalcNbreDescentes
        Next
        'Ajustement du nombre de niveaux
        'Attention il y a toujours un element dans la liste c'est le dernier qui représente l'emplacement Prise d'air
        If CalcNbreNiveauParDescente < ListInfosBuses.Count - 1 Then
            'IL y a plus de ligne dans la collection  que la valeur indiquée
            'Suppression des lignes en trop
            For n As Integer = ListInfosBuses.Count - 1 To CalcNbreNiveauParDescente Step -1
                ListInfosBuses.RemoveAt(n - 2)
            Next n
        End If
        If CalcNbreNiveauParDescente > ListInfosBuses.Count - 1 Then
            'IL y a moins de ligne dans la collection  que la valeur indiquée
            'Ajout des lignes 
            For n As Integer = ListInfosBuses.Count - 1 To CalcNbreNiveauParDescente - 1
                ListInfosBuses.Insert(ListInfosBuses.Count - 1, New RPInfosBuses(CalcNbreDescentes))
            Next n
        End If

    End Sub
    ''' <summary>
    ''' La Propriété est cachée en xml dans le diagnostic
    ''' Exposition uniquement dans le RPdiagnostic
    ''' </summary>
    ''' <returns></returns>
    Public Property RPDiagnosticBusesList() As List(Of DiagnosticBuses)
        Get
            Return MyBase.diagnosticBusesList.Liste
        End Get
        Set(ByVal value As List(Of DiagnosticBuses))
            For Each oDiagBuse As DiagnosticBuses In value
                MyBase.diagnosticBusesList.Liste.Add(oDiagBuse)
            Next

        End Set
    End Property
#Region "Persistance xml"

    Public Function writeXML(pFileName As String) As Boolean
        Return RPDiagnostic.writeXml(pFileName, Me)
    End Function


    ''' <summary>
    ''' Lecture du fichier XML et retour d'un Object
    ''' (Nothing if fails)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function readXML(pFileName As String) As RPDiagnostic
        Dim oReturn As New RPDiagnostic()
        Dim objStreamReader As StreamReader = Nothing
        Try
            If System.IO.File.Exists(RPParam.xmlFileName) Then

                objStreamReader = New StreamReader(pFileName)
                Dim x As New XmlSerializer(oReturn.GetType)
                oReturn = x.Deserialize(objStreamReader)
            End If
        Catch ex As Exception
            Debug.Print("RPDiagnostic.readXML: " & ex.Message)
            If ex.InnerException IsNot Nothing Then
                Debug.Print("RPDiagnostic.readXML: " & ex.InnerException.Message)
            End If
            oReturn = Nothing
        Finally
            If objStreamReader IsNot Nothing Then
                objStreamReader.Close()
            End If
        End Try
        Return oReturn
    End Function
    ''' <summary>
    ''' Ecriture dans le fichier XML
    ''' </summary>
    ''' <param name="pObj"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function writeXml(pFileName As String, pObj As RPDiagnostic) As Boolean
        Dim bReturn As Boolean
        Dim objStreamWriter As StreamWriter = Nothing

        Try
            Dim ns As New XmlSerializerNamespaces()
            ns.Add("", "")
            objStreamWriter = New StreamWriter(pFileName)
            Dim x As New XmlSerializer(pObj.GetType)
            x.Serialize(objStreamWriter, pObj, ns)
            objStreamWriter.Close()
            bReturn = True
        Catch ex As Exception
            Debug.Print("RPDiagnostic.WriteXML: " & ex.Message)
            If ex.InnerException IsNot Nothing Then
                Debug.Print("RPDiagnostic.WriteXML: " & ex.InnerException.Message)
            End If
            bReturn = False
        Finally
            If objStreamWriter IsNot Nothing Then
                objStreamWriter.Close()
            End If

        End Try
        Return bReturn
    End Function

#End Region
End Class
