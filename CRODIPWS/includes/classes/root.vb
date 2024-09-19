Imports System.Xml.Serialization

Public Class root
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
        Set(ByVal value As DateTime)
            _dateModificationCrodip = value
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
    Public Sub New()
        dateModificationAgent = DateTime.MinValue
        dateModificationCrodip = DateTime.MinValue
    End Sub

    Public Overridable Function Fill(pColName As String, pcolValue As Object) As Boolean
        Dim bReturn As Boolean
        bReturn = True
        Select Case pColName.Trim().ToUpper()
            Case "dateModificationAgent".Trim().ToUpper()
                Me.dateModificationAgent = CSDate.ToCRODIPString(pcolValue).ToString 'Public dateModificationAgent As String
            Case "dateModificationCrodip".Trim().ToUpper()
                Me.dateModificationCrodip = CSDate.ToCRODIPString(pcolValue).ToString 'Public dateModificationCrodip As String
            Case Else
                bReturn = False
        End Select

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
