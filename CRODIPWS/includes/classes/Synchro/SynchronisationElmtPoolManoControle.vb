Imports System.Web.Services
Imports System.Xml.Serialization
Imports System.Security.Cryptography
Imports System.IO
Imports System.Text
''' <summary>
''' SynchronisationElmtIdentifiantPulverisateur
''' Element de Synchronistation d'un identifiant Pulvérisateur
''' </summary>
''' <remarks></remarks>
Public Class SynchronisationElmtPoolManoControle
    Inherits SynchronisationElmt
    Public Sub New(pSynchroBoleans As SynchroBooleans)
        MyBase.New(getLabelGet(), pSynchroBoleans)
        IdentifiantEntier = 0
        IdentifiantChaine = ""
        ValeurAuxiliaire = ""
    End Sub
    'constructeur Sans paramètre utilisé uniquement pour la sérialisation
    Public Sub New()
        MyBase.New(getLabelGet(), New SynchroBooleans)
        IdentifiantEntier = 0
        IdentifiantChaine = ""
        ValeurAuxiliaire = ""
    End Sub

    Public Shared Function getLabelGet() As String
        Return "GetPoolManoControle"
    End Function
    Public Overrides Function SynchroDesc(pAgent As Agent) As Boolean
        Dim bReturn As Boolean
        Try
            Dim obj As New PoolManoControle
            Try
                obj = PoolManoControleManager.WSgetById(Me.IdentifiantEntier, Me.IdentifiantChaine)
                If obj.uid <> 0 Then
                    bReturn = PoolManoControleManager.Save(obj, True)
                    Dim oManoControle As ManometreControle = ManometreControleManager.getByKey(obj.uidmanoc)
                    If oManoControle Is Nothing Then
                        oManoControle = ManometreControleManager.WSgetById(obj.uidmanoc, "")
                        If oManoControle IsNot Nothing Then
                            ManometreControleManager.save(oManoControle)
                        End If
                    End If
                Else
                    bReturn = False
                End If
            Catch ex As Exception
                CSDebug.dispError("SynchronisationElmtPoolPc.SynchroDesc(" & Me.IdentifiantEntier & ") ERR : " & ex.Message.ToString)
                bReturn = False
            End Try

            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("SynchronisationElmtPoolPc.SynhcroDesc (" & Me.IdentifiantEntier & ")ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    ''' <summary>
    ''' Synhcronisation Ascendante des PoolPc
    ''' </summary>
    ''' <param name="pAgent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function SynchroAsc(pAgent As Agent) As Boolean
        Dim bReturn As Boolean = False
        Return bReturn
    End Function

End Class
