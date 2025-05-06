Imports System.Text
Imports CRODIPWS
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Microsoft.Win32

<TestClass()> Public Class AgentPCTest
    Inherits CRODIPTest

    <TestMethod()> Public Sub CRUD()

        Dim oAgentPC As New AgentPc()
        oAgentPC.idRegistre = "AQWZSX"
        oAgentPC.idCrodip = "123465"

        Assert.IsTrue(AgentPcManager.Save(oAgentPC))
        Dim sIdCrodip As String = oAgentPC.idCrodip

        oAgentPC = AgentPcManager.GetByuid("123465")
        Assert.AreEqual(sIdCrodip, oAgentPC.idCrodip)
        Assert.AreEqual("AQWZSX", oAgentPC.idRegistre)
        Assert.AreEqual("123465", oAgentPC.idCrodip)

        oAgentPC.idRegistre = "AZERTYUIOP"

        Assert.IsTrue(AgentPcManager.Save(oAgentPC))

        oAgentPC = AgentPcManager.GetByuid("123465")
        Assert.AreEqual(sIdCrodip, oAgentPC.idCrodip)
        Assert.AreEqual("AZERTYUIOP", oAgentPC.idRegistre)
        Assert.AreEqual("123465", oAgentPC.idCrodip)


    End Sub
    <TestMethod()> Public Sub GetPCListTest()
        'l'agent contient le pool
        Assert.IsNotNull(m_oAgent.oPool)
        Dim lstPc As List(Of AgentPc)
        lstPc = AgentPcManager.WSGetListByPool(m_oAgent.oPool)
        Assert.AreNotEqual(0, lstPc)
        For Each oAgentPc As AgentPc In lstPc
            Assert.AreEqual(m_oAgent.uidstructure, oAgentPc.uidstructure)
        Next


    End Sub
    <TestMethod()> Public Sub RegistryTest()
        'Sauvegarde du contenu de la base de registre
        Const RegistryPath As String = "HKEY_CURRENT_USER\CRODIP"
        Const subkey1 As String = "CRODIP"
        Const subkey2 As String = "PC"
        Dim PC_Origine As String = Registry.GetValue(RegistryPath, subkey2, "VIDE")
        Dim CLE_Origine As String = Registry.GetValue(RegistryPath, subkey1, "VIDE")
        Registry.SetValue(RegistryPath, subkey1, "")
        Registry.SetValue(RegistryPath, subkey2, "")

        Dim oAgentPc As New AgentPc()
        oAgentPc.idCrodip = "12345"
        oAgentPc.uidstructure = m_oStructure.uid
        AgentPcManager.Save(oAgentPc)

        Assert.IsTrue(AgentPcManager.IsRegistryVide())
        oAgentPc.SaveRegistry()
        Dim PC As String = Registry.GetValue(RegistryPath, subkey2, "VIDE")
        Dim CLE As String = Registry.GetValue(RegistryPath, subkey1, "VIDE")
        Assert.AreEqual(oAgentPc.idCrodip, PC)
        Assert.AreEqual(oAgentPc.idRegistre, CLE)

        Assert.IsFalse(AgentPcManager.IsRegistryVide())
        Dim oAgentPC2 As AgentPc
        oAgentPC2 = AgentPcManager.GetAgentPCFromRegistry()
        Assert.AreEqual(oAgentPc.idCrodip, oAgentPc.idCrodip)
        Assert.AreEqual(oAgentPc.idRegistre, oAgentPc.idRegistre)




        'Remise à l'état initial
        Registry.SetValue(RegistryPath, subkey2, PC_Origine)
        Registry.SetValue(RegistryPath, subkey1, CLE_Origine)

    End Sub



End Class