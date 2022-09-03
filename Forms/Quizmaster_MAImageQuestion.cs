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
    public partial class Quizmaster_MAImageQuestion : Form
    {
        // BULK STRING TAKER
        string questionTEXT = string.Empty;

        // SYSTEM STRINGS
        string validLine = string.Empty;
        string question = string.Empty;
        string questionAnswer = string.Empty;
        string aAnswer = string.Empty;
        string bAnswer = string.Empty;
        string cAnswer = string.Empty;
        string dAnswer = string.Empty;
        string questionGenre = string.Empty;
        string questionType = string.Empty;
        string questionImageType = string.Empty;
        string imagePath = string.Empty;

        // INPUT
        string userQuestionAnswer;
        Random random = new Random();

        public Quizmaster_MAImageQuestion()
        {
            InitializeComponent();
        }

        private void Quizmaster_MAImageQuestion_Load(object sender, EventArgs e)
        {
            Classes.Configuration.questionCount++;

            while (true)
            {
                questionTEXT = File.ReadAllLines(Classes.Configuration.drivePath + "Quizmaster\\Questions & Genres\\MAQuestions.txt")[random.Next(0, File.ReadAllLines(Classes.Configuration.drivePath + "Quizmaster\\Questions & Genres\\MAQuestions.txt").Length)].ToString();

                if (questionTEXT.Contains("MA") && questionTEXT.Contains("IMG_INCLUDED"))
                {
                    validLine = questionTEXT;
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
                aAnswer += validLine[s];
                s++;
            }

            s++;

            while (validLine[s].ToString() != ":")
            {
                bAnswer += validLine[s];
                s++;
            }

            s++;

            while (validLine[s].ToString() != ":")
            {
                cAnswer += validLine[s];
                s++;
            }

            s++;

            while (validLine[s].ToString() != ":")
            {
                dAnswer += validLine[s];
                s++;
            }

            s++;

            while (validLine[s].ToString() != ":")
            {
                questionGenre += validLine[s];
                s++;
            }

            s++;

            while (validLine[s].ToString() != ":")
            {
                questionType += validLine[s];
                s++;
            }

            s++;

            while (validLine[s].ToString() != ":")
            {
                questionImageType += validLine[s];
                s++;
            }

            s++;

            while (validLine[s].ToString() != "" && s < validLine.Length - 1)
            {
                imagePath += validLine[s];
                s++;
            }

            imagePath += "g";

            Bitmap bitmap = new Bitmap(Classes.Configuration.drivePath + "Quizmaster\\Images\\" + imagePath);

            Question_RichTextBox.Text = question;
            QuestionImage_PictureBox.Image = bitmap;

            A_ButtonINS.Text = aAnswer;
            B_ButtonINS.Text = bAnswer;
            C_ButtonINS.Text = cAnswer;
            D_ButtonINS.Text = dAnswer;
        }
    }
}
