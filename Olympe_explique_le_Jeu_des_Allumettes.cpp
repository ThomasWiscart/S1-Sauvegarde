#include "cstdlib"
#include "iostream"
#include "stdio.h"
#include "string.h"
using namespace std;

void saisie(int *nbAllumettes, char *niveauOrdinateur, string *pseudoUtilisateur, string *premierJoueur) {
  cout<<"Quel est ton pseudo ?"<<endl;
  cin>>*pseudoUtilisateur;
  cout<<" --> j'enregistre ce que tu as écrit dans la variable pseudoUtilisateur"<<endl;

  do {
    cout<<"Tu vas jouer contre l'ordinateur. Quel niveau souhaites-tu qu'il ait?"<<endl;
    cout<<"Tapes n ou N si tu souhaites mettre le niveau sur Naif"<<endl;
    cout<<"Tapes e ou E si tu souhaites mettre le niveau sur Expert"<<endl;
    cin>>*niveauOrdinateur;
    cout<<" --> j'enregistre ce que tu as écrit dans la variable niveauOrdinateur"<<endl;
  } while (*niveauOrdinateur != 'e' and *niveauOrdinateur != 'E' and *niveauOrdinateur != 'n' and *niveauOrdinateur != 'N');

  do {
    cout<<"Quel est le nombre d'allumettes que tu souhaites (entre 3 et 30 allumettes)?"<<endl;
    cin>>*nbAllumettes;
    cout<<" --> j'enregistre ce que tu as écrit dans la variable nbAllumettes"<<endl;
  } while (*nbAllumettes < 3 or *nbAllumettes > 30);

  do {
    cout<<"Choississez le premier joueur :"<<endl;
    cout<<"Si tu souhaites laisser l'ordinateur jouer en premier, tape Ordinateur"<<endl;
    cout<<"Si tu veux être le premier joueur, écris ton nom : "<<*pseudoUtilisateur<<endl;
    cin>>*premierJoueur;
    cout<<" --> j'enregistre ce que tu as écrit dans la variable premierJoueur"<<endl;
  } while (*premierJoueur != "Ordinateur" and *premierJoueur != *pseudoUtilisateur);
}

void Affiche(int nbAllumettes) {
  int nbGroupeCinqAllumettes, resteDivisionEuclidienne;
  string ligneAllumettes, ligneCinqAllumettes = "! ! ! ! !";

  resteDivisionEuclidienne = nbAllumettes % 5;
  nbGroupeCinqAllumettes = (nbAllumettes - resteDivisionEuclidienne) / 5;

  for (int i=0; i < nbGroupeCinqAllumettes; i++) {
    cout<<ligneCinqAllumettes<<endl;
  }

  for (int i=0; i < resteDivisionEuclidienne; i++) {
      ligneAllumettes = ligneAllumettes + "! ";
  }

  cout<<ligneAllumettes<<endl;
}

int joueOrdi(char niveauOrdinateur, int nbAllumettes) {
  int nbAllumettesChoixOrdi;
  cout<<"L'ordinateur est actuellement en train de jouer..."<<endl;
  if (niveauOrdinateur == 'n' or niveauOrdinateur == 'N') {
    if (nbAllumettes > 3) {
      nbAllumettesChoixOrdi = rand() % 3 + 1;
    } else {
      if (nbAllumettes > 2) {
        nbAllumettesChoixOrdi = rand() % 2 + 1;
      } else {
        nbAllumettesChoixOrdi = rand() % 1 + 1;
      }
    }
  } else {
    if ((nbAllumettes % 4) - 1 != -1) {
      nbAllumettesChoixOrdi = (nbAllumettes % 4) - 1;
    } else {
      nbAllumettesChoixOrdi = rand() % 3 + 1;
    }
  }
  cout<<"Le nombre d'allumettes choisis par l'ordinateur est : "<<nbAllumettesChoixOrdi<<endl;
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
    cout<<"Tu as abandonné la partie. Voici le plateau de jeu."<<endl;
    *abandon = true;
  }
}

int joueJoueur(string pseudoUtilisateur, int nbAllumettes, bool *abandon) {
  int ChoixAllumettesUtilisateur;
  cout<<"C'est à toi de jouer, "<<pseudoUtilisateur<<" !"<<endl;
  do {
    cout<<"Combien d'allumettes souhaites-tu retirer (entre 1 et 3 allumettes) {si tu choisis 0 (et tout les autres caractères non-numériques), tu abandonneras la partie} ?"<<endl;
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

void jeuAlterne(string *tourActuel, char niveauOrdinateur, int *nbAllumettes, string pseudoUtilisateur, bool *abandon) {
  int allumettesRetirees = 0;
  if (*tourActuel == "tour_ordi") {
    allumettesRetirees = joueOrdi(niveauOrdinateur, *nbAllumettes);
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

void resultatPartie(string tourActuel, bool abandon) {
  if (abandon == true) {
    cout<<"Tu as abandonné."<<endl;
  } else {
    if (tourActuel == "tour_joueur") {
      cout<<"Tu as perdu."<<endl;
    } else {
      cout<<"Tu as gagné."<<endl;
    }
  }
}

int main() {
  cout<<"Bonjour, je m'appelle Olympe. Je suis le bot développé par Thomas pour expliquer le programme jeu-des-allumettes."<<endl;
  cout<<"Premièrement, j'initialise les variables : nbAllumettes, niveauOrdinateur, pseudoUtilisateur, premierJoueur, tourActuel et abandon."<<endl;
  cout<<"Ce sont des variables qui seront utilisés toute au long du programme."<<endl;
  int nbAllumettes;
  char niveauOrdinateur;
  string pseudoUtilisateur, premierJoueur, tourActuel;
  bool abandon = false;

  cout<<"Je fais appel à la procédure Saisie pour demander les informations à l'utilisateur."<<endl;
  saisie(&nbAllumettes, &niveauOrdinateur, &pseudoUtilisateur, &premierJoueur);
  cout<<"Je fais appel à la procédure initialisationTour pour savoir qui commence."<<endl;
  initialisationTour(premierJoueur, &tourActuel);
  cout<<"Je fais appel à la procédure Affiche pour savoir qui commence."<<endl;
  Affiche(nbAllumettes);

  cout<<"Je rentre actuellement dans une boucle qui fonctionnera tant que l'utilisateur n'aura pas abandonné la partie ou que le nombre d'allumettes égal de 1."
  do {
    jeuAlterne(&tourActuel, niveauOrdinateur, &nbAllumettes, pseudoUtilisateur, &abandon);
    Affiche(nbAllumettes);
  } while (nbAllumettes > 1 and abandon != true);

  resultatPartie(tourActuel, abandon);
  return 0;
}
