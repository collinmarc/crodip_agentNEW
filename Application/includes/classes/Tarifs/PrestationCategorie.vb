Imports System.Web.Services
Imports System.Xml.Serialization

<Serializable(), XmlInclude(GetType(PrestationCategorie))> _
Public Class PrestationCategorie
    Inherits Tarif


    Sub New()
        m_isCategorie = True
    End Sub
    ''' <summary>
    ''' Redifinition de la description en libelle pour la synchro
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property libelle() As String
        Get
            Return description
        End Get
        Set(ByVal Value As String)
            description = Value
        End Set
    End Property



End Class
