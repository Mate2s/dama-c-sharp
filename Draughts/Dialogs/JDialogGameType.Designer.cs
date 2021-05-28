namespace Draughts
{
    partial class JDialogGameType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JDialogGameType));
            this.jLabel1 = new System.Windows.Forms.Label();
            this.jButton2 = new System.Windows.Forms.Button();
            this.jButton1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // jLabel1
            // 
            resources.ApplyResources(this.jLabel1, "jLabel1");
            this.jLabel1.Name = "jLabel1";
            this.jLabel1.Click += new System.EventHandler(this.jLabel1_Click);
            // 
            // jButton2
            // 
            resources.ApplyResources(this.jButton2, "jButton2");
            this.jButton2.Name = "jButton2";
            this.jButton2.UseVisualStyleBackColor = true;
            this.jButton2.Click += new System.EventHandler(this.jButton2_Click);
            // 
            // jButton1
            // 
            resources.ApplyResources(this.jButton1, "jButton1");
            this.jButton1.Name = "jButton1";
            this.jButton1.UseVisualStyleBackColor = true;
            this.jButton1.Click += new System.EventHandler(this.button2_Click);
            // 
            // JDialogGameType
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.jButton1);
            this.Controls.Add(this.jButton2);
            this.Controls.Add(this.jLabel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "JDialogGameType";
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label jLabel1;
        private System.Windows.Forms.Button jButton2;
        private System.Windows.Forms.Button jButton1;
    }
}