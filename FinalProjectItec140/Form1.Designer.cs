namespace FinalProjectItec140
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.picSnake = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnSinglePlayer = new System.Windows.Forms.Button();
            this.btnTwoPlayer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picSnake)).BeginInit();
            this.SuspendLayout();
            // 
            // picSnake
            // 
            this.picSnake.BackColor = System.Drawing.Color.GreenYellow;
            this.picSnake.Location = new System.Drawing.Point(600, 400);
            this.picSnake.Name = "picSnake";
            this.picSnake.Size = new System.Drawing.Size(10, 10);
            this.picSnake.TabIndex = 0;
            this.picSnake.TabStop = false;
            this.picSnake.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnSinglePlayer
            // 
            this.btnSinglePlayer.Location = new System.Drawing.Point(525, 100);
            this.btnSinglePlayer.Name = "btnSinglePlayer";
            this.btnSinglePlayer.Size = new System.Drawing.Size(150, 25);
            this.btnSinglePlayer.TabIndex = 1;
            this.btnSinglePlayer.Text = "Single Player";
            this.btnSinglePlayer.UseVisualStyleBackColor = true;
            this.btnSinglePlayer.Click += new System.EventHandler(this.btnSinglePlayer_Click);
            this.btnSinglePlayer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.btnSinglePlayer.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            // 
            // btnTwoPlayer
            // 
            this.btnTwoPlayer.Location = new System.Drawing.Point(525, 131);
            this.btnTwoPlayer.Name = "btnTwoPlayer";
            this.btnTwoPlayer.Size = new System.Drawing.Size(150, 25);
            this.btnTwoPlayer.TabIndex = 3;
            this.btnTwoPlayer.Text = "Two Player!";
            this.btnTwoPlayer.UseVisualStyleBackColor = true;
            this.btnTwoPlayer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.btnTwoPlayer.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.btnTwoPlayer);
            this.Controls.Add(this.btnSinglePlayer);
            this.Controls.Add(this.picSnake);
            this.Name = "Form1";
            this.Text = "Snakes R\' Us!";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.picSnake)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox picSnake;
        private System.Windows.Forms.Timer timer1;
        private Button btnSinglePlayer;
        private Button btnTwoPlayer;
    }
}