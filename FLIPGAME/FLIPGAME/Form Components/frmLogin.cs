using FLIPGAME.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FLIPGAME.Form_Components
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            ApplyPlaceholder();
        }

        private void ApplyPlaceholder()
        {
            // Đặt placeholder cho username
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                txtUsername.Text = "Username";
                txtUsername.ForeColor = Color.Gray;
            }

            // Đặt placeholder và bỏ ẩn mật khẩu
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.Gray;
                txtPassword.PasswordChar = '\0'; // •
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            using (var context = new FlipGameDBContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == username);
                if (user != null && VerifyPasswordHash(password, user.PasswordHash))
                {
                    MessageBox.Show("Đăng nhập thành công!");
                    this.Hide();
                    frmMain mainForm = new frmMain(user);
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.");
                }
            }
        }


        private bool VerifyPasswordHash(string password, string storedHash)
        {
            using (var sha256 = SHA256.Create())
            {
                var computedHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var computedHashString = string.Concat(computedHash.Select(b => b.ToString("x2")));
                return storedHash.Equals(computedHashString, StringComparison.OrdinalIgnoreCase);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string username = txtRegisterUsername.Text;
            string password = txtRegisterPassword.Text;
            string retryPassword = txtRetryPassword.Text;

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Email không hợp lệ. Vui lòng sử dụng địa chỉ Gmail.");
                return;
            }

            if (password != retryPassword)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp.");
                return;
            }

            using (var context = new FlipGameDBContext())
            {
                if (context.Users.Any(u => u.Email == email || u.Username == username))
                {
                    MessageBox.Show("Email hoặc tên đăng nhập đã tồn tại.");
                    return;
                }

                var user = new User
                {
                    Email = email,
                    Username = username,
                    PasswordHash = HashPassword(password),
                    CreatedAt = DateTime.Now
                };

                context.Users.Add(user);
                context.SaveChanges();
                MessageBox.Show("Đăng ký thành công!");
            }
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return string.Concat(hashedBytes.Select(b => b.ToString("x2")));
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email && email.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase);
            }
            catch
            {
                return false;
            }
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Username")
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = Color.Black;
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                txtUsername.Text = "Username";
                txtUsername.ForeColor = Color.Gray;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
                txtPassword.PasswordChar = '•';
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.Gray;
                txtPassword.PasswordChar = '\0';
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';  // Hiển thị mật khẩu
            }
            else
            {
                if (txtPassword.Text != "Password")
                {
                    txtPassword.PasswordChar = '•';  // Ẩn mật khẩu
                }
            }
        }
    }
}
