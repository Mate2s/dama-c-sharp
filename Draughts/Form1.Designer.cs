namespace Draughts
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changetoczToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changetoenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jLabelTime = new System.Windows.Forms.Label();
            this.jLabelPlaytime = new System.Windows.Forms.Label();
            this.jLabel1 = new System.Windows.Forms.Label();
            this.jLabelName1 = new System.Windows.Forms.Label();
            this.jLabelName2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.board1 = new Draughts.Board();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // gameToolStripMenuItem
            // 
            resources.ApplyResources(this.gameToolStripMenuItem, "gameToolStripMenuItem");
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.changetoczToolStripMenuItem,
            this.changetoenToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            // 
            // newToolStripMenuItem
            // 
            resources.ApplyResources(this.newToolStripMenuItem, "newToolStripMenuItem");
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // changetoczToolStripMenuItem
            // 
            resources.ApplyResources(this.changetoczToolStripMenuItem, "changetoczToolStripMenuItem");
            this.changetoczToolStripMenuItem.Name = "changetoczToolStripMenuItem";
            this.changetoczToolStripMenuItem.Click += new System.EventHandler(this.changetoczToolStripMenuItem_Click);
            // 
            // changetoenToolStripMenuItem
            // 
            resources.ApplyResources(this.changetoenToolStripMenuItem, "changetoenToolStripMenuItem");
            this.changetoenToolStripMenuItem.Name = "changetoenToolStripMenuItem";
            this.changetoenToolStripMenuItem.Click += new System.EventHandler(this.changeToEnToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // jLabelTime
            // 
            resources.ApplyResources(this.jLabelTime, "jLabelTime");
            this.jLabelTime.Name = "jLabelTime";
            // 
            // jLabelPlaytime
            // 
            resources.ApplyResources(this.jLabelPlaytime, "jLabelPlaytime");
            this.jLabelPlaytime.Name = "jLabelPlaytime";
            // 
            // jLabel1
            // 
            resources.ApplyResources(this.jLabel1, "jLabel1");
            this.jLabel1.Name = "jLabel1";
            this.jLabel1.Click += new System.EventHandler(this.label1_Click);
            // 
            // jLabelName1
            // 
            resources.ApplyResources(this.jLabelName1, "jLabelName1");
            this.jLabelName1.Name = "jLabelName1";
            this.jLabelName1.Click += new System.EventHandler(this.jLabelName1_Click);
            // 
            // jLabelName2
            // 
            resources.ApplyResources(this.jLabelName2, "jLabelName2");
            this.jLabelName2.Name = "jLabelName2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // board1
            // 
            resources.ApplyResources(this.board1, "board1");
            this.board1.EndColor = System.Drawing.Color.DarkBlue;
            this.board1.GradientAngle = 90;
            this.board1.Name = "board1";
            this.board1.StartColor = System.Drawing.Color.SteelBlue;
            this.board1.Transparent1 = 150;
            this.board1.Transparent2 = 150;
            this.board1.Click += new System.EventHandler(this.board1_Click);
            this.board1.Paint += new System.Windows.Forms.PaintEventHandler(this.board1_Paint_1);
            this.board1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.board1_MouseDown);
            this.board1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.board1_MouseUp);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.board1);
            this.Controls.Add(this.jLabelName2);
            this.Controls.Add(this.jLabelName1);
            this.Controls.Add(this.jLabel1);
            this.Controls.Add(this.jLabelPlaytime);
            this.Controls.Add(this.jLabelTime);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changetoczToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changetoenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label jLabelTime;
        private System.Windows.Forms.Label jLabelPlaytime;
        private System.Windows.Forms.Label jLabel1;
        private System.Windows.Forms.Label jLabelName1;
        private System.Windows.Forms.Label jLabelName2;
        private Board board1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

