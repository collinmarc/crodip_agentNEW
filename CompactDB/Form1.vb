Public Class Form1

    Public Const conf_bddUser As String = "Developpeur"
    Public conf_bddPass = "UmtU8Scb"
    Public conf_bddDLPath = "." & "\bdd\crodip_dasylab.mdb"
    Public conf_bddDLPass = "tRyQe8se"
    Public conf_bddPath = "crodip_agent"
    Public conf_bddPath_dev = "crodip_agent_dev"

    Public conf_bddEtatPath = "crodip_etats"
    Public conf_bddEtatPath_dev = "crodip_etats_dev"

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim bReturn As Boolean
        Try
            Dim jro As JRO.JetEngine
            jro = New JRO.JetEngine()
            Dim bddOri As String = getConnectString(conf_bddPath)
            Dim bdd2 As String = getConnectString(conf_bddPath & "2")
            If System.IO.File.Exists("./bdd/" & conf_bddPath & "2.mdb") Then
                System.IO.File.Delete("./bdd/" & conf_bddPath & "2.mdb")
            End If
            jro.CompactDatabase(bddOri, bdd2)
            If System.IO.File.Exists("./bdd/" & conf_bddPath & ".mdb") Then
                System.IO.File.Delete("./bdd/" & conf_bddPath & ".mdb")
            End If
            System.IO.File.Move("./bdd/" & conf_bddPath & "2.mdb", "./bdd/" & conf_bddPath & ".mdb")
            bReturn = True
        Catch ex As Exception
            MessageBox.Show("CSDB.CompateDatabase ERR" & ex.Message)
            bReturn = False
        End Try

    End Sub

    Public Function getConnectString(pDBName As String) As String
        Dim bReturn As String
#If DEBUG Then
        bReturn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=.\bdd\" & pDBName & "_dev.mdb;Jet OLEDB:System Database=.\bdd\" & pDBName & "_dev.mdw;User ID=" & conf_bddUser & ";Password=" & conf_bddPass & ";Jet OLEDB:Database Password="
#Else
        bReturn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=.\bdd\" & pDBName & ".mdb;Jet OLEDB:System Database=.\bdd\" & pDBName & ".mdw;User ID=" & conf_bddUser & ";Password=" & conf_bddPass & ";Jet OLEDB:Database Password=" & conf_bddPass & ""
#End If
        Return bReturn
    End Function

End Class
