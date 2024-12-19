using Lab04_04.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab04_04
{
    public partial class frmProductOrder : Form
    {
        private ProductOrderContext _dbContext = new ProductOrderContext();
        public frmProductOrder()
        {
            InitializeComponent();
        }
        private void ConfigureDataGridView()
        {
            // Đặt chế độ không tự động tạo cột
            dataGridViewProductOrder.AutoGenerateColumns = false;
            dataGridViewProductOrder.Columns.Clear();

            // Thêm cột Index
            var indexColumn = new DataGridViewTextBoxColumn
            {
                Name = "Index",
                HeaderText = "Index",
                Width = 50,
                ReadOnly = true
            };
            dataGridViewProductOrder.Columns.Add(indexColumn);

            // Thêm cột Invoice Number
            var invoiceNumberColumn = new DataGridViewTextBoxColumn
            {
                Name = "InvoiceNumber",
                HeaderText = "Invoice Number",
                Width = 150,
                ReadOnly = true
            };
            dataGridViewProductOrder.Columns.Add(invoiceNumberColumn);

            // Thêm cột Date Order
            var dateOrderColumn = new DataGridViewTextBoxColumn
            {
                Name = "DateOrder",
                HeaderText = "Date Order",
                Width = 150,
                ReadOnly = true
            };
            dataGridViewProductOrder.Columns.Add(dateOrderColumn);

            // Thêm cột Date Received
            var dateReceivedColumn = new DataGridViewTextBoxColumn
            {
                Name = "DateReceived",
                HeaderText = "Date Received",
                Width = 150,
                ReadOnly = true
            };
            dataGridViewProductOrder.Columns.Add(dateReceivedColumn);

            // Thêm cột Total Amount
            var totalAmountColumn = new DataGridViewTextBoxColumn
            {
                Name = "TotalAmount",
                HeaderText = "Total Amount",
                Width = 150,
                ReadOnly = true
            };
            dataGridViewProductOrder.Columns.Add(totalAmountColumn);

            // Tùy chỉnh giao diện
            dataGridViewProductOrder.AllowUserToResizeColumns = false;
            dataGridViewProductOrder.AllowUserToResizeRows = false;
            dataGridViewProductOrder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        }
        private void LoadInvoicesByDateRange(DateTime startDate, DateTime endDate)
        {
            try
            {
                // Truy vấn danh sách hóa đơn trong khoảng thời gian
                var invoices = _dbContext.Invoices
                    .Where(i => i.DeliveryDate >= startDate && i.DeliveryDate <= endDate)
                    .ToList() // Lấy dữ liệu từ cơ sở dữ liệu
                    .Select((i, index) => new
                    {
                        Index = index + 1,
                        InvoiceNumber = i.InvoiceNo,
                        DateOrder = i.OrderDate.ToString("yyyy-MM-dd"), // Chuyển đổi sau khi lấy dữ liệu
                        DateReceived = i.DeliveryDate.ToString("yyyy-MM-dd"),
                        TotalAmount = _dbContext.Orders
                            .Where(o => o.InvoiceNo == i.InvoiceNo)
                            .Sum(o => (decimal?)o.Price * o.Quantity) ?? 0
                    })
                    .ToList();

                // Hiển thị dữ liệu
                dataGridViewProductOrder.DataSource = invoices;
                txtTotal.Text = $"Total: {invoices.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmProductOrder_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView();
            dateTimePickerDateOrder.Value = DateTime.Now;
            dateTimePickerDateReceived.Value = DateTime.Now;
            LoadInvoicesByDateRange(DateTime.Now.Date, DateTime.Now.Date);
        }

        private void checkBoxViewAllInMonth_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBoxViewAllInMonth.Checked)
                {
                    DateTime firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                    LoadInvoicesByDateRange(firstDayOfMonth, lastDayOfMonth);
                }
                else
                {
                    LoadInvoicesByDateRange(dateTimePickerDateOrder.Value.Date, dateTimePickerDateReceived.Value.Date);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!checkBoxViewAllInMonth.Checked)
                {
                    LoadInvoicesByDateRange(dateTimePickerDateOrder.Value.Date, dateTimePickerDateReceived.Value.Date);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing date range: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
