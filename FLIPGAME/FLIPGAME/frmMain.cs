using FLIPGAME.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;
using FLIPGAME.Form_Components;

namespace FLIPGAME
{
    public partial class frmMain : Form
    {
        private User currentUser;
        private List<Image> imageList;
        private List<Button> buttons;
        private Button firstFlip;
        private Button secondFlip;
        private int matchedPairs;
        private Timer gameTimer;
        private int timeElapsed;
        private Image cardBackImage;
        private int movement;
        private int found;

        public frmMain(User user)
        {
            InitializeComponent();
            currentUser = user;
            InitializeListViewColumns();
            LoadTopScores();
        }

        private void InitializeListViewColumns()
        {
            lstLeaderBoard.Columns.Clear();
            lstLeaderBoard.Columns.Add("User ID", 100);
            lstLeaderBoard.Columns.Add("Time Taken", 100);
            lstLeaderBoard.Columns.Add("Game Date", 200);
            lstLeaderBoard.Columns.Add("Score", 100);

            lstLeaderBoard.View = View.Details;
        }

        private Image[] LoadImagesFromPath(string resourcesPath)
        {
            Image[] images = new Image[6];
            for (int i = 1; i <= 6; i++)
            {
                string imagePath = Path.Combine(resourcesPath, $"image{i}.jpg");
                if (File.Exists(imagePath))
                {
                    images[i - 1] = Image.FromFile(imagePath);
                }
                else
                {
                    MessageBox.Show($"File image{i}.jpg không tồn tại!");
                    return null;
                }
            }
            return images;
        }

        private void InitializeGame()
        {
            // Đường dẫn đến thư mục chứa hình ảnh
            string resourcesPath = @"D:\SourceCode\VisualStudio\CSharp\Programming-on-Windows-Environment-Lab\FLIPGAME\Resources";

            // Kiểm tra và tải hình ảnh mặt sau
            string cardBackPath = Path.Combine(resourcesPath, "card_back.jpg");
            if (File.Exists(cardBackPath))
            {
                cardBackImage = Image.FromFile(cardBackPath);
            }
            else
            {
                MessageBox.Show("File card_back.jpg không tồn tại! Sử dụng ảnh mặc định.");
            }

            // Tạo danh sách hình ảnh
            Image[] images = LoadImagesFromPath(resourcesPath);
            if (images == null) return;

            // Tạo danh sách hình ảnh với các cặp
            imageList = new List<Image>();
            for (int i = 0; i < images.Length; i++)
            {
                imageList.Add(images[i]);
                imageList.Add(images[i]); // Thêm cặp hình ảnh
            }

            // Trộn ngẫu nhiên danh sách hình ảnh
            imageList = imageList.OrderBy(x => Guid.NewGuid()).ToList();

            // Khởi tạo danh sách Button
            buttons = new List<Button>
            {
                button1, button2, button3, button4,
                button5, button6, button7, button8,
                button9, button10, button11, button12
            };

            // Gán hình ảnh và sự kiện cho Button
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Tag = imageList[i]; // Gán hình ảnh mặt trước vào Tag
                buttons[i].BackgroundImage = cardBackImage; // Hiển thị hình ảnh mặt sau
                buttons[i].BackgroundImageLayout = ImageLayout.Stretch; // Đảm bảo hình ảnh vừa với Button
                buttons[i].Enabled = true; // Kích hoạt lại Button
                buttons[i].Click += Button_Click; // Gán sự kiện Click
            }

            // Khởi tạo Timer
            gameTimer = new Timer();
            gameTimer.Interval = 1000; // 1 giây
            gameTimer.Tick += GameTimer_Tick;

