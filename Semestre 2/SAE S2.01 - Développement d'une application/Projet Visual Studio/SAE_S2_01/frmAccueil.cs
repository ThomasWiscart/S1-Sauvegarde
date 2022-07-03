using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAE_S2_01
{
    public partial class frmAccueil : Form
    {
        public frmAccueil()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Cette procédure permet de lancer le formlaire pour manipuler la BD.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OuvrirFrmManipBD(object sender, EventArgs e)
        {
            frmManipBD frm = new frmManipBD();
            frm.ShowDialog();
        }

        /// <summary>
        /// Cette procédure permet de lancer le formulaire pour présenter les données de la BD.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OuvrirFrmPresentBD(object sender, EventArgs e)
        {
            frmPresentBD frm = new frmPresentBD();
            frm.ShowDialog();
        }
    }
}
