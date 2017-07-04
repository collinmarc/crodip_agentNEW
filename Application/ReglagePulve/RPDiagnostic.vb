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

    Public Property LargeurPlantation As Decimal
        Get
            Return m_Calculs.LargeurPlantation
        End Get
        Set(value As Decimal)
            m_Calculs.LargeurPlantation = value

        End Set
    End Property
    Public Property VitesseRotation As Decimal
        Get
            Return m_Calculs.VitesseRotation

        End Get
        Set(value As Decimal)
            m_Calculs.VitesseRotation = value
        End Set
    End Property
    Public Property EmplacementPriseAir As Boolean
        Get
            Return m_Calculs.EmplacementPriseAir

        End Get
        Set(value As Boolean)
            m_Calculs.EmplacementPriseAir = value

        End Set
    End Property
    Public Property NbreDescentes As Integer
        Get
            Return m_Calculs.NbreDescentes
        End Get
        Set(value As Integer)
            m_Calculs.NbreDescentes = value

        End Set
    End Property
    Public Property NbreBusesParDescente As Integer
        Get
            Return m_Calculs.NbreBusesParDescente
        End Get
        Set(value As Integer)
            m_Calculs.NbreBusesParDescente = value

        End Set
    End Property
    Public Property NbreNiveauParDescente As Integer
        Get
            Return m_Calculs.NbreNiveauParDescente
        End Get
        Set(value As Integer)
            m_Calculs.NbreNiveauParDescente = value

        End Set
    End Property
    Public Property PressionDeMesure As Decimal
        Get
            Return m_Calculs.PressionDeMesure

        End Get
        Set(value As Decimal)
            m_Calculs.PressionDeMesure = value
        End Set
    End Property
    Public Property DebitMoyenPM As Decimal
        Get
            Return m_Calculs.DebitMoyenPM

        End Get
        Set(value As Decimal)
            m_Calculs.DebitMoyenPM = value

        End Set
    End Property
    Public Property NombreBuses As Integer
        Get
            Return m_Calculs.NombreBuses
        End Get
        Set(value As Integer)
            m_Calculs.NombreBuses = value

        End Set
    End Property
    Public Property VolHaPM As Decimal
        Get
            Return m_Calculs.VolHaPM
        End Get
        Set(value As Decimal)
            m_Calculs.VolHaPM = value

        End Set
    End Property
    Public Property PressionTravail As Decimal
        Get
            Return m_Calculs.PressionTravail
        End Get
        Set(value As Decimal)
            m_Calculs.PressionTravail = value

        End Set
    End Property
    Public Property PressionTravailMoinsPC As Decimal
        Get
            Return m_Calculs.PressionTravailMoinsPC
        End Get
        Set(value As Decimal)
            m_Calculs.PressionTravailMoinsPC = value

        End Set
    End Property
    Public Property VolHaPT As Decimal
        Get
            Return m_Calculs.VolHaPT

        End Get
        Set(value As Decimal)
            m_Calculs.VolHaPT = value

        End Set
    End Property
    Public Property NombreNiveauxBuses As Decimal
        Get
            Return m_Calculs.NombreNiveauxBuses
        End Get
        Set(value As Decimal)
            m_Calculs.NombreNiveauxBuses = value

        End Set
    End Property
    Public Property VitesseReelle1 As Decimal
        Get
            Return m_Calculs.VitesseReelle1
        End Get
        Set(value As Decimal)
            m_Calculs.VitesseReelle1 = value

        End Set
    End Property
    Public Property VitesseReelle2 As Decimal
        Get
            Return m_Calculs.VitesseReelle2
        End Get
        Set(value As Decimal)
            m_Calculs.VitesseReelle2 = value

        End Set
    End Property
    Public Property LargeurApp As Decimal
        Get
            Return m_Calculs.LargeurApp
        End Get
        Set(value As Decimal)
            m_Calculs.LargeurApp = value

        End Set
    End Property
    Public Property lstBuseUsees As String
        Get
            Return m_Calculs.lstBuseUsees
        End Get
        Set(value As String)
            m_Calculs.lstBuseUsees = value

        End Set
    End Property
    Public Property PressionConnue As Decimal
        Get
            Return m_Calculs.PressionConnue
        End Get
        Set(value As Decimal)
            m_Calculs.PressionConnue = value

        End Set
    End Property
    Public Property DebitMoyenConnu As Decimal
        Get
            Return m_Calculs.DebitMoyenConnu
        End Get
        Set(value As Decimal)
            m_Calculs.DebitMoyenConnu = value

        End Set
    End Property
    Public Property Vitesse1 As Decimal
        Get
            Return m_Calculs.Vitesse1
        End Get
        Set(value As Decimal)
            m_Calculs.Vitesse1 = value

        End Set
    End Property
    Public Property Ecartement1 As Decimal
        Get
            Return m_Calculs.Ecartement1
        End Get
        Set(value As Decimal)
            m_Calculs.Ecartement1 = value

        End Set
    End Property
    Public Property VolEauHa1 As Decimal
        Get
            Return m_Calculs.VolEauHa1
        End Get
        Set(value As Decimal)

            m_Calculs.VolEauHa1 = value
        End Set
    End Property
    Public Property Pression2 As Decimal
        Get
            Return m_Calculs.Pression2

        End Get
        Set(value As Decimal)

            m_Calculs.Pression2 = value
        End Set
    End Property
    Public Property DebitMoyen2 As Decimal
        Get
            Return m_Calculs.DebitMoyen2
        End Get
        Set(value As Decimal)

            m_Calculs.DebitMoyen2 = value
        End Set
    End Property
    Public Property Vitesse2 As Decimal
        Get
            Return m_Calculs.Vitesse2

        End Get
        Set(value As Decimal)
            m_Calculs.Vitesse2 = value

        End Set
    End Property
    Public Property Ecartement2 As Decimal
        Get
            Return m_Calculs.Ecartement2
        End Get
        Set(value As Decimal)
            m_Calculs.Ecartement2 = value

        End Set
    End Property
    Public Property VolEauHa2 As Decimal
        Get
            Return m_Calculs.VolEauHa2
        End Get
        Set(value As Decimal)
            m_Calculs.VolEauHa2 = value

        End Set
    End Property
    Public Property Distance As Decimal
        Get
            Return m_Calculs.Distance
        End Get
        Set(value As Decimal)
            m_Calculs.Distance = value

        End Set
    End Property
    Public Property Temps As Decimal
        Get
            Return m_Calculs.Temps
        End Get
        Set(value As Decimal)
            m_Calculs.Temps = value

        End Set
    End Property
    Public Property Vitesse As Decimal
        Get
            Return m_Calculs.Vitesse
        End Get
        Set(value As Decimal)
            m_Calculs.Vitesse = value

        End Set
    End Property

End Class
