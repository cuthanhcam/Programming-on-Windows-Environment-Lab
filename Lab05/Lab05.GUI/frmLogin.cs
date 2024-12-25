using Lab05.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab05.GUI
{
    public partial class frmLogin : Form
    {
        private readonly UserService userService = new UserService();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ TextBox
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Kiểm tra nếu username hoặc password rỗng
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gọi UserService để kiểm tra đăng nhập
            if (userService.Login(username, password, out string role))
            {
                // Thông báo đăng nhập thành công
                MessageBox.Show($"Đăng nhập thành công! Vai trò của bạn: {role}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Mở frmStudent và truyền vai trò
                this.Hide();
                frmStudent studentForm = new frmStudent(role);
                studentForm.ShowDialog();
                this.Close();
            }
            else
            {
                // Thông báo đăng nhập thất bại
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            // Hiển thị hoặc ẩn mật khẩu dựa trên trạng thái của CheckBox
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // Hỏi trước khi đóng form
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
