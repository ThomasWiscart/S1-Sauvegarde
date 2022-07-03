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

        private void InitApp(object sender, EventArgs e)
        {
            BD.InitConnexion();
        }

        private List<TimeSpan> ObtListHoraire(TimeSpan heurePremPassage, TimeSpan limite, TimeSpan freqLigne)
        {
            List<TimeSpan> listeHoraire = new List<TimeSpan>();

            while (heurePremPassage < limite)
            {
                listeHoraire.Add(heurePremPassage);

                heurePremPassage += freqLigne;
            }

            return listeHoraire;
        }

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

                heurePremPassage = listHoraire.Last();

                limite += uneHeure;
            }

            return tableauHoraire;
        }

        private List<List<string>> ConvertirTableauHoraireMinutes(List<List<TimeSpan>> tableauHoraire)
        {
            List<List<string>> tableauHoraireMinutes = new List<List<string>>();

            foreach(List<TimeSpan> listeHoraire in tableauHoraire)
            {
                List<string> listeHoraireMinutes = new List<string>();

                foreach(TimeSpan horaire in listeHoraire)
                {
                    listeHoraireMinutes.Add(horaire.Minutes.ToString());
                }

                tableauHoraireMinutes.Add(listeHoraireMinutes);
            }

            return tableauHoraireMinutes;
        }

        private void FermApp(object sender, FormClosedEventArgs e)
        {
            BD.FermerConnexion();
        }

        private void AffArret(List<string> listeArret)
        {
            listBoxArret.Items.Clear();

            foreach(string arret in listeArret)
            {
                listBoxArret.Items.Add(arret);
            }
        }

        private void AffArretMenuDeroul(List<string> listeArret, int numLigne)
        {
            menuDerouHoraireArret.Items.Clear();
            
            foreach (string Arret in listeArret)
            {
                menuDerouHoraireArret.Items.Add(Arret);
            }
        }

        private void SelectionLigne(object sender, EventArgs e)
        {
            int numLigne = menuDeroulLigne.SelectedIndex + 1;

            List<string> listeArret = BD.ObtArret(numLigne);

            AffArret(listeArret);
        }

        private void SelectionHoraireLigne(object sender, EventArgs e)
        {
            int numLigne = menuDeroulHoraireLigne.SelectedIndex + 1;

            List<string> listeArret = BD.ObtArret(numLigne);

            AffArretMenuDeroul(listeArret, numLigne);
        }

    }
}