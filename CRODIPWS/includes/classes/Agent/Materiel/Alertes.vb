﻿Imports System.Collections.Generic
Imports System.IO
Imports System.Xml.Serialization

<XmlType("Alertes")>
Public Class Alertes
    Public Sub New()
        NiveauxAlertes = New List(Of NiveauAlerte)
    End Sub

    Public Property NiveauxAlertes As List(Of NiveauAlerte)

    Public Shared Function readXML(Optional pstrFile As String = "Alertes.xml") As Alertes
        Dim strFileName As String = GlobalsCRODIP.GLOB_PARAM_RepertoireParametres & "/" & pstrFile
        Dim oReturn As Alertes
        Try

            Using objStreamReader As New StreamReader(strFileName)
                Dim x As New XmlSerializer(GetType(Alertes))
                oReturn = x.Deserialize(objStreamReader)
            End Using

        Catch ex As Exception
            CSDebug.dispError("Alertes.ReadXML ERR" & ex.Message)
            If ex.InnerException IsNot Nothing Then
                CSDebug.dispError("Alertes.ReadXML ERR2" & ex.InnerException.Message)
            End If
            oReturn = Nothing
        End Try
        Return oReturn
    End Function

    Public Shared Function FTO_writeXml(pAlertes As Alertes, Optional ByVal pstrFile As String = "Alertes.xml") As Boolean
        Dim bReturn As Boolean
        Try
            Dim strFileName As String = GlobalsCRODIP.GLOB_PARAM_RepertoireParametres & "/" & pstrFile
            Dim ns As New System.Xml.Serialization.XmlSerializerNamespaces()
            ns.Add("", "") 'No namespaces needed.
            Dim objStreamWriter As New StreamWriter(strFileName)
            Dim x As New XmlSerializer(GetType(Alertes))
            x.Serialize(objStreamWriter, pAlertes, ns)
            objStreamWriter.Close()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError(ex.Message)
            If ex.InnerException IsNot Nothing Then
                CSDebug.dispError(ex.InnerException.Message)
            End If
            bReturn = False
        End Try
        Return bReturn
    End Function




End Class
