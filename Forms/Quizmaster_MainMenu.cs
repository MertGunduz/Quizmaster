using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quizmaster.Forms
{
    public partial class Quizmaster_MainMenu : Form
    {
        public Quizmaster_MainMenu()
        {
            InitializeComponent();
        }


        // WINDOWSTATE BUTTONS (EXIT AND MINIMIZE)
        private void Exit_PictureBoxINS_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Minimize_PictureBoxINS_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
