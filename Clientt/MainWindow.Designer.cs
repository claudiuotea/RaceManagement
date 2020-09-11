namespace Clientt
{
    partial class MainWindow
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
            this.logoutButton = new System.Windows.Forms.Button();
            this.cautaButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.cursaListbox = new System.Windows.Forms.ListBox();
            this.participantListbox = new System.Windows.Forms.ListBox();
            this.echipaCombobox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(530, 476);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(75, 23);
            this.logoutButton.TabIndex = 2;
            this.logoutButton.Text = "LOGOUT";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // cautaButton
            // 
            this.cautaButton.Location = new System.Drawing.Point(557, 32);
            this.cautaButton.Name = "cautaButton";
            this.cautaButton.Size = new System.Drawing.Size(75, 23);
            this.cautaButton.TabIndex = 4;
            this.cautaButton.Text = "Cauta";
            this.cautaButton.UseVisualStyleBackColor = true;
            this.cautaButton.Click += new System.EventHandler(this.cautaButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(638, 32);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 5;
            this.addButton.Text = "Adauga";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // cursaListbox
            // 
            this.cursaListbox.FormattingEnabled = true;
            this.cursaListbox.Location = new System.Drawing.Point(25, 40);
            this.cursaListbox.Name = "cursaListbox";
            this.cursaListbox.Size = new System.Drawing.Size(320, 433);
            this.cursaListbox.TabIndex = 6;
            // 
            // participantListbox
            // 
            this.participantListbox.FormattingEnabled = true;
            this.participantListbox.Location = new System.Drawing.Point(423, 74);
            this.participantListbox.Name = "participantListbox";
            this.participantListbox.Size = new System.Drawing.Size(289, 381);
            this.participantListbox.TabIndex = 7;
            // 
            // echipaCombobox
            // 
            this.echipaCombobox.FormattingEnabled = true;
            this.echipaCombobox.Location = new System.Drawing.Point(423, 32);
            this.echipaCombobox.Name = "echipaCombobox";
            this.echipaCombobox.Size = new System.Drawing.Size(121, 21);
            this.echipaCombobox.TabIndex = 8;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 541);
            this.Controls.Add(this.echipaCombobox);
            this.Controls.Add(this.participantListbox);
            this.Controls.Add(this.cursaListbox);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.cautaButton);
            this.Controls.Add(this.logoutButton);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Button cautaButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ListBox cursaListbox;
        private System.Windows.Forms.ListBox participantListbox;
        private System.Windows.Forms.ComboBox echipaCombobox;
    }
}