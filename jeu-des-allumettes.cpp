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

  return 0;
}
