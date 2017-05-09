Imports System.Collections.Generic
Imports System.Xml.Serialization
<Serializable()>
Public Class ParamDiagCalc542PlagePression
    Private m_mini As String
    Private m_Maxi As String
    Private m_colEcart As New List(Of ParamDiagCalc542Ecart)
    Public Sub New()

    End Sub
    Public Sub New(pMini As String, pMaxi As String)
        m_mini = pMini
        m_Maxi = pMaxi
    End Sub
    <XmlAttribute("Mini")>
    Public Property Mini As String
        Get
            Return m_mini
        End Get
        Set(value As String)
            m_mini = value.Replace(".", ",")
        End Set
    End Property
    <XmlAttribute("Maxi")>
    Public Property Maxi As String
        Get
            Return m_Maxi
        End Get
        Set(value As String)
            m_Maxi = value.Replace(".", ",")
        End Set
    End Property
    '    <XmlArrayItem("Ecart")>
    '    <XmlArray("Ecarts")>
    'Ce tag XML Permet d'éliminer le niveau collection dans le fichier XML
    <XmlElement("ECART")>
    Public ReadOnly Property colEcart As List(Of ParamDiagCalc542Ecart)
        Get
            Return m_colEcart
        End Get
    End Property
End Class
