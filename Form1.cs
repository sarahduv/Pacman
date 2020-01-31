﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    public partial class Form1 : Form
    {
        bool goUp;
        bool goDown;
        bool goLeft;
        bool goRight;

        int speed = 5;

        int ghost1 = 8;
        int ghost2 = 8;

        int ghost3x = 8;
        int ghost3y = 8;

        int score = 0;

        public Form1()
        {
            InitializeComponent();
            label2.Visible = false;
        }

        private void keyIsDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                goLeft = true;
                pacman.Image = Properties.Resources.Left;
            }

            if(e.KeyCode == Keys.Right)
            {
                goRight = true;
                pacman.Image = Properties.Resources.Right;
            }

            if(e.KeyCode == Keys.Up)
            {
                goUp = true;
                pacman.Image = Properties.Resources.Up;
            }

            if(e.KeyCode == Keys.Down)
            {
                goDown = true;
                pacman.Image = Properties.Resources.down;
            }

        }

        private void keyIsUp(object sender, KeyEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
