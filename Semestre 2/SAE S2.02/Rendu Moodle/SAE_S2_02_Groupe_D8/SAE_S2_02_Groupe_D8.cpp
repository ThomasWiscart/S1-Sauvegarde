#include <iostream>
#include <fstream>
#include <string>

using namespace std;

struct LigneMetro
{
	int id_metro;
	string nom_metro;
	float vitMoyLigne;
};

class Sommet
{
private:
	int id;
	string nom;

public:
	Sommet();

	Sommet& operator=(const Sommet&);

	void ModifId(int);
	void ModifNom(string);

	int ObtId();
	string ObtNom();
};

class Arc
{
private:
	Sommet* extremites;
	float poids;
	LigneMetro ligne_metro;

public:
	Arc();

	void ModifDebut(Sommet);
	void ModifFin(Sommet);
	void ModifPoids(float);

	void ModifLigneMetro(LigneMetro);

	Sommet ObtDebut();
	Sommet ObtFin();
	float ObtPoids();
	LigneMetro ObtLigneMetro();
};

class Graphe
{
private:
	int nb_sommet;
	int nb_arc;

	Sommet* liste_sommet;

	Arc* liste_arc;

	float** matrice_adjacence;

public:
	Graphe(Sommet*, int);

	void InitListeArc(Arc*, int);

	void CalculerMatriceAdjacence();

	int ObtIdSommet(string);
	string ObtNomSommet(int);
	Sommet ObtSommet(int);

	Arc ObtArc(int, int);

	int ObtNbSommet();
	int ObtNbArc();
	float** ObtMatriceAdjacence();
};

///////////////////////////////////////////////// Fonctions pour la partie entrée de l'interface \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

string EnMiniscule(string chaine)
{
	string res = "";
	
	for (int i = 0; i < chaine.length(); i++)
	{
		res += tolower(chaine[i]);
	}

	return res;
}

bool EstDansChaine(string chaine, char caractère)
{
	int i = 0;

	bool res = false;

	while (chaine[i] != '\0' && !res)
	{
		if (chaine[i] == caractère)
		{
			res = true;
		}
		
		i++;
	}

	return res;
}

bool CompChaineAprox(string chaine1, string chaine2)
{
	float longueur_chaine1 = chaine1.length(), longueur_chaine2 = chaine2.length(), lettre_commun = 0, ressemblance = 0, precision = 0.85;

	chaine1 = EnMiniscule(chaine1);

	chaine2 = EnMiniscule(chaine2);

	if (longueur_chaine1 < longueur_chaine2)
	{
		for(int i = 0; i < longueur_chaine1; i++)
		{
			if (EstDansChaine(chaine2, chaine1[i]))
			{
				lettre_commun++;
			}
		}

		ressemblance = lettre_commun / longueur_chaine2;
	}
	else
	{
		for (int i = 0; i < longueur_chaine2; i++)
		{
			if (EstDansChaine(chaine1, chaine2[i]))
			{
				lettre_commun++;
			}
		}

		ressemblance = lettre_commun / longueur_chaine1;
	}

	return ressemblance >= precision;
}

void SaisieUtilisateur(Graphe G, int *depart, int *arrivee)
{
	string nom_depart, nom_arrivee;

	cout << "--------------------- Chercher un itinéraire ---------------------" << endl << endl;

	do
	{
		cout << "Veuillez entrer l'arrêt de départ : " << endl << endl;
		getline(cin, nom_depart);

		*depart = G.ObtIdSommet(nom_depart);
	}
	while (*depart == NULL);

	*depart -= 1;

	cout << endl;

	do
	{
		cout << "Veuillez entrer l'arrêt d'arrivée : " << endl << endl;
		getline(cin, nom_arrivee);

		*arrivee = G.ObtIdSommet(nom_arrivee);
	}
	while (*arrivee == NULL);

	*arrivee -= 1;

	cout << endl;

	cout << "------------------------------------------------------------------" << endl << endl;
}

