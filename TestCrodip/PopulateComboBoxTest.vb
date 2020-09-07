Imports System.Text
Imports Crodip_agent
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
        ocsXML = Globals.GLOB_XML_MARQUES_MODELES_PULVE
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
        'Dim ocbx As New Windows.Forms.ComboBox
        'MarquesManager.populateCombobox_MarquesPulve(ocbx)
        'Assert.AreEqual(142, ocbx.Items.Count)

        'ocbx.Items.Clear()
        'MarquesManager.populateCombobox_ModelesPulve(ocbx, "ARLAND")
        'Assert.AreEqual(6, ocbx.Items.Count)

    End Sub
End Class
