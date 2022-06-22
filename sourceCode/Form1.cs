using System;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        static Form1 mainForm;
        public static Form1 Instance
        {
            get
            {
                if(mainForm == null)
                {
                    mainForm = new Form1();
                }
                return mainForm;
            }
        }
        public Panel view
        {
            get { return viewControl; }
            set { viewControl = value; }
        }
        public Form1()
        {
            InitializeComponent();
            KeyPreview = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mainForm = this;
            mainView mw = new mainView();
            mw.Dock = DockStyle.Fill;
            gameForm gf = new gameForm();
            gf.Dock = DockStyle.Fill;
            viewControl.Controls.Add(mw);
            viewControl.Controls.Add(gf);
            gf.Enabled = false;
            viewControl.Controls["mainView"].BringToFront();
        }

        
 
      
    }
}
