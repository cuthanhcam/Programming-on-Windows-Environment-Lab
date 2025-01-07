using Lab06.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab06
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void FillCategoryCombobox(List<CATEGORYBOOK> listCategorys)
        {
            this.cmbCategory.DataSource = listCategorys;
            this.cmbCategory.DisplayMember = "CategoryName";
            this.cmbCategory.ValueMember = "CategoryID";
        }

        private void BindGrid(List<BOOK> listBook)
        {
            dgvBook.Rows.Clear();
            foreach (var item in listBook)
            {
                int index = dgvBook.Rows.Add();
                dgvBook.Rows[index].Cells[0].Value = item.BOOKID;
                dgvBook.Rows[index].Cells[1].Value = item.BOOKNAME;
                dgvBook.Rows[index].Cells[2].Value = item.NAMXB;
                if (item.CATEGORYBOOK != null)
                {
                    dgvBook.Rows[index].Cells[3].Value = item.CATEGORYBOOK.CATEGORYNAME;
                }
                else
                {
                    dgvBook.Rows[index].Cells[3].Value = "Công nghệ thông tin"; // Giá trị mặc định
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                CategoryContextDB db = new CategoryContextDB();
                List<BOOK> bookList = db.BOOKS.ToList();
                if (bookList.Any(s => s.BOOKID == txtID.Text))
                {
                    MessageBox.Show("Mã sách đã tồn tại. Vui lòng nhập một mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var newBook = new BOOK
                {
                    BOOKID = txtID.Text,
                    BOOKNAME = txtName.Text,
                    CATEGORYID= int.Parse(cmbCategory.SelectedValue.ToString()),
                    NAMXB = int.Parse(txtYear.Text)
                };


                //Thêm SV vào CSDL
                db.BOOKS.Add(newBook);
                db.SaveChanges();

                //Hiển thị lại danh sách sinh viên
                BindGrid(db.BOOKS.ToList());

                MessageBox.Show("Thêm sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm dữ liệu: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                

                CategoryContextDB db = new CategoryContextDB();
                List<BOOK> students = db.BOOKS.ToList();
                var student = students.FirstOrDefault(s => s.BOOKID == txtID.Text);
                if (student != null)
                {
                    if (students.Any(s => s.BOOKID == txtID.Text && s.BOOKID != student.BOOKID))
                    {
                        MessageBox.Show("Mã sách đã tồn tại. Vui lòng nhập một mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    student.BOOKNAME = txtName.Text;
                    student.CATEGORYID= int.Parse(cmbCategory.SelectedValue.ToString());
                    student.NAMXB = int.Parse(txtYear.Text);

                    //Cập nhật sinh viên lưu vào CSDL 
                    db.SaveChanges();

                    //Hiển thị lại danh sách sinh viên
                    BindGrid(db.BOOKS.ToList());

                    MessageBox.Show("Chỉnh sửa thông tin sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sách không tìm thấy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật dữ liệu: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                CategoryContextDB db = new CategoryContextDB();
                List<BOOK> bookList = db.BOOKS.ToList();

                //Tim kiếm SV có tồn tại trong CSDL hay không
                var book = bookList.FirstOrDefault(s => s.BOOKID == txtID.Text);

                if (book != null)
                {
                    //Xóa sinh viên khỏi CSDL
                    db.BOOKS.Remove(book);
                    db.SaveChanges();

                    BindGrid(db.BOOKS.ToList());

                    MessageBox.Show("Sách đã được xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Sách không tìm thấy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật dữ liệu: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvBook.Rows[e.RowIndex];
                txtID.Text = selectedRow.Cells[0].Value.ToString();
                txtName.Text = selectedRow.Cells[1].Value.ToString();
                cmbCategory.Text = selectedRow.Cells[3].Value.ToString();
                txtYear.Text = selectedRow.Cells[2].Value.ToString();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Bạn có chắc chắn muốn thoát ứng dụng?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                CategoryContextDB context = new CategoryContextDB();
                List<CATEGORYBOOK> listCategory = context.CATEGORYBOOKs.ToList(); 
                List<BOOK> listBook = context.BOOKS.ToList(); 
                FillCategoryCombobox(listCategory);
                BindGrid(listBook);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            try
            {
             

                CategoryContextDB db = new CategoryContextDB();
                List<BOOK> bookList = db.BOOKS.ToList();
                if (bookList.Any(s => s.BOOKID == txtID.Text))
                {
                    MessageBox.Show("Mã sách đã tồn tại. Vui lòng nhập một mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var newBook = new BOOK
                {
                    BOOKID = txtID.Text,
                    BOOKNAME = txtName.Text,
                    CATEGORYID = int.Parse(cmbCategory.SelectedValue.ToString()),
                    NAMXB = int.Parse(txtYear.Text)
                };


                //Thêm SV vào CSDL
                db.BOOKS.Add(newBook);
                db.SaveChanges();

                //Hiển thị lại danh sách sinh viên
                BindGrid(db.BOOKS.ToList());

                MessageBox.Show("Thêm sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm dữ liệu: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            try
            {
                

                CategoryContextDB db = new CategoryContextDB();
                List<BOOK> students = db.BOOKS.ToList();
                var student = students.FirstOrDefault(s => s.BOOKID == txtID.Text);
                if (student != null)
                {
                    if (students.Any(s => s.BOOKID == txtID.Text && s.BOOKID != student.BOOKID))
                    {
                        MessageBox.Show("Mã sách đã tồn tại. Vui lòng nhập một mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    student.BOOKNAME = txtName.Text;
                    student.CATEGORYID = int.Parse(cmbCategory.SelectedValue.ToString());
                    student.NAMXB = int.Parse(txtYear.Text);

                    //Cập nhật sinh viên lưu vào CSDL 
                    db.SaveChanges();

                    //Hiển thị lại danh sách sinh viên
                    BindGrid(db.BOOKS.ToList());

                    MessageBox.Show("Chỉnh sửa thông tin sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sách không tìm thấy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật dữ liệu: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            try
            {

                CategoryContextDB db = new CategoryContextDB();
                List<BOOK> bookList = db.BOOKS.ToList();

                //Tim kiếm SV có tồn tại trong CSDL hay không
                var book = bookList.FirstOrDefault(s => s.BOOKID == txtID.Text);

                if (book != null)
                {
                    //Xóa sinh viên khỏi CSDL
                    db.BOOKS.Remove(book);
                    db.SaveChanges();

                    BindGrid(db.BOOKS.ToList());

                    MessageBox.Show("Sách đã được xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Sách không tìm thấy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật dữ liệu: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
           "Bạn có chắc chắn muốn thoát ứng dụng?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            report.ShowDialog();
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtFind.Text.Trim();

                using (CategoryContextDB db = new CategoryContextDB())
                {
                    var filteredBooks = db.BOOKS
                        .Where(b => b.BOOKNAME.Contains(keyword) || b.BOOKID.Contains(keyword))
                        .ToList();

                    BindGrid(filteredBooks);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm sách: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
