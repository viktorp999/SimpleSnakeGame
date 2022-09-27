
namespace SimpleSnakeGame
{
    partial class SnakeForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SnakeForm));
            this.StartB = new System.Windows.Forms.Button();
            this.ScoreL = new System.Windows.Forms.Label();
            this.SnakeGraphicsPicBox = new System.Windows.Forms.PictureBox();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.SnakeGraphicsPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // StartB
            // 
            this.StartB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartB.Location = new System.Drawing.Point(572, 35);
            this.StartB.Name = "StartB";
            this.StartB.Size = new System.Drawing.Size(100, 40);
            this.StartB.TabIndex = 0;
            this.StartB.Text = "Start";
            this.StartB.UseVisualStyleBackColor = true;
            this.StartB.Click += new System.EventHandler(this.StartGame);
            // 
            // ScoreL
            // 
            this.ScoreL.AutoSize = true;
            this.ScoreL.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreL.Location = new System.Drawing.Point(569, 108);
            this.ScoreL.Name = "ScoreL";
            this.ScoreL.Size = new System.Drawing.Size(58, 18);
            this.ScoreL.TabIndex = 2;
            this.ScoreL.Text = "Score:";
            // 
            // SnakeGraphicsPicBox
            // 
            this.SnakeGraphicsPicBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.SnakeGraphicsPicBox.Location = new System.Drawing.Point(12, 12);
            this.SnakeGraphicsPicBox.Name = "SnakeGraphicsPicBox";
            this.SnakeGraphicsPicBox.Size = new System.Drawing.Size(550, 637);
            this.SnakeGraphicsPicBox.TabIndex = 5;
            this.SnakeGraphicsPicBox.TabStop = false;
            this.SnakeGraphicsPicBox.Paint += new System.Windows.Forms.PaintEventHandler(this.UpdateSnakeGraphics);
            // 
            // GameTimer
            // 
            this.GameTimer.Interval = 40;
            this.GameTimer.Tick += new System.EventHandler(this.Timer);
            // 
            // SnakeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 661);
            this.Controls.Add(this.SnakeGraphicsPicBox);
            this.Controls.Add(this.ScoreL);
            this.Controls.Add(this.StartB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SnakeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Snake Game";
            this.Load += new System.EventHandler(this.LoadGame);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.SnakeGraphicsPicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartB;
        private System.Windows.Forms.Label ScoreL;
        private System.Windows.Forms.PictureBox SnakeGraphicsPicBox;
        private System.Windows.Forms.Timer GameTimer;
    }
}

