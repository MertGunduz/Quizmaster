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
    public partial class Quizmaster_AddNewGenreMenu : Form
    {
        public Quizmaster_AddNewGenreMenu()
        {
            InitializeComponent();
        }

        private void AddNewGenre_ButtonINS_Click(object sender, EventArgs e)
        {
            if (GenreName_RichTextBox.Text != "" || GenreName_RichTextBox.Text != " ")
            {
                // ADD GENRE
                File.AppendAllText($"{Classes.Configuration.drivePath}Quizmaster\\Questions & Genres\\Genres.txt", GenreName_RichTextBox.Text.ToString() + Environment.NewLine);

                // CLOSE THE ADD GENRE MENU & OPEN OLD MENU
                Quizmaster_MainMenu quizmaster_MainMenu = new Quizmaster_MainMenu();
                this.Hide();
                quizmaster_MainMenu.Show();
            }
            else
            {
                MessageBox.Show("Please Write Category!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // PLACEHOLDER CLEAN
        private void GenreName_RichTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (GenreName_RichTextBox.Text == "  Category Name:")
            {
                GenreName_RichTextBox.Clear();
            }
        }
    }
}