///////////////////////////////////////////////// Méthodes de la classe "Sommet" \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

Sommet::Sommet() {}

Sommet& Sommet::operator=(const Sommet& nouveau_sommet)
{
	if (this != &nouveau_sommet)
	{
		id = nouveau_sommet.id;

		nom = nouveau_sommet.nom;
	}

	return *this;
}

void Sommet::ModifId(int nouveau_id) { id = nouveau_id; }

void Sommet::ModifNom(string nouveau_nom) { nom = nouveau_nom; }

int Sommet::ObtId() { return id; }

string Sommet::ObtNom() { return nom; }

///////////////////////////////////////////////// Méthodes de la classe "Arc" \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

Arc::Arc() { extremites = new Sommet[2]; }

void Arc::ModifDebut(Sommet debut) { extremites[0] = debut; }

void Arc::ModifFin(Sommet fin) { extremites[1] = fin; }

void Arc::ModifPoids(float nouveau_poids) { poids = nouveau_poids; }

void Arc::ModifLigneMetro(LigneMetro nouveau_ligne_metro) { ligne_metro = nouveau_ligne_metro; }

Sommet Arc::ObtDebut() { return extremites[0]; }

Sommet Arc::ObtFin() { return extremites[1]; }

float Arc::ObtPoids() { return poids; }

LigneMetro Arc::ObtLigneMetro() { return ligne_metro; }

///////////////////////////////////////////////// Méthodes de la classe "Graphe" \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

Graphe::Graphe(Sommet* nouvelle_liste_sommet, int nouveau_nb_sommet)
{
	nb_sommet = nouveau_nb_sommet;

	liste_sommet = new Sommet[nb_sommet];

	for (int i = 0; i < nb_sommet; i++)
	{
		liste_sommet[i] = nouvelle_liste_sommet[i];
	}
}

void Graphe::InitListeArc(Arc* nouvelle_liste_arc, int nouveau_nb_arc)
{
	nb_arc = nouveau_nb_arc;

	liste_arc = new Arc[nb_arc];

	for (int i = 0; i < nb_arc; i++)
	{
		liste_arc[i] = nouvelle_liste_arc[i];
	}

	matrice_adjacence = new float* [nb_sommet];

	for (int i = 0; i < nb_sommet; i++)
	{
		matrice_adjacence[i] = new float[nb_sommet];

		for (int j = 0; j < nb_sommet; j++)
		{
			matrice_adjacence[i][j] = INFINITY;
		}
	}
}

void Graphe::CalculerMatriceAdjacence()
{
	int ind_s1, ind_s2;

	float poids;

	for (int i = 0; i < nb_arc; i++)
	{
		ind_s1 = liste_arc[i].ObtDebut().ObtId() - 1;

		ind_s2 = liste_arc[i].ObtFin().ObtId() - 1;

		poids = liste_arc[i].ObtPoids();

		matrice_adjacence[ind_s1][ind_s2] = poids;
	}
}

int Graphe::ObtIdSommet(string nom)
{
	int id = NULL;

	for (int i = 0; i < nb_sommet; i++)
	{
		if (CompChaineAprox(nom, liste_sommet[i].ObtNom()))
		{
			id = liste_sommet[i].ObtId();
		}
	}

	if (id == NULL)
	{
		cout << "Erreur : Sommet introuvable" << endl;
	}

	return id;
}

string Graphe::ObtNomSommet(int id)
{
	string nom_sommet = "";

	for (int i = 0; i < nb_sommet; i++)
	{
		if (liste_sommet[i].ObtId() == id)
		{
			nom_sommet = liste_sommet[i].ObtNom();
		}
	}

	if (nom_sommet == "")
	{
		cout << "Erreur : Sommet introuvable." << endl;
	}

	return nom_sommet;
}

Sommet Graphe::ObtSommet(int id)
{
	Sommet res;
	
	for (int i = 0; i < nb_sommet; i++)
	{
		if (liste_sommet[i].ObtId() == id)
		{
			res = liste_sommet[i];
		}
	}

	return res;
}

