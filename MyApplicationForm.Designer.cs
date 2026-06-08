namespace JobVacancyForm
{
    partial class MyApplicationForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.cmbJobVacancy = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCoverLetter = new System.Windows.Forms.RichTextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnSaveDraft = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.dvgApplications = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(87, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "MY APPLICATION";
            // 
            // txtFirstName
            // 
            this.txtFirstName.AutoSize = true;
            this.txtFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.Location = new System.Drawing.Point(64, 147);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(75, 16);
            this.txtFirstName.TabIndex = 1;
            this.txtFirstName.Text = "First Name:";
            // 
            // txtLastName
            // 
            this.txtLastName.AutoSize = true;
            this.txtLastName.Font = new System.Drawing.Font("Lucida Fax", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.Location = new System.Drawing.Point(64, 187);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(78, 16);
            this.txtLastName.TabIndex = 5;
            this.txtLastName.Text = "Last Name:";
            // 
            // txtEmail
            // 
            this.txtEmail.AutoSize = true;
            this.txtEmail.Font = new System.Drawing.Font("Lucida Fax", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(64, 227);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(46, 16);
            this.txtEmail.TabIndex = 6;
            this.txtEmail.Text = "Email:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(158, 147);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(138, 22);
            this.textBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(158, 187);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(138, 22);
            this.textBox2.TabIndex = 8;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(158, 221);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(138, 22);
            this.textBox3.TabIndex = 9;
            // 
            // cmbJobVacancy
            // 
            this.cmbJobVacancy.FormattingEnabled = true;
            this.cmbJobVacancy.Location = new System.Drawing.Point(158, 290);
            this.cmbJobVacancy.Name = "cmbJobVacancy";
            this.cmbJobVacancy.Size = new System.Drawing.Size(138, 24);
            this.cmbJobVacancy.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Fax", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(64, 350);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Cover Letter";
            // 
            // txtCoverLetter
            // 
            this.txtCoverLetter.Location = new System.Drawing.Point(67, 402);
            this.txtCoverLetter.Name = "txtCoverLetter";
            this.txtCoverLetter.Size = new System.Drawing.Size(229, 100);
            this.txtCoverLetter.TabIndex = 13;
            this.txtCoverLetter.Text = "";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Lucida Fax", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(64, 546);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(88, 16);
            this.lblStatus.TabIndex = 14;
            this.lblStatus.Text = "Status: Draft";
            // 
            // btnSaveDraft
            // 
            this.btnSaveDraft.Location = new System.Drawing.Point(67, 619);
            this.btnSaveDraft.Name = "btnSaveDraft";
            this.btnSaveDraft.Size = new System.Drawing.Size(126, 23);
            this.btnSaveDraft.TabIndex = 16;
            this.btnSaveDraft.Text = "Save Draft";
            this.btnSaveDraft.UseVisualStyleBackColor = true;
            this.btnSaveDraft.Click += new System.EventHandler(this.btnSaveDraft_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(218, 619);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(126, 23);
            this.btnEdit.TabIndex = 17;
            this.btnEdit.Text = "Edit Draft";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(368, 619);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(126, 23);
            this.btnSubmit.TabIndex = 18;
            this.btnSubmit.Text = "Submit Application";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // dvgApplications
            // 
            this.dvgApplications.AutoSize = true;
            this.dvgApplications.Font = new System.Drawing.Font("Lucida Fax", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dvgApplications.Location = new System.Drawing.Point(64, 701);
            this.dvgApplications.Name = "dvgApplications";
            this.dvgApplications.Size = new System.Drawing.Size(134, 16);
            this.dvgApplications.TabIndex = 20;
            this.dvgApplications.Text = "Application History";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(67, 759);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(792, 150);
            this.dataGridView1.TabIndex = 21;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Fax", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(64, 293);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 16);
            this.label2.TabIndex = 22;
            this.label2.Text = "Job Vacancy";

            // MyApplicationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(1010, 979);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dvgApplications);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnSaveDraft);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtCoverLetter);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbJobVacancy);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.label1);
            this.Name = "MyApplicationForm";
            this.Text = "MyApplicationForm";

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtFirstName;
        private System.Windows.Forms.Label txtLastName;
        private System.Windows.Forms.Label txtEmail;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ComboBox cmbJobVacancy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox txtCoverLetter;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnSaveDraft;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label dvgApplications;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
    }
}