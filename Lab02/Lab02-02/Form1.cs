// 2280600285 - Cu Thanh Cam - https://github.com/cuthanhcam

using System;
using System.Linq;
using System.Windows.Forms;

namespace Lab02_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbFaculty.Items.AddRange(new string[] { "QTKD", "CNTT", "NNA" });
            cmbFaculty.SelectedIndex = 0; // Default faculty
            optFemale.Checked = true; // Default gender
            txtTotalMale.Text = "0";
            txtTotalFemale.Text = "0";
        }

        private void btnInsertUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudentID.Text) ||
                string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtAverageScore.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string studentID = txtStudentID.Text.Trim();
            string fullName = txtFullName.Text.Trim();
            string gender = optMale.Checked ? "Nam" : "Nữ";
            string faculty = cmbFaculty.SelectedItem.ToString();
            float averageScore;

            if (!float.TryParse(txtAverageScore.Text.Trim(), out averageScore))
            {
                MessageBox.Show("Điểm trung bình phải là số hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if StudentID exists
            var existingRow = dgvStudent.Rows.Cast<DataGridViewRow>()
                                  .FirstOrDefault(row => row.Cells["StudentID"].Value?.ToString() == studentID);

            if (existingRow == null)
            {
                // Add new student
                dgvStudent.Rows.Add(studentID, fullName, gender, averageScore, faculty);
                MessageBox.Show("Thêm mới dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Update existing student
                existingRow.Cells["FullName"].Value = fullName;
                existingRow.Cells["Gender"].Value = gender;
                existingRow.Cells["AverageScore"].Value = averageScore;
                existingRow.Cells["Faculty"].Value = faculty;
                MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            UpdateGenderCounts();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string studentID = txtStudentID.Text.Trim();

            var existingRow = dgvStudent.Rows.Cast<DataGridViewRow>()
                                  .FirstOrDefault(row => row.Cells["StudentID"].Value?.ToString() == studentID);

            if (existingRow == null)
            {
                MessageBox.Show("Không tìm thấy MSSV cần xóa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show("Bạn có chắc muốn xóa sinh viên này?",
                                                 "Xác nhận",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                dgvStudent.Rows.Remove(existingRow);
                MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateGenderCounts();
            }
        }

        private void dgvStudent_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStudent.CurrentRow == null) return;

            var selectedRow = dgvStudent.CurrentRow;
            txtStudentID.Text = selectedRow.Cells["StudentID"].Value?.ToString();
            txtFullName.Text = selectedRow.Cells["FullName"].Value?.ToString();
            txtAverageScore.Text = selectedRow.Cells["AverageScore"].Value?.ToString();
            cmbFaculty.SelectedItem = selectedRow.Cells["Faculty"].Value?.ToString();

            string gender = selectedRow.Cells["Gender"].Value?.ToString();
            if (gender == "Nam")
                optMale.Checked = true;
            else
                optFemale.Checked = true;
        }

        private void UpdateGenderCounts()
        {
            int maleCount = dgvStudent.Rows.Cast<DataGridViewRow>()
                            .Count(row => row.Cells["Gender"].Value?.ToString() == "Nam");
            int femaleCount = dgvStudent.Rows.Cast<DataGridViewRow>()
                              .Count(row => row.Cells["Gender"].Value?.ToString() == "Nữ");

            txtTotalMale.Text = maleCount.ToString();
            txtTotalFemale.Text = femaleCount.ToString();
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
