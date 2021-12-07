Imports System.Globalization

Public Class CSDate

    '''
    'Renvoie une date au format acceptable par les WS CRODIP
    Public Shared Function GetDateForWS(ByVal pDate As String) As String
        Dim dDate As Date
        Try
            dDate = Date.Parse(pDate)
            Return Format(dDate, "yyyy-MM-dd HH:mm:ss")
        Catch ex As Exception
            dDate = New Date(1970, 1, 1)
            Return Format(dDate, "yyyy-MM-dd HH:mm:ss")

        End Try
    End Function


    'Conversion date  => String
    'Je pense que c'est la même chose que getDateForWs
    Public Shared Function ToCRODIPString(ByVal accessDate As Object, Optional pFormat As String = "yyyy-MM-dd HH:mm:ss") As String
        Try
            Dim dDate As Date
            If accessDate.GetType.ToString = "System.String" Then
                dDate = Date.Parse(accessDate)
            Else
                dDate = accessDate
            End If
            Return Format(dDate, pFormat)
        Catch ex As Exception
            Dim mysqlDate As Date
            mysqlDate.AddDays(0)
            mysqlDate.AddMonths(0)
            mysqlDate.AddYears(0)
            mysqlDate.AddHours(0)
            mysqlDate.AddMinutes(0)
            mysqlDate.AddSeconds(0)
            Return mysqlDate.ToString()
        End Try
    End Function
    'Conversion date MySQL => Access
    Public Shared Function mysql2access(ByVal mysqlDate As Object) As Date
        Try
            If mysqlDate.GetType.ToString = "System.String" Then
                mysqlDate = Date.Parse(mysqlDate)
            End If
            Dim str As String
            str = Format(mysqlDate, "dd/MM/yyyy HH:mm:ss")
            Return CDate(str)
        Catch ex As Exception
            Dim accessDate As Date
            accessDate.AddDays(0)
            accessDate.AddMonths(0)
            accessDate.AddYears(0)
            accessDate.AddHours(0)
            accessDate.AddMinutes(0)
            accessDate.AddSeconds(0)
            Return accessDate
        End Try
    End Function

    Public Shared Function FromCrodipString(ByVal accessDate As String) As Date
        Dim vbDate As Date
        Try
            If accessDate IsNot Nothing Then
                If accessDate <> "" Then
                    'La Date est au format yyyy-MM-dd HH:mm:ss
                    Dim dy As String = accessDate.Substring(8, 2)
                    Dim mo As String = accessDate.Substring(5, 2)
                    Dim yr As String = accessDate.Substring(0, 4)
                    Dim hr As String = "00"
                    Dim mi As String = "00"
                    Dim se As String = "00"
                    If accessDate.Length >= 19 Then
                        hr = accessDate.Substring(11, 2)
                        mi = accessDate.Substring(14, 2)
                        se = accessDate.Substring(17, 2)
                    End If
                    vbDate = New Date(CType(yr, Double), CType(mo, Double), CType(dy, Double), CType(hr, Double), CType(mi, Double), CType(se, Double))
                Else
                        vbDate = Date.MinValue
                End If
            Else
                vbDate = Date.MinValue
            End If
        Catch Ex As Exception
            vbDate = mysql2vb(accessDate)
        End Try

        Return vbDate
    End Function

    Public Shared Function mysql2vb(ByVal accessDate As String) As Date
        'La Date est au format dd/MM/yyyy HH:mm:ss
        Dim dy As String = accessDate.Substring(0, 2)
        Dim mo As String = accessDate.Substring(3, 2)
        Dim yr As String = accessDate.Substring(6, 4)
        Dim hr As String = accessDate.Substring(11, 2)
        Dim mi As String = accessDate.Substring(14, 2)
        Dim se As String = accessDate.Substring(17, 2)
        Dim vbDate As New Date(CType(yr, Double), CType(mo, Double), CType(dy, Double), CType(hr, Double), CType(mi, Double), CType(se, Double))
        Return vbDate
    End Function

    Public Shared Function CheckHours(ByVal pInputText As String) As Boolean
        Dim bReturn As Boolean
        Dim dDate As Date
        Dim culture As CultureInfo
        culture = CultureInfo.CurrentCulture()
        Dim styles As DateTimeStyles = DateTimeStyles.None
        bReturn = True
        If Date.TryParse(pInputText, culture, styles, dDate) Then
            If dDate > CDate("00:00") And dDate < CDate("23:59") Then
                bReturn = False
            End If
        Else
            bReturn = False
        End If

        Return bReturn
    End Function

    Public Shared Function isDateNull(ByVal pDate As String) As Boolean
        If String.IsNullOrEmpty(pDate) Then
            Return True
        Else
            If IsDate(pDate) Then
                Return isDateNull(CDate(pDate))
            Else
                Return True
            End If
        End If
    End Function
    Public Shared Function isDateNull(ByVal pDate As Date) As Boolean
        Return pDate = CDate("01/01/0001 00:00:00")
    End Function



End Class
