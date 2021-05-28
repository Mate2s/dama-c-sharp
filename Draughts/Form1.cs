using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Draughts.Enums;

namespace Draughts
{
    public partial class Form1 : Form
    {
        public delegate void MyEventHandler();
        private DateTime start;
        private bool end = false;
        private int clickx = 0;
        private int clicky = 0;
        private bool clicked = false;
        private GameType gametype = GameType.PC;
        private String name1 = "Player1";
        private String name2 = "Player2";
        private String winner = "";
        private Colors aicolor;
        private Colors helpmove;
        private AI.AI ai = null;
        private Thread thread1 = null;
        private JDialogGameType c = null;
        LoaderAssembly  loaderassembly = new LoaderAssembly();
        private String culture = "en-US";

        private string path =
            @"..\..\..\..\Draughts\AssemblyLibrary\bin\Debug\AssemblyLibrary.dll";

        public Form1()
        {
            InitializeComponent();
            start = DateTime.Now;
            NewGame();
            LoadAssembly();
            Writelog("load assembly");
            CheckAssembly();
            Writelog("checked assembly");
            Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
        }

       

        private void LoadAssembly()
        {
            loaderassembly.LoadAssembly(path);
        }

        private void CheckAssembly()
        {
            if (!loaderassembly.AssemblyCheck(path))
            {
                throw new MyException();
            }
        }

        //aktualizace casu co vterinu
        private void A()
        {
            for (;;)
            {
                try
                {
                    Thread.Sleep(1000);
                    jLabelTime.Invoke(new MyEventHandler(() =>
                    {
                        DateTime now = DateTime.Now;
                        jLabelTime.Text = now.ToString("h:mm:ss");
                    }));
                    jLabelPlaytime.Invoke(new MyEventHandler(() =>
                    {
                        DateTime now = DateTime.Now;
                        TimeSpan ss = now - start;
                        jLabelPlaytime.Text = new DateTime(ss.Ticks).ToString("HH:mm:ss");
                    }));
                }
                catch (Exception ex)
                {
                    
                }

            }

        }



        private void board1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public GameType GetGameType()
        {
            return gametype;
        }

        public String GetWinner()
        {
            return winner;
        }

        public Board GetBoard()
        {
            return board1;
        }

        public void SetTime(String s)
        {
            jLabelTime.Text = s;
        }

        public void SetPlaytime(String s)
        {
            jLabelPlaytime.Text = s;
        }

        public void SetAi(AI.AI pc)
        {
            ai = pc;
        }

        public void SetAiColor(Colors c)
        {
            aicolor = c;
        }

        public void SetName1(String name)
        {
            name1 = name;
        }

        public void SetName2(String name)
        {
            name2 = name;
        }

        public void SetGameType(GameType type)
        {
            gametype = type;
        }

        private void Report(Actions a, String name)
        {
            switch (a)
            {
                case Actions.NEXT:
                    jLabel1.Text = "";
                    break;

                case Actions.FOCUSED:
                    jLabel1.Text = @" >> selected";
                    break;

                case Actions.KEEP_JUMPING:
                    jLabel1.Text = (name + @" >> keep jumping");
                    break;

                case Actions.TRY_JUMP:
                    jLabel1.Text = (name + @" >> jump where u can");
                    break;

                case Actions.FOCUS_OR_JUMP:
                    jLabel1.Text = (name + @" >> select something what can jump or jump");
                    break;

                case Actions.TRY_FOCUS:
                    jLabel1.Text = (name + @" >> select something what can Move");
                    break;

                case Actions.TRY_MOVE:
                    jLabel1.Text = (name + @" >> try Move where u can");
                    break;

                case Actions.TRY_FOCUS_TO_JUMP:
                    jLabel1.Text = (name + @" >> try select something what can jump");
                    break;
            }
        }

 

