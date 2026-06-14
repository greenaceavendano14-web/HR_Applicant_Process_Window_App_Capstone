namespace ApplicantSystem
{
    partial class JobVacancyForm
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
            cmbStatus = new ComboBox();
            label1 = new Label();
            txtJobTitle = new TextBox();
            dataGridView1 = new DataGridView();
            txtDescription = new TextBox();
            txtRequirements = new TextBox();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            ADD = new Button();
            CLEAR = new Button();
            DELETE = new Button();
            UPDATE = new Button();
            lblDepartment = new Label();
            cmbDepartment = new ComboBox();
            lblEmploymentType = new Label();
            cmbEmploymentType = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Open", "Close", "On Hold" });
            cmbStatus.Location = new Point(509, 329);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(108, 23);
            cmbStatus.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(90, 185);
            label1.Name = "label1";
            label1.Size = new Size(75, 21);
            label1.TabIndex = 1;
            label1.Text = "Job Title";
            // 
            // txtJobTitle
            // 
            txtJobTitle.Location = new Point(186, 185);
            txtJobTitle.Multiline = true;
            txtJobTitle.Name = "txtJobTitle";
            txtJobTitle.Size = new Size(240, 34);
            txtJobTitle.TabIndex = 6;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.Thistle;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(171, 575);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 24;
            dataGridView1.Size = new Size(935, 177);
            dataGridView1.TabIndex = 9;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(214, 307);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(240, 106);
            txtDescription.TabIndex = 10;
            // 
            // txtRequirements
            // 
            txtRequirements.Location = new Point(866, 185);
            txtRequirements.Multiline = true;
            txtRequirements.Name = "txtRequirements";
            txtRequirements.Size = new Size(240, 106);
            txtRequirements.TabIndex = 11;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Thistle;
            panel1.Location = new Point(186, -7);
            panel1.Name = "panel1";
            panel1.Size = new Size(996, 121);
            panel1.TabIndex = 12;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(-8, -7);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(193, 121);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(533, 305);
            label5.Name = "label5";
            label5.Size = new Size(57, 21);
            label5.TabIndex = 14;
            label5.Text = "Status";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(715, 185);
            label6.Name = "label6";
            label6.Size = new Size(116, 21);
            label6.TabIndex = 15;
            label6.Text = "Requirements";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(90, 309);
            label7.Name = "label7";
            label7.Size = new Size(98, 21);
            label7.TabIndex = 16;
            label7.Text = "Description";
            // 
            // ADD
            // 
            ADD.Location = new Point(320, 484);
            ADD.Name = "ADD";
            ADD.Size = new Size(133, 46);
            ADD.TabIndex = 17;
            ADD.Text = "ADD";
            ADD.UseVisualStyleBackColor = true;
            ADD.Click += ADD_Click;
            // 
            // CLEAR
            // 
            CLEAR.Location = new Point(866, 484);
            CLEAR.Name = "CLEAR";
            CLEAR.Size = new Size(133, 46);
            CLEAR.TabIndex = 18;
            CLEAR.Text = "CLEAR";
            CLEAR.UseVisualStyleBackColor = true;
            CLEAR.Click += CLEAR_Click;
            // 
            // DELETE
            // 
            DELETE.Location = new Point(686, 484);
            DELETE.Name = "DELETE";
            DELETE.Size = new Size(133, 46);
            DELETE.TabIndex = 19;
            DELETE.Text = "DELETE";
            DELETE.UseVisualStyleBackColor = true;
            DELETE.Click += DELETE_Click;
            // 
            // UPDATE
            // 
            UPDATE.Location = new Point(509, 484);
            UPDATE.Name = "UPDATE";
            UPDATE.Size = new Size(133, 46);
            UPDATE.TabIndex = 20;
            UPDATE.Text = "UPDATE";
            UPDATE.UseVisualStyleBackColor = true;
            UPDATE.Click += UPDATE_Click;
            // 
            // lblDepartment
            // 
            lblDepartment.AutoSize = true;
            lblDepartment.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDepartment.Location = new Point(698, 305);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(102, 21);
            lblDepartment.TabIndex = 22;
            lblDepartment.Text = "Department";
            // 
            // cmbDepartment
            // 
            cmbDepartment.FormattingEnabled = true;
            cmbDepartment.Items.AddRange(new object[] { "Open", "Close", "On Hold" });
            cmbDepartment.Location = new Point(698, 329);
            cmbDepartment.Name = "cmbDepartment";
            cmbDepartment.Size = new Size(108, 23);
            cmbDepartment.TabIndex = 21;
            // 
            // lblEmploymentType
            // 
            lblEmploymentType.AutoSize = true;
            lblEmploymentType.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmploymentType.Location = new Point(875, 305);
            lblEmploymentType.Name = "lblEmploymentType";
            lblEmploymentType.Size = new Size(148, 21);
            lblEmploymentType.TabIndex = 24;
            lblEmploymentType.Text = "Employment Type";
            // 
            // cmbEmploymentType
            // 
            cmbEmploymentType.FormattingEnabled = true;
            cmbEmploymentType.Items.AddRange(new object[] { "Open", "Close", "On Hold" });
            cmbEmploymentType.Location = new Point(891, 329);
            cmbEmploymentType.Name = "cmbEmploymentType";
            cmbEmploymentType.Size = new Size(108, 23);
            cmbEmploymentType.TabIndex = 23;
            // 
            // JobVacancyForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(1178, 774);
            Controls.Add(lblEmploymentType);
            Controls.Add(cmbEmploymentType);
            Controls.Add(lblDepartment);
            Controls.Add(cmbDepartment);
            Controls.Add(UPDATE);
            Controls.Add(DELETE);
            Controls.Add(CLEAR);
            Controls.Add(ADD);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Controls.Add(txtRequirements);
            Controls.Add(txtDescription);
            Controls.Add(dataGridView1);
            Controls.Add(txtJobTitle);
            Controls.Add(label1);
            Controls.Add(cmbStatus);
            Name = "JobVacancyForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtJobTitle;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtRequirements;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button ADD;
        private System.Windows.Forms.Button CLEAR;
        private System.Windows.Forms.Button DELETE;
        private System.Windows.Forms.Button UPDATE;
        private Label lblDepartment;
        private ComboBox cmbDepartment;
        private Label lblEmploymentType;
        private ComboBox cmbEmploymentType;
    }
}

