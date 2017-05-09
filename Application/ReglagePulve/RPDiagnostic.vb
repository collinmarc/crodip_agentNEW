Public Class RPDiagnostic
    Inherits Diagnostic

    Private m_Commentaires As String
    Private m_oRPParam As RPParam
    Private m_FileName As String

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
End Class
