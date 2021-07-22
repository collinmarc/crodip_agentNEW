Imports System.Xml.Serialization
Public Class Tarif
    Protected m__id As Integer
    Protected m_idStructure As Integer
    Protected m_isCategorie As Boolean
    Protected m_description As String
    'Uniquement pour pertation tarif
    Private _tarifHT As Decimal
    Private _tarifTTC As Decimal
    Private _tva As Decimal
    Protected m_dateModificationAgent As String
    Protected m_dateModificationCrodip As String

    Private m_etat As BDEtat

    Public Enum BDEtat As Integer
        ETATNEW = 1
        ETATUPDATED = 2
        ETATDELETED = 3
        ETATNONE = 4
    End Enum

    Public Sub New()
        m_description = ""
        '        tva = My.Settings.TxTVADefaut
        tarifHT = 0
        tarifTTC = 0
        m_etat = BDEtat.ETATNEW
    End Sub
    Protected Sub UpdateEtat()
        If m_etat = BDEtat.ETATNONE Then
            m_etat = BDEtat.ETATUPDATED
        End If
    End Sub
    Public Sub setEtat(pEtat As BDEtat)
        m_etat = pEtat
    End Sub
    Public Function getEtat() As BDEtat
        Return m_etat
    End Function

    Public Property id() As Integer
        Get
            Return m__id
        End Get
        Set(ByVal Value As Integer)
            If Value <> m__id Then
                m__id = Value
                UpdateEtat()
                dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
            End If
        End Set
    End Property
    Public Property idStructure() As Integer
        Get
            Return m_idStructure
        End Get
        Set(ByVal Value As Integer)
            If Value <> m_idStructure Then
                m_idStructure = Value
                UpdateEtat()
                dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
            End If

        End Set
    End Property

    <XmlIgnoreAttribute()>
    Public Property isCategorie() As Boolean
        Get
            Return m_isCategorie
        End Get
        Set(ByVal Value As Boolean)
            If Value <> m_isCategorie Then
                m_isCategorie = Value
                UpdateEtat()
                dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
            End If

        End Set
    End Property


    Public Property description() As String
        Get
            Return m_description
        End Get
        Set(ByVal Value As String)
            If Value <> m_description Then
                m_description = Value
                UpdateEtat()
                dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
            End If
        End Set
    End Property

    Public Property tarifHT() As Decimal
        Get
            Return _tarifHT
        End Get
        Set(ByVal Value As Decimal)
            If Value <> _tarifHT Then
                _tarifHT = Value
                calcTTC()
                UpdateEtat()
                dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
            End If
        End Set
    End Property

    <XmlIgnoreAttribute()>
    Public Property tarifHTS() As String
        Get
            Return tarifHT.ToString("C2")
        End Get
        Set(ByVal Value As String)
            tarifHT = GlobalsCRODIP.StringToDouble(Value)
        End Set
    End Property
    Public Property tarifTTC() As Decimal
        Get
            Return _tarifTTC
        End Get
        Set(ByVal Value As Decimal)
            If Value <> _tarifTTC Then
                _tarifTTC = Value
                UpdateEtat()
                dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
            End If
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property tarifTTCS() As String
        Get
            Return tarifTTC.ToString("C2")
        End Get
        Set(ByVal Value As String)
            tarifTTC = GlobalsCRODIP.StringToDouble(Value)
        End Set
    End Property

    Public Property tva() As Decimal
        Get
            Return _tva
        End Get
        Set(ByVal Value As Decimal)
            If Value <> _tva Then
                _tva = Value
                UpdateEtat()
                calcTTC()
                dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
            End If
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property tvaS() As String
        Get
            Return tva.ToString()
        End Get
        Set(ByVal Value As String)
            tva = GlobalsCRODIP.StringToDouble(Value)
        End Set
    End Property

    <XmlElement("dateModificationAgent")>
    Public Property dateModificationAgentWS() As String
        Get
            Return CSDate.GetDateForWS(m_dateModificationAgent)
        End Get
        Set(ByVal Value As String)
            Throw New NotSupportedException("Setting the dateModificationAgentWS property is not supported, needed for XML Serialize")
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property dateModificationAgent() As String
        Get
            Return m_dateModificationAgent
        End Get
        Set(ByVal Value As String)
            m_dateModificationAgent = Value
        End Set
    End Property

    <XmlElement("dateModificationCrodip")>
    Public Property dateModificationCrodipWS() As String
        Get
            Return CSDate.GetDateForWS(m_dateModificationCrodip)
        End Get
        Set(ByVal Value As String)
            Throw New NotSupportedException("Setting the dateModificationCrodipWS property is not supported, needed for XML Serialize")
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property dateModificationCrodip() As String
        Get
            Return m_dateModificationCrodip
        End Get
        Set(ByVal Value As String)
            m_dateModificationCrodip = Value
        End Set
    End Property

    Private Sub calcTTC()
        tarifTTC = tarifHT * (1 + (tva / 100))
    End Sub

End Class
