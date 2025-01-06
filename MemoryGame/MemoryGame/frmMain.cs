using MemoryGame.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    public partial class frmMain : Form
    {
        private const int Rows = 6;
        private const int Columns = 5;
        private Button[,] buttons;
        private List<Image> images;
        private Button firstButton = null, secondButton = null;
        private Timer gameTimer;
        private int elapsedSeconds;
        private int matchedPairs;
        private readonly User currentUser;

        public frmMain(User user)
        {
            InitializeComponent();
            currentUser = user;
            InitializeGame();
        }

        private void InitializeGame()
        {
            matchedPairs = 0;
            elapsedSeconds = 0;

            images = GenerateRandomImages();

            tableLayoutPanel.Controls.Clear();
            buttons = new Button[Rows, Columns];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    var button = new Button
                    {
                        Dock = DockStyle.Fill,
                        Tag = images[i * Columns + j],
                        BackColor = Color.White
                    };
                    button.Click += OnButtonClick;
                    buttons[i, j] = button;
                    tableLayoutPanel.Controls.Add(button, j, i);
                }
            }

            if (gameTimer == null)
            {
                gameTimer = new Timer { Interval = 1000 };
                gameTimer.Tick += OnGameTimerTick;
            }
            gameTimer.Start();
        }

        private List<Image> GenerateRandomImages()
        {
            var imageList = new List<Image>();
            for (int i = 0; i < 15; i++)
            {
                imageList.Add(Properties.Resources.ResourceManager.GetObject($"Animal{i}") as Image);
            }
            imageList.AddRange(imageList);
            return imageList.OrderBy(_ => Guid.NewGuid()).ToList();
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button == null || button == firstButton || button == secondButton)
                return;

            button.BackgroundImage = (Image)button.Tag;
            button.BackgroundImageLayout = ImageLayout.Stretch;

            if (firstButton == null)
            {
                firstButton = button;
            }
            else
            {
                secondButton = button;
                CheckMatch();
            }
        }

        private void CheckMatch()
        {
            Button tempFirstButton = firstButton;
            Button tempSecondButton = secondButton;

            if (firstButton.Tag == secondButton.Tag)
            {
                firstButton.Enabled = false;
                secondButton.Enabled = false;
                matchedPairs++;
                if (matchedPairs == 15)
                {
                    GameOver();
                }
            }
            else
            {
                Timer delayTimer = new Timer { Interval = 1000 };
                delayTimer.Tick += (s, e) =>
                {
                    tempFirstButton.BackgroundImage = null;
                    tempSecondButton.BackgroundImage = null;

                    tempFirstButton = null;
                    tempSecondButton = null;

                    delayTimer.Stop();
                };
                delayTimer.Start();
            }

            firstButton = null;
            secondButton = null;
        }


        private void OnGameTimerTick(object sender, EventArgs e)
        {
            elapsedSeconds++;
            lblTimer.Text = $"Thời gian: {elapsedSeconds / 60:D2}:{elapsedSeconds % 60:D2}";
        }

        private void GameOver()
        {
            gameTimer.Stop();
            using (var context = new MemoryGameDBContext())
            {
                context.GameResults.Add(new GameResult
                {
                    UserID = currentUser.UserID,
                    PlayTime = elapsedSeconds
                });
                context.SaveChanges();
            }

            MessageBox.Show("Chúc mừng! Bạn đã hoàn thành trò chơi.", "Hoàn thành");
            LoadTop5Players();
        }

        private void btnReplay_Click(object sender, EventArgs e)
        {
            InitializeGame();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLoginRegister loginForm = new frmLoginRegister();
            loginForm.ShowDialog();
            this.Close();
        }


        private void LoadTop5Players()
        {
            using (var context = new MemoryGameDBContext())
            {
                var top5 = context.GameResults
                    .OrderBy(r => r.PlayTime)
                    .Take(5)
                    .ToList();

                var formattedTop5 = top5.Select(r => new
                {
                    Email = r.User.Email,
                    PlayTime = $"{r.PlayTime / 60:D2}:{r.PlayTime % 60:D2}"
                }).ToList();
                dataGridViewTop5.DataSource = formattedTop5;
            }
        }
    }
}
