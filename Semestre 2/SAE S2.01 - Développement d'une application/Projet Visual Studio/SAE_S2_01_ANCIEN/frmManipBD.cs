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

        private void FermApp(object sender, FormClosedEventArgs e)
        {
            BD.FermerConnexion();
        }

        private bool ConfAvantInsert()
        {
            DialogResult reponse = MessageBox.Show("Voulez-vous ajouter cet enregistrement ou ces enregistrements à la base ?", "Confirmation avant ajout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            bool confirmation = (reponse == DialogResult.Yes);

            return confirmation;
        }

        private bool ConfAvantModif()
        {
            DialogResult reponse = MessageBox.Show("Voulez-vous modifer cet enregistrement ou ces enregistrements de la base ?", "Confirmation avant modification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            bool confirmation = (reponse == DialogResult.Yes);

            return confirmation;
        }

        private bool ConfAvantSuppr()
        {
            DialogResult reponse = MessageBox.Show("Voulez-vous supprimer cet enregistrement ou ces enregistrements de la base ?", "Confirmation avant suprression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            bool confirmation = (reponse == DialogResult.Yes);

            return confirmation;
        }

        private void ConfSuccess()
        {
            if (BD.succes)
            {
                MessageBox.Show("L'opération a été réalisé avec succès !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("L'opération a échoué.\n", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

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

        private void AffArret(DataGridView vueBD)
        {
            vueBD.Rows.Clear();

            vueBD.ColumnCount = 3;

            vueBD.Columns[0].Name = "numArret";
            vueBD.Columns[1].Name = "nomArret";
            vueBD.Columns[2].Name = "adrArret";

            if(vueBD != vueBDInsert)
            {
                string[][] matrice = BD.ObtDonnArret();

                for (int i = 0; i < BD.ObtNbEnreg("ARRET"); i++)
                {
                    vueBD.Rows.Add(matrice[i]);
                }
            }
        }

        private void AffDistance(DataGridView vueBD)
        {
            vueBD.Rows.Clear();

            vueBD.ColumnCount = 3;

            vueBD.Columns[0].Name = "numArret1";
            vueBD.Columns[1].Name = "numArret2";
            vueBD.Columns[2].Name = "distArret";

            if(vueBD != vueBDInsert)
            {
                string[][] matrice = BD.ObtDonnDistance();

                for (int i = 0; i < BD.ObtNbEnreg("DISTANCE"); i++)
                {
                    vueBD.Rows.Add(matrice[i]);
                }
            }
        }

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

        private string[][] LectureDonneeInsert()
        {
            int nbLigne = vueBDInsert.Rows.Count - 1;
            int nbColonne = vueBDInsert.Columns.Count;

            string[][] matrice = new string[nbLigne][];

            for (int i = 0; i < nbLigne; i++)
            {
                matrice[i] = new string[nbColonne];

                for (int j = 0; j < nbColonne; j++)
                {
                    if (vueBDInsert.Rows[i].Cells[j].Value != null)
                    {
                        matrice[i][j] = vueBDInsert.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }

            return matrice;
        }

        private bool VerifDonneeInsertNonNull(string[][] matrice)
        {
            bool correct = true;

            for (int i = 0; i < matrice.Length; i++)
            {
                for(int j = 0; j < matrice[i].Length; j++)
                {
                    if (matrice[i][j] == null)
                    {
                        correct = false;
                    }
                }
            }

            return correct;
        }

        private void ValiderInsert(object sender, EventArgs e)
        {
            string[][] matrice = LectureDonneeInsert();

            if (ConfAvantInsert())
            {
                if (VerifDonneeInsertNonNull(matrice) && matrice.Length != 0)
                {
                    switch (menuDeroulInsert.SelectedIndex)
                    {
                        case 0:
                            BD.InsertDonnee("LIGNE", matrice);
                            break;

                        case 1:
                            BD.InsertDonnee("ARRET", matrice);
                            break;

                        case 2:
                            BD.InsertDonnee("DISTANCE", matrice);
                            break;

                        case 3:
                            BD.InsertDonnee("EST_DESSERVI", matrice);
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

        private void SelectTable(object sender, EventArgs e)
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

        private string[][] ObtIdDonneeSuppr()
        {
            int nbMaxID = 2;
            int nbLigne = vueBDSuppr.SelectedRows.Count;
            string[][] tabID = new string[nbLigne][];

            for(int i=0; i<nbLigne; i++)
            {
                tabID[i] = new string[nbMaxID];

                tabID[i][0] = vueBDSuppr.SelectedRows[i].Cells[0].Value.ToString();
                tabID[i][1] = vueBDSuppr.SelectedRows[i].Cells[1].Value.ToString();
            }

            return tabID;
        }

        private void ValiderSuppr(object sender, EventArgs e)
        {
            string[][] listID = ObtIdDonneeSuppr();

            if (ConfAvantSuppr())
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

        private List<DataGridViewRow> LectureDonneeModif(string[][] enregOriginal)
        {
            List<DataGridViewRow> ligne = new List<DataGridViewRow>();

            for (int i = 0; i < vueBDModif.RowCount; i++)
            {
                for( int j = 0; j < vueBDModif.ColumnCount; j++)
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

        private string[][] ConvertirEnTableauString(List<DataGridViewRow> matrice_entree)
        {
            string[][] matrice = new string[matrice_entree.Count][];

            for(int i = 0; i < matrice_entree.Count; i++)
            {
                matrice[i] = new string[matrice_entree[i].Cells.Count];

                for(int j = 0; j < matrice_entree[i].Cells.Count; j++)
                {
                    matrice[i][j] = matrice_entree[i].Cells[j].Value.ToString();
                }
            }

            return matrice;
        }

        private void ModifBD(string nomTable)
        {
            string[][] original;
            string[][] modifs;
            List<List<string>> clePrims;

            switch (nomTable)
            {
                case "LIGNE":
                    original = BD.ObtDonnLigne();
                    modifs = ConvertirEnTableauString(LectureDonneeModif(original));
                    clePrims = ObtIdDonneeModif(original);
                    BD.ModifDonnee("LIGNE", modifs, clePrims);
                    break;

                case "ARRET":
                    original = BD.ObtDonnArret();
                    modifs = ConvertirEnTableauString(LectureDonneeModif(original));
                    clePrims = ObtIdDonneeModif(original);
                    BD.ModifDonnee("ARRET", modifs, clePrims);
                    AffArret(vueBDModif);
                    break;

                case "DISTANCE":
                    original = BD.ObtDonnDistance();
                    modifs = ConvertirEnTableauString(LectureDonneeModif(original));
                    clePrims = ObtIdDonneeModif(original);
                    BD.ModifDonnee("DISTANCE", modifs, clePrims);
                    AffDistance(vueBDModif);
                    break;

                case "EST_DESSERVI":
                    original = BD.ObtDonnEstDesservi();
                    modifs = ConvertirEnTableauString(LectureDonneeModif(original));
                    clePrims = ObtIdDonneeModif(original);
                    BD.ModifDonnee("EST_DESSERVI", modifs, clePrims);
                    AffEstDesservi(vueBDModif);                    
                    break;
            }
        }

        private void ValiderModif(object sender, EventArgs e)
        {
            if (ConfAvantModif())
            {
                switch (menuDeroulModif.SelectedIndex)
                {
                    case 0:
                        ModifBD("LIGNE");
                        AffLigne(vueBDModif);
                        break;

                    case 1:
                        ModifBD("ARRET");
                        AffArret(vueBDModif);
                        break;

                    case 2:
                        ModifBD("DISTANCE");
                        AffDistance(vueBDModif);
                        break;

                    case 3:
                        ModifBD("EST_DESSERVI");
                        break;
                }

                ConfSuccess();
            }
        }

        private void VerifSaisieEntier(DataGridView vueBD, DataGridViewCellValidatingEventArgs e)
        {
            bool estUnNombre = int.TryParse(e.FormattedValue.ToString(), out int temp); ;

            if (!estUnNombre)
            {
                MessageBox.Show("Vous devez entrer un entier. Veuillez réessayer.", "Erreur - Type incorrect", MessageBoxButtons.OK, MessageBoxIcon.Error);

                vueBD.CancelEdit();
            }
        }

        private void VerifSaisieReel(DataGridView vueBD, DataGridViewCellValidatingEventArgs e)
        {
            bool estUnNombre = double.TryParse(e.FormattedValue.ToString(), out double temp); ;

            if (!estUnNombre)
            {
                MessageBox.Show("Vous devez entrer un nombre réel. Veuillez réessayer.", "Erreur - Type incorrect", MessageBoxButtons.OK, MessageBoxIcon.Error);

                vueBD.CancelEdit();
            }
        }

        private void VerifSaisieHeure(DataGridView vueBD, DataGridViewCellValidatingEventArgs e)
        {
            bool estUneHeure = TimeSpan.TryParse(e.FormattedValue.ToString(), out TimeSpan temp);

            if (!estUneHeure)
            {
                MessageBox.Show("Vous devez utiliser ce format : 'HH:MM:SS'.\nVeuillez réessayer.", "Erreur - Type format incorrect", MessageBoxButtons.OK, MessageBoxIcon.Error);

                vueBD.CancelEdit();
            }
        }

        private void VerifSaisieChaine(DataGridView vueBD, DataGridViewCellValidatingEventArgs e, int nbCar)
        {
            bool nomEstLong = e.FormattedValue.ToString().Length > nbCar;

            if (nomEstLong)
            {
                MessageBox.Show("Vous avez saisi une chaîne de caractères trop long. Veuillez réessayer.", "Erreur - Chaîne de caractères trop long", MessageBoxButtons.OK, MessageBoxIcon.Error);

                vueBD.CancelEdit();
            }
        }

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