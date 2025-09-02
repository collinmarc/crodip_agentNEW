'doc thechnique
'--------------
La Form Principale utilise un timer pour lire les donnée dans le gpsManager
en fonction de l'état on utiliser différents HAndler
GPS_RecherchePortSerie
GPS_AttenteVitesseStable
GPS_RecupDonnees

le timer est armé et désarmé par la machine à etat

la methode GPE_RECUPDonnees va lire les donnée dans le GPSManager à intervalles Reguliers
S'il y a eu des modifications (bDataUpdated)

La classe GPSMAnager fait l'interface avec l'antenne
pour pallier l'incertitude de l'antenne, on convertit les coordonnées reçues en decimales et on prend la moyenne des x dernières mesures 


BUILD 20250404160000
	CRODIPGPS : Prendre l'espace temps sur la trame GPS
BUILD 20250828180000
		0001821: CRODIPGPS : Amélioration de la précision
		0001820: CRODIPGPS : Améliorations