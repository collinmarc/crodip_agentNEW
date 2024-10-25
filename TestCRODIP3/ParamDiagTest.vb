Imports System.Text
Imports CrodipWS
Imports System.Xml.Serialization
Imports System.IO
Imports CRODIP_ControlLibrary
Imports Microsoft.VisualStudio.TestTools.UnitTesting

''' <summary>
''' Classe de tests pour les paramètres de diagnostic
''' 
''' </summary>
''' <remarks></remarks>
<TestClass()>
Public Class ParamDiagTest
    Inherits CRODIPTest
    ''' <summary>
    ''' Ce test permet de générer le fichier XML, ce n'est pas un test au sens strict du term
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod(), Ignore()>
    Public Sub generateXMLParamCtrlDiag()
        Dim olst As LstParamCtrlDiag
        '        Dim oCSLib As CSLibelles


        olst = New LstParamCtrlDiag()
        'oCSLib = New CSLibelles()
        'Lecture du fichier
        Assert.IsTrue(olst.readXML("TestFiles/ParamdiagRampe.xml"))
        ' Afectationdu Libellé Long
        For Each oCtrl As ParamCtrlDiag In olst.ListeParam
            Assert.IsTrue(String.IsNullOrEmpty(oCtrl.LibelleLong))
            Assert.IsTrue(oCtrl.Actif)
            If String.IsNullOrEmpty(oCtrl.LibelleLong) And oCtrl.Libelle <> "OK" Then
                oCtrl.Actif = False
            End If
            If oCtrl.Code.IndexOf(".") = -1 Then
                oCtrl.Code = ParamCtrlDiag.ConvertCode(oCtrl.Code)
            End If
            Dim oDeb As String
            oDeb = oCtrl.Code.Substring(0, 5)
            If oDeb = "8.1.1" Or oDeb = "8.1.2" Or oDeb = "8.1.3" Or oDeb = "8.2.1" Or oDeb = "8.2.2" Or oDeb = "8.2.3" Or oDeb = "9.1.1" Or oDeb = "9.1.2" Then
                oCtrl.Actif = True
            End If
            If oDeb = "8.1.4" Then
                oCtrl.Actif = False
            End If
            If oCtrl.Code = "8.3.1.2" Then
                oCtrl.Actif = True
            End If
            If oCtrl.Code = "8.3.1.3" Then
                oCtrl.Actif = True
            End If
            If oCtrl.NiveauCauseMax = CRODIP_NIVEAUCAUSE.UN.ToString Then
                oCtrl.Cause1 = True
            End If
            If oCtrl.NiveauCauseMax = CRODIP_NIVEAUCAUSE.DEUX.ToString Then
                oCtrl.Cause1 = True
                oCtrl.Cause2 = True
            End If
            If oCtrl.NiveauCauseMax = CRODIP_NIVEAUCAUSE.TROIS.ToString Then
                oCtrl.Cause1 = True
                oCtrl.Cause2 = True
                oCtrl.Cause3 = True
            End If
            If oCtrl.Code = "10.2.1.3" Then
                oCtrl.DefaultCategorie = CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR.ToString
            End If
            If oCtrl.Code = "10.2.2.2" Then
                oCtrl.DefaultCategorie = CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR.ToString
            End If
            If oCtrl.Code = "10.2.2.3" Then
                oCtrl.DefaultCategorie = CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR.ToString
            End If
        Next
        'Sauvegarde du fichier
        Assert.IsTrue(olst.writeXml("TestFiles/ParamdiagRampeNew.xml"))
        'Relecture du fichier
        Assert.IsTrue(olst.readXML("TestFiles/ParamdiagRampeNew.xml"))
        For Each oCtrl As ParamCtrlDiag In olst.ListeParam
            'Vérificattion de la lecture du libelle Long
            If oCtrl.Libelle = "OK" Then
                Assert.IsTrue(String.IsNullOrEmpty(oCtrl.LibelleLong))
            Else
                If oCtrl.Actif Then
                    Assert.IsFalse(String.IsNullOrEmpty(oCtrl.LibelleLong))
                Else
                    Assert.IsTrue(String.IsNullOrEmpty(oCtrl.LibelleLong))
                End If
            End If
        Next

        '========================================
        'Lecture du fichier Arboviti
        olst = New LstParamCtrlDiag()
        Assert.IsTrue(olst.readXML("TestFiles/ParamdiagArboViti.xml"))
        ' Afectationdu Libellé Long
        For Each oCtrl As ParamCtrlDiag In olst.ListeParam
            Assert.IsTrue(String.IsNullOrEmpty(oCtrl.LibelleLong))
            Assert.IsTrue(oCtrl.Actif)
            If String.IsNullOrEmpty(oCtrl.LibelleLong) And oCtrl.Libelle <> "OK" Then
                oCtrl.Actif = False
            End If

            oCtrl.Code = ParamCtrlDiag.ConvertCode(oCtrl.Code)

            Dim oDeb As String
            oDeb = oCtrl.Code.Substring(0, 5)
            If oDeb = "8.1.1" Or oDeb = "8.1.2" Or oDeb = "8.1.3" Or oDeb = "8.2.1" Or oDeb = "8.2.2" Or oDeb = "8.2.3" Or oDeb = "9.1.1" Or oDeb = "9.1.2" Then
                oCtrl.Actif = False
            End If
            If oDeb = "8.1.4" Then
                oCtrl.Actif = True
            End If
            If oCtrl.Code = "8.3.1.2" Then
                oCtrl.Actif = False
            End If
            If oCtrl.Code = "8.3.1.3" Then
                oCtrl.Actif = False
            End If
            If oCtrl.NiveauCauseMax = CRODIP_NIVEAUCAUSE.UN.ToString Then
                oCtrl.Cause1 = True
            End If
            If oCtrl.NiveauCauseMax = CRODIP_NIVEAUCAUSE.DEUX.ToString Then
                oCtrl.Cause1 = True
                oCtrl.Cause2 = True
            End If
            If oCtrl.NiveauCauseMax = CRODIP_NIVEAUCAUSE.TROIS.ToString Then
                oCtrl.Cause1 = True
                oCtrl.Cause2 = True
                oCtrl.Cause3 = True
            End If
            If oCtrl.Code = "10.2.1.3" Then
                oCtrl.DefaultCategorie = CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR.ToString
            End If
            If oCtrl.Code = "10.2.2.2" Then
                oCtrl.DefaultCategorie = CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR.ToString
            End If
            If oCtrl.Code = "10.2.2.3" Then
                oCtrl.DefaultCategorie = CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR.ToString
            End If
        Next
        'Sauvegarde du fichier
        Assert.IsTrue(olst.writeXml("TestFiles/ParamdiagArboVitiNew.xml"))
        'Relecture du fichier
        Assert.IsTrue(olst.readXML("TestFiles/ParamdiagArboVitiNew.xml"))
        For Each oCtrl As ParamCtrlDiag In olst.ListeParam
            'Vérificattion de la lecture du libelle Long
            If oCtrl.Libelle = "OK" Then
                Assert.IsTrue(String.IsNullOrEmpty(oCtrl.LibelleLong))
            Else
                If oCtrl.Actif Then
                    Assert.IsFalse(String.IsNullOrEmpty(oCtrl.LibelleLong))
                Else
                    Assert.IsTrue(String.IsNullOrEmpty(oCtrl.LibelleLong))
                End If
            End If
        Next
    End Sub
    ''' <summary>
    ''' Ce test teste la classe ParamDiag qui contient le fichier de diag en fonction des types de pulvé
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()>
    Public Sub generateXML()

        Dim oParamDiag As ParamDiag
        Dim lst As List(Of ParamDiag)

        lst = New List(Of ParamDiag)

        oParamDiag = New ParamDiag()
        oParamDiag.id = "1"
        oParamDiag.libelle = "Cultures basses"
        oParamDiag.fichierConfig = "File1.xml"
        oParamDiag.ParamDiagCalc542.FTO_init()
        Dim oPression As New ParamDiagCalc542PlagePression("0", "2")
        oPression.colEcart.Add(New ParamDiagCalc542Ecart("VALEUR", "0,1", "0,2", 1))
        oPression.colEcart.Add(New ParamDiagCalc542Ecart("VALEUR", "0,2", "999", 2))
        oParamDiag.ParamDiagCalc542.EcartVariable.colPression.Add(oPression)
        oPression = New ParamDiagCalc542PlagePression("2", "999")
        oPression.colEcart.Add(New ParamDiagCalc542Ecart("%_PRESSION_REELLE", "5", "10", 1))
        oPression.colEcart.Add(New ParamDiagCalc542Ecart("%_PRESSION_REELLE", "10", "100", 2))
        oParamDiag.ParamDiagCalc542.EcartVariable.colPression.Add(oPression)
        oPression = New ParamDiagCalc542PlagePression("0", "10")
        oPression.colEcart.Add(New ParamDiagCalc542Ecart("VALEUR", "0", "0,5", 1))
        oPression.colEcart.Add(New ParamDiagCalc542Ecart("VALEUR", "0,5", "999", 2))
        oParamDiag.ParamDiagCalc542.EcartConstant.colPression.Add(oPression)
        oPression = New ParamDiagCalc542PlagePression("10", "999")
        oPression.colEcart.Add(New ParamDiagCalc542Ecart("VALEUR", "0", "1", 1))
        oPression.colEcart.Add(New ParamDiagCalc542Ecart("VALEUR", "1", "999", 2))
        oParamDiag.ParamDiagCalc542.EcartConstant.colPression.Add(oPression)
        oParamDiag.ParamDiagCalc833.limite8332 = "10.5"
        oParamDiag.ParamDiagCalc833.limite8333 = "11.5"

        lst.Add(oParamDiag)

        oParamDiag = New ParamDiag()
        oParamDiag.id = "2"
        oParamDiag.libelle = "Arbres"
        oParamDiag.fichierConfig = "File2.xml"
        oParamDiag.ParamDiagCalc833.limite8332 = "10.6"
        oParamDiag.ParamDiagCalc833.limite8333 = "11.6"

        lst.Add(oParamDiag)

        oParamDiag = New ParamDiag()
        oParamDiag.id = "3"
        oParamDiag.libelle = "Vignes"
        oParamDiag.fichierConfig = "File3.xml"
        oParamDiag.ParamDiagCalc833.limite8332 = "10.7"
        oParamDiag.ParamDiagCalc833.limite8333 = "11.7"

        lst.Add(oParamDiag)


        Assert.IsTrue(ParamDiag.writeXml(lst))

        lst = ParamDiag.readXML()
        Assert.AreEqual(3, lst.Count)

        oParamDiag = lst(0)
        Assert.AreEqual("Cultures basses", oParamDiag.libelle)
        Assert.AreEqual("0", oParamDiag.ParamDiagCalc542.EcartConstant.colPression(0).Mini)
        Assert.AreEqual("10", oParamDiag.ParamDiagCalc542.EcartConstant.colPression(0).Maxi)
        Assert.AreEqual(2, oParamDiag.ParamDiagCalc542.EcartConstant.colPression(0).colEcart.Count)
        Assert.AreEqual("0", oParamDiag.ParamDiagCalc542.EcartConstant.colPression(0).colEcart(0).Mini)
        Assert.AreEqual("0,5", oParamDiag.ParamDiagCalc542.EcartConstant.colPression(0).colEcart(0).Maxi)
        Assert.AreEqual("VALEUR", oParamDiag.ParamDiagCalc542.EcartConstant.colPression(0).colEcart(0).typeValeur)
        Assert.AreEqual(1, oParamDiag.ParamDiagCalc542.EcartConstant.colPression(0).colEcart(0).Imprecision)
        Assert.AreEqual("0,5", oParamDiag.ParamDiagCalc542.EcartConstant.colPression(0).colEcart(1).Mini)
        Assert.AreEqual("999", oParamDiag.ParamDiagCalc542.EcartConstant.colPression(0).colEcart(1).Maxi)
        Assert.AreEqual("VALEUR", oParamDiag.ParamDiagCalc542.EcartConstant.colPression(0).colEcart(1).typeValeur)
        Assert.AreEqual(2, oParamDiag.ParamDiagCalc542.EcartConstant.colPression(0).colEcart(1).Imprecision)
        Assert.AreEqual("10,5", oParamDiag.ParamDiagCalc833.limite8332)
        Assert.AreEqual("11,5", oParamDiag.ParamDiagCalc833.limite8333)

        oParamDiag = lst(1)
        Assert.AreEqual("Arbres", oParamDiag.libelle)
        oParamDiag = lst(2)
        Assert.AreEqual("Vignes", oParamDiag.libelle)

    End Sub
    ''' <summary>
    ''' Ce test vérifier le chargement correct du fichier de paramétrage
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()>
    <Ignore()>
    Public Sub testLoad()

        Dim oParamDiag As ParamDiag
        Dim lst As List(Of ParamDiag)

        lst = New List(Of ParamDiag)
        lst = ParamDiag.readXML()
        Assert.AreEqual(3, lst.Count)

        oParamDiag = lst(0)
        Assert.AreEqual("Cultures basses", oParamDiag.libelle)
        oParamDiag = lst(1)
        Assert.AreEqual("Arbres", oParamDiag.libelle)
        oParamDiag = lst(2)
        Assert.AreEqual("Vignes", oParamDiag.libelle)

    End Sub
    <TestMethod()>
    Public Sub testconvertCode()

        Dim oParamactrl As New CRODIP_ControlLibrary.ParamCtrlDiag()

        Assert.AreEqual("1.1.3.1", CRODIP_ControlLibrary.ParamCtrlDiag.ConvertCode("1131"))
        Assert.AreEqual("11.3.1.0", CRODIP_ControlLibrary.ParamCtrlDiag.ConvertCode("11310"))
        Assert.AreEqual("1.2.3.1", CRODIP_ControlLibrary.ParamCtrlDiag.ConvertCode("1231"))
        Assert.AreEqual("12.3.1.0", CRODIP_ControlLibrary.ParamCtrlDiag.ConvertCode("12310"))
        Assert.AreEqual("5.3.1.1", CRODIP_ControlLibrary.ParamCtrlDiag.ConvertCode("5311"))
    End Sub

    <TestMethod()>
    Public Sub testNiveau()

        Dim oParamactrl As New CRODIP_ControlLibrary.ParamCtrlDiag()
        oParamactrl.Code = "1"
        Assert.AreEqual(1, oParamactrl.Niveau)
        oParamactrl.Code = "1.1"
        Assert.AreEqual(2, oParamactrl.Niveau)
        oParamactrl.Code = "1.1.1"
        Assert.AreEqual(3, oParamactrl.Niveau)
        oParamactrl.Code = "1.1.1.1"
        Assert.AreEqual(4, oParamactrl.Niveau)

    End Sub
    <TestMethod()>
    Public Sub testgetlstHierarchique()

        Dim oLst As New CRODIP_ControlLibrary.LstParamCtrlDiag
        Dim oParamactrl As New CRODIP_ControlLibrary.ParamCtrlDiag()
        oParamactrl.Code = "1"
        oLst.ListeParam.Add(oParamactrl)
        oParamactrl = New CRODIP_ControlLibrary.ParamCtrlDiag()
        oParamactrl.Code = "1.1"
        oLst.ListeParam.Add(oParamactrl)
        oParamactrl = New CRODIP_ControlLibrary.ParamCtrlDiag()
        oParamactrl.Code = "1.2"
        oLst.ListeParam.Add(oParamactrl)
        oParamactrl = New CRODIP_ControlLibrary.ParamCtrlDiag()
        oParamactrl.Code = "1.2.1"
        oLst.ListeParam.Add(oParamactrl)
        oParamactrl = New CRODIP_ControlLibrary.ParamCtrlDiag()
        oParamactrl.Code = "1.2.1.1"
        oLst.ListeParam.Add(oParamactrl)
        oParamactrl = New CRODIP_ControlLibrary.ParamCtrlDiag()
        oParamactrl.Code = "1.2.1.2"
        oLst.ListeParam.Add(oParamactrl)
        oParamactrl = New CRODIP_ControlLibrary.ParamCtrlDiag()
        oParamactrl.Code = "1.2.2"
        oLst.ListeParam.Add(oParamactrl)
        oParamactrl = New CRODIP_ControlLibrary.ParamCtrlDiag()
        oParamactrl.Code = "2"
        oLst.ListeParam.Add(oParamactrl)
        oParamactrl = New CRODIP_ControlLibrary.ParamCtrlDiag()
        oParamactrl.Code = "1.3"
        oLst.ListeParam.Add(oParamactrl)
        oParamactrl = New CRODIP_ControlLibrary.ParamCtrlDiag()
        oParamactrl.Code = "2.1"
        oLst.ListeParam.Add(oParamactrl)

        Dim olstH As List(Of ParamCtrlDiag)
        olstH = oLst.getListeHierachique
        Assert.IsNotNull(olstH)
        'Nomre de niveau 1
        Assert.AreEqual(2, olstH.Count)
        For Each oParamactrl In olstH
            Assert.AreEqual(1, oParamactrl.Niveau)
        Next
        'Récupération du premier niveau
        oParamactrl = olstH(0)
        Assert.AreEqual("1", oParamactrl.Code)
        'Vérification du niveau 2
        Assert.AreEqual(3, oParamactrl.lstSubNodes.Count)
        For Each oParam As ParamCtrlDiag In oParamactrl.lstSubNodes
            Assert.AreEqual(2, oParam.Niveau)
            Assert.IsTrue(oParam.Code.StartsWith("1."))
        Next
        'Récupération du  niveau 2
        oParamactrl = oParamactrl.lstSubNodes(1)
        Assert.AreEqual("1.2", oParamactrl.Code)
        'Vérification du niveau 3
        Assert.AreEqual(2, oParamactrl.lstSubNodes.Count)
        For Each oParam As ParamCtrlDiag In oParamactrl.lstSubNodes
            Assert.AreEqual(3, oParam.Niveau)
            Assert.IsTrue(oParam.Code.StartsWith("1.2"))
        Next
        'Récupération du  niveau 3
        oParamactrl = oParamactrl.lstSubNodes(0)
        Assert.AreEqual("1.2.1", oParamactrl.Code)
        'Vérification du niveau 4
        Assert.AreEqual(2, oParamactrl.lstSubNodes.Count)
        For Each oParam As ParamCtrlDiag In oParamactrl.lstSubNodes
            Assert.AreEqual(4, oParam.Niveau)
            Assert.IsTrue(oParam.Code.StartsWith("1.2.1"))
        Next
        'Récupération du  niveau 4
        Dim oParam2 As ParamCtrlDiag
        oParam2 = oParamactrl.lstSubNodes(0)
        Assert.AreEqual("1.2.1.1", oParam2.Code)
        Assert.AreEqual(0, oParam2.lstSubNodes.Count)

        oParam2 = oParamactrl.lstSubNodes(1)
        Assert.AreEqual("1.2.1.2", oParam2.Code)
        Assert.AreEqual(0, oParam2.lstSubNodes.Count)
    End Sub
    <TestMethod()>
    Public Sub testgetNiveauInf()

        Dim oLst As New CRODIP_ControlLibrary.LstParamCtrlDiag
        Dim oParamactrl As New CRODIP_ControlLibrary.ParamCtrlDiag()
        oParamactrl.Code = "1"
        oLst.ListeParam.Add(oParamactrl)
        oParamactrl = New CRODIP_ControlLibrary.ParamCtrlDiag()
        oParamactrl.Code = "1.1"
        oLst.ListeParam.Add(oParamactrl)
        oParamactrl = New CRODIP_ControlLibrary.ParamCtrlDiag()
        oParamactrl.Code = "1.2"
        oLst.ListeParam.Add(oParamactrl)
        oParamactrl = New CRODIP_ControlLibrary.ParamCtrlDiag()
        oParamactrl.Code = "1.2.1"
        oLst.ListeParam.Add(oParamactrl)
        oParamactrl = New CRODIP_ControlLibrary.ParamCtrlDiag()
        oParamactrl.Code = "2"
        oLst.ListeParam.Add(oParamactrl)
        oParamactrl = New CRODIP_ControlLibrary.ParamCtrlDiag()
        oParamactrl.Code = "1.3"
        oLst.ListeParam.Add(oParamactrl)
        oParamactrl = New CRODIP_ControlLibrary.ParamCtrlDiag()
        oParamactrl.Code = "2.1"
        oLst.ListeParam.Add(oParamactrl)

        Dim olstinf As List(Of ParamCtrlDiag)
        olstinf = oLst.getNiveauInf("1")
        Assert.IsNotNull(olstinf)
        Assert.AreEqual(3, olstinf.Count)
        olstinf = oLst.getNiveauInf("1.1")
        Assert.IsNotNull(olstinf)
        Assert.AreEqual(0, olstinf.Count)
        olstinf = oLst.getNiveauInf("1.2")
        Assert.IsNotNull(olstinf)
        Assert.AreEqual(1, olstinf.Count)
        olstinf = oLst.getNiveauInf("2")
        Assert.IsNotNull(olstinf)
        Assert.AreEqual(1, olstinf.Count)

        olstinf = oLst.getNiveauInf("")
        Assert.IsNotNull(olstinf)
        Assert.AreEqual(2, olstinf.Count)
        For Each oParamactrl In olstinf
            Assert.AreEqual(1, oParamactrl.Niveau)
        Next


    End Sub

End Class
