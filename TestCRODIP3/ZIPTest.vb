Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Ionic.Zip

<TestClass()> Public Class ZIPTest

    <TestMethod()> Public Sub CreateZipFile()

        If System.IO.File.Exists("./pdfs.zip") Then
            System.IO.File.Delete("./pdfs.zip")
        End If
        Using z As New ZipFile()
            z.Password = "password"
            z.AddFile("testfiles/test/test.pdf")
            z.Save("./pdfs.zip")
        End Using
        If System.IO.File.Exists("./TEMP/testfiles/test/test.pdf") Then
            System.IO.File.Delete("./TEMP/testfiles/test/test.pdf")
        End If
        Using z As ZipFile = ZipFile.Read("./pdfs.zip")
            z.Password = "password"
            z.ExtractAll("TEMP")
        End Using
        Assert.IsTrue(System.IO.File.Exists("./TEMP/testfiles/test/test.pdf"))

        If System.IO.File.Exists("./testfiles/test/test.pdf") Then
            System.IO.File.Delete("./testfiles/test/test.pdf")
        End If
        Using z As ZipFile = ZipFile.Read("./pdfs.zip")
            z.Password = "password"
            z.ExtractSelectedEntries("test.pdf", "testfiles/test", "", ExtractExistingFileAction.OverwriteSilently)
        End Using
        Assert.IsTrue(System.IO.File.Exists("./testfiles/test/test.pdf"))


    End Sub

End Class