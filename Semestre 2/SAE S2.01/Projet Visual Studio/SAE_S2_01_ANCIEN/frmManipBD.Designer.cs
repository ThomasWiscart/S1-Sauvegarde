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
            this.tabControlsManipBD = new System.Windows.Forms.TabControl();
            this.ongletInsert = new System.Windows.Forms.TabPage();
            this.cmdValiderInsert = new System.Windows.Forms.Button();
            this.vueBDInsert = new System.Windows.Forms.DataGridView();
            this.lblInsert = new System.Windows.Forms.Label();
            this.ongletModif = new System.Windows.Forms.TabPage();
            this.cmdValiderModif = new System.Windows.Forms.Button();
            this.vueBDModif = new System.Windows.Forms.DataGridView();
            this.menuDeroulModif = new System.Windows.Forms.ComboBox();
            this.lblModif = new System.Windows.Forms.Label();
            this.ongletSuppr = new System.Windows.Forms.TabPage();
            this.cmdValiderSuppr = new System.Windows.Forms.Button();
            this.vueBDSuppr = new System.Windows.Forms.DataGridView();
            this.menuDeroulSuppr = new System.Windows.Forms.ComboBox();
            this.lblSuppr = new System.Windows.Forms.Label();
            this.menuDeroulInsert = new System.Windows.Forms.ComboBox();
            this.tabControlsManipBD.SuspendLayout();
            this.ongletInsert.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vueBDInsert)).BeginInit();
            this.ongletModif.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vueBDModif)).BeginInit();
            this.ongletSuppr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vueBDSuppr)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlsManipBD
            // 
            this.tabControlsManipBD.Controls.Add(this.ongletInsert);
            this.tabControlsManipBD.Controls.Add(this.ongletModif);
            this.tabControlsManipBD.Controls.Add(this.ongletSuppr);
            this.tabControlsManipBD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlsManipBD.Location = new System.Drawing.Point(0, 0);
            this.tabControlsManipBD.Name = "tabControlsManipBD";
            this.tabControlsManipBD.SelectedIndex = 0;
            this.tabControlsManipBD.Size = new System.Drawing.Size(784, 461);
            this.tabControlsManipBD.TabIndex = 0;
            // 
            // ongletInsert
            // 
            this.ongletInsert.Controls.Add(this.cmdValiderInsert);
            this.ongletInsert.Controls.Add(this.vueBDInsert);
            this.ongletInsert.Controls.Add(this.menuDeroulInsert);
            this.ongletInsert.Controls.Add(this.lblInsert);
            this.ongletInsert.Location = new System.Drawing.Point(4, 22);
            this.ongletInsert.Name = "ongletInsert";
            this.ongletInsert.Padding = new System.Windows.Forms.Padding(3);
            this.ongletInsert.Size = new System.Drawing.Size(776, 435);
            this.ongletInsert.TabIndex = 0;
            this.ongletInsert.Text = "Insertion";
            this.ongletInsert.UseVisualStyleBackColor = true;
            // 
            // cmdValiderInsert
            // 
            this.cmdValiderInsert.Location = new System.Drawing.Point(639, 380);
            this.cmdValiderInsert.Name = "cmdValiderInsert";
            this.cmdValiderInsert.Size = new System.Drawing.Size(99, 28);
            this.cmdValiderInsert.TabIndex = 3;
            this.cmdValiderInsert.Text = "Valider";
            this.cmdValiderInsert.UseVisualStyleBackColor = true;
            this.cmdValiderInsert.Click += new System.EventHandler(this.ValiderInsert);
            // 
            // vueBDInsert
            // 
            this.vueBDInsert.AllowUserToDeleteRows = false;
            this.vueBDInsert.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.vueBDInsert.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vueBDInsert.Location = new System.Drawing.Point(38, 92);
            this.vueBDInsert.Name = "vueBDInsert";
            this.vueBDInsert.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.vueBDInsert.Size = new System.Drawing.Size(700, 250);
            this.vueBDInsert.TabIndex = 2;
            this.vueBDInsert.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.VerifSaisie);
            // 
            // lblInsert
            // 
            this.lblInsert.Location = new System.Drawing.Point(38, 15);
            this.lblInsert.Name = "lblInsert";
            this.lblInsert.Size = new System.Drawing.Size(700, 23);
            this.lblInsert.TabIndex = 0;
            this.lblInsert.Text = "Choix de la table";
            this.lblInsert.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ongletModif
            // 
            this.ongletModif.Controls.Add(this.cmdValiderModif);
            this.ongletModif.Controls.Add(this.vueBDModif);
            this.ongletModif.Controls.Add(this.menuDeroulModif);
            this.ongletModif.Controls.Add(this.lblModif);
            this.ongletModif.Location = new System.Drawing.Point(4, 22);
            this.ongletModif.Name = "ongletModif";
            this.ongletModif.Padding = new System.Windows.Forms.Padding(3);
            this.ongletModif.Size = new System.Drawing.Size(776, 435);
            this.ongletModif.TabIndex = 1;
            this.ongletModif.Text = "Modification";
            this.ongletModif.UseVisualStyleBackColor = true;
            // 
            // cmdValiderModif
            // 
            this.cmdValiderModif.Location = new System.Drawing.Point(639, 380);
            this.cmdValiderModif.Name = "cmdValiderModif";
            this.cmdValiderModif.Size = new System.Drawing.Size(99, 28);
            this.cmdValiderModif.TabIndex = 7;
            this.cmdValiderModif.Text = "Valider";
            this.cmdValiderModif.UseVisualStyleBackColor = true;
            this.cmdValiderModif.Click += new System.EventHandler(this.ValiderModif);
            // 
            // vueBDModif
            // 
            this.vueBDModif.AllowUserToAddRows = false;
            this.vueBDModif.AllowUserToDeleteRows = false;
            this.vueBDModif.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.vueBDModif.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vueBDModif.Location = new System.Drawing.Point(38, 92);
            this.vueBDModif.Name = "vueBDModif";
            this.vueBDModif.Size = new System.Drawing.Size(700, 250);
            this.vueBDModif.TabIndex = 6;
            this.vueBDModif.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.VerifSaisie);
            // 
            // menuDeroulModif
            // 
            this.menuDeroulModif.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.menuDeroulModif.FormattingEnabled = true;
            this.menuDeroulModif.Items.AddRange(new object[] {
            "LIGNE",
            "ARRET",
            "DISTANCE",
            "EST_DESSERVI"});
            this.menuDeroulModif.Location = new System.Drawing.Point(38, 41);
            this.menuDeroulModif.Name = "menuDeroulModif";
            this.menuDeroulModif.Size = new System.Drawing.Size(700, 21);
            this.menuDeroulModif.TabIndex = 5;
            this.menuDeroulModif.SelectionChangeCommitted += new System.EventHandler(this.SelectTable);
            // 
            // lblModif
            // 
            this.lblModif.Location = new System.Drawing.Point(38, 15);
            this.lblModif.Name = "lblModif";
            this.lblModif.Size = new System.Drawing.Size(700, 23);
            this.lblModif.TabIndex = 4;
            this.lblModif.Text = "Choix de la table";
            this.lblModif.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ongletSuppr
            // 
            this.ongletSuppr.Controls.Add(this.cmdValiderSuppr);
            this.ongletSuppr.Controls.Add(this.vueBDSuppr);
            this.ongletSuppr.Controls.Add(this.menuDeroulSuppr);
            this.ongletSuppr.Controls.Add(this.lblSuppr);
            this.ongletSuppr.Location = new System.Drawing.Point(4, 22);
            this.ongletSuppr.Name = "ongletSuppr";
            this.ongletSuppr.Padding = new System.Windows.Forms.Padding(3);
            this.ongletSuppr.Size = new System.Drawing.Size(776, 435);
            this.ongletSuppr.TabIndex = 2;
            this.ongletSuppr.Text = "Suppression";
            this.ongletSuppr.UseVisualStyleBackColor = true;
            // 
            // cmdValiderSuppr
            // 
            this.cmdValiderSuppr.Location = new System.Drawing.Point(639, 380);
            this.cmdValiderSuppr.Name = "cmdValiderSuppr";
            this.cmdValiderSuppr.Size = new System.Drawing.Size(99, 28);
            this.cmdValiderSuppr.TabIndex = 11;
            this.cmdValiderSuppr.Text = "Valider";
            this.cmdValiderSuppr.UseVisualStyleBackColor = true;
            this.cmdValiderSuppr.Click += new System.EventHandler(this.ValiderSuppr);
            // 
            // vueBDSuppr
            // 
            this.vueBDSuppr.AllowUserToAddRows = false;
            this.vueBDSuppr.AllowUserToDeleteRows = false;
            this.vueBDSuppr.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.vueBDSuppr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vueBDSuppr.Location = new System.Drawing.Point(38, 92);
            this.vueBDSuppr.Name = "vueBDSuppr";
            this.vueBDSuppr.ReadOnly = true;
            this.vueBDSuppr.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.vueBDSuppr.Size = new System.Drawing.Size(700, 250);
            this.vueBDSuppr.TabIndex = 10;
            // 
            // menuDeroulSuppr
            // 
            this.menuDeroulSuppr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.menuDeroulSuppr.FormattingEnabled = true;
            this.menuDeroulSuppr.Items.AddRange(new object[] {
            "LIGNE",
            "ARRET",
            "DISTANCE",
            "EST_DESSERVI"});
            this.menuDeroulSuppr.Location = new System.Drawing.Point(38, 41);
            this.menuDeroulSuppr.Name = "menuDeroulSuppr";
            this.menuDeroulSuppr.Size = new System.Drawing.Size(700, 21);
            this.menuDeroulSuppr.TabIndex = 9;
            this.menuDeroulSuppr.SelectionChangeCommitted += new System.EventHandler(this.SelectTable);
            // 
            // lblSuppr
            // 
            this.lblSuppr.Location = new System.Drawing.Point(38, 15);
            this.lblSuppr.Name = "lblSuppr";
            this.lblSuppr.Size = new System.Drawing.Size(700, 23);
            this.lblSuppr.TabIndex = 8;
            this.lblSuppr.Text = "Choix de la table";
            this.lblSuppr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuDeroulInsert
            // 
            this.menuDeroulInsert.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.menuDeroulInsert.FormattingEnabled = true;
            this.menuDeroulInsert.Items.AddRange(new object[] {
            "LIGNE",
            "ARRET",
            "DISTANCE",
            "EST_DESSERVI"});
            this.menuDeroulInsert.Location = new System.Drawing.Point(38, 41);
            this.menuDeroulInsert.Name = "menuDeroulInsert";
            this.menuDeroulInsert.Size = new System.Drawing.Size(700, 21);
            this.menuDeroulInsert.TabIndex = 1;
            // 
            // frmManipBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.tabControlsManipBD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmManipBD";
            this.Text = "Manipulation des données de la base de donnée";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FermApp);
            this.Load += new System.EventHandler(this.InitApp);
            this.tabControlsManipBD.ResumeLayout(false);
            this.ongletInsert.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vueBDInsert)).EndInit();
            this.ongletModif.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vueBDModif)).EndInit();
            this.ongletSuppr.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vueBDSuppr)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlsManipBD;
        private System.Windows.Forms.TabPage ongletInsert;
        private System.Windows.Forms.TabPage ongletModif;
        private System.Windows.Forms.TabPage ongletSuppr;
        private System.Windows.Forms.Label lblInsert;
        private System.Windows.Forms.Button cmdValiderInsert;
        private System.Windows.Forms.DataGridView vueBDInsert;
        private System.Windows.Forms.Button cmdValiderModif;
        private System.Windows.Forms.DataGridView vueBDModif;
        private System.Windows.Forms.ComboBox menuDeroulModif;
        private System.Windows.Forms.Label lblModif;
        private System.Windows.Forms.Button cmdValiderSuppr;
        private System.Windows.Forms.DataGridView vueBDSuppr;
        private System.Windows.Forms.ComboBox menuDeroulSuppr;
        private System.Windows.Forms.Label lblSuppr;
        private System.Windows.Forms.ComboBox menuDeroulInsert;
    }
}

