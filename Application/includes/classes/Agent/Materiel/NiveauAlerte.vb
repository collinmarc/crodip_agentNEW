Imports System.Collections.Generic
Imports System.IO
Imports System.Xml.Serialization

<XmlType("NiveauAlerte")>
Public Class NiveauAlerte
    <Flags>
    Public Enum Enum_typeMateriel
        <XmlEnum("Banc")> Banc = 0
        <XmlEnum("ManometreControle")> ManometreControle = 1
        <XmlEnum("Buse")> Buse = 2
        <XmlEnum("Pulverisateur")> Pulverisateur = 3
        <XmlEnum("ManometreEtalon")> ManometreEtalon = 4
    End Enum
    Private _Materiel As Enum_typeMateriel
    <XmlAttribute("Materiel")>
    Public Property Materiel() As Enum_typeMateriel
        Get
            Return _Materiel
        End Get
        Set(ByVal value As Enum_typeMateriel)
            _Materiel = value
        End Set
    End Property

    Private _Noire As Integer
    <XmlAttribute("Noire")>
    Public Property Noire() As Integer
        Get
            Return _Noire
        End Get
        Set(ByVal value As Integer)
            _Noire = value
        End Set
    End Property
    Private _Rouge As Integer
    <XmlAttribute("Rouge")>
    Public Property Rouge() As Integer
        Get
            Return _Rouge
        End Get
        Set(ByVal value As Integer)
            _Rouge = value
        End Set
    End Property
    Private _Orange As Integer
    <XmlAttribute("Orange")>
    Public Property Orange() As Integer
        Get
            Return _Orange
        End Get
        Set(ByVal value As Integer)
            _Orange = value
        End Set
    End Property
    Private _Jaune As Integer
    <XmlAttribute("Jaune")>
    Public Property Jaune() As Integer
        Get
            Return _Jaune
        End Get
        Set(ByVal value As Integer)
            _Jaune = value
        End Set
    End Property
    Private _EcartTolere As Decimal
    <XmlAttribute("EcartTolere")>
    Public Property EcartTolere() As Decimal
        Get
            Return _EcartTolere
        End Get
        Set(ByVal value As Decimal)
            _EcartTolere = value
        End Set
    End Property
    Private _DateEffet As Date
    <XmlAttribute("DateEffet")>
    Public Property DateEffetStr() As String
        Get
            Return CSDate.ToCRODIPString(_DateEffet)
        End Get
        Set(ByVal value As String)
            _DateEffet = CSDate.FromCrodipString(value)
        End Set
    End Property
    <XmlIgnore>
    Public Property DateEffet() As Date
        Get
            Return _DateEffet
        End Get
        Set(ByVal value As Date)
            _DateEffet = value
        End Set
    End Property

    'Public Shared Function readXML(Optional pstrFile As String = "Alertes.xml") As List(Of NiveauAlerte)
    '    Dim strFileName As String = My.Settings.RepertoireParametres & "/" & pstrFile
    '    Dim olst As New List(Of NiveauAlerte)
    '    Using objStreamReader As New StreamReader(strFileName)
    '        Dim root As XmlRootAttribute = New XmlRootAttribute("NiveauxAlertes")
    '        Dim x As New XmlSerializer(GetType(List(Of NiveauAlerte)), root)
    '        olst = x.Deserialize(objStreamReader)
    '    End Using

    '    Return olst
    'End Function

    'Public Shared Function FTO_writeXml(pList As List(Of NiveauAlerte), Optional ByVal pstrFile As String = "Alertes.xml") As Boolean
    '    Dim bReturn As Boolean
    '    Try
    '        Dim strFileName As String = My.Settings.RepertoireParametres & "/" & pstrFile
    '        Dim ns As New System.Xml.Serialization.XmlSerializerNamespaces()
    '        ns.Add("", "") 'No namespaces needed.
    '        Dim root As XmlRootAttribute = New XmlRootAttribute("NiveauxAlertes")
    '        Dim objStreamWriter As New StreamWriter(strFileName)
    '        Dim x As New XmlSerializer(GetType(List(Of NiveauAlerte)), root)
    '        x.Serialize(objStreamWriter, pList, ns)
    '        objStreamWriter.Close()
    '        bReturn = True
    '    Catch ex As Exception
    '        CSDebug.dispError(ex.Message)
    '        If ex.InnerException IsNot Nothing Then
    '            CSDebug.dispError(ex.InnerException.Message)
    '        End If
    '        bReturn = False
    '    End Try
    '    Return bReturn
    'End Function


End Class
