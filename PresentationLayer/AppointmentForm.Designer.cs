namespace PresentationLayer
{
    partial class AppointmentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppointmentForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAppointment = new System.Windows.Forms.Label();
            this.labelClinicManagement = new System.Windows.Forms.Label();
            this.pictureBoxLogout = new System.Windows.Forms.PictureBox();
            this.lsvAppointment = new System.Windows.Forms.ListView();
            this.appointmentId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.patientName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DOB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gender = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bloodGroup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contact = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.doctorName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.appointmentDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.appointmentTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.symptom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grbPatientInfo = new System.Windows.Forms.GroupBox();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpAge = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cbBloodGroup = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbGender = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grbDoctorInfo = new System.Windows.Forms.GroupBox();
            this.cbSelectDoctor = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.grbSchedule = new System.Windows.Forms.GroupBox();
            this.cbAppointmentTime = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpAppointmentDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lsvSymptom = new System.Windows.Forms.ListView();
            this.Serial = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.symptomName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddSymptom = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtOtherSymptom = new System.Windows.Forms.TextBox();
            this.cbSymptom = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnBook = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAppointmentList = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogout)).BeginInit();
            this.grbPatientInfo.SuspendLayout();
            this.grbDoctorInfo.SuspendLayout();
            this.grbSchedule.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Controls.Add(this.lblAppointment);
            this.panel1.Controls.Add(this.labelClinicManagement);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1174, 100);
            this.panel1.TabIndex = 1;
            // 
            // lblAppointment
            // 
            this.lblAppointment.AutoSize = true;
            this.lblAppointment.BackColor = System.Drawing.Color.DodgerBlue;
            this.lblAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppointment.ForeColor = System.Drawing.Color.AliceBlue;
            this.lblAppointment.Location = new System.Drawing.Point(499, 52);
            this.lblAppointment.Name = "lblAppointment";
            this.lblAppointment.Size = new System.Drawing.Size(177, 29);
            this.lblAppointment.TabIndex = 10;
            this.lblAppointment.Text = "ĐẶT LỊCH HẸN";
            this.lblAppointment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelClinicManagement
            // 
            this.labelClinicManagement.AutoSize = true;
            this.labelClinicManagement.BackColor = System.Drawing.Color.DodgerBlue;
            this.labelClinicManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClinicManagement.ForeColor = System.Drawing.Color.AliceBlue;
            this.labelClinicManagement.Location = new System.Drawing.Point(358, 20);
            this.labelClinicManagement.Name = "labelClinicManagement";
            this.labelClinicManagement.Size = new System.Drawing.Size(459, 32);
            this.labelClinicManagement.TabIndex = 9;
            this.labelClinicManagement.Text = "CLINIC MANAGEMENT SYSTEM";
            this.labelClinicManagement.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxLogout
            // 
            this.pictureBoxLogout.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogout.Image")));
            this.pictureBoxLogout.Location = new System.Drawing.Point(1084, 585);
            this.pictureBoxLogout.Name = "pictureBoxLogout";
            this.pictureBoxLogout.Size = new System.Drawing.Size(78, 50);
            this.pictureBoxLogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogout.TabIndex = 24;
            this.pictureBoxLogout.TabStop = false;
            this.pictureBoxLogout.Click += new System.EventHandler(this.pictureBoxLogout_Click);
            // 
            // lsvAppointment
            // 
            this.lsvAppointment.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.appointmentId,
            this.patientName,
            this.DOB,
            this.gender,
            this.bloodGroup,
            this.contact,
            this.doctorName,
            this.appointmentDate,
            this.appointmentTime,
            this.symptom});
            this.lsvAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvAppointment.FullRowSelect = true;
            this.lsvAppointment.GridLines = true;
            this.lsvAppointment.HideSelection = false;
            this.lsvAppointment.Location = new System.Drawing.Point(55, 449);
            this.lsvAppointment.Name = "lsvAppointment";
            this.lsvAppointment.Size = new System.Drawing.Size(1066, 135);
            this.lsvAppointment.TabIndex = 25;
            this.lsvAppointment.UseCompatibleStateImageBehavior = false;
            this.lsvAppointment.View = System.Windows.Forms.View.Details;
            this.lsvAppointment.DoubleClick += new System.EventHandler(this.lsvAppointment_DoubleClick);
            this.lsvAppointment.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lsvAppointment_MouseClick);
            // 
            // appointmentId
            // 
            this.appointmentId.Text = "STT";
            this.appointmentId.Width = 50;
            // 
            // patientName
            // 
            this.patientName.Text = "Tên bệnh nhân";
            this.patientName.Width = 120;
            // 
            // DOB
            // 
            this.DOB.Text = "Ngày sinh";
            this.DOB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DOB.Width = 120;
            // 
            // gender
            // 
            this.gender.Text = "Giới tính";
            this.gender.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gender.Width = 80;
            // 
            // bloodGroup
            // 
            this.bloodGroup.Text = "Nhóm máu";
            this.bloodGroup.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.bloodGroup.Width = 90;
            // 
            // contact
            // 
            this.contact.Text = "Liên hệ";
            this.contact.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.contact.Width = 100;
            // 
            // doctorName
            // 
            this.doctorName.Text = "Tên Bác sĩ";
            this.doctorName.Width = 100;
            // 
            // appointmentDate
            // 
            this.appointmentDate.Text = "Ngày hẹn";
            this.appointmentDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.appointmentDate.Width = 100;
            // 
            // appointmentTime
            // 
            this.appointmentTime.Text = "Giờ hẹn";
            this.appointmentTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.appointmentTime.Width = 100;
            // 
            // symptom
            // 
            this.symptom.Text = "Triệu chứng";
            this.symptom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.symptom.Width = 150;
            // 
            // txtPatientName
            // 
            this.txtPatientName.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatientName.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtPatientName.Location = new System.Drawing.Point(154, 20);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(181, 32);
            this.txtPatientName.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 18);
            this.label1.TabIndex = 28;
            this.label1.Text = "Tên bệnh nhân:";
            // 
            // grbPatientInfo
            // 
            this.grbPatientInfo.Controls.Add(this.txtContact);
            this.grbPatientInfo.Controls.Add(this.label6);
            this.grbPatientInfo.Controls.Add(this.dtpAge);
            this.grbPatientInfo.Controls.Add(this.label5);
            this.grbPatientInfo.Controls.Add(this.cbBloodGroup);
            this.grbPatientInfo.Controls.Add(this.label4);
            this.grbPatientInfo.Controls.Add(this.cbGender);
            this.grbPatientInfo.Controls.Add(this.label3);
            this.grbPatientInfo.Controls.Add(this.label1);
            this.grbPatientInfo.Controls.Add(this.txtPatientName);
            this.grbPatientInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbPatientInfo.Location = new System.Drawing.Point(12, 117);
            this.grbPatientInfo.Name = "grbPatientInfo";
            this.grbPatientInfo.Size = new System.Drawing.Size(341, 238);
            this.grbPatientInfo.TabIndex = 31;
            this.grbPatientInfo.TabStop = false;
            this.grbPatientInfo.Text = "Thông tin bệnh nhân";
            // 
            // txtContact
            // 
            this.txtContact.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContact.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtContact.Location = new System.Drawing.Point(154, 196);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(181, 32);
            this.txtContact.TabIndex = 38;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(22, 217);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 18);
            this.label6.TabIndex = 37;
            this.label6.Text = "Liên hệ:";
            // 
            // dtpAge
            // 
            this.dtpAge.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtpAge.CalendarTitleForeColor = System.Drawing.SystemColors.WindowFrame;
            this.dtpAge.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAge.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAge.Location = new System.Drawing.Point(154, 64);
            this.dtpAge.Name = "dtpAge";
            this.dtpAge.Size = new System.Drawing.Size(181, 32);
            this.dtpAge.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 18);
            this.label5.TabIndex = 36;
            this.label5.Text = "Ngày sinh:";
            // 
            // cbBloodGroup
            // 
            this.cbBloodGroup.DisplayMember = "Name";
            this.cbBloodGroup.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBloodGroup.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.cbBloodGroup.FormattingEnabled = true;
            this.cbBloodGroup.Items.AddRange(new object[] {
            "A+",
            "A-",
            "B+",
            "B-",
            "O+",
            "O-",
            "AB+",
            "AB-"});
            this.cbBloodGroup.Location = new System.Drawing.Point(154, 152);
            this.cbBloodGroup.Name = "cbBloodGroup";
            this.cbBloodGroup.Size = new System.Drawing.Size(181, 32);
            this.cbBloodGroup.TabIndex = 35;
            this.cbBloodGroup.ValueMember = "PatientId";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 36);
            this.label4.TabIndex = 34;
            this.label4.Text = "Nhóm máu\r\n(Không bắt buộc):";
            // 
            // cbGender
            // 
            this.cbGender.DisplayMember = "Name";
            this.cbGender.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGender.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.cbGender.FormattingEnabled = true;
            this.cbGender.Items.AddRange(new object[] {
            "Nam",
            "Nữ",
            "Khác"});
            this.cbGender.Location = new System.Drawing.Point(154, 108);
            this.cbGender.Name = "cbGender";
            this.cbGender.Size = new System.Drawing.Size(181, 32);
            this.cbGender.TabIndex = 33;
            this.cbGender.ValueMember = "PatientId";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 18);
            this.label3.TabIndex = 29;
            this.label3.Text = "Giới tính:";
            // 
            // grbDoctorInfo
            // 
            this.grbDoctorInfo.Controls.Add(this.cbSelectDoctor);
            this.grbDoctorInfo.Controls.Add(this.label11);
            this.grbDoctorInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbDoctorInfo.Location = new System.Drawing.Point(12, 361);
            this.grbDoctorInfo.Name = "grbDoctorInfo";
            this.grbDoctorInfo.Size = new System.Drawing.Size(341, 82);
            this.grbDoctorInfo.TabIndex = 39;
            this.grbDoctorInfo.TabStop = false;
            this.grbDoctorInfo.Text = "Thông tin bác sĩ";
            // 
            // cbSelectDoctor
            // 
            this.cbSelectDoctor.DisplayMember = "Name";
            this.cbSelectDoctor.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSelectDoctor.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.cbSelectDoctor.FormattingEnabled = true;
            this.cbSelectDoctor.Location = new System.Drawing.Point(154, 25);
            this.cbSelectDoctor.Name = "cbSelectDoctor";
            this.cbSelectDoctor.Size = new System.Drawing.Size(181, 32);
            this.cbSelectDoctor.TabIndex = 33;
            this.cbSelectDoctor.ValueMember = "PatientId";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(22, 39);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 18);
            this.label11.TabIndex = 28;
            this.label11.Text = "Tên bác sĩ:";
            // 
            // grbSchedule
            // 
            this.grbSchedule.Controls.Add(this.cbAppointmentTime);
            this.grbSchedule.Controls.Add(this.label7);
            this.grbSchedule.Controls.Add(this.dtpAppointmentDate);
            this.grbSchedule.Controls.Add(this.label2);
            this.grbSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbSchedule.Location = new System.Drawing.Point(361, 117);
            this.grbSchedule.Name = "grbSchedule";
            this.grbSchedule.Size = new System.Drawing.Size(367, 112);
            this.grbSchedule.TabIndex = 40;
            this.grbSchedule.TabStop = false;
            this.grbSchedule.Text = "Thông tin lịch hẹn";
            // 
            // cbAppointmentTime
            // 
            this.cbAppointmentTime.DisplayMember = "Name";
            this.cbAppointmentTime.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAppointmentTime.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.cbAppointmentTime.FormattingEnabled = true;
            this.cbAppointmentTime.Location = new System.Drawing.Point(131, 63);
            this.cbAppointmentTime.Name = "cbAppointmentTime";
            this.cbAppointmentTime.Size = new System.Drawing.Size(181, 32);
            this.cbAppointmentTime.TabIndex = 39;
            this.cbAppointmentTime.ValueMember = "PatientId";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(22, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 18);
            this.label7.TabIndex = 40;
            this.label7.Text = "Giờ hẹn:";
            // 
            // dtpAppointmentDate
            // 
            this.dtpAppointmentDate.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtpAppointmentDate.CalendarTitleForeColor = System.Drawing.SystemColors.WindowFrame;
            this.dtpAppointmentDate.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAppointmentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAppointmentDate.Location = new System.Drawing.Point(133, 23);
            this.dtpAppointmentDate.Name = "dtpAppointmentDate";
            this.dtpAppointmentDate.Size = new System.Drawing.Size(181, 32);
            this.dtpAppointmentDate.TabIndex = 39;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 18);
            this.label2.TabIndex = 28;
            this.label2.Text = "Ngày hẹn:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lsvSymptom);
            this.groupBox1.Controls.Add(this.btnAddSymptom);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtOtherSymptom);
            this.groupBox1.Controls.Add(this.cbSymptom);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(736, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(425, 200);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin triệu chứng";
            // 
            // lsvSymptom
            // 
            this.lsvSymptom.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Serial,
            this.symptomName});
            this.lsvSymptom.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvSymptom.FullRowSelect = true;
            this.lsvSymptom.GridLines = true;
            this.lsvSymptom.HideSelection = false;
            this.lsvSymptom.Location = new System.Drawing.Point(254, 11);
            this.lsvSymptom.Name = "lsvSymptom";
            this.lsvSymptom.Size = new System.Drawing.Size(157, 177);
            this.lsvSymptom.TabIndex = 42;
            this.lsvSymptom.UseCompatibleStateImageBehavior = false;
            this.lsvSymptom.View = System.Windows.Forms.View.Details;
            this.lsvSymptom.DoubleClick += new System.EventHandler(this.lsvtSymptom_DoubleClick);
            // 
            // Serial
            // 
            this.Serial.Text = "STT";
            this.Serial.Width = 50;
            // 
            // symptomName
            // 
            this.symptomName.Text = "Triệu chứng";
            this.symptomName.Width = 120;
            // 
            // btnAddSymptom
            // 
            this.btnAddSymptom.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddSymptom.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSymptom.ForeColor = System.Drawing.Color.White;
            this.btnAddSymptom.Location = new System.Drawing.Point(6, 150);
            this.btnAddSymptom.Name = "btnAddSymptom";
            this.btnAddSymptom.Size = new System.Drawing.Size(238, 38);
            this.btnAddSymptom.TabIndex = 42;
            this.btnAddSymptom.Text = "THÊM TRIỆU CHỨNG";
            this.btnAddSymptom.UseVisualStyleBackColor = false;
            this.btnAddSymptom.Click += new System.EventHandler(this.btnAddSymptom_Click_1);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 18);
            this.label9.TabIndex = 35;
            this.label9.Text = "Triệu chứng khác:";
            // 
            // txtOtherSymptom
            // 
            this.txtOtherSymptom.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOtherSymptom.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtOtherSymptom.Location = new System.Drawing.Point(6, 98);
            this.txtOtherSymptom.Multiline = true;
            this.txtOtherSymptom.Name = "txtOtherSymptom";
            this.txtOtherSymptom.Size = new System.Drawing.Size(238, 43);
            this.txtOtherSymptom.TabIndex = 34;
            // 
            // cbSymptom
            // 
            this.cbSymptom.DisplayMember = "Name";
            this.cbSymptom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.cbSymptom.Location = new System.Drawing.Point(107, 23);
            this.cbSymptom.Name = "cbSymptom";
            this.cbSymptom.Size = new System.Drawing.Size(137, 32);
            this.cbSymptom.TabIndex = 33;
            this.cbSymptom.ValueMember = "PatientId";
            this.cbSymptom.SelectedValueChanged += new System.EventHandler(this.cbSymptom_SelectedValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 18);
            this.label8.TabIndex = 28;
            this.label8.Text = "Triệu chứng:";
            // 
            // btnBook
            // 
            this.btnBook.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBook.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBook.ForeColor = System.Drawing.Color.White;
            this.btnBook.Location = new System.Drawing.Point(12, 597);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(131, 48);
            this.btnBook.TabIndex = 41;
            this.btnBook.Text = "ĐẶT LỊCH";
            this.btnBook.UseVisualStyleBackColor = false;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnEdit.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(149, 597);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(131, 48);
            this.btnEdit.TabIndex = 44;
            this.btnEdit.Text = "SỬA";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Crimson;
            this.btnDelete.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(286, 597);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(131, 48);
            this.btnDelete.TabIndex = 45;
            this.btnDelete.Text = "XÓA";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAppointmentList
            // 
            this.btnAppointmentList.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAppointmentList.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAppointmentList.ForeColor = System.Drawing.Color.White;
            this.btnAppointmentList.Location = new System.Drawing.Point(423, 597);
            this.btnAppointmentList.Name = "btnAppointmentList";
            this.btnAppointmentList.Size = new System.Drawing.Size(253, 48);
            this.btnAppointmentList.TabIndex = 46;
            this.btnAppointmentList.Text = "XEM DANH SÁCH ĐÃ ĐẶT LỊCH";
            this.btnAppointmentList.UseVisualStyleBackColor = false;
            this.btnAppointmentList.Click += new System.EventHandler(this.btnAppointmentList_Click_1);
            // 
            // AppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 647);
            this.Controls.Add(this.btnAppointmentList);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnBook);
            this.Controls.Add(this.grbSchedule);
            this.Controls.Add(this.grbDoctorInfo);
            this.Controls.Add(this.grbPatientInfo);
            this.Controls.Add(this.lsvAppointment);
            this.Controls.Add(this.pictureBoxLogout);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AppointmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "s";
            this.Load += new System.EventHandler(this.AppointmentForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogout)).EndInit();
            this.grbPatientInfo.ResumeLayout(false);
            this.grbPatientInfo.PerformLayout();
            this.grbDoctorInfo.ResumeLayout(false);
            this.grbDoctorInfo.PerformLayout();
            this.grbSchedule.ResumeLayout(false);
            this.grbSchedule.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblAppointment;
        private System.Windows.Forms.Label labelClinicManagement;
        private System.Windows.Forms.PictureBox pictureBoxLogout;
        private System.Windows.Forms.ListView lsvAppointment;
        private System.Windows.Forms.ColumnHeader patientName;
        private System.Windows.Forms.ColumnHeader DOB;
        private System.Windows.Forms.ColumnHeader gender;
        private System.Windows.Forms.ColumnHeader bloodGroup;
        private System.Windows.Forms.ColumnHeader contact;
        private System.Windows.Forms.ColumnHeader appointmentId;
        private System.Windows.Forms.TextBox txtPatientName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grbPatientInfo;
        private System.Windows.Forms.ComboBox cbGender;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbBloodGroup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpAge;
        private System.Windows.Forms.GroupBox grbDoctorInfo;
        private System.Windows.Forms.ComboBox cbSelectDoctor;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox grbSchedule;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpAppointmentDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ColumnHeader doctorName;
        private System.Windows.Forms.ColumnHeader appointmentDate;
        private System.Windows.Forms.ColumnHeader appointmentTime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbSymptom;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtOtherSymptom;
        private System.Windows.Forms.ColumnHeader symptom;
        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.Button btnAddSymptom;
        private System.Windows.Forms.ListView lsvSymptom;
        private System.Windows.Forms.ColumnHeader Serial;
        private System.Windows.Forms.ColumnHeader symptomName;
        private System.Windows.Forms.ComboBox cbAppointmentTime;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAppointmentList;
    }
}