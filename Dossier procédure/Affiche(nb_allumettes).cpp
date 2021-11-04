void Affiche(int nombre_allumettes) {
  // Le nombre de groupe de cinq allumettes et le reste de la division euclidienne par cinq sont des entiers
  int nbGroupeCinqAllumettes, resteDivisionEuclidienne;
  // La ligne représentant les allumettes et la ligne composée de cinq allumettes sont tout deux des chaines de caractères
  string ligneAllumettes, ligneCinqAllumettes = "! ! ! ! !";

  // Notre but est d'avoir le nombre de groupe de cinq allumettes
  // Nous allons donc faire la division euclidienne du nombre total d'Allumettes par 5 (pour obtenir le nombre d'allumettes ne faisant pas parti d'un groupe de cinq)
  resteDivisionEuclidienne = nombre_allumettes % 5;
  // Nous faisons aussi la division du nombre d'allumettes appartenant à un groupe de 5 par 5 (pour obtenir le nombre de groupe de 5 allumettes)
  nbGroupeCinqAllumettes = (nombre_allumettes - resteDivisionEuclidienne) / 5;

  // Afficher le nombre de groupe de cinq allumettes fois la ligne de cinq allumettes
  for (int i=0; i < 3; i++) {
    cout<<ligneCinqAllumettes<<endl;
  }
  // Afficher la dernière ligne
  cout<<ligneAllumettes;
}
