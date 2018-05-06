namespace carousel_gui.views
{
    partial class SettingsForm
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
            this.RevokeAccessButton = new System.Windows.Forms.Button();
            this.SetRemoteDirButton = new System.Windows.Forms.Button();
            this.SettingsTabPage = new System.Windows.Forms.TabControl();
            this.MainTab = new System.Windows.Forms.TabPage();
            this.LogTab = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.NewClientConfigButton = new System.Windows.Forms.Button();
            this.SettingsTabPage.SuspendLayout();
            this.MainTab.SuspendLayout();
            this.LogTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // RevokeAccessButton
            // 
            this.RevokeAccessButton.Location = new System.Drawing.Point(68, 49);
            this.RevokeAccessButton.Name = "RevokeAccessButton";
            this.RevokeAccessButton.Size = new System.Drawing.Size(184, 23);
            this.RevokeAccessButton.TabIndex = 0;
            this.RevokeAccessButton.Text = "Revoke access to Google Drive";
            this.RevokeAccessButton.UseVisualStyleBackColor = true;
            this.RevokeAccessButton.Click += new System.EventHandler(this.RevokeAccessButton_Click);
            // 
            // SetRemoteDirButton
            // 
            this.SetRemoteDirButton.Location = new System.Drawing.Point(68, 78);
            this.SetRemoteDirButton.Name = "SetRemoteDirButton";
            this.SetRemoteDirButton.Size = new System.Drawing.Size(183, 23);
            this.SetRemoteDirButton.TabIndex = 1;
            this.SetRemoteDirButton.Text = "Set remote directory";
            this.SetRemoteDirButton.UseVisualStyleBackColor = true;
            // 
            // SettingsTabPage
            // 
            this.SettingsTabPage.Controls.Add(this.MainTab);
            this.SettingsTabPage.Controls.Add(this.LogTab);
            this.SettingsTabPage.Location = new System.Drawing.Point(12, 12);
            this.SettingsTabPage.Name = "SettingsTabPage";
            this.SettingsTabPage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SettingsTabPage.SelectedIndex = 0;
            this.SettingsTabPage.Size = new System.Drawing.Size(327, 271);
            this.SettingsTabPage.TabIndex = 2;
            // 
            // MainTab
            // 
            this.MainTab.Controls.Add(this.NewClientConfigButton);
            this.MainTab.Controls.Add(this.RevokeAccessButton);
            this.MainTab.Controls.Add(this.SetRemoteDirButton);
            this.MainTab.Location = new System.Drawing.Point(4, 22);
            this.MainTab.Name = "MainTab";
            this.MainTab.Padding = new System.Windows.Forms.Padding(3);
            this.MainTab.Size = new System.Drawing.Size(319, 245);
            this.MainTab.TabIndex = 0;
            this.MainTab.Text = "Main";
            this.MainTab.UseVisualStyleBackColor = true;
            // 
            // LogTab
            // 
            this.LogTab.Controls.Add(this.textBox1);
            this.LogTab.Location = new System.Drawing.Point(4, 22);
            this.LogTab.Name = "LogTab";
            this.LogTab.Padding = new System.Windows.Forms.Padding(3);
            this.LogTab.Size = new System.Drawing.Size(319, 245);
            this.LogTab.TabIndex = 1;
            this.LogTab.Text = "Log";
            this.LogTab.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(7, 7);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(306, 232);
            this.textBox1.TabIndex = 0;
            // 
            // NewClientConfigButton
            // 
            this.NewClientConfigButton.Location = new System.Drawing.Point(68, 108);
            this.NewClientConfigButton.Name = "NewClientConfigButton";
            this.NewClientConfigButton.Size = new System.Drawing.Size(183, 23);
            this.NewClientConfigButton.TabIndex = 2;
            this.NewClientConfigButton.Text = "Create new configuration";
            this.NewClientConfigButton.UseVisualStyleBackColor = true;
            this.NewClientConfigButton.Click += new System.EventHandler(this.NewClientConfigButton_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 293);
            this.Controls.Add(this.SettingsTabPage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.SettingsTabPage.ResumeLayout(false);
            this.MainTab.ResumeLayout(false);
            this.LogTab.ResumeLayout(false);
            this.LogTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button RevokeAccessButton;
        private System.Windows.Forms.Button SetRemoteDirButton;
        private System.Windows.Forms.TabControl SettingsTabPage;
        private System.Windows.Forms.TabPage MainTab;
        private System.Windows.Forms.TabPage LogTab;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button NewClientConfigButton;
    }
}