Arc Graphe::ObtArc(int sommet1, int sommet2)
{
	Arc res;

	for (int i = 0; i < nb_arc; i++)
	{
		if (liste_arc[i].ObtDebut().ObtId() == sommet1 && liste_arc[i].ObtFin().ObtId() == sommet2)
		{
			res = liste_arc[i];
		}
	}

	return res;
}

int Graphe::ObtNbSommet() { return nb_sommet; }

int Graphe::ObtNbArc() { return nb_arc; }

float** Graphe::ObtMatriceAdjacence() { return matrice_adjacence; }

///////////////////////////////////////////////// Fonctions pour la lecture du fichier csv \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

int CpteNbElem(string chaine)
{
	int i = 0, n = 1;

	while (chaine[i] != '\0')
	{
		if (chaine[i] == ',')
		{
			n++;
		}

		i++;
	}

	return n;
}

string* Separer(string chaine, int *nb_elem)
{
	int i = 0, j = 0;

	*nb_elem = CpteNbElem(chaine);

	string elem = "";

	string* liste_elem = new string[*nb_elem];

	while (chaine[i] != '\0')
	{
		if (chaine[i] != ',')
		{
			elem += chaine[i];
		}
		else
		{
			liste_elem[j] = elem;

			elem = "";

			j++;
		}

		i++;
	}

	liste_elem[j] = elem;

	return liste_elem;
}

int CpteNbLigne(string chemin_fichier)
{
	int i = 0;

	string ligne_fichier;

	ifstream fichier(chemin_fichier);

	while (getline(fichier, ligne_fichier))
	{
		i++;
	}

	fichier.close();

	return i;
}

string** LectureFichier(string chemin_fichier, int *nb_ligne, int *nb_elem)
{
	*nb_ligne = CpteNbLigne(chemin_fichier);

	int i = 0;
	
	string ligne_fichier;

	string** contenu_fichier = new string*[*nb_ligne];

	ifstream fichier(chemin_fichier);

	while (getline(fichier, ligne_fichier))
	{
		contenu_fichier[i] = Separer(ligne_fichier, &*nb_elem);

		i++;
	}

	fichier.close();

	return contenu_fichier;
}

Sommet* GenererListeSommet(string chemin_fichier, int *nb_sommet)
{
	int nb_ligne_fichier, nb_elem_ligne_fichier;

	string** table_arret = LectureFichier(chemin_fichier, &nb_ligne_fichier, &nb_elem_ligne_fichier);

	Sommet* liste_sommet = new Sommet[nb_ligne_fichier];

	*nb_sommet = nb_ligne_fichier;

	for (int i = 0; i < nb_ligne_fichier; i++)
	{
		liste_sommet[i].ModifId( stoi(table_arret[i][0]) );
		liste_sommet[i].ModifNom( table_arret[i][1] );
	}

	return liste_sommet;
}

LigneMetro ChercherLigneMetro(string chemin_fichier_table_ligne, int id)
{
	int nb_ligne_fichier, nb_elem_ligne_fichier;

	string** table_ligne = LectureFichier(chemin_fichier_table_ligne, &nb_ligne_fichier, &nb_elem_ligne_fichier);

	LigneMetro res;

	for (int i = 0; i < nb_ligne_fichier; i++)
	{
		if ( id == stoi(table_ligne[i][0]) )
		{
			res.id_metro = stoi(table_ligne[i][0]);

			res.nom_metro = table_ligne[i][1];

			res.vitMoyLigne = stof(table_ligne[i][3]);
		}
	}

	return res;
}

float ChercherDistanceArret(string chemin_fichier_table_distance, int numArret1, int numArret2)
{
	int nb_ligne_fichier, nb_elem_ligne_fichier;

	float res = NULL;

	string** table_distance = LectureFichier(chemin_fichier_table_distance, &nb_ligne_fichier, &nb_elem_ligne_fichier);

	for (int i = 0; i < nb_ligne_fichier; i++)
	{
		if ( numArret1 == stoi(table_distance[i][0]) && numArret2 == stoi(table_distance[i][1]) || numArret1 == stoi(table_distance[i][1]) && numArret2 == stoi(table_distance[i][0]))
		{
			res = stof(table_distance[i][2]);
		}
	}

	return res;
}

