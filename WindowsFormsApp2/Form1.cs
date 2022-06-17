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
            if (chose == -1) return;
            newgame.trackJudge(newgame.GameTime(), chose, Info.pressed);
            Graphics g = pictureBox1.CreateGraphics();
            newgame.paint(g);
            newgame.paintHit(chose, g);
        }

        private void button1_click(object sender, EventArgs e)
        {
            newgame = new game(4, Properties.Resources.testMusic, "data.dat", 0, pictureBox1.ClientSize, pictureBox1.CreateGraphics());
            newgame.starts();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            newgame.exitGame();
        }
    }
}
