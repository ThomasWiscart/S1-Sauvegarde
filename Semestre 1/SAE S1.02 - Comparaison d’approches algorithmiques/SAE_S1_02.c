/**
 * Procédure de tri par sélection selon l'ordre lexicographique.
 *
 * Cette procédure effectue un tri par sélection sur une liste d'étudiants en utilisant l'ordre lexicographique de leur nom de famille.
 * Le tri par sélection consiste à trouver à chaque itération le plus petit élément restant dans la liste et à l'échanger avec l'élément à la position actuelle.
 * Cela permet de placer progressivement les éléments dans l'ordre croissant.
 *
 * @param liste La liste d'éléments de type étudiant à trier.
 * @param deb L'indice de début de la liste.
 * @param fin L'indice de fin de la liste.
 */
void triSelect(listEtud liste, int deb, int fin){
    // ...
}
/*
Auteurs: Annaïs Tchewo Kewe, Victor Guenez-Charles, Thomas Wiscart et Colins Neil Nimalaraj
*/

#include <stdio.h>
#include <string.h>
#define N 1000

typedef char chaine[20];

typedef struct etudiant etud;

struct etudiant {
    chaine prenom;
    chaine nom;
    int id;
};

typedef etud listEtud[N];

/**************************************** Procédures pour les messages d'erreurs ****************************************/

void erreurFichier(){
    /**
    description: Procédure qui affiche les messages d'erreurs
    */

    printf("\n");
    printf("Le fichier est introuvable\n");
    printf("Vérifier si le fichier est dans le même emplacement que le code source ou bien qu'il se nomme 'Liste1000niveau2'\n");
    printf("Après avoir régler le problème veuillez redémarrer le programme\n");
    printf("\n");

}

/**************************************** Procédures d'entré/sortie ****************************************/

int lecture(listEtud liste){
    /**
    description: Fonction pour la lecture du fichier
    entrée:
        liste: Liste d'éléments de type étudiant (listEtud)
    sortie:
        code_sortie: Code permettant d'indiquer si ça a marché (int)
    */

    FILE* fichier = NULL; // Pointeur du fichier à lire

    fichier = fopen("Liste1000niveau2.txt", "r");

    int code_sortie = 1; // Le code est égal à 1 lorqu'il y a pas d'erreur

    if (fichier != NULL){ // Si on trouve le fichier

        for (int i=0; i<N; i++){
            fscanf(fichier, "%s %s %d", &liste[i].prenom, &liste[i].nom, &liste[i].id);
        }

    } else {

        code_sortie = 0;
        erreurFichier();

    }

    fclose(fichier); // On ferme le fichier et on libère la mémoire

    return code_sortie;
}

void ecriture(listEtud liste) {
    /**
    description: Procédure pour l'écriture du fichier
    entrée:
        liste: Liste d'éléments de type étudiant (listEtud)
    */

    FILE* fichier = NULL; // Pointeur du fichier à lire

    fichier = fopen("Fichier_out.txt", "w");

    for(int i=0; i<N; i++){
        fprintf(fichier, "%s\t%s\t%d\n", liste[i].prenom, liste[i].nom, liste[i].id);
    }

    fclose(fichier);
}

/**************************************** Fonctions/Procédures utiles ****************************************/

void echanger(listEtud liste, int a, int b){
    /**
    description: Procédure pour échanger deux étudiants dans la liste
    entrée:
        liste: Liste d'éléments de type étudiant (listEtud)
        a: Indice d'un élément du tableau de type etud (int)
        b: Indice d'un élément du tableau de type etud (int)
    */

    etud temp;

    temp = liste[a];
    liste[a] = liste[b];
    liste[b] = temp;
}

void afficher(listEtud liste){
    /**
    decription: Procédure pour afficher la liste (debug)
    entrée:
        liste: Liste d'éléments de type étudiant (listEtud)
    */

    for (int i=0; i<N; i++){
        printf("%10s %10s %10d\n", liste[i].prenom, liste[i].nom, liste[i].id);
    }
}


/**************************************** Tri selection ****************************************/

int premOrdreLexico(listEtud liste, int deb, int fin){
    /**
    description: Fonction qui retourne l'indice du premier élément (nom de famille) d'une liste selon l'ordre lexicographique
    entrée:
        liste: Liste d'éléments de type étudiant (listEtud)
        deb: Indice de début de la liste (int)
        fin: Indice de fin de la liste (int)
    sortie:
        prem: Indice du premier élément (int)
    */

    int prem = deb;

    for (int i=deb+1; i<fin; i++){

        if ( strcmp(liste[prem].nom, liste[i].nom) == 1){ // liste[prem].nom > liste[i].nom
            prem = i;
        }

    }

    return prem;
}

void triSelect(listEtud liste, int deb, int fin){
    /**
    description: Procédure de tri par sélection selon l'ordre lexicographique
    entrée:
        liste: Liste d'éléments de type étudiant (listEtud)
        deb: Indice de début de la liste (int)
        fin: Indice de fin de la liste (int)
    */

    int ind_prem;

    for (int i=deb; i<fin; i++){

        ind_prem = premOrdreLexico(liste, i, fin);
        echanger(liste, ind_prem, i);

    }
}


