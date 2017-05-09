Imports System

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Crodip_agent



'''<summary>
'''Classe de de base pour les tests CRODIP
'''</summary>
<TestClass()> _
Public Class cmdTest
    Inherits CRODIPTest

    '''<summary>
    '''Test pour Execute Delete File
    '''</summary>
    <TestMethod()> _
    Public Sub ExecuteDeleteFileTest()
        Dim oCmd As New Cmd

        'Création des fichiers temporaires
        If System.IO.File.Exists("TEST1.tmp") Then
            My.Computer.FileSystem.DeleteFile("TEST1.tmp")
        End If
        System.IO.File.CreateText("Test1.tmp").Close()
        If System.IO.File.Exists("TEST2.tmp") Then
            My.Computer.FileSystem.DeleteFile("TEST2.tmp")
        End If
        System.IO.File.CreateText("Test2.tmp").Close()

        'Vérification de l'existence des fichiers
        Assert.IsTrue(System.IO.File.Exists("TEST1.tmp"))
        Assert.IsTrue(System.IO.File.Exists("TEST2.tmp"))

        'Execution de la requete
        Assert.IsTrue(oCmd.executeLine("DELETE Test1.tmp"))

        'Vérification du résultat
        Assert.IsFalse(System.IO.File.Exists("TEST1.tmp"))
        Assert.IsTrue(System.IO.File.Exists("TEST2.tmp"))

        ' Executiond'une commande avec un fichier inexistant
        Assert.IsTrue(oCmd.executeLine("DELETE Test3.tmp"))

        ' Execution d'une commande Erronnée
        Assert.IsTrue(oCmd.executeLine("DELET Test2.tmp"))
        Assert.IsTrue(System.IO.File.Exists("TEST2.tmp"))


    End Sub

    '''Vérification de la suppression des répertoires
    <TestMethod()> _
    Public Sub ExecuteDeleteDirTest()
        Dim oCmd As New Cmd

        'Création des fichiers temporaires
        If My.Computer.FileSystem.DirectoryExists("TempDirVide") Then
            My.Computer.FileSystem.DeleteDirectory("TempDirVide", FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If
        My.Computer.FileSystem.CreateDirectory("TempDirVide")

        If My.Computer.FileSystem.DirectoryExists("TempDirPleine") Then
            My.Computer.FileSystem.DeleteDirectory("TempDirPleine", FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If
        My.Computer.FileSystem.CreateDirectory("TempDirPleine")
        System.IO.File.CreateText("TempDirPleine/Test1.tmp").Close()

        If My.Computer.FileSystem.DirectoryExists("TempDir3") Then
            My.Computer.FileSystem.DeleteDirectory("TempDir3", FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If
        My.Computer.FileSystem.CreateDirectory("TempDir3")

        'Vérification de l'existence des répertoires
        Assert.IsTrue(My.Computer.FileSystem.DirectoryExists("TempDirVide"))
        Assert.IsTrue(My.Computer.FileSystem.DirectoryExists("TempDirPleine"))
        Assert.IsTrue(My.Computer.FileSystem.DirectoryExists("TempDir3"))

        'Execution de la requete
        Assert.IsTrue(oCmd.executeLine("DELETE TempDirVide"))

        'Vérification du résultat
        Assert.IsFalse(My.Computer.FileSystem.DirectoryExists("TempDirVide"))
        Assert.IsTrue(My.Computer.FileSystem.DirectoryExists("TempDirPleine"))
        Assert.IsTrue(My.Computer.FileSystem.DirectoryExists("TempDir3"))

        'Execution de la requete
        Assert.IsTrue(oCmd.executeLine("DELETE TempDirPleine"))
        Assert.IsFalse(My.Computer.FileSystem.DirectoryExists("TempDirVide"))
        Assert.IsFalse(My.Computer.FileSystem.DirectoryExists("TempDirPleine"))
        Assert.IsTrue(My.Computer.FileSystem.DirectoryExists("TempDir3"))


    End Sub

    '''Test de l'execution d'un ensemble de commande
    <TestMethod()> _
    Public Sub ExecuteFileTest()
        'Création des fichier temporaires
        If System.IO.File.Exists("TEST1.tmp") Then
            My.Computer.FileSystem.DeleteFile("TEST1.tmp")
        End If
        System.IO.File.CreateText("Test1.tmp").Close()
        If System.IO.File.Exists("TEST2.tmp") Then
            My.Computer.FileSystem.DeleteFile("TEST2.tmp")
        End If
        System.IO.File.CreateText("Test2.tmp").Close()
        If My.Computer.FileSystem.DirectoryExists("TempDirPleine") Then
            My.Computer.FileSystem.DeleteDirectory("TempDirPleine", FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If
        My.Computer.FileSystem.CreateDirectory("TempDirPleine")
        System.IO.File.CreateText("TempDirPleine/Test1.tmp").Close()

        If My.Computer.FileSystem.DirectoryExists("TempDir3") Then
            My.Computer.FileSystem.DeleteDirectory("TempDir3", FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If
        My.Computer.FileSystem.CreateDirectory("TempDir3")

        'Création du fichier de commande
        If System.IO.File.Exists("cmd.temp") Then
            My.Computer.FileSystem.DeleteFile("cmd.temp")
        End If

        System.IO.File.AppendAllText("cmd.temp", "DELETE Test1.tmp" & vbCrLf)
        System.IO.File.AppendAllText("cmd.temp", "DELETE tempDir1" & vbCrLf)
        Assert.IsTrue(My.Computer.FileSystem.FileExists("cmd.temp"))

        Dim oCmd As New Cmd()
        Assert.IsTrue(oCmd.execute("cmd.temp"))
        Assert.IsFalse(My.Computer.FileSystem.FileExists("Test1.tmp"))
        Assert.IsFalse(My.Computer.FileSystem.DirectoryExists("TempDirPleine.tmp"))
        Assert.IsTrue(My.Computer.FileSystem.DirectoryExists("TempDir3"))
    End Sub

End Class
