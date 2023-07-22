namespace scansText
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btn_Pay = new System.Windows.Forms.Button();
            this.txt_IdStd = new System.Windows.Forms.TextBox();
            this.btn_Hitsory = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txt_NameStudent = new System.Windows.Forms.TextBox();
            this.btn_Cleardata = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Register = new System.Windows.Forms.Button();
            this.lb_valid1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(11, 71);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(480, 292);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // btn_Pay
            // 
            this.btn_Pay.BackColor = System.Drawing.Color.Teal;
            this.btn_Pay.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Pay.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Pay.Location = new System.Drawing.Point(212, 414);
            this.btn_Pay.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Pay.Name = "btn_Pay";
            this.btn_Pay.Size = new System.Drawing.Size(120, 45);
            this.btn_Pay.TabIndex = 1;
            this.btn_Pay.Text = "THAM GIA";
            this.btn_Pay.UseVisualStyleBackColor = false;
            this.btn_Pay.Click += new System.EventHandler(this.btn_Pay_Click);
            // 
            // txt_IdStd
            // 
            this.txt_IdStd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txt_IdStd.Enabled = false;
            this.txt_IdStd.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_IdStd.Location = new System.Drawing.Point(11, 414);
            this.txt_IdStd.Margin = new System.Windows.Forms.Padding(2);
            this.txt_IdStd.Name = "txt_IdStd";
            this.txt_IdStd.Size = new System.Drawing.Size(183, 39);
            this.txt_IdStd.TabIndex = 2;
            // 
            // btn_Hitsory
            // 
            this.btn_Hitsory.BackColor = System.Drawing.Color.Green;
            this.btn_Hitsory.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Hitsory.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Hitsory.Location = new System.Drawing.Point(925, 414);
            this.btn_Hitsory.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Hitsory.Name = "btn_Hitsory";
            this.btn_Hitsory.Size = new System.Drawing.Size(122, 47);
            this.btn_Hitsory.TabIndex = 3;
            this.btn_Hitsory.Text = "XEM ";
            this.btn_Hitsory.UseVisualStyleBackColor = false;
            this.btn_Hitsory.Click += new System.EventHandler(this.btn_Hitsory_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.DarkSeaGreen;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(506, 71);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(767, 292);
            this.dataGridView1.TabIndex = 4;
            // 
            // txt_NameStudent
            // 
            this.txt_NameStudent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txt_NameStudent.Enabled = false;
            this.txt_NameStudent.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NameStudent.Location = new System.Drawing.Point(664, 416);
            this.txt_NameStudent.Margin = new System.Windows.Forms.Padding(2);
            this.txt_NameStudent.Name = "txt_NameStudent";
            this.txt_NameStudent.Size = new System.Drawing.Size(246, 39);
            this.txt_NameStudent.TabIndex = 5;
            // 
            // btn_Cleardata
            // 
            this.btn_Cleardata.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cleardata.BackColor = System.Drawing.Color.Maroon;
            this.btn_Cleardata.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cleardata.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Cleardata.Location = new System.Drawing.Point(1169, 481);
            this.btn_Cleardata.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Cleardata.Name = "btn_Cleardata";
            this.btn_Cleardata.Size = new System.Drawing.Size(106, 31);
            this.btn_Cleardata.TabIndex = 6;
            this.btn_Cleardata.Text = "ĐẶT LẠI";
            this.btn_Cleardata.UseVisualStyleBackColor = false;
            this.btn_Cleardata.Click += new System.EventHandler(this.btn_Cleardata_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(81, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(326, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "QUÉT THẺ SINH VIÊN CỦA BẠN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(735, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(312, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "LỊCH SỬ GIAO DỊCH CỦA BẠN";
            // 
            // btn_Register
            // 
            this.btn_Register.BackColor = System.Drawing.Color.Navy;
            this.btn_Register.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Register.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_Register.Location = new System.Drawing.Point(212, 414);
            this.btn_Register.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Register.Name = "btn_Register";
            this.btn_Register.Size = new System.Drawing.Size(120, 45);
            this.btn_Register.TabIndex = 9;
            this.btn_Register.Text = "ĐĂNG KÝ";
            this.btn_Register.UseVisualStyleBackColor = false;
            this.btn_Register.Click += new System.EventHandler(this.btn_Register_Click);
            // 
            // lb_valid1
            // 
            this.lb_valid1.AutoSize = true;
            this.lb_valid1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_valid1.ForeColor = System.Drawing.Color.Navy;
            this.lb_valid1.Location = new System.Drawing.Point(12, 376);
            this.lb_valid1.Name = "lb_valid1";
            this.lb_valid1.Size = new System.Drawing.Size(232, 22);
            this.lb_valid1.TabIndex = 10;
            this.lb_valid1.Text = "Mã tài khoản chưa tồn tại !";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1286, 523);
            this.Controls.Add(this.lb_valid1);
            this.Controls.Add(this.btn_Register);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Cleardata);
            this.Controls.Add(this.txt_NameStudent);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_Hitsory);
            this.Controls.Add(this.txt_IdStd);
            this.Controls.Add(this.btn_Pay);
            this.Controls.Add(this.pictureBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button btn_Pay;
        private System.Windows.Forms.TextBox txt_IdStd;
        private System.Windows.Forms.Button btn_Hitsory;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txt_NameStudent;
        private System.Windows.Forms.Button btn_Cleardata;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Register;
        private System.Windows.Forms.Label lb_valid1;
    }
}

