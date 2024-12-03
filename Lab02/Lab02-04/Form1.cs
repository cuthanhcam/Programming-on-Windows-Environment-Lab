// 2280600285 - Cu Thanh Cam - https://github.com/cuthanhcam
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab02_04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddOrUpdate_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu nhập liệu
            if (string.IsNullOrWhiteSpace(txtAccountNumber.Text) ||
                string.IsNullOrWhiteSpace(txtCustomerName.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) ||
                string.IsNullOrWhiteSpace(txtBalance.Text) ||
                !decimal.TryParse(txtBalance.Text, out decimal balance) || balance < 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin hợp lệ!");
                return;
            }

            string accountNumber = txtAccountNumber.Text;
            string customerName = txtCustomerName.Text;
            string address = txtAddress.Text;

            // Kiểm tra tài khoản đã tồn tại
            ListViewItem existingItem = lvAccounts.Items
                .Cast<ListViewItem>()
                .FirstOrDefault(item => item.SubItems[1].Text == accountNumber);

            if (existingItem == null)
            {
                // Thêm mới tài khoản
                ListViewItem newItem = new ListViewItem((lvAccounts.Items.Count + 1).ToString());
                newItem.SubItems.Add(accountNumber);
                newItem.SubItems.Add(customerName);
                newItem.SubItems.Add(address);
                newItem.SubItems.Add(balance.ToString("N0"));
                lvAccounts.Items.Add(newItem);
                MessageBox.Show("Thêm mới dữ liệu thành công!");
            }
            else
            {
                // Cập nhật tài khoản
                existingItem.SubItems[2].Text = customerName;
                existingItem.SubItems[3].Text = address;
                existingItem.SubItems[4].Text = balance.ToString("N0");
                MessageBox.Show("Cập nhật dữ liệu thành công!");
            }

            // Cập nhật lại STT và tổng tiền
            UpdateListViewIndex();
            UpdateTotalAmount();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAccountNumber.Text))
            {
                MessageBox.Show("Vui lòng nhập số tài khoản cần xóa!");
                return;
            }

            string accountNumber = txtAccountNumber.Text;

            // Tìm kiếm tài khoản
            ListViewItem existingItem = lvAccounts.Items
                .Cast<ListViewItem>()
                .FirstOrDefault(item => item.SubItems[1].Text == accountNumber);

            if (existingItem == null)
            {
                MessageBox.Show("Không tìm thấy số tài khoản cần xóa!");
                return;
            }

            // Xác nhận xóa
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa tài khoản này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                lvAccounts.Items.Remove(existingItem);
                MessageBox.Show("Xóa tài khoản thành công!");
                UpdateListViewIndex(); // Cập nhật lại STT
                UpdateTotalAmount(); // Cập nhật tổng tiền
            }
        }

        // Cập nhật STT
        private void UpdateListViewIndex()
        {
            for (int i = 0; i < lvAccounts.Items.Count; i++)
            {
                lvAccounts.Items[i].Text = (i + 1).ToString(); // Gán lại STT
            }
        }

        // Cập nhật tổng tiền
        private void UpdateTotalAmount()
        {
            decimal total = 0;
            foreach (ListViewItem item in lvAccounts.Items)
            {
                total += decimal.Parse(item.SubItems[4].Text.Replace(",", ""));
            }
            txtTotalBalance.Text = "Tổng tiền: " + total.ToString("N0") + " VNĐ";
        }

        private void lvAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvAccounts.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvAccounts.SelectedItems[0];
                txtAccountNumber.Text = selectedItem.SubItems[1].Text;
                txtCustomerName.Text = selectedItem.SubItems[2].Text;
                txtAddress.Text = selectedItem.SubItems[3].Text;
                txtBalance.Text = selectedItem.SubItems[4].Text;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