Arc* GenererListeArc(Graphe G, string chemin_fichier_table_ligne, string chemin_fichier_table_distance, string chemin_fichier_table_est_desservi, int* nb_arc)
{
	int nb_ligne_fichier, nb_elem_ligne_fichier, sommet1, sommet2;

	float distance, vitesse, poids;

	string** table_est_desservi = LectureFichier(chemin_fichier_table_est_desservi, &nb_ligne_fichier, &nb_elem_ligne_fichier);

	Arc* liste_arc = new Arc[nb_ligne_fichier];

	*nb_arc = nb_ligne_fichier;

	for (int i = 0; i < nb_ligne_fichier; i++)
	{
		liste_arc[i].ModifDebut( G.ObtSommet( stoi(table_est_desservi[i][1]) ) );

		liste_arc[i].ModifFin( G.ObtSommet( stoi(table_est_desservi[i][3]) ) );

		liste_arc[i].ModifLigneMetro( ChercherLigneMetro( chemin_fichier_table_ligne, stoi(table_est_desservi[i][0]) ) );

		sommet1 = liste_arc[i].ObtDebut().ObtId();

		sommet2 = liste_arc[i].ObtFin().ObtId();

		distance = ChercherDistanceArret(chemin_fichier_table_distance, sommet1, sommet2);

		vitesse = liste_arc[i].ObtLigneMetro().vitMoyLigne;

		poids = (distance / vitesse) * 60.0;

		liste_arc[i].ModifPoids( poids );
	}

	return liste_arc;
}

///////////////////////////////////////////////// Fonctions pour le calculateur d'itinéraire \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

void Bellman(Graphe G, int depart, int* pred, float* dist)
{
	int n = G.ObtNbSommet(), k = 1;

	for (int i = 0; i < n; i++)
	{
		pred[i] = 0;
	}

	for (int i = 0; i < n; i++)
	{
		if (i == depart)
		{
			dist[i] = 0;
		}
		else
		{
			dist[i] = INFINITY;
		}
	}

	G.CalculerMatriceAdjacence();

	float** w = G.ObtMatriceAdjacence();

	while (k < n)
	{
		for (int x = 0; x < n; x++)
		{
			for (int y = 0; y < n; y++)
			{
				if (dist[x] + w[x][y] < dist[y])
				{
					dist[y] = dist[x] + w[x][y];

					pred[y] = x;
				}
			}
		}

		k++;
	}
}

int CpteLongueurChemin(int* pred, int depart, int arrivee)
{
	int longueur_chemin = 1, arrivee_temp = arrivee;

	while (depart != arrivee_temp)
	{
		arrivee_temp = pred[arrivee_temp];

		longueur_chemin++;
	}

	return longueur_chemin;
}

int* ConstruireChemin(int* pred, int depart, int arrivee, int longueur_chemin)
{
	int* chemin = new int[longueur_chemin];

	int i = 1, arrive_temp = arrivee;

	chemin[longueur_chemin - i] = arrive_temp;

	while (depart != arrive_temp)
	{
		arrive_temp = pred[arrive_temp];

		i++;

		chemin[longueur_chemin - i] = arrive_temp;
	}
	
	return chemin;
}

int* GenererChemin(Graphe G, int* pred, int depart, int arrivee, int *longueur_chemin)
{
	*longueur_chemin = CpteLongueurChemin(pred, depart, arrivee);

	int* chemin = ConstruireChemin(pred, depart, arrivee, *longueur_chemin);

	return chemin;
}

