namespace tst_db
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.Carica = new System.Windows.Forms.Button();
            this.Scrivi = new System.Windows.Forms.Button();
            this.Stampa = new System.Windows.Forms.Button();
            this.Esci = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.StatoTxtBox = new System.Windows.Forms.RichTextBox();
            this.Billing = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Carica
            // 
            this.Carica.Location = new System.Drawing.Point(89, 341);
            this.Carica.Name = "Carica";
            this.Carica.Size = new System.Drawing.Size(75, 23);
            this.Carica.TabIndex = 0;
            this.Carica.Text = "Carica dati";
            this.Carica.UseVisualStyleBackColor = true;
            this.Carica.Click += new System.EventHandler(this.Carica_Click);
            // 
            // Scrivi
            // 
            this.Scrivi.Location = new System.Drawing.Point(89, 395);
            this.Scrivi.Name = "Scrivi";
            this.Scrivi.Size = new System.Drawing.Size(75, 23);
            this.Scrivi.TabIndex = 1;
            this.Scrivi.Text = "Scrivi dati";
            this.Scrivi.UseVisualStyleBackColor = true;
            // 
            // Stampa
            // 
            this.Stampa.Location = new System.Drawing.Point(89, 446);
            this.Stampa.Name = "Stampa";
            this.Stampa.Size = new System.Drawing.Size(75, 23);
            this.Stampa.TabIndex = 2;
            this.Stampa.Text = "Stampa dati";
            this.Stampa.UseVisualStyleBackColor = true;
            // 
            // Esci
            // 
            this.Esci.Location = new System.Drawing.Point(952, 520);
            this.Esci.Name = "Esci";
            this.Esci.Size = new System.Drawing.Size(75, 23);
            this.Esci.TabIndex = 3;
            this.Esci.Text = "Esci";
            this.Esci.UseVisualStyleBackColor = true;
            this.Esci.Click += new System.EventHandler(this.Esci_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::tst_db.Properties.Resources.logo_objlab;
            this.pictureBox1.Location = new System.Drawing.Point(12, 65);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1002, 217);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // StatoTxtBox
            // 
            this.StatoTxtBox.Location = new System.Drawing.Point(313, 341);
            this.StatoTxtBox.Name = "StatoTxtBox";
            this.StatoTxtBox.Size = new System.Drawing.Size(406, 128);
            this.StatoTxtBox.TabIndex = 5;
            this.StatoTxtBox.Text = "";
            this.StatoTxtBox.TextChanged += new System.EventHandler(this.StatoTxtBox_TextChanged);
            // 
            // Billing
            // 
            this.Billing.Location = new System.Drawing.Point(196, 341);
            this.Billing.Name = "Billing";
            this.Billing.Size = new System.Drawing.Size(75, 23);
            this.Billing.TabIndex = 6;
            this.Billing.Text = "Billing";
            this.Billing.UseVisualStyleBackColor = true;
            this.Billing.Click += new System.EventHandler(this.Billing_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 568);
            this.Controls.Add(this.Billing);
            this.Controls.Add(this.StatoTxtBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Esci);
            this.Controls.Add(this.Stampa);
            this.Controls.Add(this.Scrivi);
            this.Controls.Add(this.Carica);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Carica;
        private System.Windows.Forms.Button Scrivi;
        private System.Windows.Forms.Button Stampa;
        private System.Windows.Forms.Button Esci;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox StatoTxtBox;
        private System.Windows.Forms.Button Billing;
    }
}

