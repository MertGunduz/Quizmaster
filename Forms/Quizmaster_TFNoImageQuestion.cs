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
    public partial class Quizmaster_TFNoImageQuestion : Form
    {
        // BULK STRING TAKER
        string questionTEXT = string.Empty;

        // SYSTEM STRINGS
        string validLine = string.Empty;
        int validLineLine = 0;
        string question = string.Empty;
        string questionAnswer = string.Empty;
        string questionGenre = string.Empty;

        // INPUT
        string userQuestionAnswer;

        Random random = new Random();

        public Quizmaster_TFNoImageQuestion()
        {
            InitializeComponent();
        }

        private void Quizmaster_Load(object sender, EventArgs e)
        {
            Classes.Configuration.questionCount++;

            for (int i = 0; i < File.ReadAllLines(Classes.Configuration.drivePath + "Quizmaster\\Questions & Genres\\TFQuestions.txt").Length; i++)
            {
                questionTEXT = File.ReadAllLines(Classes.Configuration.drivePath + "Quizmaster\\Questions & Genres\\TFQuestions.txt")[random.Next(0, File.ReadAllLines(Classes.Configuration.drivePath + "Quizmaster\\Questions & Genres\\TFQuestions.txt").Length - 1)].ToString();

                if (questionTEXT.Contains("TF") && questionTEXT.Contains("IMG_NOT_INCLUDED"))
                {
                    validLine = questionTEXT;
                    validLineLine = i;
                    break;
                }
            }

            int s = 0;
            while (validLine[s].ToString() != ":")
            {
                question += validLine[s];
                s++;
            }

            s++;

            while (validLine[s].ToString() != ":")
            {
                questionAnswer += validLine[s];
                s++;
            }

            s++;

            while (validLine[s].ToString() != ":")
            {
                questionGenre += validLine[s];
                s++;
            }

            Question_RichTextBox.Text = question;
        }

        private void SubmitAnswer_ButtonINS_Click(object sender, EventArgs e)
        {
            Classes.Configuration.questionCount++;

            if (userQuestionAnswer == questionAnswer)
            {
                Classes.Configuration.trueAnswers++;
            }
            else
            {
                Classes.Configuration.falseAnswers++;
            }

            if (Classes.Configuration.questionCount == 10)
            {
                MessageBox.Show($"Finished!\n\nTrue Answers: {Classes.Configuration.trueAnswers}\n\nFalse Answers:{Classes.Configuration.falseAnswers}", $"Congratulations {Classes.Configuration.trueAnswers}TRUE/{Classes.Configuration.falseAnswers}FALSE", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Quizmaster_MainMenu quizmaster_MainMenu = new Quizmaster_MainMenu();
                this.Dispose();
                quizmaster_MainMenu.Show();
            }
            else
            {
                // Opens New Menu
                Quizmaster_TFImageQuestion quizmaster_TFImageQuestion = new Quizmaster_TFImageQuestion();
                this.Dispose();
                quizmaster_TFImageQuestion.Show();
            }
        }

        private void Minimize_PictureBoxINS_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Exit_PictureBoxINS_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AnswerRichTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (AnswerRichTextBox.Text == "  Answer:")
            {
                AnswerRichTextBox.Clear();
            }
        }
    }
}