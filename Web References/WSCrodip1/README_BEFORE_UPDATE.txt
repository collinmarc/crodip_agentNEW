ATTENTION , En cas de Maj des WebServices , 

        'Il faut ajouter les XmlInclude(GetType(Classes_Utilis�e_dans_les_send)) 
		'dans le fichier REFERENCE.vb
        'Soit � la d�claration de la classe crodipserver, soit avant chaque send
        'Pas besoin de la d�clarer dans la classe elle-m�me , juste qu'elle soit Serializable
