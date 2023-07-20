Imports System.Text
Imports Crodip_agent
Imports System.Xml.Serialization
Imports System.IO
Imports CRODIP_ControlLibrary
Imports Microsoft.VisualStudio.TestTools.UnitTesting

''' <summary>
''' Classe de tests pour les paramètres de Metrologie
''' 
''' </summary>
''' <remarks></remarks>
<TestClass()>
Public Class ParamMetrologieTest
    Inherits CRODIPTest
    ''' <summary>
    ''' Ce test permet de générer le fichier XML, ce n'est pas un test au sens strict du term
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()>
    Public Sub generateXMLParamCtrlDiag()
        Dim olst As lstParamMetrologie


        olst = New lstParamMetrologie()

        Dim oParam As ParamMetrologie

        oParam = New ParamMetrologie("1.6", "1")
        oParam.PressionMontantes.Add(New CRODIP_ControlLibrary.ParamMetrologiePression(1, 1.6D))
        oParam.PressionMontantes.Add(New CRODIP_ControlLibrary.ParamMetrologiePression(2, 1.7D))
        oParam.PressionMontantes.Add(New CRODIP_ControlLibrary.ParamMetrologiePression(3, 1.8D))
        oParam.PressionMontantes.Add(New CRODIP_ControlLibrary.ParamMetrologiePression(4, 1.9D))
        oParam.PressionMontantes.Add(New CRODIP_ControlLibrary.ParamMetrologiePression(5, 2D))
        oParam.PressionMontantes.Add(New CRODIP_ControlLibrary.ParamMetrologiePression(6, 2.1D))

        oParam.PressionDescendantes.Add(New CRODIP_ControlLibrary.ParamMetrologiePression(1, 2D))
        oParam.PressionDescendantes.Add(New CRODIP_ControlLibrary.ParamMetrologiePression(2, 2.1D))
        oParam.PressionDescendantes.Add(New CRODIP_ControlLibrary.ParamMetrologiePression(3, 2.2D))
        oParam.PressionDescendantes.Add(New CRODIP_ControlLibrary.ParamMetrologiePression(4, 2.3D))
        oParam.PressionDescendantes.Add(New CRODIP_ControlLibrary.ParamMetrologiePression(5, 2.4D))

        oParam.Repetitions.Add(New CRODIP_ControlLibrary.ParamMetrologiePression(1, 3D))
        oParam.Repetitions.Add(New CRODIP_ControlLibrary.ParamMetrologiePression(2, 3.1D))
        oParam.Repetitions.Add(New CRODIP_ControlLibrary.ParamMetrologiePression(3, 3.2D))
        olst.lstParam.Add(oParam)

        oParam = New ParamMetrologie("10", "1")
        oParam.PressionMontantes.Add(New CRODIP_ControlLibrary.ParamMetrologiePression(1, 10.6D))
        oParam.PressionMontantes.Add(New CRODIP_ControlLibrary.ParamMetrologiePression(2, 10.7D))
        oParam.PressionMontantes.Add(New CRODIP_ControlLibrary.ParamMetrologiePression(3, 10.8D))
        oParam.PressionMontantes.Add(New CRODIP_ControlLibrary.ParamMetrologiePression(4, 10.9D))
        oParam.PressionMontantes.Add(New CRODIP_ControlLibrary.ParamMetrologiePression(5, 20D))
        oParam.PressionMontantes.Add(New CRODIP_ControlLibrary.ParamMetrologiePression(6, 20.1D))

        oParam.PressionDescendantes.Add(New CRODIP_ControlLibrary.ParamMetrologiePression(1, 20D))
        oParam.PressionDescendantes.Add(New CRODIP_ControlLibrary.ParamMetrologiePression(2, 20.1D))
        oParam.PressionDescendantes.Add(New CRODIP_ControlLibrary.ParamMetrologiePression(3, 20.2D))
        oParam.PressionDescendantes.Add(New CRODIP_ControlLibrary.ParamMetrologiePression(4, 20.3D))
        oParam.PressionDescendantes.Add(New CRODIP_ControlLibrary.ParamMetrologiePression(5, 20.4D))

        oParam.Repetitions.Add(New CRODIP_ControlLibrary.ParamMetrologiePression(1, 30D))
        oParam.Repetitions.Add(New CRODIP_ControlLibrary.ParamMetrologiePression(2, 30.1D))
        oParam.Repetitions.Add(New CRODIP_ControlLibrary.ParamMetrologiePression(3, 30.2D))
        olst.lstParam.Add(oParam)
        'Sauvegarde du fichier
        Assert.IsTrue(olst.writeXml())

        'Test Existence
        Assert.IsTrue(File.Exists(lstParamMetrologie.FILE_NAME))
        'Ouverture
        CSFile.open(lstParamMetrologie.FILE_NAME)

        'Relecture du fichier
        Assert.IsTrue(olst.readXML())
        'on a 
        Assert.AreEqual(2, olst.lstParam.Count)
        oParam = olst.lstParam(0)
        Assert.AreEqual("1.6", oParam.FondEchelle)
        Assert.AreEqual("1", oParam.Classe)
        Assert.AreEqual(6, oParam.PressionMontantes.Count)
        Assert.AreEqual(5, oParam.PressionDescendantes.Count)
        Assert.AreEqual(3, oParam.Repetitions.Count)

        Assert.AreEqual(1, oParam.PressionMontantes(0).Num)
        Assert.AreEqual(1.6D, oParam.PressionMontantes(0).Valeur)
        Assert.AreEqual(2, oParam.PressionMontantes(1).Num)
        Assert.AreEqual(1.7D, oParam.PressionMontantes(1).Valeur)
        Assert.AreEqual(3, oParam.PressionMontantes(2).Num)
        Assert.AreEqual(1.8D, oParam.PressionMontantes(2).Valeur)
        Assert.AreEqual(4, oParam.PressionMontantes(3).Num)
        Assert.AreEqual(1.9D, oParam.PressionMontantes(3).Valeur)
        Assert.AreEqual(5, oParam.PressionMontantes(4).Num)
        Assert.AreEqual(2D, oParam.PressionMontantes(4).Valeur)
        Assert.AreEqual(6, oParam.PressionMontantes(5).Num)
        Assert.AreEqual(2.1D, oParam.PressionMontantes(5).Valeur)

        Assert.AreEqual(1, oParam.PressionDescendantes(0).Num)
        Assert.AreEqual(2D, oParam.PressionDescendantes(0).Valeur)
        Assert.AreEqual(2, oParam.PressionDescendantes(1).Num)
        Assert.AreEqual(2.1D, oParam.PressionDescendantes(1).Valeur)
        Assert.AreEqual(3, oParam.PressionDescendantes(2).Num)
        Assert.AreEqual(2.2D, oParam.PressionDescendantes(2).Valeur)
        Assert.AreEqual(4, oParam.PressionDescendantes(3).Num)
        Assert.AreEqual(2.3D, oParam.PressionDescendantes(3).Valeur)
        Assert.AreEqual(5, oParam.PressionDescendantes(4).Num)
        Assert.AreEqual(2.4D, oParam.PressionDescendantes(4).Valeur)

        Assert.AreEqual(1, oParam.Repetitions(0).Num)
        Assert.AreEqual(3D, oParam.Repetitions(0).Valeur)
        Assert.AreEqual(2, oParam.Repetitions(1).Num)
        Assert.AreEqual(3.1D, oParam.Repetitions(1).Valeur)
        Assert.AreEqual(3, oParam.Repetitions(2).Num)
        Assert.AreEqual(3.2D, oParam.Repetitions(2).Valeur)

    End Sub

End Class
