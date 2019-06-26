namespace Pong
{
    partial class FormPong
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbBackGround = new System.Windows.Forms.PictureBox();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.lblLeftScore = new System.Windows.Forms.Label();
            this.lblRightsScore = new System.Windows.Forms.Label();
            this.delaytimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbBackGround)).BeginInit();
            this.SuspendLayout();
            // 
            // pbBackGround
            // 
            this.pbBackGround.BackColor = System.Drawing.Color.Black;
            this.pbBackGround.Location = new System.Drawing.Point(0, 0);
            this.pbBackGround.Name = "pbBackGround";
            this.pbBackGround.Size = new System.Drawing.Size(840, 550);
            this.pbBackGround.TabIndex = 0;
            this.pbBackGround.TabStop = false;
            this.pbBackGround.Paint += new System.Windows.Forms.PaintEventHandler(this.pbBackGround_Paint);
            // 
            // GameTimer
            // 
            this.GameTimer.Interval = 30;
            this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // lblLeftScore
            // 
            this.lblLeftScore.AutoSize = true;
            this.lblLeftScore.BackColor = System.Drawing.Color.Transparent;
            this.lblLeftScore.Font = new System.Drawing.Font("Courier New", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeftScore.ForeColor = System.Drawing.Color.White;
            this.lblLeftScore.Location = new System.Drawing.Point(211, 98);
            this.lblLeftScore.Name = "lblLeftScore";
            this.lblLeftScore.Size = new System.Drawing.Size(40, 40);
            this.lblLeftScore.TabIndex = 5;
            this.lblLeftScore.Text = "0";
            // 
            // lblRightsScore
            // 
            this.lblRightsScore.AutoSize = true;
            this.lblRightsScore.BackColor = System.Drawing.Color.Transparent;
            this.lblRightsScore.Font = new System.Drawing.Font("Courier New", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRightsScore.ForeColor = System.Drawing.Color.White;
            this.lblRightsScore.Location = new System.Drawing.Point(594, 98);
            this.lblRightsScore.Name = "lblRightsScore";
            this.lblRightsScore.Size = new System.Drawing.Size(40, 40);
            this.lblRightsScore.TabIndex = 6;
            this.lblRightsScore.Text = "0";
            // 
            // delaytimer
            // 
            this.delaytimer.Interval = 1000;
            // 
            // FormPong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 553);
            this.Controls.Add(this.lblRightsScore);
            this.Controls.Add(this.lblLeftScore);
            this.Controls.Add(this.pbBackGround);
            this.Name = "FormPong";
            this.Text = "Pong";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormPong_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormPong_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbBackGround)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbBackGround;
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.Label lblLeftScore;
        private System.Windows.Forms.Label lblRightsScore;
        private System.Windows.Forms.Timer delaytimer;
    }
}

