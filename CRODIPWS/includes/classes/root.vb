Imports System.Xml.Serialization
<XmlInclude(GetType(Materiel))>
Public Class root
    Private _uid As Integer
    Public Property uid() As Integer
        Get
            Return _uid
        End Get
        Set(ByVal value As Integer)
            _uid = value
        End Set
    End Property
    Private _aid As String
    Public Property aid() As String
        Get
            Return _aid
        End Get
        Set(ByVal value As String)
            _aid = value
        End Set
    End Property
    Private _dateModificationAgent As DateTime
    <XmlIgnoreAttribute()>
    Public Property dateModificationAgent() As Date
        Get
            Return _dateModificationAgent
        End Get
        Set(ByVal Value As Date)
            _dateModificationAgent = Value
        End Set
    End Property
    <XmlElement("dateModificationAgent")>
    Public Property dateModificationAgentS() As String
        Get
            If dateModificationAgent <> Date.MinValue Then
                Return CSDate.GetDateForWS(dateModificationAgent)
            Else
                Return ""
            End If
        End Get
        Set(ByVal Value As String)
            If Value <> "" Then
                Try
                    dateModificationAgent = Value
                Catch
                End Try
            End If
        End Set
    End Property
    Private _dateModificationCrodip As DateTime
    <XmlIgnoreAttribute()>
    Public Property dateModificationCrodip() As DateTime
        Get
            Return _dateModificationCrodip
        End Get
        Set(ByVal value As DateTime)
            _dateModificationCrodip = value
        End Set
    End Property
    <XmlElement("dateModificationCrodip")>
    Public Property dateModificationCrodipS() As String
        Get
            If dateModificationCrodip <> Date.MinValue Then
                Return CSDate.GetDateForWS(dateModificationCrodip)
            Else
                Return ""
            End If
        End Get
        Set(ByVal Value As String)
            If Value <> "" Then
                Try
                    dateModificationCrodip = Value
                Catch
                End Try
            End If
        End Set
    End Property
    Public Sub New()
        uid = 0
        aid = ""
        dateModificationAgent = DateTime.MinValue
        dateModificationCrodip = DateTime.MinValue
    End Sub

    Public Function getRootQuery() As String
        Dim strQuery As String = ""
        If Me.uid > 0 Then
            strQuery = strQuery & " , uid=" & Me.uid & ""
        End If
        If Not String.IsNullOrEmpty(aid) Then
            strQuery = strQuery & " , aid='" & Me.aid & "'"
        End If
        If Not String.IsNullOrEmpty(dateModificationCrodipS) Then
            strQuery = strQuery & " , dateModificationCrodip='" & CSDate.ToCRODIPString((dateModificationCrodip)) & "'"
        End If
        If Not String.IsNullOrEmpty(dateModificationAgentS) Then
            strQuery = strQuery & " , dateModificationAgent='" & CSDate.ToCRODIPString((dateModificationAgent)) & "'"
        End If
        Return strQuery
    End Function

    Public Overridable Function Fill(pColName As String, pcolValue As Object) As Boolean
        Dim bReturn As Boolean = False
        If pcolValue IsNot Nothing Then
            bReturn = True
            Select Case pColName.Trim().ToUpper()
                Case "uid".Trim().ToUpper()
                    Me.uid = CInt(pcolValue)
                Case "aid".Trim().ToUpper()
                    Me.aid = pcolValue.ToString
                Case "dateModificationAgent".Trim().ToUpper()
                    Me.dateModificationAgent = CSDate.ToCRODIPString(pcolValue).ToString 'Public dateModificationAgent As String
                Case "dateModificationCrodip".Trim().ToUpper()
                    Me.dateModificationCrodip = CSDate.ToCRODIPString(pcolValue).ToString 'Public dateModificationCrodip As String
                Case Else
                    bReturn = False
            End Select
        End If
        Return bReturn
    End Function
    Public Function FillDR(oDataReader As Common.DbDataReader) As Boolean
        Dim bReturn As Boolean
        Try
            Dim tmpColId As Integer = 0
            bReturn = True
            While tmpColId < oDataReader.FieldCount()
                If Not oDataReader.IsDBNull(tmpColId) Then
                    bReturn = bReturn And Fill(oDataReader.GetName(tmpColId), oDataReader.Item(tmpColId))
                End If
                tmpColId = tmpColId + 1
            End While

            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("root.FillDR ERR : " + ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
End Class
