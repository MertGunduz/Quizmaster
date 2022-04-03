using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net;

namespace Quizmaster.Forms
{
    public partial class Quizmaster_AddNewQuestionMA : Form
    {
        // VARIABLES
        List<string> genresList = new List<string>();
        string question = string.Empty;
        string questionAnswerA = string.Empty;
        string questionAnswerB = string.Empty;
        string questionAnswerC = string.Empty;
        string questionAnswerD = string.Empty;
        string trueAnswer = string.Empty;
        string questionCategory = string.Empty;
        string imageName = string.Empty;

        char[] Numbers_Array = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        char[] LowerCase_Array = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        char[] UpperCase_Array = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        Random random = new Random();

        public Quizmaster_AddNewQuestionMA()
        {
            InitializeComponent();
        }

        private void Quizmaster_AddNewQuestionMA_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < File.ReadAllLines($"{Classes.Configuration.drivePath}Quizmaster\\Questions & Genres\\Genres.txt").Length; i++)
            {
                // ADDS THE GENRES
                genresList.Add(File.ReadAllLines($"{Classes.Configuration.drivePath}Quizmaster\\Questions & Genres\\Genres.txt")[i]);
                Genre_ListBox.Items.Add(genresList[i]);
            }
        }

        private void A_ButtonINS_Click(object sender, EventArgs e)
        {
            trueAnswer = "A";
        }

        private void B_ButtonINS_Click(object sender, EventArgs e)
        {
            trueAnswer = "B";
        }

        private void C_ButtonINS_Click(object sender, EventArgs e)
        {
            trueAnswer = "C";
        }

        private void D_ButtonINS_Click(object sender, EventArgs e)
        {
            trueAnswer = "D";
        }

        private void AddImageToQuestion_ButtonINS_Click(object sender, EventArgs e)
        {
            // SETS QUESTION
            question = Question_RichTextBox.Text;
            questionAnswerA = QuestionAnswerA_RichTextBox.Text;
            questionAnswerB = QuestionAnswerB_RichTextBox.Text;
            questionAnswerC = QuestionAnswerC_RichTextBox.Text;
            questionAnswerD = QuestionAnswerD_RichTextBox.Text;
            questionCategory = Genre_ListBox.Items[Genre_ListBox.SelectedIndex].ToString();

            if (ImageURL_RichTextBox.Text != " " && ImageURL_RichTextBox.Text != "")
            {
                imageName = LowerCase_Array[random.Next(0, LowerCase_Array.Length - 1)].ToString() + LowerCase_Array[random.Next(0, LowerCase_Array.Length - 1)].ToString() + LowerCase_Array[random.Next(0, LowerCase_Array.Length - 1)].ToString() + LowerCase_Array[random.Next(0, LowerCase_Array.Length - 1)].ToString() + UpperCase_Array[random.Next(0, UpperCase_Array.Length - 1)].ToString() + UpperCase_Array[random.Next(0, UpperCase_Array.Length - 1)].ToString() + UpperCase_Array[random.Next(0, UpperCase_Array.Length - 1)].ToString() + UpperCase_Array[random.Next(0, UpperCase_Array.Length - 1)].ToString() + UpperCase_Array[random.Next(0, UpperCase_Array.Length - 1)].ToString() + Numbers_Array[random.Next(0, Numbers_Array.Length - 1)].ToString() + ".png";

                var client = new WebClient();
                client.DownloadFile(ImageURL_RichTextBox.Text, Classes.Configuration.drivePath + "Quizmaster\\Images\\" + imageName);
            }

            if ((question != "" && question != " ") && (questionAnswerA != "" && questionAnswerA != " ") && (questionAnswerB != "" && questionAnswerB != " ") && (questionAnswerC != "" && questionAnswerC != " ") && (questionAnswerD != "" && questionAnswerD != " "))
            {
                if (ImageURL_RichTextBox.Text == "" || ImageURL_RichTextBox.Text == " " || ImageURL_RichTextBox.Text == "  Image URL: ")
                {
                    File.AppendAllText($"{Classes.Configuration.drivePath}Quizmaster\\Questions & Genres\\Questions.txt", question + ":" + trueAnswer + ":" + questionAnswerA + ":" + questionAnswerB + ":" + questionAnswerC + ":" + questionAnswerD + ":" +  questionCategory + ":" + "MA" + ":" + "IMG_NOT_INCLUDED" + Environment.NewLine);
                }
                else
                {
                    File.AppendAllText($"{Classes.Configuration.drivePath}Quizmaster\\Questions & Genres\\Questions.txt", question + ":" + trueAnswer + ":" + questionAnswerA + ":" + questionAnswerB + ":" + questionAnswerC + ":" + questionAnswerD + ":" + questionCategory + ":" + "MA" + ":" + "IMG_INCLUDED" + ":" + imageName + Environment.NewLine);
                }

                // OPENS THE MAIN MENU (Quizmaster_MainMenu.cs)
                Quizmaster_MainMenu quizmaster_MainMenu = new Quizmaster_MainMenu();
                this.Dispose();
                quizmaster_MainMenu.Show();
            }
            else
            {
                MessageBox.Show("Please Enter The Inputs!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Question_RichTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (Question_RichTextBox.Text == "  Question:")
            {
                Question_RichTextBox.Clear();
            }
        }

        private void QuestionAnswerA_RichTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (QuestionAnswerA_RichTextBox.Text == "  Question Answer A:")
            {
                QuestionAnswerA_RichTextBox.Clear();
            }
        }

        private void QuestionAnswerB_RichTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (QuestionAnswerB_RichTextBox.Text == "Question Answer B:")
            {
                QuestionAnswerB_RichTextBox.Clear();
            }
        }

        private void QuestionAnswerC_RichTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (QuestionAnswerC_RichTextBox.Text == "  Question Answer C:")
            {
                QuestionAnswerC_RichTextBox.Clear();
            }
        }

        private void QuestionAnswerD_RichTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (QuestionAnswerD_RichTextBox.Text == "  Question Answer D:")
            {
                QuestionAnswerD_RichTextBox.Clear();
            }
        }

        private void ImageURL_RichTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (ImageURL_RichTextBox.Text == "  Image URL: ")
            {
                ImageURL_RichTextBox.Clear();
            }
        }
    }
}
