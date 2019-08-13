Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Net

<TestClass()> Public Class CsFTPTest
    Inherits CRODIPTest

    <TestMethod()> Public Sub UpLoad()

        'Creation d'un fichier
        If System.IO.File.Exists("./a.tst") Then
            System.IO.File.Delete("./a.tst")
        End If

        System.IO.File.AppendAllText("./a.tst", "fichier de test")
        Dim oCSFTP As New Crodip_agent.CSFTP("test", "test", "127.0.0.1:21")
        oCSFTP.Upload("a.tst")

        Assert.IsFalse(oCSFTP.FileExists("./adel.tst"))
        Assert.IsTrue(oCSFTP.FileExists("./a.tst"))

    End Sub

End Class