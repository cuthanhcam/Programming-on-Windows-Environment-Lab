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
        private void LoadInvoicesByDateRange(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                MessageBox.Show("Start date cannot be greater than end date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var invoices = _dbContext.Invoices
                    .Where(i => i.DeliveryDate >= startDate && i.DeliveryDate <= endDate)
                    .ToList()
                    .Select((i, index) => new
                    {
                        Index = index + 1,
                        InvoiceNumber = i.InvoiceNo,
                        DateOrder = i.OrderDate.ToString("yyyy-MM-dd"),
                        DateReceived = i.DeliveryDate.ToString("yyyy-MM-dd"),
                        TotalAmount = _dbContext.Orders
                            .Where(o => o.InvoiceNo == i.InvoiceNo)
                            .Sum(o => (decimal?)o.Price * o.Quantity) ?? 0
                    })
                    .ToList();

                // Sử dụng AutoGenerateColumns để tạo cột tự động
                dataGridViewProductOrder.AutoGenerateColumns = true;
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
            // Thiết lập giá trị mặc định cho DateTimePicker
            dateTimePickerDateOrder.Value = DateTime.Now;
            dateTimePickerDateReceived.Value = DateTime.Now;

            // Tải dữ liệu mặc định theo ngày hiện tại
            LoadInvoicesByDateRange(DateTime.Now.Date, DateTime.Now.Date);
        }

        private void checkBoxViewAllInMonth_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBoxViewAllInMonth.Checked)
                {
                    // Lọc dữ liệu theo tháng hiện tại
                    DateTime firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                    LoadInvoicesByDateRange(firstDayOfMonth, lastDayOfMonth);
                }
                else
                {
                    // Lọc dữ liệu theo khoảng thời gian của DateTimePicker
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
                    // Lọc dữ liệu theo khoảng thời gian của DateTimePicker
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
