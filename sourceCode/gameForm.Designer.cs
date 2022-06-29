namespace WindowsFormsApp2
{
    partial class gameForm
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.gameView = new System.Windows.Forms.PictureBox();
            this.restart = new System.Windows.Forms.Button();
            this.back = new System.Windows.Forms.Button();
            this.endPic = new System.Windows.Forms.PictureBox();
            this.backtogame = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gameView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endPic)).BeginInit();
            this.SuspendLayout();
            // 
            // gameView
            // 
            this.gameView.Location = new System.Drawing.Point(0, 0);
            this.gameView.Name = "gameView";
            this.gameView.Size = new System.Drawing.Size(800, 752);
            this.gameView.TabIndex = 1;
            this.gameView.TabStop = false;
            // 
            // restart
            // 
            this.restart.Location = new System.Drawing.Point(920, 542);
            this.restart.Name = "restart";
            this.restart.Size = new System.Drawing.Size(127, 48);
            this.restart.TabIndex = 2;
            this.restart.Text = "ReStart";
            this.restart.UseVisualStyleBackColor = true;
            this.restart.Click += new System.EventHandler(this.restart_Click);
            // 
            // back
            // 
            this.back.Location = new System.Drawing.Point(920, 622);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(127, 48);
            this.back.TabIndex = 3;
            this.back.Text = "back";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // endPic
            // 
            this.endPic.Location = new System.Drawing.Point(866, 67);
            this.endPic.Name = "endPic";
            this.endPic.Size = new System.Drawing.Size(225, 335);
            this.endPic.TabIndex = 4;
            this.endPic.TabStop = false;
            // 
            // backtogame
            // 
            this.backtogame.Location = new System.Drawing.Point(919, 458);
            this.backtogame.Name = "backtogame";
            this.backtogame.Size = new System.Drawing.Size(127, 48);
            this.backtogame.TabIndex = 5;
            this.backtogame.Text = "continue";
            this.backtogame.UseVisualStyleBackColor = true;
            this.backtogame.Click += new System.EventHandler(this.backtogame_Click);
            // 
            // gameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.backtogame);
            this.Controls.Add(this.endPic);
            this.Controls.Add(this.back);
            this.Controls.Add(this.restart);
            this.Controls.Add(this.gameView);
            this.Name = "gameForm";
            this.Size = new System.Drawing.Size(1179, 752);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gameForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gameForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.gameView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox gameView;
        private System.Windows.Forms.Button restart;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.PictureBox endPic;
        private System.Windows.Forms.Button backtogame;
    }
}
