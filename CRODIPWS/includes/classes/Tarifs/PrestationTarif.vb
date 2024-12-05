Imports System.Web.Services
Imports System.Xml.Serialization

<Serializable(), XmlInclude(GetType(PrestationTarif))> _
Public Class PrestationTarif
    Inherits Tarif

    Private _idCategorie As Integer
    Private _uidCategorie As Integer

    Sub New()
        m_isCategorie = False
    End Sub
    Public Property uidcategorie() As String
        Get
            Return _uidCategorie
        End Get
        Set(ByVal value As String)
            If value <> uidcategorie Then
                _uidCategorie = value
                UpdateEtat()
                dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
            End If
        End Set
    End Property

    <XmlElement("numCategorie")>
    Public Property idCategorie() As Integer
        Get
            Return _idCategorie
        End Get
        Set(ByVal Value As Integer)
            If Value <> _idCategorie Then
                _idCategorie = Value
                UpdateEtat()
                dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
            End If
        End Set
    End Property
    Public Property numTarif() As Integer
        Get
            Return id
        End Get
        Set(ByVal value As Integer)
            id = value
        End Set
    End Property

    Public Overrides Function Fill(ByVal pName As String, ByVal pValue As Object) As Boolean
        Dim bReturn As Boolean
        Try

            Select Case pName
                Case "id"
                    Me.id = pValue
                Case "uid"
                    Me.uid = pValue
                Case "idStructure"
                    Me.idStructure = pValue
                Case "uidstructure"
                    Me.uidstructure = pValue
                Case "idCategorie"
                    Me.idCategorie = pValue
                Case "numCategorie"
                    Me.idCategorie = pValue
                Case "numTarif"
                    Me.id = pValue
                Case "uidcategorie"
                    Me.uidcategorie = pValue
                Case "description"
                    Me.description = pValue.ToString()
                Case "tarifHT"
                    Me.tarifHT = pValue
                Case "tarifTTC"
                    Me.tarifTTC = pValue
                Case "tva"
                    Me.tva = pValue
                Case "dateModificationAgent"
                    Me.dateModificationAgent = CSDate.ToCRODIPString(pValue.ToString())
                Case "dateModificationCrodip"
                    Me.dateModificationCrodip = CSDate.ToCRODIPString(pValue.ToString())
            End Select
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("PrestationTarif.Fill(" & pName & "," & pValue.ToString() & ") ERR : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function



End Class
