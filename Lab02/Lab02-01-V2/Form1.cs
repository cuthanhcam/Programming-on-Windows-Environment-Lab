// 2280600285 - Cu Thanh Cam - https://github.com/cuthanhcam
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lab02_01_V2
{
    public partial class Form1 : Form
    {
        private List<string> operations = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void AddNumberAndOperator(string operatorSymbol)
        {
            if (string.IsNullOrWhiteSpace(txtInput.Text))
            {
                MessageBox.Show("Vui lòng nhập số trước khi chọn toán tử!");
                return;
            }

            operations.Add(txtInput.Text);
            operations.Add(operatorSymbol);

            txtInput.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddNumberAndOperator("+");
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            AddNumberAndOperator("-");
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            AddNumberAndOperator("*");
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            AddNumberAndOperator("/");
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInput.Text))
            {
                MessageBox.Show("Vui lòng nhập số trước khi nhấn '='!");
                return;
            }

            operations.Add(txtInput.Text);

            try
            {
                double result = CalculateResult();

                txtInput.Text = string.Join(" ", operations) + " = " + result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }

            operations.Clear();
        }

        private double CalculateResult()
        {
            List<string> tempOps = new List<string>(operations);

            if (tempOps.Count < 3 || tempOps.Count % 2 == 0)
                throw new InvalidOperationException("Phép tính không hợp lệ!");

            for (int i = 0; i < tempOps.Count; i++)
            {
                if (tempOps[i] == "*" || tempOps[i] == "/")
                {
                    double left = double.Parse(tempOps[i - 1]);
                    double right = double.Parse(tempOps[i + 1]);

                    if (tempOps[i] == "/" && right == 0)
                        throw new DivideByZeroException("Không thể chia cho 0!");

                    double intermediateResult = tempOps[i] == "*" ? left * right : left / right;

                    tempOps[i - 1] = intermediateResult.ToString();
                    tempOps.RemoveAt(i);
                    tempOps.RemoveAt(i);
                    i--;
                }
            }


            double result = double.Parse(tempOps[0]);
            for (int i = 1; i < tempOps.Count; i += 2)
            {
                string op = tempOps[i];
                double nextValue = double.Parse(tempOps[i + 1]);

                result = op == "+" ? result + nextValue : result - nextValue;
            }

            return result;
        }

        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '\b')
            {
                e.Handled = true;
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có chắc chắn muốn reset máy tính?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (res == DialogResult.Yes)
            {
                operations.Clear();
                txtInput.Clear();
            }
        }
    }
}
