using Lab06.Models;
using Microsoft.Reporting.WinForms;
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
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.ReportPath = "D:\\Lab\\Lab06\\Lab06\\Report1.rdlc";
            var layData = GetBooks();
            var datasourceReport = new ReportDataSource("DataSet1", layData);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(datasourceReport);

            this.reportViewer1.RefreshReport();
        }

        private DataTable GetBooks()
        {
            try
            {
        
                DataTable table = new DataTable();
                table.Columns.Add("BOOKID", typeof(string));
                table.Columns.Add("BOOKNAME", typeof(string));
                table.Columns.Add("NAMXB", typeof(int));
                table.Columns.Add("CATEGORYID", typeof(string)); 

       
                using (CategoryContextDB db = new CategoryContextDB())
                {
                    var books = db.BOOKS.Select(b => new
                    {
                        b.BOOKID,
                        b.BOOKNAME,
                        b.NAMXB,
                        CategoryID = b.CATEGORYBOOK != null ? b.CATEGORYBOOK.CATEGORYID.ToString() : "Không xác định" 
                    }).ToList();

        
                    foreach (var book in books)
                    {
                        table.Rows.Add(book.BOOKID, book.BOOKNAME, book.NAMXB, book.CategoryID);
                    }
                }
                return table;
            }
            catch (Exception ex)
            {
         
                MessageBox.Show($"Lỗi khi lấy dữ liệu sách: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
