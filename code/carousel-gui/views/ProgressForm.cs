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
    public partial class ProgressForm : Form
    {
        private CancellationTokenSource _CancelSource;

        public ProgressForm(CancellationTokenSource cancelSource, string formText)
        {
            InitializeComponent();

            this.ActionLabel.Text = formText;

            cancelSource.Token.Register(() =>
            {
                this.BeginInvoke(new InvokeDelegate(CloseWindow));
            });
        }

        private delegate void InvokeDelegate();

        private void CloseWindow()
        {
            this.Close();
        }

        // private void CancelButton_Click(object sender, EventArgs e)
        // {
        //     this._CancelSource.Cancel();
        //     this.Close();
        // }
    }
}
