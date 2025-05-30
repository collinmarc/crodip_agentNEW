Imports System.Collections.Generic
Imports System.Linq
Imports System.Xml.Serialization

Public Class [Structure]
    Inherits root

    Private _id As Integer
    Private _idCrodip As String
    Private _nom As String
    Private _type As String
    Private _nomResponsable As String
    Private _nomContact As String
    Private _prenomContact As String
    Private _adresse As String
    Private _codePostal As String
    Private _commune As String
    Private _codeInsee As String
    Private _telephoneFixe As String
    Private _telephonePortable As String
    Private _telephoneFax As String
    Private _eMail As String
    Private _commentaire As String
    Private m_DernNumFact As String


    Sub New()
        _id = 0
        _idCrodip = ""
        nom = ""
    End Sub
#Region "Properties"
    <XmlIgnore()>
    Public Property id() As Integer
        Get
            Return uid
        End Get
        Set(ByVal Value As Integer)
            uid = Value
        End Set
    End Property
    <XmlElement("idStructure")>
    Public Property idCrodip() As String
        Get
            Return _idCrodip
        End Get
        Set(ByVal Value As String)
            _idCrodip = Value
        End Set
    End Property

    Public Property nom() As String
        Get
            Return _nom
        End Get
        Set(ByVal Value As String)
            _nom = Value
        End Set
    End Property

    Public Property type() As String
        Get
            Return _type
        End Get
        Set(ByVal Value As String)
            _type = Value
        End Set
    End Property

    Public Property nomResponsable() As String
        Get
            Return _nomResponsable
        End Get
        Set(ByVal Value As String)
            _nomResponsable = Value
        End Set
    End Property

    Public Property nomContact() As String
        Get
            Return _nomContact
        End Get
        Set(ByVal Value As String)
            _nomContact = Value
        End Set
    End Property

    Public Property prenomContact() As String
        Get
            Return _prenomContact
        End Get
        Set(ByVal Value As String)
            _prenomContact = Value
        End Set
    End Property

    Public Property adresse() As String
        Get
            Return _adresse
        End Get
        Set(ByVal Value As String)
            _adresse = Value
        End Set
    End Property

    Public Property codePostal() As String
        Get
            Return _codePostal
        End Get
        Set(ByVal Value As String)
            _codePostal = Value
        End Set
    End Property

    Public Property commune() As String
        Get
            Return _commune
        End Get
        Set(ByVal Value As String)
            _commune = Value
        End Set
    End Property

    Public Property codeInsee() As String
        Get
            Return _codeInsee
        End Get
        Set(ByVal Value As String)
            _codeInsee = Value
        End Set
    End Property

    Public Property telephoneFixe() As String
        Get
            Return _telephoneFixe
        End Get
        Set(ByVal Value As String)
            _telephoneFixe = Value
        End Set
    End Property

    Public Property telephonePortable() As String
        Get
            Return _telephonePortable
        End Get
        Set(ByVal Value As String)
            _telephonePortable = Value
        End Set
    End Property

    Public Property telephoneFax() As String
        Get
            Return _telephoneFax
        End Get
        Set(ByVal Value As String)
            _telephoneFax = Value
        End Set
    End Property

    Public Property eMail() As String
        Get
            Return _eMail
        End Get
        Set(ByVal Value As String)
            _eMail = Value
        End Set
    End Property

    Public Property commentaire() As String
        Get
            Return _commentaire
        End Get
        Set(ByVal Value As String)
            _commentaire = Value
        End Set
    End Property

    Private _ModeReglement As String = ""
    Public Property modereglement() As String
        Get
            Dim sReturn As String = ""
            Dim FACTURATION_XML_CONFIG As CSXml = New CSXml(GlobalsCRODIP.GLOB_STR_FACTURATIONCONFIG_FILENAME)
            Dim x As Xml.XmlNode = FACTURATION_XML_CONFIG.getXmlNode("/root/modereglement")
            If x IsNot Nothing Then
                sReturn = x.InnerText
            End If
            Return sReturn
        End Get
        Set(ByVal value As String)
            Using FACTURATION_XML_CONFIG As New CSXml(GlobalsCRODIP.GLOB_STR_FACTURATIONCONFIG_FILENAME)
                FACTURATION_XML_CONFIG.setElementValue("/root/modereglement", value)
                'FACTURATION_XML_CONFIG.setElementValue("/root/tva", facturation_tva.Text)
                'FACTURATION_XML_CONFIG.setElementValue("/root/rcs", facturation_rcs.Text)
                'FACTURATION_XML_CONFIG.setElementValue("/root/footer", facturation_footer.Text)
                'FACTURATION_XML_CONFIG.setElementValue("/root/footer", facturation_footer.Text)
            End Using
        End Set
    End Property
    Private _SIREN As String
    Public Property SIREN() As String
        Get
            Dim sReturn As String = ""
            Dim FACTURATION_XML_CONFIG As CSXml = New CSXml(GlobalsCRODIP.GLOB_STR_FACTURATIONCONFIG_FILENAME)
            Dim x As Xml.XmlNode = FACTURATION_XML_CONFIG.getXmlNode("/root/siren")
            If x IsNot Nothing Then
                sReturn = x.InnerText
            End If
            Return sReturn
        End Get
        Set(ByVal value As String)
            Using FACTURATION_XML_CONFIG As New CSXml(GlobalsCRODIP.GLOB_STR_FACTURATIONCONFIG_FILENAME)
                FACTURATION_XML_CONFIG.setElementValue("/root/siren", value)
                'FACTURATION_XML_CONFIG.setElementValue("/root/tva", facturation_tva.Text)
                'FACTURATION_XML_CONFIG.setElementValue("/root/rcs", facturation_rcs.Text)
                'FACTURATION_XML_CONFIG.setElementValue("/root/footer", facturation_footer.Text)
                'FACTURATION_XML_CONFIG.setElementValue("/root/footer", facturation_footer.Text)
            End Using
        End Set
    End Property
    Public Property TVA() As String
        Get
            Dim sReturn As String = ""
            Dim FACTURATION_XML_CONFIG As CSXml = New CSXml(GlobalsCRODIP.GLOB_STR_FACTURATIONCONFIG_FILENAME)
            Dim x As Xml.XmlNode = FACTURATION_XML_CONFIG.getXmlNode("/root/tva")
            If x IsNot Nothing Then
                sReturn = x.InnerText
            End If
            Return sReturn
        End Get
        Set(ByVal value As String)
            Using FACTURATION_XML_CONFIG As New CSXml(GlobalsCRODIP.GLOB_STR_FACTURATIONCONFIG_FILENAME)
                '                FACTURATION_XML_CONFIG.setElementValue("/root/siren", value)
                FACTURATION_XML_CONFIG.setElementValue("/root/tva", value)
                '               FACTURATION_XML_CONFIG.setElementValue("/root/rcs", facturation_rcs.Text)
                '              FACTURATION_XML_CONFIG.setElementValue("/root/footer", facturation_footer.Text)
                '             FACTURATION_XML_CONFIG.setElementValue("/root/footer", facturation_footer.Text)
            End Using
        End Set
    End Property
    Public Property txTVA() As String
        Get
            Dim sReturn As String = ""
            Using FACTURATION_XML_CONFIG As New CSXml(GlobalsCRODIP.GLOB_STR_FACTURATIONCONFIG_FILENAME)
                Dim x As Xml.XmlNode = FACTURATION_XML_CONFIG.getXmlNode("/root/txTVA")
                If x IsNot Nothing Then
                    sReturn = x.InnerText
                End If
            End Using
            If sReturn = "" Then
                sReturn = "0"
            End If
            Return sReturn
        End Get
        Set(ByVal value As String)
            Using FACTURATION_XML_CONFIG As New CSXml(GlobalsCRODIP.GLOB_STR_FACTURATIONCONFIG_FILENAME)
                FACTURATION_XML_CONFIG.setElementValue("/root/txTVA", value)
            End Using
        End Set
    End Property
    Public Property RCS() As String
        Get
            Dim sReturn As String = ""
            Dim FACTURATION_XML_CONFIG As CSXml = New CSXml(GlobalsCRODIP.GLOB_STR_FACTURATIONCONFIG_FILENAME)
            Dim x As Xml.XmlNode = FACTURATION_XML_CONFIG.getXmlNode("/root/rcs")
            If x IsNot Nothing Then
                sReturn = x.InnerText
            End If
            Return sReturn
        End Get
        Set(ByVal value As String)
            Using FACTURATION_XML_CONFIG As New CSXml(GlobalsCRODIP.GLOB_STR_FACTURATIONCONFIG_FILENAME)
                'FACTURATION_XML_CONFIG.setElementValue("/root/siren", value)
                'FACTURATION_XML_CONFIG.setElementValue("/root/tva", facturation_tva.Text)
                FACTURATION_XML_CONFIG.setElementValue("/root/rcs", value)
                'FACTURATION_XML_CONFIG.setElementValue("/root/footer", facturation_footer.Text)
                'FACTURATION_XML_CONFIG.setElementValue("/root/footer", facturation_footer.Text)
            End Using
        End Set
    End Property
    Public Property CoordBancaires() As String
        Get
            Dim sReturn As String = ""
            Dim FACTURATION_XML_CONFIG As CSXml = New CSXml(GlobalsCRODIP.GLOB_STR_FACTURATIONCONFIG_FILENAME)
            Dim x As Xml.XmlNode = FACTURATION_XML_CONFIG.getXmlNode("/root/coordonneesBancaires")
            If x IsNot Nothing Then
                sReturn = x.InnerText
            End If
            Return sReturn
        End Get
        Set(ByVal value As String)
            Using FACTURATION_XML_CONFIG As New CSXml(GlobalsCRODIP.GLOB_STR_FACTURATIONCONFIG_FILENAME)
                FACTURATION_XML_CONFIG.setElementValue("/root/coordonneesBancaires", value)
            End Using
        End Set
    End Property
    Public Property PiedPage() As String
        Get
            Dim sReturn As String = ""
            Dim FACTURATION_XML_CONFIG As CSXml = New CSXml(GlobalsCRODIP.GLOB_STR_FACTURATIONCONFIG_FILENAME)
            Dim x As Xml.XmlNode = FACTURATION_XML_CONFIG.getXmlNode("/root/footer")
            If x IsNot Nothing Then
                sReturn = x.InnerText
            End If
            Return sReturn
        End Get
        Set(ByVal value As String)
            Using FACTURATION_XML_CONFIG As New CSXml(GlobalsCRODIP.GLOB_STR_FACTURATIONCONFIG_FILENAME)
                FACTURATION_XML_CONFIG.setElementValue("/root/footer", value)
            End Using
        End Set
    End Property
    Public Property Entete() As String
        Get
            Dim sReturn As String = ""
            Dim FACTURATION_XML_CONFIG As CSXml = New CSXml(GlobalsCRODIP.GLOB_STR_FACTURATIONCONFIG_FILENAME)
            Dim x As Xml.XmlNode = FACTURATION_XML_CONFIG.getXmlNode("/root/header")
            If x IsNot Nothing Then
                sReturn = x.InnerText
            End If
            Return sReturn
        End Get
        Set(ByVal value As String)
            Using FACTURATION_XML_CONFIG As New CSXml(GlobalsCRODIP.GLOB_STR_FACTURATIONCONFIG_FILENAME)
                FACTURATION_XML_CONFIG.setElementValue("/root/header", value)
            End Using
        End Set
    End Property
    Public Property RacineNumFact() As String
        Get
            Dim sReturn As String = ""
            Dim FACTURATION_XML_CONFIG As CSXml = New CSXml(GlobalsCRODIP.GLOB_STR_FACTURATIONCONFIG_FILENAME)
            Dim x As Xml.XmlNode = FACTURATION_XML_CONFIG.getXmlNode("/root/racinenumerotation")
            If x IsNot Nothing Then
                sReturn = x.InnerText
            End If
            Return sReturn
        End Get
        Set(ByVal value As String)
            Dim FACTURATION_XML_CONFIG As CSXml = New CSXml(GlobalsCRODIP.GLOB_STR_FACTURATIONCONFIG_FILENAME)
            FACTURATION_XML_CONFIG.setElementValue("/root/racinenumerotation", value)
        End Set
    End Property
    Public Property DernierNumFact() As String
        Get
            Return m_DernNumFact
        End Get
        Set(ByVal value As String)
            m_DernNumFact = value
        End Set
    End Property
    Public Sub LireDernierNumFact()
        Dim FACTURATION_XML_CONFIG As CSXml = New CSXml(GlobalsCRODIP.GLOB_STR_FACTURATIONCONFIG_FILENAME)
        Dim x As Xml.XmlNode = FACTURATION_XML_CONFIG.getXmlNode("/root/derniernumero")
        If x IsNot Nothing Then
            DernierNumFact = x.InnerText
        End If
    End Sub
    Public Sub SauverDernierNumFact()
        Dim FACTURATION_XML_CONFIG As CSXml = New CSXml(GlobalsCRODIP.GLOB_STR_FACTURATIONCONFIG_FILENAME)
        FACTURATION_XML_CONFIG.setElementValue("/root/derniernumero", DernierNumFact)
    End Sub
    Public Property isFacturationActive() As Boolean
        Get
            Dim sReturn As Boolean = False
            Dim FACTURATION_XML_CONFIG As CSXml = New CSXml(GlobalsCRODIP.GLOB_STR_FACTURATIONCONFIG_FILENAME)
            Dim x As Xml.XmlNode = FACTURATION_XML_CONFIG.getXmlNode("/root/isActive")
            If x IsNot Nothing Then
                sReturn = CBool(x.InnerText)
            End If
            Return sReturn
        End Get
        Set(ByVal value As Boolean)
            Dim FACTURATION_XML_CONFIG As CSXml = New CSXml(GlobalsCRODIP.GLOB_STR_FACTURATIONCONFIG_FILENAME)
            FACTURATION_XML_CONFIG.setElementValue("/root/isActive", value.ToString())
        End Set
    End Property
    Public Property isCVImmediateActive() As Boolean
        Get
            Return System.IO.File.Exists("ContreVisiteGratuite")
        End Get
        Set(ByVal value As Boolean)

            If value Then
                If Not System.IO.File.Exists("ContreVisiteGratuite") Then
                    System.IO.File.CreateText("ContreVisiteGratuite").Close()
                End If
            Else
                If System.IO.File.Exists("ContreVisiteGratuite") Then
                    System.IO.File.Delete("ContreVisiteGratuite")
                End If
            End If
        End Set
    End Property
#End Region
End Class
