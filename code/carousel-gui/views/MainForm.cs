using carousel;
using carousel_gui.views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

            try
            {
                _Client = CarouselClient.CreateInstance("jamesalfredmills@gmail.com").Result;
            }
            catch (Exception)
            {
                MessageBox.Show("Error authorizing Google Drive API. Please check configuration files.");
                return;
            }

            this.GamesListBox.DataSource = _Client.GetGamesList();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            var settingsForm = new SettingsForm(_Client);
            settingsForm.ShowDialog();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            this.GamesListBox.DataSource = _Client.GetGamesList();
        }
    }
}
