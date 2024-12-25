using Lab05.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lab05.BUS
{
    public class UserService
    {
        // Password có mã hóa SHA256
        /*
        public bool Login(string username, string password, out string role)
        {
            role = null;
            using (StudentModel context = new StudentModel())
            {
                string passwordHash = HashPassword(password);
                var user = context.Users
                    .FirstOrDefault(u => u.Username == username && u.PasswordHash == passwordHash);

                if (user != null)
                {
                    role = user.Role; // Lấy vai trò người dùng
                    return true;
                }

                return false;
            }
        }
        */
        public bool Login(string username, string password, out string role)
        {
            role = null;
            using (StudentModel context = new StudentModel())
            {
                // So sánh trực tiếp với mật khẩu trong CSDL
                var user = context.Users
                    .FirstOrDefault(u => u.Username == username && u.PasswordHash == password);

                if (user != null)
                {
                    role = user.Role; // Lấy vai trò người dùng
                    return true;
                }

                return false;
            }
        }

        public bool Register(string username, string password, string role)
        {
            using (StudentModel context = new StudentModel())
            {
                if (context.Users.Any(u => u.Username == username))
                {
                    return false; // Username đã tồn tại
                }

                var newUser = new User
                {
                    Username = username,
                    PasswordHash = HashPassword(password),
                    Role = role
                };

                context.Users.Add(newUser);
                context.SaveChanges();
                return true;
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower(); // Chuyển đổi giống SQL Server
            }
        }

    }
}
