# RC41 STEP3C FIX3.1

Correction du test FIX3 : le marqueur PowerShell contenant `$_` était placé dans une chaîne double-quoted et était interpolé pendant le test, provoquant un faux négatif « filtre dockerbuild absent ».

- test FIX3 rendu littéral pour le filtre `dockerbuild` ;
- expression régulière `.dockerbuild` normalisée dans la commande STEP3C ;
- aucune modification de la logique transactionnelle STEP3B ni des garanties FIX1/FIX2.
