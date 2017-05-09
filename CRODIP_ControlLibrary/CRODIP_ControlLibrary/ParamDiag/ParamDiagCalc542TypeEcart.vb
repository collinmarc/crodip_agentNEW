Imports System.Collections.Generic
Imports System.Xml.Serialization
<Serializable()>
Public Class ParamDiagCalc542TypeEcart

    Private m_Type As String ' Variable/Constant'
    Private m_colPression As New List(Of ParamDiagCalc542PlagePression)

    Public Sub New()

    End Sub

    Public Sub New(pType As String)
        m_Type = pType
    End Sub
    <XmlAttribute("Type")>
    Public Property Type As String
        Get
            Return m_Type
        End Get
        Set(value As String)
            m_Type = value
        End Set
    End Property
    '    <XmlArrayItem("PlagePression")>
    'Ce tag XML Permet d'éliminer le niveau collection dans le fichier XML
    <XmlElement("PLAGEPRESSION")>
    Public ReadOnly Property colPression As List(Of ParamDiagCalc542PlagePression)
        Get
            Return m_colPression
        End Get
    End Property
End Class
