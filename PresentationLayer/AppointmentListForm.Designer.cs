namespace PresentationLayer
{
    partial class AppointmentListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppointmentListForm));
            this.lsvAppointmentList = new System.Windows.Forms.ListView();
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
            this.status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkFilterByDate = new System.Windows.Forms.CheckBox();
            this.dtpDateFilter = new System.Windows.Forms.DateTimePicker();
            this.chkFilterByDoctor = new System.Windows.Forms.CheckBox();
            this.cbDoctorFilter = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAppointment = new System.Windows.Forms.Label();
            this.labelClinicManagement = new System.Windows.Forms.Label();
            this.pictureBoxLogout = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogout)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsvAppointmentList
            // 
            this.lsvAppointmentList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.appointmentId,
            this.patientName,
            this.DOB,
            this.gender,
            this.bloodGroup,
            this.contact,
            this.doctorName,
            this.appointmentDate,
            this.appointmentTime,
            this.symptom,
            this.status});
            this.lsvAppointmentList.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvAppointmentList.FullRowSelect = true;
            this.lsvAppointmentList.GridLines = true;
            this.lsvAppointmentList.HideSelection = false;
            this.lsvAppointmentList.Location = new System.Drawing.Point(54, 319);
            this.lsvAppointmentList.Name = "lsvAppointmentList";
            this.lsvAppointmentList.Size = new System.Drawing.Size(1066, 246);
            this.lsvAppointmentList.TabIndex = 26;
            this.lsvAppointmentList.UseCompatibleStateImageBehavior = false;
            this.lsvAppointmentList.View = System.Windows.Forms.View.Details;
            // 
            // appointmentId
            // 
            this.appointmentId.Text = "STT";
            this.appointmentId.Width = 50;
            // 
            // patientName
            // 
            this.patientName.Text = "Tên bệnh nhân";
            this.patientName.Width = 119;
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
            // status
            // 
            this.status.Text = "Tình trạng";
            this.status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkFilterByDate);
            this.groupBox1.Controls.Add(this.dtpDateFilter);
            this.groupBox1.Controls.Add(this.chkFilterByDoctor);
            this.groupBox1.Controls.Add(this.cbDoctorFilter);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(54, 125);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(456, 117);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lọc";
            // 
            // chkFilterByDate
            // 
            this.chkFilterByDate.AutoSize = true;
            this.chkFilterByDate.Location = new System.Drawing.Point(249, 25);
            this.chkFilterByDate.Name = "chkFilterByDate";
            this.chkFilterByDate.Size = new System.Drawing.Size(151, 22);
            this.chkFilterByDate.TabIndex = 48;
            this.chkFilterByDate.Text = "Lọc theo ngày hẹn";
            this.chkFilterByDate.UseVisualStyleBackColor = true;
            this.chkFilterByDate.CheckedChanged += new System.EventHandler(this.chkFilterByDate_CheckedChanged);
            // 
            // dtpDateFilter
            // 
            this.dtpDateFilter.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtpDateFilter.CalendarTitleForeColor = System.Drawing.SystemColors.WindowFrame;
            this.dtpDateFilter.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateFilter.Location = new System.Drawing.Point(249, 53);
            this.dtpDateFilter.Name = "dtpDateFilter";
            this.dtpDateFilter.Size = new System.Drawing.Size(181, 32);
            this.dtpDateFilter.TabIndex = 40;
            this.dtpDateFilter.ValueChanged += new System.EventHandler(this.dtpDateFilter_ValueChanged);
            // 
            // chkFilterByDoctor
            // 
            this.chkFilterByDoctor.AutoSize = true;
            this.chkFilterByDoctor.Location = new System.Drawing.Point(26, 23);
            this.chkFilterByDoctor.Name = "chkFilterByDoctor";
            this.chkFilterByDoctor.Size = new System.Drawing.Size(131, 22);
            this.chkFilterByDoctor.TabIndex = 47;
            this.chkFilterByDoctor.Text = "Lọc theo bác sĩ";
            this.chkFilterByDoctor.UseVisualStyleBackColor = true;
            this.chkFilterByDoctor.CheckedChanged += new System.EventHandler(this.chkFilterByDoctor_CheckedChanged);
            // 
            // cbDoctorFilter
            // 
            this.cbDoctorFilter.DisplayMember = "Name";
            this.cbDoctorFilter.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDoctorFilter.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.cbDoctorFilter.FormattingEnabled = true;
            this.cbDoctorFilter.Location = new System.Drawing.Point(26, 53);
            this.cbDoctorFilter.Name = "cbDoctorFilter";
            this.cbDoctorFilter.Size = new System.Drawing.Size(181, 32);
            this.cbDoctorFilter.TabIndex = 33;
            this.cbDoctorFilter.ValueMember = "PatientId";
            this.cbDoctorFilter.SelectedIndexChanged += new System.EventHandler(this.cbDoctorFilter_SelectedIndexChanged);
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
            this.panel1.TabIndex = 45;
            // 
            // lblAppointment
            // 
            this.lblAppointment.AutoSize = true;
            this.lblAppointment.BackColor = System.Drawing.Color.DodgerBlue;
            this.lblAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppointment.ForeColor = System.Drawing.Color.AliceBlue;
            this.lblAppointment.Location = new System.Drawing.Point(436, 52);
            this.lblAppointment.Name = "lblAppointment";
            this.lblAppointment.Size = new System.Drawing.Size(302, 29);
            this.lblAppointment.TabIndex = 10;
            this.lblAppointment.Text = "DANH SÁCH ĐÃ ĐẶT LỊCH";
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
            this.pictureBoxLogout.TabIndex = 46;
            this.pictureBoxLogout.TabStop = false;
            this.pictureBoxLogout.Click += new System.EventHandler(this.pictureBoxLogout_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblSearch);
            this.groupBox2.Controls.Add(this.txtSearch);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(531, 125);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(361, 117);
            this.groupBox2.TabIndex = 49;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm kiếm";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(27, 29);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(254, 18);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "Tìm kiếm bằng tên hoặc số điện thoại";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(30, 55);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(294, 30);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Crimson;
            this.btnDelete.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(54, 587);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(131, 48);
            this.btnDelete.TabIndex = 51;
            this.btnDelete.Text = "XÓA";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // AppointmentListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 647);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pictureBoxLogout);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lsvAppointmentList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AppointmentListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AppointmentListForm";
            this.Load += new System.EventHandler(this.AppointmentListForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogout)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView lsvAppointmentList;
        private System.Windows.Forms.ColumnHeader appointmentId;
        private System.Windows.Forms.ColumnHeader patientName;
        private System.Windows.Forms.ColumnHeader DOB;
        private System.Windows.Forms.ColumnHeader gender;
        private System.Windows.Forms.ColumnHeader bloodGroup;
        private System.Windows.Forms.ColumnHeader contact;
        private System.Windows.Forms.ColumnHeader doctorName;
        private System.Windows.Forms.ColumnHeader appointmentDate;
        private System.Windows.Forms.ColumnHeader appointmentTime;
        private System.Windows.Forms.ColumnHeader symptom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpDateFilter;
        private System.Windows.Forms.ComboBox cbDoctorFilter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblAppointment;
        private System.Windows.Forms.Label labelClinicManagement;
        private System.Windows.Forms.PictureBox pictureBoxLogout;
        private System.Windows.Forms.ColumnHeader status;
        private System.Windows.Forms.CheckBox chkFilterByDoctor;
        private System.Windows.Forms.CheckBox chkFilterByDate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnDelete;
    }
}