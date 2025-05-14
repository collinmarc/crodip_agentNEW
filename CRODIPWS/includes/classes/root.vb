Imports System.Reflection
Imports System.Xml.Serialization
<Serializable(), XmlInclude(GetType(Materiel))>
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
                    dateModificationAgent = CSDate.FromCrodipString(Value)
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
                    dateModificationCrodip = CSDate.FromCrodipString(Value)
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
            bReturn = AffectationAuto(pColName, pcolValue)
            'Si l'affectation auto n'a pas fonctionné
            If Not bReturn Then
                Select Case pColName.Trim().ToUpper()
                    Case "uid".Trim().ToUpper()
                        Me.uid = CInt(pcolValue)
                    Case "aid".Trim().ToUpper()
                        Me.aid = pcolValue.ToString
                    Case "dateModificationAgent".Trim().ToUpper()
                        If Not String.IsNullOrEmpty(pcolValue) And pcolValue <> "0000-00-00 00:00:00" Then
                            Me.dateModificationAgent = CSDate.ToCRODIPString(pcolValue) 'Public dateModificationAgent As String
                        End If
                    Case "dateModificationCrodip".Trim().ToUpper()
                        If Not String.IsNullOrEmpty(pcolValue) And pcolValue <> "0000-00-00 00:00:00" Then
                            Me.dateModificationCrodip = CSDate.ToCRODIPString(pcolValue) 'Public dateModificationCrodip As String
                        End If
                    Case Else
                        bReturn = False
                End Select
            End If
        End If
        Return bReturn
    End Function
    ''' <summary>
    ''' Affectation automantique de la valeur à la propriété
    ''' </summary>
    ''' <param name="pColName"></param>
    ''' <param name="pcolValue"></param>
    ''' <returns></returns>
    Private Function AffectationAuto(pColName As String, pcolValue As Object) As Boolean
        Dim bReturn As Boolean
        'Recherche de la propriété de même nom
        Dim properties As PropertyInfo() = Me.GetType().GetProperties()
        Dim propInfo As PropertyInfo = properties.Where(Function(p)
                                                            Return p.Name.ToUpper() = pColName.ToUpper()
                                                        End Function).FirstOrDefault()
        bReturn = False
        If propInfo IsNot Nothing Then
            'Affectation de la valeur à la propriété
            Try
                Select Case propInfo.PropertyType.Name.ToUpper()
                    Case "INTEGER", "INT32", "Int64"
                        propInfo.SetValue(Me, CInt(pcolValue))
                        bReturn = True
                    Case "DATETIME"
                        If Not String.IsNullOrEmpty(pcolValue) And pcolValue <> "0000-00-00 00:00:00" Then
                            propInfo.SetValue(Me, CSDate.FromCrodipString(pcolValue))
                        End If
                        bReturn = True
                    Case "BOOLEAN"
                        propInfo.SetValue(Me, CType(pcolValue, Boolean))
                        bReturn = True
                    Case Else
                        propInfo.SetValue(Me, pcolValue)
                End Select
                bReturn = True
            Catch ex As Exception
                bReturn = False
            End Try
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
