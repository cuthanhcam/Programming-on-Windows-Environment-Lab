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
    public partial class Form1 : Form
    {
        List<Student> studentList = new List<Student>();
        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
        }
        private void AddNewStudent()
        {
            // Mở Form nhập liệu và truyền danh sách hiện tại
            Form2 inputForm = new Form2(studentList);
            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                // Cập nhật DataGridView
                dataGridViewStudents.DataSource = null; // Xóa DataSource cũ
                dataGridViewStudents.DataSource = new BindingList<Student>(studentList);

                // Cập nhật cột Index
                UpdateRowIndexes();
            }
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            AddNewStudent();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewStudent();
        }

        private void toolStripTextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = toolStripTextBoxSearch.Text.ToLower();

            // Lọc danh sách sinh viên chứa tên tìm kiếm
            var filteredList = studentList
                .Where(s => s.Name.ToLower().Contains(searchText))
                .ToList();

            // Cập nhật DataGridView với danh sách tìm được
            dataGridViewStudents.DataSource = null;
            dataGridViewStudents.DataSource = filteredList;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void UpdateRowIndexes()
        {
            for (int i = 0; i < dataGridViewStudents.Rows.Count; i++)
            {
                dataGridViewStudents.Rows[i].Cells["Index"].Value = i + 1;
            }
        }
        private void dataGridViewStudents_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < dataGridViewStudents.Rows.Count; i++)
            {
                dataGridViewStudents.Rows[i].Cells["Index"].Value = i + 1;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Tắt chế độ tự động tạo cột
            dataGridViewStudents.AutoGenerateColumns = false;

            // Xóa tất cả các cột hiện có (nếu có)
            dataGridViewStudents.Columns.Clear();

            // Thêm các cột thủ công
            dataGridViewStudents.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Index",
                HeaderText = "Index",
                Width = 50,
                ReadOnly = true
            });
            dataGridViewStudents.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Id",
                Name = "Id",
                HeaderText = "Student ID",
                Width = 150
            });
            dataGridViewStudents.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Name",
                Name = "Name",
                HeaderText = "Name",
                Width = 250
            });
            dataGridViewStudents.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Faculty",
                Name = "Faculty",
                HeaderText = "Faculty",
                Width = 200
            });
            dataGridViewStudents.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Score",
                Name = "Score",
                HeaderText = "Average Score",
                Width = 150
            });

            // Gán danh sách sinh viên ban đầu
            dataGridViewStudents.DataSource = studentList;
        }
    }
}
