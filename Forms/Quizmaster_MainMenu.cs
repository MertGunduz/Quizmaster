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
                QuestionGenres_RichTextBox.Text += genresList[i] + "\n";
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
    }
}