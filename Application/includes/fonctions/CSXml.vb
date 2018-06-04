Imports System.Xml
Imports System.Xml.XPath

Public Class CSXml

    'Le nom du fichier xml sur lequel on travaillera
    Private m_Nomfichier As String

    Public Sub New(ByVal pNomFichier As String)
        If System.IO.File.Exists(pNomFichier) Then
            m_Nomfichier = pNomFichier
        Else
            '' on crée le fichier
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

            'récupère la valeur du premier élément
            valeur = doc.SelectSingleNode(path).FirstChild.InnerText()
            'libère les ressources
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

            'récupère la valeur du premier élément
            valeur = doc.SelectNodes(path).ItemOf(position).FirstChild.InnerText()
            'libère les ressources
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
            'récupère la valeur du noeud
            node = doc.SelectSingleNode(path)
            'libère les ressources
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
            'récupère la valeur du noeud
            nodes = doc.SelectNodes(path)
            'libère les ressources
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

            'definit la racine de l'element a modifier
            Dim parent As XmlNode = doc.SelectSingleNode(path).ParentNode

            'définit la node
            Dim node As XmlNode = doc.SelectSingleNode(path)

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

    Public Sub setElementValue(ByVal path As String, ByVal valeur As String, ByVal position As Integer)

        Try

            'charge le fichier xml
            Dim doc As New XmlDocument
            doc.Load(m_Nomfichier)

            'definit la racine de l'element a modifier
            Dim parent As XmlNode = doc.SelectNodes(path).ItemOf(position).ParentNode

            'définit la node
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

    Public Sub addElement(ByVal path As String, ByVal nom As String, ByVal valeur As String)

        Try
            'charge le fichier xml
            Dim doc As New XmlDocument
            doc.Load(m_Nomfichier)

            'selectionne le noeud parent de l'élément à ajouter
            Dim root As XmlNode = doc.SelectSingleNode(path)

            'création du nouvel élément
            Dim elem As XmlElement = doc.CreateElement(nom)

            'on lui assigne une valeur
            elem.InnerText = valeur

            'puis on l'ajoute au noeud parent
            root.AppendChild(elem)

            'on sauvegarde
            doc.Save(m_Nomfichier)

        Catch e As Exception
            CSDebug.dispError("Erreur dans la création de l'élément : " & e.Message)
        End Try

    End Sub

    Public Sub addElement(ByVal path As String, ByVal nom As String, ByVal valeur As String, ByVal position As Integer)

        Try
            'charge le fichier xml
            Dim doc As New XmlDocument
            doc.Load(m_Nomfichier)

            'selectionne le noeud parent de l'élément à ajouter
            Dim root As XmlNode = doc.SelectNodes(path).ItemOf(position)

            'création du nouvel élément
            Dim elem As XmlElement = doc.CreateElement(nom)

            'on lui assigne une valeur
            elem.InnerText = valeur

            'puis on l'ajoute au noeud parent
            root.AppendChild(elem)

            'on sauvegarde
            doc.Save(m_Nomfichier)

        Catch e As Exception
            CSDebug.dispError("Erreur dans la création de l'élément : " & e.Message)
        End Try

    End Sub

    Public Sub deleteElement(ByVal path As String, ByVal nom As String)

        Try
            'charge le fichier xml
            Dim doc As New XmlDocument
            doc.Load(m_Nomfichier)

            'selectionne le noeud parent de l'élément à supprimer
            Dim root As XmlNode = doc.SelectSingleNode(path)

            'selectionne l'élément à supprimer
            Dim elem As XmlElement = doc.SelectSingleNode(path & "/" & nom)

            'supprime l'élément
            root.RemoveChild(elem)

            'sauvegarde
            doc.Save(m_Nomfichier)

        Catch e As Exception
            CSDebug.dispError("Erreur dans la suppression de l'élément : " & e.Message)
        End Try
    End Sub

    Public Sub deleteElement(ByVal path As String, ByVal nom As String, ByVal position As Integer)

        Try
            'charge le fichier xml
            Dim doc As New XmlDocument
            doc.Load(m_Nomfichier)

            'selectionne le noeud parent de l'élément à supprimer
            Dim root As XmlNode = doc.SelectSingleNode(path)

            'selectionne l'élément à supprimer
            Dim elem As XmlElement = doc.SelectNodes(path & "/" & nom).ItemOf(position)

            'supprime l'élément
            root.RemoveChild(elem)

            'sauvegarde
            doc.Save(m_Nomfichier)

        Catch e As Exception
            CSDebug.dispError("Erreur dans la suppression de l'élément : " & e.Message)
        End Try
    End Sub

    Public Sub addAttribute(ByVal path As String, ByVal nom As String, ByVal valeur As String)

        Try
            'charge le fichier xml
            Dim doc As New XmlDocument
            doc.Load(m_Nomfichier)

            'declaration de l'élément auquel on ajoutera un attribut et de l'attribut en question
            Dim root As XmlNode = doc.SelectSingleNode(path)
            Dim attrib As XmlAttribute = doc.CreateAttribute(nom)

            'on valorise l'attribut
            attrib.InnerText = valeur

            'on ajoute l'attribut à l'élément
            root.Attributes.Append(attrib)

            'et on sauvegarde
            doc.Save(m_Nomfichier)

        Catch e As Exception
            CSDebug.dispError("Erreur dans la création de l'attribut : " & e.Message)
        End Try

    End Sub

    Public Sub addAttribute(ByVal path As String, ByVal nom As String, ByVal valeur As String, ByVal position As Integer)

        Try
            'charge le fichier xml
            Dim doc As New XmlDocument
            doc.Load(m_Nomfichier)

            'declaration de l'élément auquel on ajoutera un attribut et de l'attribut en question
            Dim root As XmlNodeList = doc.SelectNodes(path)
            Dim attrib As XmlAttribute = doc.CreateAttribute(nom)

            'on valorise l'attribut
            attrib.InnerText = valeur

            'on ajoute l'attribut à l'élément
            root.ItemOf(position).Attributes.Append(attrib)

            'et on sauvegarde
            doc.Save(m_Nomfichier)

        Catch e As Exception
            CSDebug.dispError("Erreur dans la création de l'attribut : " & e.Message)
        End Try

    End Sub

    Public Sub setAttribute(ByVal path As String, ByVal nom As String, ByVal valeur As String)

        Try
            'on charge le fichier xml
            Dim doc As New XmlDocument
            doc.Load(m_Nomfichier)

            'déclarations
            Dim root As XmlNode = doc.SelectSingleNode(path)
            Dim attrib As XmlAttribute = doc.CreateAttribute(nom)

            'valorisation de l'attribut
            attrib.InnerText = valeur

            'ajout de l'attribut à l'élément
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

            'déclarations
            Dim root As XmlNode = doc.SelectNodes(path).ItemOf(position)
            Dim attrib As XmlAttribute = doc.CreateAttribute(nom)

            'valorisation de l'attribut
            attrib.InnerText = valeur

            'ajout de l'attribut à l'élément
            root.Attributes.Append(attrib)

            'sauvegarde
            doc.Save(m_Nomfichier)

        Catch e As Exception
            CSDebug.dispError("Erreur dans la modification de l'attribut : " & e.Message)
        End Try

    End Sub

    Public Function getAttribute(ByVal path As String, ByVal nom As String) As String

        Dim valeur As String
        Try
            'charge le fichier xml
            Dim doc As New XmlDocument
            doc.Load(m_Nomfichier)

            'declarations
            Dim root As XmlNode = doc.SelectSingleNode(path)
            Dim attrib As XmlAttribute = root.Attributes.GetNamedItem(nom)

            'récupération de la valeur de l'attribut
            valeur = attrib.InnerText()

        Catch e As Exception
            CSDebug.dispError("Erreur dans le retour de l'attribut : " & e.Message)
        End Try

        Return valeur

    End Function

    Public Function getAttribute(ByVal path As String, ByVal nom As String, ByVal position As Integer) As String

        Dim valeur As String
        Try
            'charge le fichier xml
            Dim doc As New XmlDocument
            doc.Load(m_Nomfichier)

            'declarations
            Dim root As XmlNode = doc.SelectNodes(path).ItemOf(position)
            Dim attrib As XmlAttribute = root.Attributes.GetNamedItem(nom)

            'récupération de la valeur de l'attribut
            valeur = attrib.InnerText()

        Catch e As Exception
            CSDebug.dispError("Erreur dans le retour de l'attribut : " & e.Message)
        End Try

        'retourne la valeur de l'attribut
        Return valeur

    End Function

    Public Sub createRoot(ByVal nom As String)

        Try
            'déclare un nouveau document xml
            Dim doc As New XmlDocument

            'lui ajoute son entête et la balise racine
            doc.LoadXml("<?xml version='1.0' encoding='ISO-8859-1'?>" & _
                         "<" & nom & ">" & _
                         "</" & nom & ">")

            'sauvegarde les modifications
            doc.Save(m_Nomfichier)

        Catch e As Exception
            CSDebug.dispError("Erreur dans la création de la racine : " & e.Message)
        End Try
    End Sub

    Public Sub createNewFile(ByVal nomFichier As String)

        Try
            'creation d'un nouveau fichier
            System.IO.File.Create(nomFichier)
        Catch e As Exception
            CSDebug.dispError("Erreur dans la création du fichier : " & e.Message)
        End Try
    End Sub

    Public Function getFormatedXMLString() As String

        'charge le fichier xml
        Dim doc As New XmlDocument
        doc.Load(m_Nomfichier)

        'retourne le contenu intégral du fichier dans une chaine
        Return (doc.OuterXml).Replace("><", ">" & vbNewLine & "<")

    End Function


    Public Function getIndexOfElement(ByVal path As String, ByVal valeur As String) As Integer
        Dim num As Integer = -1
        Try
            'charge le fichier xml
            Dim doc As New XmlDocument
            doc.Load(m_Nomfichier)

            'déclarations
            Dim nodes As XmlNodeList = doc.SelectNodes(path)
            Dim nod As XmlElement
            Dim trouve As Boolean = False

            'recherche de l'élément
            For Each nod In nodes
                num = num + 1
                'si la valeur de l'élément correspond à la valeur cherchée alors
                If nod.InnerText = valeur Then
                    trouve = True
                    Exit For
                End If
            Next

            'si non trouvé num <-- -1
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

            'Compte les éléments correspondants au chemin
            nb = doc.SelectNodes(path).Count

        Catch e As Exception
            CSDebug.dispError("Erreur dans le comptage des éléments : " & e.Message)
            nb = -1
        End Try

        'retourne la valeur
        Return nb

    End Function

End Class
