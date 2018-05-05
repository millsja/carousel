namespace carousel_gui
{
    partial class MainForm
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
            this.GamesListBox = new System.Windows.Forms.ListBox();
            this.ConfigureGameButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GamesListBox
            // 
            this.GamesListBox.FormattingEnabled = true;
            this.GamesListBox.Location = new System.Drawing.Point(12, 12);
            this.GamesListBox.Name = "GamesListBox";
            this.GamesListBox.Size = new System.Drawing.Size(228, 355);
            this.GamesListBox.TabIndex = 0;
            // 
            // ConfigureGameButton
            // 
            this.ConfigureGameButton.Location = new System.Drawing.Point(248, 12);
            this.ConfigureGameButton.Name = "ConfigureGameButton";
            this.ConfigureGameButton.Size = new System.Drawing.Size(102, 47);
            this.ConfigureGameButton.TabIndex = 1;
            this.ConfigureGameButton.Text = "Configure game";
            this.ConfigureGameButton.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(248, 65);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 48);
            this.button2.TabIndex = 2;
            this.button2.Text = "Start game";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // SettingsButton
            // 
            this.SettingsButton.Location = new System.Drawing.Point(248, 321);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(102, 46);
            this.SettingsButton.TabIndex = 3;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.BackgroundImage = global::carousel_gui.Properties.Resources.Refresh_grey_16xMD;
            this.RefreshButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RefreshButton.FlatAppearance.BorderSize = 0;
            this.RefreshButton.Location = new System.Drawing.Point(202, 333);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(25, 23);
            this.RefreshButton.TabIndex = 6;
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.BackgroundImage = global::carousel_gui.Properties.Resources.Remove_16x;
            this.RemoveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RemoveButton.FlatAppearance.BorderSize = 0;
            this.RemoveButton.Location = new System.Drawing.Point(171, 333);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(25, 23);
            this.RemoveButton.TabIndex = 5;
            this.RemoveButton.UseVisualStyleBackColor = true;
            // 
            // AddButton
            // 
            this.AddButton.BackgroundImage = global::carousel_gui.Properties.Resources.Add_16x;
            this.AddButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AddButton.FlatAppearance.BorderSize = 0;
            this.AddButton.Location = new System.Drawing.Point(140, 333);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(25, 23);
            this.AddButton.TabIndex = 4;
            this.AddButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 380);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ConfigureGameButton);
            this.Controls.Add(this.GamesListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Carousel game state manager";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox GamesListBox;
        private System.Windows.Forms.Button ConfigureGameButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button RefreshButton;
    }
}

