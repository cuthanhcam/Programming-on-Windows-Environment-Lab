namespace Lab04_04
{
    partial class frmProductOrder
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerDateReceived = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDateOrder = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxViewAllInMonth = new System.Windows.Forms.CheckBox();
            this.dataGridViewProductOrder = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateTimePickerDateReceived);
            this.groupBox1.Controls.Add(this.dateTimePickerDateOrder);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.checkBoxViewAllInMonth);
            this.groupBox1.Location = new System.Drawing.Point(17, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(850, 132);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Product Information";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(464, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "~";
            // 
            // dateTimePickerDateReceived
            // 
            this.dateTimePickerDateReceived.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDateReceived.Location = new System.Drawing.Point(508, 75);
            this.dateTimePickerDateReceived.Name = "dateTimePickerDateReceived";
            this.dateTimePickerDateReceived.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerDateReceived.TabIndex = 3;
            this.dateTimePickerDateReceived.UseWaitCursor = true;
            this.dateTimePickerDateReceived.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // dateTimePickerDateOrder
            // 
            this.dateTimePickerDateOrder.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDateOrder.Location = new System.Drawing.Point(232, 75);
            this.dateTimePickerDateOrder.Name = "dateTimePickerDateOrder";
            this.dateTimePickerDateOrder.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerDateOrder.TabIndex = 2;
            this.dateTimePickerDateOrder.UseWaitCursor = true;
            this.dateTimePickerDateOrder.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Delivery Time:";
            // 
            // checkBoxViewAllInMonth
            // 
            this.checkBoxViewAllInMonth.AutoSize = true;
            this.checkBoxViewAllInMonth.Location = new System.Drawing.Point(61, 31);
            this.checkBoxViewAllInMonth.Name = "checkBoxViewAllInMonth";
            this.checkBoxViewAllInMonth.Size = new System.Drawing.Size(127, 20);
            this.checkBoxViewAllInMonth.TabIndex = 0;
            this.checkBoxViewAllInMonth.Text = "View all in month";
            this.checkBoxViewAllInMonth.UseVisualStyleBackColor = true;
            this.checkBoxViewAllInMonth.CheckedChanged += new System.EventHandler(this.checkBoxViewAllInMonth_CheckedChanged);
            // 
            // dataGridViewProductOrder
            // 
            this.dataGridViewProductOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProductOrder.Location = new System.Drawing.Point(17, 162);
            this.dataGridViewProductOrder.Name = "dataGridViewProductOrder";
            this.dataGridViewProductOrder.RowHeadersWidth = 51;
            this.dataGridViewProductOrder.RowTemplate.Height = 24;
            this.dataGridViewProductOrder.Size = new System.Drawing.Size(850, 340);
            this.dataGridViewProductOrder.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(720, 522);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Total:";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(767, 519);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(100, 22);
            this.txtTotal.TabIndex = 7;
            // 
            // frmProductOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 553);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridViewProductOrder);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmProductOrder";
            this.Text = "Product and Order Management";
            this.Load += new System.EventHandler(this.frmProductOrder_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxViewAllInMonth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateReceived;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewProductOrder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTotal;
    }
}

