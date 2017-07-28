Public Class RPDiagnostic
    Inherits Diagnostic

    Private m_Commentaires As String
    Private m_oRPParam As RPParam
    Private m_FileName As String
    Private m_Calculs As New CalcVolumeHa()

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
    Public Property FilePath As String
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
    Public Property FileName As String
        Get
            Return m_FileName
        End Get
        Set(value As String)
            m_FileName = value
        End Set
    End Property
    Public Property Commentaires As String
        Get
            Return m_Commentaires
        End Get
        Set(value As String)
            m_Commentaires = value
        End Set
    End Property


    Public Sub New()

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
    Public Property CalcNbreNiveauParDescente As Integer
        Get
            Return m_Calculs.NbreNiveauParDescente
        End Get
        Set(value As Integer)
            m_Calculs.NbreNiveauParDescente = value

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

End Class
