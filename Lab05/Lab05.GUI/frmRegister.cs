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
                var listMajors = majorService.GetAll(); // Lấy toàn bộ chuyên ngành

                FillFalcultyComboBox(listFacultys);
                FillMajorComboBox(listMajors); // Đổ dữ liệu vào cmbMajor
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

        //Hàm binding list dữ liệu khoa vào combobox có tên hiện thị là tên khoa, giá trị là Mã khoa
        private void FillFalcultyComboBox(List<Faculty> listFacultys)
        {
            this.cmbFaculty.DataSource = listFacultys;
            this.cmbFaculty.DisplayMember = "FacultyName";
            this.cmbFaculty.ValueMember = "FacultyID";
        }
        private void cmbFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            Faculty selectedFaculty = cmbFaculty.SelectedItem as Faculty;
            if (selectedFaculty != null)
            {
                var listMajor = majorService.GetAllByFaculty(selectedFaculty.FacultyID);
                FillMajorComboBox(listMajor); // Đổ dữ liệu vào combobox chuyên ngành

                var listStudent = chkNotRegisterMajor.Checked
                    ? studentService.GetAllHasNoMajor(selectedFaculty.FacultyID)
                    : studentService.GetAllByFaculty(selectedFaculty.FacultyID);
                BindGrid(listStudent); // Cập nhật danh sách sinh viên theo khoa
            }
        }

        private void BindGrid(List<Student> listStudent)
        {
            dgvStudent.Rows.Clear();

            foreach (var item in listStudent)
            {
                int index = dgvStudent.Rows.Add();
                dgvStudent.Rows[index].Cells[0].Value = false; // Checkbox để chọn sinh viên
                dgvStudent.Rows[index].Cells[1].Value = item.StudentID;
                dgvStudent.Rows[index].Cells[2].Value = item.FullName;
                dgvStudent.Rows[index].Cells[3].Value = item.Faculty?.FacultyName ?? "N/A"; // Kiểm tra null
                dgvStudent.Rows[index].Cells[4].Value = item.AverageScore?.ToString("0.00") ?? "N/A";
                //dgvStudent.Rows[index].Cells[5].Value = item.Major?.Name ?? "N/A";
            }
        }


        private void FillMajorComboBox(List<Major> listMajor)
        {
            if (listMajor == null || listMajor.Count == 0)
            {
                this.cmbMajor.DataSource = null; // Làm trống combobox nếu không có chuyên ngành
                this.cmbMajor.Items.Clear();
            }
            else
            {
                this.cmbMajor.DataSource = listMajor;
                this.cmbMajor.DisplayMember = "Name";
                this.cmbMajor.ValueMember = "MajorID";
            }
        }

        private void chkNotRegisterMajor_CheckedChanged(object sender, EventArgs e)
        {
            var listStudent = new List<Student>();
            if (this.chkNotRegisterMajor.Checked)
                listStudent = studentService.GetAllHasNoMajor();
            else
                listStudent = studentService.GetAll();
            BindGrid(listStudent);
        }

        private void cmbMajor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!chkNotRegisterMajor.Checked)
            {
                if (int.TryParse(cmbFaculty.SelectedValue?.ToString(), out int selectedFacultyID) &&
                    int.TryParse(cmbMajor.SelectedValue?.ToString(), out int selectedMajorID))
                {
                    var listStudent = studentService.GetAllHasNoMajor(selectedFacultyID, selectedMajorID);
                    BindGrid(listStudent);
                }
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
            var selectedMajorID = (int)cmbMajor.SelectedValue;

            foreach (DataGridViewRow row in dgvStudent.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    string studentID = row.Cells[1].Value.ToString();
                    RegisterMajor(studentID, selectedMajorID);
                }
            }
            MessageBox.Show("Đăng ký chuyên ngành thành công!");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                return;
            this.Close();
        }
    }
}