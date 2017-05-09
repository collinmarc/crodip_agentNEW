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
        'File.AppendText("./ADEL.txt").WriteLine("Ceci est un fichier texte")
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

End Class