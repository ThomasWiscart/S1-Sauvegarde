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
            this.tabControlPresent = new System.Windows.Forms.TabControl();
            this.ongletReseau = new System.Windows.Forms.TabPage();
            this.pnlReseau = new System.Windows.Forms.Panel();
            this.imgReseau = new System.Windows.Forms.PictureBox();
            this.ongletLigne = new System.Windows.Forms.TabPage();
            this.listBoxArret = new System.Windows.Forms.ListBox();
            this.menuDeroulLigne = new System.Windows.Forms.ComboBox();
            this.lblLigne = new System.Windows.Forms.Label();
            this.ongletHoraire = new System.Windows.Forms.TabPage();
            this.vueBDHoraire = new System.Windows.Forms.DataGridView();
            this.menuDeroulHoraireArret = new System.Windows.Forms.ComboBox();
            this.lblHoraireArret = new System.Windows.Forms.Label();
            this.menuDeroulHoraireLigne = new System.Windows.Forms.ComboBox();
            this.lblHoraireLigne = new System.Windows.Forms.Label();
            this.tabControlPresent.SuspendLayout();
            this.ongletReseau.SuspendLayout();
            this.pnlReseau.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReseau)).BeginInit();
            this.ongletLigne.SuspendLayout();
            this.ongletHoraire.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vueBDHoraire)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlPresent
            // 
            this.tabControlPresent.Controls.Add(this.ongletReseau);
            this.tabControlPresent.Controls.Add(this.ongletLigne);
            this.tabControlPresent.Controls.Add(this.ongletHoraire);
            this.tabControlPresent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPresent.Location = new System.Drawing.Point(0, 0);
            this.tabControlPresent.Name = "tabControlPresent";
            this.tabControlPresent.SelectedIndex = 0;
            this.tabControlPresent.Size = new System.Drawing.Size(800, 450);
            this.tabControlPresent.TabIndex = 0;
            // 
            // ongletReseau
            // 
            this.ongletReseau.Controls.Add(this.pnlReseau);
            this.ongletReseau.Location = new System.Drawing.Point(4, 22);
            this.ongletReseau.Name = "ongletReseau";
            this.ongletReseau.Padding = new System.Windows.Forms.Padding(3);
            this.ongletReseau.Size = new System.Drawing.Size(792, 424);
            this.ongletReseau.TabIndex = 0;
            this.ongletReseau.Text = "Réseau";
            this.ongletReseau.UseVisualStyleBackColor = true;
            // 
            // pnlReseau
            // 
            this.pnlReseau.AutoScroll = true;
            this.pnlReseau.Controls.Add(this.imgReseau);
            this.pnlReseau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlReseau.Location = new System.Drawing.Point(3, 3);
            this.pnlReseau.Name = "pnlReseau";
            this.pnlReseau.Size = new System.Drawing.Size(786, 418);
            this.pnlReseau.TabIndex = 0;
            // 
            // imgReseau
            // 
            this.imgReseau.Image = global::SAE_S2_01.Properties.Resources.plan_metro_lyon;
            this.imgReseau.Location = new System.Drawing.Point(0, 0);
            this.imgReseau.Name = "imgReseau";
            this.imgReseau.Size = new System.Drawing.Size(765, 1000);
            this.imgReseau.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgReseau.TabIndex = 0;
            this.imgReseau.TabStop = false;
            // 
            // ongletLigne
            // 
            this.ongletLigne.Controls.Add(this.listBoxArret);
            this.ongletLigne.Controls.Add(this.menuDeroulLigne);
            this.ongletLigne.Controls.Add(this.lblLigne);
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
            this.listBoxArret.Location = new System.Drawing.Point(3, 62);
            this.listBoxArret.Name = "listBoxArret";
            this.listBoxArret.Size = new System.Drawing.Size(786, 329);
            this.listBoxArret.TabIndex = 2;
            // 
            // menuDeroulLigne
            // 
            this.menuDeroulLigne.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuDeroulLigne.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.menuDeroulLigne.FormattingEnabled = true;
            this.menuDeroulLigne.Location = new System.Drawing.Point(3, 26);
            this.menuDeroulLigne.Name = "menuDeroulLigne";
            this.menuDeroulLigne.Size = new System.Drawing.Size(786, 21);
            this.menuDeroulLigne.TabIndex = 1;
            this.menuDeroulLigne.SelectionChangeCommitted += new System.EventHandler(this.PresentationLigne);
            // 
            // lblLigne
            // 
            this.lblLigne.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLigne.Location = new System.Drawing.Point(3, 3);
            this.lblLigne.Name = "lblLigne";
            this.lblLigne.Size = new System.Drawing.Size(786, 23);
            this.lblLigne.TabIndex = 3;
            this.lblLigne.Text = "Choix de la ligne";
            this.lblLigne.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ongletHoraire
            // 
            this.ongletHoraire.Controls.Add(this.vueBDHoraire);
            this.ongletHoraire.Controls.Add(this.menuDeroulHoraireArret);
            this.ongletHoraire.Controls.Add(this.lblHoraireArret);
            this.ongletHoraire.Controls.Add(this.menuDeroulHoraireLigne);
            this.ongletHoraire.Controls.Add(this.lblHoraireLigne);
            this.ongletHoraire.Location = new System.Drawing.Point(4, 22);
            this.ongletHoraire.Name = "ongletHoraire";
            this.ongletHoraire.Padding = new System.Windows.Forms.Padding(3);
            this.ongletHoraire.Size = new System.Drawing.Size(792, 424);
            this.ongletHoraire.TabIndex = 2;
            this.ongletHoraire.Text = "Horaire";
            this.ongletHoraire.UseVisualStyleBackColor = true;
            // 
            // vueBDHoraire
            // 
            this.vueBDHoraire.AllowUserToAddRows = false;
            this.vueBDHoraire.AllowUserToDeleteRows = false;
            this.vueBDHoraire.AllowUserToResizeColumns = false;
            this.vueBDHoraire.AllowUserToResizeRows = false;
            this.vueBDHoraire.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vueBDHoraire.Location = new System.Drawing.Point(3, 113);
            this.vueBDHoraire.Name = "vueBDHoraire";
            this.vueBDHoraire.ReadOnly = true;
            this.vueBDHoraire.Size = new System.Drawing.Size(786, 278);
            this.vueBDHoraire.TabIndex = 3;
            // 
            // menuDeroulHoraireArret
            // 
            this.menuDeroulHoraireArret.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuDeroulHoraireArret.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.menuDeroulHoraireArret.FormattingEnabled = true;
            this.menuDeroulHoraireArret.Location = new System.Drawing.Point(3, 70);
            this.menuDeroulHoraireArret.Name = "menuDeroulHoraireArret";
            this.menuDeroulHoraireArret.Size = new System.Drawing.Size(786, 21);
            this.menuDeroulHoraireArret.TabIndex = 2;
            this.menuDeroulHoraireArret.SelectionChangeCommitted += new System.EventHandler(this.PresentationHoraire);
            // 
            // lblHoraireArret
            // 
            this.lblHoraireArret.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHoraireArret.Location = new System.Drawing.Point(3, 47);
            this.lblHoraireArret.Name = "lblHoraireArret";
            this.lblHoraireArret.Size = new System.Drawing.Size(786, 23);
            this.lblHoraireArret.TabIndex = 5;
            this.lblHoraireArret.Text = "Choix de l\'arrêt";
            this.lblHoraireArret.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuDeroulHoraireLigne
            // 
            this.menuDeroulHoraireLigne.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuDeroulHoraireLigne.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.menuDeroulHoraireLigne.FormattingEnabled = true;
            this.menuDeroulHoraireLigne.Location = new System.Drawing.Point(3, 26);
            this.menuDeroulHoraireLigne.Name = "menuDeroulHoraireLigne";
            this.menuDeroulHoraireLigne.Size = new System.Drawing.Size(786, 21);
            this.menuDeroulHoraireLigne.TabIndex = 1;
            this.menuDeroulHoraireLigne.SelectionChangeCommitted += new System.EventHandler(this.SelectionHoraireLigne);
            // 
            // lblHoraireLigne
            // 
            this.lblHoraireLigne.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHoraireLigne.Location = new System.Drawing.Point(3, 3);
            this.lblHoraireLigne.Name = "lblHoraireLigne";
            this.lblHoraireLigne.Size = new System.Drawing.Size(786, 23);
            this.lblHoraireLigne.TabIndex = 4;
            this.lblHoraireLigne.Text = "Choix de la ligne";
            this.lblHoraireLigne.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmPresentBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControlPresent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmPresentBD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Presentation des données de la base de données";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FermApp);
            this.Load += new System.EventHandler(this.InitApp);
            this.tabControlPresent.ResumeLayout(false);
            this.ongletReseau.ResumeLayout(false);
            this.pnlReseau.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgReseau)).EndInit();
            this.ongletLigne.ResumeLayout(false);
            this.ongletHoraire.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vueBDHoraire)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlPresent;
        private System.Windows.Forms.TabPage ongletReseau;
        private System.Windows.Forms.TabPage ongletLigne;
        private System.Windows.Forms.TabPage ongletHoraire;
        private System.Windows.Forms.Panel pnlReseau;
        private System.Windows.Forms.PictureBox imgReseau;
        private System.Windows.Forms.ListBox listBoxArret;
        private System.Windows.Forms.ComboBox menuDeroulLigne;
        private System.Windows.Forms.Label lblLigne;
        private System.Windows.Forms.ComboBox menuDeroulHoraireArret;
        private System.Windows.Forms.Label lblHoraireArret;
        private System.Windows.Forms.ComboBox menuDeroulHoraireLigne;
        private System.Windows.Forms.Label lblHoraireLigne;
        private System.Windows.Forms.DataGridView vueBDHoraire;
    }
}