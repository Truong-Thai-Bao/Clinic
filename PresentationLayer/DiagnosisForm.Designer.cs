﻿namespace PresentationLayer
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
            this.cbPatients = new System.Windows.Forms.ComboBox();
            this.patientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cMSystemDataSet1 = new PresentationLayer.CMSystemDataSet1();
            this.symptomDataGridView = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.medicineDataGridView = new System.Windows.Forms.DataGridView();
            this.Serial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MedicineName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MorningDose = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoonDose = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AfternoonDose = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.day = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MedicineId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.cbMedicine = new System.Windows.Forms.ComboBox();
            this.medicineBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cMSystemDataSet = new PresentationLayer.CMSystemDataSet();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbType = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDay = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lbNum = new System.Windows.Forms.Label();
            this.txtAfternoon = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNoon = new System.Windows.Forms.TextBox();
            this.txtMorning = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.medicineTableAdapter = new PresentationLayer.CMSystemDataSetTableAdapters.MedicineTableAdapter();
            this.patientTableAdapter = new PresentationLayer.CMSystemDataSet1TableAdapters.PatientTableAdapter();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lsvDiagnosis = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Diagnosis = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddDiagnosis = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDiagnosis = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGender = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.txtBlood = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.txtPatientCode = new System.Windows.Forms.TextBox();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pictureBoxLogout = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.patientBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cMSystemDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.symptomDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medicineDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medicineBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cMSystemDataSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogout)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.labelClinicManagement);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1067, 100);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DodgerBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.AliceBlue;
            this.label1.Location = new System.Drawing.Point(453, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 29);
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
            this.labelClinicManagement.Location = new System.Drawing.Point(309, 20);
            this.labelClinicManagement.Name = "labelClinicManagement";
            this.labelClinicManagement.Size = new System.Drawing.Size(459, 32);
            this.labelClinicManagement.TabIndex = 9;
            this.labelClinicManagement.Text = "CLINIC MANAGEMENT SYSTEM";
            this.labelClinicManagement.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbPatients
            // 
            this.cbPatients.DataSource = this.patientBindingSource;
            this.cbPatients.DisplayMember = "Name";
            this.cbPatients.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPatients.FormattingEnabled = true;
            this.cbPatients.Location = new System.Drawing.Point(28, 112);
            this.cbPatients.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbPatients.Name = "cbPatients";
            this.cbPatients.Size = new System.Drawing.Size(253, 41);
            this.cbPatients.TabIndex = 24;
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
            // symptomDataGridView
            // 
            this.symptomDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.symptomDataGridView.Location = new System.Drawing.Point(116, 93);
            this.symptomDataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.symptomDataGridView.Name = "symptomDataGridView";
            this.symptomDataGridView.RowHeadersWidth = 51;
            this.symptomDataGridView.RowTemplate.Height = 24;
            this.symptomDataGridView.Size = new System.Drawing.Size(622, 46);
            this.symptomDataGridView.TabIndex = 27;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAdd.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(610, 553);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(114, 38);
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
            this.btnSave.Location = new System.Drawing.Point(776, 553);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(114, 38);
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
            this.AfternoonDose,
            this.day,
            this.MedicineId,
            this.Type,
            this.Delete});
            this.medicineDataGridView.Location = new System.Drawing.Point(24, 107);
            this.medicineDataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.medicineDataGridView.Name = "medicineDataGridView";
            this.medicineDataGridView.ReadOnly = true;
            this.medicineDataGridView.RowHeadersWidth = 51;
            this.medicineDataGridView.RowTemplate.Height = 24;
            this.medicineDataGridView.Size = new System.Drawing.Size(728, 159);
            this.medicineDataGridView.TabIndex = 34;
            this.medicineDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.medicineDataGridView_CellContentClick);
            this.medicineDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.medicineDataGridView_CellDoubleClick);
            // 
            // Serial
            // 
            this.Serial.FillWeight = 121.8274F;
            this.Serial.HeaderText = "STT";
            this.Serial.MinimumWidth = 6;
            this.Serial.Name = "Serial";
            this.Serial.ReadOnly = true;
            this.Serial.Width = 45;
            // 
            // MedicineName
            // 
            this.MedicineName.FillWeight = 96.88181F;
            this.MedicineName.HeaderText = "Tên thuốc";
            this.MedicineName.MinimumWidth = 6;
            this.MedicineName.Name = "MedicineName";
            this.MedicineName.ReadOnly = true;
            this.MedicineName.Width = 330;
            // 
            // MorningDose
            // 
            this.MorningDose.FillWeight = 96.88181F;
            this.MorningDose.HeaderText = "Sáng";
            this.MorningDose.MinimumWidth = 6;
            this.MorningDose.Name = "MorningDose";
            this.MorningDose.ReadOnly = true;
            this.MorningDose.Width = 50;
            // 
            // NoonDose
            // 
            this.NoonDose.FillWeight = 96.88181F;
            this.NoonDose.HeaderText = "Trưa";
            this.NoonDose.MinimumWidth = 6;
            this.NoonDose.Name = "NoonDose";
            this.NoonDose.ReadOnly = true;
            this.NoonDose.Width = 50;
            // 
            // AfternoonDose
            // 
            this.AfternoonDose.FillWeight = 96.88181F;
            this.AfternoonDose.HeaderText = "Chiều";
            this.AfternoonDose.MinimumWidth = 6;
            this.AfternoonDose.Name = "AfternoonDose";
            this.AfternoonDose.ReadOnly = true;
            this.AfternoonDose.Width = 50;
            // 
            // day
            // 
            this.day.FillWeight = 96.88181F;
            this.day.HeaderText = "Ngày";
            this.day.MinimumWidth = 6;
            this.day.Name = "day";
            this.day.ReadOnly = true;
            this.day.Width = 50;
            // 
            // MedicineId
            // 
            this.MedicineId.HeaderText = "Column1";
            this.MedicineId.MinimumWidth = 6;
            this.MedicineId.Name = "MedicineId";
            this.MedicineId.ReadOnly = true;
            this.MedicineId.Visible = false;
            this.MedicineId.Width = 125;
            // 
            // Type
            // 
            this.Type.FillWeight = 96.88181F;
            this.Type.HeaderText = "Loại";
            this.Type.MinimumWidth = 6;
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Width = 60;
            // 
            // Delete
            // 
            this.Delete.FillWeight = 96.88181F;
            this.Delete.HeaderText = "Xóa";
            this.Delete.MinimumWidth = 6;
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Width = 45;
            // 
            // cbMedicine
            // 
            this.cbMedicine.DataSource = this.medicineBindingSource;
            this.cbMedicine.DisplayMember = "MedicineName";
            this.cbMedicine.Font = new System.Drawing.Font("Bahnschrift Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMedicine.FormattingEnabled = true;
            this.cbMedicine.Location = new System.Drawing.Point(27, 20);
            this.cbMedicine.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbMedicine.Name = "cbMedicine";
            this.cbMedicine.Size = new System.Drawing.Size(732, 27);
            this.cbMedicine.TabIndex = 24;
            this.cbMedicine.SelectedIndexChanged += new System.EventHandler(this.cbMedicine_SelectedIndexChanged);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbType);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtDay);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lbNum);
            this.groupBox1.Controls.Add(this.txtAfternoon);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtNoon);
            this.groupBox1.Controls.Add(this.txtMorning);
            this.groupBox1.Location = new System.Drawing.Point(27, 48);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(732, 53);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            // 
            // lbType
            // 
            this.lbType.AutoSize = true;
            this.lbType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbType.ForeColor = System.Drawing.Color.Black;
            this.lbType.Location = new System.Drawing.Point(684, 17);
            this.lbType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(52, 25);
            this.lbType.TabIndex = 9;
            this.lbType.Text = "Viên";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(72, 17);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "Sáng";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(195, 17);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 25);
            this.label7.TabIndex = 0;
            this.label7.Text = "Trưa";
            // 
            // txtDay
            // 
            this.txtDay.Location = new System.Drawing.Point(514, 17);
            this.txtDay.Margin = new System.Windows.Forms.Padding(4);
            this.txtDay.Name = "txtDay";
            this.txtDay.Size = new System.Drawing.Size(40, 26);
            this.txtDay.TabIndex = 1;
            this.txtDay.Text = "7";
            this.txtDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDay.TextChanged += new System.EventHandler(this.txtDay_TextChanged);
            this.txtDay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumMes_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(329, 17);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 25);
            this.label8.TabIndex = 0;
            this.label8.Text = "Chiều";
            // 
            // lbNum
            // 
            this.lbNum.AutoSize = true;
            this.lbNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNum.ForeColor = System.Drawing.Color.Black;
            this.lbNum.Location = new System.Drawing.Point(636, 17);
            this.lbNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNum.Name = "lbNum";
            this.lbNum.Size = new System.Drawing.Size(50, 25);
            this.lbNum.TabIndex = 0;
            this.lbNum.Text = "num";
            // 
            // txtAfternoon
            // 
            this.txtAfternoon.Location = new System.Drawing.Point(280, 15);
            this.txtAfternoon.Margin = new System.Windows.Forms.Padding(4);
            this.txtAfternoon.Name = "txtAfternoon";
            this.txtAfternoon.Size = new System.Drawing.Size(40, 26);
            this.txtAfternoon.TabIndex = 1;
            this.txtAfternoon.Text = "1";
            this.txtAfternoon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAfternoon.TextChanged += new System.EventHandler(this.txtAfternoon_TextChanged);
            this.txtAfternoon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumMes_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(562, 17);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 25);
            this.label10.TabIndex = 0;
            this.label10.Text = "Ngày = ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(490, 17);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 25);
            this.label9.TabIndex = 0;
            this.label9.Text = "x";
            // 
            // txtNoon
            // 
            this.txtNoon.Location = new System.Drawing.Point(147, 15);
            this.txtNoon.Margin = new System.Windows.Forms.Padding(4);
            this.txtNoon.Name = "txtNoon";
            this.txtNoon.Size = new System.Drawing.Size(40, 26);
            this.txtNoon.TabIndex = 1;
            this.txtNoon.Text = "1";
            this.txtNoon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNoon.TextChanged += new System.EventHandler(this.txtNoon_TextChanged);
            this.txtNoon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumMes_KeyPress);
            // 
            // txtMorning
            // 
            this.txtMorning.Location = new System.Drawing.Point(24, 15);
            this.txtMorning.Margin = new System.Windows.Forms.Padding(4);
            this.txtMorning.Name = "txtMorning";
            this.txtMorning.Size = new System.Drawing.Size(40, 26);
            this.txtMorning.TabIndex = 8;
            this.txtMorning.Text = "1";
            this.txtMorning.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMorning.TextChanged += new System.EventHandler(this.txtMorning_TextChanged);
            this.txtMorning.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumMes_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(23, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 34);
            this.label5.TabIndex = 36;
            this.label5.Text = "Chẩn đoán bệnh";
            // 
            // medicineTableAdapter
            // 
            this.medicineTableAdapter.ClearBeforeFill = true;
            // 
            // patientTableAdapter
            // 
            this.patientTableAdapter.ClearBeforeFill = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lsvDiagnosis);
            this.groupBox2.Controls.Add(this.btnAddDiagnosis);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtDiagnosis);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(22, 259);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(239, 332);
            this.groupBox2.TabIndex = 42;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin chẩn đoán";
            // 
            // lsvDiagnosis
            // 
            this.lsvDiagnosis.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.Diagnosis});
            this.lsvDiagnosis.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvDiagnosis.FullRowSelect = true;
            this.lsvDiagnosis.GridLines = true;
            this.lsvDiagnosis.HideSelection = false;
            this.lsvDiagnosis.Location = new System.Drawing.Point(10, 18);
            this.lsvDiagnosis.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lsvDiagnosis.Name = "lsvDiagnosis";
            this.lsvDiagnosis.Size = new System.Drawing.Size(214, 198);
            this.lsvDiagnosis.TabIndex = 42;
            this.lsvDiagnosis.UseCompatibleStateImageBehavior = false;
            this.lsvDiagnosis.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "STT";
            this.columnHeader1.Width = 50;
            // 
            // Diagnosis
            // 
            this.Diagnosis.Text = "Chẩn đoán";
            this.Diagnosis.Width = 120;
            // 
            // btnAddDiagnosis
            // 
            this.btnAddDiagnosis.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddDiagnosis.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDiagnosis.ForeColor = System.Drawing.Color.White;
            this.btnAddDiagnosis.Location = new System.Drawing.Point(6, 269);
            this.btnAddDiagnosis.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddDiagnosis.Name = "btnAddDiagnosis";
            this.btnAddDiagnosis.Size = new System.Drawing.Size(218, 41);
            this.btnAddDiagnosis.TabIndex = 42;
            this.btnAddDiagnosis.Text = "THÊM CHẨN ĐOÁN";
            this.btnAddDiagnosis.UseVisualStyleBackColor = false;
            this.btnAddDiagnosis.Click += new System.EventHandler(this.btnAddDiagnosis_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 78);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(125, 18);
            this.label11.TabIndex = 35;
            this.label11.Text = "Triệu chứng khác:";
            // 
            // txtDiagnosis
            // 
            this.txtDiagnosis.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiagnosis.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtDiagnosis.Location = new System.Drawing.Point(6, 232);
            this.txtDiagnosis.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDiagnosis.Multiline = true;
            this.txtDiagnosis.Name = "txtDiagnosis";
            this.txtDiagnosis.Size = new System.Drawing.Size(216, 33);
            this.txtDiagnosis.TabIndex = 34;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(3, 37);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 18);
            this.label12.TabIndex = 28;
            this.label12.Text = "Triệu chứng:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(286, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 34);
            this.label2.TabIndex = 36;
            this.label2.Text = "Nhóm máu";
            // 
            // txtGender
            // 
            this.txtGender.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGender.Location = new System.Drawing.Point(659, 31);
            this.txtGender.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtGender.Name = "txtGender";
            this.txtGender.ReadOnly = true;
            this.txtGender.Size = new System.Drawing.Size(55, 40);
            this.txtGender.TabIndex = 30;
            this.txtGender.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAge
            // 
            this.txtAge.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAge.Location = new System.Drawing.Point(502, 34);
            this.txtAge.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAge.Name = "txtAge";
            this.txtAge.ReadOnly = true;
            this.txtAge.Size = new System.Drawing.Size(55, 40);
            this.txtAge.TabIndex = 28;
            this.txtAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBlood
            // 
            this.txtBlood.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBlood.Location = new System.Drawing.Point(371, 31);
            this.txtBlood.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBlood.Name = "txtBlood";
            this.txtBlood.ReadOnly = true;
            this.txtBlood.Size = new System.Drawing.Size(55, 40);
            this.txtBlood.TabIndex = 28;
            this.txtBlood.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(582, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 34);
            this.label4.TabIndex = 36;
            this.label4.Text = "Giới tính";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAge.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAge.Location = new System.Drawing.Point(460, 37);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(52, 34);
            this.lblAge.TabIndex = 41;
            this.lblAge.Text = "Tuổi";
            // 
            // txtPatientCode
            // 
            this.txtPatientCode.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatientCode.Location = new System.Drawing.Point(145, 161);
            this.txtPatientCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPatientCode.Name = "txtPatientCode";
            this.txtPatientCode.ReadOnly = true;
            this.txtPatientCode.Size = new System.Drawing.Size(136, 40);
            this.txtPatientCode.TabIndex = 26;
            this.txtPatientCode.Text = "MÃ BỆNH NHÂN";
            this.txtPatientCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtContact
            // 
            this.txtContact.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContact.Location = new System.Drawing.Point(101, 31);
            this.txtContact.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtContact.Name = "txtContact";
            this.txtContact.ReadOnly = true;
            this.txtContact.Size = new System.Drawing.Size(171, 40);
            this.txtContact.TabIndex = 25;
            this.txtContact.Text = "LIÊN HỆ";
            this.txtContact.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtContact);
            this.groupBox3.Controls.Add(this.lblAge);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtBlood);
            this.groupBox3.Controls.Add(this.txtAge);
            this.groupBox3.Controls.Add(this.txtGender);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.symptomDataGridView);
            this.groupBox3.Location = new System.Drawing.Point(298, 112);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(752, 155);
            this.groupBox3.TabIndex = 42;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông tin bệnh nhân";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label14.Location = new System.Drawing.Point(12, 102);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(127, 34);
            this.label14.TabIndex = 36;
            this.label14.Text = "Triệu Chứng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(24, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 34);
            this.label3.TabIndex = 36;
            this.label3.Text = "Liên hệ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label13.Location = new System.Drawing.Point(23, 167);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(150, 34);
            this.label13.TabIndex = 36;
            this.label13.Text = "MÃ BỆNH NHÂN";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox1);
            this.groupBox4.Controls.Add(this.medicineDataGridView);
            this.groupBox4.Controls.Add(this.cbMedicine);
            this.groupBox4.Location = new System.Drawing.Point(285, 277);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(765, 271);
            this.groupBox4.TabIndex = 43;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Kê Thuốc";
            // 
            // pictureBoxLogout
            // 
            this.pictureBoxLogout.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogout.Image")));
            this.pictureBoxLogout.Location = new System.Drawing.Point(998, 558);
            this.pictureBoxLogout.Name = "pictureBoxLogout";
            this.pictureBoxLogout.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxLogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogout.TabIndex = 38;
            this.pictureBoxLogout.TabStop = false;
            this.pictureBoxLogout.Click += new System.EventHandler(this.pictureBoxLogout_Click_1);
            // 
            // DiagnosisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(1067, 620);
            this.Controls.Add(this.pictureBoxLogout);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txtPatientCode);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cbPatients);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.MintCream;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DiagnosisForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DiagnosisForm";
            this.Load += new System.EventHandler(this.DiagnosisForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.patientBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cMSystemDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.symptomDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medicineDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medicineBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cMSystemDataSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelClinicManagement;
        private System.Windows.Forms.ComboBox cbPatients;
        private System.Windows.Forms.DataGridView symptomDataGridView;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView medicineDataGridView;
        private System.Windows.Forms.ComboBox cbMedicine;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private CMSystemDataSet cMSystemDataSet;
        private System.Windows.Forms.BindingSource medicineBindingSource;
        private CMSystemDataSetTableAdapters.MedicineTableAdapter medicineTableAdapter;
        private CMSystemDataSet1 cMSystemDataSet1;
        private System.Windows.Forms.BindingSource patientBindingSource;
        private CMSystemDataSet1TableAdapters.PatientTableAdapter patientTableAdapter;
        private System.Windows.Forms.TextBox txtDay;
        private System.Windows.Forms.TextBox txtAfternoon;
        private System.Windows.Forms.TextBox txtNoon;
        private System.Windows.Forms.TextBox txtMorning;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbType;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lsvDiagnosis;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader Diagnosis;
        private System.Windows.Forms.Button btnAddDiagnosis;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDiagnosis;
        private System.Windows.Forms.Label label12;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGender;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.TextBox txtBlood;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.TextBox txtPatientCode;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lbNum;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serial;
        private System.Windows.Forms.DataGridViewTextBoxColumn MedicineName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MorningDose;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoonDose;
        private System.Windows.Forms.DataGridViewTextBoxColumn AfternoonDose;
        private System.Windows.Forms.DataGridViewTextBoxColumn day;
        private System.Windows.Forms.DataGridViewTextBoxColumn MedicineId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox pictureBoxLogout;
    }
}