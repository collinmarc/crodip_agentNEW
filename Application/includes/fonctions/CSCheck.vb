Option Explicit On 
Module CSCheck

    Public Function numSIREN(ByVal param As Object)

        ' On retire les espaces
        param = param.Replace(" ", "")

        Dim i As Integer
        Dim v As Integer
        Dim iLuhnKey As Integer
        Dim Siren_IsValid As Boolean

        Siren_IsValid = False
        If Not IsNumeric(param) Then
            Return False
        End If
        If Len(Format$(CDbl(param), "000000000")) <> 9 Then
            Return False
        End If
        If param = "000000000" Then
            Return False
        End If
        iLuhnKey = 0
        For i = 1 To Len(param)
            v = CInt(Mid$(param, i, 1))
            If (i Mod 2) = 0 Then
                v = v * 2
            End If
            If v >= 10 Then
                iLuhnKey = iLuhnKey + (v - 9)
            Else
                iLuhnKey = iLuhnKey + v
            End If
        Next
        Siren_IsValid = (iLuhnKey Mod 10 = 0)
        Return Siren_IsValid
    End Function

    Public Function numSIRET(ByVal param As Object)
        Dim i As Integer
        Dim v As Integer
        Dim iLuhnKey As Integer
        Dim Siret_IsValid As Boolean

        Siret_IsValid = False
        If Not IsNumeric(param) Then
            Return False
        End If
        If Len(Format$(CDbl(param), "00000000000000")) <> 14 Then
            Return False
        End If
        If param = "00000000000000" Then
            Return False
        End If
        If Not numSIREN(Left$(param, 9)) Then
            Return False
        End If
        iLuhnKey = 0
        For i = 1 To Len(param)
            v = CInt(Mid$(param, i, 1))
            If (i Mod 2) = 1 Then
                v = v * 2
            End If
            If v >= 10 Then
                iLuhnKey = iLuhnKey + (v - 9)
            Else
                iLuhnKey = iLuhnKey + v
            End If
        Next
        Siret_IsValid = (iLuhnKey Mod 10 = 0)
    End Function

End Module
