Imports System.Xml.Serialization
Imports System.Collections.Generic
Public Class ParamReglagePulve
    Private Const XMLFileName As String = "aqwzsx.crodip"
    Private _Coluser As New List(Of UserReglagePulve)
    Public Property coluser As List(Of UserReglagePulve)
        Get
            Return _Coluser
        End Get
        Set(value As List(Of UserReglagePulve))
            _Coluser = value
        End Set
    End Property
    Public Function getUSer(pCode As String) As UserReglagePulve
        Dim oReturn As UserReglagePulve
        Dim oUser As UserReglagePulve
        For Each oUser In _Coluser
            If oUser.Code = pCode Then
                oReturn = oUser
            End If
        Next
        Return oReturn
    End Function

    'Fonction de génération du fichier XML 
    'Paramétre = nom du fichier XML
    Public Shared Function GenerateXML(pObj As ParamReglagePulve) As Boolean
        Dim bReturn As Boolean
        Dim oStW As New System.IO.StreamWriter(XMLFileName, False, System.Text.Encoding.UTF8)
        Try
            'Création de l'objet d'écriture dans le fichier
            'Création du sérializer
            Dim oXS As New XmlSerializer(pObj.GetType())
            'Déclaration pour supprimer le NameSpace dans l'entete
            Dim ns As New XmlSerializerNamespaces
            ns.Add(String.Empty, String.Empty)
            'Génération du Flux XML
            oXS.Serialize(oStW, pObj, ns)
            'Ecriture et fermeture du fichier
            oStW.Close()
            bReturn = True
        Catch ex As Exception
            bReturn = False
            oStW.Close()
        End Try
        Return bReturn
    End Function

    ''' <summary>
    ''' Lecture des Paramètre dans le fichier XML
    ''' </summary>
    ''' <param name="pFileName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ReadXML() As ParamReglagePulve
        Dim bReturn As Boolean
        Dim oParamReglagePulve As New ParamReglagePulve
        Try
            If (System.IO.File.Exists(XMLFileName)) Then
                'Création du reader du fichier XML
                Dim oStR As New System.IO.StreamReader(XMLFileName)
                Dim oXS As New XmlSerializer(oParamReglagePulve.GetType())
                'Déclaration pour supprimer le NameSpace dans l'entete
                Dim ns As New XmlSerializerNamespaces
                ns.Add(String.Empty, String.Empty)
                'La lecture du fichier XML génére une collection de VIF_INNOVAS
                oParamReglagePulve = oXS.Deserialize(oStR)
                oStR.Close()

                bReturn = True
            Else
                'Le fichier XML n'existe pas
                bReturn = False
            End If
        Catch ex As Exception
            bReturn = False
        End Try
        Return oParamReglagePulve
    End Function

End Class
