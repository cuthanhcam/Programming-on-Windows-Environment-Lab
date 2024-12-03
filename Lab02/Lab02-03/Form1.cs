// 2280600285 - Cu Thanh Cam - https://github.com/cuthanhcam

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab02_03
{
    public partial class Form1 : Form
    {
        private const int Rows = 4; // 4 hàng
        private const int SeatsPerRow = 5; // 5 ghế mỗi hàng
        private readonly int[] SeatPrices = { 30000, 40000, 50000, 80000 };

        public Form1()
        {
            InitializeComponent();
            CreateSeats();
        }

        private void CreateSeats()
        {
            GroupBox seatGroup = new GroupBox
            {
                Text = "Sơ đồ ghế ngồi",
                Width = 360,
                Height = 300,
                Location = new Point(10, 10)
            };

            this.Controls.Add(seatGroup);

            int seatNumber = 1;

            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < SeatsPerRow; col++)
                {
                    Button seatButton = new Button
                    {
                        Text = seatNumber.ToString(),
                        Width = 60,
                        Height = 60,
                        BackColor = Color.White, // Mặc định là ghế trống
                        Location = new Point(col * 70 + 10, row * 70 + 20),
                        Tag = new SeatInfo { Row = row, Price = SeatPrices[row] } // Lưu thông tin hàng và giá vé
                    };

                    seatButton.Click += btnChooseASeat;
                    seatGroup.Controls.Add(seatButton);

                    seatNumber++;
                }
            }

            /*
            // Nút Chọn
            Button btnConfirm = new Button
            {
                Text = "Chọn",
                Width = 80,
                Height = 40,
                Location = new Point(420, 50)
            };
            btnConfirm.Click += btnConfirm_Click;
            this.Controls.Add(btnConfirm);

            // Nút Hủy bỏ
            Button btnCancel = new Button
            {
                Text = "Hủy bỏ",
                Width = 80,
                Height = 40,
                Location = new Point(420, 100)
            };
            btnCancel.Click += btnCancel_Click;
            this.Controls.Add(btnCancel);

            // Label hiển thị tổng tiền
            Label lblTotal = new Label
            {
                Text = "Thành tiền:",
                Location = new Point(420, 160),
                Width = 70
            };
            this.Controls.Add(lblTotal);

            // TextBox hiển thị giá trị tổng tiền
            TextBox txtTotal = new TextBox
            {
                Name = "txtTotal",
                Location = new Point(500, 157),
                Width = 100,
                ReadOnly = true,
                Text = "0"
            };
            this.Controls.Add(txtTotal);
            */
        }


        private void btnChooseASeat(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn.BackColor == Color.White)
                btn.BackColor = Color.Blue; // Đổi sang màu đang chọn
            else if (btn.BackColor == Color.Blue)
                btn.BackColor = Color.White; // Đổi lại màu ghế trống
            else if (btn.BackColor == Color.Yellow)
                MessageBox.Show("Ghế đã được bán!!");
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            int total = 0;

            var seatGroup = this.Controls.OfType<GroupBox>().FirstOrDefault();
            if (seatGroup == null) return;

            foreach (Button btn in seatGroup.Controls.OfType<Button>())
            {
                if (btn.BackColor == Color.Blue) // Nếu là ghế đang chọn
                {
                    btn.BackColor = Color.Yellow; // Đổi thành ghế đã bán
                    var seatInfo = (SeatInfo)btn.Tag;
                    total += seatInfo.Price;
                }
            }

            var txtTotal = this.Controls.OfType<TextBox>().FirstOrDefault(txt => txt.Name == "txtTotal");
            if (txtTotal != null)
                txtTotal.Text = total.ToString();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            var seatGroup = this.Controls.OfType<GroupBox>().FirstOrDefault();
            if (seatGroup == null) return;

            foreach (Button btn in seatGroup.Controls.OfType<Button>())
            {
                if (btn.BackColor == Color.Blue) // Nếu là ghế đang chọn
                {
                    btn.BackColor = Color.White; // Đổi lại ghế trống
                }
            }

            var txtTotal = this.Controls.OfType<TextBox>().FirstOrDefault(txt => txt.Name == "txtTotal");
            if (txtTotal != null)
                txtTotal.Text = "0";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có muốn thoát", "Câu hỏi thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
