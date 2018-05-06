using carousel.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace carousel_gui.views
{
    public partial class ConfigureGameForm : Form
    {
        private GameDto _Game;

        public ConfigureGameForm(GameDto game)
        {
            InitializeComponent();

            this._Game = game;
            this._Game.Load();
            this.ExePathLabel.Text = this._Game.ExePath;
            this.GameFileDataTable.DataSource = this._Game.LocalFiles;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            this._Game.Save();
            MessageBox.Show("Save complete.");
        }

        private void SetExePathButton_Click(object sender, EventArgs e)
        {
            var loadFilePath = new OpenFileDialog();
            if (loadFilePath.ShowDialog() == DialogResult.OK)
            {
                this._Game.ExePath = loadFilePath.FileName;
                this.ExePathLabel.Text = loadFilePath.FileName;
            }
        }
    }
}
