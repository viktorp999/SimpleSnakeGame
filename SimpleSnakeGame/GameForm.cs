using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleSnakeGame
{
    public partial class SnakeForm : Form
    {
        private List<Circle> Snake = new List<Circle>();
        private Circle food = new Circle();
        int maxWidth;
        int maxHeight;
        int score = 0;
        Random rand = new Random();
        bool goRight, goLeft, goUp, goDown;
        public SnakeForm()
        {
            InitializeComponent();
            new Settings();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && Settings.direction != "right")
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right && Settings.direction != "left")
            {
                goRight = true;
            }
            if (e.KeyCode == Keys.Up && Settings.direction != "down")
            {
                goUp = true;
            }
            if (e.KeyCode == Keys.Down && Settings.direction != "up")
            {
                goDown = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
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

        private void StartGame(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void Timer(object sender, EventArgs e)
        {
            if (goRight)
            {
                Settings.direction = "right";
            }
            if (goLeft)
            {
                Settings.direction = "left";
            }
            if (goUp)
            {
                Settings.direction = "up";
            }
            if (goDown)
            {
                Settings.direction = "down";
            }
            for (int i = Snake.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (Settings.direction)
                    {
                        case "left":
                            Snake[i].X--;
                            break;
                        case "right":
                            Snake[i].X++;
                            break;
                        case "up":
                            Snake[i].Y--;
                            break;
                        case "down":
                            Snake[i].Y++;
                            break;
                    }
                    if (Snake[i].X < 0)
                    {
                        Snake[i].X = maxWidth;
                    }
                    if (Snake[i].X > maxWidth)
                    {
                        Snake[i].X = 0;
                    }
                    if (Snake[i].Y < 0)
                    {
                        Snake[i].Y = maxHeight;
                    }
                    if (Snake[i].Y > maxHeight)
                    {
                        Snake[i].Y = 0;
                    }
                    if (Snake[i].X == food.X && Snake[i].Y == food.Y)
                    {
                        EatFood();
                    }
                    for (int j = 1; j < Snake.Count; j++)
                    {
                        if(Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
                        {
                            GameOver();
                        }
                    }
                }
                else
                {
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }
            }
            SnakeGraphicsPicBox.Invalidate();
        }

        private void UpdateSnakeGraphics(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            Brush snakeColour;
            for(int i = 0; i < Snake.Count; i++ )
            {
                if (i == 0)
                {
                    snakeColour = Brushes.White;
                }
                else
                {
                    snakeColour = Brushes.Gray;
                }
                canvas.FillEllipse(snakeColour, new Rectangle(Snake[i].X * Settings.Width, Snake[i].Y * Settings.Height, Settings.Width, Settings.Height));
            }
            canvas.FillEllipse(Brushes.Green, new Rectangle(food.X * Settings.Width, food.Y * Settings.Height, Settings.Width, Settings.Height));
        }

        private void LoadGame(object sender, EventArgs e)
        {
            ScoreL.Text = "Score: " + score;
        }

        private void RestartGame()
        {
            maxWidth = SnakeGraphicsPicBox.Width / Settings.Width - 1;
            maxHeight = SnakeGraphicsPicBox.Height / Settings.Height - 1;
            Snake.Clear();
            StartB.Enabled = false;
            score = 0;
            ScoreL.Text = "Score: " + score;
            Circle head = new Circle { X = 20, Y = 20 };
            Snake.Add(head);
            for (int i = 0; i < 10; i++)
            {
                Circle body = new Circle();
                Snake.Add(body);
            }
            food = new Circle {X = rand.Next(2, maxWidth), Y= rand.Next(2, maxHeight) };
            GameTimer.Start();
        }

        private void EatFood()
        {
            score += 1;
            ScoreL.Text = "Score " + score;
            Circle body = new Circle {X = Snake[Snake.Count - 1].X, Y = Snake[Snake.Count - 1].Y};
            Snake.Add(body);
            food = new Circle { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };
        }

        private void GameOver()
        {
            GameTimer.Stop();
            StartB.Enabled = true;
            MessageBox.Show("Game Over!");
        }
    }
}
