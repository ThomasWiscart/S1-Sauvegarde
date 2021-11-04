#include "iostream"
#include "stdio.h"
#include "string.h"
using namespace std;

// Définition de la procédure saisie (procédure à faire dans la sous-tâche 1)
void saisie(string *nomUtilisateur, char *niveauUtilisateur, int *nombre_allumettes, string *premierJoueur) {
  // Demande le nom du joueur
  cout<<"Quel est ton nom de joueur?"<<endl;
  cin>>*nomUtilisateur;

  // Début du contrôle de saisie
  do {
      // Demande à l'utilisateur quel est le niveau qu'il veut pour l'ordinateur
      cout<<"Tu vas jouer contre l'ordinateur. Quel niveau souhaites-tu qu'il ait?"<<endl;
      cout<<"Tapes n ou N si tu souhaites mettre le niveau sur Naif"<<endl;
      cout<<"Tapes e ou E si tu souhaites mettre le niveau sur Expert"<<endl;
      cin>>*niveauUtilisateur;
  // Condition qui contrôle la saisie
  } while (*niveauUtilisateur != 'e' and *niveauUtilisateur != 'E' and *niveauUtilisateur != 'n' and *niveauUtilisateur != 'N');


  // Début du contrôle de saisie
  do {
      // Demande à l'utilisateur quel est le nombre d'allumettes qu'il souhaite
      cout<<"Quel est le nombre d'allumettes que tu souhaites (entre 0 et 30 allumettes)?"<<endl;
      cin>>*nombre_allumettes;
  // Condition qui contrôle la saisie
  } while (*nombre_allumettes < 0 or *nombre_allumettes > 30);

// Début du contrôle de saisie
  do {
      // Demande à l'utilisateur quel est le premier joueur entre lui et l'ordinateur
      cout<<"Choississez le premier joueur :"<<endl;
      cout<<"Si vous voulez laisser l'ordinateur jouer en premier, tapez Ordinateur"<<endl;
      cout<<"Si vous voulez être le premier joueur, écrivez votre nom : "<<*nomUtilisateur<<endl;
      cin>>*premierJoueur;
  // Condition qui contrôle la saisie
  } while (*premierJoueur != "Ordinateur" and *premierJoueur != *nomUtilisateur);
}

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
  for (int i=0; i < nbGroupeCinqAllumettes; i++) {
    cout<<ligneCinqAllumettes<<endl;
  }
  // Cancaténer les points d'exclamation en fonction du reste d'allumettes qui ne se trouve pas dans un groupe de 5
  for (int i=0; i < resteDivisionEuclidienne; i++) {
      ligneAllumettes = ligneAllumettes + "! ";
  }
  // Afficher la dernière ligne
  cout<<ligneAllumettes;
}

int main() {
  // Déclaration des variables
  // Le nombre d'allumettes est un entier
  int nb_allumettes;
  // Le niveau est donné à l'aide uniquement d'un caractère
  char niv;
  // Le nom et le premier joueur sont des chaines de caractères
  string nom, prem;

  // Appel de la procédure Saisie (procédure à faire dans la sous-tâche 1)
  saisie(&nom, &niv, &nb_allumettes, &prem);
  Affiche(nb_allumettes);
  return 0;
}
