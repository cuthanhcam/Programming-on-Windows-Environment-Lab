using Lab04_01.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab04_01
{
    public partial class frmSearch : Form
    {
        public frmSearch()
        {
            InitializeComponent();
        }
        private void frmSearch_Load(object sender, EventArgs e)
        {
            try
            {
                using (StudentContextDB context = new StudentContextDB())
                {
                    var faculties = context.Faculties.ToList();
                    faculties.Insert(0, new Faculty { FacultyID = 0, FacultyName = "Empty" }); // Dòng mặc định
                    comboBoxFaculty.DataSource = faculties;
                    comboBoxFaculty.DisplayMember = "FacultyName";
                    comboBoxFaculty.ValueMember = "FacultyID";
                    comboBoxFaculty.SelectedIndex = 0; // Chọn mặc định là "Empty"
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu khoa: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                using (StudentContextDB context = new StudentContextDB())
                {
                    var query = context.Students.AsQueryable();

                    // Điều kiện tìm kiếm theo StudentID
                    if (!string.IsNullOrWhiteSpace(txtStudentID.Text))
                    {
                        query = query.Where(s => s.StudentID.Contains(txtStudentID.Text));
                    }

                    // Điều kiện tìm kiếm theo StudentName
                    if (!string.IsNullOrWhiteSpace(txtStudentName.Text))
                    {
                        query = query.Where(s => s.FullName.Contains(txtStudentName.Text));
                    }

                    // Điều kiện tìm kiếm theo Faculty
                    if (comboBoxFaculty.SelectedIndex > 0) // Bỏ qua "Empty"
                    {
                        int facultyID = (int)comboBoxFaculty.SelectedValue;
                        query = query.Where(s => s.FacultyID == facultyID);
                    }

                    // Lấy danh sách kết quả
                    var result = query.ToList();

                    // Kiểm tra kết quả
                    if (result.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy kết quả phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridViewSearchResults.Rows.Clear();
                        txtSearchResult.Text = "0";
                        return;
                    }

                    // Hiển thị kết quả trên DataGridView
                    BindGrid(result);

                    // Cập nhật số lượng kết quả tìm thấy
                    txtSearchResult.Text = result.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void BindGrid(List<Student> students)
        {
            dataGridViewSearchResults.Rows.Clear();

            foreach (var student in students)
            {
                int index = dataGridViewSearchResults.Rows.Add();
                dataGridViewSearchResults.Rows[index].Cells[0].Value = student.StudentID;
                dataGridViewSearchResults.Rows[index].Cells[1].Value = student.FullName;
                dataGridViewSearchResults.Rows[index].Cells[2].Value = student.Faculty?.FacultyName ?? "Không xác định";
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            txtStudentID.Clear();
            txtStudentName.Clear();
            comboBoxFaculty.SelectedIndex = 0; // Reset về "Empty"
            txtSearchResult.Text = "0"; // Đặt lại số lượng kết quả
            dataGridViewSearchResults.Rows.Clear(); // Xóa kết quả hiển thị
        }
    }
}
