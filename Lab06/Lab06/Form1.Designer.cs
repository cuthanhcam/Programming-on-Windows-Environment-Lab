namespace Lab06
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.chứcNăngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQuanLyKhoa = new System.Windows.Forms.ToolStripMenuItem();
            this.thốngKêToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblFaculty = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.dgvBook = new System.Windows.Forms.DataGridView();
            this.clnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnFaculty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entityCommand1 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.lblID = new System.Windows.Forms.Label();
            this.grbTTS = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBook)).BeginInit();
            this.grbTTS.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Bahnschrift", 12F);
            this.btnExit.Location = new System.Drawing.Point(820, 394);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(97, 36);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click_1);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(208, 192);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click_1);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(113, 192);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 30);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click_1);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(19, 192);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 30);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_1);
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(134, 142);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(149, 27);
            this.cmbCategory.TabIndex = 2;
            // 
            // txtYear
            // 
            this.txtYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtYear.Location = new System.Drawing.Point(134, 102);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(149, 27);
            this.txtYear.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chứcNăngToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(929, 27);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // chứcNăngToolStripMenuItem
            // 
            this.chứcNăngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuQuanLyKhoa,
            this.thốngKêToolStripMenuItem,
            this.toolStripSeparator1,
            this.thoátToolStripMenuItem});
            this.chứcNăngToolStripMenuItem.Font = new System.Drawing.Font("Bahnschrift", 12F);
            this.chứcNăngToolStripMenuItem.Name = "chứcNăngToolStripMenuItem";
            this.chứcNăngToolStripMenuItem.Size = new System.Drawing.Size(98, 23);
            this.chứcNăngToolStripMenuItem.Text = "Chức năng";
            // 
            // menuQuanLyKhoa
            // 
            this.menuQuanLyKhoa.Image = ((System.Drawing.Image)(resources.GetObject("menuQuanLyKhoa.Image")));
            this.menuQuanLyKhoa.Name = "menuQuanLyKhoa";
            this.menuQuanLyKhoa.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.menuQuanLyKhoa.Size = new System.Drawing.Size(199, 24);
            this.menuQuanLyKhoa.Text = "Quản lý khoa";
            // 
            // thốngKêToolStripMenuItem
            // 
            this.thốngKêToolStripMenuItem.Name = "thốngKêToolStripMenuItem";
            this.thốngKêToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.thốngKêToolStripMenuItem.Size = new System.Drawing.Size(199, 24);
            this.thốngKêToolStripMenuItem.Text = "Thống Kê";
            this.thốngKêToolStripMenuItem.Click += new System.EventHandler(this.thốngKêToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(196, 6);
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(199, 24);
            this.thoátToolStripMenuItem.Text = "Thoát";
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Location = new System.Drawing.Point(134, 67);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(149, 27);
            this.txtName.TabIndex = 1;
            // 
            // txtID
            // 
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID.Location = new System.Drawing.Point(134, 30);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(149, 27);
            this.txtID.TabIndex = 1;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(15, 142);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(74, 19);
            this.lblScore.TabIndex = 0;
            this.lblScore.Text = "Thể Loại:";
            // 
            // lblFaculty
            // 
            this.lblFaculty.AutoSize = true;
            this.lblFaculty.Location = new System.Drawing.Point(15, 105);
            this.lblFaculty.Name = "lblFaculty";
            this.lblFaculty.Size = new System.Drawing.Size(115, 19);
            this.lblFaculty.TabIndex = 0;
            this.lblFaculty.Text = "Năm Xuất Bản:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(15, 70);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(78, 19);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Tên Sách:";
            // 
            // dgvBook
            // 
            this.dgvBook.AllowUserToAddRows = false;
            this.dgvBook.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Bahnschrift", 9F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBook.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBook.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnID,
            this.clnName,
            this.clnFaculty,
            this.clnScore});
            this.dgvBook.Location = new System.Drawing.Point(345, 142);
            this.dgvBook.Name = "dgvBook";
            this.dgvBook.Size = new System.Drawing.Size(572, 233);
            this.dgvBook.TabIndex = 7;
            // 
            // clnID
            // 
            this.clnID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clnID.HeaderText = "Mã Sách";
            this.clnID.Name = "clnID";
            // 
            // clnName
            // 
            this.clnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clnName.HeaderText = "Tên Sách";
            this.clnName.Name = "clnName";
            // 
            // clnFaculty
            // 
            this.clnFaculty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clnFaculty.HeaderText = "Năm XB";
            this.clnFaculty.Name = "clnFaculty";
            // 
            // clnScore
            // 
            this.clnScore.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clnScore.HeaderText = "Thể Loại";
            this.clnScore.Name = "clnScore";
            // 
            // entityCommand1
            // 
            this.entityCommand1.CommandTimeout = 0;
            this.entityCommand1.CommandTree = null;
            this.entityCommand1.Connection = null;
            this.entityCommand1.EnablePlanCaching = true;
            this.entityCommand1.Transaction = null;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(15, 33);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(74, 19);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "Mã Sách:";
            // 
            // grbTTS
            // 
            this.grbTTS.Controls.Add(this.btnDelete);
            this.grbTTS.Controls.Add(this.btnEdit);
            this.grbTTS.Controls.Add(this.btnAdd);
            this.grbTTS.Controls.Add(this.cmbCategory);
            this.grbTTS.Controls.Add(this.txtYear);
            this.grbTTS.Controls.Add(this.txtName);
            this.grbTTS.Controls.Add(this.txtID);
            this.grbTTS.Controls.Add(this.lblScore);
            this.grbTTS.Controls.Add(this.lblFaculty);
            this.grbTTS.Controls.Add(this.lblName);
            this.grbTTS.Controls.Add(this.lblID);
            this.grbTTS.Font = new System.Drawing.Font("Bahnschrift", 12F);
            this.grbTTS.Location = new System.Drawing.Point(12, 134);
            this.grbTTS.Name = "grbTTS";
            this.grbTTS.Size = new System.Drawing.Size(309, 241);
            this.grbTTS.TabIndex = 6;
            this.grbTTS.TabStop = false;
            this.grbTTS.Text = "Thông Tin Sách";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 36F);
            this.label1.Location = new System.Drawing.Point(198, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(538, 58);
            this.label1.TabIndex = 5;
            this.label1.Text = "Quản Lý Thông Tin Sách";
            // 
            // txtFind
            // 
            this.txtFind.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFind.Font = new System.Drawing.Font("Bahnschrift", 12F);
            this.txtFind.Location = new System.Drawing.Point(762, 109);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(155, 27);
            this.txtFind.TabIndex = 10;
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(929, 453);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dgvBook);
            this.Controls.Add(this.grbTTS);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Quản Lý Thông Tin Sách";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBook)).EndInit();
            this.grbTTS.ResumeLayout(false);
            this.grbTTS.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem chứcNăngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuQuanLyKhoa;
        private System.Windows.Forms.ToolStripMenuItem thốngKêToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblFaculty;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.DataGridView dgvBook;
        private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand1;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.GroupBox grbTTS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnFaculty;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnScore;
        private System.Windows.Forms.TextBox txtFind;
    }
}

