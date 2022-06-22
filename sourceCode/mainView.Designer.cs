namespace WindowsFormsApp2
{
    partial class mainView
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
            this.start = new System.Windows.Forms.Button();
            this.setting = new System.Windows.Forms.Button();
            this.settingPanel = new System.Windows.Forms.Panel();
            this.backMain = new System.Windows.Forms.Button();
            this.offsetInput = new System.Windows.Forms.TextBox();
            this.offsetLabel = new System.Windows.Forms.Label();
            this.speedInput = new System.Windows.Forms.TextBox();
            this.speedLabel = new System.Windows.Forms.Label();
            this.trackReset = new System.Windows.Forms.Button();
            this.trackSet4 = new System.Windows.Forms.TextBox();
            this.trackSet3 = new System.Windows.Forms.TextBox();
            this.trackSet2 = new System.Windows.Forms.TextBox();
            this.trackSet1 = new System.Windows.Forms.TextBox();
            this.track4 = new System.Windows.Forms.Label();
            this.track3 = new System.Windows.Forms.Label();
            this.track2 = new System.Windows.Forms.Label();
            this.track1 = new System.Windows.Forms.Label();
            this.songChose = new System.Windows.Forms.Panel();
            this.spdSub = new System.Windows.Forms.Button();
            this.spdSu = new System.Windows.Forms.Button();
            this.spdAdd = new System.Windows.Forms.Button();
            this.spdAd = new System.Windows.Forms.Button();
            this.offsetAdd = new System.Windows.Forms.Button();
            this.offsetAd = new System.Windows.Forms.Button();
            this.offsetSu = new System.Windows.Forms.Button();
            this.offsetSub = new System.Windows.Forms.Button();
            this.spdRe = new System.Windows.Forms.Button();
            this.offsetRe = new System.Windows.Forms.Button();
            this.songList = new System.Windows.Forms.ListBox();
            this.settingPanel.SuspendLayout();
            this.songChose.SuspendLayout();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(728, 268);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(150, 58);
            this.start.TabIndex = 0;
            this.start.Text = "开始";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // setting
            // 
            this.setting.Location = new System.Drawing.Point(729, 403);
            this.setting.Name = "setting";
            this.setting.Size = new System.Drawing.Size(149, 64);
            this.setting.TabIndex = 1;
            this.setting.Text = "设置";
            this.setting.UseVisualStyleBackColor = true;
            this.setting.Click += new System.EventHandler(this.setting_Click);
            // 
            // settingPanel
            // 
            this.settingPanel.Controls.Add(this.offsetRe);
            this.settingPanel.Controls.Add(this.spdRe);
            this.settingPanel.Controls.Add(this.offsetSu);
            this.settingPanel.Controls.Add(this.offsetSub);
            this.settingPanel.Controls.Add(this.offsetAdd);
            this.settingPanel.Controls.Add(this.offsetAd);
            this.settingPanel.Controls.Add(this.spdAdd);
            this.settingPanel.Controls.Add(this.spdAd);
            this.settingPanel.Controls.Add(this.spdSu);
            this.settingPanel.Controls.Add(this.spdSub);
            this.settingPanel.Controls.Add(this.backMain);
            this.settingPanel.Controls.Add(this.offsetInput);
            this.settingPanel.Controls.Add(this.offsetLabel);
            this.settingPanel.Controls.Add(this.speedInput);
            this.settingPanel.Controls.Add(this.speedLabel);
            this.settingPanel.Controls.Add(this.trackReset);
            this.settingPanel.Controls.Add(this.trackSet4);
            this.settingPanel.Controls.Add(this.trackSet3);
            this.settingPanel.Controls.Add(this.trackSet2);
            this.settingPanel.Controls.Add(this.trackSet1);
            this.settingPanel.Controls.Add(this.track4);
            this.settingPanel.Controls.Add(this.track3);
            this.settingPanel.Controls.Add(this.track2);
            this.settingPanel.Controls.Add(this.track1);
            this.settingPanel.Location = new System.Drawing.Point(87, 54);
            this.settingPanel.Name = "settingPanel";
            this.settingPanel.Size = new System.Drawing.Size(900, 511);
            this.settingPanel.TabIndex = 2;
            this.settingPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.settingPanel_Paint);
            this.settingPanel.Enter += new System.EventHandler(this.settingPanel_Enter);
            this.settingPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.settingPanel_MouseMove);
            // 
            // backMain
            // 
            this.backMain.Location = new System.Drawing.Point(728, 406);
            this.backMain.Name = "backMain";
            this.backMain.Size = new System.Drawing.Size(150, 58);
            this.backMain.TabIndex = 3;
            this.backMain.Text = "返回";
            this.backMain.UseVisualStyleBackColor = true;
            this.backMain.Click += new System.EventHandler(this.backMain_Click);
            // 
            // offsetInput
            // 
            this.offsetInput.Location = new System.Drawing.Point(218, 137);
            this.offsetInput.Name = "offsetInput";
            this.offsetInput.Size = new System.Drawing.Size(73, 25);
            this.offsetInput.TabIndex = 15;
            // 
            // offsetLabel
            // 
            this.offsetLabel.AutoSize = true;
            this.offsetLabel.Location = new System.Drawing.Point(106, 140);
            this.offsetLabel.Name = "offsetLabel";
            this.offsetLabel.Size = new System.Drawing.Size(37, 15);
            this.offsetLabel.TabIndex = 14;
            this.offsetLabel.Text = "偏移";
            // 
            // speedInput
            // 
            this.speedInput.Location = new System.Drawing.Point(228, 66);
            this.speedInput.Name = "speedInput";
            this.speedInput.Size = new System.Drawing.Size(52, 25);
            this.speedInput.TabIndex = 13;
            this.speedInput.TextChanged += new System.EventHandler(this.speedInput_TextChanged);
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.Location = new System.Drawing.Point(106, 69);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(37, 15);
            this.speedLabel.TabIndex = 12;
            this.speedLabel.Text = "流速";
            // 
            // trackReset
            // 
            this.trackReset.Location = new System.Drawing.Point(315, 363);
            this.trackReset.Name = "trackReset";
            this.trackReset.Size = new System.Drawing.Size(84, 61);
            this.trackReset.TabIndex = 11;
            this.trackReset.Text = "重置按键";
            this.trackReset.UseVisualStyleBackColor = true;
            this.trackReset.Click += new System.EventHandler(this.trackReset_Click);
            // 
            // trackSet4
            // 
            this.trackSet4.Location = new System.Drawing.Point(203, 438);
            this.trackSet4.Name = "trackSet4";
            this.trackSet4.Size = new System.Drawing.Size(53, 25);
            this.trackSet4.TabIndex = 10;
            this.trackSet4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.trackSet4.KeyUp += new System.Windows.Forms.KeyEventHandler(this.trackSet4_KeyUp);
            // 
            // trackSet3
            // 
            this.trackSet3.Location = new System.Drawing.Point(203, 400);
            this.trackSet3.Name = "trackSet3";
            this.trackSet3.Size = new System.Drawing.Size(53, 25);
            this.trackSet3.TabIndex = 9;
            this.trackSet3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.trackSet3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.trackSet3_KeyUp);
            // 
            // trackSet2
            // 
            this.trackSet2.Location = new System.Drawing.Point(203, 363);
            this.trackSet2.Name = "trackSet2";
            this.trackSet2.Size = new System.Drawing.Size(53, 25);
            this.trackSet2.TabIndex = 8;
            this.trackSet2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.trackSet2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.trackSet2_KeyUp);
            // 
            // trackSet1
            // 
            this.trackSet1.Location = new System.Drawing.Point(203, 326);
            this.trackSet1.Name = "trackSet1";
            this.trackSet1.Size = new System.Drawing.Size(53, 25);
            this.trackSet1.TabIndex = 7;
            this.trackSet1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.trackSet1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.trackSet1_KeyUp);
            // 
            // track4
            // 
            this.track4.AutoSize = true;
            this.track4.Location = new System.Drawing.Point(114, 441);
            this.track4.Name = "track4";
            this.track4.Size = new System.Drawing.Size(30, 15);
            this.track4.TabIndex = 6;
            this.track4.Text = "轨4";
            // 
            // track3
            // 
            this.track3.AutoSize = true;
            this.track3.Location = new System.Drawing.Point(114, 404);
            this.track3.Name = "track3";
            this.track3.Size = new System.Drawing.Size(30, 15);
            this.track3.TabIndex = 4;
            this.track3.Text = "轨3";
            // 
            // track2
            // 
            this.track2.AutoSize = true;
            this.track2.Location = new System.Drawing.Point(114, 367);
            this.track2.Name = "track2";
            this.track2.Size = new System.Drawing.Size(30, 15);
            this.track2.TabIndex = 2;
            this.track2.Text = "轨2";
            // 
            // track1
            // 
            this.track1.AutoSize = true;
            this.track1.Location = new System.Drawing.Point(114, 330);
            this.track1.Name = "track1";
            this.track1.Size = new System.Drawing.Size(30, 15);
            this.track1.TabIndex = 0;
            this.track1.Text = "轨1";
            // 
            // songChose
            // 
            this.songChose.Controls.Add(this.songList);
            this.songChose.Controls.Add(this.start);
            this.songChose.Controls.Add(this.setting);
            this.songChose.Location = new System.Drawing.Point(87, 54);
            this.songChose.Name = "songChose";
            this.songChose.Size = new System.Drawing.Size(900, 511);
            this.songChose.TabIndex = 3;
            // 
            // spdSub
            // 
            this.spdSub.Font = new System.Drawing.Font("宋体", 5F);
            this.spdSub.Location = new System.Drawing.Point(200, 66);
            this.spdSub.Name = "spdSub";
            this.spdSub.Size = new System.Drawing.Size(25, 25);
            this.spdSub.TabIndex = 16;
            this.spdSub.Text = "<<";
            this.spdSub.UseVisualStyleBackColor = true;
            this.spdSub.Click += new System.EventHandler(this.spdSub_Click);
            // 
            // spdSu
            // 
            this.spdSu.Font = new System.Drawing.Font("宋体", 5F);
            this.spdSu.Location = new System.Drawing.Point(173, 66);
            this.spdSu.Name = "spdSu";
            this.spdSu.Size = new System.Drawing.Size(25, 25);
            this.spdSu.TabIndex = 17;
            this.spdSu.Text = "<";
            this.spdSu.UseVisualStyleBackColor = true;
            this.spdSu.Click += new System.EventHandler(this.spdSu_Click);
            // 
            // spdAdd
            // 
            this.spdAdd.Font = new System.Drawing.Font("宋体", 5F);
            this.spdAdd.Location = new System.Drawing.Point(283, 66);
            this.spdAdd.Name = "spdAdd";
            this.spdAdd.Size = new System.Drawing.Size(25, 25);
            this.spdAdd.TabIndex = 19;
            this.spdAdd.Text = ">>";
            this.spdAdd.UseVisualStyleBackColor = true;
            this.spdAdd.Click += new System.EventHandler(this.spdAdd_Click);
            // 
            // spdAd
            // 
            this.spdAd.Font = new System.Drawing.Font("宋体", 5F);
            this.spdAd.Location = new System.Drawing.Point(310, 66);
            this.spdAd.Name = "spdAd";
            this.spdAd.Size = new System.Drawing.Size(25, 25);
            this.spdAd.TabIndex = 18;
            this.spdAd.Text = ">";
            this.spdAd.UseVisualStyleBackColor = true;
            this.spdAd.Click += new System.EventHandler(this.spdAd_Click);
            // 
            // offsetAdd
            // 
            this.offsetAdd.Font = new System.Drawing.Font("宋体", 5F);
            this.offsetAdd.Location = new System.Drawing.Point(298, 137);
            this.offsetAdd.Name = "offsetAdd";
            this.offsetAdd.Size = new System.Drawing.Size(25, 25);
            this.offsetAdd.TabIndex = 21;
            this.offsetAdd.Text = ">>";
            this.offsetAdd.UseVisualStyleBackColor = true;
            this.offsetAdd.Click += new System.EventHandler(this.offsetAdd_Click);
            // 
            // offsetAd
            // 
            this.offsetAd.Font = new System.Drawing.Font("宋体", 5F);
            this.offsetAd.Location = new System.Drawing.Point(325, 137);
            this.offsetAd.Name = "offsetAd";
            this.offsetAd.Size = new System.Drawing.Size(25, 25);
            this.offsetAd.TabIndex = 20;
            this.offsetAd.Text = ">";
            this.offsetAd.UseVisualStyleBackColor = true;
            this.offsetAd.Click += new System.EventHandler(this.offsetAd_Click);
            // 
            // offsetSu
            // 
            this.offsetSu.Font = new System.Drawing.Font("宋体", 5F);
            this.offsetSu.Location = new System.Drawing.Point(160, 137);
            this.offsetSu.Name = "offsetSu";
            this.offsetSu.Size = new System.Drawing.Size(25, 25);
            this.offsetSu.TabIndex = 23;
            this.offsetSu.Text = "<";
            this.offsetSu.UseVisualStyleBackColor = true;
            this.offsetSu.Click += new System.EventHandler(this.offsetSu_Click);
            // 
            // offsetSub
            // 
            this.offsetSub.Font = new System.Drawing.Font("宋体", 5F);
            this.offsetSub.Location = new System.Drawing.Point(187, 137);
            this.offsetSub.Name = "offsetSub";
            this.offsetSub.Size = new System.Drawing.Size(25, 25);
            this.offsetSub.TabIndex = 22;
            this.offsetSub.Text = "<<";
            this.offsetSub.UseVisualStyleBackColor = true;
            this.offsetSub.Click += new System.EventHandler(this.offsetSub_Click);
            // 
            // spdRe
            // 
            this.spdRe.Location = new System.Drawing.Point(341, 66);
            this.spdRe.Name = "spdRe";
            this.spdRe.Size = new System.Drawing.Size(70, 25);
            this.spdRe.TabIndex = 24;
            this.spdRe.Text = "重置";
            this.spdRe.UseVisualStyleBackColor = true;
            this.spdRe.Click += new System.EventHandler(this.spdRe_Click);
            // 
            // offsetRe
            // 
            this.offsetRe.Location = new System.Drawing.Point(356, 137);
            this.offsetRe.Name = "offsetRe";
            this.offsetRe.Size = new System.Drawing.Size(70, 25);
            this.offsetRe.TabIndex = 25;
            this.offsetRe.Text = "重置";
            this.offsetRe.UseVisualStyleBackColor = true;
            this.offsetRe.Click += new System.EventHandler(this.offsetRe_Click);
            // 
            // songList
            // 
            this.songList.FormattingEnabled = true;
            this.songList.ItemHeight = 15;
            this.songList.Location = new System.Drawing.Point(95, 47);
            this.songList.Name = "songList";
            this.songList.Size = new System.Drawing.Size(240, 409);
            this.songList.TabIndex = 2;
            // 
            // mainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.songChose);
            this.Controls.Add(this.settingPanel);
            this.Name = "mainView";
            this.Size = new System.Drawing.Size(1200, 800);
            this.Load += new System.EventHandler(this.mainView_Load);
            this.settingPanel.ResumeLayout(false);
            this.settingPanel.PerformLayout();
            this.songChose.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button setting;
        private System.Windows.Forms.Panel settingPanel;
        private System.Windows.Forms.Label track4;
        private System.Windows.Forms.Label track3;
        private System.Windows.Forms.Label track2;
        private System.Windows.Forms.Label track1;
        private System.Windows.Forms.TextBox trackSet4;
        private System.Windows.Forms.TextBox trackSet3;
        private System.Windows.Forms.TextBox trackSet2;
        private System.Windows.Forms.TextBox trackSet1;
        private System.Windows.Forms.Button trackReset;
        private System.Windows.Forms.TextBox offsetInput;
        private System.Windows.Forms.Label offsetLabel;
        private System.Windows.Forms.TextBox speedInput;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.Button backMain;
        private System.Windows.Forms.Panel songChose;
        private System.Windows.Forms.Button spdAdd;
        private System.Windows.Forms.Button spdAd;
        private System.Windows.Forms.Button spdSu;
        private System.Windows.Forms.Button spdSub;
        private System.Windows.Forms.Button offsetSu;
        private System.Windows.Forms.Button offsetSub;
        private System.Windows.Forms.Button offsetAdd;
        private System.Windows.Forms.Button offsetAd;
        private System.Windows.Forms.Button offsetRe;
        private System.Windows.Forms.Button spdRe;
        private System.Windows.Forms.ListBox songList;
    }
}
