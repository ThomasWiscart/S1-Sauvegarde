#include "cstdlib"
#include "iostream"
#include "stdio.h"
#include "string.h"
using namespace std;

// Définition de la procédure saisie (procédure à faire dans la sous-tâche 1)
void saisie(int *nbAllumettes, char *niveauOrdinateur, string *pseudoUtilisateur, string *premierJoueur) {
  cout<<"Quel est ton pseudo ?"<<endl;
  cin>>*pseudoUtilisateur;

  // Début du contrôle de saisie
  do {
    // Demande à l'utilisateur quel est le niveau qu'il veut pour l'ordinateur
    cout<<"Tu vas jouer contre l'ordinateur. Quel niveau souhaites-tu qu'il ait?"<<endl;
    cout<<"Tapes n ou N si tu souhaites mettre le niveau sur Naif"<<endl;
    cout<<"Tapes e ou E si tu souhaites mettre le niveau sur Expert"<<endl;
    cin>>*niveauOrdinateur;
  // Condition qui contrôle la saisie
  } while (*niveauOrdinateur != 'e' and *niveauOrdinateur != 'E' and *niveauOrdinateur != 'n' and *niveauOrdinateur != 'N');

  // Début du contrôle de saisie
  do {
    // Demande à l'utilisateur quel est le nombre d'allumettes qu'il souhaite
    cout<<"Quel est le nombre d'allumettes que tu souhaites (entre 3 et 30 allumettes)?"<<endl;
    cin>>*nbAllumettes;
  // Condition qui contrôle la saisie
  } while (*nbAllumettes < 3 or *nbAllumettes > 30);
  // Début du contrôle de saisie
  do {
    // Demande à l'utilisateur quel est le premier joueur entre lui et l'ordinateur
    cout<<"Choississez le premier joueur :"<<endl;
    cout<<"Si tu souhaites laisser l'ordinateur jouer en premier, tape Ordinateur"<<endl;
    cout<<"Si tu veux être le premier joueur, écris ton nom : "<<*pseudoUtilisateur<<endl;
    cin>>*premierJoueur;
    // Condition qui contrôle la saisie
  } while (*premierJoueur != "Ordinateur" and *premierJoueur != *pseudoUtilisateur);
}

void Affiche(int nbAllumettes) {
  // Le nombre de groupe de cinq allumettes et le reste de la division euclidienne par cinq sont des entiers
  int nbGroupeCinqAllumettes, resteDivisionEuclidienne;
  // La ligne représentant les allumettes et la ligne composée de cinq allumettes sont tout deux des chaines de caractères
  string ligneAllumettes, ligneCinqAllumettes = "! ! ! ! !";
  // Notre but est d'avoir le nombre de groupe de cinq allumettes
  // Nous allons donc faire la division euclidienne du nombre total d'Allumettes par 5 (pour obtenir le nombre d'allumettes ne faisant pas parti d'un groupe de cinq)
  resteDivisionEuclidienne = nbAllumettes % 5;
    // Nous faisons aussi la division du nombre d'allumettes appartenant à un groupe de 5 par 5 (pour obtenir le nombre de groupe de 5 allumettes)
  nbGroupeCinqAllumettes = (nbAllumettes - resteDivisionEuclidienne) / 5;

  // Afficher le nombre de groupe de cinq allumettes fois la ligne de cinq allumettes
  for (int i=0; i < nbGroupeCinqAllumettes; i++) {
    cout<<ligneCinqAllumettes<<endl;
  }

  // Cancaténer les points d'exclamation en fonction du reste d'allumettes qui ne se trouve pas dans un groupe de 5
  for (int i=0; i < resteDivisionEuclidienne; i++) {
      ligneAllumettes = ligneAllumettes + "! ";
  }

  // Afficher la dernière ligne
  cout<<ligneAllumettes<<endl;
}

int joueOrdi(char niveauOrdi, int nbAllumettes) {
  int nbAllumettesChoixOrdi;
  cout<<"L'ordinateur est actuellement en train de jouer..."<<endl;
  if (niveauOrdi == 'n' or niveauOrdi == 'N') {
    nbAllumettesChoixOrdi = rand() % 3 + 1;
  } else {
    nbAllumettesChoixOrdi = (nbAllumettes % 4) - 1;
    cout<<"Le nombre d'allumettes choisis par l'ordinateur est : "<<nbAllumettesChoixOrdi<<endl;
  }
  return nbAllumettesChoixOrdi;
}

