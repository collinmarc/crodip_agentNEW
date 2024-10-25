Imports CRODIPWS
Public Class MarquesManager
    Public Const XPATH_MARQUES_PULVE As String = "/root/marque/libelle"
    Public Const XPATH_MODELES_PULVE As String = "/root/marque[libelle=""%marque%""]/modeles/modele"
    Public Const XPATH_TYPES_PULVE As String = "/root/type/libelle"
    Public Const XPATH_CATEGORIES_PULVE As String = "/root/type[libelle=""%type%""]/categories/categorie/text()"
    Public Const XPATH_TYPEVALEUR_PULVE As String = "/root/type[libelle=""%type%""]/categories/categorie[text()=""%categorie%""]/@typevaleur"
    Public Const XPATH_VALEURS_PULVE As String = "/root/type[libelle=""%type%""]/categories/categorie[text()=""%categorie%""]/@valeurs"
    Public Const XPATH_VALEURS_ATTELAGE As String = "/root/type[libelle=""%type%""]/attelages/@valeurs"
    Public Const XPATH_VALEURS_TRTSPE As String = "/root/type[libelle=""%type%""]/categories/categorie[text()=""%categorie%""]/@TRTSPE"
    Public Shared Sub populateCombobox_Largeur_NbRangs_Pulve(ByVal pControl As Object, pType As String, pCategorie As String)
        Try
            Dim xpath As String
            Dim strValeurs As String()
            Dim oCbx As ComboBox
            oCbx = CType(pControl, ComboBox)
            oCbx.Items.Clear()
            xpath = XPATH_VALEURS_PULVE.Replace("%type%", pType)
            xpath = xpath.Replace("%categorie%", pCategorie)
            Dim oNodes As Xml.XmlNodeList = GlobalsCRODIP.GLOB_XML_TYPES_CATEGORIES_PULVE.getXmlNodes(xpath)
            For Each oNode As Xml.XmlNode In oNodes
                strValeurs = oNode.InnerText().Split("|")
                For Each Str As String In strValeurs
                    'Controle du format numérique (99,99)
                    Str = Str.Replace(".", Application.CurrentCulture.NumberFormat.NumberDecimalSeparator)
                    If IsNumeric(Str) Then
                        Str = CType(Str, Decimal).ToString("##0.##")
                        Str = Str.Replace(Application.CurrentCulture.NumberFormat.NumberDecimalSeparator, ".")
                    End If
                    oCbx.Items.Add(Str)
                Next Str
            Next oNode
        Catch ex As Exception
            CSDebug.dispError("populateCombobox_CategoriesPulve : " & ex.Message)
        End Try

    End Sub
    Public Shared Sub populateCombobox_Attelage_Pulve(ByVal pControl As Object, pType As String)
        Try
            Dim xpath As String
            Dim strValeurs As String()
            Dim oCbx As ComboBox
            oCbx = CType(pControl, ComboBox)
            oCbx.Items.Clear()
            xpath = XPATH_VALEURS_ATTELAGE.Replace("%type%", pType)
            Dim oNodes As Xml.XmlNodeList = GlobalsCRODIP.GLOB_XML_TYPES_CATEGORIES_PULVE.getXmlNodes(xpath)
            For Each oNode As Xml.XmlNode In oNodes
                strValeurs = oNode.InnerText().Split("|")
                For Each Str As String In strValeurs
                    oCbx.Items.Add(Str)
                Next Str
            Next oNode
        Catch ex As Exception
            CSDebug.dispError("populateCombobox_Attelage_Pulve : " & ex.Message)
        End Try

    End Sub 'populateCombobox_Attelage_Pulve
    ''' <summary>
    ''' Rend le type de valeur associé au type et à la catégorie de pulvérisateur
    ''' </summary>
    ''' <param name="pType">Type de Pulvé</param>
    ''' <param name="pCategorie">Catégorie</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetTypeValeur_Pulve(pType As String, pCategorie As String) As String
        Dim strReturn As String
        Try
            strReturn = ""
            Dim xpath As String
            xpath = XPATH_TYPEVALEUR_PULVE.Replace("%type%", pType)
            xpath = xpath.Replace("%categorie%", pCategorie)
            Dim oNodes As Xml.XmlNodeList = GlobalsCRODIP.GLOB_XML_TYPES_CATEGORIES_PULVE.getXmlNodes(xpath)
            For Each oNode As Xml.XmlNode In oNodes
                strReturn = oNode.InnerText
            Next

        Catch ex As Exception
            CSDebug.dispError("GetTypeValeur_Pulve : " & ex.Message)
            strReturn = "...."
        End Try
        Return strReturn
    End Function
    Public Shared Sub populateCombobox_CategoriesPulve(ByVal pControl As Object, pType As String, Optional bClear As Boolean = True)

        '#################################################################################
        '########                    Chargement des marques                       ########
        '#################################################################################
        Try
            Dim xpath As String
            xpath = XPATH_CATEGORIES_PULVE.Replace("%type%", pType)
            populateCombobox_xpath(GlobalsCRODIP.GLOB_XML_TYPES_CATEGORIES_PULVE, pControl, xpath, bClear)
        Catch ex As Exception
            CSDebug.dispError("populateCombobox_CategoriesPulve : " & ex.Message)
        End Try

    End Sub
    Public Shared Sub populateCombobox_TypesPulve(ByVal pControl As Object, Optional bClear As Boolean = True)

        '#################################################################################
        '########                    Chargement des marques                       ########
        '#################################################################################
        Try
            populateCombobox_xpath(GlobalsCRODIP.GLOB_XML_TYPES_CATEGORIES_PULVE, pControl, XPATH_TYPES_PULVE, bClear)
        Catch ex As Exception
            CSDebug.dispError("populateCombobox_TypesPulve : " & ex.Message)
        End Try

    End Sub
    Public Shared Sub populateCombobox_ModelesPulve(ByVal pControl As Object, pMarque As String, Optional bClear As Boolean = True)

        '#################################################################################
        '########                    Chargement des marques                       ########
        '#################################################################################
        Try
            Dim xpath As String
            xpath = XPATH_MODELES_PULVE.Replace("%marque%", pMarque)
            populateCombobox_xpath(GlobalsCRODIP.GLOB_XML_MARQUES_MODELES_PULVE, pControl, xpath, bClear)
        Catch ex As Exception
            CSDebug.dispError("populateCombobox_ModelesPulve : " & ex.Message)
        End Try

    End Sub
    Public Shared Sub populateCombobox_MarquesPulve(ByVal pControl As Object, Optional bClear As Boolean = True)

        '#################################################################################
        '########                    Chargement des marques                       ########
        '#################################################################################
        Try
            populateCombobox_xpath(GlobalsCRODIP.GLOB_XML_MARQUES_MODELES_PULVE, pControl, XPATH_MARQUES_PULVE, bClear)
        Catch ex As Exception
            CSDebug.dispError("populateCombobox_MarquesPulve : " & ex.Message)
        End Try

    End Sub
    ''' <summary>
    ''' initialisation de la combobox du fonctionnement des buses en fonctiondu type de buses
    ''' </summary>
    ''' <param name="pControl"></param>
    ''' <param name="pTypeBuse"></param>
    ''' <param name="bClear"></param>
    ''' <remarks></remarks>
    Public Shared Sub populateCombobox_xpath(ByVal xmlFile As CSXml, ByVal pControl As Object, pXPath As String, Optional bClear As Boolean = True)

        '#################################################################################
        '########                    Chargement des marques                       ########
        '#################################################################################
        Try

            Dim oNodes As Xml.XmlNodeList = xmlFile.getXmlNodes(pXPath)
            Dim oCbx As ComboBox
            oCbx = CType(pControl, ComboBox)
            If bClear Then
                oCbx.Items.Clear()
            End If
            For Each oNode As Xml.XmlNode In oNodes
                oCbx.Items.Add(oNode.InnerText)
            Next
        Catch ex As Exception
            CSDebug.dispError("MarquesManager.populateCombobox_1 : " & ex.Message)
        End Try

    End Sub

    Public Shared Sub populateCombobox(ByVal xmlFile As CSXml, ByVal arrMCMarquesControls As Object)
        populateCombobox(xmlFile, arrMCMarquesControls, "/root")
    End Sub

    Public Shared Sub populateCombobox(ByVal xmlFile As CSXml, ByVal arrMCMarquesControls As Object, ByVal rootNode As String, Optional ByVal bAutoComplete As Boolean = False)

        '#################################################################################
        '########                    Chargement des marques                       ########
        '#################################################################################
        Try

            Dim x As Xml.XmlNode = xmlFile.getXmlNode(rootNode)
            Dim y As Integer = x.ChildNodes.Count

            If arrMCMarquesControls.GetType.ToString = "System.Windows.Forms.ComboBox" Then
                Dim oCbx As ComboBox
                oCbx = CType(arrMCMarquesControls, ComboBox)
                'oCbx.Sorted = True
                For i As Integer = 0 To y - 1
                    arrMCMarquesControls.Items.Add(x.ChildNodes.Item(i).Item("libelle").InnerText())
                Next
                If bAutoComplete Then
                    oCbx.AutoCompleteSource = AutoCompleteSource.ListItems
                    oCbx.AutoCompleteCustomSource.Clear()
                    For Each str As String In oCbx.Items
                        oCbx.AutoCompleteCustomSource.Add(str)
                    Next
                    oCbx.AutoCompleteMode = AutoCompleteMode.Suggest
                End If
            Else
                ReDim Preserve arrMCMarquesControls(arrMCMarquesControls.Length - 2)
                For Each controlToPopulate As ComboBox In arrMCMarquesControls
                    For i As Integer = 0 To y - 1
                        controlToPopulate.Items.Add(x.ChildNodes.Item(i).Item("libelle").InnerText())
                    Next
                Next
            End If
        Catch ex As Exception
            CSDebug.dispError("populateCombobox : " & ex.Message)
        End Try

    End Sub

End Class
