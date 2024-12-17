using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03_03
{
    public partial class Form2 : Form
    {
        List<Student> studentList;
        public Form2(List<Student> students)
        {
            InitializeComponent();
            studentList = students;
            comboBoxFaculty.SelectedIndex = 0; // Giá trị mặc định
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string id = textBoxId.Text.Trim();
            string name = textBoxName.Text.Trim();
            string faculty = comboBoxFaculty.SelectedItem.ToString();
            float score;

            // Kiểm tra dữ liệu nhập vào
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(textBoxScore.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra mã số sinh viên trùng
            if (studentList.Any(s => s.Id == id))
            {
                MessageBox.Show("Mã số sinh viên đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra điểm hợp lệ
            if (!float.TryParse(textBoxScore.Text, out score) || score < 0 || score > 10)
            {
                MessageBox.Show("Điểm phải nằm trong khoảng từ 0 đến 10!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Thêm mới sinh viên vào danh sách
            studentList.Add(new Student
            {
                Id = id,
                Name = name,
                Faculty = faculty,
                Score = score
            });

            MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK; // Trả kết quả thành công về Form chính
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