void verificationSaisie(int ChoixAllumettesUtilisateur, int nbAllumettes, bool *abandon) {
  if (ChoixAllumettesUtilisateur < 0) {
    cout<<"Le nombre d'allumettes choisies est inférieur à zéro. Or, il est impossible de choisir un nombre d'allumettes étant inférieur à zéro."<<endl<<"Je repose donc la question suivante :"<<endl;
  }

  if (ChoixAllumettesUtilisateur > 3) {
    cout<<"Le nombres d'allumettes choisies est supérieur à 3. Or, dans les règles de ce jeu, il est dit que l'on ne peut prendre un nombre d'allumettes supérieurs à 3."<<endl<<"Je repose donc la question suivante :"<<endl;
  }

  if (ChoixAllumettesUtilisateur > nbAllumettes) {
    cout<<"Le nombres d'allumettes choisies est supérieur au nombre d'allumettes disponibles sur le plateau de jeu."<<endl<<"Je repose donc la question suivante :"<<endl;
  }

  if (ChoixAllumettesUtilisateur == nbAllumettes) {
    cout<<"Le nombres d'allumettes choisies est égale au nombre d'allumettes disponibles sur le plateau de jeu."<<endl<<"Je repose donc la question suivante :"<<endl;
  }

  if (ChoixAllumettesUtilisateur == 0) {
    cout<<"Tu ne joues aucune allumettes ce qui signifie que tu abandonnes la partie. Voici le plateau de jeu : "<<endl;
    *abandon = true;
  }
}

int joueJoueur(string pseudoUtilisateur, int nbAllumettes, bool *abandon) {
  int ChoixAllumettesUtilisateur;
  cout<<"C'est à toi de jouer, "<<pseudoUtilisateur<<" !"<<endl;
  do {
    cout<<"Combien d'allumettes souhaites-tu retirer (entre 1 et 3 allumettes) {si tu choisis 0, tu abandonneras la partie} ?"<<endl;
    cin>>ChoixAllumettesUtilisateur;
    verificationSaisie(ChoixAllumettesUtilisateur, nbAllumettes, abandon);
  } while (ChoixAllumettesUtilisateur < 0 or ChoixAllumettesUtilisateur > 3 or ChoixAllumettesUtilisateur >= nbAllumettes);
  return ChoixAllumettesUtilisateur;
}

void miseAjour(int *nbAllumettes, int allumettesRetirees) {
  *nbAllumettes = *nbAllumettes - allumettesRetirees;
}

void tourSuivant(string *tourActuel) {
  if (*tourActuel == "tour_ordi") {
    *tourActuel = "tour_joueur";
  } else {
    *tourActuel = "tour_ordi";
  }
}

void jeuAlterne(string *tourActuel, char niveau, int *nbAllumettes, string pseudoUtilisateur, bool *abandon) {
  int allumettesRetirees = 0;
  if (*tourActuel == "tour_ordi") {
    allumettesRetirees = joueOrdi(niveau, *nbAllumettes);
  } else {
    allumettesRetirees = joueJoueur(pseudoUtilisateur, *nbAllumettes, abandon);
  }
  miseAjour(nbAllumettes, allumettesRetirees);
  tourSuivant(tourActuel);
}

void initialisationTour(string premierJoueur, string *tourActuel) {
  if (premierJoueur == "Ordinateur") {
    *tourActuel = "tour_ordi";
  } else {
    *tourActuel = "tour_joueur";
  }
}

int main() {
  // Déclaration des variables
  // Le nombre d'allumettes est un entier
  int nbAllumettes;
  // Le niveau est donné à l'aide uniquement d'un caractère
  char niveauOrdi;
  // Le nom et le premier joueur sont des chaines de caractères
  string pseudoUtilisateur, premierJoueur, tourActuel;
  bool abandon = false;

  // Appel de la procédure Saisie (procédure à faire dans la sous-tâche 1)
  saisie(&nbAllumettes, &niveauOrdi, &pseudoUtilisateur, &premierJoueur);
  initialisationTour(premierJoueur, &tourActuel);
  Affiche(nbAllumettes);

  do {
    jeuAlterne(&tourActuel, niveauOrdi, &nbAllumettes, pseudoUtilisateur, &abandon);
    Affiche(nbAllumettes);
  } while (nbAllumettes > 1 and abandon != true);

  if (abandon == true) {
    cout<<"Tu as abandonné."<<endl;
  } else {
    if (tourActuel == "tour_joueur") {
      cout<<"Tu as perdu."<<endl;
    } else {
      cout<<"Tu as gagné."<<endl;
    }
  }
  return 0;
}
