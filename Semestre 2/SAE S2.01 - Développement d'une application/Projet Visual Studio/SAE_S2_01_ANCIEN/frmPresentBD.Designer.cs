namespace SAE_S2_01
{
    partial class frmPresentBD
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControlsPresentBD = new System.Windows.Forms.TabControl();
            this.ongletReseau = new System.Windows.Forms.TabPage();
            this.pnlImgReseau = new System.Windows.Forms.Panel();
            this.imgReseau = new System.Windows.Forms.PictureBox();
            this.ongletLigne = new System.Windows.Forms.TabPage();
            this.listBoxArret = new System.Windows.Forms.ListBox();
            this.lblLigne = new System.Windows.Forms.Label();
            this.menuDeroulLigne = new System.Windows.Forms.ComboBox();
            this.ongletHoraire = new System.Windows.Forms.TabPage();
            this.lblHoaireArret = new System.Windows.Forms.Label();
            this.menuDerouHoraireArret = new System.Windows.Forms.ComboBox();
            this.lblHoraireLigne = new System.Windows.Forms.Label();
            this.menuDeroulHoraireLigne = new System.Windows.Forms.ComboBox();
            this.tabControlsPresentBD.SuspendLayout();
            this.ongletReseau.SuspendLayout();
            this.pnlImgReseau.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReseau)).BeginInit();
            this.ongletLigne.SuspendLayout();
            this.ongletHoraire.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlsPresentBD
            // 
            this.tabControlsPresentBD.Controls.Add(this.ongletReseau);
            this.tabControlsPresentBD.Controls.Add(this.ongletLigne);
            this.tabControlsPresentBD.Controls.Add(this.ongletHoraire);
            this.tabControlsPresentBD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlsPresentBD.Location = new System.Drawing.Point(0, 0);
            this.tabControlsPresentBD.Name = "tabControlsPresentBD";
            this.tabControlsPresentBD.SelectedIndex = 0;
            this.tabControlsPresentBD.Size = new System.Drawing.Size(800, 450);
            this.tabControlsPresentBD.TabIndex = 0;
            // 
            // ongletReseau
            // 
            this.ongletReseau.Controls.Add(this.pnlImgReseau);
            this.ongletReseau.Location = new System.Drawing.Point(4, 22);
            this.ongletReseau.Name = "ongletReseau";
            this.ongletReseau.Padding = new System.Windows.Forms.Padding(3);
            this.ongletReseau.Size = new System.Drawing.Size(792, 424);
            this.ongletReseau.TabIndex = 0;
            this.ongletReseau.Text = "Réseau";
            this.ongletReseau.UseVisualStyleBackColor = true;
            // 
            // pnlImgReseau
            // 
            this.pnlImgReseau.AutoScroll = true;
            this.pnlImgReseau.Controls.Add(this.imgReseau);
            this.pnlImgReseau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImgReseau.Location = new System.Drawing.Point(3, 3);
            this.pnlImgReseau.Name = "pnlImgReseau";
            this.pnlImgReseau.Size = new System.Drawing.Size(786, 418);
            this.pnlImgReseau.TabIndex = 0;
            // 
            // imgReseau
            // 
            this.imgReseau.Image = global::SAE_S2_01.Properties.Resources.plan_metro_lyon;
            this.imgReseau.Location = new System.Drawing.Point(0, 0);
            this.imgReseau.Name = "imgReseau";
            this.imgReseau.Size = new System.Drawing.Size(767, 1043);
            this.imgReseau.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgReseau.TabIndex = 0;
            this.imgReseau.TabStop = false;
            // 
            // ongletLigne
            // 
            this.ongletLigne.Controls.Add(this.listBoxArret);
            this.ongletLigne.Controls.Add(this.lblLigne);
            this.ongletLigne.Controls.Add(this.menuDeroulLigne);
            this.ongletLigne.Location = new System.Drawing.Point(4, 22);
            this.ongletLigne.Name = "ongletLigne";
            this.ongletLigne.Padding = new System.Windows.Forms.Padding(3);
            this.ongletLigne.Size = new System.Drawing.Size(792, 424);
            this.ongletLigne.TabIndex = 1;
            this.ongletLigne.Text = "Ligne";
            this.ongletLigne.UseVisualStyleBackColor = true;
            // 
            // listBoxArret
            // 
            this.listBoxArret.FormattingEnabled = true;
            this.listBoxArret.Location = new System.Drawing.Point(46, 110);
            this.listBoxArret.Name = "listBoxArret";
            this.listBoxArret.Size = new System.Drawing.Size(700, 264);
            this.listBoxArret.TabIndex = 4;
            // 
            // lblLigne
            // 
            this.lblLigne.Location = new System.Drawing.Point(46, 29);
            this.lblLigne.Name = "lblLigne";
            this.lblLigne.Size = new System.Drawing.Size(700, 23);
            this.lblLigne.TabIndex = 3;
            this.lblLigne.Text = "Choix de la ligne";
            this.lblLigne.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuDeroulLigne
            // 
            this.menuDeroulLigne.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.menuDeroulLigne.FormattingEnabled = true;
            this.menuDeroulLigne.Items.AddRange(new object[] {
            "Ligne MA en direction de Vaulx-en-Velin La Soie",
            "Ligne MA en direction de Perrache",
            "Ligne MB en direction Gare d’Oullins",
            "Ligne MB en direction Charpennes",
            "Ligne MC en direction Cuire",
            "Ligne MC en direction Hôtel de Ville",
            "Ligne MD en direction Gare de Vénissieux",
            "Ligne MD en direction Gare de Vaise"});
            this.menuDeroulLigne.Location = new System.Drawing.Point(46, 55);
            this.menuDeroulLigne.Name = "menuDeroulLigne";
            this.menuDeroulLigne.Size = new System.Drawing.Size(700, 21);
            this.menuDeroulLigne.TabIndex = 2;
            this.menuDeroulLigne.SelectionChangeCommitted += new System.EventHandler(this.SelectionLigne);
            // 
            // ongletHoraire
            // 
            this.ongletHoraire.Controls.Add(this.lblHoaireArret);
            this.ongletHoraire.Controls.Add(this.menuDerouHoraireArret);
            this.ongletHoraire.Controls.Add(this.lblHoraireLigne);
            this.ongletHoraire.Controls.Add(this.menuDeroulHoraireLigne);
            this.ongletHoraire.Location = new System.Drawing.Point(4, 22);
            this.ongletHoraire.Name = "ongletHoraire";
            this.ongletHoraire.Padding = new System.Windows.Forms.Padding(3);
            this.ongletHoraire.Size = new System.Drawing.Size(792, 424);
            this.ongletHoraire.TabIndex = 2;
            this.ongletHoraire.Text = "Horaire";
            this.ongletHoraire.UseVisualStyleBackColor = true;
            // 
            // lblHoaireArret
            // 
            this.lblHoaireArret.Location = new System.Drawing.Point(46, 95);
            this.lblHoaireArret.Name = "lblHoaireArret";
            this.lblHoaireArret.Size = new System.Drawing.Size(700, 23);
            this.lblHoaireArret.TabIndex = 7;
            this.lblHoaireArret.Text = "Choix de l\'arrêt";
            this.lblHoaireArret.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuDerouHoraireArret
            // 
            this.menuDerouHoraireArret.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.menuDerouHoraireArret.FormattingEnabled = true;
            this.menuDerouHoraireArret.Location = new System.Drawing.Point(46, 122);
            this.menuDerouHoraireArret.Name = "menuDerouHoraireArret";
            this.menuDerouHoraireArret.Size = new System.Drawing.Size(700, 21);
            this.menuDerouHoraireArret.TabIndex = 6;
            // 
            // lblHoraireLigne
            // 
            this.lblHoraireLigne.Location = new System.Drawing.Point(46, 28);
            this.lblHoraireLigne.Name = "lblHoraireLigne";
            this.lblHoraireLigne.Size = new System.Drawing.Size(700, 23);
            this.lblHoraireLigne.TabIndex = 5;
            this.lblHoraireLigne.Text = "Choix de la ligne";
            this.lblHoraireLigne.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuDeroulHoraireLigne
            // 
            this.menuDeroulHoraireLigne.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.menuDeroulHoraireLigne.FormattingEnabled = true;
            this.menuDeroulHoraireLigne.Items.AddRange(new object[] {
            "Ligne MA en direction de Vaulx-en-Velin La Soie",
            "Ligne MA en direction de Perrache",
            "Ligne MB en direction Gare d’Oullins",
            "Ligne MB en direction Charpennes",
            "Ligne MC en direction Cuire",
            "Ligne MC en direction Hôtel de Ville",
            "Ligne MD en direction Gare de Vénissieux",
            "Ligne MD en direction Gare de Vaise"});
            this.menuDeroulHoraireLigne.Location = new System.Drawing.Point(46, 55);
            this.menuDeroulHoraireLigne.Name = "menuDeroulHoraireLigne";
            this.menuDeroulHoraireLigne.Size = new System.Drawing.Size(700, 21);
            this.menuDeroulHoraireLigne.TabIndex = 4;
            this.menuDeroulHoraireLigne.SelectionChangeCommitted += new System.EventHandler(this.SelectionHoraireLigne);
            // 
            // frmPresentBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControlsPresentBD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmPresentBD";
            this.Text = "Présentation des données de la base de donnée";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FermApp);
            this.Load += new System.EventHandler(this.InitApp);
            this.tabControlsPresentBD.ResumeLayout(false);
            this.ongletReseau.ResumeLayout(false);
            this.pnlImgReseau.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgReseau)).EndInit();
            this.ongletLigne.ResumeLayout(false);
            this.ongletHoraire.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlsPresentBD;
        private System.Windows.Forms.TabPage ongletReseau;
        private System.Windows.Forms.TabPage ongletLigne;
        private System.Windows.Forms.TabPage ongletHoraire;
        private System.Windows.Forms.Panel pnlImgReseau;
        private System.Windows.Forms.PictureBox imgReseau;
        private System.Windows.Forms.ComboBox menuDeroulLigne;
        private System.Windows.Forms.Label lblLigne;
        private System.Windows.Forms.ListBox listBoxArret;
        private System.Windows.Forms.Label lblHoraireLigne;
        private System.Windows.Forms.ComboBox menuDeroulHoraireLigne;
        private System.Windows.Forms.Label lblHoaireArret;
        private System.Windows.Forms.ComboBox menuDerouHoraireArret;
    }
}