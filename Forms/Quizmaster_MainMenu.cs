using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quizmaster.Forms
{
    public partial class Quizmaster_MainMenu : Form
    {
        // VARIABLES
        List<string> genresList = new List<string>();

        public Quizmaster_MainMenu()
        {
            InitializeComponent();
        }

        private void Quizmaster_MainMenu_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < File.ReadAllLines($"{Classes.Configuration.drivePath}Quizmaster\\Questions & Genres\\Genres.txt").Length; i++)
            {                
                // ADDS THE GENRES
                genresList.Add(File.ReadAllLines($"{Classes.Configuration.drivePath}Quizmaster\\Questions & Genres\\Genres.txt")[i]);
                QuestionGenres_RichTextBox.Text += "  " + genresList[i] + "\n";
            }
        }

        // BUTTONS
        private void AddNewGenre_ButtonINS_Click(object sender, EventArgs e)
        {
            // OPENS ADD GENRE MENU (Quizmaster_AddNewGenreMenu.cs)
            Quizmaster_AddNewGenreMenu quizmaster_AddNewGenreMenu = new Quizmaster_AddNewGenreMenu();
            this.Dispose();
            quizmaster_AddNewGenreMenu.Show();
            
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

        private void AddNewQuestion_ButtonINS_Click(object sender, EventArgs e)
        {
            if (QuestionGenres_RichTextBox.Text != "")
            {
                // OPENS ADD QUESTION MENU (Quizmaster_AddNewQuestionMenu.cs)
                Quizmaster_AddNewQuestionMenu quizmaster_AddNewQuestionMenu = new Quizmaster_AddNewQuestionMenu();
                this.Dispose();
                quizmaster_AddNewQuestionMenu.Show();
            }
            else
            {
                MessageBox.Show("Please add categories to the system!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StartQuiz_ButtonINS_Click(object sender, EventArgs e)
        {
            if (QuestionGenres_RichTextBox.Text != "")
            {
                string TFQuestionsFile = File.ReadAllText($"{Classes.Configuration.drivePath}Quizmaster\\Questions & Genres\\TFQuestions.txt");
                string MAQuestionsFile = File.ReadAllText($"{Classes.Configuration.drivePath}Quizmaster\\Questions & Genres\\MAQuestions.txt");

                if (TFQuestionsFile != "" && TFQuestionsFile != " ")
                {
                    if (TFQuestionsFile.Contains("IMG_INCLUDED"))
                    {
                        // SHOW THE FIRST TF QUESTION WITH IMAGE INCLUDED
                        Quizmaster_TFImageQuestion quizmaster_TFImageQuestion = new Quizmaster_TFImageQuestion();
                        this.Dispose();
                        quizmaster_TFImageQuestion.Show();
                    }
                    else if (TFQuestionsFile.Contains("IMG_NOT_INCLUDED"))
                    {
                        // SHOW THE FIRST TF QUESTION WITH IMAGE NOT INCLUDED
                        Quizmaster_TFNoImageQuestion quizmaster_TFNoImageQuestion = new Quizmaster_TFNoImageQuestion();
                        this.Dispose();
                        quizmaster_TFNoImageQuestion.Show();
                    }
                }
                else if (MAQuestionsFile != "" && MAQuestionsFile != " ")
                {
                    if (MAQuestionsFile.Contains("IMG_INCLUDED"))
                    {
                        // SHOW THE FIRST MA QUESTION WITH IMAGE INCLUDED
                    }
                    else if (MAQuestionsFile.Contains("IMG_NOT_INCLUDED"))
                    {
                        // SHOW THE FIRST MA QUESTION WITH IMAGE NOT INCLUDED
                    }
                }
                else
                {
                    MessageBox.Show("Please add questions to the system!\n\nThere are no questions in the system!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please add categories and questions to the system!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}