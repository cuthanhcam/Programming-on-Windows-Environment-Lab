namespace MemoryGame
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.btnReplay = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.dataGridViewTop5 = new System.Windows.Forms.DataGridView();
            this.lblTimer = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTop5)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 5;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 6;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(504, 561);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // btnReplay
            // 
            this.btnReplay.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.btnReplay.Location = new System.Drawing.Point(523, 11);
            this.btnReplay.Margin = new System.Windows.Forms.Padding(2);
            this.btnReplay.Name = "btnReplay";
            this.btnReplay.Size = new System.Drawing.Size(120, 50);
            this.btnReplay.TabIndex = 2;
            this.btnReplay.Text = "Play Again";
            this.btnReplay.UseVisualStyleBackColor = true;
            this.btnReplay.Click += new System.EventHandler(this.btnReplay_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLogout.BackgroundImage")));
            this.btnLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogout.Location = new System.Drawing.Point(721, 12);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(52, 52);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // dataGridViewTop5
            // 
            this.dataGridViewTop5.AllowUserToAddRows = false;
            this.dataGridViewTop5.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewTop5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTop5.GridColor = System.Drawing.Color.White;
            this.dataGridViewTop5.Location = new System.Drawing.Point(523, 275);
            this.dataGridViewTop5.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewTop5.Name = "dataGridViewTop5";
            this.dataGridViewTop5.ReadOnly = true;
            this.dataGridViewTop5.RowHeadersWidth = 51;
            this.dataGridViewTop5.RowTemplate.Height = 24;
            this.dataGridViewTop5.Size = new System.Drawing.Size(250, 275);
            this.dataGridViewTop5.TabIndex = 3;
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.lblTimer.Location = new System.Drawing.Point(519, 226);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(57, 22);
            this.lblTimer.TabIndex = 4;
            this.lblTimer.Text = "Timer";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.dataGridViewTop5);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnReplay);
            this.Controls.Add(this.tableLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Memory Game";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTop5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button btnReplay;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.DataGridView dataGridViewTop5;
        private System.Windows.Forms.Label lblTimer;
    }
}