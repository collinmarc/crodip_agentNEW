﻿Imports System.Xml.Serialization
Imports System.Collections.Generic
Imports System.IO
Imports System.IO.Compression

Public Class ParamReglagePulve
    Public Shared XMLFileName As String = "aqwzsx.crodip"
    Private _Coluser As New List(Of RPUser)
    Public Property coluser As List(Of RPUser)
        Get
            Return _Coluser
        End Get
        Set(value As List(Of RPUser))
            _Coluser = value
        End Set
    End Property
    Public Function getUSer(pCode As String) As RPUser
        Dim oReturn As RPUser = Nothing
        Dim oUser As RPUser
        For Each oUser In _Coluser
            If oUser.Code = pCode Then
                oReturn = oUser
            End If
        Next
        Return oReturn
    End Function

    'Fonction de génération du fichier XML 
    'Paramétre = nom du fichier XML
    Public Shared Function GenerateXML(pFolder As String, pObj As ParamReglagePulve) As Boolean
        Dim bReturn As Boolean
        Dim n As Integer = 0
        Dim oStW As New System.IO.StreamWriter(pFolder & "/" & XMLFileName, False, System.Text.Encoding.UTF8)
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
            Compress(pFolder & "/" & XMLFileName)
            System.IO.File.Delete(pFolder & "/" & XMLFileName)
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
    Public Shared Function ReadXML(pFolder As String) As ParamReglagePulve
        Dim bReturn As Boolean
        Dim oParamReglagePulve As New ParamReglagePulve

        Try
            Decompress(pFolder & "/" & XMLFileName & "z")
            If (System.IO.File.Exists(pFolder & "/" & XMLFileName)) Then
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
                File.Delete(pFolder & "/" & XMLFileName)
            Else
                'Le fichier XML n'existe pas
                bReturn = False
            End If
        Catch ex As Exception
            bReturn = False
        End Try
        Return oParamReglagePulve
    End Function
    ''' <summary>
    ''' Compression d'un fichier
    ''' le fichier sera compressé dans Fichierz
    ''' </summary>
    ''' <param name="pstrFile">Nom du fichier à Compresser</param>
    Private Shared Sub Compress(pstrFile As String)
        'Suppression du fichier compressé 
        If File.Exists(pstrFile & "z") Then
            File.Delete(pstrFile & "z")
        End If
        Dim FileToCompress As FileInfo = New FileInfo(pstrFile)
        Using originalFileStream As FileStream = FileToCompress.OpenRead()
            If (File.GetAttributes(FileToCompress.FullName) And FileAttributes.Hidden) <> FileAttributes.Hidden And FileToCompress.Extension <> ".crodipz" Then
                Using compressedFileStream As FileStream = File.Create(pstrFile & "z")
                    Using compressionStream As New GZipStream(compressedFileStream, CompressionMode.Compress)

                        originalFileStream.CopyTo(compressionStream)
                    End Using
                End Using
            End If
        End Using
    End Sub
    ''' <summary>
    ''' Decompression d'une archive
    ''' on enelve la dernière lettre du nom de fichier pour le décompresser
    ''' </summary>
    ''' <param name="pstrFileArchive"></param>
    Private Shared Sub Decompress(ByVal pstrFileArchive As String)
        Dim fileToDecompress As New FileInfo(pstrFileArchive)
        Using originalFileStream As FileStream = fileToDecompress.OpenRead()
            Dim currentFileName As String = fileToDecompress.FullName
            Dim newFileName As String = currentFileName.Remove(currentFileName.Length - 1)

            Using decompressedFileStream As FileStream = File.Create(newFileName)
                Using decompressionStream As GZipStream = New GZipStream(originalFileStream, CompressionMode.Decompress)
                    decompressionStream.CopyTo(decompressedFileStream)
                End Using
            End Using
        End Using
    End Sub



End Class
