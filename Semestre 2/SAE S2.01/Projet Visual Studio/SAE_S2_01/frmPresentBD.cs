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
    public partial class frmPresentBD : Form
    {
        public frmPresentBD()
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

            AffArretMenuDeroulLigne();

            AffLigneMenuDeroulHoraireLigne();
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
        /// Cette fonction permet d'obtenir sous forme de liste tout les temps de passage du métro d'une heure choisi.
        /// </summary>
        /// <param name="heurePremPassage">Premier passage du métro à l'arrêt.</param>
        /// <param name="limite">Heure où on veut obtenir tout les temps de passages.</param>
        /// <param name="freqLigne">La fréquence du métro.</param>
        /// <returns>Liste contenant les temps de passages du métro sur l'heure choisi.</returns>
        private List<TimeSpan> ObtListHoraire(TimeSpan heurePremPassage, TimeSpan limite, TimeSpan freqLigne)
        {
            List<TimeSpan> listeHoraire = new List<TimeSpan>();

            while (heurePremPassage < limite)
            {
                if (heurePremPassage > limite - new TimeSpan(1, 0, 0))
                {
                    listeHoraire.Add(heurePremPassage);
                }
                
                heurePremPassage += freqLigne;
            }

            return listeHoraire;
        }

        /// <summary>
        /// Cette fonction permet d'obtenir le tableau contenant les horaires.
        /// </summary>
        /// <param name="numLigne">Identifiant de la ligne.</param>
        /// <param name="nomArret">Nom de l'arrêt.</param>
        /// <returns>Tableau contenant les horaires</returns>
        private List<List<TimeSpan>> ObtTableauHoraire(int numLigne, string nomArret)
        {
            List<List<TimeSpan>> tableauHoraire = new List<List<TimeSpan>>();

            List<TimeSpan> listHoraire;

            TimeSpan heurePremPassage = BD.ObtHeurePremPassage(numLigne, nomArret);

            TimeSpan freqLigne = BD.ObtFreqLigne(numLigne);

            TimeSpan limite = new TimeSpan(6, 0, 0);

            TimeSpan uneHeure = new TimeSpan(1, 0, 0);

            for (int i = 0; i < 18; i++)
            {
                listHoraire = ObtListHoraire(heurePremPassage, limite, freqLigne);

                tableauHoraire.Add(listHoraire);

                heurePremPassage = listHoraire.Last() + freqLigne;

                limite += uneHeure;
            }

            return tableauHoraire;
        }

        /// <summary>
        /// Cette fonction permet de convertir le tableau des horaires en string et nous permet aussi d'obtenir que les minutes pour l'affichage.
        /// </summary>
        /// <param name="tableauHoraire">Tableau contenant les horaires.</param>
        /// <returns>Tableau des horaires où uniquement les minutes sont gardées et sont converti en string</returns>
        private List<List<string>> ConvertirTableauHoraireMinutes(List<List<TimeSpan>> tableauHoraire)
        {
            List<List<string>> tableauHoraireMinutes = new List<List<string>>();

            foreach (List<TimeSpan> listeHoraire in tableauHoraire)
            {
                List<string> listeHoraireMinutes = new List<string>();

                foreach (TimeSpan horaire in listeHoraire)
                {
                    listeHoraireMinutes.Add(horaire.Minutes.ToString());
                }

                tableauHoraireMinutes.Add(listeHoraireMinutes);
            }

            return tableauHoraireMinutes;
        }

        /// <summary>
        /// Cette procédure permet d'afficher les arrêts.
        /// </summary>
        /// <param name="listeArret">Liste de tout les arrêts qu'on veut afficher.</param>
        private void AffArret(List<string> listeArret)
        {
            listBoxArret.Items.Clear();

            foreach (string arret in listeArret)
            {
                listBoxArret.Items.Add(arret);
            }
        }

        /// <summary>
        /// Afficher les lignes dans le menu déroulant pour présenter les lignes.
        /// </summary>
        private void AffArretMenuDeroulLigne()
        {
            List<string> listeLigne = BD.ObtLigne();
            
            foreach (string ligne in listeLigne)
            {
                menuDeroulLigne.Items.Add(ligne);
            }
        }

        /// <summary>
        /// Cette procédure permet d'afficher les arrêts dans le menu déroulant pour choisir les horaires à l'arrêt.
        /// </summary>
        /// <param name="listeArret">Liste des arrêts.</param>
        private void AffArretMenuDeroul(List<string> listeArret)
        {
            menuDeroulHoraireArret.Items.Clear();

            foreach (string Arret in listeArret)
            {
                menuDeroulHoraireArret.Items.Add(Arret);
            }
        }
        
        /// <summary>
        /// Cette procédure permet d'afficher les horaires.
        /// </summary>
        /// <param name="tableauHoraire">Tableau des horaires où on a gardé que les minutes.</param>
        private void AffHoraire(List<List<string>> tableauHoraire)
        {
            vueBDHoraire.Columns.Clear();
            vueBDHoraire.Rows.Clear();

            vueBDHoraire.ColumnCount = 18;
            vueBDHoraire.RowCount = 16;

            for(int i = 0; i < vueBDHoraire.ColumnCount; i++)
            {
                vueBDHoraire.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

                vueBDHoraire.Columns[i].Name = Convert.ToString(i + 5);

                for (int j = 0; j < vueBDHoraire.RowCount; j++)
                {
                    if (j < tableauHoraire[i].Count)
                    {
                        vueBDHoraire.Rows[j].Cells[i].Value = tableauHoraire[i][j];
                    }
                    
                }
            }
        }

        /// <summary>
        /// Cette procédure contient le code pour gérer la présentation de la ligne choisi.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PresentationLigne(object sender, EventArgs e)
        {
            string nomLigne = menuDeroulLigne.SelectedItem.ToString().Split(new string[] { "  " }, StringSplitOptions.None)[1];

            string nomTerminus = menuDeroulLigne.SelectedItem.ToString().Split(new string[] { "  " }, StringSplitOptions.None)[5];

            int numLigne = BD.ObtIDLigne(nomLigne, nomTerminus);

            List<string> listeArret = BD.ObtArret(numLigne);

            AffArret(listeArret);
        }

        /// <summary>
        /// Cette procédure permet d'afficher les lignes dans le menu deroulant pour choisir les horaires à l'arrêt.
        /// </summary>
        private void AffLigneMenuDeroulHoraireLigne()
        {
            List<string> listeLigne = BD.ObtLigne();

            foreach(string ligne in listeLigne)
            {
                menuDeroulHoraireLigne.Items.Add(ligne);
            }
        }

        /// <summary>
        /// Cette procédure contient le code pour afficher les arrêts dans le menu déroulant des arrêt pour selectionner les horaires à l'arrêt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectionHoraireLigne(object sender, EventArgs e)
        {
            string nomLigne = menuDeroulHoraireLigne.SelectedItem.ToString().Split(new string[] { "  " }, StringSplitOptions.None)[1];

            string nomTerminus = menuDeroulHoraireLigne.SelectedItem.ToString().Split(new string[] { "  " }, StringSplitOptions.None)[5];

            int numLigne = BD.ObtIDLigne(nomLigne, nomTerminus);

            List<string> listeArret = BD.ObtArretSansTerminus(numLigne);

            AffArretMenuDeroul(listeArret);
        }

        /// <summary>
        /// Cette procédure permet de présenter les horaires à l'arrêt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PresentationHoraire(object sender, EventArgs e)
        {
            string nomLigne = menuDeroulHoraireLigne.SelectedItem.ToString().Split(new string[] { "  " }, StringSplitOptions.None)[1];

            string nomTerminus = menuDeroulHoraireLigne.SelectedItem.ToString().Split(new string[] { "  " }, StringSplitOptions.None)[5];

            int numLigne = BD.ObtIDLigne(nomLigne, nomTerminus);

            string nomArret = menuDeroulHoraireArret.SelectedItem.ToString();
            
            List<List<TimeSpan>> tableauHoraire = ObtTableauHoraire(numLigne, nomArret);

            List<List<string>> tableauHoraireMinutes = ConvertirTableauHoraireMinutes(tableauHoraire);

            AffHoraire(tableauHoraireMinutes);
        }
    }
}