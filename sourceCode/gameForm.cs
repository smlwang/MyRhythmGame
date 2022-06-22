using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class gameForm : UserControl
    {
        static gameForm gameform;
        Timer timer;
        public static gameForm Instence
        {
            get { return gameform; }
        }
        public gameForm()
        {
            InitializeComponent();
            gameform = this;
        }
        public void stoppedShow()
        {
            back.Visible = true;
            back.Enabled = true;
            restart.Visible = true;
            restart.Enabled = true;
        }
        public void stoppedHide()
        {
            back.Visible = false;
            back.Enabled = false;
            restart.Visible = false;
            restart.Enabled = false;
        }
        public Keys[] keyFlect;
        public gameInfo gameInfo;
        game game;
        public void gameStart(Keys[] selfKeyFlect, gameInfo choseGame, gameSet gameset)
        {
            stoppedHide();
            timer = new Timer();
            timer.Interval = 200;
            timer.Tick += timer_Tick;
            keyFlect = selfKeyFlect;
            gameInfo = choseGame;
            game = new game(4, gameInfo.musicInfo, gameInfo.trackInfo, gameView.Size, gameView.CreateGraphics(), endPic.Size, endPic.CreateGraphics());
            game.Set(gameset.speed / 10, gameset.offset);
            game.starts();
            timer.Start();
        }
        private void gameForm_KeyDown(object sender, KeyEventArgs e)
        {
            int chose = -1;
            for (int i = 0; i < keyFlect.Length; i++)
            {
                if (keyFlect[i] == e.KeyCode)
                {
                    chose = i;
                    break;
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                game.pauseControl();
                if (!game.run)
                {
                    stoppedShow();
                }
                else
                {
                    stoppedHide();
                }
            }
            if (game != null) { 
                game.lisenKey(chose, true);
            }
        }

        private void gameForm_KeyUp(object sender, KeyEventArgs e)
        {
            int chose = -1;
            for (int i = 0; i < keyFlect.Length; i++)
            {
                if (keyFlect[i] == e.KeyCode)
                {
                    chose = i;
                    break;
                }
            }
            if (game != null)
                game.lisenKey(chose, false);
        }

        private void restart_Click(object sender, EventArgs e)
        {
            stoppedHide();
            Focus();
            game.reStart();
        }
        private void gameForm_Enter(object sender, EventArgs e)
        {
        }

        private void back_Click(object sender, EventArgs e)
        {
            game.exit();
            timer.Stop();
            game = null;
            this.Enabled = false;
            mainView.Instance.Enabled = true;
            Form1.Instance.view.Controls["mainView"].BringToFront();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (game.end)
            {
                stoppedShow();
                timer.Stop();
            }
        }
    }
}
