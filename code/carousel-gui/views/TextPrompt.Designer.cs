namespace carousel_gui.views
{
    partial class TextPrompt
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
            this.textPromptLabel = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textPromptLabel
            // 
            this.textPromptLabel.AutoSize = true;
            this.textPromptLabel.Location = new System.Drawing.Point(13, 9);
            this.textPromptLabel.Name = "textPromptLabel";
            this.textPromptLabel.Size = new System.Drawing.Size(35, 13);
            this.textPromptLabel.TabIndex = 0;
            this.textPromptLabel.Text = "label1";
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(16, 30);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(240, 20);
            this.textBox.TabIndex = 1;
            this.textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(263, 30);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(48, 20);
            this.OkButton.TabIndex = 2;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // TextPrompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 61);
            this.ControlBox = false;
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.textPromptLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TextPrompt";
            this.Text = "TextPrompt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label textPromptLabel;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button OkButton;
    }
}