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
    public partial class Quizmaster_AddNewQuestionMenu : Form
    {
        public Quizmaster_AddNewQuestionMenu()
        {
            InitializeComponent();
        }

        private void FillInTheBlank_ButtonINS_Click(object sender, EventArgs e)
        {
            // OPENS MULTIPLE ANSWER QUESTION MENU (Quizmaster_AddNewQuestionTFMenu.cs)
            Quizmaster_AddNewQuestionTFMenu quizmaster_AddNewQuestionTFMenu = new Quizmaster_AddNewQuestionTFMenu();
            this.Dispose();
            quizmaster_AddNewQuestionTFMenu.Show();
        }

        private void MultipleAnswer_ButtonINS_Click(object sender, EventArgs e)
        {
            // OPENS MULTIPLE ANSWER QUESTION MENU (Quizmaster_AddNewQuestionMAMenu.cs)
            Quizmaster_AddNewQuestionMA quizmaster_AddNewQuestionMA = new Quizmaster_AddNewQuestionMA();
            this.Dispose();
            quizmaster_AddNewQuestionMA.Show();
        }
    }
}
