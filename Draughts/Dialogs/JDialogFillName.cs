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
    public partial class JDialogFillName : Form
    {
        private GameType t;
        private Colors aic;
        private AI.AI ai=null;
        private String name1;
        private String name2;

        public GameType T
        {
            get { return t; }
            set { t = value; }
        }

        public Colors Aic
        {
            get { return aic; }
            set { aic = value; }
        }

        public AI.AI Ai
        {
            get { return ai; }
            set { ai = value; }
        }

        public string Name1
        {
            get { return name1; }
            set { name1 = value; }
        }

        public string Name2
        {
            get { return name2; }
            set { name2 = value; }
        }

        public JDialogFillName()
        {
            InitializeComponent();
            jRadioButtonBlack.Checked = true;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void JDialogFillName_Load(object sender, EventArgs e)
        {

        }
        private bool checkNames()
        {
            String tmp = jTextField1.Text;
            char[] jmeno;
            //jmeno = new char[tmp.length()];
            jmeno = tmp.ToCharArray();
            for (int i = 0; i < tmp.Length; i++)
            {
                if (jmeno[i] == ' ')
                {
                    return false;
                }
            }

            tmp = jTextField2.Text;
            //jmeno=new char[tmp.length()];
            jmeno = tmp.ToCharArray();
            for (int i = 0; i < tmp.Length; i++)
            {
                if (jmeno[i] == ' ')
                {
                    return false;
                }
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkNames())
            {
                if (t == GameType.PC)
                {
                    ai=(new AI.AI());
                    if (jRadioButtonBlack.Checked)
                    {
                        aic = Colors.WHITE;
                        name1 = "PC";
                        name2=(jTextField1.Text);
                    }
                    else {
                        aic = Colors.BLACK;
                        name1 = (jTextField1.Text);
                        name2 = "PC";
                    }
                }
                else {
                    //w.SetAiColor(null);
                    name1 = (jTextField1.Text);
                    name2 = (jTextField2.Text);
                }
                DialogResult = DialogResult.OK;
                //this.dispose();
            }
            else {
                MessageBox.Show(@"Please, write your nickname as one word(without spaces)");
            }
        }

        private void jRadioButtonWhite_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
