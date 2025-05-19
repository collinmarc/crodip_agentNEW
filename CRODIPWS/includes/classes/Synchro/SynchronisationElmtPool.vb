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
Public Class SynchronisationElmtPool
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
        Return "GetPool"
    End Function
    Public Overrides Function SynchroDesc(pAgent As Agent) As Boolean
        Dim bReturn As Boolean
        Try
            Dim oPool As New Pool
            Try
                oPool = PoolManager.WSgetById(Me.IdentifiantEntier, Me.IdentifiantChaine)
                If oPool.uid <> 0 Then
                    bReturn = PoolManager.Save(oPool, True)
                    If bReturn Then
                        Dim oBanc As Banc
                        oBanc = BancManager.WSgetById(oPool.uidbanc, oPool.aidbanc)
                        If oBanc IsNot Nothing Then
                            BancManager.save(oBanc)
                        End If
                    End If

                    'Suppression de toutes les associations dépendantes car elle seront recrées ensuite par synchro
                    PoolManoControleManager.DeleteFromPool(oPool)
                    PoolBuseManager.DeleteFromPool(oPool)
                    PoolAgentManager.DeleteFromPool(oPool)
                    PoolManoEtalonManager.DeleteFromPool(oPool)
                    PoolPcManager.DeleteFromPool(oPool)
                Else
                    bReturn = False
                End If
            Catch ex As Exception
                CSDebug.dispError("SynchronisationElmtPool.SynchroDesc(" & Me.IdentifiantEntier & ") ERR : " & ex.Message.ToString)
                bReturn = False
            End Try

            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("SynchronisationElmtPool.SynhcroDesc (" & Me.IdentifiantEntier & ")ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    ''' <summary>
    ''' Synhcronisation Ascendante des Pool
    ''' </summary>
    ''' <param name="pAgent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function SynchroAsc(pAgent As Agent) As Boolean
        Dim bReturn As Boolean = False
        Return bReturn
    End Function

End Class
