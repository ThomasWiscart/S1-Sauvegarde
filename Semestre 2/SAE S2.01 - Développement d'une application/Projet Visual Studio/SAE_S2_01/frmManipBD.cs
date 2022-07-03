using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConnexionBD;

namespace SAE_S2_01
{
    public partial class frmManipBD : Form
    {
        public frmManipBD()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Cette procédure permet d'initialiser l'application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InitApp(object sender, EventArgs e)
        {
            BD.InitConnexion();

            menuDeroulInsert.SelectedIndex = 0;
            AffLigne(vueBDInsert);

            menuDeroulModif.SelectedIndex = 0;
            AffLigne(vueBDModif);

            menuDeroulSuppr.SelectedIndex = 0;
            AffLigne(vueBDSuppr);
        }

        /// <summary>
        /// Cette procédure permet de fermer la connexion à la BD.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FermApp(object sender, FormClosedEventArgs e)
        {
            BD.FermerConnexion();
        }

        /// <summary>
        /// Cette fonction permet d'afficher un message de confirmation.
        /// </summary>
        /// <param name="titre">Titre de la fenêtre.</param>
        /// <param name="msg">Texte de la fenêtre.</param>
        /// <returns>Réponse de l'utilisateur.</returns>
        private bool ConfAvantManipBD(string titre, string msg)
        {
            DialogResult reponse = MessageBox.Show(msg, titre, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            bool confirmation = (reponse == DialogResult.Yes);

            return confirmation;
        }

        /// <summary>
        /// Cette procédure affiche les messages d'erreurs.
        /// </summary>
        private void ConfSuccess()
        {
            if (BD.succes)
            {
                MessageBox.Show("L'opération a été réalisé avec succès !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"L'opération a échoué.\n\nDétails :\n{BD.msgErreur}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Cette procédure permet d'afficher la table "LIGNE".
        /// </summary>
        /// <param name="vueBD">Un DataGridView où on veut afficher la table.</param>
        private void AffLigne(DataGridView vueBD)
        {
            vueBD.Rows.Clear();

            vueBD.ColumnCount = 6;

            vueBD.Columns[0].Name = "numLigne";
            vueBD.Columns[1].Name = "nomLigne";
            vueBD.Columns[2].Name = "freqLigne";
            vueBD.Columns[3].Name = "vitMoyLigne";
            vueBD.Columns[4].Name = "numArretDep";
            vueBD.Columns[5].Name = "numArretArr";

            if (vueBD != vueBDInsert)
            {
                string[][] matrice = BD.ObtDonnLigne();

                for (int i = 0; i < BD.ObtNbEnreg("LIGNE"); i++)
                {
                    vueBD.Rows.Add(matrice[i]);
                }
            }
        }

        /// <summary>
        /// Cette procédure permet d'afficher la table "ARRET".
        /// </summary>
        /// <param name="vueBD">Un DataGridView où on veut afficher la table.</param>
        private void AffArret(DataGridView vueBD)
        {
            vueBD.Rows.Clear();

            vueBD.ColumnCount = 3;

            vueBD.Columns[0].Name = "numArret";
            vueBD.Columns[1].Name = "nomArret";
            vueBD.Columns[2].Name = "adrArret";

            if (vueBD != vueBDInsert)
            {
                string[][] matrice = BD.ObtDonnArret();

                for (int i = 0; i < BD.ObtNbEnreg("ARRET"); i++)
                {
                    vueBD.Rows.Add(matrice[i]);
                }
            }
        }

        /// <summary>
        /// Cette procédure permet d'afficher la table "DISTANCE".
        /// </summary>
        /// <param name="vueBD">Un DataGridView où on veut afficher la table.</param>
        private void AffDistance(DataGridView vueBD)
        {
            vueBD.Rows.Clear();

            vueBD.ColumnCount = 3;

            vueBD.Columns[0].Name = "numArret1";
            vueBD.Columns[1].Name = "numArret2";
            vueBD.Columns[2].Name = "distArret";

            if (vueBD != vueBDInsert)
            {
                string[][] matrice = BD.ObtDonnDistance();

                for (int i = 0; i < BD.ObtNbEnreg("DISTANCE"); i++)
                {
                    vueBD.Rows.Add(matrice[i]);
                }
            }
        }

        /// <summary>
        /// Cette procédure permet d'afficher la table "EST_DESSERVI".
        /// </summary>
        /// <param name="vueBD">Un DataGridView où on veut afficher la table.</param>
        private void AffEstDesservi(DataGridView vueBD)
        {
            vueBD.Rows.Clear();

            vueBD.ColumnCount = 4;

            vueBD.Columns[0].Name = "numLigne";
            vueBD.Columns[1].Name = "numArret";
            vueBD.Columns[2].Name = "heurePremPassage";
            vueBD.Columns[3].Name = "numArretSuiv";

            if (vueBD != vueBDInsert)
            {
                string[][] matrice = BD.ObtDonnEstDesservi();

                for (int i = 0; i < BD.ObtNbEnreg("EST_DESSERVI"); i++)
                {
                    vueBD.Rows.Add(matrice[i]);
                }
            }
        }

        /// <summary>
        /// Cette fonction permet d'obtenir les données que l'utilisateur à saisi pour l'insertion à la BD.
        /// </summary>
        /// <returns>Liste des enregistrents que l'utilisateur veut insérer.</returns>
        private string[][] LectureDonneeInsert()
        {
            int nbLigne = vueBDInsert.Rows.Count - 1;
            int nbColonne = vueBDInsert.Columns.Count;

            string[][] listeEnregistrement = new string[nbLigne][];

            for (int i = 0; i < nbLigne; i++)
            {
                listeEnregistrement[i] = new string[nbColonne];

                for (int j = 0; j < nbColonne; j++)
                {
                    if (vueBDInsert.Rows[i].Cells[j].Value != null)
                    {
                        listeEnregistrement[i][j] = vueBDInsert.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }

            return listeEnregistrement;
        }

        /// <summary>
        /// Cette fonction permet de vérifier si l'utilisateur n'a pas saisi de valeurs nulls (la BD n'accepte pas les valeurs nulls) pour l'insertion à la BD.
        /// </summary>
        /// <param name="listeEnregistrement">Liste des enregistrements que l'utisateur veut insérer.</param>
        /// <returns>Résultat qui permet de savoir si la saisie est correct.</returns>
        private bool VerifDonneeInsertNonNull(string[][] listeEnregistrement)
        {
            bool correct = true;

            for (int i = 0; i < listeEnregistrement.Length; i++)
            {
                for (int j = 0; j < listeEnregistrement[i].Length; j++)
                {
                    if (listeEnregistrement[i][j] == null)
                    {
                        correct = false;
                    }
                }
            }

            return correct;
        }

        /// <summary>
        /// Cette procédure permet l'insertion des enregistrements à la BD.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Insertion(object sender, EventArgs e)
        {
            string[][] listeEnregistrement = LectureDonneeInsert();

            if (ConfAvantManipBD("Confirmation avant ajout", "Voulez-vous ajouter cet enregistrement ou ces enregistrements à la base ?"))
            {
                if (VerifDonneeInsertNonNull(listeEnregistrement) && listeEnregistrement.Length != 0)
                {
                    switch (menuDeroulInsert.SelectedIndex)
                    {
                        case 0:
                            BD.InsertDonnee("LIGNE", listeEnregistrement);
                            break;

                        case 1:
                            BD.InsertDonnee("ARRET", listeEnregistrement);
                            break;

                        case 2:
                            BD.InsertDonnee("DISTANCE", listeEnregistrement);
                            break;

                        case 3:
                            BD.InsertDonnee("EST_DESSERVI", listeEnregistrement);
                            break;
                    }

                    ConfSuccess();
                }
                else
                {
                    MessageBox.Show("Vous avez laissé un champs ou des champs vide(s).\nVeuillez revérifier votre saisie.", "Erreur - Type 'NULL'", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Cette procédure permet d'afficher la table "LIGNE" dans l'onglet voulu.
        /// </summary>
        /// <param name="nomMenuDeroul">Le menu déroulant qui permet de determiner dans quel onglet on veut afficher la table.</param>
        private void AffVueBDTableLigne(string nomMenuDeroul)
        {
            switch (nomMenuDeroul)
            {
                case "menuDeroulInsert":
                    AffLigne(vueBDInsert);
                    break;

                case "menuDeroulModif":
                    AffLigne(vueBDModif);
                    break;

                case "menuDeroulSuppr":
                    AffLigne(vueBDSuppr);
                    break;
            }
        }

        /// <summary>
        /// Cette procédure permet d'afficher la table "ARRET" dans l'onglet voulu.
        /// </summary>
        /// <param name="nomMenuDeroul">Le menu déroulant qui permet de determiner dans quel onglet on veut afficher la table.</param>
        private void AffVueBDTableArret(string nomMenuDeroul)
        {
            switch (nomMenuDeroul)
            {
                case "menuDeroulInsert":
                    AffArret(vueBDInsert);
                    break;

                case "menuDeroulModif":
                    AffArret(vueBDModif);
                    break;

                case "menuDeroulSuppr":
                    AffArret(vueBDSuppr);
                    break;
            }
        }

        /// <summary>
        /// Cette procédure permet d'afficher la table "DISTANCE" dans l'onglet voulu.
        /// </summary>
        /// <param name="nomMenuDeroul">Le menu déroulant qui permet de determiner dans quel onglet on veut afficher la table.</param>
        private void AffVueBDTableDistance(string nomMenuDeroul)
        {
            switch (nomMenuDeroul)
            {
                case "menuDeroulInsert":
                    AffDistance(vueBDInsert);
                    break;

                case "menuDeroulModif":
                    AffDistance(vueBDModif);
                    break;

                case "menuDeroulSuppr":
                    AffDistance(vueBDSuppr);
                    break;
            }
        }

        /// <summary>
        /// Cette procédure permet d'afficher la table "EST_DESSERVI" dans l'onglet voulu.
        /// </summary>
        /// <param name="nomMenuDeroul">Le menu déroulant qui permet de determiner dans quel onglet on veut afficher la table.</param>
        private void AffVueBDTableEstDesservi(string nomMenuDeroul)
        {
            switch (nomMenuDeroul)
            {
                case "menuDeroulInsert":
                    AffEstDesservi(vueBDInsert);
                    break;

                case "menuDeroulModif":
                    AffEstDesservi(vueBDModif);
                    break;

                case "menuDeroulSuppr":
                    AffEstDesservi(vueBDSuppr);
                    break;
            }
        }

        /// <summary>
        /// Cette procédure permet d'afficher les différentes tables de la BD.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AfficherTable(object sender, EventArgs e)
        {
            ComboBox menuDeroul = (ComboBox)sender;

            switch (menuDeroul.SelectedIndex)
            {
                case 0:
                    AffVueBDTableLigne(menuDeroul.Name);
                    break;

                case 1:
                    AffVueBDTableArret(menuDeroul.Name);
                    break;

                case 2:
                    AffVueBDTableDistance(menuDeroul.Name);
                    break;

                case 3:
                    AffVueBDTableEstDesservi(menuDeroul.Name);
                    break;
            }
        }

        /// <summary>
        /// Cette fonction permet d'obtenir la liste des clés primaires des enregistrements qu'on veut supprimer.
        /// </summary>
        /// <returns>Liste des clés primaires identifiant les enregistrements.</returns>
        private string[][] ObtIdDonneeSuppr()
        {
            int nbMaxAttribut = 2;
            int nbLigne = vueBDSuppr.SelectedRows.Count;
            string[][] listeClePrim = new string[nbLigne][];

            for (int i = 0; i < nbLigne; i++)
            {
                listeClePrim[i] = new string[nbMaxAttribut];

                listeClePrim[i][0] = vueBDSuppr.SelectedRows[i].Cells[0].Value.ToString();
                listeClePrim[i][1] = vueBDSuppr.SelectedRows[i].Cells[1].Value.ToString();
            }

            return listeClePrim;
        }

        /// <summary>
        /// Cette fonction permet de supprimer les enregistrements choisi par l'utilisateur.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Suppression(object sender, EventArgs e)
        {
            string[][] listID = ObtIdDonneeSuppr();

            if (ConfAvantManipBD("Confirmation avant suprression", "Voulez-vous supprimer cet enregistrement ou ces enregistrements de la base ?"))
            {
                switch (menuDeroulSuppr.SelectedIndex)
                {
                    case 0:
                        BD.SupprDonnee("LIGNE", listID);
                        AffLigne(vueBDSuppr);
                        break;

                    case 1:
                        BD.SupprDonnee("ARRET", listID);
                        AffArret(vueBDSuppr);
                        break;

                    case 2:
                        BD.SupprDonnee("DISTANCE", listID);
                        AffDistance(vueBDSuppr);
                        break;

                    case 3:
                        BD.SupprDonnee("EST_DESSERVI", listID);
                        AffEstDesservi(vueBDSuppr);
                        break;
                }

                ConfSuccess();
            }
        }

        /// <summary>
        /// Cette fonction permet d'obtenir les enregistrements modifiés par l'utilisateur.
        /// </summary>
        /// <param name="enregOriginal">Liste de tout les enregistrements non-modifés de la BD.</param>
        /// <returns>Liste des enregistrements modifiés par l'utilisateur.</returns>
        private List<DataGridViewRow> LectureDonneeModif(string[][] enregOriginal)
        {
            List<DataGridViewRow> ligne = new List<DataGridViewRow>();

            for (int i = 0; i < vueBDModif.RowCount; i++)
            {
                for (int j = 0; j < vueBDModif.ColumnCount; j++)
                {
                    if (enregOriginal[i][j] != vueBDModif.Rows[i].Cells[j].Value.ToString())
                    {
                        if (!ligne.Contains(vueBDModif.Rows[i]))
                        {
                            ligne.Add(vueBDModif.Rows[i]);
                        }
                    }
                }
            }

            return ligne;
        }

        /// <summary>
        /// Cette fonction permet d'obtenir la liste des clés primaires identifiant les enregistrement modifiés.
        /// </summary>
        /// <param name="enregOriginal">Liste de tout les enregistrements non-modifés de la BD.</param>
        /// <returns>Liste des clés primaires identifiant les enregistrement modifiés.</returns>
        private List<List<string>> ObtIdDonneeModif(string[][] enregOriginal)
        {
            List<DataGridViewRow> ligne = new List<DataGridViewRow>();

            List<List<string>> clePrims = new List<List<string>>();

            for (int i = 0; i < enregOriginal.Length; i++)
            {
                for (int j = 0; j < enregOriginal[i].Length; j++)
                {
                    if (enregOriginal[i][j] != vueBDModif.Rows[i].Cells[j].Value.ToString())
                    {
                        if (!ligne.Contains(vueBDModif.Rows[i]))
                        {
                            ligne.Add(vueBDModif.Rows[i]);

                            List<string> clePrim = new List<string>();

                            clePrim.Add(enregOriginal[i][0]);
                            clePrim.Add(enregOriginal[i][1]);

                            clePrims.Add(clePrim);
                        }
                    }
                }
            }

            return clePrims;
        }

        /// <summary>
        /// Cette fonction permet de convertir les données saisi par l'utilisateur en string.
        /// </summary>
        /// <param name="listeEnregistrementEntree">Liste des enregistrements modifiés par l'utilisateur.</param>
        /// <returns>Liste des enregistrements modifiés par l'utilisateur en string.</returns>
        private string[][] ConvertirEnString(List<DataGridViewRow> listeEnregistrementEntree)
        {
            string[][] listeEnregistrement = new string[listeEnregistrementEntree.Count][];

            for (int i = 0; i < listeEnregistrementEntree.Count; i++)
            {
                listeEnregistrement[i] = new string[listeEnregistrementEntree[i].Cells.Count];

                for (int j = 0; j < listeEnregistrementEntree[i].Cells.Count; j++)
                {
                    listeEnregistrement[i][j] = listeEnregistrementEntree[i].Cells[j].Value.ToString();
                }
            }

            return listeEnregistrement;
        }

        /// <summary>
        /// Cette procédure permet d'appliquer les modifications à la BD.
        /// </summary>
        /// <param name="nomTable">Nom de la table à modifier</param>
        private void AppliquerModificationBD(string nomTable)
        {
            string[][] original;
            string[][] modifs;
            List<List<string>> clePrims;

            switch (nomTable)
            {
                case "LIGNE":
                    original = BD.ObtDonnLigne();
                    modifs = ConvertirEnString(LectureDonneeModif(original));
                    clePrims = ObtIdDonneeModif(original);
                    BD.ModifDonnee("LIGNE", modifs, clePrims);
                    break;

                case "ARRET":
                    original = BD.ObtDonnArret();
                    modifs = ConvertirEnString(LectureDonneeModif(original));
                    clePrims = ObtIdDonneeModif(original);
                    BD.ModifDonnee("ARRET", modifs, clePrims);
                    AffArret(vueBDModif);
                    break;

                case "DISTANCE":
                    original = BD.ObtDonnDistance();
                    modifs = ConvertirEnString(LectureDonneeModif(original));
                    clePrims = ObtIdDonneeModif(original);
                    BD.ModifDonnee("DISTANCE", modifs, clePrims);
                    AffDistance(vueBDModif);
                    break;

                case "EST_DESSERVI":
                    original = BD.ObtDonnEstDesservi();
                    modifs = ConvertirEnString(LectureDonneeModif(original));
                    clePrims = ObtIdDonneeModif(original);
                    BD.ModifDonnee("EST_DESSERVI", modifs, clePrims);
                    AffEstDesservi(vueBDModif);
                    break;
            }
        }

        /// <summary>
        /// Cette procédure gère la modification de la BD.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Modification(object sender, EventArgs e)
        {
            if (ConfAvantManipBD("Confirmation avant modification", "Voulez-vous modifer cet enregistrement ou ces enregistrements de la base ?"))
            {
                switch (menuDeroulModif.SelectedIndex)
                {
                    case 0:
                        AppliquerModificationBD("LIGNE");
                        AffLigne(vueBDModif);
                        break;

                    case 1:
                        AppliquerModificationBD("ARRET");
                        AffArret(vueBDModif);
                        break;

                    case 2:
                        AppliquerModificationBD("DISTANCE");
                        AffDistance(vueBDModif);
                        break;

                    case 3:
                        AppliquerModificationBD("EST_DESSERVI");
                        break;
                }

                ConfSuccess();
            }
        }

        /// <summary>
        /// Cette procédure permet de vérifier la saisi d'un entier.
        /// </summary>
        /// <param name="vueBD">Le DataGridView dans lequel on veut vérifier la saisie.</param>
        /// <param name="e">Les événements de ce DataGridView.</param>
        private void VerifSaisieEntier(DataGridView vueBD, DataGridViewCellValidatingEventArgs e)
        {
            bool estUnNombre = int.TryParse(e.FormattedValue.ToString(), out int temp); ;

            if (!estUnNombre)
            {
                MessageBox.Show("Vous devez entrer un entier. Veuillez réessayer.", "Erreur - Type incorrect", MessageBoxButtons.OK, MessageBoxIcon.Error);

                vueBD.CancelEdit();
            }
        }

        /// <summary>
        /// Cette procédure permet de vérifier la saisi d'un réel.
        /// </summary>
        /// <param name="vueBD">Le DataGridView dans lequel on veut vérifier la saisie.</param>
        /// <param name="e">Les événements de ce DataGridView.</param>
        private void VerifSaisieReel(DataGridView vueBD, DataGridViewCellValidatingEventArgs e)
        {
            bool estUnNombre = double.TryParse(e.FormattedValue.ToString(), out double temp); ;

            if (!estUnNombre)
            {
                MessageBox.Show("Vous devez entrer un nombre réel. Veuillez réessayer.", "Erreur - Type incorrect", MessageBoxButtons.OK, MessageBoxIcon.Error);

                vueBD.CancelEdit();
            }
        }

        /// <summary>
        /// Cette procédure permet de vérifier la saisi d'une heure.
        /// </summary>
        /// <param name="vueBD">Le DataGridView dans lequel on veut vérifier la saisie.</param>
        /// <param name="e">Les événements de ce DataGridView.</param>
        private void VerifSaisieHeure(DataGridView vueBD, DataGridViewCellValidatingEventArgs e)
        {
            bool estUneHeure = TimeSpan.TryParse(e.FormattedValue.ToString(), out TimeSpan temp);

            if (!estUneHeure)
            {
                MessageBox.Show("Vous devez utiliser ce format : 'HH:MM:SS'.\nVeuillez réessayer.", "Erreur - Type format incorrect", MessageBoxButtons.OK, MessageBoxIcon.Error);

                vueBD.CancelEdit();
            }
        }

        /// <summary>
        /// Cette procédure assure que l'utilisateur saisi une chaine de caractères avec une longueur correct.
        /// </summary>
        /// <param name="vueBD">Le DataGridView dans lequel on veut vérifier la saisie.</param>
        /// <param name="e">Les événements de ce DataGridView.</param>
        /// <param name="nbCar">Le nombres de caractères qui limite la chaine de caractères saisi par l'utilisateur.</param>
        private void VerifSaisieChaine(DataGridView vueBD, DataGridViewCellValidatingEventArgs e, int nbCar)
        {
            bool nomEstLong = e.FormattedValue.ToString().Length > nbCar;

            if (nomEstLong)
            {
                MessageBox.Show("Vous avez saisi une chaîne de caractères trop long. Veuillez réessayer.", "Erreur - Chaîne de caractères trop long", MessageBoxButtons.OK, MessageBoxIcon.Error);

                vueBD.CancelEdit();
            }
        }

        /// <summary>
        /// Cette procédure verifie la saisie de données pour la table "LIGNE".
        /// </summary>
        /// <param name="vueBD">Le DataGridView dans lequel on veut vérifier la saisie.</param>
        /// <param name="e">Les événements de ce DataGridView.</param>
        private void VerifSaisieTableLigne(DataGridView vueBD, DataGridViewCellValidatingEventArgs e)
        {
            if (vueBD.Columns[0].Name == "numLigne" && vueBD.Columns[1].Name == "nomLigne")
            {
                switch (e.ColumnIndex)
                {
                    case 0:
                        VerifSaisieEntier(vueBD, e);
                        break;

                    case 1:
                        VerifSaisieChaine(vueBD, e, 2);
                        break;

                    case 2:
                        VerifSaisieHeure(vueBD, e);
                        break;

                    case 3:
                        VerifSaisieReel(vueBD, e);
                        break;

                    case 4:
                        VerifSaisieEntier(vueBD, e);
                        break;
                }
            }
        }

        /// <summary>
        /// Cette procédure verifie la saisie de données pour la table "ARRET".
        /// </summary>
        /// <param name="vueBD">Le DataGridView dans lequel on veut vérifier la saisie.</param>
        /// <param name="e">Les événements de ce DataGridView.</param>
        private void VerifSaisieTableArret(DataGridView vueBD, DataGridViewCellValidatingEventArgs e)
        {
            if (vueBD.Columns[0].Name == "numArret")
            {
                switch (e.ColumnIndex)
                {
                    case 0:
                        VerifSaisieEntier(vueBD, e);
                        break;

                    case 1:
                        VerifSaisieChaine(vueBD, e, 30);
                        break;

                    case 2:
                        VerifSaisieChaine(vueBD, e, 50);
                        break;
                }
            }
        }

        /// <summary>
        /// Cette procédure verifie la saisie de données pour la table "DISTANCE".
        /// </summary>
        /// <param name="vueBD">Le DataGridView dans lequel on veut vérifier la saisie.</param>
        /// <param name="e">Les événements de ce DataGridView.</param>
        private void VerifSaisieTableDistance(DataGridView vueBD, DataGridViewCellValidatingEventArgs e)
        {
            if (vueBD.Columns[0].Name == "numArret1" && vueBD.Columns[1].Name == "numArret2")
            {
                switch (e.ColumnIndex)
                {
                    case 2:
                        VerifSaisieReel(vueBD, e);
                        break;

                    default:
                        VerifSaisieEntier(vueBD, e);
                        break;
                }
            }
        }

        /// <summary>
        /// Cette procédure verifie la saisie de données pour la table "EST_DESSERVI".
        /// </summary>
        /// <param name="vueBD">Le DataGridView dans lequel on veut vérifier la saisie.</param>
        /// <param name="e">Les événements de ce DataGridView.</param>
        private void VerifSaisieTableEstDesservi(DataGridView vueBD, DataGridViewCellValidatingEventArgs e)
        {
            if (vueBD.Columns[0].Name == "numLigne" && vueBD.Columns[1].Name == "numArret")
            {
                switch (e.ColumnIndex)
                {
                    case 2:
                        VerifSaisieHeure(vueBD, e);
                        break;

                    default:
                        VerifSaisieEntier(vueBD, e);
                        break;
                }
            }
        }

        /// <summary>
        /// Cette procédure permet la vérification des données saisi par l'utilisateur dans tout l'application.
        /// </summary>
        /// <param name="sender">Les différents DataGridViews</param>
        /// <param name="e">Les événements de ce DataGridView.</param>
        private void VerifSaisie(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridView vueBD = (DataGridView)sender;

            VerifSaisieTableLigne(vueBD, e);
            VerifSaisieTableArret(vueBD, e);
            VerifSaisieTableDistance(vueBD, e);
            VerifSaisieTableEstDesservi(vueBD, e);
        }
    }
}
