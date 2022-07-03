namespace SAE_S2_01
{
    partial class frmManipBD
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControlManipBD = new System.Windows.Forms.TabControl();
            this.ongletInsert = new System.Windows.Forms.TabPage();
            this.vueBDInsert = new System.Windows.Forms.DataGridView();
            this.cmdInsert = new System.Windows.Forms.Button();
            this.menuDeroulInsert = new System.Windows.Forms.ComboBox();
            this.lblInsert = new System.Windows.Forms.Label();
            this.ongletModif = new System.Windows.Forms.TabPage();
            this.vueBDModif = new System.Windows.Forms.DataGridView();
            this.cmdModif = new System.Windows.Forms.Button();
            this.menuDeroulModif = new System.Windows.Forms.ComboBox();
            this.lblModif = new System.Windows.Forms.Label();
            this.ongletSuppr = new System.Windows.Forms.TabPage();
            this.vueBDSuppr = new System.Windows.Forms.DataGridView();
            this.cmdSuppr = new System.Windows.Forms.Button();
            this.menuDeroulSuppr = new System.Windows.Forms.ComboBox();
            this.lblSuppr = new System.Windows.Forms.Label();
            this.tabControlManipBD.SuspendLayout();
            this.ongletInsert.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vueBDInsert)).BeginInit();
            this.ongletModif.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vueBDModif)).BeginInit();
            this.ongletSuppr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vueBDSuppr)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlManipBD
            // 
            this.tabControlManipBD.Controls.Add(this.ongletInsert);
            this.tabControlManipBD.Controls.Add(this.ongletModif);
            this.tabControlManipBD.Controls.Add(this.ongletSuppr);
            this.tabControlManipBD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlManipBD.Location = new System.Drawing.Point(0, 0);
            this.tabControlManipBD.Name = "tabControlManipBD";
            this.tabControlManipBD.SelectedIndex = 0;
            this.tabControlManipBD.Size = new System.Drawing.Size(800, 450);
            this.tabControlManipBD.TabIndex = 0;
            // 
            // ongletInsert
            // 
            this.ongletInsert.Controls.Add(this.vueBDInsert);
            this.ongletInsert.Controls.Add(this.cmdInsert);
            this.ongletInsert.Controls.Add(this.menuDeroulInsert);
            this.ongletInsert.Controls.Add(this.lblInsert);
            this.ongletInsert.Location = new System.Drawing.Point(4, 22);
            this.ongletInsert.Name = "ongletInsert";
            this.ongletInsert.Padding = new System.Windows.Forms.Padding(3);
            this.ongletInsert.Size = new System.Drawing.Size(792, 424);
            this.ongletInsert.TabIndex = 0;
            this.ongletInsert.Text = "Insertion";
            this.ongletInsert.UseVisualStyleBackColor = true;
            // 
            // vueBDInsert
            // 
            this.vueBDInsert.AllowUserToDeleteRows = false;
            this.vueBDInsert.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.vueBDInsert.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vueBDInsert.Location = new System.Drawing.Point(3, 62);
            this.vueBDInsert.Name = "vueBDInsert";
            this.vueBDInsert.Size = new System.Drawing.Size(786, 307);
            this.vueBDInsert.TabIndex = 2;
            this.vueBDInsert.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.VerifSaisie);
            // 
            // cmdInsert
            // 
            this.cmdInsert.Location = new System.Drawing.Point(684, 386);
            this.cmdInsert.Name = "cmdInsert";
            this.cmdInsert.Size = new System.Drawing.Size(100, 30);
            this.cmdInsert.TabIndex = 3;
            this.cmdInsert.Text = "Valider";
            this.cmdInsert.UseVisualStyleBackColor = true;
            this.cmdInsert.Click += new System.EventHandler(this.Insertion);
            // 
            // menuDeroulInsert
            // 
            this.menuDeroulInsert.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuDeroulInsert.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.menuDeroulInsert.FormattingEnabled = true;
            this.menuDeroulInsert.Items.AddRange(new object[] {
            "LIGNE",
            "ARRET",
            "DISTANCE",
            "EST_DESSERVI"});
            this.menuDeroulInsert.Location = new System.Drawing.Point(3, 26);
            this.menuDeroulInsert.Name = "menuDeroulInsert";
            this.menuDeroulInsert.Size = new System.Drawing.Size(786, 21);
            this.menuDeroulInsert.TabIndex = 1;
            this.menuDeroulInsert.SelectionChangeCommitted += new System.EventHandler(this.AfficherTable);
            // 
            // lblInsert
            // 
            this.lblInsert.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInsert.Location = new System.Drawing.Point(3, 3);
            this.lblInsert.Name = "lblInsert";
            this.lblInsert.Size = new System.Drawing.Size(786, 23);
            this.lblInsert.TabIndex = 4;
            this.lblInsert.Text = "Choix de la table";
            this.lblInsert.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ongletModif
            // 
            this.ongletModif.Controls.Add(this.vueBDModif);
            this.ongletModif.Controls.Add(this.cmdModif);
            this.ongletModif.Controls.Add(this.menuDeroulModif);
            this.ongletModif.Controls.Add(this.lblModif);
            this.ongletModif.Location = new System.Drawing.Point(4, 22);
            this.ongletModif.Name = "ongletModif";
            this.ongletModif.Padding = new System.Windows.Forms.Padding(3);
            this.ongletModif.Size = new System.Drawing.Size(792, 424);
            this.ongletModif.TabIndex = 1;
            this.ongletModif.Text = "Modification";
            this.ongletModif.UseVisualStyleBackColor = true;
            // 
            // vueBDModif
            // 
            this.vueBDModif.AllowUserToAddRows = false;
            this.vueBDModif.AllowUserToDeleteRows = false;
            this.vueBDModif.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.vueBDModif.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vueBDModif.Location = new System.Drawing.Point(3, 62);
            this.vueBDModif.Name = "vueBDModif";
            this.vueBDModif.Size = new System.Drawing.Size(786, 307);
            this.vueBDModif.TabIndex = 2;
            this.vueBDModif.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.VerifSaisie);
            // 
            // cmdModif
            // 
            this.cmdModif.Location = new System.Drawing.Point(684, 386);
            this.cmdModif.Name = "cmdModif";
            this.cmdModif.Size = new System.Drawing.Size(100, 30);
            this.cmdModif.TabIndex = 3;
            this.cmdModif.Text = "Valider";
            this.cmdModif.UseVisualStyleBackColor = true;
            this.cmdModif.Click += new System.EventHandler(this.Modification);
            // 
            // menuDeroulModif
            // 
            this.menuDeroulModif.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuDeroulModif.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.menuDeroulModif.FormattingEnabled = true;
            this.menuDeroulModif.Items.AddRange(new object[] {
            "LIGNE",
            "ARRET",
            "DISTANCE",
            "EST_DESSERVI"});
            this.menuDeroulModif.Location = new System.Drawing.Point(3, 26);
            this.menuDeroulModif.Name = "menuDeroulModif";
            this.menuDeroulModif.Size = new System.Drawing.Size(786, 21);
            this.menuDeroulModif.TabIndex = 1;
            this.menuDeroulModif.SelectionChangeCommitted += new System.EventHandler(this.AfficherTable);
            // 
            // lblModif
            // 
            this.lblModif.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblModif.Location = new System.Drawing.Point(3, 3);
            this.lblModif.Name = "lblModif";
            this.lblModif.Size = new System.Drawing.Size(786, 23);
            this.lblModif.TabIndex = 4;
            this.lblModif.Text = "Choix de la table";
            this.lblModif.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ongletSuppr
            // 
            this.ongletSuppr.Controls.Add(this.vueBDSuppr);
            this.ongletSuppr.Controls.Add(this.cmdSuppr);
            this.ongletSuppr.Controls.Add(this.menuDeroulSuppr);
            this.ongletSuppr.Controls.Add(this.lblSuppr);
            this.ongletSuppr.Location = new System.Drawing.Point(4, 22);
            this.ongletSuppr.Name = "ongletSuppr";
            this.ongletSuppr.Padding = new System.Windows.Forms.Padding(3);
            this.ongletSuppr.Size = new System.Drawing.Size(792, 424);
            this.ongletSuppr.TabIndex = 2;
            this.ongletSuppr.Text = "Suppression";
            this.ongletSuppr.UseVisualStyleBackColor = true;
            // 
            // vueBDSuppr
            // 
            this.vueBDSuppr.AllowUserToAddRows = false;
            this.vueBDSuppr.AllowUserToDeleteRows = false;
            this.vueBDSuppr.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.vueBDSuppr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vueBDSuppr.Location = new System.Drawing.Point(3, 62);
            this.vueBDSuppr.Name = "vueBDSuppr";
            this.vueBDSuppr.ReadOnly = true;
            this.vueBDSuppr.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.vueBDSuppr.Size = new System.Drawing.Size(786, 307);
            this.vueBDSuppr.TabIndex = 2;
            this.vueBDSuppr.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.VerifSaisie);
            // 
            // cmdSuppr
            // 
            this.cmdSuppr.Location = new System.Drawing.Point(684, 386);
            this.cmdSuppr.Name = "cmdSuppr";
            this.cmdSuppr.Size = new System.Drawing.Size(100, 30);
            this.cmdSuppr.TabIndex = 3;
            this.cmdSuppr.Text = "Valider";
            this.cmdSuppr.UseVisualStyleBackColor = true;
            this.cmdSuppr.Click += new System.EventHandler(this.Suppression);
            // 
            // menuDeroulSuppr
            // 
            this.menuDeroulSuppr.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuDeroulSuppr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.menuDeroulSuppr.FormattingEnabled = true;
            this.menuDeroulSuppr.Items.AddRange(new object[] {
            "LIGNE",
            "ARRET",
            "DISTANCE",
            "EST_DESSERVI"});
            this.menuDeroulSuppr.Location = new System.Drawing.Point(3, 26);
            this.menuDeroulSuppr.Name = "menuDeroulSuppr";
            this.menuDeroulSuppr.Size = new System.Drawing.Size(786, 21);
            this.menuDeroulSuppr.TabIndex = 1;
            this.menuDeroulSuppr.SelectionChangeCommitted += new System.EventHandler(this.AfficherTable);
            // 
            // lblSuppr
            // 
            this.lblSuppr.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSuppr.Location = new System.Drawing.Point(3, 3);
            this.lblSuppr.Name = "lblSuppr";
            this.lblSuppr.Size = new System.Drawing.Size(786, 23);
            this.lblSuppr.TabIndex = 4;
            this.lblSuppr.Text = "Choix de la table";
            this.lblSuppr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmManipBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControlManipBD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmManipBD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manipulation des données de la base de données";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FermApp);
            this.Load += new System.EventHandler(this.InitApp);
            this.tabControlManipBD.ResumeLayout(false);
            this.ongletInsert.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vueBDInsert)).EndInit();
            this.ongletModif.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vueBDModif)).EndInit();
            this.ongletSuppr.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vueBDSuppr)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlManipBD;
        private System.Windows.Forms.TabPage ongletInsert;
        private System.Windows.Forms.TabPage ongletModif;
        private System.Windows.Forms.TabPage ongletSuppr;
        private System.Windows.Forms.Label lblInsert;
        private System.Windows.Forms.ComboBox menuDeroulInsert;
        private System.Windows.Forms.Button cmdInsert;
        private System.Windows.Forms.DataGridView vueBDInsert;
        private System.Windows.Forms.DataGridView vueBDModif;
        private System.Windows.Forms.Button cmdModif;
        private System.Windows.Forms.ComboBox menuDeroulModif;
        private System.Windows.Forms.Label lblModif;
        private System.Windows.Forms.DataGridView vueBDSuppr;
        private System.Windows.Forms.Button cmdSuppr;
        private System.Windows.Forms.ComboBox menuDeroulSuppr;
        private System.Windows.Forms.Label lblSuppr;
    }
}

