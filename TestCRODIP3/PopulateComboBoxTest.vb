Imports System.Text
Imports CrodipWS
Imports System.Xml.Serialization
Imports System.IO
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()>
Public Class PopulateComboTest

    ''' <summary>
    ''' Test ignoré car dépendant du paramétrage en cours
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod(), Ignore()>
    Public Sub XMLFileTest()
        Dim ocsXML As CSXml
        ocsXML = CrodipWS.GlobalsCRODIP.GLOB_XML_MARQUES_MODELES_PULVE
        Dim oNodes As Xml.XmlNodeList
        oNodes = ocsXML.getXmlNodes("/root/marque/libelle")
        Assert.AreEqual(142, oNodes.Count)

        oNodes = ocsXML.getXmlNodes("/root/marque[libelle=""ARLAND""]/Modeles/modele")
        Assert.AreEqual(0, oNodes.Count)
    End Sub
    ''' <summary>
    ''' Test ignoré car dépendant du paramétrage en cours
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod(), Ignore()>
    Public Sub CbxMarqueTest()
    End Sub
End Class
