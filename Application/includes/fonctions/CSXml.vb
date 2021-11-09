Imports System.Xml
Imports System.Xml.XPath

Public Class CSXml
    Implements IDisposable

    'Le nom du fichier xml sur lequel on travaillera
    Private m_Nomfichier As String

    Public Sub New(ByVal pNomFichier As String)
        If System.IO.File.Exists(pNomFichier) Then
            m_Nomfichier = pNomFichier
        Else
            '' on cr�e le fichier
            'Try

            '    Dim objFichier As New System.IO.FileStream(pNomFichier, IO.FileMode.Create, IO.FileAccess.Write)
            '    m_Nomfichier = pNomFichier
            '    m_Nomfichier = ""
            'Catch ex As Exception

            'End Try
        End If
    End Sub

    Public Sub New()
        m_Nomfichier = ""
    End Sub

    Public Property Nomfichier() As String
        Get
            Return m_Nomfichier
        End Get
        Set(ByVal Value As String)
            m_Nomfichier = Value
        End Set
    End Property

    Public Function getElementValue(ByVal path As String) As String

        'declarations
        Dim valeur As String = ""

        Try
            'on charge le fchier xml
            Dim doc As New XmlDocument
            doc.Load(m_Nomfichier)

            'r�cup�re la valeur du premier �l�ment
            valeur = doc.SelectSingleNode(path).FirstChild.InnerText()
            'lib�re les ressources
            doc = Nothing
        Catch e As Exception
            'en cas d'erreur
            'CSDebug.dispFatal("CSXml::getElementValue : " & e.Message)
            valeur = "error"
        End Try

        Return valeur

    End Function

    Public Function getElementValue(ByVal path As String, ByVal position As Integer) As String

        'declarations
        Dim valeur As String = ""

        Try
            'on charge le fchier xml
            Dim doc As New XmlDocument
            doc.Load(m_Nomfichier)

            'r�cup�re la valeur du premier �l�ment
            valeur = doc.SelectNodes(path).ItemOf(position).FirstChild.InnerText()
            'lib�re les ressources
            doc = Nothing
        Catch e As Exception
            'en cas d'erreur
            CSDebug.dispError("CSXml::getElementValue : " & e.Message)
            valeur = "error"
        End Try

        Return valeur

    End Function

    Public Function getXmlNode(ByVal path As String) As System.Xml.XmlNode

        'declarations
        Dim node As System.Xml.XmlNode = Nothing
        Try
            'on charge le fchier xml
            Dim doc As New XmlDocument()
            doc.Load(m_Nomfichier)
            'r�cup�re la valeur du noeud
            node = doc.SelectSingleNode(path)
            'lib�re les ressources
            doc = Nothing
        Catch e As Exception
            'en cas d'erreur
            CSDebug.dispError("CSXml::getXmlNode : " & e.Message)
        End Try

        Return node

    End Function
    Public Function getXmlNodes(ByVal path As String) As System.Xml.XmlNodeList

        'declarations
        Dim nodes As System.Xml.XmlNodeList = Nothing
        Try
            'on charge le fchier xml
            Dim doc As New XmlDocument
            doc.Load(m_Nomfichier)
            'r�cup�re la valeur du noeud
            nodes = doc.SelectNodes(path)
            'lib�re les ressources
            doc = Nothing
        Catch e As Exception
            'en cas d'erreur
            CSDebug.dispError("CSXml::getXmlNode : " & e.Message)
        End Try

        Return nodes

    End Function

    Public Sub setElementValue(ByVal path As String, ByVal valeur As String)

        Try

            'charge le fichier xml
            Dim doc As New XmlDocument
            doc.Load(m_Nomfichier)

            'd�finit la node
            Dim node As XmlNode = doc.SelectSingleNode(path)
            If node Is Nothing Then
                Dim parentPath As String
                Dim nodeName As String

                parentPath = Left(path, path.LastIndexOf("/"))
                nodeName = path.Substring(path.LastIndexOf("/") + 1)
                addElement(parentPath, nodeName, valeur)
            Else
                'definit la racine de l'element a modifier
                Dim parent As XmlNode = doc.SelectSingleNode(path).ParentNode


                'Si le noeud a des enfants alors il faut sauver les enfants
                If node.HasChildNodes Then

                    'creation d'un nouvel element
                    Dim clone As XmlElement = doc.CreateElement(node.Name)

                    'on lui assigne la nouvelle valeur
                    clone.InnerText = valeur

                    'copie des enfants du noeud dans le nouvel element
                    Dim child As XmlNode
                    For Each child In node.ChildNodes
                        If child.GetType.ToString <> "System.Xml.XmlText" Then
                            clone.AppendChild(child.Clone())
                        End If
                        parent.ReplaceChild(clone, node)
                        node = clone
                    Next
                Else  'sinon on change juste la valeur

                    'creation d'un nouvel element
                    Dim elem As XmlElement = doc.CreateElement(node.Name)

                    'on lui assigne la nouvelle valeur
                    elem.InnerText = valeur

                    'on remplace par la nouvelle node
                    parent.ReplaceChild(elem, node)
                End If
                'Sauve les modifications
                doc.Save(m_Nomfichier)
            End If

            doc = Nothing

        Catch e As Exception

            CSDebug.dispError("setSettings <> Erreur dans la modification de " & m_Nomfichier & " : " & e.Message)

        End Try

    End Sub

    Public Sub setElementValue(ByVal path As String, ByVal valeur As String, ByVal position As Integer)

        Try

            'charge le fichier xml
            Dim doc As New XmlDocument
            doc.Load(m_Nomfichier)

            'definit la racine de l'element a modifier
            Dim parent As XmlNode = doc.SelectNodes(path).ItemOf(position).ParentNode

            'd�finit la node
            Dim node As XmlNode = doc.SelectNodes(path).ItemOf(position)

            'Si le noeud a des enfants alors il faut sauver les enfants
            If node.HasChildNodes Then

                'creation d'un nouvel element
                Dim clone As XmlElement = doc.CreateElement(node.Name)

                'on lui assigne la nouvelle valeur
                clone.InnerText = valeur

                'copie des enfants du noeud dans le nouvel element
                Dim child As XmlNode
                For Each child In node.ChildNodes
                    If child.GetType.ToString <> "System.Xml.XmlText" Then
                        clone.AppendChild(child.Clone())
                    End If
                    parent.ReplaceChild(clone, node)
                    node = clone
                Next
            Else  'sinon on change juste la valeur

                'creation d'un nouvel element
                Dim elem As XmlElement = doc.CreateElement(node.Name)

                'on lui assigne la nouvelle valeur
                elem.InnerText = valeur

                'on remplace par la nouvelle node
                parent.ReplaceChild(elem, node)
            End If

            'Sauve les modifications
            doc.Save(m_Nomfichier)

            doc = Nothing

        Catch e As Exception

            CSDebug.dispError("setSettings <> Erreur dans la modification de " & m_Nomfichier & " : " & e.Message)

        End Try

    End Sub

    Private Sub addElement(ByVal path As String, ByVal nom As String, ByVal valeur As String)

        Try
            'charge le fichier xml
            Dim doc As New XmlDocument
            doc.Load(m_Nomfichier)

            'selectionne le noeud parent de l'�l�ment � ajouter
            Dim root As XmlNode = doc.SelectSingleNode(path)

            'cr�ation du nouvel �l�ment
            Dim elem As XmlElement = doc.CreateElement(nom)

            'on lui assigne une valeur
            elem.InnerText = valeur

            'puis on l'ajoute au noeud parent
            root.AppendChild(elem)

            'on sauvegarde
            doc.Save(m_Nomfichier)

        Catch e As Exception
            CSDebug.dispError("Erreur dans la cr�ation de l'�l�ment : " & e.Message)
        End Try

    End Sub

    Public Sub addElement(ByVal path As String, ByVal nom As String, ByVal valeur As String, ByVal position As Integer)

        Try
            'charge le fichier xml
            Dim doc As New XmlDocument
            doc.Load(m_Nomfichier)

            'selectionne le noeud parent de l'�l�ment � ajouter
            Dim root As XmlNode = doc.SelectNodes(path).ItemOf(position)

            'cr�ation du nouvel �l�ment
            Dim elem As XmlElement = doc.CreateElement(nom)

            'on lui assigne une valeur
            elem.InnerText = valeur

            'puis on l'ajoute au noeud parent
            root.AppendChild(elem)

            'on sauvegarde
            doc.Save(m_Nomfichier)

        Catch e As Exception
            CSDebug.dispError("Erreur dans la cr�ation de l'�l�ment : " & e.Message)
        End Try

    End Sub

    Public Sub deleteElement(ByVal path As String, ByVal nom As String)

        Try
            'charge le fichier xml
            Dim doc As New XmlDocument
            doc.Load(m_Nomfichier)

            'selectionne le noeud parent de l'�l�ment � supprimer
            Dim root As XmlNode = doc.SelectSingleNode(path)

            'selectionne l'�l�ment � supprimer
            Dim elem As XmlElement = doc.SelectSingleNode(path & "/" & nom)

            'supprime l'�l�ment
            root.RemoveChild(elem)

            'sauvegarde
            doc.Save(m_Nomfichier)

        Catch e As Exception
            CSDebug.dispError("Erreur dans la suppression de l'�l�ment : " & e.Message)
        End Try
    End Sub

    Public Sub deleteElement(ByVal path As String, ByVal nom As String, ByVal position As Integer)

        Try
            'charge le fichier xml
            Dim doc As New XmlDocument
            doc.Load(m_Nomfichier)

            'selectionne le noeud parent de l'�l�ment � supprimer
            Dim root As XmlNode = doc.SelectSingleNode(path)

            'selectionne l'�l�ment � supprimer
            Dim elem As XmlElement = doc.SelectNodes(path & "/" & nom).ItemOf(position)

            'supprime l'�l�ment
            root.RemoveChild(elem)

            'sauvegarde
            doc.Save(m_Nomfichier)

        Catch e As Exception
            CSDebug.dispError("Erreur dans la suppression de l'�l�ment : " & e.Message)
        End Try
    End Sub

    Public Sub addAttribute(ByVal path As String, ByVal nom As String, ByVal valeur As String)

        Try
            'charge le fichier xml
            Dim doc As New XmlDocument
            doc.Load(m_Nomfichier)

            'declaration de l'�l�ment auquel on ajoutera un attribut et de l'attribut en question
            Dim root As XmlNode = doc.SelectSingleNode(path)
            Dim attrib As XmlAttribute = doc.CreateAttribute(nom)

            'on valorise l'attribut
            attrib.InnerText = valeur

            'on ajoute l'attribut � l'�l�ment
            root.Attributes.Append(attrib)

            'et on sauvegarde
            doc.Save(m_Nomfichier)

        Catch e As Exception
            CSDebug.dispError("Erreur dans la cr�ation de l'attribut : " & e.Message)
        End Try

    End Sub

    Public Sub addAttribute(ByVal path As String, ByVal nom As String, ByVal valeur As String, ByVal position As Integer)

        Try
            'charge le fichier xml
            Dim doc As New XmlDocument
            doc.Load(m_Nomfichier)

            'declaration de l'�l�ment auquel on ajoutera un attribut et de l'attribut en question
            Dim root As XmlNodeList = doc.SelectNodes(path)
            Dim attrib As XmlAttribute = doc.CreateAttribute(nom)

            'on valorise l'attribut
            attrib.InnerText = valeur

            'on ajoute l'attribut � l'�l�ment
            root.ItemOf(position).Attributes.Append(attrib)

            'et on sauvegarde
            doc.Save(m_Nomfichier)

        Catch e As Exception
            CSDebug.dispError("Erreur dans la cr�ation de l'attribut : " & e.Message)
        End Try

    End Sub

    Public Sub setAttribute(ByVal path As String, ByVal nom As String, ByVal valeur As String)

        Try
            'on charge le fichier xml
            Dim doc As New XmlDocument
            doc.Load(m_Nomfichier)

            'd�clarations
            Dim root As XmlNode = doc.SelectSingleNode(path)
            Dim attrib As XmlAttribute = doc.CreateAttribute(nom)

            'valorisation de l'attribut
            attrib.InnerText = valeur

            'ajout de l'attribut � l'�l�ment
            root.Attributes.Append(attrib)

            'sauvegarde
            doc.Save(m_Nomfichier)

        Catch e As Exception
            CSDebug.dispError("Erreur dans la modification de l'attribut : " & e.Message)
        End Try

    End Sub

    Public Sub setAttribute(ByVal path As String, ByVal nom As String, ByVal valeur As String, ByVal position As Integer)

        Try
            'on charge le fichier xml
            Dim doc As New XmlDocument
            doc.Load(m_Nomfichier)

            'd�clarations
            Dim root As XmlNode = doc.SelectNodes(path).ItemOf(position)
            Dim attrib As XmlAttribute = doc.CreateAttribute(nom)

            'valorisation de l'attribut
            attrib.InnerText = valeur

            'ajout de l'attribut � l'�l�ment
            root.Attributes.Append(attrib)

            'sauvegarde
            doc.Save(m_Nomfichier)

        Catch e As Exception
            CSDebug.dispError("Erreur dans la modification de l'attribut : " & e.Message)
        End Try

    End Sub

    Public Function getAttribute(ByVal path As String, ByVal nom As String) As String

        Dim valeur As String = ""
        Try
            'charge le fichier xml
            Dim doc As New XmlDocument
            doc.Load(m_Nomfichier)

            'declarations
            Dim root As XmlNode = doc.SelectSingleNode(path)
            Dim attrib As XmlAttribute = root.Attributes.GetNamedItem(nom)

            'r�cup�ration de la valeur de l'attribut
            valeur = attrib.InnerText()

        Catch e As Exception
            CSDebug.dispError("Erreur dans le retour de l'attribut : " & e.Message)
        End Try

        Return valeur

    End Function

    Public Function getAttribute(ByVal path As String, ByVal nom As String, ByVal position As Integer) As String

        Dim valeur As String = ""
        Try
            'charge le fichier xml
            Dim doc As New XmlDocument
            doc.Load(m_Nomfichier)

            'declarations
            Dim root As XmlNode = doc.SelectNodes(path).ItemOf(position)
            Dim attrib As XmlAttribute = root.Attributes.GetNamedItem(nom)

            'r�cup�ration de la valeur de l'attribut
            valeur = attrib.InnerText()

        Catch e As Exception
            CSDebug.dispError("Erreur dans le retour de l'attribut : " & e.Message)
        End Try

        'retourne la valeur de l'attribut
        Return valeur

    End Function

    Public Sub createRoot(ByVal nom As String)

        Try
            'd�clare un nouveau document xml
            Dim doc As New XmlDocument

            'lui ajoute son ent�te et la balise racine
            doc.LoadXml("<?xml version='1.0' encoding='ISO-8859-1'?>" &
                         "<" & nom & ">" &
                         "</" & nom & ">")

            'sauvegarde les modifications
            doc.Save(m_Nomfichier)

        Catch e As Exception
            CSDebug.dispError("Erreur dans la cr�ation de la racine : " & e.Message)
        End Try
    End Sub

    Public Sub createNewFile(ByVal nomFichier As String)

        Try
            'creation d'un nouveau fichier
            System.IO.File.Create(nomFichier)
        Catch e As Exception
            CSDebug.dispError("Erreur dans la cr�ation du fichier : " & e.Message)
        End Try
    End Sub

    Public Function getFormatedXMLString() As String

        'charge le fichier xml
        Dim doc As New XmlDocument
        doc.Load(m_Nomfichier)

        'retourne le contenu int�gral du fichier dans une chaine
        Return (doc.OuterXml).Replace("><", ">" & vbNewLine & "<")

    End Function


    Public Function getIndexOfElement(ByVal path As String, ByVal valeur As String) As Integer
        Dim num As Integer = -1
        Try
            'charge le fichier xml
            Dim doc As New XmlDocument
            doc.Load(m_Nomfichier)

            'd�clarations
            Dim nodes As XmlNodeList = doc.SelectNodes(path)
            Dim nod As XmlElement
            Dim trouve As Boolean = False

            'recherche de l'�l�ment
            For Each nod In nodes
                num = num + 1
                'si la valeur de l'�l�ment correspond � la valeur cherch�e alors
                If nod.InnerText = valeur Then
                    trouve = True
                    Exit For
                End If
            Next

            'si non trouv� num <-- -1
            If Not trouve Then num = -1

            'on retourne la position
        Catch e As Exception
            CSDebug.dispError("Erreur de retour de l'index : " & e.Message)
        End Try
        Return num
    End Function

    Public Function countElements(ByVal path As String) As Integer

        Dim nb As Integer = 0
        Try
            'Charge le fichier xml
            Dim doc As New XmlDocument
            doc.Load(m_Nomfichier)

            'Compte les �l�ments correspondants au chemin
            nb = doc.SelectNodes(path).Count

        Catch e As Exception
            CSDebug.dispError("Erreur dans le comptage des �l�ments : " & e.Message)
            nb = -1
        End Try

        'retourne la valeur
        Return nb

    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean ' Pour d�tecter les appels redondants

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: supprimer l'�tat manag� (objets manag�s).
            End If

            ' TODO: lib�rer les ressources non manag�es (objets non manag�s) et remplacer Finalize() ci-dessous.
            ' TODO: d�finir les champs de grande taille avec la valeur Null.
        End If
        disposedValue = True
    End Sub

    ' TODO: remplacer Finalize() seulement si la fonction Dispose(disposing As Boolean) ci-dessus a du code pour lib�rer les ressources non manag�es.
    'Protected Overrides Sub Finalize()
    '    ' Ne modifiez pas ce code. Placez le code de nettoyage dans Dispose(disposing As Boolean) ci-dessus.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' Ce code est ajout� par Visual Basic pour impl�menter correctement le mod�le supprimable.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Ne modifiez pas ce code. Placez le code de nettoyage dans Dispose(disposing As Boolean) ci-dessus.
        Dispose(True)
        ' TODO: supprimer les marques de commentaire pour la ligne suivante si Finalize() est remplac� ci-dessus.
        ' GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
