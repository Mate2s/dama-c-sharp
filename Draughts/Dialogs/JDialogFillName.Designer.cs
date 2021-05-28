namespace Draughts
{
    partial class JDialogFillName
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JDialogFillName));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.jTextField1 = new System.Windows.Forms.TextBox();
            this.jTextField2 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.jRadioButtonWhite = new System.Windows.Forms.RadioButton();
            this.jRadioButtonBlack = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // jTextField1
            // 
            resources.ApplyResources(this.jTextField1, "jTextField1");
            this.jTextField1.Name = "jTextField1";
            // 
            // jTextField2
            // 
            resources.ApplyResources(this.jTextField2, "jTextField2");
            this.jTextField2.Name = "jTextField2";
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.jRadioButtonWhite);
            this.groupBox1.Controls.Add(this.jRadioButtonBlack);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // jRadioButtonWhite
            // 
            resources.ApplyResources(this.jRadioButtonWhite, "jRadioButtonWhite");
            this.jRadioButtonWhite.Name = "jRadioButtonWhite";
            this.jRadioButtonWhite.TabStop = true;
            this.jRadioButtonWhite.UseVisualStyleBackColor = true;
            this.jRadioButtonWhite.CheckedChanged += new System.EventHandler(this.jRadioButtonWhite_CheckedChanged);
            // 
            // jRadioButtonBlack
            // 
            resources.ApplyResources(this.jRadioButtonBlack, "jRadioButtonBlack");
            this.jRadioButtonBlack.Name = "jRadioButtonBlack";
            this.jRadioButtonBlack.TabStop = true;
            this.jRadioButtonBlack.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // JDialogFillName
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.jTextField2);
            this.Controls.Add(this.jTextField1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "JDialogFillName";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.JDialogFillName_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox jTextField1;
        private System.Windows.Forms.TextBox jTextField2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton jRadioButtonWhite;
        private System.Windows.Forms.RadioButton jRadioButtonBlack;
        private System.Windows.Forms.Button button1;
    }
}