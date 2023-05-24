namespace Parser
{
    partial class Glavna
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Glavna));
            panel1 = new Panel();
            panel2 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            button2 = new Button();
            button1 = new Button();
            label3 = new Label();
            label2 = new Label();
            toolTip1 = new ToolTip(components);
            linkLabel3 = new LinkLabel();
            linkLabel1 = new LinkLabel();
            label4 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(121, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 103);
            panel1.TabIndex = 20;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Black;
            panel2.Controls.Add(label1);
            panel2.Location = new Point(9, 9);
            panel2.Name = "panel2";
            panel2.Size = new Size(180, 83);
            panel2.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 36F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(6, 8);
            label1.Name = "label1";
            label1.Size = new Size(167, 65);
            label1.TabIndex = 2;
            label1.Text = "Parser";
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(103, 103);
            pictureBox1.TabIndex = 19;
            pictureBox1.TabStop = false;
            // 
            // button2
            // 
            button2.Location = new Point(12, 235);
            button2.Name = "button2";
            button2.Size = new Size(311, 53);
            button2.TabIndex = 24;
            button2.Text = "Otvori Excel parser";
            toolTip1.SetToolTip(button2, "Otvara aplikaciju koja kopira sve vazne podatke sa ATS registra u Excel tabelu");
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(12, 176);
            button1.Name = "button1";
            button1.Size = new Size(311, 53);
            button1.TabIndex = 23;
            button1.Text = "Otvori SQL parser";
            toolTip1.SetToolTip(button1, "Otvara aplikaciju koja prebacuje bazu podataka iz Postgre u MySQL");
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 158);
            label3.Name = "label3";
            label3.Size = new Size(227, 15);
            label3.TabIndex = 22;
            label3.Text = "Pokrenite aplikaciju koja vam je potrebna.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 133);
            label2.Name = "label2";
            label2.Size = new Size(119, 15);
            label2.TabIndex = 21;
            label2.Text = "Dobro došli u Parser! ";
            // 
            // linkLabel3
            // 
            linkLabel3.AutoSize = true;
            linkLabel3.Location = new Point(12, 321);
            linkLabel3.Name = "linkLabel3";
            linkLabel3.Size = new Size(196, 15);
            linkLabel3.TabIndex = 27;
            linkLabel3.TabStop = true;
            linkLabel3.Text = "https://github.com/LukaStef/parser";
            linkLabel3.LinkClicked += linkLabel3_LinkClicked;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(12, 306);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(245, 15);
            linkLabel1.TabIndex = 26;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "https://www.lukastefanovic.com/parser.html";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 291);
            label4.Name = "label4";
            label4.Size = new Size(90, 15);
            label4.TabIndex = 25;
            label4.Text = "Luka Stefanović";
            // 
            // Glavna
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(335, 349);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(linkLabel3);
            Controls.Add(linkLabel1);
            Controls.Add(label4);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Glavna";
            Text = "Parser v2.0.0";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private PictureBox pictureBox1;
        private Button button2;
        private ToolTip toolTip1;
        private Button button1;
        private Label label3;
        private Label label2;
        private LinkLabel linkLabel3;
        private LinkLabel linkLabel1;
        private Label label4;
    }
}