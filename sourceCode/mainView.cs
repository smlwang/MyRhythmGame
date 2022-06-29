using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class mainView : UserControl
    {
        static mainView mview;
        public static mainView Instance
        {
            get { return mview; }
        }
        List<gameInfo> songlist = new List<gameInfo>();
        gameInfo gameInfo;
        Keys []keyFlect = {Keys.D, Keys.F, Keys.J, Keys.K};
        TextBox[] trackSets;
        gameSet gameset = new gameSet(5, -30);
        gameSet defaultGameSet = new gameSet(5, -30);
        //long offset = -30; 
        //float speed = 5; // 0 - 20, / 10
        public mainView()
        {
            InitializeComponent();
            mview = this;
            trackSets = new TextBox[4] { trackSet1, trackSet2, trackSet3, trackSet4};
            readInfo();
        }
        void readInfo()
        {
            FileStream fs = new FileStream("gameInfo.dat", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string[] s = sr.ReadToEnd().Split('\n');
            for(int i = 0; i < s.Length; i += 2)
            {
                s[i] = s[i].TrimEnd(Info.spaceChar);
                s[i + 1] = s[i + 1].TrimEnd(Info.spaceChar);
                songlist.Add(new gameInfo(s[i], s[i + 1]));
            }
            for(int i = 0; i < songlist.Count; i++)
            {
                songList.Items.Add(songlist[i].musicInfo);
            }
        }
        private void start_Click(object sender, EventArgs e)
        {
            int idx = songList.SelectedIndex;
            if(idx < 0 || idx >= songlist.Count) return;
            gameForm.Instence.Enabled = true;
            Form1.Instance.view.Controls["gameForm"].BringToFront();
            gameInfo = songlist[idx];
            gameForm.Instence.gameStart(keyFlect, gameInfo, gameset);
            Enabled = false;
        }

        private void setting_Click(object sender, EventArgs e)
        {
            settingPanel.Enabled = true;
            settingPanel.Visible = true;
            songChose.Enabled = false;
            songChose.Visible = false;
        }
        private void trackSet1_KeyUp(object sender, KeyEventArgs e)
        {
            trackSet1.Text = e.KeyCode.ToString();
            keyFlect[0] = e.KeyCode;
        }
        private void trackSet2_KeyUp(object sender, KeyEventArgs e)
        {
            trackSet2.Text = e.KeyCode.ToString();
            keyFlect[1] = e.KeyCode;
        }
        private void trackSet3_KeyUp(object sender, KeyEventArgs e)
        {
            trackSet3.Text = e.KeyCode.ToString();
            keyFlect[2] = e.KeyCode;
        }
        private void trackSet4_KeyUp(object sender, KeyEventArgs e)
        {
            trackSet4.Text = e.KeyCode.ToString();
            keyFlect[3] = e.KeyCode;
        }
        void resetTrack()
        {
            keyFlect[0] = Keys.D;
            keyFlect[1] = Keys.F;
            keyFlect[2] = Keys.J;
            keyFlect[3] = Keys.K;
        }
        private void trackReset_Click(object sender, EventArgs e)
        {
            resetTrack();
            for(int i = 0; i < keyFlect.Length; i++)
                trackSets[i].Text = keyFlect[i].ToString();
        }


        private void backMain_Click(object sender, EventArgs e)
        {
            settingPanel.Visible = false;
            settingPanel.Enabled = false;
            songChose.Visible = true;
            songChose.Enabled = true;
        }

        private void mainView_Load(object sender, EventArgs e)
        {
            settingPanel.Visible = false;
            settingPanel.Enabled = false;
        }

        private void speedInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void settingPanel_Paint(object sender, PaintEventArgs e)
        {

        }
        void show()
        {
            speedInput.Text = gameset.speed.ToString();
            offsetInput.Text = gameset.offset.ToString();
            for(int i = 0; i < trackSets.Count(); i++)
            {   
                trackSets[i].Text = keyFlect[i].ToString();
            }
        }
        private void spdAd_Click(object sender, EventArgs e)
        {
            gameset.speed = gameset.speed + 1;
            if(gameset.speed > 30)
            {
                gameset.speed = 30;
            }
            show();
        }

        private void offsetRe_Click(object sender, EventArgs e)
        {
            gameset.offset = defaultGameSet.offset;
            show();
        }

        private void spdRe_Click(object sender, EventArgs e)
        {
            gameset.speed = defaultGameSet.speed;
            show();
        }

        private void spdAdd_Click(object sender, EventArgs e)
        {
            gameset.speed = gameset.speed + 5;
            if(gameset.speed > 30)
            {
                gameset.speed = 30;
            }
            show();
        }

        private void offsetSub_Click(object sender, EventArgs e)
        {
            gameset.offset = gameset.offset - 20;
            if(gameset.offset < -10000)
            {
                gameset.offset = -10000;
            }
            show();
        }

        private void offsetSu_Click(object sender, EventArgs e)
        {
            gameset.offset = gameset.offset - 1;
            if (gameset.offset < -10000)
            {
                gameset.offset = -10000;
            }
            show();
        }

        private void offsetAdd_Click(object sender, EventArgs e)
        {
            gameset.offset = gameset.offset + 20;
            if (gameset.offset > 10000)
            {
                gameset.offset = 10000;
            }
            show();
        }

        private void offsetAd_Click(object sender, EventArgs e)
        {
            gameset.offset = gameset.offset + 1;
            if (gameset.offset > 10000)
            {
                gameset.offset = 10000;
            }
            show();
        }

        private void spdSu_Click(object sender, EventArgs e)
        {
            gameset.speed = gameset.speed - 1;
            if (gameset.speed < 1)
            {
                gameset.speed = 1;
            }
            show();
        }

        private void spdSub_Click(object sender, EventArgs e)
        {
            gameset.speed = gameset.speed - 5;
            if (gameset.speed < 1)
            {
                gameset.speed = 1;
            }
            show();
        }

        private void settingPanel_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void settingPanel_Enter(object sender, EventArgs e)
        {
            show();
        }
    }
}
