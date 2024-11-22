Imports System.Xml.Serialization
Public Class Tarif
    Inherits root
    Protected m_idStructure As Integer
    Protected m_isCategorie As Boolean
    Protected m_description As String
    'Uniquement pour Prestationtarif
    Private _tarifHT As Decimal
    Private _tarifTTC As Decimal
    Private _tva As Decimal

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
        dateModificationCrodip = Date.MinValue
        dateModificationAgent = Date.Now
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
            Return uid
        End Get
        Set(ByVal Value As Integer)
            If Value <> uid Then
                uid = Value
                UpdateEtat()
                dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
            End If
        End Set
    End Property
    Public Property idStructure() As Integer
        Get
            Return uidstructure
        End Get
        Set(ByVal Value As Integer)
            If Value <> idStructure Then
                uidstructure = Value
                UpdateEtat()
                dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
            End If

        End Set
    End Property
    Private _uidstructure As Integer
    <XmlElement("uidstructure")>
    Public Property uidstructureS() As String
        Get
            Return uidstructure
        End Get
        Set(ByVal Value As String)
            If Not String.IsNullOrEmpty(Value) Then
                uidstructure = Value
            End If
        End Set
    End Property
    <XmlIgnore>
    Public Property uidstructure() As Integer
        Get
            Return _uidstructure
        End Get
        Set(ByVal Value As Integer)
            If Value <> m_idStructure Then
                _uidstructure = Value
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

    Private Sub calcTTC()
        tarifTTC = tarifHT * (1 + (tva / 100))
    End Sub

End Class
