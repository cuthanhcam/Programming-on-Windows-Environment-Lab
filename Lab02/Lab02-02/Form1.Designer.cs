namespace Lab02_02
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
            this.lblStudentInformationManagement = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblFaculty = new System.Windows.Forms.Label();
            this.lblAverageScore = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblStudentID = new System.Windows.Forms.Label();
            this.lblTotalMale = new System.Windows.Forms.Label();
            this.lblTotalFemale = new System.Windows.Forms.Label();
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtAverageScore = new System.Windows.Forms.TextBox();
            this.optMale = new System.Windows.Forms.RadioButton();
            this.optFemale = new System.Windows.Forms.RadioButton();
            this.cmbFaculty = new System.Windows.Forms.ComboBox();
            this.btnInsertUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvStudent = new System.Windows.Forms.DataGridView();
            this.txtTotalMale = new System.Windows.Forms.TextBox();
            this.txtTotalFemale = new System.Windows.Forms.TextBox();
            this.StudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AverageScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Faculty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStudentInformationManagement
            // 
            this.lblStudentInformationManagement.AutoSize = true;
            this.lblStudentInformationManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudentInformationManagement.Location = new System.Drawing.Point(227, 23);
            this.lblStudentInformationManagement.Name = "lblStudentInformationManagement";
            this.lblStudentInformationManagement.Size = new System.Drawing.Size(536, 42);
            this.lblStudentInformationManagement.TabIndex = 0;
            this.lblStudentInformationManagement.Text = "Quản Lý Thông Tin Sinh Viên";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnInsertUpdate);
            this.groupBox1.Controls.Add(this.cmbFaculty);
            this.groupBox1.Controls.Add(this.optFemale);
            this.groupBox1.Controls.Add(this.optMale);
            this.groupBox1.Controls.Add(this.txtAverageScore);
            this.groupBox1.Controls.Add(this.txtFullName);
            this.groupBox1.Controls.Add(this.txtStudentID);
            this.groupBox1.Controls.Add(this.lblFaculty);
            this.groupBox1.Controls.Add(this.lblAverageScore);
            this.groupBox1.Controls.Add(this.lblGender);
            this.groupBox1.Controls.Add(this.lblFullName);
            this.groupBox1.Controls.Add(this.lblStudentID);
            this.groupBox1.Location = new System.Drawing.Point(29, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 305);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Sinh Viên";
            // 
            // lblFaculty
            // 
            this.lblFaculty.AutoSize = true;
            this.lblFaculty.Location = new System.Drawing.Point(15, 209);
            this.lblFaculty.Name = "lblFaculty";
            this.lblFaculty.Size = new System.Drawing.Size(95, 16);
            this.lblFaculty.TabIndex = 4;
            this.lblFaculty.Text = "Chuyên Ngành";
            // 
            // lblAverageScore
            // 
            this.lblAverageScore.AutoSize = true;
            this.lblAverageScore.Location = new System.Drawing.Point(15, 165);
            this.lblAverageScore.Name = "lblAverageScore";
            this.lblAverageScore.Size = new System.Drawing.Size(105, 16);
            this.lblAverageScore.TabIndex = 3;
            this.lblAverageScore.Text = "Điểm Trung Bình";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(15, 120);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(60, 16);
            this.lblGender.TabIndex = 2;
            this.lblGender.Text = "Giới Tính";
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(15, 81);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(52, 16);
            this.lblFullName.TabIndex = 1;
            this.lblFullName.Text = "Họ Tên";
            // 
            // lblStudentID
            // 
            this.lblStudentID.AutoSize = true;
            this.lblStudentID.Location = new System.Drawing.Point(15, 41);
            this.lblStudentID.Name = "lblStudentID";
            this.lblStudentID.Size = new System.Drawing.Size(85, 16);
            this.lblStudentID.TabIndex = 0;
            this.lblStudentID.Text = "Mã Sinh Viên";
            // 
            // lblTotalMale
            // 
            this.lblTotalMale.AutoSize = true;
            this.lblTotalMale.Location = new System.Drawing.Point(671, 421);
            this.lblTotalMale.Name = "lblTotalMale";
            this.lblTotalMale.Size = new System.Drawing.Size(92, 16);
            this.lblTotalMale.TabIndex = 2;
            this.lblTotalMale.Text = "Tổng SV Nam";
            // 
            // lblTotalFemale
            // 
            this.lblTotalFemale.AutoSize = true;
            this.lblTotalFemale.Location = new System.Drawing.Point(840, 421);
            this.lblTotalFemale.Name = "lblTotalFemale";
            this.lblTotalFemale.Size = new System.Drawing.Size(80, 16);
            this.lblTotalFemale.TabIndex = 3;
            this.lblTotalFemale.Text = "Tổng SV Nữ";
            // 
            // txtStudentID
            // 
            this.txtStudentID.Location = new System.Drawing.Point(138, 41);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(209, 22);
            this.txtStudentID.TabIndex = 5;
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(138, 81);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(209, 22);
            this.txtFullName.TabIndex = 6;
            // 
            // txtAverageScore
            // 
            this.txtAverageScore.Location = new System.Drawing.Point(138, 162);
            this.txtAverageScore.Name = "txtAverageScore";
            this.txtAverageScore.Size = new System.Drawing.Size(209, 22);
            this.txtAverageScore.TabIndex = 7;
            // 
            // optMale
            // 
            this.optMale.AutoSize = true;
            this.optMale.Location = new System.Drawing.Point(138, 120);
            this.optMale.Name = "optMale";
            this.optMale.Size = new System.Drawing.Size(57, 20);
            this.optMale.TabIndex = 8;
            this.optMale.TabStop = true;
            this.optMale.Text = "Nam";
            this.optMale.UseVisualStyleBackColor = true;
            // 
            // optFemale
            // 
            this.optFemale.AutoSize = true;
            this.optFemale.Location = new System.Drawing.Point(225, 118);
            this.optFemale.Name = "optFemale";
            this.optFemale.Size = new System.Drawing.Size(45, 20);
            this.optFemale.TabIndex = 9;
            this.optFemale.TabStop = true;
            this.optFemale.Text = "Nữ";
            this.optFemale.UseVisualStyleBackColor = true;
            // 
            // cmbFaculty
            // 
            this.cmbFaculty.FormattingEnabled = true;
            this.cmbFaculty.Location = new System.Drawing.Point(138, 206);
            this.cmbFaculty.Name = "cmbFaculty";
            this.cmbFaculty.Size = new System.Drawing.Size(209, 24);
            this.cmbFaculty.TabIndex = 10;
            // 
            // btnInsertUpdate
            // 
            this.btnInsertUpdate.Location = new System.Drawing.Point(138, 253);
            this.btnInsertUpdate.Name = "btnInsertUpdate";
            this.btnInsertUpdate.Size = new System.Drawing.Size(98, 23);
            this.btnInsertUpdate.TabIndex = 11;
            this.btnInsertUpdate.Text = "Thêm/Sửa";
            this.btnInsertUpdate.UseVisualStyleBackColor = true;
            this.btnInsertUpdate.Click += new System.EventHandler(this.btnInsertUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(272, 253);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgvStudent
            // 
            this.dgvStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StudentID,
            this.FullName,
            this.Gender,
            this.AverageScore,
            this.Faculty});
            this.dgvStudent.Location = new System.Drawing.Point(432, 95);
            this.dgvStudent.Name = "dgvStudent";
            this.dgvStudent.RowHeadersWidth = 51;
            this.dgvStudent.RowTemplate.Height = 24;
            this.dgvStudent.Size = new System.Drawing.Size(550, 305);
            this.dgvStudent.TabIndex = 4;
            this.dgvStudent.SelectionChanged += new System.EventHandler(this.dgvStudent_SelectionChanged);
            // 
            // txtTotalMale
            // 
            this.txtTotalMale.Location = new System.Drawing.Point(769, 418);
            this.txtTotalMale.Name = "txtTotalMale";
            this.txtTotalMale.Size = new System.Drawing.Size(65, 22);
            this.txtTotalMale.TabIndex = 5;
            // 
            // txtTotalFemale
            // 
            this.txtTotalFemale.Location = new System.Drawing.Point(927, 418);
            this.txtTotalFemale.Name = "txtTotalFemale";
            this.txtTotalFemale.Size = new System.Drawing.Size(79, 22);
            this.txtTotalFemale.TabIndex = 6;
            // 
            // StudentID
            // 
            this.StudentID.HeaderText = "MSSV";
            this.StudentID.MinimumWidth = 6;
            this.StudentID.Name = "StudentID";
            // 
            // FullName
            // 
            this.FullName.HeaderText = "Họ Tên";
            this.FullName.MinimumWidth = 6;
            this.FullName.Name = "FullName";
            this.FullName.Width = 150;
            // 
            // Gender
            // 
            this.Gender.HeaderText = "Giới tính";
            this.Gender.MinimumWidth = 6;
            this.Gender.Name = "Gender";
            // 
            // AverageScore
            // 
            this.AverageScore.HeaderText = "Điểm trung bình";
            this.AverageScore.MinimumWidth = 6;
            this.AverageScore.Name = "AverageScore";
            // 
            // Faculty
            // 
            this.Faculty.HeaderText = "Khoa";
            this.Faculty.MinimumWidth = 6;
            this.Faculty.Name = "Faculty";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 472);
            this.Controls.Add(this.txtTotalFemale);
            this.Controls.Add(this.txtTotalMale);
            this.Controls.Add(this.dgvStudent);
            this.Controls.Add(this.lblTotalFemale);
            this.Controls.Add(this.lblTotalMale);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblStudentInformationManagement);
            this.Name = "Form1";
            this.Text = "Lab02-02 - Quản Lý Thông Tin Sinh Viên";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStudentInformationManagement;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblFaculty;
        private System.Windows.Forms.Label lblAverageScore;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.Label lblTotalMale;
        private System.Windows.Forms.Label lblTotalFemale;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnInsertUpdate;
        private System.Windows.Forms.ComboBox cmbFaculty;
        private System.Windows.Forms.RadioButton optFemale;
        private System.Windows.Forms.RadioButton optMale;
        private System.Windows.Forms.TextBox txtAverageScore;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.DataGridView dgvStudent;
        private System.Windows.Forms.TextBox txtTotalMale;
        private System.Windows.Forms.TextBox txtTotalFemale;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn AverageScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn Faculty;
    }
}

