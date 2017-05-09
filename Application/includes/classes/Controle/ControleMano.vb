Imports System.Web.Services
Imports System.Xml.Serialization
Imports System.Collections.Generic

<Serializable(), XmlInclude(GetType(ControleMano))> _
Public Class ControleMano

    Private _id As String
    Private _DateVerif As String
    Private _AgentVerif As String
    Private _Proprietaire As String
    Private _idStructure As String
    Private _idMano As String
    Private _idFichevie As String
    Private _manoEtalon As String
    Private _tempAir As String
    Private _resultat As String
    Private _pressionControle As String
    Private _valeurMesurees As String
    Private _lst As Dictionary(Of String, ControleManoDetail)
    Private _FileName As String


    Private _dateModificationAgent As String
    Private _dateModificationCrodip As String

    Sub New()
        _lst = New Dictionary(Of String, ControleManoDetail)

        _lst.Add("UP1", New ControleManoDetail("UP", "1"))
        _lst.Add("UP2", New ControleManoDetail("UP", "2"))
        _lst.Add("UP3", New ControleManoDetail("UP", "3"))
        _lst.Add("UP4", New ControleManoDetail("UP", "4"))
        _lst.Add("UP5", New ControleManoDetail("UP", "5"))
        _lst.Add("UP6", New ControleManoDetail("UP", "6"))
        _lst.Add("DOWN1", New ControleManoDetail("DOWN", "1"))
        _lst.Add("DOWN2", New ControleManoDetail("DOWN", "2"))
        _lst.Add("DOWN3", New ControleManoDetail("DOWN", "3"))
        _lst.Add("DOWN4", New ControleManoDetail("DOWN", "4"))
        _lst.Add("DOWN5", New ControleManoDetail("DOWN", "5"))
        _lst.Add("DOWN6", New ControleManoDetail("DOWN", "6"))
    End Sub

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

    Public Property idMano() As String
        Get
            Return _idMano
        End Get
        Set(ByVal Value As String)
            _idMano = Value
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

    Public Property manoEtalon() As String
        Get
            Return _manoEtalon
        End Get
        Set(ByVal Value As String)
            _manoEtalon = Value
        End Set
    End Property

    Public Property tempAir() As String
        Get
            Return _tempAir
        End Get
        Set(ByVal Value As String)
            _tempAir = Value
        End Set
    End Property

    Public Property resultat() As String
        Get
            Dim sReturn As String
            sReturn = "Votre manomètre est fiable : il répond à sa classe de précision."
            For Each oDetail As ControleManoDetail In _lst.Values
                If oDetail.conformite = "0" Then
                    sReturn = "Votre manomètre n'est pas fiable : il ne répond pas à sa classe de précision. Faites le remettre en état ou changez le."
                End If
            Next
            Return sReturn
        End Get
        Set(ByVal Value As String)
            _resultat = Value
        End Set
    End Property
    <XmlIgnore()>
    Public Property lstControleManoDetail As Dictionary(Of String, ControleManoDetail)
        Get
            Return _lst
        End Get
        Set(value As Dictionary(Of String, ControleManoDetail))

        End Set
    End Property
    Public Property up_pt1_pres_manoCtrl() As String
        Get
            Return _lst("UP1").pres_manoCtrl
        End Get
        Set(ByVal Value As String)
            _lst("UP1").pres_manoCtrl = Value
        End Set
    End Property

    Public Property up_pt1_pres_manoEtalon() As String
        Get
            Return _lst("UP1").pres_manoEtalon
        End Get
        Set(ByVal Value As String)
            _lst("UP1").pres_manoEtalon = Value
        End Set
    End Property

    Public Property up_pt1_incertitude() As String
        Get
            Return _lst("UP1").incertitude
        End Get
        Set(ByVal Value As String)
            _lst("UP1").incertitude = Value
        End Set
    End Property

    Public Property up_pt1_EMT() As String
        Get
            Return _lst("UP1").EMT
        End Get
        Set(ByVal Value As String)
            _lst("UP1").EMT = Value
        End Set
    End Property

    Public Property up_pt1_err_abs() As String
        Get
            Return _lst("UP1").err_abs
        End Get
        Set(ByVal Value As String)
            _lst("UP1").err_abs = Value
        End Set
    End Property

    Public Property up_pt1_err_fondEchelle() As String
        Get
            Return _lst("UP1").err_fondEchelle
        End Get
        Set(ByVal Value As String)
            _lst("UP1").err_fondEchelle = Value
        End Set
    End Property

    Public Property up_pt1_conformite() As String
        Get
            Return _lst("UP1").conformite
        End Get
        Set(ByVal Value As String)
            _lst("UP1").conformite = Value
        End Set
    End Property

    Public Property up_pt2_pres_manoCtrl() As String
        Get
            Return _lst("UP2").pres_manoCtrl
        End Get
        Set(ByVal Value As String)
            _lst("UP2").pres_manoCtrl = Value
        End Set
    End Property

    Public Property up_pt2_pres_manoEtalon() As String
        Get
            Return _lst("UP2").pres_manoEtalon
        End Get
        Set(ByVal Value As String)
            _lst("UP2").pres_manoEtalon = Value
        End Set
    End Property

    Public Property up_pt2_incertitude() As String
        Get
            Return _lst("UP2").incertitude
        End Get
        Set(ByVal Value As String)
            _lst("UP2").incertitude = Value
        End Set
    End Property

    Public Property up_pt2_EMT() As String
        Get
            Return _lst("UP2").EMT
        End Get
        Set(ByVal Value As String)
            _lst("UP2").EMT = Value
        End Set
    End Property

    Public Property up_pt2_err_abs() As String
        Get
            Return _lst("UP2").err_abs
        End Get
        Set(ByVal Value As String)
            _lst("UP2").err_abs = Value
        End Set
    End Property

    Public Property up_pt2_err_fondEchelle() As String
        Get
            Return _lst("UP2").err_fondEchelle
        End Get
        Set(ByVal Value As String)
            _lst("UP2").err_fondEchelle = Value
        End Set
    End Property

    Public Property up_pt2_conformite() As String
        Get
            Return _lst("UP2").conformite
        End Get
        Set(ByVal Value As String)
            _lst("UP2").conformite = Value
        End Set
    End Property

    Public Property up_pt3_pres_manoCtrl() As String
        Get
            Return _lst("UP3").pres_manoCtrl
        End Get
        Set(ByVal Value As String)
            _lst("UP3").pres_manoCtrl = Value
        End Set
    End Property

    Public Property up_pt3_pres_manoEtalon() As String
        Get
            Return _lst("UP3").pres_manoEtalon
        End Get
        Set(ByVal Value As String)
            _lst("UP3").pres_manoEtalon = Value
        End Set
    End Property

    Public Property up_pt3_incertitude() As String
        Get
            Return _lst("UP3").incertitude
        End Get
        Set(ByVal Value As String)
            _lst("UP3").incertitude = Value
        End Set
    End Property

    Public Property up_pt3_EMT() As String
        Get
            Return _lst("UP3").EMT
        End Get
        Set(ByVal Value As String)
            _lst("UP3").EMT = Value
        End Set
    End Property

    Public Property up_pt3_err_abs() As String
        Get
            Return _lst("UP3").err_abs
        End Get
        Set(ByVal Value As String)
            _lst("UP3").err_abs = Value
        End Set
    End Property

    Public Property up_pt3_err_fondEchelle() As String
        Get
            Return _lst("UP3").err_fondEchelle
        End Get
        Set(ByVal Value As String)
            _lst("UP3").err_fondEchelle = Value
        End Set
    End Property

    Public Property up_pt3_conformite() As String
        Get
            Return _lst("UP3").conformite
        End Get
        Set(ByVal Value As String)
            _lst("UP3").conformite = Value
        End Set
    End Property

    Public Property up_pt4_pres_manoCtrl() As String
        Get
            Return _lst("UP4").pres_manoCtrl
        End Get
        Set(ByVal Value As String)
            _lst("UP4").pres_manoCtrl = Value
        End Set
    End Property

    Public Property up_pt4_pres_manoEtalon() As String
        Get
            Return _lst("UP4").pres_manoEtalon
        End Get
        Set(ByVal Value As String)
            _lst("UP4").pres_manoEtalon = Value
        End Set
    End Property

    Public Property up_pt4_incertitude() As String
        Get
            Return _lst("UP4").incertitude
        End Get
        Set(ByVal Value As String)
            _lst("UP4").incertitude = Value
        End Set
    End Property

    Public Property up_pt4_EMT() As String
        Get
            Return _lst("UP4").EMT
        End Get
        Set(ByVal Value As String)
            _lst("UP4").EMT = Value
        End Set
    End Property

    Public Property up_pt4_err_abs() As String
        Get
            Return _lst("UP4").err_abs
        End Get
        Set(ByVal Value As String)
            _lst("UP4").err_abs = Value
        End Set
    End Property

    Public Property up_pt4_err_fondEchelle() As String
        Get
            Return _lst("UP4").err_fondEchelle
        End Get
        Set(ByVal Value As String)
            _lst("UP4").err_fondEchelle = Value
        End Set
    End Property

    Public Property up_pt4_conformite() As String
        Get
            Return _lst("UP4").conformite
        End Get
        Set(ByVal Value As String)
            _lst("UP4").conformite = Value
        End Set
    End Property

    Public Property up_pt5_pres_manoCtrl() As String
        Get
            Return _lst("UP5").pres_manoCtrl
        End Get
        Set(ByVal Value As String)
            _lst("UP5").pres_manoCtrl = Value
        End Set
    End Property

    Public Property up_pt5_pres_manoEtalon() As String
        Get
            Return _lst("UP5").pres_manoEtalon
        End Get
        Set(ByVal Value As String)
            _lst("UP5").pres_manoEtalon = Value
        End Set
    End Property

    Public Property up_pt5_incertitude() As String
        Get
            Return _lst("UP5").incertitude
        End Get
        Set(ByVal Value As String)
            _lst("UP5").incertitude = Value
        End Set
    End Property

    Public Property up_pt5_EMT() As String
        Get
            Return _lst("UP5").EMT
        End Get
        Set(ByVal Value As String)
            _lst("UP5").EMT = Value
        End Set
    End Property

    Public Property up_pt5_err_abs() As String
        Get
            Return _lst("UP5").err_abs
        End Get
        Set(ByVal Value As String)
            _lst("UP5").err_abs = Value
        End Set
    End Property

    Public Property up_pt5_err_fondEchelle() As String
        Get
            Return _lst("UP5").err_fondEchelle
        End Get
        Set(ByVal Value As String)
            _lst("UP5").err_fondEchelle = Value
        End Set
    End Property

    Public Property up_pt5_conformite() As String
        Get
            Return _lst("UP5").conformite
        End Get
        Set(ByVal Value As String)
            _lst("UP5").conformite = Value
        End Set
    End Property

    Public Property up_pt6_pres_manoCtrl() As String
        Get
            Return _lst("UP6").pres_manoCtrl
        End Get
        Set(ByVal Value As String)
            _lst("UP6").pres_manoCtrl = Value
        End Set
    End Property

    Public Property up_pt6_pres_manoEtalon() As String
        Get
            Return _lst("UP6").pres_manoEtalon
        End Get
        Set(ByVal Value As String)
            _lst("UP6").pres_manoEtalon = Value
        End Set
    End Property

    Public Property up_pt6_incertitude() As String
        Get
            Return _lst("UP6").incertitude
        End Get
        Set(ByVal Value As String)
            _lst("UP6").incertitude = Value
        End Set
    End Property

    Public Property up_pt6_EMT() As String
        Get
            Return _lst("UP6").EMT
        End Get
        Set(ByVal Value As String)
            _lst("UP6").EMT = Value
        End Set
    End Property

    Public Property up_pt6_err_abs() As String
        Get
            Return _lst("UP6").err_abs
        End Get
        Set(ByVal Value As String)
            _lst("UP6").err_abs = Value
        End Set
    End Property

    Public Property up_pt6_err_fondEchelle() As String
        Get
            Return _lst("UP6").err_fondEchelle
        End Get
        Set(ByVal Value As String)
            _lst("UP6").err_fondEchelle = Value
        End Set
    End Property

    Public Property up_pt6_conformite() As String
        Get
            Return _lst("UP6").conformite
        End Get
        Set(ByVal Value As String)
            _lst("UP6").conformite = Value
        End Set
    End Property

    Public Property down_pt1_pres_manoCtrl() As String
        Get
            Return _lst("DOWN1").pres_manoCtrl
        End Get
        Set(ByVal Value As String)
            _lst("DOWN1").pres_manoCtrl = Value
        End Set
    End Property

    Public Property down_pt1_pres_manoEtalon() As String
        Get
            Return _lst("DOWN1").pres_manoEtalon
        End Get
        Set(ByVal Value As String)
            _lst("DOWN1").pres_manoEtalon = Value
        End Set
    End Property

    Public Property down_pt1_incertitude() As String
        Get
            Return _lst("DOWN1").incertitude
        End Get
        Set(ByVal Value As String)
            _lst("DOWN1").incertitude = Value
        End Set
    End Property

    Public Property down_pt1_EMT() As String
        Get
            Return _lst("DOWN1").EMT
        End Get
        Set(ByVal Value As String)
            _lst("DOWN1").EMT = Value
        End Set
    End Property

    Public Property down_pt1_err_abs() As String
        Get
            Return _lst("DOWN1").err_abs
        End Get
        Set(ByVal Value As String)
            _lst("DOWN1").err_abs = Value
        End Set
    End Property

    Public Property down_pt1_err_fondEchelle() As String
        Get
            Return _lst("DOWN1").err_fondEchelle
        End Get
        Set(ByVal Value As String)
            _lst("DOWN1").err_fondEchelle = Value
        End Set
    End Property

    Public Property down_pt1_conformite() As String
        Get
            Return _lst("DOWN1").conformite
        End Get
        Set(ByVal Value As String)
            _lst("DOWN1").conformite = Value
        End Set
    End Property

    Public Property down_pt2_pres_manoCtrl() As String
        Get
            Return _lst("DOWN2").pres_manoCtrl
        End Get
        Set(ByVal Value As String)
            _lst("DOWN2").pres_manoCtrl = Value
        End Set
    End Property

    Public Property down_pt2_pres_manoEtalon() As String
        Get
            Return _lst("DOWN2").pres_manoEtalon
        End Get
        Set(ByVal Value As String)
            _lst("DOWN2").pres_manoEtalon = Value
        End Set
    End Property

    Public Property down_pt2_incertitude() As String
        Get
            Return _lst("DOWN2").incertitude
        End Get
        Set(ByVal Value As String)
            _lst("DOWN2").incertitude = Value
        End Set
    End Property

    Public Property down_pt2_EMT() As String
        Get
            Return _lst("DOWN2").EMT
        End Get
        Set(ByVal Value As String)
            _lst("DOWN2").EMT = Value
        End Set
    End Property

    Public Property down_pt2_err_abs() As String
        Get
            Return _lst("DOWN2").err_abs
        End Get
        Set(ByVal Value As String)
            _lst("DOWN2").err_abs = Value
        End Set
    End Property

    Public Property down_pt2_err_fondEchelle() As String
        Get
            Return _lst("DOWN2").err_fondEchelle
        End Get
        Set(ByVal Value As String)
            _lst("DOWN2").err_fondEchelle = Value
        End Set
    End Property

    Public Property down_pt2_conformite() As String
        Get
            Return _lst("DOWN2").conformite
        End Get
        Set(ByVal Value As String)
            _lst("DOWN2").conformite = Value
        End Set
    End Property

    Public Property down_pt3_pres_manoCtrl() As String
        Get
            Return _lst("DOWN3").pres_manoCtrl
        End Get
        Set(ByVal Value As String)
            _lst("DOWN3").pres_manoCtrl = Value
        End Set
    End Property

    Public Property down_pt3_pres_manoEtalon() As String
        Get
            Return _lst("DOWN3").pres_manoEtalon
        End Get
        Set(ByVal Value As String)
            _lst("DOWN3").pres_manoEtalon = Value
        End Set
    End Property

    Public Property down_pt3_incertitude() As String
        Get
            Return _lst("DOWN3").incertitude
        End Get
        Set(ByVal Value As String)
            _lst("DOWN3").incertitude = Value
        End Set
    End Property

    Public Property down_pt3_EMT() As String
        Get
            Return _lst("DOWN3").EMT
        End Get
        Set(ByVal Value As String)
            _lst("DOWN3").EMT = Value
        End Set
    End Property

    Public Property down_pt3_err_abs() As String
        Get
            Return _lst("DOWN3").err_abs
        End Get
        Set(ByVal Value As String)
            _lst("DOWN3").err_abs = Value
        End Set
    End Property

    Public Property down_pt3_err_fondEchelle() As String
        Get
            Return _lst("DOWN3").err_fondEchelle
        End Get
        Set(ByVal Value As String)
            _lst("DOWN3").err_fondEchelle = Value
        End Set
    End Property

    Public Property down_pt3_conformite() As String
        Get
            Return _lst("DOWN3").conformite
        End Get
        Set(ByVal Value As String)
            _lst("DOWN3").conformite = Value
        End Set
    End Property

    Public Property down_pt4_pres_manoCtrl() As String
        Get
            Return _lst("DOWN4").pres_manoCtrl
        End Get
        Set(ByVal Value As String)
            _lst("DOWN4").pres_manoCtrl = Value
        End Set
    End Property

    Public Property down_pt4_pres_manoEtalon() As String
        Get
            Return _lst("DOWN4").pres_manoEtalon
        End Get
        Set(ByVal Value As String)
            _lst("DOWN4").pres_manoEtalon = Value
        End Set
    End Property

    Public Property down_pt4_incertitude() As String
        Get
            Return _lst("DOWN4").incertitude
        End Get
        Set(ByVal Value As String)
            _lst("DOWN4").incertitude = Value
        End Set
    End Property

    Public Property down_pt4_EMT() As String
        Get
            Return _lst("DOWN4").EMT
        End Get
        Set(ByVal Value As String)
            _lst("DOWN4").EMT = Value
        End Set
    End Property

    Public Property down_pt4_err_abs() As String
        Get
            Return _lst("DOWN4").err_abs
        End Get
        Set(ByVal Value As String)
            _lst("DOWN4").err_abs = Value
        End Set
    End Property

    Public Property down_pt4_err_fondEchelle() As String
        Get
            Return _lst("DOWN4").err_fondEchelle
        End Get
        Set(ByVal Value As String)
            _lst("DOWN4").err_fondEchelle = Value
        End Set
    End Property

    Public Property down_pt4_conformite() As String
        Get
            Return _lst("DOWN4").conformite
        End Get
        Set(ByVal Value As String)
            _lst("DOWN4").conformite = Value
        End Set
    End Property

    Public Property down_pt5_pres_manoCtrl() As String
        Get
            Return _lst("DOWN5").pres_manoCtrl
        End Get
        Set(ByVal Value As String)
            _lst("DOWN5").pres_manoCtrl = Value
        End Set
    End Property

    Public Property down_pt5_pres_manoEtalon() As String
        Get
            Return _lst("DOWN5").pres_manoEtalon
        End Get
        Set(ByVal Value As String)
            _lst("DOWN5").pres_manoEtalon = Value
        End Set
    End Property

    Public Property down_pt5_incertitude() As String
        Get
            Return _lst("DOWN5").incertitude
        End Get
        Set(ByVal Value As String)
            _lst("DOWN5").incertitude = Value
        End Set
    End Property

    Public Property down_pt5_EMT() As String
        Get
            Return _lst("DOWN5").EMT
        End Get
        Set(ByVal Value As String)
            _lst("DOWN5").EMT = Value
        End Set
    End Property

    Public Property down_pt5_err_abs() As String
        Get
            Return _lst("DOWN5").err_abs
        End Get
        Set(ByVal Value As String)
            _lst("DOWN5").err_abs = Value
        End Set
    End Property

    Public Property down_pt5_err_fondEchelle() As String
        Get
            Return _lst("DOWN5").err_fondEchelle
        End Get
        Set(ByVal Value As String)
            _lst("DOWN5").err_fondEchelle = Value
        End Set
    End Property

    Public Property down_pt5_conformite() As String
        Get
            Return _lst("DOWN5").conformite
        End Get
        Set(ByVal Value As String)
            _lst("DOWN5").conformite = Value
        End Set
    End Property

    Public Property down_pt6_pres_manoCtrl() As String
        Get
            Return _lst("DOWN6").pres_manoCtrl
        End Get
        Set(ByVal Value As String)
            _lst("DOWN6").pres_manoCtrl = Value
        End Set
    End Property

    Public Property down_pt6_pres_manoEtalon() As String
        Get
            Return _lst("DOWN6").pres_manoEtalon
        End Get
        Set(ByVal Value As String)
            _lst("DOWN6").pres_manoEtalon = Value
        End Set
    End Property

    Public Property down_pt6_incertitude() As String
        Get
            Return _lst("DOWN6").incertitude
        End Get
        Set(ByVal Value As String)
            _lst("DOWN6").incertitude = Value
        End Set
    End Property

    Public Property down_pt6_EMT() As String
        Get
            Return _lst("DOWN6").EMT
        End Get
        Set(ByVal Value As String)
            _lst("DOWN6").EMT = Value
        End Set
    End Property

    Public Property down_pt6_err_abs() As String
        Get
            Return _lst("DOWN6").err_abs
        End Get
        Set(ByVal Value As String)
            _lst("DOWN6").err_abs = Value
        End Set
    End Property

    Public Property down_pt6_err_fondEchelle() As String
        Get
            Return _lst("DOWN6").err_fondEchelle
        End Get
        Set(ByVal Value As String)
            _lst("DOWN6").err_fondEchelle = Value
        End Set
    End Property

    Public Property down_pt6_conformite() As String
        Get
            Return _lst("DOWN6").conformite
        End Get
        Set(ByVal Value As String)
            _lst("DOWN6").conformite = Value
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
    Public Property PressionControle As String
        Get
            Return _pressionControle
        End Get
        Set(value As String)
            _pressionControle = value
        End Set
    End Property
    Public Property ValeursMesurees As String
        Get
            Return _valeurMesurees
        End Get
        Set(value As String)
            _valeurMesurees = value
        End Set
    End Property
    Public Property FileName As String
        Get
            Return _FileName
        End Get
        Set(value As String)
            _FileName = value
        End Set
    End Property

    Public Function buildPDF() As String

        Dim oEtat As New EtatFVMano(Me)
        If oEtat.GenereEtat() Then
            '            oEtat.Open()
        End If

        _FileName = oEtat.getFileName()
        Return oEtat.getFileName()

    End Function 'Build PDF


End Class

