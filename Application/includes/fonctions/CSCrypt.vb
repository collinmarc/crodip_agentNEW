Imports System.Security.Cryptography
Imports System.Text

Module CSCrypt

    Public Function encode(ByVal Texte As String, ByVal type As String) As String

        Dim md5 As New MD5CryptoServiceProvider
        Dim sha1 As New SHA1CryptoServiceProvider
        Dim sha256 As New SHA256Managed
        Dim sha512 As New SHA512Managed

        Dim TexteEnBit() As Byte
        Dim TexteHache() As Byte = Nothing

        ' Récupération de la valeur en bit du texte à hacher 
        TexteEnBit = System.Text.Encoding.UTF8.GetBytes(Texte)

        Select Case type
            Case "md5"
                ' Hachage
                TexteHache = md5.ComputeHash(TexteEnBit)
                'Libération des ressources 
                md5.Clear()
            Case "sha1"
                ' Hachage
                TexteHache = sha1.ComputeHash(TexteEnBit)
                'Libération des ressources 
                sha1.Clear()
            Case "sha256"
                ' Hachage
                TexteHache = sha256.ComputeHash(TexteEnBit)
                'Libération des ressources 
                sha256.Clear()
            Case "sha512"
                ' Hachage 
                TexteHache = sha512.ComputeHash(TexteEnBit)
                'Libération des ressources 
                sha512.Clear()

        End Select

        ' Renvoi 
        encode = ByteArrayToString(TexteHache)

    End Function

    'Fonction pour convertir des bits en string
    Function ByteArrayToString(ByVal arrInput() As Byte) As String
        Dim i As Integer
        Dim sOutput As New StringBuilder(arrInput.Length)
        For i = 0 To arrInput.Length - 1
            sOutput.Append(arrInput(i).ToString("X2"))
        Next
        Return sOutput.ToString().ToLower
    End Function

End Module
