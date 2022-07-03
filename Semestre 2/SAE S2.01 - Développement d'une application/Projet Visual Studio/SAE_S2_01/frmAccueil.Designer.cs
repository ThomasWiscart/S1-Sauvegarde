namespace SAE_S2_01
{
    partial class frmAccueil
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
            this.lblBonjour = new System.Windows.Forms.Label();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.cmdManip = new System.Windows.Forms.Button();
            this.cmdPresent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblBonjour
            // 
            this.lblBonjour.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBonjour.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBonjour.Location = new System.Drawing.Point(0, 0);
            this.lblBonjour.Name = "lblBonjour";
            this.lblBonjour.Size = new System.Drawing.Size(800, 31);
            this.lblBonjour.TabIndex = 2;
            this.lblBonjour.Text = "Bienvenue dans l\'application de gestion de base de données !";
            this.lblBonjour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestion.Location = new System.Drawing.Point(280, 114);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(240, 25);
            this.lblQuestion.TabIndex = 3;
            this.lblQuestion.Text = "Que voulez-vous faire ?";
            // 
            // cmdManip
            // 
            this.cmdManip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdManip.Location = new System.Drawing.Point(75, 200);
            this.cmdManip.Name = "cmdManip";
            this.cmdManip.Size = new System.Drawing.Size(250, 100);
            this.cmdManip.TabIndex = 0;
            this.cmdManip.Text = "Manipuler la base de données";
            this.cmdManip.UseVisualStyleBackColor = true;
            this.cmdManip.Click += new System.EventHandler(this.OuvrirFrmManipBD);
            // 
            // cmdPresent
            // 
            this.cmdPresent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPresent.Location = new System.Drawing.Point(475, 200);
            this.cmdPresent.Name = "cmdPresent";
            this.cmdPresent.Size = new System.Drawing.Size(250, 100);
            this.cmdPresent.TabIndex = 1;
            this.cmdPresent.Text = "Afficher les données de la base de données";
            this.cmdPresent.UseVisualStyleBackColor = true;
            this.cmdPresent.Click += new System.EventHandler(this.OuvrirFrmPresentBD);
            // 
            // frmAccueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmdPresent);
            this.Controls.Add(this.cmdManip);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.lblBonjour);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmAccueil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Accueil";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBonjour;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Button cmdManip;
        private System.Windows.Forms.Button cmdPresent;
    }
}