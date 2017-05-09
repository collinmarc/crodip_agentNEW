Public Class ControleRegulier
    Private _id As Integer
    Private _idStructure As Integer
    Private _Type As String
    Private _idMateriel As String
    Private _dateControle As Date
    Private _Etat As Integer '-1 = non effectué, 0 = OK, 1 = NOK
    Private _dateModificationAgent As Date
    Private _dateModificationCrodip As Date
    Public Sub New()
        _id = -1
        _Etat = -1
        _dateModificationAgent = Date.Now()
        _dateModificationCrodip = CDate("01/01/1970")
    End Sub
    Public Sub New(ByVal pMano As ManometreControle)
        _id = -1
        _Etat = -1
        Type = "MANOC"
        IdMateriel = pMano.idCrodip
        IdStructure = pMano.idStructure
    End Sub
    Public Sub New(ByVal pMano As ManometreEtalon)
        _id = -1
        _Etat = -1
        Type = "MANOE"
        IdMateriel = pMano.idCrodip
        IdStructure = pMano.idStructure
    End Sub
    Public Sub New(pBanc As Banc)
        _id = -1
        _Etat = -1
        Type = "BANC"
        IdMateriel = pBanc.id
        IdStructure = pBanc.idStructure
    End Sub
    Public ReadOnly Property Id() As Integer
        Get
            Return _id
        End Get
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
    Public Property Type() As String
        Get
            Return _Type
        End Get
        Set(ByVal Value As String)
            _Type = Value
        End Set
    End Property
    Public Property IdMateriel() As String
        Get
            Return _idMateriel
        End Get
        Set(ByVal Value As String)
            _idMateriel = Value
        End Set
    End Property
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
    Public Property isOK() As Boolean
        Get
            Return (_Etat = 0)
        End Get
        Set(ByVal Value As Boolean)
            If Value Then
                _Etat = 0
            Else
                Debug.Assert(False, "uniquement true")
            End If
        End Set
    End Property

    Public Property isNOK() As Boolean
        Get
            Return (_Etat = 1)
        End Get
        Set(ByVal Value As Boolean)
            If Value Then
                _Etat = 1
            Else
                Debug.Assert(False, "uniquement true")
            End If
        End Set
    End Property
    Public Property isNonEffectue() As Boolean
        Get
            Return (_Etat = -1)
        End Get
        Set(ByVal Value As Boolean)
            If Value Then
                _Etat = -1
            Else
                Debug.Assert(False, "uniquement true")
            End If
        End Set
    End Property

    Public Property dateModificationAgent() As Date
        Get
            Return _dateModificationAgent
        End Get
        Set(ByVal Value As Date)
            _dateModificationAgent = Value
        End Set
    End Property

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
                Case "CTRG_ID".Trim().ToUpper()
                    Me.setId(CInt(pValue))
                Case "CTRG_date".Trim().ToUpper()
                    Me.DateControle = CSDate.access2mysql(pValue.ToString())
                Case "CTRG_STRUCTUREID".Trim().ToUpper()
                    Me.idStructure = pValue.ToString()
                Case "CTRG_TYPE".Trim().ToUpper()
                    Me.Type = pValue.ToString()
                Case "CTRG_MATID".Trim().ToUpper()
                    Me.idMateriel = pValue.ToString()
                Case "CTRG_ETAT".Trim().ToUpper()
                    Me.Etat = pValue
                Case "dateModificationAgent".Trim().ToUpper()
                    Me.dateModificationAgent = CSDate.access2mysql(pValue.ToString())
                Case "dateModificationCrodip".Trim().ToUpper()
                    Me.dateModificationCrodip = CSDate.access2mysql(pValue.ToString())
            End Select
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("ControleRegulier.Fill Error : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

End Class
