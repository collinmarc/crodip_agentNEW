Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Crodip_agent

<TestClass()> Public Class testBDASCAR

    'Test uniquement pour MAJ base ASCAR
    'Mettre la base crodip_agent_dev(ASCAROK).mdb active avant l'executio du test
    <TestMethod()>
    Public Sub TestASCAR()
        Dim olst As List(Of Pulverisateur)
        Dim oPulve As Pulverisateur
        Dim oAgent As Agent
        olst = FTOgetUpdates()


        WSCrodip.Init("http://admin.crodip.fr/server")
        oAgent = AgentManager.getAgentById("1048")
        PulverisateurManager.MAJetatPulverisateurs(oAgent, olst)

        For Each oPulve In olst
            If oPulve.numeroNational <> "E001" Then
                Dim oReturn As Object
                Dim nRet As Integer
                nRet = PulverisateurManager.sendWSPulverisateur(oAgent, oPulve, oReturn)

            End If
        Next

        'ceci est un test
    End Sub

    Public Shared Function FTOgetUpdates() As List(Of Pulverisateur)
        ' déclarations
        Dim oLst As New List(Of Pulverisateur)
        Dim oCSdb As New CSDb(True)
        Dim bddCommande As OleDb.OleDbCommand = oCSdb.getConnection().CreateCommand()
        bddCommande.CommandText = "SELECT * FROM Pulverisateur WHERE dateModificationAgent>=#2017/06/29 00:00:01#"
        '        bddCommande.CommandText = bddCommande.CommandText & " and id = '5-1074-680'"
        '"

        Try
            ' On récupère les résultats
            Dim tmpListProfils As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
            ' Puis on les parcours
            While tmpListProfils.Read()
                ' On rempli notre tableau
                Dim tmpPulverisateur As New Pulverisateur
                Dim tmpColId As Integer = 0
                While tmpColId < tmpListProfils.FieldCount()
                    If Not tmpListProfils.IsDBNull(tmpColId) Then
                        tmpPulverisateur.Fill(tmpListProfils.GetName(tmpColId), tmpListProfils.Item(tmpColId))
                    End If
                    tmpColId = tmpColId + 1
                End While
                oLst.Add(tmpPulverisateur)
            End While

        Catch ex As Exception ' On intercepte l'erreur
            CSDebug.dispError("PulverisateurManager - getUpdates : " & ex.Message)
        End Try

        oCSdb.free()
        'on retourne les objet non synchro
        Return oLst
    End Function

End Class