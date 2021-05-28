using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draughts
{
    public partial class JDialogGameOver : Form
    {
        private String winner;
        private bool newgame=false;

        public string Winner
        {
            get { return winner; }
            set
            {
                winner = value;
                label1.Text = winner;
            }
        }

        public bool Newgame
        {
            get { return newgame; }
            set { newgame = value; }
        }

        public JDialogGameOver()
        {
            InitializeComponent();
        }

        private void JDialogGameOver_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            newgame = true;
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            newgame = false;
            this.DialogResult = DialogResult.OK;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
