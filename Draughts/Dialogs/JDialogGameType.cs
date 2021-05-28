using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Draughts.Enums;

namespace Draughts
{
    public partial class JDialogGameType : Form
    {
        GameType type;

        public GameType Type
        {
            get { return type; }
            set { type = value; }
        }

        public JDialogGameType()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            type = GameType.PLAYER;
            this.DialogResult = DialogResult.OK;
        }

        private void jLabel1_Click(object sender, EventArgs e)
        {
            
        }

        private void jButton2_Click(object sender, EventArgs e)
        {
            type=GameType.PC;
            this.DialogResult = DialogResult.OK;
        }
    }
}
