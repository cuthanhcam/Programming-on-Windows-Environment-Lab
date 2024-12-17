using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //timer1.Tick += timer1_Tick;
            //openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            //exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // Gắn sự kiện Resize cho Form
            this.Resize += Form1_Resize;

            // Kích thước ban đầu
            this.Size = new System.Drawing.Size(900, 450);
            axWindowsMediaPlayer1.Size = new System.Drawing.Size(900, 400);
            axWindowsMediaPlayer1.Location = new System.Drawing.Point(0, 25);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = string.Format("Hôm nay là ngày {0} - Bây giờ là {1}",
            DateTime.Now.ToString("dd/MM/yyyy"),
            DateTime.Now.ToString("hh:mm:ss tt"));
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Tạo hộp thoại Open File
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "AVI file|*.avi|MPEG File|*.mpeg|WAV File|*.wav|MIDI File|*.midi|MP4 File|*.mp4|MP3 File|*.mp3";

            // Hiển thị hộp thoại và kiểm tra người dùng có chọn file không
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                axWindowsMediaPlayer1.URL = dlg.FileName; // Mở file đã chọn
                //axWindowsMediaPlayer1.Ctlcontrols.play(); // Bắt đầu phát file
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Size = new System.Drawing.Size(this.ClientSize.Width, this.ClientSize.Height - 50);
            axWindowsMediaPlayer1.Location = new System.Drawing.Point(0, 25); // Tránh MenuStrip
        }
    }
}
