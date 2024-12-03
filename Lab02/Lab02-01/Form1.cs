using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab02_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                float number1 = float.Parse(txtNumber1.Text);
                float number2 = float.Parse(txtNumber2.Text);
                float answer = number1 + number2;
                txtAnswer.Text = answer.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            try
            {
                float number1 = float.Parse(txtNumber1.Text);
                float number2 = float.Parse(txtNumber2.Text);
                float answer = number1 - number2;
                txtAnswer.Text = answer.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            try
            {
                float number1 = float.Parse(txtNumber1.Text);
                float number2 = float.Parse(txtNumber2.Text);
                float answer = number1 * number2;
                txtAnswer.Text = answer.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            try
            {
                float number1 = float.Parse(txtNumber1.Text);
                float number2 = float.Parse(txtNumber2.Text);
                if (number2 == 0)
                {
                    MessageBox.Show("Không thể chia cho 0!", "Lỗi toán học", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                float answer = number1 / number2;
                txtAnswer.Text = answer.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có muốn thoát", "Câu hỏi thoát",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
