namespace carousel_gui.views
{
    partial class ConfigureGameForm
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
            this.GameFileDataTable = new System.Windows.Forms.DataGridView();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SetExePathButton = new System.Windows.Forms.Button();
            this.ExePathLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GameFileDataTable)).BeginInit();
            this.SuspendLayout();
            // 
            // GameFileDataTable
            // 
            this.GameFileDataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GameFileDataTable.Location = new System.Drawing.Point(13, 13);
            this.GameFileDataTable.Name = "GameFileDataTable";
            this.GameFileDataTable.Size = new System.Drawing.Size(542, 151);
            this.GameFileDataTable.TabIndex = 0;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(479, 171);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 1;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // SetExePathButton
            // 
            this.SetExePathButton.Location = new System.Drawing.Point(13, 171);
            this.SetExePathButton.Name = "SetExePathButton";
            this.SetExePathButton.Size = new System.Drawing.Size(96, 23);
            this.SetExePathButton.TabIndex = 2;
            this.SetExePathButton.Text = "Sete exe path";
            this.SetExePathButton.UseVisualStyleBackColor = true;
            this.SetExePathButton.Click += new System.EventHandler(this.SetExePathButton_Click);
            // 
            // ExePathLabel
            // 
            this.ExePathLabel.AutoEllipsis = true;
            this.ExePathLabel.Location = new System.Drawing.Point(115, 176);
            this.ExePathLabel.Name = "ExePathLabel";
            this.ExePathLabel.Size = new System.Drawing.Size(300, 18);
            this.ExePathLabel.TabIndex = 3;
            // 
            // ConfigureGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 204);
            this.Controls.Add(this.ExePathLabel);
            this.Controls.Add(this.SetExePathButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.GameFileDataTable);
            this.Name = "ConfigureGameForm";
            this.Text = "Configure Game";
            ((System.ComponentModel.ISupportInitialize)(this.GameFileDataTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView GameFileDataTable;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button SetExePathButton;
        private System.Windows.Forms.Label ExePathLabel;
    }
}