using carousel;
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
        private CarouselClient _CarouselClient;

        public ConfigureGameForm(GameDto game, CarouselClient client)
        {
            InitializeComponent();

            this._CarouselClient = client;
            this._Game = game;
            this._Game.Load();
            this.ExePathLabel.Text = this._Game.ExePath;
            this.GameFileDataTable.DataSource = this._Game.LocalFiles;

            if (this.GameFileDataTable.RowCount >= 1)
            {
                for (int i = GameFileDataTable.ColumnCount - 1; i >= 0; i--)
                {
                    if (i == GameFileDataTable.ColumnCount - 1)
                    {
                        GameFileDataTable.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                    else
                    {
                        GameFileDataTable.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    }
                }
            }
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

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            this._Game.Save();

            // validate and attempt to start game
            if (this._CarouselClient != null)
            {
                throw new NotImplementedException();
            }
        }

        private void GameFileDataTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex != -1)
            {
                var dg = new SaveFileDialog();
                if (dg.ShowDialog() == DialogResult.OK)
                {
                    this.GameFileDataTable.CurrentCell.Value = dg.FileName;
                }
            }
        }
    }
}
