Imports Crodip_agent
Imports System.Xml.Serialization

<Serializable()>
<XmlRoot("DiagnosticItem")>
Public Class DiagnosticItemAuto
    Inherits DiagnosticItem
    Enum EtatDiagItemAuto
        Actif
        Inactif
    End Enum

    Public Sub New(idDiagnostic As String, pItem As String, pValue As String, Optional pCause As String = "", Optional pCodeEtat As String = "")
        MyBase.New(idDiagnostic, pItem, pValue, pCause, pCodeEtat)
        Etat = EtatDiagItemAuto.Inactif
    End Sub

    Private m_Etat As EtatDiagItemAuto
    <XmlIgnore()>
    Public Property Etat() As EtatDiagItemAuto
        Get
            Return m_Etat
        End Get

        Set(ByVal value As EtatDiagItemAuto)
            m_Etat = value
        End Set
    End Property

    Public Sub FillWithParam(pTypectrl As CRODIP_ControlLibrary.ParamCtrlDiag)
        MyBase.SetItemCodeEtat(pTypectrl.DefaultCategorie)
        LibelleLong = pTypectrl.LibelleLong
        LibelleCourt = pTypectrl.Libelle

        Etat = EtatDiagItemAuto.Actif
    End Sub

End Class
