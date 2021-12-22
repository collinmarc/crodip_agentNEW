Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization

<Serializable()>
Public Class FactureItem
    Implements ICloneable
#Region "Properties"
    Private _idFacture As String
    Public Property idFacture() As String
        Get
            Return _idFacture
        End Get
        Set(ByVal value As String)
            _idFacture = value
        End Set
    End Property
    Private _Categorie As String
    Public Property categorie() As String
        Get
            Return _Categorie
        End Get
        Set(ByVal value As String)
            _Categorie = value
        End Set
    End Property
    Private _Prestation As String
    Public Property prestation() As String
        Get
            Return _Prestation
        End Get
        Set(ByVal value As String)
            _Prestation = value
        End Set
    End Property
    Private _Quantite As Decimal
    Public Property quantite() As Decimal
        Get
            Return _Quantite
        End Get
        Set(ByVal value As Decimal)
            _Quantite = value
        End Set
    End Property
    <XmlIgnore()>
    Public Property quantiteStr() As String
        Get
            Return quantite.ToString("N2")
        End Get
        Set(ByVal value As String)
            'If IsNumeric(value) Then
            quantite = GlobalsCRODIP.StringToDouble(value)
            'End If
        End Set
    End Property
    Private _PU As Decimal
    Public Property pu() As Decimal
        Get
            Return _PU
        End Get
        Set(ByVal value As Decimal)
            _PU = value
        End Set
    End Property
    <XmlIgnore()>
    Public Property pustr() As String
        Get
            Return pu.ToString("N2")
        End Get
        Set(ByVal value As String)
            pu = GlobalsCRODIP.StringToDouble(value)
        End Set
    End Property
    Private _txTVA As Decimal
    Public Property txTVA() As Decimal
        Get
            Return _txTVA
        End Get
        Set(ByVal value As Decimal)
            _txTVA = value
        End Set
    End Property

    Public Property totalHT() As Decimal
        Get
            Return pu * quantite
        End Get
        Set(ByVal value As Decimal)
        End Set
    End Property
    Public Property totalTVA() As Decimal
        Get
            Return pu * quantite * (txTVA / 100)
        End Get
        Set(ByVal value As Decimal)
        End Set
    End Property
    Public Property totalTTC() As Decimal
        Get
            Return totalHT * (1 + (txTVA / 100))
        End Get
        Set(ByVal value As Decimal)
        End Set
    End Property
    Private _idDiag As String
    Public Property idDiag() As String
        Get
            Return _idDiag
        End Get
        Set(ByVal value As String)
            _idDiag = value
        End Set
    End Property
#End Region

    Public Sub New()
        dateModificationCrodip = DateTime.MinValue
        dateModificationAgent = DateTime.Now()
    End Sub
    Public Sub New(pCategorie As String, pPrestation As String, pPU As Decimal, pQte As Decimal, ptxTva As Decimal, pDiagId As String)
        Me.New()
        categorie = pCategorie
        prestation = pPrestation
        pu = pPU
        quantite = pQte
        txTVA = ptxTva
        idDiag = pDiagId

    End Sub

    Public Overridable Function Clone() As Object Implements ICloneable.Clone
        Dim oXS As New XmlSerializer(Me.GetType())
        Dim oStream As New System.IO.MemoryStream()
        Dim oReturn As FactureItem

        Try


            ' Create a memory stream and a formatter.
            Dim ms As New System.IO.MemoryStream(1000)
            Dim bf As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter(Nothing,
                New System.Runtime.Serialization.StreamingContext(System.Runtime.Serialization.StreamingContextStates.Clone))
            ' Serialize the object into the stream.
            bf.Serialize(ms, Me)
            ' Position streem pointer back to first byte.
            ms.Seek(0, System.IO.SeekOrigin.Begin)
            ' Deserialize into another object.
            oReturn = bf.Deserialize(ms)
            ' release memory.
            ms.Close()
        Catch ex As Exception
            CSDebug.dispError("FactureItem.Clone ERR : " & ex.Message)
            oReturn = Nothing
        End Try
        Return oReturn
    End Function
    Private _NFactureItem As Integer
    Public Property nFactureItem() As Integer
        Get
            Return _NFactureItem
        End Get
        Set(ByVal value As Integer)
            _NFactureItem = value
        End Set
    End Property
    Private _dateModificationAgent As DateTime
    <XmlIgnoreAttribute()>
    Public Property dateModificationAgent() As DateTime
        Get
            Return _dateModificationAgent
        End Get
        Set(ByVal Value As DateTime)
            _dateModificationAgent = Value
        End Set
    End Property
    <XmlElement("dateModificationAgent")>
    Public Property dateModificationAgentS() As String
        Get
            Return CSDate.GetDateForWS(_dateModificationAgent)
        End Get
        Set(ByVal Value As String)
            _dateModificationAgent = Value
        End Set
    End Property
    Private _dateModificationCrodip As DateTime
    <XmlIgnoreAttribute()>
    Public Property dateModificationCrodip() As DateTime
        Get
            Return _dateModificationCrodip
        End Get
        Set(ByVal Value As DateTime)
            _dateModificationCrodip = Value
        End Set
    End Property
    <XmlElement("dateModificationCrodip")>
    Public Property dateModificationCrodipS() As String
        Get
            Return CSDate.GetDateForWS(_dateModificationCrodip)
        End Get
        Set(ByVal Value As String)
            _dateModificationCrodip = Value
        End Set
    End Property
End Class
