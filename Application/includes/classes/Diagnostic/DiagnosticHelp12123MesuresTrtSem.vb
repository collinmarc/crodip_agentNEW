Imports System.Web.Services
Imports System.Xml.Serialization
Imports System.Collections.Generic
'''
''' Classe de stockage des infos saisie de mesures pour l'item 12123
''' Voir fichier Calcul12123
<Serializable()>
Public Class DiagnosticHelp12123MesuresTrtSem
    '    Implements ICloneable
    Public m_id As String
    Public m_idDiag As String

    Private m_numpompe As Decimal
    Public Property numPompe() As Decimal
        Get
            Return m_numpompe
        End Get
        Set(ByVal value As Decimal)
            m_numpompe = value
        End Set
    End Property
    Private m_numMesure As Integer
    Public Property numMesure() As Integer
        Get
            Return m_numMesure
        End Get
        Set(ByVal value As Integer)
            m_numMesure = value
        End Set
    End Property
    Private m_QteGrains As Decimal
    Public Property qteGrains() As Decimal
        Get
            Return m_QteGrains
        End Get
        Set(ByVal value As Decimal)
            m_QteGrains = value
        End Set
    End Property

    Private m_DebitSouhaitee As Decimal
    Public Property DebitSouhaite() As Decimal
        Get
            Return m_DebitSouhaitee
        End Get
        Set(ByVal value As Decimal)
            m_DebitSouhaitee = value
        End Set
    End Property
    Private m_Pesee1 As Decimal
    Public Property Pesee1() As Decimal
        Get
            Return m_Pesee1
        End Get
        Set(ByVal value As Decimal)
            m_Pesee1 = value
        End Set
    End Property
    Private m_Ecart1 As Decimal
    Public Property Ecart1() As Decimal
        Get
            Return m_Ecart1
        End Get
        Set(ByVal value As Decimal)
            m_Ecart1 = value
        End Set
    End Property
    Private m_Pesee2 As Decimal
    Public Property Pesee2() As Decimal
        Get
            Return m_Pesee2
        End Get
        Set(ByVal value As Decimal)
            m_Pesee2 = value
        End Set
    End Property
    Private m_Ecart2 As Decimal
    Public Property Ecart2() As Decimal
        Get
            Return m_Ecart2
        End Get
        Set(ByVal value As Decimal)
            m_Ecart2 = value
        End Set
    End Property
    Private m_Pesee3 As Decimal
    Public Property Pesee3() As Decimal
        Get
            Return m_Pesee3
        End Get
        Set(ByVal value As Decimal)
            m_Pesee3 = value
        End Set
    End Property
    Private m_Ecart3 As Decimal
    Public Property Ecart3() As Decimal
        Get
            Return m_Ecart3
        End Get
        Set(ByVal value As Decimal)
            m_Ecart3 = value
        End Set
    End Property
    Private m_PeseeMoyenne As Decimal
    Public Property PeseeMoyenne() As Decimal
        Get
            Return m_PeseeMoyenne
        End Get
        Set(ByVal value As Decimal)
            m_PeseeMoyenne = value
        End Set
    End Property
    Private m_EcartMoyen As Decimal
    Public Property EcartMoyen() As Decimal
        Get
            Return m_EcartMoyen
        End Get
        Set(ByVal value As Decimal)
            m_EcartMoyen = value
        End Set
    End Property
    Private m_Resultat As String
    Public Property Resultat() As String
        Get
            Return m_Resultat
        End Get
        Set(ByVal value As String)
            m_Resultat = value
        End Set
    End Property
    Public m_bCalcule As Boolean = True

    Public Const DIAGITEM_ID As String = "help12123TrtSem"
    Public LIMITE_ECART_MAJEUR As Decimal = 5

    Public Sub New(pNum As Integer)
        m_Resultat = ""
        m_numMesure = pNum
        '''// FOR PROP ONLY
        If pNum = 1 Then
            Image = New Bitmap("img/puces/V.jpg")
            m_Resultat = "OK"
        End If
        If pNum = 2 Then
            Image = New Bitmap("img/puces/R.jpg")
            m_Resultat = "ERREUR"
        End If
        If pNum = 3 Then
            Image = New Bitmap("img/puces/G.jpg")
            m_Resultat = ""
        End If
    End Sub
    Private _image As Bitmap
    Public Property Image() As Bitmap
        Get
            Return _image
        End Get
        Set(ByVal value As Bitmap)
            _image = value
        End Set
    End Property


    Public Sub New(ByVal pId As String, ByVal pIdDiag As String)
        m_id = pId
        m_idDiag = pIdDiag
        m_Resultat = ""
    End Sub


End Class
