Imports System.IO
Imports System.Xml.Serialization

<Serializable()>
Public Class lstParamMetrologie
    Public Const FILE_NAME As String = "moduleDocumentaire/ParamMetrologie.xml"
    Public Sub New()
        lstParam = New List(Of ParamMetrologie)()
    End Sub
    Private _LstParam As List(Of ParamMetrologie)
    <XmlElement("Metrologie")>
    Public Property lstParam() As List(Of ParamMetrologie)
        Get
            Return _LstParam
        End Get
        Set(ByVal value As List(Of ParamMetrologie))
            _LstParam = value
        End Set
    End Property
    Public Function writeXml(Optional strFileName As String = FILE_NAME) As Boolean
        Dim bReturn As Boolean
        Try

            Dim objStreamWriter As New StreamWriter(strFileName)
            Dim x As New XmlSerializer(Me.GetType)
            x.Serialize(objStreamWriter, Me)
            objStreamWriter.Close()
            bReturn = True
        Catch ex As Exception
            Console.Write("writexml ERR:" & ex.Message)
            If ex.InnerException IsNot Nothing Then
                Console.Write("writexml ERR:" & ex.InnerException.Message)

            End If
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Function readXML(Optional ByVal strFileName As String = FILE_NAME) As Boolean
        Dim bReturn As Boolean
        Try
            Dim olst As New lstParamMetrologie()
            Using objStreamReader As New StreamReader(strFileName)

                Dim x As New XmlSerializer(Me.GetType)

                olst = x.Deserialize(objStreamReader)
                objStreamReader.Close()
                lstParam.Clear()
                For Each oParam As ParamMetrologie In olst.lstParam
                    lstParam.Add(oParam)
                Next
            End Using
            bReturn = True
        Catch ex As Exception
            bReturn = False
        End Try
        Return bReturn
    End Function

End Class
<Serializable()>
Public Class ParamMetrologie
    Public Sub New()
        PressionMontantes = New List(Of ParamMetrologiePression)()
        PressionDescendantes = New List(Of ParamMetrologiePression)()
        Repetitions = New List(Of ParamMetrologiePression)()
    End Sub
    Public Sub New(pFond As String)
        FondEchelle = pFond
        PressionMontantes = New List(Of ParamMetrologiePression)()
        PressionDescendantes = New List(Of ParamMetrologiePression)()
        Repetitions = New List(Of ParamMetrologiePression)()
    End Sub
    Private _FondEchelle As String
    <XmlAttribute("FondEchelle")>
    Public Property FondEchelle() As String
        Get
            Return _FondEchelle
        End Get
        Set(ByVal value As String)
            _FondEchelle = value
        End Set
    End Property
    Private _PressionsMontantes As List(Of ParamMetrologiePression)
    Public Property PressionMontantes() As List(Of ParamMetrologiePression)
        Get
            Return _PressionsMontantes
        End Get
        Set(ByVal value As List(Of ParamMetrologiePression))
            _PressionsMontantes = value
        End Set
    End Property
    Private _PressionsDescendantes As List(Of ParamMetrologiePression)
    Public Property PressionDescendantes() As List(Of ParamMetrologiePression)
        Get
            Return _PressionsDescendantes
        End Get
        Set(ByVal value As List(Of ParamMetrologiePression))
            _PressionsDescendantes = value
        End Set
    End Property
    Private _repetitions As List(Of ParamMetrologiePression)
    Public Property Repetitions() As List(Of ParamMetrologiePression)
        Get
            Return _repetitions
        End Get
        Set(ByVal value As List(Of ParamMetrologiePression))
            _repetitions = value
        End Set
    End Property



End Class
<Serializable>
<XmlType("PressionCtrl")>
Public Class ParamMetrologiePression
    Public Sub New()

    End Sub
    Public Sub New(pNum As Integer, pValeur As Decimal)
        Me.Num = pNum
        Me.Valeur = pValeur
    End Sub
    Private _Num As Integer
    <XmlAttribute("Num")>
    Public Property Num() As Integer
        Get
            Return _Num
        End Get
        Set(ByVal value As Integer)
            _Num = value
        End Set
    End Property
    Private _Valeur As Decimal

    <XmlAttribute("Valeur")>
    Public Property Valeur() As Decimal
        Get
            Return _Valeur
        End Get
        Set(ByVal value As Decimal)
            _Valeur = value
        End Set
    End Property
End Class
