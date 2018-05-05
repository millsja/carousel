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
            this.SuspendLayout();
            // 
            // RevokeAccessButton
            // 
            this.RevokeAccessButton.Location = new System.Drawing.Point(12, 12);
            this.RevokeAccessButton.Name = "RevokeAccessButton";
            this.RevokeAccessButton.Size = new System.Drawing.Size(203, 23);
            this.RevokeAccessButton.TabIndex = 0;
            this.RevokeAccessButton.Text = "Revoke access to Google Drive";
            this.RevokeAccessButton.UseVisualStyleBackColor = true;
            this.RevokeAccessButton.Click += new System.EventHandler(this.RevokeAccessButton_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 52);
            this.Controls.Add(this.RevokeAccessButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button RevokeAccessButton;
    }
}