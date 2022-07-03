#include <iostream>
#include <math.h>

using namespace std;

struct graphe {
	int nb_sommet;
	string* liste_sommet;
	float** matrice_adjacence;
};

void afficherListe(int* liste, int n) {
	cout << "[ ";

	for (int i = 0; i < n; i++) {
		cout << liste[i];

		if (i != n - 1) {
			cout << ", ";
		}
	}

	cout << " ]" << endl;
}

void afficherListe(float* liste, int n) {
	cout << "[ ";

	for (int i = 0; i < n; i++) {
		cout << liste[i];

		if (i != n - 1) {
			cout << ", ";
		}
	}

	cout << " ]" << endl;
}

void afficherListe(string* liste, int n) {
	cout << "[ ";

	for (int i = 0; i < n; i++) {
		cout << liste[i];

		if (i != n - 1) {
			cout << ", ";
		}
	}

	cout << " ]" << endl;
}

int obtIndSommet(string* liste, int n, string sommet) {
	int res = -1;

	for (int i = 0; i < n; i++) {
		if (liste[i] == sommet) {
			res = i;
		}
	}

	return res;
}

void bellman(graphe G, string depart, string arrivee) {
	// D�claration des variables
	int n = G.nb_sommet;
	int k = 1;
	int j = -1;
	int long_temp = 0;
	int dep = obtIndSommet(G.liste_sommet, G.nb_sommet, depart);
	int arr = obtIndSommet(G.liste_sommet, G.nb_sommet, arrivee);
	int duree;

	int* pred = new int[n];
	float* dist = new float[n];

	bool estModif = true;

	string* temp = new string[n];
	string* itineraire = new string[n];


	// Initialisation des tableaux pred et dist
	for (int i = 0; i < n; i++) {
		pred[i] = 0;

		if (i == dep) {
			dist[i] = 0;
		}
		else {
			dist[i] = INFINITY;
		}
	}

	// Partie de l'algorithme
	while (k <= n && estModif) {
		estModif = false;

		for (int x = 0; x < n; x++) {
			for (int y = 0; y < n; y++) {
				if (dist[x] + G.matrice_adjacence[x][y] < dist[y]) {
					dist[y] = dist[x] + G.matrice_adjacence[x][y];
					pred[y] = x;
					estModif = true;
				}
			}
		}

		k += 1;
	}

	// On obtient la dur�e du trajet
	duree = dist[arr];

	// On met les sommets dans une liste pour ensuite l'afficher (on a besoin de faire �a pour inverser)
	while (arr != dep) {
		j += 1;
		temp[j] = G.liste_sommet[arr];
		arr = pred[arr];
	}
	j += 1;
	temp[j] = G.liste_sommet[dep];
	long_temp = j + 1;

	// On inverse la liste pour avoir le bon ordre
	for (int i = 0; i < long_temp; i++) {
		itineraire[i] = temp[long_temp - 1 - i];
	}

	// On affiche la liste
	cout << "L'itineraire est ";
	afficherListe(itineraire, long_temp);

	// On affiche la somme des valeurs sur les arr�ts en minutes
	cout << "La dur�e du trajet est de " << duree << " minute(s)" << endl;

	delete[] pred;
	delete[] dist;
}

int main() {
	graphe G;

	G.nb_sommet = 4;
	G.liste_sommet = new string[G.nb_sommet];
	G.matrice_adjacence = new float* [G.nb_sommet];
	for (int i = 0; i < G.nb_sommet; i++) {
		G.matrice_adjacence[i] = new float[G.nb_sommet];
	}

	float* dist_res = new float[G.nb_sommet];
	int* pred_res = new int[G.nb_sommet];

	G.liste_sommet[0] = "A";
	G.liste_sommet[1] = "B";
	G.liste_sommet[2] = "C";
	G.liste_sommet[3] = "D";

	G.matrice_adjacence[0][0] = INFINITY;
	G.matrice_adjacence[0][1] = INFINITY;
	G.matrice_adjacence[0][2] = 7;
	G.matrice_adjacence[0][3] = 1;

	G.matrice_adjacence[1][0] = INFINITY;
	G.matrice_adjacence[1][1] = INFINITY;
	G.matrice_adjacence[1][2] = 1;
	G.matrice_adjacence[1][3] = 2;

	G.matrice_adjacence[2][0] = 7;
	G.matrice_adjacence[2][1] = 1;
	G.matrice_adjacence[2][2] = INFINITY;
	G.matrice_adjacence[2][3] = INFINITY;

	G.matrice_adjacence[3][0] = 1;
	G.matrice_adjacence[3][1] = 2;
	G.matrice_adjacence[3][2] = INFINITY;
	G.matrice_adjacence[3][3] = INFINITY;

	bellman(G, "A", "D");
}