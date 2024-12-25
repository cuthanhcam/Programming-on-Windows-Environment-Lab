using Lab05.BUS;
using Lab05.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab05.GUI
{
    public partial class frmStudent : Form
    {
        private readonly StudentService studentService = new StudentService();
        private readonly FacultyService facultyService = new FacultyService();
        private string imageRelativePath;
        private string imageFileName = "D:\\SourceCode\\VisualStudio\\CSharp\\Programming-on-Windows-Environment-Lab\\Lab05";
        public frmStudent()
        {
            InitializeComponent();
        }

        private void frmStudent_Load(object sender, EventArgs e)
        {
            try
            {
                setGridViewStyle(dgvStudent);
                var listFacultys = facultyService.GetAll();
                var listStudents = studentService.GetAll();
                FillFacultyComboBox(listFacultys);
                BindGrid(listStudents);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillFacultyComboBox(List<Faculty> listFacultys)
        {
            listFacultys.Insert(0, new Faculty());
            this.cmbFaculty.DataSource = listFacultys;
            this.cmbFaculty.DisplayMember = "FacultyName";
            this.cmbFaculty.ValueMember = "FacultyID";
        }

        //Hàm binding gridView từ list sinh viên                   
        private void BindGrid(List<Student> listStudent)
        {
            dgvStudent.Rows.Clear();
            foreach (var item in listStudent)
            {
                int index = dgvStudent.Rows.Add();
                dgvStudent.Rows[index].Cells[0].Value = item.StudentID;
                dgvStudent.Rows[index].Cells[1].Value = item.FullName;
                if (item.Faculty != null)
                    dgvStudent.Rows[index].Cells[2].Value = item.Faculty.FacultyName;
                dgvStudent.Rows[index].Cells[3].Value = item.AverageScore + "";

                if (item.MajorID != null)
                    dgvStudent.Rows[index].Cells[4].Value = item.Major.Name + "";
                ShowAvatar(item.Avatar);
            }
        }
        public void setGridViewStyle(DataGridView dgview)
        {
            dgview.BorderStyle = BorderStyle.None;
            dgview.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgview.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgview.BackgroundColor = Color.White;
            dgview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void chkNotRegisteredMajor_CheckedChanged(object sender, EventArgs e)
        {
            var listStudent = new List<Student>();
            if (this.chkNotRegisteredMajor.Checked) listStudent = studentService.GetAllHasNoMajor();
            else listStudent = studentService.GetAll();
            BindGrid(listStudent);
        }
        private void ShowAvatar(string ImageName)
        {
            if (string.IsNullOrEmpty(ImageName))
            {
                picAvatar.Image = null;
            }
            else
            {
                string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                string imagePath = Path.Combine(parentDirectory, imageFileName, ImageName);
                picAvatar.Image = Image.FromFile(imagePath);
                picAvatar.Refresh();
            }
        }

        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStudentID.Text))
            {
                MessageBox.Show("Please enter or select student ID to save avatar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string studentID = txtStudentID.Text;
            string imageFolder = Path.Combine(Application.StartupPath, imageFileName);
            string imagePathJPG = Path.Combine(imageFolder, studentID + ".jpg");
            string imagePathPNG = Path.Combine(imageFolder, studentID + ".png");
            if (picAvatar.Image != null)
            {
                picAvatar.Image.Dispose();
                picAvatar.Image = null;
            }
            if (File.Exists(imagePathJPG))
            {
                File.Delete(imagePathJPG);
            }
            else if (File.Exists(imagePathPNG))
            {
                File.Delete(imagePathPNG);
            }
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files (*.png, *.jpg, *.jpeg, *.gif, *.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string imagePath = ofd.FileName;
                string extension = Path.GetExtension(imagePath);
                string fileName = studentID + extension;
                picAvatar.Image = Image.FromFile(imagePath);
                if (!Directory.Exists(imageFolder))
                {
                    Directory.CreateDirectory(imageFolder);
                }
                string destinationFilePath = Path.Combine(imageFolder, fileName);
                File.Copy(imagePath, destinationFilePath, true); // Lưu ảnh mới vào thư mục
                imageRelativePath = Path.Combine(imageFileName, fileName);
            }
        }
        private int GetSelectedRow(string studentID)
        {
            for (int i = 0; i < dgvStudent.Rows.Count; i++)
            {
                if (dgvStudent.Rows[i].Cells[0].Value != null &&
                    dgvStudent.Rows[i].Cells[0].Value.ToString() == studentID)
                {
                    return i;
                }
            }
            return -1;
        }
        private void LoadData()
        {
            List<Student> students = studentService.GetAll();
            dgvStudent.Rows.Clear();
            foreach (var student in students)
            {
                int index = dgvStudent.Rows.Add();

                dgvStudent.Rows[index].Cells[0].Value = student.StudentID;
                dgvStudent.Rows[index].Cells[1].Value = student.FullName;
                dgvStudent.Rows[index].Cells[2].Value = student.Faculty?.FacultyName ?? null;
                dgvStudent.Rows[index].Cells[3].Value = student.AverageScore;
                dgvStudent.Rows[index].Cells[4].Value = student.Major?.Name ?? null;
            }
        }

        private void registerMajorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegister frmRegister = new frmRegister();
            frmRegister.ShowDialog();
        }

        private void btnAddUpdate_Click(object sender, EventArgs e)
        {
            string studentID = txtStudentID.Text;
            string fullName = txtFullName.Text;
            string averageScoreText = txtAverageScore.Text;
            Faculty selectedFaculty = cmbFaculty.SelectedItem as Faculty; // Lấy khoa từ ComboBox
            string imageName = Path.GetFileName(imageRelativePath); // Lấy tên ảnh từ đường dẫn

            if (string.IsNullOrEmpty(studentID) || string.IsNullOrEmpty(fullName) || selectedFaculty == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var student = new Student()
            {
                StudentID = studentID,
                FullName = fullName,
                AverageScore = float.Parse(averageScoreText),
                FacultyID = selectedFaculty.FacultyID,
                Avatar = imageName,
            };

            studentService.InsertUpdate(student);
            List<Student> listStudents = studentService.GetAll();
            BindGrid(listStudents);
            frmStudent_Load(null, null);
            MessageBox.Show("Thêm/Cập nhật sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                return;
            this.Close();
        }

        private void dgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !dgvStudent.Rows[e.RowIndex].IsNewRow)
            {
                DataGridViewRow row = dgvStudent.Rows[e.RowIndex];

                txtStudentID.Text = row.Cells[0].Value.ToString();
                txtFullName.Text = row.Cells[1].Value.ToString();
                txtAverageScore.Text = row.Cells[3].Value.ToString();
                cmbFaculty.Text = row.Cells[2].Value.ToString();

                string studentID = txtStudentID.Text;
                string imageFolder = Path.Combine(Application.StartupPath, imageFileName);
                string imagePathJPG = Path.Combine(imageFolder, studentID + ".jpg");
                string imagePathPNG = Path.Combine(imageFolder, studentID + ".png");

                if (File.Exists(imagePathJPG))
                {
                    picAvatar.Image = Image.FromFile(imagePathJPG);
                }
                else if (File.Exists(imagePathPNG))
                {
                    picAvatar.Image = Image.FromFile(imagePathPNG);
                }
                else
                {
                    picAvatar.Image = null;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvStudent.SelectedRows.Count > 0)
            {
                int row = GetSelectedRow(txtStudentID.Text);
                if (row == -1)
                {
                    MessageBox.Show("Không tìm thấy sinh viên cần xoá", "THÔNG BÁO");
                    return;
                }
                string selectedStudentID = dgvStudent.SelectedRows[0].Cells[0].Value.ToString();
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        Student studentToDelete = studentService.FindById(selectedStudentID);

                        if (studentToDelete != null)
                        {
                            if (!string.IsNullOrEmpty(studentToDelete.Avatar))
                            {
                                string imagePath = Path.Combine(Application.StartupPath, imageFileName, studentToDelete.Avatar);
                                if (File.Exists(imagePath))
                                {
                                    File.Delete(imagePath);
                                }
                            }
                            studentService.DeleteStudent(selectedStudentID);
                            LoadData();
                            MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi  ra khi xóa sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sinh viên để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
