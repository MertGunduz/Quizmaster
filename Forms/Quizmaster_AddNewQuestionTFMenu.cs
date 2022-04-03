using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace Quizmaster.Forms
{
    public partial class Quizmaster_AddNewQuestionTFMenu : Form
    {
        // VARIABLES
        List<string> genresList = new List<string>();
        string question = string.Empty;
        string questionAnswer = string.Empty;
        string questionCategory = string.Empty;
        string imageName = string.Empty;

        char[] Numbers_Array = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        char[] LowerCase_Array = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        char[] UpperCase_Array = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };


        Random random = new Random();

        public Quizmaster_AddNewQuestionTFMenu()
        {
            InitializeComponent();
        }

        private void Quizmaster_AddNewQuestionTFMenu_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < File.ReadAllLines($"{Classes.Configuration.drivePath}Quizmaster\\Questions & Genres\\Genres.txt").Length; i++)
            {
                // ADDS THE GENRES
                genresList.Add(File.ReadAllLines($"{Classes.Configuration.drivePath}Quizmaster\\Questions & Genres\\Genres.txt")[i]);
                Genre_ListBox.Items.Add(genresList[i]);
            }
        }

        private void AddImageToQuestion_ButtonINS_Click(object sender, EventArgs e)
        {
            // SETS QUESTION
            question = Question_RichTextBox.Text;
            questionAnswer = QuestionAnswer_RichTextBox.Text;
            questionCategory = Genre_ListBox.Items[Genre_ListBox.SelectedIndex].ToString();

            if (ImageURL_RichTextBox.Text != " " && ImageURL_RichTextBox.Text != "" && ImageURL_RichTextBox.Text != "  Image URL: ")
            {
                imageName = LowerCase_Array[random.Next(0, LowerCase_Array.Length - 1)].ToString() + LowerCase_Array[random.Next(0, LowerCase_Array.Length - 1)].ToString() + LowerCase_Array[random.Next(0, LowerCase_Array.Length - 1)].ToString() + LowerCase_Array[random.Next(0, LowerCase_Array.Length - 1)].ToString() + UpperCase_Array[random.Next(0, UpperCase_Array.Length - 1)].ToString() + UpperCase_Array[random.Next(0, UpperCase_Array.Length - 1)].ToString() + UpperCase_Array[random.Next(0, UpperCase_Array.Length - 1)].ToString() + UpperCase_Array[random.Next(0, UpperCase_Array.Length - 1)].ToString() + UpperCase_Array[random.Next(0, UpperCase_Array.Length - 1)].ToString() + Numbers_Array[random.Next(0, Numbers_Array.Length - 1)].ToString() + ".png";

                var client = new WebClient();
                client.DownloadFile(ImageURL_RichTextBox.Text, Classes.Configuration.drivePath + "Quizmaster\\Images\\" + imageName);
            }

            if ((question != "" && question != " ") && (questionAnswer != "" && questionAnswer != " "))
            {
                if (ImageURL_RichTextBox.Text == "" || ImageURL_RichTextBox.Text == " " || ImageURL_RichTextBox.Text == "  Image URL: ")
                {
                    File.AppendAllText($"{Classes.Configuration.drivePath}Quizmaster\\Questions & Genres\\TFQuestions.txt", question + ":" + questionAnswer + ":" + questionCategory + ":" + "TF" + ":" + "IMG_NOT_INCLUDED" + Environment.NewLine);
                }
                else
                {
                    File.AppendAllText($"{Classes.Configuration.drivePath}Quizmaster\\Questions & Genres\\TFQuestions.txt", question + ":" + questionAnswer + ":" + questionCategory + ":" + "TF" + ":"+ "IMG_INCLUDED" + ":" + imageName + Environment.NewLine);
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

        // PLACEHOLDER CLEANING
        private void ImageURL_RichTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (ImageURL_RichTextBox.Text == "  Image URL: ")
            {
                ImageURL_RichTextBox.Clear();
            }
        }

        private void Question_RichTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (Question_RichTextBox.Text == "  Question:")
            {
                Question_RichTextBox.Clear();
            }
        }

        private void QuestionAnswer_RichTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (QuestionAnswer_RichTextBox.Text == "  Question Answer:")
            {
                QuestionAnswer_RichTextBox.Clear();
            }
        }
    }
}
