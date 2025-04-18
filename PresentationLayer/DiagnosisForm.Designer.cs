namespace PresentationLayer
{
    partial class DiagnosisForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiagnosisForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelClinicManagement = new System.Windows.Forms.Label();
            this.pictureBoxLogout = new System.Windows.Forms.PictureBox();
            this.cbPatients = new System.Windows.Forms.ComboBox();
            this.patientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cMSystemDataSet1 = new PresentationLayer.CMSystemDataSet1();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.txtPatientCode = new System.Windows.Forms.TextBox();
            this.symptomDataGridView = new System.Windows.Forms.DataGridView();
            this.txtBlood = new System.Windows.Forms.TextBox();
            this.txtGender = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.medicineDataGridView = new System.Windows.Forms.DataGridView();
            this.Serial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MedicineName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MorningDose = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoonDose = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EveningDose = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NightDose = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPatientId = new System.Windows.Forms.TextBox();
            this.cbMedicine = new System.Windows.Forms.ComboBox();
            this.medicineBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cMSystemDataSet = new PresentationLayer.CMSystemDataSet();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDianosis = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.medicineTableAdapter = new PresentationLayer.CMSystemDataSetTableAdapters.MedicineTableAdapter();
            this.patientTableAdapter = new PresentationLayer.CMSystemDataSet1TableAdapters.PatientTableAdapter();
            this.lblAge = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMorning = new System.Windows.Forms.TextBox();
            this.txtNoon = new System.Windows.Forms.TextBox();
            this.txtAfternoon = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cMSystemDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.symptomDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medicineDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medicineBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cMSystemDataSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.labelClinicManagement);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1269, 81);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DodgerBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.AliceBlue;
            this.label1.Location = new System.Drawing.Point(340, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = "CHẨN ĐOÁN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelClinicManagement
            // 
            this.labelClinicManagement.AutoSize = true;
            this.labelClinicManagement.BackColor = System.Drawing.Color.DodgerBlue;
            this.labelClinicManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClinicManagement.ForeColor = System.Drawing.Color.AliceBlue;
            this.labelClinicManagement.Location = new System.Drawing.Point(232, 16);
            this.labelClinicManagement.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelClinicManagement.Name = "labelClinicManagement";
            this.labelClinicManagement.Size = new System.Drawing.Size(368, 26);
            this.labelClinicManagement.TabIndex = 9;
            this.labelClinicManagement.Text = "CLINIC MANAGEMENT SYSTEM";
            this.labelClinicManagement.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxLogout
            // 
            this.pictureBoxLogout.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogout.Image")));
            this.pictureBoxLogout.Location = new System.Drawing.Point(1134, 495);
            this.pictureBoxLogout.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBoxLogout.Name = "pictureBoxLogout";
            this.pictureBoxLogout.Size = new System.Drawing.Size(71, 41);
            this.pictureBoxLogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogout.TabIndex = 23;
            this.pictureBoxLogout.TabStop = false;
            this.pictureBoxLogout.Click += new System.EventHandler(this.pictureBoxLogout_Click);
            // 
            // cbPatients
            // 
            this.cbPatients.DataSource = this.patientBindingSource;
            this.cbPatients.DisplayMember = "Name";
            this.cbPatients.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPatients.FormattingEnabled = true;
            this.cbPatients.Location = new System.Drawing.Point(11, 94);
            this.cbPatients.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbPatients.Name = "cbPatients";
            this.cbPatients.Size = new System.Drawing.Size(246, 35);
            this.cbPatients.TabIndex = 0;
            this.cbPatients.ValueMember = "PatientId";
            this.cbPatients.SelectedValueChanged += new System.EventHandler(this.cbPatients_SelectedValueChanged);
            // 
            // patientBindingSource
            // 
            this.patientBindingSource.DataMember = "Patient";
            this.patientBindingSource.DataSource = this.cMSystemDataSet1;
            // 
            // cMSystemDataSet1
            // 
            this.cMSystemDataSet1.DataSetName = "CMSystemDataSet1";
            this.cMSystemDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtContact
            // 
            this.txtContact.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContact.Location = new System.Drawing.Point(11, 144);
            this.txtContact.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtContact.Name = "txtContact";
            this.txtContact.ReadOnly = true;
            this.txtContact.Size = new System.Drawing.Size(246, 33);
            this.txtContact.TabIndex = 25;
            this.txtContact.Text = "LIÊN HỆ";
            this.txtContact.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPatientCode
            // 
            this.txtPatientCode.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatientCode.Location = new System.Drawing.Point(11, 193);
            this.txtPatientCode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPatientCode.Name = "txtPatientCode";
            this.txtPatientCode.ReadOnly = true;
            this.txtPatientCode.Size = new System.Drawing.Size(246, 33);
            this.txtPatientCode.TabIndex = 26;
            this.txtPatientCode.Text = "MÃ BỆNH NHÂN";
            this.txtPatientCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // symptomDataGridView
            // 
            this.symptomDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.symptomDataGridView.Location = new System.Drawing.Point(11, 242);
            this.symptomDataGridView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.symptomDataGridView.Name = "symptomDataGridView";
            this.symptomDataGridView.RowHeadersWidth = 51;
            this.symptomDataGridView.RowTemplate.Height = 24;
            this.symptomDataGridView.Size = new System.Drawing.Size(243, 192);
            this.symptomDataGridView.TabIndex = 27;
            // 
            // txtBlood
            // 
            this.txtBlood.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBlood.Location = new System.Drawing.Point(468, 93);
            this.txtBlood.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBlood.Name = "txtBlood";
            this.txtBlood.ReadOnly = true;
            this.txtBlood.Size = new System.Drawing.Size(51, 33);
            this.txtBlood.TabIndex = 28;
            this.txtBlood.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtGender
            // 
            this.txtGender.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGender.Location = new System.Drawing.Point(1082, 104);
            this.txtGender.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtGender.Name = "txtGender";
            this.txtGender.ReadOnly = true;
            this.txtGender.Size = new System.Drawing.Size(92, 33);
            this.txtGender.TabIndex = 30;
            this.txtGender.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAdd.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(582, 495);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 31);
            this.btnAdd.TabIndex = 32;
            this.btnAdd.Text = "THÊM";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(1003, 505);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 31);
            this.btnSave.TabIndex = 33;
            this.btnSave.Text = "LƯU";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // medicineDataGridView
            // 
            this.medicineDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.medicineDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Serial,
            this.MedicineName,
            this.MorningDose,
            this.NoonDose,
            this.EveningDose,
            this.NightDose});
            this.medicineDataGridView.Location = new System.Drawing.Point(561, 277);
            this.medicineDataGridView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.medicineDataGridView.Name = "medicineDataGridView";
            this.medicineDataGridView.RowHeadersWidth = 51;
            this.medicineDataGridView.RowTemplate.Height = 24;
            this.medicineDataGridView.Size = new System.Drawing.Size(678, 200);
            this.medicineDataGridView.TabIndex = 34;
            this.medicineDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.medicineDataGridView_CellDoubleClick);
            // 
            // Serial
            // 
            this.Serial.HeaderText = "STT";
            this.Serial.MinimumWidth = 6;
            this.Serial.Name = "Serial";
            this.Serial.Width = 60;
            // 
            // MedicineName
            // 
            this.MedicineName.HeaderText = "Tên thuốc";
            this.MedicineName.MinimumWidth = 6;
            this.MedicineName.Name = "MedicineName";
            this.MedicineName.Width = 250;
            // 
            // MorningDose
            // 
            this.MorningDose.HeaderText = "Sáng";
            this.MorningDose.MinimumWidth = 6;
            this.MorningDose.Name = "MorningDose";
            this.MorningDose.Width = 125;
            // 
            // NoonDose
            // 
            this.NoonDose.HeaderText = "Trưa";
            this.NoonDose.MinimumWidth = 6;
            this.NoonDose.Name = "NoonDose";
            this.NoonDose.Width = 125;
            // 
            // EveningDose
            // 
            this.EveningDose.HeaderText = "Chiều";
            this.EveningDose.MinimumWidth = 6;
            this.EveningDose.Name = "EveningDose";
            this.EveningDose.Width = 125;
            // 
            // NightDose
            // 
            this.NightDose.HeaderText = "Tối";
            this.NightDose.MinimumWidth = 6;
            this.NightDose.Name = "NightDose";
            this.NightDose.Width = 125;
            // 
            // txtPatientId
            // 
            this.txtPatientId.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatientId.ForeColor = System.Drawing.Color.Teal;
            this.txtPatientId.Location = new System.Drawing.Point(10, 461);
            this.txtPatientId.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPatientId.Name = "txtPatientId";
            this.txtPatientId.ReadOnly = true;
            this.txtPatientId.Size = new System.Drawing.Size(244, 33);
            this.txtPatientId.TabIndex = 35;
            this.txtPatientId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPatientId.Visible = false;
            // 
            // cbMedicine
            // 
            this.cbMedicine.DataSource = this.medicineBindingSource;
            this.cbMedicine.DisplayMember = "MedicineName";
            this.cbMedicine.Font = new System.Drawing.Font("Bahnschrift Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMedicine.FormattingEnabled = true;
            this.cbMedicine.Location = new System.Drawing.Point(561, 176);
            this.cbMedicine.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbMedicine.Name = "cbMedicine";
            this.cbMedicine.Size = new System.Drawing.Size(678, 24);
            this.cbMedicine.TabIndex = 1;
            this.cbMedicine.SelectedValueChanged += new System.EventHandler(this.cbPatients_SelectedValueChanged);
            // 
            // medicineBindingSource
            // 
            this.medicineBindingSource.DataMember = "Medicine";
            this.medicineBindingSource.DataSource = this.cMSystemDataSet;
            // 
            // cMSystemDataSet
            // 
            this.cMSystemDataSet.DataSetName = "CMSystemDataSet";
            this.cMSystemDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(339, 97);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 27);
            this.label2.TabIndex = 36;
            this.label2.Text = "Nhóm máu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(654, 104);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 27);
            this.label3.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(965, 104);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 27);
            this.label4.TabIndex = 36;
            this.label4.Text = "Giới tính";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.txtAfternoon);
            this.groupBox1.Controls.Add(this.txtNoon);
            this.groupBox1.Controls.Add(this.txtMorning);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(561, 213);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(678, 51);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(317, 147);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 27);
            this.label5.TabIndex = 36;
            this.label5.Text = "Chẩn đoán bệnh";
            // 
            // txtDianosis
            // 
            this.txtDianosis.Location = new System.Drawing.Point(298, 176);
            this.txtDianosis.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDianosis.Multiline = true;
            this.txtDianosis.Name = "txtDianosis";
            this.txtDianosis.Size = new System.Drawing.Size(221, 318);
            this.txtDianosis.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DodgerBlue;
            this.button1.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(719, 495);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 31);
            this.button1.TabIndex = 32;
            this.button1.Text = "XÓA";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // medicineTableAdapter
            // 
            this.medicineTableAdapter.ClearBeforeFill = true;
            // 
            // patientTableAdapter
            // 
            this.patientTableAdapter.ClearBeforeFill = true;
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAge.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAge.Location = new System.Drawing.Point(635, 104);
            this.lblAge.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(40, 27);
            this.lblAge.TabIndex = 41;
            this.lblAge.Text = "Tuổi";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(67, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Sáng";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(216, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Trưa";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(350, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "Chiều";
            // 
            // txtMorning
            // 
            this.txtMorning.Location = new System.Drawing.Point(11, 15);
            this.txtMorning.Name = "txtMorning";
            this.txtMorning.Size = new System.Drawing.Size(55, 20);
            this.txtMorning.TabIndex = 8;
            this.txtMorning.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumMes_KeyPress);
            // 
            // txtNoon
            // 
            this.txtNoon.Location = new System.Drawing.Point(158, 18);
            this.txtNoon.Name = "txtNoon";
            this.txtNoon.Size = new System.Drawing.Size(55, 20);
            this.txtNoon.TabIndex = 1;
            this.txtNoon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumMes_KeyPress);
            // 
            // txtAfternoon
            // 
            this.txtAfternoon.Location = new System.Drawing.Point(289, 18);
            this.txtAfternoon.Name = "txtAfternoon";
            this.txtAfternoon.Size = new System.Drawing.Size(55, 20);
            this.txtAfternoon.TabIndex = 1;
            this.txtAfternoon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumMes_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(473, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(16, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "x";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(495, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(35, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumMes_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(536, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 20);
            this.label10.TabIndex = 0;
            this.label10.Text = "Ngày = ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(594, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "xx Viên";
            // 
            // txtAge
            // 
            this.txtAge.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAge.Location = new System.Drawing.Point(689, 101);
            this.txtAge.Margin = new System.Windows.Forms.Padding(2);
            this.txtAge.Name = "txtAge";
            this.txtAge.ReadOnly = true;
            this.txtAge.Size = new System.Drawing.Size(51, 33);
            this.txtAge.TabIndex = 28;
            this.txtAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DiagnosisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(1269, 547);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.txtDianosis);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPatientId);
            this.Controls.Add(this.medicineDataGridView);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtGender);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.txtBlood);
            this.Controls.Add(this.symptomDataGridView);
            this.Controls.Add(this.txtPatientCode);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.cbMedicine);
            this.Controls.Add(this.cbPatients);
            this.Controls.Add(this.pictureBoxLogout);
            this.ForeColor = System.Drawing.Color.MintCream;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "DiagnosisForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DiagnosisForm";
            this.Load += new System.EventHandler(this.DiagnosisForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cMSystemDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.symptomDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medicineDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medicineBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cMSystemDataSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelClinicManagement;
        private System.Windows.Forms.PictureBox pictureBoxLogout;
        private System.Windows.Forms.ComboBox cbPatients;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.TextBox txtPatientCode;
        private System.Windows.Forms.DataGridView symptomDataGridView;
        private System.Windows.Forms.TextBox txtBlood;
        private System.Windows.Forms.TextBox txtGender;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView medicineDataGridView;
        private System.Windows.Forms.TextBox txtPatientId;
        private System.Windows.Forms.ComboBox cbMedicine;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDianosis;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serial;
        private System.Windows.Forms.DataGridViewTextBoxColumn MedicineName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MorningDose;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoonDose;
        private System.Windows.Forms.DataGridViewTextBoxColumn EveningDose;
        private System.Windows.Forms.DataGridViewTextBoxColumn NightDose;
        private CMSystemDataSet cMSystemDataSet;
        private System.Windows.Forms.BindingSource medicineBindingSource;
        private CMSystemDataSetTableAdapters.MedicineTableAdapter medicineTableAdapter;
        private CMSystemDataSet1 cMSystemDataSet1;
        private System.Windows.Forms.BindingSource patientBindingSource;
        private CMSystemDataSet1TableAdapters.PatientTableAdapter patientTableAdapter;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtAfternoon;
        private System.Windows.Forms.TextBox txtNoon;
        private System.Windows.Forms.TextBox txtMorning;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtAge;
    }
}