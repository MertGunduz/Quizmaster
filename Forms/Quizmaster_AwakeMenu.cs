﻿using System;
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
    public partial class Quizmaster_AwakeMenu : Form
    {
        // VARIABLES
        int timeCount = 0;

        public Quizmaster_AwakeMenu()
        {
            InitializeComponent();
        }

        private void Quizmaster_AwakeMenu_Load(object sender, EventArgs e)
        {
            // STARTS THE TIMER
            AwakeMenu_TimerINS.Start();
        }

        private void AwakeMenu_TimerINS_Tick(object sender, EventArgs e)
        {
            timeCount++;

            if (timeCount == 100)
            {
                // STOPS THE TIMER
                AwakeMenu_TimerINS.Stop();

                // OPENS THE MAIN MENU (Quizmaster_MainMenu.cs)
                Quizmaster_MainMenu quizmaster_MainMenu = new Quizmaster_MainMenu();
                this.Hide();
                quizmaster_MainMenu.Show();
            }
        }
    }
}
