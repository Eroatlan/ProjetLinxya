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
            this.softwaresListBox = new System.Windows.Forms.CheckedListBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.launchButton = new System.Windows.Forms.Button();
            this.listBoxSelectedSoftwares = new System.Windows.Forms.ListBox();
            this.keysListBox = new System.Windows.Forms.CheckedListBox();
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
            this.splitContainer1.Panel1.Controls.Add(this.softwaresListBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.submitButton);
            this.splitContainer1.Panel2.Controls.Add(this.launchButton);
            this.splitContainer1.Panel2.Controls.Add(this.listBoxSelectedSoftwares);
            this.splitContainer1.Panel2.Controls.Add(this.keysListBox);
            this.splitContainer1.Size = new System.Drawing.Size(587, 423);
            this.splitContainer1.SplitterDistance = 316;
            this.splitContainer1.TabIndex = 0;
            // 
            // softwaresListBox
            // 
            this.softwaresListBox.FormattingEnabled = true;
            this.softwaresListBox.Location = new System.Drawing.Point(4, 3);
            this.softwaresListBox.Name = "softwaresListBox";
            this.softwaresListBox.Size = new System.Drawing.Size(305, 409);
            this.softwaresListBox.TabIndex = 0;
            this.softwaresListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.softwaresListBox_ItemCheck);
            this.softwaresListBox.SelectedIndexChanged += new System.EventHandler(this.softwaresListBox_SelectedIndexChanged);
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(153, 371);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(104, 41);
            this.submitButton.TabIndex = 3;
            this.submitButton.Text = "Soumettre";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // launchButton
            // 
            this.launchButton.Location = new System.Drawing.Point(43, 370);
            this.launchButton.Name = "launchButton";
            this.launchButton.Size = new System.Drawing.Size(104, 41);
            this.launchButton.TabIndex = 2;
            this.launchButton.Text = "Générer";
            this.launchButton.UseVisualStyleBackColor = true;
            this.launchButton.Click += new System.EventHandler(this.launchButton_Click);
            // 
            // listBoxSelectedSoftwares
            // 
            this.listBoxSelectedSoftwares.FormattingEnabled = true;
            this.listBoxSelectedSoftwares.Location = new System.Drawing.Point(9, 191);
            this.listBoxSelectedSoftwares.Name = "listBoxSelectedSoftwares";
            this.listBoxSelectedSoftwares.Size = new System.Drawing.Size(248, 173);
            this.listBoxSelectedSoftwares.TabIndex = 1;
            // 
            // keysListBox
            // 
            this.keysListBox.CheckOnClick = true;
            this.keysListBox.FormattingEnabled = true;
            this.keysListBox.HorizontalScrollbar = true;
            this.keysListBox.Location = new System.Drawing.Point(9, 9);
            this.keysListBox.Name = "keysListBox";
            this.keysListBox.Size = new System.Drawing.Size(248, 169);
            this.keysListBox.TabIndex = 0;
            this.keysListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.keysListBox_ItemCheck);
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
            this.splitContainer1.Panel2.ResumeLayout(false);
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
    }
}

