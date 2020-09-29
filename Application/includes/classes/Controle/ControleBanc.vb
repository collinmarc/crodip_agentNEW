Imports System.Web.Services
Imports System.Xml.Serialization
Imports System.Collections.Generic

<Serializable(), XmlInclude(GetType(ControleBanc))> _
Public Class ControleBanc

    Private _id As String
    Private _DateVerif As String
    Private _AgentVerif As String
    Private _Proprietaire As String
    Private _idStructure As String
    Private _idBanc As String
    Private _idFichevie As String
    Private _buse1 As String
    Private _buse2 As String
    Private _buse3 As String
    Private _buse4 As String
    Private _buse5 As String
    Private _buse6 As String
    Private _tempExt As String
    Private _tempEau As String
    Private _resultat As String
    Private _bresultat As Boolean


    Private _lstMesures As List(Of ControleBancBuse)
    Private _dateModificationAgent As String
    Private _dateModificationCrodip As String

    Sub New()
        _lstMesures = New List(Of ControleBancBuse)()
        _lstMesures.Add(New ControleBancBuse("1"))
        _lstMesures.Add(New ControleBancBuse("2"))
        _lstMesures.Add(New ControleBancBuse("3"))
        _lstMesures.Add(New ControleBancBuse("4"))
        _lstMesures.Add(New ControleBancBuse("5"))
        _lstMesures.Add(New ControleBancBuse("6"))
    End Sub

    Public ReadOnly Property lstMesures As List(Of ControleBancBuse)
        Get
            Return _lstMesures
        End Get
    End Property
    Public Property id() As String
        Get
            Return _id
        End Get
        Set(ByVal Value As String)
            _id = Value
        End Set
    End Property

    Public Property idStructure() As String
        Get
            Return _idStructure
        End Get
        Set(ByVal Value As String)
            _idStructure = Value
        End Set
    End Property

    Public Property idBanc() As String
        Get
            Return _idBanc
        End Get
        Set(ByVal Value As String)
            _idBanc = Value
        End Set
    End Property

    Public Property idFichevie() As String
        Get
            Return _idFichevie
        End Get
        Set(ByVal Value As String)
            _idFichevie = Value
        End Set
    End Property

    Public Property buse1() As String
        Get
            Return b1_NumNatBuse
        End Get
        Set(ByVal Value As String)
            b1_NumNatBuse = Value
        End Set
    End Property

    Public Property buse2() As String
        Get
            Return b2_NumNatBuse
        End Get
        Set(ByVal Value As String)
            b2_NumNatBuse = Value
        End Set
    End Property

    Public Property buse3() As String
        Get
            Return b3_NumNatBuse
        End Get
        Set(ByVal Value As String)
            b3_NumNatBuse = Value
        End Set
    End Property

    Public Property buse4() As String
        Get
            Return b4_NumNatBuse
        End Get
        Set(ByVal Value As String)
            b4_NumNatBuse = Value
        End Set
    End Property

    Public Property buse5() As String
        Get
            Return b5_NumNatBuse
        End Get
        Set(ByVal Value As String)
            b5_NumNatBuse = Value
        End Set
    End Property

    Public Property buse6() As String
        Get
            Return b6_NumNatBuse
        End Get
        Set(ByVal Value As String)
            b6_NumNatBuse = Value
        End Set
    End Property

    Public Property tempExt() As String
        Get
            Return _tempExt
        End Get
        Set(ByVal Value As String)
            _tempExt = Value
        End Set
    End Property

    Public Property tempEau() As String
        Get
            Return _tempEau
        End Get
        Set(ByVal Value As String)
            _tempEau = Value
        End Set
    End Property

    Public Property resultat() As String
        Get
            Return _resultat
        End Get
        Set(ByVal Value As String)
            _resultat = Value
        End Set
    End Property
    Public Property bResultat() As Boolean
        Get
            Return _bresultat
        End Get
        Set(ByVal Value As Boolean)
            _bresultat = Value
        End Set
    End Property
    Public Property DateVerif As String
        Get
            Return _DateVerif
        End Get
        Set(value As String)
            _DateVerif = value
        End Set
    End Property
    Public Property AgentVerif As String
        Get
            Return _AgentVerif
        End Get
        Set(value As String)
            _AgentVerif = value
        End Set
    End Property
    Public Property Proprietaire As String
        Get
            Return _Proprietaire
        End Get
        Set(value As String)
            _Proprietaire = value
        End Set
    End Property

    Public Property b1_couleur() As String
        Get
            Return _lstMesures(0).Couleur
        End Get
        Set(ByVal Value As String)
            _lstMesures(0).Couleur = Value
        End Set
    End Property

    Public Property b2_couleur() As String
        Get
            Return _lstMesures(1).Couleur
        End Get
        Set(ByVal Value As String)
            _lstMesures(1).Couleur = Value
        End Set
    End Property
    Public Property b3_couleur() As String
        Get
            Return _lstMesures(2).Couleur
        End Get
        Set(ByVal Value As String)
            _lstMesures(2).Couleur = Value
        End Set
    End Property
    Public Property b4_couleur() As String
        Get
            Return _lstMesures(3).Couleur
        End Get
        Set(ByVal Value As String)
            _lstMesures(3).Couleur = Value
        End Set
    End Property
    Public Property b5_couleur() As String
        Get
            Return _lstMesures(4).Couleur
        End Get
        Set(ByVal Value As String)
            _lstMesures(4).Couleur = Value
        End Set
    End Property
    Public Property b6_couleur() As String
        Get
            Return _lstMesures(5).Couleur
        End Get
        Set(ByVal Value As String)
            _lstMesures(5).Couleur = Value
        End Set
    End Property

    Public Property b1_NumNatBuse() As String
        Get
            Return _lstMesures(0).NumNatBuse
        End Get
        Set(ByVal Value As String)
            _lstMesures(0).NumNatBuse = Value
        End Set
    End Property

    Public Property b2_NumNatBuse() As String
        Get
            Return _lstMesures(1).NumNatBuse
        End Get
        Set(ByVal Value As String)
            _lstMesures(1).NumNatBuse = Value
        End Set
    End Property
    Public Property b3_NumNatBuse() As String
        Get
            Return _lstMesures(2).NumNatBuse
        End Get
        Set(ByVal Value As String)
            _lstMesures(2).NumNatBuse = Value
        End Set
    End Property
    Public Property b4_NumNatBuse() As String
        Get
            Return _lstMesures(3).NumNatBuse
        End Get
        Set(ByVal Value As String)
            _lstMesures(3).NumNatBuse = Value
        End Set
    End Property
    Public Property b5_NumNatBuse() As String
        Get
            Return _lstMesures(4).NumNatBuse
        End Get
        Set(ByVal Value As String)
            _lstMesures(4).NumNatBuse = Value
        End Set
    End Property
    Public Property b6_NumNatBuse() As String
        Get
            Return _lstMesures(5).NumNatBuse
        End Get
        Set(ByVal Value As String)
            _lstMesures(5).NumNatBuse = Value
        End Set
    End Property

    Public Property b1_pressionEtal() As String
        Get
            Return _lstMesures(0).pressionEtal
        End Get
        Set(ByVal Value As String)
            _lstMesures(0).pressionEtal = Value
        End Set
    End Property

    Public Property b1_debitEtal() As String
        Get
            Return _lstMesures(0).debitEtal
        End Get
        Set(ByVal Value As String)
            _lstMesures(0).debitEtal = Value
        End Set
    End Property


    Public Property b1_3bar_m1() As String
        Get
            Return _lstMesures(0).m1_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(0).m1_3bar = Value
        End Set
    End Property

    Public Property b1_3bar_m2() As String
        Get
            Return _lstMesures(0).m2_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(0).m2_3bar = Value
        End Set
    End Property

    Public Property b1_3bar_m3() As String
        Get
            Return _lstMesures(0).m3_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(0).m3_3bar = Value
        End Set
    End Property

    Public Property b1_3bar_moy() As String
        Get
            Return _lstMesures(0).moy_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(0).moy_3bar = Value
        End Set
    End Property

    Public Property b1_3bar_ecart() As String
        Get
            Return _lstMesures(0).ecart_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(0).ecart_3bar = Value
        End Set
    End Property
    Public Property b1_3bar_pctEcart() As String
        Get
            Return _lstMesures(0).pctEcart_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(0).pctEcart_3bar = Value
        End Set
    End Property
    Public Property b1_3bar_pctTolerance() As String
        Get
            Return _lstMesures(0).pctTolerance_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(0).pctTolerance_3bar = Value
        End Set
    End Property

    Public Property b2_pressionEtal() As String
        Get
            Return _lstMesures(1).pressionEtal
        End Get
        Set(ByVal Value As String)
            _lstMesures(1).pressionEtal = Value
        End Set
    End Property

    Public Property b2_debitEtal() As String
        Get
            Return _lstMesures(1).debitEtal
        End Get
        Set(ByVal Value As String)
            _lstMesures(1).debitEtal = Value
        End Set
    End Property


    Public Property b2_3bar_m1() As String
        Get
            Return _lstMesures(1).m1_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(1).m1_3bar = Value
        End Set
    End Property

    Public Property b2_3bar_m2() As String
        Get
            Return _lstMesures(1).m2_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(1).m2_3bar = Value
        End Set
    End Property

    Public Property b2_3bar_m3() As String
        Get
            Return _lstMesures(1).m3_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(1).m3_3bar = Value
        End Set
    End Property

    Public Property b2_3bar_moy() As String
        Get
            Return _lstMesures(1).moy_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(1).moy_3bar = Value
        End Set
    End Property

    Public Property b2_3bar_ecart() As String
        Get
            Return _lstMesures(1).ecart_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(1).ecart_3bar = Value
        End Set
    End Property

    Public Property b2_3bar_pctEcart() As String
        Get
            Return _lstMesures(1).pctEcart_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(1).pctEcart_3bar = Value
        End Set
    End Property
    Public Property b2_3bar_pctTolerance() As String
        Get
            Return _lstMesures(1).pctTolerance_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(1).pctTolerance_3bar = Value
        End Set
    End Property
    Public Property b3_pressionEtal() As String
        Get
            Return _lstMesures(2).pressionEtal
        End Get
        Set(ByVal Value As String)
            _lstMesures(2).pressionEtal = Value
        End Set
    End Property

    Public Property b3_debitEtal() As String
        Get
            Return _lstMesures(2).debitEtal
        End Get
        Set(ByVal Value As String)
            _lstMesures(2).debitEtal = Value
        End Set
    End Property


    Public Property b3_3bar_m1() As String
        Get
            Return _lstMesures(2).m1_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(2).m1_3bar = Value
        End Set
    End Property

    Public Property b3_3bar_m2() As String
        Get
            Return _lstMesures(2).m2_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(2).m2_3bar = Value
        End Set
    End Property

    Public Property b3_3bar_m3() As String
        Get
            Return _lstMesures(2).m3_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(2).m3_3bar = Value
        End Set
    End Property

    Public Property b3_3bar_moy() As String
        Get
            Return _lstMesures(2).moy_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(2).moy_3bar = Value
        End Set
    End Property

    Public Property b3_3bar_ecart() As String
        Get
            Return _lstMesures(2).ecart_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(2).ecart_3bar = Value
        End Set
    End Property
    Public Property b3_3bar_pctEcart() As String
        Get
            Return _lstMesures(2).pctEcart_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(2).pctEcart_3bar = Value
        End Set
    End Property
    Public Property b3_3bar_pctTolerance() As String
        Get
            Return _lstMesures(2).pctTolerance_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(2).pctTolerance_3bar = Value
        End Set
    End Property

    Public Property b4_pressionEtal() As String
        Get
            Return _lstMesures(3).pressionEtal
        End Get
        Set(ByVal Value As String)
            _lstMesures(3).pressionEtal = Value
        End Set
    End Property

    Public Property b4_debitEtal() As String
        Get
            Return _lstMesures(3).debitEtal
        End Get
        Set(ByVal Value As String)
            _lstMesures(3).debitEtal = Value
        End Set
    End Property


    Public Property b4_3bar_m1() As String
        Get
            Return _lstMesures(3).m1_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(3).m1_3bar = Value
        End Set
    End Property

    Public Property b4_3bar_m2() As String
        Get
            Return _lstMesures(3).m2_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(3).m2_3bar = Value
        End Set
    End Property

    Public Property b4_3bar_m3() As String
        Get
            Return _lstMesures(3).m3_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(3).m3_3bar = Value
        End Set
    End Property

    Public Property b4_3bar_moy() As String
        Get
            Return _lstMesures(3).moy_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(3).moy_3bar = Value
        End Set
    End Property

    Public Property b4_3bar_ecart() As String
        Get
            Return _lstMesures(3).ecart_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(3).ecart_3bar = Value
        End Set
    End Property
    Public Property b4_3bar_pctEcart() As String
        Get
            Return _lstMesures(3).pctEcart_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(3).pctEcart_3bar = Value
        End Set
    End Property
    Public Property b4_3bar_pctTolerance() As String
        Get
            Return _lstMesures(3).pctTolerance_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(3).pctTolerance_3bar = Value
        End Set
    End Property

    Public Property b5_pressionEtal() As String
        Get
            Return _lstMesures(4).pressionEtal
        End Get
        Set(ByVal Value As String)
            _lstMesures(4).pressionEtal = Value
        End Set
    End Property

    Public Property b5_debitEtal() As String
        Get
            Return _lstMesures(4).debitEtal
        End Get
        Set(ByVal Value As String)
            _lstMesures(4).debitEtal = Value
        End Set
    End Property

    Public Property b5_3bar_m1() As String
        Get
            Return _lstMesures(4).m1_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(4).m1_3bar = Value
        End Set
    End Property

    Public Property b5_3bar_m2() As String
        Get
            Return _lstMesures(4).m2_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(4).m2_3bar = Value
        End Set
    End Property

    Public Property b5_3bar_m3() As String
        Get
            Return _lstMesures(4).m3_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(4).m3_3bar = Value
        End Set
    End Property

    Public Property b5_3bar_moy() As String
        Get
            Return _lstMesures(4).moy_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(4).moy_3bar = Value
        End Set
    End Property

    Public Property b5_3bar_ecart() As String
        Get
            Return _lstMesures(4).ecart_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(4).ecart_3bar = Value
        End Set
    End Property
    Public Property b5_3bar_pctEcart() As String
        Get
            Return _lstMesures(4).pctEcart_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(4).pctEcart_3bar = Value
        End Set
    End Property
    Public Property b5_3bar_pctTolerance() As String
        Get
            Return _lstMesures(4).pctTolerance_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(4).pctTolerance_3bar = Value
        End Set
    End Property

    Public Property b6_pressionEtal() As String
        Get
            Return _lstMesures(5).pressionEtal
        End Get
        Set(ByVal Value As String)
            _lstMesures(5).pressionEtal = Value
        End Set
    End Property

    Public Property b6_debitEtal() As String
        Get
            Return _lstMesures(5).debitEtal
        End Get
        Set(ByVal Value As String)
            _lstMesures(5).debitEtal = Value
        End Set
    End Property


    Public Property b6_3bar_m1() As String
        Get
            Return _lstMesures(5).m1_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(5).m1_3bar = Value
        End Set
    End Property

    Public Property b6_3bar_m2() As String
        Get
            Return _lstMesures(5).m2_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(5).m2_3bar = Value
        End Set
    End Property

    Public Property b6_3bar_m3() As String
        Get
            Return _lstMesures(5).m3_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(5).m3_3bar = Value
        End Set
    End Property

    Public Property b6_3bar_moy() As String
        Get
            Return _lstMesures(5).moy_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(5).moy_3bar = Value
        End Set
    End Property

    Public Property b6_3bar_ecart() As String
        Get
            Return _lstMesures(5).ecart_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(5).ecart_3bar = Value
        End Set
    End Property
    Public Property b6_3bar_pctEcart() As String
        Get
            Return _lstMesures(5).pctEcart_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(5).pctEcart_3bar = Value
        End Set
    End Property
    Public Property b6_3bar_pctTolerance() As String
        Get
            Return _lstMesures(5).pctTolerance_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(5).pctTolerance_3bar = Value
        End Set
    End Property

    Public Property dateModificationAgent() As String
        Get
            Return _dateModificationAgent
        End Get
        Set(ByVal Value As String)
            _dateModificationAgent = Value
        End Set
    End Property

    Public Property dateModificationCrodip() As String
        Get
            Return _dateModificationCrodip
        End Get
        Set(ByVal Value As String)
            _dateModificationCrodip = Value
        End Set
    End Property

    Public Property b1_3bar_conformite() As String
        Get
            Return _lstMesures(0).resultat_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(0).resultat_3bar = Value
        End Set
    End Property

    Public Property b2_3bar_conformite() As String
        Get
            Return _lstMesures(1).resultat_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(1).resultat_3bar = Value
        End Set
    End Property

    Public Property b3_3bar_conformite() As String
        Get
            Return _lstMesures(2).resultat_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(2).resultat_3bar = Value
        End Set
    End Property

    Public Property b4_3bar_conformite() As String
        Get
            Return _lstMesures(3).resultat_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(3).resultat_3bar = Value
        End Set
    End Property

    Public Property b5_3bar_conformite() As String
        Get
            Return _lstMesures(4).resultat_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(4).resultat_3bar = Value
        End Set
    End Property

    Public Property b6_3bar_conformite() As String
        Get
            Return _lstMesures(5).resultat_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(5).resultat_3bar = Value
        End Set
    End Property

    Public Property b1_pctEcart3bar() As String
        Get
            Return _lstMesures(0).pctEcart_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(0).pctEcart_3bar = Value
        End Set
    End Property
    Public Property b2_pctEcart3bar() As String
        Get
            Return _lstMesures(1).pctEcart_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(1).pctEcart_3bar = Value
        End Set
    End Property
    Public Property b3_pctEcart3bar() As String
        Get
            Return _lstMesures(2).pctEcart_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(2).pctEcart_3bar = Value
        End Set
    End Property
    Public Property b4_pctEcart3bar() As String
        Get
            Return _lstMesures(3).pctEcart_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(3).pctEcart_3bar = Value
        End Set
    End Property
    Public Property b5_pctEcart3bar() As String
        Get
            Return _lstMesures(4).pctEcart_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(4).pctEcart_3bar = Value
        End Set
    End Property
    Public Property b6_pctEcart3bar() As String
        Get
            Return _lstMesures(5).pctEcart_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(5).pctEcart_3bar = Value
        End Set
    End Property

    Public Property b1_pctTolerance() As String
        Get
            Return _lstMesures(0).pctTolerance_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(0).pctTolerance_3bar = Value
        End Set
    End Property
    Public Property b2_pctTolerance() As String
        Get
            Return _lstMesures(1).pctTolerance_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(1).pctTolerance_3bar = Value
        End Set
    End Property
    Public Property b3_pctTolerance() As String
        Get
            Return _lstMesures(2).pctTolerance_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(2).pctTolerance_3bar = Value
        End Set
    End Property
    Public Property b4_pctTolerance() As String
        Get
            Return _lstMesures(3).pctTolerance_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(3).pctTolerance_3bar = Value
        End Set
    End Property
    Public Property b5_pctTolerance() As String
        Get
            Return _lstMesures(4).pctTolerance_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(4).pctTolerance_3bar = Value
        End Set
    End Property
    Public Property b6_pctTolerance() As String
        Get
            Return _lstMesures(5).pctTolerance_3bar
        End Get
        Set(ByVal Value As String)
            _lstMesures(5).pctTolerance_3bar = Value
        End Set
    End Property

    Public Sub calc_ecart_buse1()
        _lstMesures(0).calc_ecart_buse()
    End Sub
    Public Sub calc_ecart_buse2()
        _lstMesures(1).calc_ecart_buse()
    End Sub
    Public Sub calc_ecart_buse3()
        _lstMesures(2).calc_ecart_buse()
    End Sub
    Public Sub calc_ecart_buse4()
        _lstMesures(3).calc_ecart_buse()
    End Sub
    Public Sub calc_ecart_buse5()
        _lstMesures(4).calc_ecart_buse()
    End Sub
    Public Sub calc_ecart_buse6()
        _lstMesures(5).calc_ecart_buse()
    End Sub

    Public Sub setbuse1(pBuse As Buse)
        _lstMesures(0).SetBuse(pBuse)
    End Sub
    Public Sub setbuse2(pBuse As Buse)
        _lstMesures(1).SetBuse(pBuse)
    End Sub
    Public Sub setbuse3(pBuse As Buse)
        _lstMesures(2).SetBuse(pBuse)
    End Sub
    Public Sub setbuse4(pBuse As Buse)
        _lstMesures(3).SetBuse(pBuse)
    End Sub
    Public Sub setbuse5(pBuse As Buse)
        _lstMesures(4).SetBuse(pBuse)
    End Sub
    Public Sub setbuse6(pBuse As Buse)
        _lstMesures(5).SetBuse(pBuse)
    End Sub
    Public Sub calc1()
        _lstMesures(0).Calc()
        CalcResultat()
    End Sub
    Public Sub calc2()
        _lstMesures(1).Calc()
        CalcResultat()
    End Sub
    Public Sub calc3()
        _lstMesures(2).Calc()
        CalcResultat()
    End Sub
    Public Sub calc4()
        _lstMesures(3).Calc()
        CalcResultat()
    End Sub
    Public Sub calc5()
        _lstMesures(4).Calc()
        CalcResultat()
    End Sub
    Public Sub calc6()
        _lstMesures(5).Calc()
        CalcResultat()
    End Sub

    Private Sub CalcResultat()
        bResultat = True
        For Each oBuse As ControleBancBuse In lstMesures
            If Not String.IsNullOrEmpty(oBuse.Couleur) Then
                bResultat = bResultat And oBuse.resultat_3bar
            End If
        Next
        If bResultat Then
            Me.resultat = "Votre banc de mesure de débit est dans les tolérances admises pour le contrôle obligatoire"
        Else
            Me.resultat = "Le résultat est négatif : vérifiez votre banc de mesure de débits"
        End If
    End Sub
    ''' <summary>
    ''' construction du PDF de Fiche de Vie Controle 
    ''' </summary>
    ''' <param name="curBanc"></param>
    ''' <param name="pAgent"></param>
    ''' <returns>le Nom du Fichier PDF Généré ou Vide</returns>
    ''' <remarks></remarks>
    Public Function buildPDF(ByVal curBanc As Banc, pAgent As Agent) As String
        Dim sReturn As String

        Me.DateVerif = curBanc.dateDernierControleS
        Me.Proprietaire = pAgent.NomStructure
        Me.AgentVerif = pAgent.nom & " " & pAgent.prenom
        Me.idBanc = curBanc.id

        Dim oEtat As New EtatFVBanc(Me)
        Dim bReturn As Boolean = oEtat.GenereEtat()
        If bReturn Then
            sReturn = oEtat.getFileName()
        Else
            sReturn = ""
        End If
        Return sReturn
    End Function 'BuildPDF
End Class
