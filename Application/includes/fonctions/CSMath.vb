Imports System.Text.RegularExpressions
Module CSMath

    ' Retourne un double avec N chiffres après la virgules (tronqués)
    Public Function truncate(ByVal myDouble As Double, ByVal nbDecimale As Integer)
        Dim tmpReturn As Double = myDouble
        Try
            Dim tmpArrMyDouble() As String = {0, 0}
            tmpArrMyDouble = myDouble.ToString.Split(",")
            Dim tmpMyDoubleDecimales As String = tmpArrMyDouble(1).Substring(0, nbDecimale - 1)
            tmpReturn = CType(tmpArrMyDouble(0) & "," & tmpMyDoubleDecimales, Double)
        Catch ex As Exception
            CSDebug.dispError("CSMath.truncate(" & myDouble & ", " & nbDecimale & ") : " & ex.Message)
        End Try
        Return tmpReturn
    End Function


    Public Function formatNumbers(ByVal number As Double) As String
        Dim returnString As String
        returnString = CType(Math.Round(CType(number, Double), 2), String)

        Dim RegexObj As Regex = New Regex("^[0-9]+[\,|\.][0-9]{1}$")
        If RegexObj.IsMatch(returnString) Then
            returnString = returnString & "0"
        End If

        Return returnString
    End Function

End Module