string* GenererCheminNom(Graphe G, int* chemin, int longueur_chemin)
{
	string* chemin_nom = new string[longueur_chemin];

	for (int i = 0; i < longueur_chemin; i++)
	{
		chemin_nom[i] = G.ObtNomSommet(chemin[i] + 1);
	}

	return chemin_nom;
}

float CalculerCoutChemin(float* dist, int arrivee) { return dist[arrivee]; }

///////////////////////////////////////////////// Fonctions pour la partie sortie de l'interface \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

void AfficherChemin(string* chemin, int longueur)
{
	for (int i = 0; i < longueur; i++)
	{
		cout << chemin[i];

		if (i != longueur - 1)
		{
			cout << " --> ";
		}
	}

	cout << endl << endl;
}

void AfficherLigne(Graphe G, int* chemin, int longueur)
{
	string ligne, nouvelle_ligne;

	for (int i = 0; i < longueur - 1; i++)
	{
		nouvelle_ligne = G.ObtArc(chemin[i] + 1, chemin[i + 1] + 1).ObtLigneMetro().nom_metro;

		if (nouvelle_ligne != ligne && nouvelle_ligne != "")
		{
			cout.width(10);

			ligne = nouvelle_ligne;

			cout << ligne;
		}
	}

	cout << endl << endl;
}

void AttendreQuitter()
{
	string reponse;

	do
	{
		cout << "Appuyez sur 'Entrer' pour quitter..." << endl;
		getline(cin, reponse);
	}
	while (reponse == "\n");
}

void AfficherResultat(Graphe G, int* chemin, int* pred, string* chemin_nom, int longueur_chemin, float cout_chemin)
{
	cout << "--------------------- Résultat de la recherche ---------------------" << endl << endl;
	
	cout << "Meilleur trajet : " << endl << endl;

	AfficherChemin(chemin_nom, longueur_chemin);

	cout << "Durée du trajet : " << endl << endl;

	cout << cout_chemin << " minutes" << endl << endl;

	cout << "Ligne à emprunter : " << endl << endl;

	AfficherLigne(G, chemin, longueur_chemin);

	cout << "--------------------------------------------------------------------" << endl << endl;

	AttendreQuitter();
}

///////////////////////////////////////////////// Fonction principale de l'application \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

void calculateurItineraire()
{
	// Création du graphe
	int nb_sommet, nb_arc;

	string chemin_fichier_table_ligne = "./TABLE_BD/LIGNE.csv",
		chemin_fichier_table_arret = "./TABLE_BD/ARRET.csv",
		chemin_fichier_table_distance = "./TABLE_BD/DISTANCE.csv",
		chemin_fichier_table_est_desservi = "./TABLE_BD/EST_DESSERVI.csv";

	Sommet* liste_sommet = GenererListeSommet(chemin_fichier_table_arret, &nb_sommet);

	Graphe G(liste_sommet, nb_sommet);

	Arc* liste_arc = GenererListeArc(G, chemin_fichier_table_ligne, chemin_fichier_table_distance, chemin_fichier_table_est_desservi, &nb_arc);

	G.InitListeArc(liste_arc, nb_arc);

	G.CalculerMatriceAdjacence();

	float** matrice = G.ObtMatriceAdjacence();

	// Code pour gérer la partie entrée de l'application
	int depart, arrivee;

	SaisieUtilisateur(G, &depart, &arrivee);

	// Code de la partie qui calcule l'initinéraire
	int longueur_chemin;

	int* pred = new int[nb_sommet];

	float* dist = new float[nb_sommet];

	Bellman(G, depart, pred, dist);

	int* chemin = GenererChemin(G, pred, depart, arrivee, &longueur_chemin);

	string* chemin_nom = GenererCheminNom(G, chemin, longueur_chemin);

	float cout_chemin = CalculerCoutChemin(dist, arrivee);

	// Code pour afficher le résultat
	AfficherResultat(G, chemin, pred, chemin_nom, longueur_chemin, cout_chemin);
}

///////////////////////////////////////////////// Fonction main \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

int main()
{
	calculateurItineraire();	
}