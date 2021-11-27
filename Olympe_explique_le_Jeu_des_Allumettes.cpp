#include "cstdlib"
#include "iostream"
#include "stdio.h"
#include "string.h"
using namespace std;

// Définition de la procédure saisie (procédure à faire dans la sous-tâche 1)
void saisie(int *nombre_allumettes, char *niveauUtilisateur, string *nomUtilisateur, string *premierJoueur) {
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
  cout<<ligneAllumettes<<endl;
  cout<<"Kesepasstil?";
}

int joueOrdi(char niveauOrdi, int nbAllumettes) {
  cout<<"Execution de joueOrdi"<<endl;
  int nbAllumettesChoixOrdi;
  cout<<"L'ordinateur est actuellement en train de jouer..."<<endl;
  if (niveauOrdi == 'n' or niveauOrdi == 'N') {
    nbAllumettesChoixOrdi = rand() % 3 + 1;
  } else {
    cout<<nbAllumettes<<endl;
    cout<<(nbAllumettes % 4)<<endl;
    cout<<(nbAllumettes % 4) - 1<<endl;
    nbAllumettesChoixOrdi = (nbAllumettes % 4) - 1;
    cout<<"Le choix de l'ordinateur est : "<<nbAllumettesChoixOrdi<<endl;
  }
  return nbAllumettesChoixOrdi;
}

void verificationSaisie(int ChoixAllumettesUtilisateur, int nbAllumettes, bool *abandon) {
  cout<<"Execution de verificationSaisie"<<endl;

  cout<<ChoixAllumettesUtilisateur<<endl;
  cout<<nbAllumettes<<endl;

  cout<<"Première vérification"<<endl;
  if (ChoixAllumettesUtilisateur < 0) {
    cout<<"Le nombre d'allumettes est inférieur à zéro. Or, il est impossible de choisir un nombre d'allumettes étant inférieur à zéro."<<endl<<"Je repose donc la question suivante :"<<endl;
  }
  cout<<"Seconde vérification"<<endl;
  if (ChoixAllumettesUtilisateur > 3) {
    cout<<"Le nombres d'allumettes choisis est supérieur à 3. Or, dans les règles de ce jeu, il est dit que l'on ne peut prendre un nombre d'allumettes supérieurs à 3."<<endl<<"Je repose donc la question suivante :"<<endl;
  }
  cout<<"Troisième vérification"<<endl;
  if (ChoixAllumettesUtilisateur > nbAllumettes) {
    cout<<"Le nombres d'allumettes choisis est supérieur au nombre d'allumettes disponibles sur le plateau de jeu."<<endl<<"Je repose donc la question suivante :"<<endl;
  }
  cout<<"Quatrième vérification"<<endl;
  if (ChoixAllumettesUtilisateur == nbAllumettes) {
    cout<<"Le nombres d'allumettes choisis est égale au nombre d'allumettes disponibles sur le plateau de jeu."<<endl<<"Je repose donc la question suivante :"<<endl;
  }
  cout<<"Cinquième vérification"<<endl;
  if (ChoixAllumettesUtilisateur == 0) {
    cout<<"Tu as abandonné la partie."<<endl;
    *abandon = true;
  }
}

int joueJoueur(string nomUtilisateur, int nbAllumettes, bool *abandon) {
  cout<<"Execution de joueJoueur"<<endl;
  int ChoixAllumettesUtilisateur;
  cout<<"C'est à toi de jouer, "<<nomUtilisateur<<" !"<<endl;
  do {
    cout<<"Combien d'allumettes souhaites-tu retirer ?"<<endl;
    cin>>ChoixAllumettesUtilisateur;
    verificationSaisie(ChoixAllumettesUtilisateur, nbAllumettes, abandon);
  } while (ChoixAllumettesUtilisateur < 0 or ChoixAllumettesUtilisateur > 3 or ChoixAllumettesUtilisateur >= nbAllumettes);
  return ChoixAllumettesUtilisateur;
}

void miseAjour(int *nbAllumettes, int allumettesRetirées) {
  cout<<"Execution de miseAjour"<<endl;
  *nbAllumettes = *nbAllumettes - allumettesRetirées;
}

void tourSuivant(string *tour_actuel) {
  cout<<"Execution de tourSuivant"<<endl;
  if (*tour_actuel == "tour_ordi") {
    *tour_actuel = "tour_joueur";
  } else {
    *tour_actuel = "tour_ordi";
  }
}

void jeuAlterne(string *tour_actuel, char niveau, int *nbAllumettes, string nom, bool *abandon) {
  cout<<"Execution de jeuAlterne"<<endl;
  int allumettesRetirées = 0;
  if (*tour_actuel == "tour_ordi") {
    allumettesRetirées = joueOrdi(niveau, *nbAllumettes);
  } else {
    allumettesRetirées = joueJoueur(nom, *nbAllumettes, abandon);
  }
  miseAjour(nbAllumettes, allumettesRetirées);
  tourSuivant(tour_actuel);
}

void initialisationTour(string premierJoueur, string *tour_actuel) {
  cout<<"Execution de initialisationTour"<<endl;
  if (premierJoueur == "Ordinateur") {
    *tour_actuel = "tour_ordi";
    cout<<"Le premier joueur est l'ordinateur"<<endl;
  } else {
    *tour_actuel = "tour_joueur";
    cout<<"Tu es le premier joueur"<<endl;
  }
}

int identitéGagnant(string tour, string nom) {
  string vainqueur;
  if (tour == "tour_ordi") {
    vainqueur = nom;
  } else {
    vainqueur = "l'ordinateur";
  }
}

int main() {
  // Déclaration des variables
  // Le nombre d'allumettes est un entier
  int nb_allumettes;
  // Le niveau est donné à l'aide uniquement d'un caractère
  char niv;
  // Le nom et le premier joueur sont des chaines de caractères
  string nom, prem, tour;
  bool abandon = false;

  // Appel de la procédure Saisie (procédure à faire dans la sous-tâche 1)
  saisie(&nb_allumettes, &niv, &nom, &prem);
  initialisationTour(prem, &tour);
  Affiche(nb_allumettes);

  do {
    jeuAlterne(&tour, niv, &nb_allumettes, nom, &abandon);
    Affiche(nb_allumettes);
  } while (nb_allumettes != 1);

  if (tour =="tour_ordi") {
    cout<<"Tu as gagné"<<endl;
  } else {
    if (tour == "tour_joueur") {
      cout<<"Tu as perdu"<<endl;
    } else {
      cout<<"Tu as abandonné"<<endl;
    }

  }
  cout<<"Kwea?"<<endl;
  return 0;
}
