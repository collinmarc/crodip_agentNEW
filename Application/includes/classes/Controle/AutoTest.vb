Imports System.Web.Services
Imports System.Xml.Serialization

<Serializable(), XmlInclude(GetType(AutoTest))> _
<XmlInclude(GetType(AutoTest))> _
Public Class AutoTest
    Private _id As Integer
    Private _idStructure As Integer
    Private _IdAgent As String
    Private _Type As String
    Private _idMateriel As String
    Private _dateControle As Date
    Private _Etat As Integer '-1 = non effectué, 0 = OK, 1 = NOK
    Private _dateModificationAgent As Date
    Private _dateModificationCrodip As Date
    Public Sub New()
        _id = -1
        _Etat = -1
        NumAgent = ""
        IdStructure = 0
        _dateModificationAgent = Date.Now()
        _dateModificationCrodip = CDate("01/01/1970")
    End Sub
    Public Sub New(pAgent As Agent)
        _id = -1
        _Etat = -1
        NumAgent = pAgent.id
        IdStructure = pAgent.idStructure
        _dateModificationAgent = Date.Now()
        _dateModificationCrodip = CDate("01/01/1970")
    End Sub
    Public Sub New(pAgent As Agent, ByVal pMano As ManometreControle)
        _id = -1
        _Etat = -1
        Type = "MANOC"
        IdMateriel = pMano.idCrodip
        IdStructure = pMano.idStructure
        NumAgent = pAgent.id
    End Sub
    Public Sub New(pAgent As Agent, ByVal pMano As ManometreEtalon)
        _id = -1
        _Etat = -1
        Type = "MANOE"
        IdMateriel = pMano.idCrodip
        IdStructure = pMano.idStructure
        NumAgent = pAgent.id
    End Sub
    Public Sub New(pAgent As Agent, pBanc As Banc)
        _id = -1
        _Etat = -1
        Type = "BANC"
        IdMateriel = pBanc.id
        IdStructure = pBanc.idStructure
        NumAgent = pAgent.id
    End Sub
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal Value As Integer)
            Throw New NotSupportedException("Setting the Id property is not supported, needed for XML Serialize")
        End Set
    End Property
    Public Sub setId(ByVal pId As Integer)
        _id = pId
    End Sub
    Public Property IdStructure() As Integer
        Get
            Return _idStructure
        End Get
        Set(ByVal Value As Integer)
            _idStructure = Value
        End Set
    End Property
    Public Property NumAgent() As String
        Get
            Return _IdAgent
        End Get
        Set(ByVal Value As String)
            _IdAgent = Value
        End Set
    End Property
    Public Property Type() As String
        Get
            Return _Type
        End Get
        Set(ByVal Value As String)
            _Type = Value
        End Set
    End Property
    Public ReadOnly Property TypeLibelle() As String
        Get
            Select Case _Type
                Case "BANC"
                    Return "Banc de mesure"
                Case "MANOC"
                    Return "Manomètre de contrôle"
                Case "MANOE"
                    Return "Manomètre étalon"
                Case "BUSE"
                    Return "Buse étalon"
            End Select
            Return _Type
        End Get
    End Property
    Public Property IdMateriel() As String
        Get
            Return _idMateriel
        End Get
        Set(ByVal Value As String)
            _idMateriel = Value
        End Set
    End Property
    <XmlElement("DateControle")>
    Public Property DateControleS() As String
        Get
            Return CSDate.ToCRODIPString(_dateControle)
        End Get
        Set(ByVal Value As String)
            Throw New NotSupportedException("Setting the DateControle property is not supported, needed for XML Serialize")
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property DateControle() As Date
        Get
            Return _dateControle
        End Get
        Set(ByVal Value As Date)
            _dateControle = Value
        End Set
    End Property
    Public Property Etat() As Integer
        Get
            Return _Etat
        End Get
        Set(ByVal Value As Integer)
            _Etat = Value
        End Set
    End Property
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property isOK() As Boolean
        Get
            Return (_Etat = 0)
        End Get
        Set(ByVal Value As Boolean)
            If Value Then
                _Etat = 0
            Else
                '                Debug.Assert(False, "uniquement true")
            End If
        End Set
    End Property

    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property isNOK() As Boolean
        Get
            Return (_Etat = 1)
        End Get
        Set(ByVal Value As Boolean)
            If Value Then
                _Etat = 1
            Else
                '               Debug.Assert(False, "uniquement true")
            End If
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property isNonEffectue() As Boolean
        Get
            Return (_Etat = -1)
        End Get
        Set(ByVal Value As Boolean)
            If Value Then
                _Etat = -1
            Else
                '              Debug.Assert(False, "uniquement true")
            End If
        End Set
    End Property

    <XmlElement("dateModificationAgent")>
    Public Property dateModificationAgentS() As String
        Get
            Return CSDate.ToCRODIPString(_dateModificationAgent)
        End Get
        Set(ByVal Value As String)
            Throw New NotSupportedException("Setting the dateModificationAgent property is not supported, needed for XML Serialize")
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property dateModificationAgent() As Date
        Get
            Return _dateModificationAgent
        End Get
        Set(ByVal Value As Date)
            _dateModificationAgent = Value
        End Set
    End Property

    <XmlElement("dateModificationCrodip")>
    Public Property dateModificationCrodipS() As String
        Get
            Return CSDate.ToCRODIPString(_dateModificationCrodip)
        End Get
        Set(ByVal Value As String)
            Throw New NotSupportedException("Setting the dateModificationCrodip property is not supported, needed for XML Serialize")
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property dateModificationCrodip() As Date
        Get
            Return _dateModificationCrodip
        End Get
        Set(ByVal Value As Date)
            _dateModificationCrodip = Value
        End Set
    End Property
    Public Function Fill(pDBReader As System.Data.OleDb.OleDbDataReader) As Boolean
        Dim tmpColId As Integer = 0
        Dim bReturn As Boolean

        bReturn = True
        While tmpColId < pDBReader.FieldCount()
            If Not pDBReader.IsDBNull(tmpColId) Then
                bReturn = bReturn And Fill(pDBReader.GetName(tmpColId), pDBReader.Item(tmpColId))
            End If
            tmpColId = tmpColId + 1
        End While
        Return bReturn
    End Function
    ''' <summary>
    ''' Initialise l'objet avec le résultat d'une requete ou d'un WS
    ''' </summary>
    ''' <param name="pColName"></param>
    ''' <param name="pValue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Fill(ByVal pColName As String, ByVal pValue As Object) As Boolean
        Dim bReturn As Boolean
        Try
            Select Case pColName.ToUpper.Trim().ToUpper()
                'Le Nom des champs de Bdd et des champs transmis par WS ne sont pas les mêmes
                Case "CTRG_ID".Trim().ToUpper(), "Id".Trim.ToUpper()
                    Me.setId(CInt(pValue))
                Case "CTRG_date".Trim().ToUpper(), "DateControle".Trim.ToUpper()
                    Me.DateControle = CSDate.ToCRODIPString(pValue.ToString())
                Case "CTRG_STRUCTUREID".Trim().ToUpper(), "IdStructure".Trim.ToUpper()
                    Me.IdStructure = pValue.ToString()
                Case "CTRG_TYPE".Trim().ToUpper(), "Type".Trim.ToUpper()
                    Me.Type = pValue.ToString()
                Case "CTRG_MATID".Trim().ToUpper(), "IdMateriel".Trim.ToUpper()
                    Me.IdMateriel = pValue.ToString()
                Case "CTRG_ETAT".Trim().ToUpper(), "Etat".Trim.ToUpper()
                    Me.Etat = CType(pValue, Boolean)
                Case "CTRG_NUMAGENT".Trim().ToUpper(), "NumAgent".Trim.ToUpper()
                    Me.NumAgent = pValue
                Case "dateModificationAgent".Trim().ToUpper()
                    Me.dateModificationAgent = CSDate.ToCRODIPString(pValue.ToString())
                Case "dateModificationCrodip".Trim().ToUpper()
                    Me.dateModificationCrodip = CSDate.ToCRODIPString(pValue.ToString())
            End Select
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("ControleRegulier.Fill Error : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

End Class
