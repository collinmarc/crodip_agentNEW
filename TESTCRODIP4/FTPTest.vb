Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Crodip_agent
Imports System.IO

''' <summary>
''' Ces tests sont ignorés car ils nécessitent d'aciver un serv FTP en local 
''' </summary>
''' <remarks></remarks>
<TestClass(), Ignore()> Public Class FTPTest

    <TestMethod(), Ignore()> Public Sub TestUpload()
        'Le Serveur FTP Local est paramétré avec user test, password test / Repertoire = R:\FTPLocal\
        'Avec TyopSoftTFP , il faut donner les droits Sous-RépertoireInclus et Upload

        Dim oFTP As New CSFTP("test", "test", "localhost")
        'Création du fichier en local
        File.AppendText("./ADEL.txt").WriteLine("Ceci est un fichier texte")
        'Suppression du fichier s'il existe sur le rep distant
        If File.Exists("r:/FTPLocal/updates.sql") Then
            File.Delete("r:/FTPLocal/updates.sql")
        End If

        oFTP.Upload("updates.sql")
        Assert.IsTrue(File.Exists("R:/FTPLocal/updates.sql"))
    End Sub
    <TestMethod(), Ignore()> Public Sub TestDownLoad()
        'Le Serveur FTP Local est paramétré avec user test, password test / Repertoire = R:\FTPLocal\
        'Avec TyopSoftTFP , il faut donner les droits Sous-RépertoireInclus et Upload

        Dim oFTP As New CSFTP("test", "test", "localhost")
        'Création du fichier en local
        'File.AppendText("./ADEL.txt").WriteLine("Ceci est un fichier texte")
        'Suppression du fichier s'il existe sur le rep distant
        If File.Exists("r:/FTPLocal/updates.sql") Then
            File.Delete("r:/FTPLocal/updates.sql")
        End If

        oFTP.Upload("updates.sql")
        Assert.IsTrue(File.Exists("R:/FTPLocal/updates.sql"))

        File.Delete("updates.sql")
        oFTP.DownLoad("updates.sql", "./")
        Assert.IsTrue(File.Exists("./updates.sql"))
    End Sub

    <TestMethod()> Public Sub TestUploadDownLoadTXT()

        Dim oFTP As New CSFTP()
        'Création du fichier en local

        Using sw As StreamWriter = File.AppendText("./ADEL.TXT")
            sw.WriteLine("Ceci est un fichier de tst")
        End Using

        oFTP.Upload("ADEL.txt")

        File.Delete("ADEL.txt")
        oFTP.DownLoad("ADEL.txt", "./")
        Assert.IsTrue(File.Exists("./ADEL.txt"))
    End Sub
    <TestMethod()> Public Sub TestUploadDownLoadPDF()

        Dim oFTP As New CSFTP()
        'Création du fichier en local


        oFTP.Upload("TestFiles/test.pdf", )

        If File.Exists("./test.pdf") Then
            File.Delete(".test.pdf")
        End If
        oFTP.DownLoad("test.pdf", "./")
        Assert.IsTrue(File.Exists("./test.pdf"))
    End Sub
End Class