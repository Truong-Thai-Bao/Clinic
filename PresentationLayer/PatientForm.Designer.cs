namespace PresentationLayer
{
    partial class PatientForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientForm));
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.cbBlood = new System.Windows.Forms.ComboBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.cbSelectDoctor = new System.Windows.Forms.ComboBox();
            this.txtOtherSymptom = new System.Windows.Forms.TextBox();
            this.symptomDataGridView = new System.Windows.Forms.DataGridView();
            this.Serial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBoxLogout = new System.Windows.Forms.PictureBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnGetPrescription = new System.Windows.Forms.Button();
            this.txtPatientId = new System.Windows.Forms.TextBox();
            this.lblPCode = new System.Windows.Forms.Label();
            this.lblPCodeNum = new System.Windows.Forms.Label();
            this.cbGender = new System.Windows.Forms.ComboBox();
            this.cbSymptom = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelClinicManagement = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.symptomDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogout)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPatientName
            // 
            this.txtPatientName.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatientName.Location = new System.Drawing.Point(12, 138);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(243, 40);
            this.txtPatientName.TabIndex = 9;
            this.txtPatientName.Text = "TÊN BỆNH NHÂN";
            this.txtPatientName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAge
            // 
            this.txtAge.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAge.Location = new System.Drawing.Point(12, 185);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(125, 40);
            this.txtAge.TabIndex = 12;
            this.txtAge.Text = "TUỔI";
            this.txtAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAge_KeyPress);
            // 
            // cbBlood
            // 
            this.cbBlood.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBlood.FormattingEnabled = true;
            this.cbBlood.Items.AddRange(new object[] {
            "A+",
            "A-",
            "B+",
            "B-",
            "O+",
            "O-",
            "AB+",
            "AB-"});
            this.cbBlood.Location = new System.Drawing.Point(12, 231);
            this.cbBlood.Name = "cbBlood";
            this.cbBlood.Size = new System.Drawing.Size(243, 41);
            this.cbBlood.TabIndex = 13;
            this.cbBlood.Text = "NHÓM MÁU";
            this.cbBlood.SelectedIndexChanged += new System.EventHandler(this.cbBlood_SelectedIndexChanged);
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.MintCream;
            this.txtAddress.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(12, 289);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(488, 158);
            this.txtAddress.TabIndex = 14;
            this.txtAddress.Text = "ĐỊA CHỈ";
            this.txtAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtContact
            // 
            this.txtContact.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContact.Location = new System.Drawing.Point(261, 185);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(243, 40);
            this.txtContact.TabIndex = 15;
            this.txtContact.Text = "LIÊN HỆ";
            this.txtContact.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbSelectDoctor
            // 
            this.cbSelectDoctor.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSelectDoctor.FormattingEnabled = true;
            this.cbSelectDoctor.Location = new System.Drawing.Point(261, 231);
            this.cbSelectDoctor.Name = "cbSelectDoctor";
            this.cbSelectDoctor.Size = new System.Drawing.Size(243, 41);
            this.cbSelectDoctor.TabIndex = 16;
            this.cbSelectDoctor.Text = "CHỌN BÁC SĨ";
            // 
            // txtOtherSymptom
            // 
            this.txtOtherSymptom.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOtherSymptom.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtOtherSymptom.Location = new System.Drawing.Point(451, 138);
            this.txtOtherSymptom.Name = "txtOtherSymptom";
            this.txtOtherSymptom.Size = new System.Drawing.Size(175, 32);
            this.txtOtherSymptom.TabIndex = 20;
            this.txtOtherSymptom.Text = "Triệu chứng khác";
            this.txtOtherSymptom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // symptomDataGridView
            // 
            this.symptomDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.symptomDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Serial,
            this.Name});
            this.symptomDataGridView.Location = new System.Drawing.Point(510, 190);
            this.symptomDataGridView.Name = "symptomDataGridView";
            this.symptomDataGridView.RowHeadersWidth = 51;
            this.symptomDataGridView.RowTemplate.Height = 24;
            this.symptomDataGridView.Size = new System.Drawing.Size(350, 316);
            this.symptomDataGridView.TabIndex = 21;
            this.symptomDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.symptomDataGridView_CellFormatting);
            // 
            // Serial
            // 
            this.Serial.HeaderText = "STT";
            this.Serial.MinimumWidth = 6;
            this.Serial.Name = "Serial";
            this.Serial.Width = 125;
            // 
            // Name
            // 
            this.Name.HeaderText = "Triệu chứng";
            this.Name.MinimumWidth = 6;
            this.Name.Name = "Name";
            this.Name.Width = 125;
            // 
            // pictureBoxLogout
            // 
            this.pictureBoxLogout.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogout.Image")));
            this.pictureBoxLogout.Location = new System.Drawing.Point(810, 512);
            this.pictureBoxLogout.Name = "pictureBoxLogout";
            this.pictureBoxLogout.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxLogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogout.TabIndex = 22;
            this.pictureBoxLogout.TabStop = false;
            this.pictureBoxLogout.Click += new System.EventHandler(this.pictureBoxLogout_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.DarkCyan;
            this.btnAdd.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(641, 138);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(147, 38);
            this.btnAdd.TabIndex = 23;
            this.btnAdd.Text = "THÊM";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkCyan;
            this.btnSave.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(16, 468);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(239, 38);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "LƯU";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnGetPrescription
            // 
            this.btnGetPrescription.BackColor = System.Drawing.Color.DarkCyan;
            this.btnGetPrescription.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetPrescription.ForeColor = System.Drawing.Color.White;
            this.btnGetPrescription.Location = new System.Drawing.Point(16, 512);
            this.btnGetPrescription.Name = "btnGetPrescription";
            this.btnGetPrescription.Size = new System.Drawing.Size(488, 38);
            this.btnGetPrescription.TabIndex = 25;
            this.btnGetPrescription.Text = "Lấy đơn thuốc";
            this.btnGetPrescription.UseVisualStyleBackColor = false;
            this.btnGetPrescription.Click += new System.EventHandler(this.btnGetPrescription_Click);
            // 
            // txtPatientId
            // 
            this.txtPatientId.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatientId.ForeColor = System.Drawing.Color.Teal;
            this.txtPatientId.Location = new System.Drawing.Point(561, 512);
            this.txtPatientId.Name = "txtPatientId";
            this.txtPatientId.ReadOnly = true;
            this.txtPatientId.Size = new System.Drawing.Size(204, 40);
            this.txtPatientId.TabIndex = 26;
            this.txtPatientId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPatientId.Visible = false;
            // 
            // lblPCode
            // 
            this.lblPCode.AutoSize = true;
            this.lblPCode.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPCode.ForeColor = System.Drawing.Color.Red;
            this.lblPCode.Location = new System.Drawing.Point(261, 473);
            this.lblPCode.Name = "lblPCode";
            this.lblPCode.Size = new System.Drawing.Size(63, 28);
            this.lblPCode.TabIndex = 27;
            this.lblPCode.Text = "Mã BN:";
            // 
            // lblPCodeNum
            // 
            this.lblPCodeNum.AutoSize = true;
            this.lblPCodeNum.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPCodeNum.ForeColor = System.Drawing.Color.Red;
            this.lblPCodeNum.Location = new System.Drawing.Point(338, 473);
            this.lblPCodeNum.Name = "lblPCodeNum";
            this.lblPCodeNum.Size = new System.Drawing.Size(112, 28);
            this.lblPCodeNum.TabIndex = 28;
            this.lblPCodeNum.Text = "0000000000";
            // 
            // cbGender
            // 
            this.cbGender.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGender.FormattingEnabled = true;
            this.cbGender.Items.AddRange(new object[] {
            "Nam",
            "Nữ",
            "Khác"});
            this.cbGender.Location = new System.Drawing.Point(143, 184);
            this.cbGender.Name = "cbGender";
            this.cbGender.Size = new System.Drawing.Size(112, 41);
            this.cbGender.TabIndex = 29;
            this.cbGender.Text = "GIỚI TÍNH";
            // 
            // cbSymptom
            // 
            this.cbSymptom.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSymptom.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.cbSymptom.FormattingEnabled = true;
            this.cbSymptom.Items.AddRange(new object[] {
            "Kích ứng mắt",
            "Chảy nước mũi",
            "Ngạt mũi",
            "Hắt hơi",
            "Ho",
            "Nhiễm virus",
            "Khác"});
            this.cbSymptom.Location = new System.Drawing.Point(261, 138);
            this.cbSymptom.Name = "cbSymptom";
            this.cbSymptom.Size = new System.Drawing.Size(175, 32);
            this.cbSymptom.TabIndex = 30;
            this.cbSymptom.Text = "Triệu chứng";
            this.cbSymptom.SelectedValueChanged += new System.EventHandler(this.cbSymptom_SelectedValueChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkCyan;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.labelClinicManagement);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(919, 100);
            this.panel1.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkCyan;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.AliceBlue;
            this.label1.Location = new System.Drawing.Point(323, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 29);
            this.label1.TabIndex = 10;
            this.label1.Text = "BỆNH NHÂN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelClinicManagement
            // 
            this.labelClinicManagement.AutoSize = true;
            this.labelClinicManagement.BackColor = System.Drawing.Color.DarkCyan;
            this.labelClinicManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClinicManagement.ForeColor = System.Drawing.Color.AliceBlue;
            this.labelClinicManagement.Location = new System.Drawing.Point(171, 20);
            this.labelClinicManagement.Name = "labelClinicManagement";
            this.labelClinicManagement.Size = new System.Drawing.Size(459, 32);
            this.labelClinicManagement.TabIndex = 9;
            this.labelClinicManagement.Text = "CLINIC MANAGEMENT SYSTEM";
            this.labelClinicManagement.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PatientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(919, 574);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbSymptom);
            this.Controls.Add(this.cbGender);
            this.Controls.Add(this.lblPCodeNum);
            this.Controls.Add(this.lblPCode);
            this.Controls.Add(this.txtPatientId);
            this.Controls.Add(this.btnGetPrescription);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.pictureBoxLogout);
            this.Controls.Add(this.symptomDataGridView);
            this.Controls.Add(this.txtOtherSymptom);
            this.Controls.Add(this.cbSelectDoctor);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.cbBlood);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.txtPatientName);
            this.ForeColor = System.Drawing.Color.Teal;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PatientForm";
            this.Load += new System.EventHandler(this.PatientForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.symptomDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogout)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtPatientName;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.ComboBox cbBlood;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.ComboBox cbSelectDoctor;
        private System.Windows.Forms.TextBox txtOtherSymptom;
        private System.Windows.Forms.DataGridView symptomDataGridView;
        private System.Windows.Forms.PictureBox pictureBoxLogout;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnGetPrescription;
        private System.Windows.Forms.TextBox txtPatientId;
        private System.Windows.Forms.Label lblPCode;
        private System.Windows.Forms.Label lblPCodeNum;
        private System.Windows.Forms.ComboBox cbGender;
        private System.Windows.Forms.ComboBox cbSymptom;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelClinicManagement;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
    }
}