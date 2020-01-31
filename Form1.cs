using System;
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
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }

            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = "Score: " + score;

            if (goLeft)
            {
                pacman.Left -= speed; // this moves the player to the left
            }

            if (goRight)
            {
                pacman.Left += speed; // this moves the player to the right
            }

            if (goUp)
            {
                pacman.Top -= speed; // this moves the player up
            }

            if (goDown)
            {
                pacman.Top += speed; // this moves the player down
            }

            redGhost.Left += ghost1;
            yellowGhost.Left += ghost2;

            if (redGhost.Bounds.IntersectsWith(pictureBox4.Bounds))
            {
                ghost1 = -ghost1; // if the red ghost hits the wall then we reverse the speed
            }
            else if (redGhost.Bounds.IntersectsWith(pictureBox3.Bounds))
            {
                ghost1 = -ghost1; // if the red ghost hits the wall then we reverse the speed
            }

            if (yellowGhost.Bounds.IntersectsWith(pictureBox1.Bounds))
            {
                ghost2 = -ghost2; // if the yellow ghost hits the wall then we reverse the speed
            }
            else if (yellowGhost.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
                ghost2 = -ghost2; // if the yellow ghost hits the wall then we reverse the speed
            }

            foreach (Control x in this.Controls)
            {
                if ( x is PictureBox && x.Tag == "wall" || x.Tag == "ghost")
                {
                    if (((PictureBox)x).Bounds.IntersectsWith(pacman.Bounds) || score == 30)
                    {
                        pacman.Left = 0;
                        pacman.Top = 25;
                        label2.Text = "Game Over";
                        label2.Visible = true;
                        timer1.Stop();
                    }
                }

                if (x is PictureBox && x.Tag == "coin")
                {
                    if (((PictureBox)x).Bounds.IntersectsWith(pacman.Bounds))
                    {
                        this.Controls.Remove(x); // we want to remove the coin
                        score++; // we also want to increment the score
                    }
                }
            }

            pinkGhost.Left += ghost3x;
            pinkGhost.Top += ghost3y;

            if (pinkGhost.Left < 1 ||
                pinkGhost.Left + pinkGhost.Width > ClientSize.Width - 2 ||
                (pinkGhost.Bounds.IntersectsWith(pictureBox4.Bounds)) ||
                (pinkGhost.Bounds.IntersectsWith(pictureBox3.Bounds)) ||
                (pinkGhost.Bounds.IntersectsWith(pictureBox2.Bounds)) ||
                (pinkGhost.Bounds.IntersectsWith(pictureBox1.Bounds)))
            {
                ghost3x = -ghost3x;
            }

            if (pinkGhost.Top < 1 || pinkGhost.Top + pinkGhost.Height > ClientSize.Height - 2)
            {
                ghost3y = -ghost3y;
            }

        }
    }
}
