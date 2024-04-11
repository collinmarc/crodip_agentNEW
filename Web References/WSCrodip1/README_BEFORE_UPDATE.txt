ATTENTION , En cas de Maj des WebServices , 

        'Il faut ajouter les XmlInclude(GetType(Classes_Utilisée_dans_les_send)) 
		'dans le fichier REFERENCE.vb
        'Soit à la déclaration de la classe crodipserver, soit avant chaque send
        'Pas besoin de la déclarer dans la classe elle-même , juste qu'elle soit Serializable
