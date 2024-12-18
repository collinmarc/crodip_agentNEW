﻿Imports System.Web.Services
Imports System.Xml.Serialization
Imports System.Collections.Generic

<Serializable(), XmlInclude(GetType(IdentifiantPulverisateur))>
Public Class IdentifiantPulverisateur
    Inherits root
    Private m_id As Long
    Private m_idStructure As Long
    Private m_numeroNational As String
    Private m_etat As String
    Private m_dateUtilisation As String
    Private m_libelle As String
    Private m_IDCRODIPPOOL As String
    Private m_dateModificationAgent As String
    Private m_dateModificationCrodip As String

    Public Property id As Long
        Get
            If Not String.IsNullOrEmpty(aid) Then
                Return aid
            Else
                Return 0
            End If
        End Get
        Set(value As Long)
            aid = value
        End Set
    End Property
    Public Property idStructure As Long
        Get
            Return m_idStructure
        End Get
        Set(value As Long)
            m_idStructure = value
        End Set
    End Property
    Public Property uidstructure As Integer
        Get
            Return m_idStructure
        End Get
        Set(value As Integer)
            m_idStructure = value
        End Set
    End Property
    Public Property numeroNational As String
        Get
            Return m_numeroNational
        End Get
        Set(value As String)
            m_numeroNational = value
        End Set
    End Property
    'Enum 'INUTILISE','UTILISE','INUTILISABLE'
    Public Property etat As String
        Get
            Return m_etat
        End Get
        Set(value As String)
            If value = "INUTILISE" Or value = "UTILISE" Or value = "INUTILISABLE" Then
                m_etat = value
            Else
                Throw New Exception("Valeurs possibles INUTILISE, UTILISE,INUTILISABLE")
            End If
        End Set
    End Property

    Public Sub SetEtatINUTILISE()
        etat = "INUTILISE"
    End Sub
    Public Sub SetEtatUTILISE()
        etat = "UTILISE"
    End Sub
    Public Sub SetEtatINUTILISABLE()
        etat = "INUTILISABLE"
    End Sub
    Public Function isEtatINUTILISE() As Boolean
        Return (etat = "INUTILISE")
    End Function
    Public Function isEtatUTILISE() As Boolean
        Return (etat = "UTILISE")
    End Function
    Public Function isEtatINUTILISABLE() As Boolean
        Return (etat = "INUTILISABLE")
    End Function
    Public Property dateUtilisation As String
        Get
            Return m_dateUtilisation
        End Get
        Set(value As String)
            If Not String.IsNullOrEmpty(value) Then
                m_dateUtilisation = CSDate.ToCRODIPString(value)
            Else
                m_dateUtilisation = ""
            End If
        End Set
    End Property
    Public Property libelle As String
        Get
            Return m_libelle
        End Get
        Set(value As String)
            m_libelle = value
        End Set
    End Property
    <XmlIgnore()>
    Public Property idCRODIPPool As String
        Get
            Return m_IDCRODIPPOOL
        End Get
        Set(value As String)
            m_IDCRODIPPOOL = value
        End Set
    End Property

    Public Overrides Function Fill(pColName As String, pColValue As Object) As Boolean
        Dim bReturn As Boolean = True
        Try
            pColName = pColName.Replace("IdentifiantPulverisateur.", "")
            If Not MyBase.Fill(pColName, pColValue) Then
                bReturn = True
                Select Case pColName.ToUpper().Trim
                    Case "id".ToUpper().Trim()
                        Me.id = pColValue.ToString()
                    Case "numeroNational".ToUpper().Trim()
                        Me.numeroNational = pColValue.ToString()
                    Case "idStructure".ToUpper().Trim()
                        Me.idStructure = pColValue.ToString()
                    Case "uidstructure".ToUpper().Trim()
                        Me.uidstructure = pColValue.ToString()
                    Case "etat".ToUpper().Trim()
                        Me.etat = pColValue.ToString()
                    Case "libelle".ToUpper().Trim()
                        Me.libelle = pColValue.ToString()
                    Case "idCrodipPool".ToUpper().Trim()
                        Me.idCRODIPPool = pColValue.ToString()
                    Case "dateUtilisation".ToUpper().Trim()
                        Me.dateUtilisation = pColValue.ToString()
                    Case Else
                        bReturn = False
                End Select
            End If
        Catch ex As Exception
            CSDebug.dispError("IdentifiantPulverisateur.Fill ERR" + ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Public Overrides Function ToString() As String
        Return "IdentifiantPulverisateur id=" & id & ",idStructure=" & idStructure & ",NuméroNational=" & numeroNational
    End Function

End Class
