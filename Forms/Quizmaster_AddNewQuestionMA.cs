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
    public partial class Quizmaster_AddNewQuestionMA : Form
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
    }
}