/**************************************** Tri rapide ****************************************/

int partition(listEtud liste, int g, int d){
    /**
    description: Cette procédure met les élément plus petit que le pivot à gauche et les plus grand à droite, le pivot est le début de la liste
    entrée:
        liste: Liste d'éléments de type étudiant (listEtud)
        g: Indice de début de la liste (int)
        d: Indice de fin de la liste (int)
    sortie:
        j: (int)
    */

    etud pivot = liste[g]; // On défini l'étudiant en début de liste comme pivot
    int i = g; // On fait commencer l'indice i au début
    int j = d; // On fait commencer l'indice j à la fin

    // Cette boucle met j au premier plus petit élément trouvé (par rapport au pivot)
    while (strcmp(liste[j].nom, pivot.nom) == 1){ // (liste[j].nom > pivot.nom)
        j -= 1;
    }

    while (i<j){ // On vérifie si c'est pas un tableau d'un élément

        echanger(liste, i, j);

        // Cette boucle met j au premier plus petit élément trouvé (par rapport au pivot)
        do{
            j -= 1;
        } while (strcmp(liste[j].nom, pivot.nom) == 1); // (liste[j].nom > pivot.nom)

        // Cette boucle met i au premier plus grand élément trouvé (par rapport au pivot)
        do{
            i += 1;
        } while (strcmp(liste[i].nom, pivot.nom) == -1); // (liste[i].nom < pivot.nom)

    }

    return j;
}

void triRapide(listEtud liste, int g, int d){
    /**
    description: Procédure de tri par sélection selon l'ordre lexicographique
    entrée:
        liste: Liste d'éléments de type étudiant (listEtud)
        g: Indice de début de la liste (int)
        d: Indice de fin de la liste (int)
    */

    int p;

    if ( g < d ){
        p = partition(liste, g, d);
        triRapide(liste, g, p);
        triRapide(liste, p+1, d);
    }
}

/**************************************** Interface ****************************************/

void choixTri(listEtud liste){
    /**
    description: Procédure permetant de choisir un type de tri et de le lancer
    entrée:
        liste: Liste d'éléments de type étudiant (listEtud)
    */
    int choix;

    do{
        printf("\nVeuillez sélectionner un tri\n");
        printf("1: Tri par sélection\n2: Tri rapide\n");
        scanf("%d", &choix);

        switch(choix){
            case 1:
                printf("\nLe tri par sélection a été sélectionné\n");
                printf("Lancement du tri...\n");
                triSelect(liste, 0, N-1);
                printf("Tri fini...\n\n");
                break;
            case 2:
                printf("\nLe tri rapide a été sélectionné\n");
                printf("Lancement du tri...\n");
                triRapide(liste, 0, N-1);
                printf("Tri fini...\n\n");
                break;
            default:
                printf("\nPour choisir un tri entrer 1 ou 2...\n");
                break;
        }
    } while(choix != 1 && choix != 2);

    printf("\n");
}

void choixEcriture(listEtud liste){
    /**
    description: Procédure qui demande à l'utilisateur si il veut créer un fichier de sortie (peut écraser un ancien fichier du même nom)
    entrée:
        liste: Liste d'éléments de type étudiant (listEtud)
    */

    char choix;

    do{
        printf("Voulez-vous écrire un fichier nommé 'Fichier_Out' ? (o/n)\n");
        scanf(" %c", &choix);

        if (choix == 'o' || choix == 'O'){
            ecriture(liste);
            printf("Le fichier a été créé\n");
        } else {
            printf("Le fichier n'a pas été créé\n");
        }
    } while (choix != 'o' && choix != 'n' && choix != 'O' && choix != 'N');

    printf("\n");
}

void choixContinuer(int *continuer){
    /**
    description: Procédure qui demande à l'utilisateur si il veut quitter
    entrée:
        contiuer: Variable qui permet de faire tourner le prgramme (int en paramètre)
    */

    char choix;

    do{
        printf("Voulez-vous quitter ? (o/n)\n");
        scanf(" %c", &choix);

        if (choix == 'o' || choix == 'O'){
            *continuer = 0;
            printf("Vous avez quitté\n");
        } else {
            *continuer = 1;
        }
    } while (choix != 'o' && choix != 'n' && choix != 'O' && choix != 'N');

    printf("\n");
}

/**************************************** Procédure principale ****************************************/

int main(){
    int continuer;

    listEtud liste_etudiant;

    printf("Auteurs: Annaïs Tchewo Kewe, Victor Guenez-Charles, Thomas Wiscart et Colins Neil Nimalaraj\n\n\n");
    printf("----------------------------------------------------------------------------------------------------------------------\n");

    continuer = lecture(liste_etudiant);

    while(continuer){

        choixTri(liste_etudiant);

        choixEcriture(liste_etudiant);

        choixContinuer(&continuer);

    }

    printf("----------------------------------------------------------------------------------------------------------------------\n\n");
}
