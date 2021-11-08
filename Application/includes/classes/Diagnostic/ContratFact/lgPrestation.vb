Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization

<Serializable()>
Public Class lgPrestation
    Implements ICloneable
#Region "Properties"
    Private _ContratCommercialID As String
    Public Property ContratCommercialID() As String
        Get
            Return _ContratCommercialID
        End Get
        Set(ByVal value As String)
            _ContratCommercialID = value
        End Set
    End Property
    Private _Categorie As String
    Public Property Categorie() As String
        Get
            Return _Categorie
        End Get
        Set(ByVal value As String)
            _Categorie = value
        End Set
    End Property
    Private _Prestation As String
    Public Property Prestation() As String
        Get
            Return _Prestation
        End Get
        Set(ByVal value As String)
            _Prestation = value
        End Set
    End Property
    Private _Quantite As Decimal
    Public Property Quantite() As Decimal
        Get
            Return _Quantite
        End Get
        Set(ByVal value As Decimal)
            _Quantite = value
        End Set
    End Property
    Private _PU As Decimal
    Public Property PU() As Decimal
        Get
            Return _PU
        End Get
        Set(ByVal value As Decimal)
            _PU = value
        End Set
    End Property


    Public Property TotalHT() As Decimal
        Get
            Return PU * Quantite
        End Get
        Set(ByVal value As Decimal)
        End Set
    End Property
    Private _DiagId As String
    Public Property DiagId() As String
        Get
            Return _DiagId
        End Get
        Set(ByVal value As String)
            _DiagId = value
        End Set
    End Property
#End Region

    Public Sub New()

    End Sub
    Public Sub New(pCategorie As String, pPrestation As String, pPU As Decimal, pQte As Decimal, pDiagId As String)
        Categorie = pCategorie
        Prestation = pPrestation
        PU = pPU
        Quantite = pQte
        DiagId = pDiagId

    End Sub

    Public Overridable Function Clone() As Object Implements ICloneable.Clone
        Dim oXS As New XmlSerializer(Me.GetType())
        Dim oStream As New System.IO.MemoryStream()
        Dim oReturn As lgPrestation

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
            CSDebug.dispError("lgPrestation.Clone ERR : " & ex.Message)
            oReturn = Nothing
        End Try
        Return oReturn
    End Function
End Class
