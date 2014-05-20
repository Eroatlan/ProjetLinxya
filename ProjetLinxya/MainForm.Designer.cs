namespace ProjetLinxya
{
    partial class MainForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.softwaresListBox = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.launchButton = new System.Windows.Forms.Button();
            this.listBoxSelectedSoftwares = new System.Windows.Forms.ListBox();
            this.keysListBox = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.softwaresListBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.submitButton);
            this.splitContainer1.Panel2.Controls.Add(this.launchButton);
            this.splitContainer1.Panel2.Controls.Add(this.listBoxSelectedSoftwares);
            this.splitContainer1.Panel2.Controls.Add(this.keysListBox);
            this.splitContainer1.Size = new System.Drawing.Size(587, 423);
            this.splitContainer1.SplitterDistance = 316;
            this.splitContainer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Liste des logiciels installés :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // softwaresListBox
            // 
            this.softwaresListBox.FormattingEnabled = true;
            this.softwaresListBox.Location = new System.Drawing.Point(4, 24);
            this.softwaresListBox.Name = "softwaresListBox";
            this.softwaresListBox.Size = new System.Drawing.Size(305, 394);
            this.softwaresListBox.TabIndex = 0;
            this.softwaresListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.softwaresListBox_ItemCheck);
            this.softwaresListBox.SelectedIndexChanged += new System.EventHandler(this.softwaresListBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Liste des clés correspondantes :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(134, 377);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(121, 41);
            this.submitButton.TabIndex = 3;
            this.submitButton.Text = "Soumettre";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // launchButton
            // 
            this.launchButton.Location = new System.Drawing.Point(9, 377);
            this.launchButton.Name = "launchButton";
            this.launchButton.Size = new System.Drawing.Size(121, 41);
            this.launchButton.TabIndex = 2;
            this.launchButton.Text = "Générer";
            this.launchButton.UseVisualStyleBackColor = true;
            this.launchButton.Click += new System.EventHandler(this.launchButton_Click);
            // 
            // listBoxSelectedSoftwares
            // 
            this.listBoxSelectedSoftwares.FormattingEnabled = true;
            this.listBoxSelectedSoftwares.Location = new System.Drawing.Point(9, 211);
            this.listBoxSelectedSoftwares.Name = "listBoxSelectedSoftwares";
            this.listBoxSelectedSoftwares.Size = new System.Drawing.Size(248, 160);
            this.listBoxSelectedSoftwares.TabIndex = 1;
            // 
            // keysListBox
            // 
            this.keysListBox.CheckOnClick = true;
            this.keysListBox.FormattingEnabled = true;
            this.keysListBox.HorizontalScrollbar = true;
            this.keysListBox.Location = new System.Drawing.Point(9, 24);
            this.keysListBox.Name = "keysListBox";
            this.keysListBox.Size = new System.Drawing.Size(248, 154);
            this.keysListBox.TabIndex = 0;
            this.keysListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.keysListBox_ItemCheck);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Liste des logiciels à soumettre :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 423);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Prototype";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckedListBox softwaresListBox;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button launchButton;
        private System.Windows.Forms.ListBox listBoxSelectedSoftwares;
        private System.Windows.Forms.CheckedListBox keysListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

