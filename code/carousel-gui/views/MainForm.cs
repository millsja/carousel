using carousel;
using carousel.models;
using carousel_gui.views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace carousel_gui
{
    public partial class MainForm : Form
    {
        private CarouselClient _Client = null;

        public MainForm()
        {
            InitializeComponent();

            var logoImage = Properties.Resources.carousel_logo.GetHicon();
            this.Icon = Icon.FromHandle(logoImage);
        }

        internal async Task Initialize()
        {
            try
            {
                // var worker = new ProgressWorker();
                // await worker.Run((cts) =>
                // {
                var cts = new CancellationTokenSource();
                _Client = CarouselClient.CreateInstance(cts, () =>
                {
                    var prompt = new TextPrompt("Please enter your Google username");
                    prompt.ShowDialog();
                    return prompt.TextResult;
                }).Result;
                // });
            }
            catch (Exception)
            {
                MessageBox.Show("Error authorizing Google Drive API. Please check configuration files.");
                return;
            }

            using (var cts = new CancellationTokenSource())
            {
                this.GamesListBox.DataSource = _Client.GetGamesList();
            }
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            var settingsForm = new SettingsForm(_Client);
            settingsForm.ShowDialog();
        }

        private async void RefreshButton_Click(object sender, EventArgs e)
        {
            this.GamesListBox.DataSource = _Client.GetGamesList();
        }

        private void GamesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.GamesListBox.SelectedIndex == -1)
            {
                this.ConfigureGameButton.Enabled = false;
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            this.Initialize();
        }

        private void ConfigureGameButton_Click(object sender, EventArgs e)
        {
            var game = this.GamesListBox.SelectedItem;
            if (game is GameDto)
            {
                new ConfigureGameForm((GameDto)this.GamesListBox.SelectedItem, this._Client).ShowDialog();
            }
        }
    }
}