        public void NewGame()
        {

            c = new JDialogGameType();
            if (c.ShowDialog() == DialogResult.OK)
            {
                gametype = c.Type;
            }


            JDialogFillName fn = new JDialogFillName();
            jLabelName1.Text = (name1);
            jLabelName2.Text = (name2);
            fn.T = gametype;
            if (fn.ShowDialog() == DialogResult.OK)
            {

                name1 = fn.Name1;
                jLabelName1.Text = name1;
                name2 = fn.Name2;
                jLabelName2.Text = name2;
                ai = fn.Ai;
                aicolor = fn.Aic;
            }
            board1.startGame();
            if (gametype == GameType.PC)
            {
                ai.SetBoard(board1);
            }
            end = false;
            clicked = false;
            if (thread1 == null)
            {
                thread1 = new Thread(new ThreadStart(A));
                thread1.IsBackground = true;
                thread1.Start();
            }
        }

        public void End()
        {
            end = board1.isEnd();
            if (end)
            {
                if (board1.getMove() == Colors.BLACK)
                {
                    winner = name1;
                }
                else {
                    winner = name2;
                }
                JDialogGameOver go = new JDialogGameOver();
                go.Winner = ("Winner is " + winner);
                go.ShowDialog();
            }
        }

        private void board1_MouseDown(object sender, MouseEventArgs e)
        {
            clicked = true;
            clickx = e.X / board1.getFieldsize();
            clicky = e.Y / board1.getFieldsize();
        }

        private void board1_MouseUp(object sender, MouseEventArgs e)
        {
            if (end == false)
            {
                int x = e.X / board1.getFieldsize();
                int y = e.Y / board1.getFieldsize();
                String name;
                if (board1.getMove() == Colors.WHITE)
                {
                    name = name1;
                }
                else {
                    name = name2;
                }

                if (gametype == GameType.PLAYER)
                {
                    Actions a = board1.action(x, y);
                    Report(a, name);
                }
                else {
                    if (board1.getMove() == aicolor)
                    {
                        ai.AIFocus();
                        while (true)
                        {
                            
                            if (ai.AIAction() == true)
                            {
                                break;
                            }
                        }
                    }
                    else {
                        Actions a = board1.action(x, y);
                        Report(a, name);
                        End();
                        if (end == true)
                        {
                            return;
                        }

                        if (board1.getMove() == aicolor)
                        {
                            ai.AIFocus();
                            while (true)
                            {
                                
                                if (ai.AIAction() == true)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }

            }

            End();

            board1.Invalidate();
            Invalidate();
            clicked = false;
        }

        private void loToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void saveGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void jLabelName1_Click(object sender, EventArgs e)
        {

        }

        private void board1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void board1_Click(object sender, EventArgs e)
        {

        }

        private void board1_MouseDown_1(object sender, MouseEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }


        private void czToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }


        private void enToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        void Writelog(string message)
        {
            string m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            try
            {
                using (StreamWriter w = File.AppendText(m_exePath + "\\" + "log.txt"))
                {
                    w.WriteLine(DateTime.Now + ": " + message);
                    w.Flush();
                }
            }
            catch (Exception ex)
            {
            }
        }


        private void changetoczToolStripMenuItem_Click(object sender, EventArgs e)
        {
            culture = "cs-CZ";
            Debug.WriteLine(DateTime.Now.ToLongTimeString() + " Use assembly method to load cz culture");
            loaderassembly.LoadMethodChangeCulture(culture);


            JDialogAsk fn = new JDialogAsk();
            if (fn.ShowDialog() == DialogResult.OK)
            {
                Controls.Clear();
                InitializeComponent();
                start = DateTime.Now;
                NewGame();
            }
        }

        private void changeToEnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            culture = "en-US";

            Debug.WriteLine(DateTime.Now.ToLongTimeString() + " Use assembly method to load en culture");
            loaderassembly.LoadMethodChangeCulture(culture);

            JDialogAsk fn = new JDialogAsk();
            if (fn.ShowDialog() == DialogResult.OK)
            {
                Controls.Clear();
                InitializeComponent();
                start = DateTime.Now;
                NewGame();
            }
                


        }
    }

}
