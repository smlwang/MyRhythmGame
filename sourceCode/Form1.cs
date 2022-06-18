using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        game newgame;
        
        public Form1()
        {
            InitializeComponent();
            KeyPreview = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int chose = -1;
            if(e.KeyCode == Keys.D)
            {
                chose = 0;
            }else if(e.KeyCode == Keys.F)
            {
                chose = 1;
            }else if (e.KeyCode == Keys.J)
            {
                chose = 2;
            }else if(e.KeyCode== Keys.K)
            {
                chose = 3;
            }
            if(newgame != null)
                newgame.lisenKey(chose, true);
        }

        private void button1_click(object sender, EventArgs e)
        {
            newgame = new game(4, Properties.Resources.testMusic, "data.dat", 0, pictureBox1.ClientSize, pictureBox1.CreateGraphics());
            KeyPreview = true;
            newgame.starts();
            timer1.Enabled = true;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            newgame.exitGame();
            KeyPreview = false;
            timer1.Enabled = false;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            int chose = -1;
            if(e.KeyCode == Keys.D)
            {
                chose = 0;
            }else if(e.KeyCode == Keys.F)
            {
                chose = 1;
            }else if (e.KeyCode == Keys.J)
            {
                chose = 2;
            }else if(e.KeyCode== Keys.K)
            {
                chose = 3;
            }
            if(newgame != null)
                newgame.lisenKey(chose, false);

        }

        private void label1_BindingContextChanged(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = "combo : " + newgame.combo + "\nscore : " + newgame.Score;
        }
    }
}
