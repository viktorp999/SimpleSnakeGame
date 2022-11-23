using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleSnakeGame
{
    public partial class SnakeForm : Form
    {
        private List<Circle> _snake = new List<Circle>();
        private Circle _food = new Circle();
        private int _maxWidth;
        private int _maxHeight;
        private int _score = 0;
        private Random _rand = new Random();
        private bool _isgoRight, _isgoLeft, _isgoUp, _isgoDown;

        public SnakeForm()
        {
            InitializeComponent();
            new Settings();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && Settings.direction != "right")
            {
                _isgoLeft = true;
            }

            if (e.KeyCode == Keys.Right && Settings.direction != "left")
            {
                _isgoRight = true;
            }

            if (e.KeyCode == Keys.Up && Settings.direction != "down")
            {
                _isgoUp = true;
            }

            if (e.KeyCode == Keys.Down && Settings.direction != "up")
            {
                _isgoDown = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                _isgoLeft = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                _isgoRight = false;
            }

            if (e.KeyCode == Keys.Up)
            {
                _isgoUp = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                _isgoDown = false;
            }
        }

        private void StartGame(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void Timer(object sender, EventArgs e)
        {
            if (_isgoRight)
            {
                Settings.direction = "right";
            }

            if (_isgoLeft)
            {
                Settings.direction = "left";
            }

            if (_isgoUp)
            {
                Settings.direction = "up";
            }

            if (_isgoDown)
            {
                Settings.direction = "down";
            }

            for (int i = _snake.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (Settings.direction)
                    {
                        case "left":
                            _snake[i].X--;
                            break;

                        case "right":
                            _snake[i].X++;
                            break;

                        case "up":
                            _snake[i].Y--;
                            break;

                        case "down":
                            _snake[i].Y++;
                            break;
                    }

                    if (_snake[i].X < 0)
                    {
                        _snake[i].X = _maxWidth;
                    }

                    if (_snake[i].X > _maxWidth)
                    {
                        _snake[i].X = 0;
                    }

                    if (_snake[i].Y < 0)
                    {
                        _snake[i].Y = _maxHeight;
                    }

                    if (_snake[i].Y > _maxHeight)
                    {
                        _snake[i].Y = 0;
                    }

                    if (_snake[i].X == _food.X && _snake[i].Y == _food.Y)
                    {
                        EatFood();
                    }

                    for (int j = 1; j < _snake.Count; j++)
                    {
                        if(_snake[i].X == _snake[j].X && _snake[i].Y == _snake[j].Y)
                        {
                            GameOver();
                        }
                    }
                }

                else
                {
                    _snake[i].X = _snake[i - 1].X;
                    _snake[i].Y = _snake[i - 1].Y;
                }
            }

            SnakeGraphicsPicBox.Invalidate();
        }

        private void UpdateSnakeGraphics(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            Brush snakeColour;

            for(int i = 0; i < _snake.Count; i++ )
            {
                if (i == 0)
                {
                    snakeColour = Brushes.White;
                }

                else
                {
                    snakeColour = Brushes.Gray;
                }

                canvas.FillEllipse(snakeColour, new Rectangle(_snake[i].X * Settings.Width, _snake[i].Y * Settings.Height, Settings.Width, Settings.Height));
            }

            canvas.FillEllipse(Brushes.Green, new Rectangle(_food.X * Settings.Width, _food.Y * Settings.Height, Settings.Width, Settings.Height));
        }

        private void LoadGame(object sender, EventArgs e)
        {
            ScoreL.Text = "Score: " + _score;
        }

        private void RestartGame()
        {
            _maxWidth = SnakeGraphicsPicBox.Width / Settings.Width - 1;
            _maxHeight = SnakeGraphicsPicBox.Height / Settings.Height - 1;
            _snake.Clear();
            StartB.Enabled = false;
            _score = 0;
            ScoreL.Text = "Score: " + _score;
            Circle head = new Circle 
            { 
                X = 20, 
                Y = 20 
            };

            _snake.Add(head);

            for (int i = 0; i < 10; i++)
            {
                Circle body = new Circle();
                _snake.Add(body);
            }

            _food = new Circle 
            {
                X = _rand.Next(2, _maxWidth), 
                Y= _rand.Next(2, _maxHeight) 
            };

            GameTimer.Start();
        }

        private void EatFood()
        {
            _score += 1;
            ScoreL.Text = "Score " + _score;
            Circle body = new Circle 
            {
                X = _snake[_snake.Count - 1].X,
                Y = _snake[_snake.Count - 1].Y
            };

            _snake.Add(body);
            _food = new Circle { X = _rand.Next(2, _maxWidth), Y = _rand.Next(2, _maxHeight) };
        }

        private void GameOver()
        {
            GameTimer.Stop();
            StartB.Enabled = true;
            MessageBox.Show("Game Over!");
        }
    }
}
