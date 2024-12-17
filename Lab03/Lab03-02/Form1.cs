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

namespace Lab03_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Load danh sách Font vào comboBoxFont
            foreach (FontFamily font in FontFamily.Families)
            {
                comboBoxFont.Items.Add(font.Name);
            }
            comboBoxFont.SelectedItem = "Tahoma"; // Giá trị mặc định

            // Load danh sách Size vào comboBoxSize
            int[] fontSizes = { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (int size in fontSizes)
            {
                comboBoxSize.Items.Add(size);
            }
            comboBoxSize.SelectedItem = 14; // Giá trị mặc định

            // Đặt font mặc định cho RichTextBox
            richTextBox1.Font = new Font("Tahoma", 14);
        }

        private void NewFile()
        {
            richTextBox1.Clear();
            richTextBox1.Font = new Font("Tahoma", 14);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFile();
        }

        private void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            NewFile();
        }
        private void OpenFile()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Text Files (*.txt)|*.txt|Rich Text Format (*.rtf)|*.rtf";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(dlg.FileName).ToLower() == ".rtf")
                    richTextBox1.LoadFile(dlg.FileName, RichTextBoxStreamType.RichText);
                else
                    richTextBox1.LoadFile(dlg.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void SaveFile()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Rich Text Format (*.rtf)|*.rtf";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SaveFile(dlg.FileName, RichTextBoxStreamType.RichText);
                MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void formatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.Font = richTextBox1.SelectionFont;

            if (fontDlg.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fontDlg.Font;
            }
        }

        private void BoldText()
        {
            Font currentFont = richTextBox1.SelectionFont;
            FontStyle newStyle = currentFont.Bold ? FontStyle.Regular : FontStyle.Bold;
            richTextBox1.SelectionFont = new Font(currentFont, newStyle);
        }
        private void ItalicText()
        {
            Font currentFont = richTextBox1.SelectionFont;
            FontStyle newStyle = currentFont.Italic ? FontStyle.Regular : FontStyle.Italic;
            richTextBox1.SelectionFont = new Font(currentFont, newStyle);
        }
        private void UnderlineText()
        {
            Font currentFont = richTextBox1.SelectionFont;
            FontStyle newStyle = currentFont.Underline ? FontStyle.Regular : FontStyle.Underline;
            richTextBox1.SelectionFont = new Font(currentFont, newStyle);
        }

        private void toolStripButtonBold_Click(object sender, EventArgs e)
        {
            BoldText();
        }

        private void toolStripButtonItalic_Click(object sender, EventArgs e)
        {
            ItalicText();
        }

        private void toolStripButtonUnderline_Click(object sender, EventArgs e)
        {
            UnderlineText();
        }

        private void comboBoxFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fontName = comboBoxFont.SelectedItem.ToString();
            richTextBox1.SelectionFont = new Font(fontName, richTextBox1.SelectionFont.Size);
        }

        private void comboBoxSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            float fontSize = float.Parse(comboBoxSize.SelectedItem.ToString());
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, fontSize);
        }
    }
}
