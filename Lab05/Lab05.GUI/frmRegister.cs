using Lab05.BUS;
using Lab05.DAL.Entities;
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
    public partial class frmRegister : Form
    {
        private readonly StudentService studentService = new StudentService();
        private readonly FacultyService facultyService = new FacultyService();
        private readonly MajorService majorService = new MajorService();
        public frmRegister()
        {
            InitializeComponent();
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            try
            {
                setGridViewStyle(dgvStudent);
                var listStudents = studentService.GetAll();
                var listFacultys = facultyService.GetAll();
                FillFalcultyComboBox(listFacultys);
                BindGrid(listStudents);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void setGridViewStyle(DataGridView dgview)
        {
            dgview.BorderStyle = BorderStyle.None;
            dgview.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgview.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgview.BackgroundColor = Color.White;
            dgview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void FillFalcultyComboBox(List<Faculty> listFacultys)
        {
            this.cmbFaculty.DataSource = listFacultys;
            this.cmbFaculty.DisplayMember = "FacultyName";
            this.cmbFaculty.ValueMember = "FacultyID";
        }
        private void FillMajorComboBox(List<Major> listMajor)
        {
            cmbMajor.DataSource = null; // Xóa binding cũ
            cmbMajor.Items.Clear();    // Xóa tất cả mục trước đó (nếu có)

            if (listMajor != null && listMajor.Count > 0)
            {
                cmbMajor.DataSource = listMajor;
                cmbMajor.DisplayMember = "Name";
                cmbMajor.ValueMember = "MajorID";
            }
            else
            {
                MessageBox.Show("Không có chuyên ngành nào được tìm thấy!");
            }
        }


        private void BindGrid(List<Student> listStudent)
        {
            dgvStudent.Rows.Clear();
            foreach (var item in listStudent)
            {
                int index = dgvStudent.Rows.Add();

                dgvStudent.Rows[index].Cells[1].Value = item.StudentID;
                dgvStudent.Rows[index].Cells[2].Value = item.FullName;
                if (item.Faculty != null)
                {
                    dgvStudent.Rows[index].Cells[3].Value = item.Faculty.FacultyName;
                }
                else
                {
                    dgvStudent.Rows[index].Cells[4].Value = "N/A";
                }
                dgvStudent.Rows[index].Cells[4].Value = item.AverageScore + "";
                if (item.MajorID != null)
                    dgvStudent.Rows[index].Cells[5].Value = item.Major.Name + "";
            }
        }
        private void cmbFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            Faculty selectedFaculty = cmbFaculty.SelectedItem as Faculty;
            if (selectedFaculty != null)
            {
                var listMajor = majorService.GetAllByFaculty(selectedFaculty.FacultyID);
                FillMajorComboBox(listMajor);

                if (int.TryParse(cmbFaculty.SelectedValue?.ToString(), out int selectedFacultyID) &&
                    int.TryParse(cmbMajor.SelectedValue?.ToString(), out int selectedMajorID))
                {
                    var listStudent = studentService.GetAllHasNoMajor(selectedFacultyID, selectedMajorID);
                    BindGrid(listStudent);
                }
                else
                {
                    var listStudent = studentService.GetAllHasNoMajor(selectedFaculty.FacultyID);
                    BindGrid(listStudent);
                }

            }
        }


        private void cmbMajor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFaculty.SelectedValue == null || cmbMajor.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn khoa và chuyên ngành hợp lệ.");
                return;
            }

            if (int.TryParse(cmbFaculty.SelectedValue.ToString(), out int selectedFacultyID) &&
                int.TryParse(cmbMajor.SelectedValue.ToString(), out int selectedMajorID))
            {
                var listStudent = studentService.GetAllHasNoMajor(selectedFacultyID, selectedMajorID);
                BindGrid(listStudent);
            }
        }
        private void RegisterMajor(string studentID, int majorID)
        {
            using (var context = new StudentModel())
            {
                var sinhVien = context.Students.SingleOrDefault(sv => sv.StudentID == studentID);

                if (sinhVien != null)
                {
                    sinhVien.MajorID = majorID;

                    context.SaveChanges();
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (cmbMajor.SelectedValue == null || !int.TryParse(cmbMajor.SelectedValue.ToString(), out int selectedMajorID))
            {
                MessageBox.Show("Vui lòng chọn chuyên ngành hợp lệ.");
                return;
            }

            bool hasSelected = false;
            foreach (DataGridViewRow row in dgvStudent.Rows)
            {
                if (row.Cells[0].Value is bool isChecked && isChecked)
                {
                    string studentID = row.Cells[1].Value.ToString();
                    RegisterMajor(studentID, selectedMajorID);
                    hasSelected = true;
                }
            }

            if (hasSelected)
            {
                MessageBox.Show("Đăng ký chuyên ngành thành công!");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ít nhất một sinh viên.");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                return;
            this.Close();
        }
    }
}