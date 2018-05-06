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
    public partial class TextPrompt : Form
    {
        public string TextResult;

        public TextPrompt(string prompt)
        {
            InitializeComponent();

            this.textPromptLabel.Text = prompt;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.TextResult = textBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.OkButton_Click(null, null);
            }
        }
    }
}
