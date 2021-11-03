#include "iostream"
#include "stdio.h"
#include "string.h"
using namespace std;

// Définition de la procédure saisie (procédure à faire dans la sous-tâche 1)
void saisie(string *nom, char *niv, int *nb_allumettes, string *prem) {
  // Demande le nom du joueur
  cout<<"Quel est ton nom de joueur?"<<endl;
  cin>>*nom;

  // Demande à l'utilisateur quel est le niveau qu'il veut pour l'ordinateur
  cout<<"Tu vas jouer contre l'ordinateur. Quel niveau souhaites-tu qu'il ai?"<<endl;
  cout<<"Tapes n ou N si tu souhaites mettre le niveau sur Naif"<<endl;
  cout<<"Tapes e ou E si tu souhaites mettre le niveau sur Expert"<<endl;
  cin>>*niv;

  // Demande à l'utilisateur quel est le nombre d'allumettes qu'il souhaite
  cout<<"Quel est le nombre d'allumettes que tu souhaites (entre 0 et 30 allumettes)?"<<endl;
  cin>>*nb_allumettes;

  // Demande à l'utilisateur quel est le premier joueur entre lui et l'ordinateur
  cout<<"Choississez le premier joueur :"<<endl;
  cout<<"Si vous voulez laisser l'ordinateur jouer en premier, tapez Ordinateur"<<endl;
  cout<<"Si vous voulez être le premier joueur, écrivez votre nom : "<<*nom<<endl;
  cin>>*prem;
}
int main() {
  // Déclaration des variables
  // Le nombre d'allumettes est un entier
  int nb_allumettes;
  // Le niveau est donné à l'aide uniquement un caractère
  char niv;
  // Le nom et le premier joueur sont des ensembles de caractères
  string nom, prem;

  // Appel de la procédure Saisie (procédure à faire dans la sous-tâche 1)
  saisie(&nom, &niv, &nb_allumettes, &prem);

  return 0;
}
