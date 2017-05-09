Imports System.Web.Services
Imports System.Xml.Serialization

<Serializable(), XmlInclude(GetType(PrestationTarif))> _
Public Class PrestationTarif
    Inherits Tarif

    Private _idCategorie As Integer

    Sub New()
        m_isCategorie = False
    End Sub



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

    Public Function Fill(ByVal pName As String, ByVal pValue As Object) As Boolean
        Dim bReturn As Boolean
        Try

            Select Case pName
                Case "id"
                    Me.id = pValue
                Case "idStructure"
                    Me.idStructure = pValue
                Case "idCategorie"
                    Me.idCategorie = pValue
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
