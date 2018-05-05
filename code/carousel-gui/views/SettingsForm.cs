using carousel;
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

namespace carousel_gui.views
{
    public partial class SettingsForm : Form
    {
        private CarouselClient _CarouselClient = null;
        
        public SettingsForm(CarouselClient client)
        {
            InitializeComponent();

            _CarouselClient = client;
        }

        private async void RevokeAccessButton_Click(object sender, EventArgs e)
        {
            await _CarouselClient.RevokeAuthorization(CancellationToken.None);
        }
    }
}