            // Reset biến đếm
            matchedPairs = 0;
            timeElapsed = 0;
            movement = 0;
            found = 0;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            // Kiểm tra nếu Button được nhấp và hình ảnh hiện tại là mặt sau
            if (clickedButton != null && clickedButton.BackgroundImage == cardBackImage && firstFlip != clickedButton)
            {
                // Lật thẻ bằng cách hiển thị hình ảnh mặt trước
                clickedButton.BackgroundImage = clickedButton.Tag as Image;
                movement++;

                // Nếu chưa có thẻ nào được lật, lưu thẻ này làm thẻ đầu tiên
                if (firstFlip == null)
                {
                    firstFlip = clickedButton;
                }
                else
                {
                    // Nếu đã có một thẻ được lật, lưu thẻ này làm thẻ thứ hai và kiểm tra khớp
                    secondFlip = clickedButton;
                    CheckForMatch();
                }
            }
        }

        private void LoadTopScores()
        {
            using (var context = new FlipGameDBContext())
            {
                var topScores = context.Scores
                    .Include(s => s.User) // Sử dụng Include để tải dữ liệu liên quan
                    .OrderBy(s => s.TimeTaken)
                    .Take(5)
                    .Select(s => new
                    {
                        UserID = s.UserID,
                        TimeTaken = s.TimeTaken,
                        GameDate = s.GameDate,
                        Username = s.User.Username
                    })
                    .ToList();

                lstLeaderBoard.Items.Clear();
                foreach (var score in topScores)
                {
                    var item = new ListViewItem(new[] {
                score.UserID.ToString(),
                score.TimeTaken.ToString(),
                score.GameDate.ToString(),
                score.Username
            });
                    lstLeaderBoard.Items.Add(item);
                }
            }
        }

        private void CheckForMatch()
        {
            if (firstFlip != null && secondFlip != null && firstFlip.Tag == secondFlip.Tag)
            {
                firstFlip.Enabled = false;
                secondFlip.Enabled = false;
                found++;

                if (found == imageList.Count / 2)
                {
                    gameTimer.Stop();
                    SaveScore();
                    MessageBox.Show($"Hoàn thành trong {timeElapsed} giây với {movement} lần lật!", "Chúc mừng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTopScores();
                }
            }
            else
            {
                DisableAllButtons();

                Timer delayTimer = new Timer();
                delayTimer.Interval = 1000; // 1 giây
                delayTimer.Tick += (s, e) =>
                {
                    if (firstFlip != null) firstFlip.BackgroundImage = cardBackImage;
                    if (secondFlip != null) secondFlip.BackgroundImage = cardBackImage;
                    EnableAllButtons();
                    firstFlip = null;
                    secondFlip = null;
                    delayTimer.Stop();
                };
                delayTimer.Start();
            }
        }

        private void DisableAllButtons()
        {
            foreach (var button in buttons)
            {
                button.Enabled = false;
            }
        }

        private void EnableAllButtons()
        {
            foreach (var button in buttons.Where(b => b.BackgroundImage == cardBackImage))
            {
                button.Enabled = true;
            }
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            timeElapsed++;
            lblTime.Text = "Thời gian: " + timeElapsed + " giây";
        }

        private void SaveScore()
        {
            using (var context = new FlipGameDBContext())
            {
                var score = new Score
                {
                    UserID = currentUser.UserID,
                    TimeTaken = timeElapsed,
                    Movement = movement, // Lưu số lần lật
                    GameDate = DateTime.Now
                };

                context.Scores.Add(score);
                context.SaveChanges();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            matchedPairs = 0;
            timeElapsed = 0;
            movement = 0;
            found = 0;
            firstFlip = null;
            secondFlip = null;
            InitializeGame();
            gameTimer.Start();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin loginForm = new frmLogin();
            loginForm.ShowDialog();
            this.Close();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            foreach (var button in buttons)
            {
                button.BackgroundImage = button.Tag as Image;
            }

            // Sau 2 giây, lật lại tất cả các thẻ
            Timer delayTimer = new Timer();
            delayTimer.Interval = 2000; // 2 giây
            delayTimer.Tick += (s, ev) =>
            {
                foreach (var button in buttons)
                {
                    button.BackgroundImage = cardBackImage;
                }
                delayTimer.Stop();
            };
            delayTimer.Start();
        }
    }
}