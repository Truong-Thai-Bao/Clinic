namespace PresentationLayer
{
    partial class PatientArrivalForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientArrivalForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoNo = new System.Windows.Forms.RadioButton();
            this.rdoYes = new System.Windows.Forms.RadioButton();
            this.lblAppointment = new System.Windows.Forms.Label();
            this.labelClinicManagement = new System.Windows.Forms.Label();
            this.pictureBoxLogout = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.btnNewAdmission = new System.Windows.Forms.Button();
            this.grbSearch = new System.Windows.Forms.GroupBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
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
            this.btnConfirmation = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogout)).BeginInit();
            this.panel1.SuspendLayout();
            this.grbSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rdoNo);
            this.groupBox1.Controls.Add(this.txtPatientName);
            this.groupBox1.Controls.Add(this.rdoYes);
            this.groupBox1.Controls.Add(this.btnNewAdmission);
            this.groupBox1.Location = new System.Drawing.Point(25, 137);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 117);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kiểm tra đặt lịch";
            // 
            // rdoNo
            // 
            this.rdoNo.AutoSize = true;
            this.rdoNo.Location = new System.Drawing.Point(162, 32);
            this.rdoNo.Name = "rdoNo";
            this.rdoNo.Size = new System.Drawing.Size(104, 20);
            this.rdoNo.TabIndex = 1;
            this.rdoNo.TabStop = true;
            this.rdoNo.Text = "Chưa đặt lịch";
            this.rdoNo.UseVisualStyleBackColor = true;
            this.rdoNo.CheckedChanged += new System.EventHandler(this.rdoNo_CheckedChanged);
            // 
            // rdoYes
            // 
            this.rdoYes.AutoSize = true;
            this.rdoYes.Location = new System.Drawing.Point(6, 32);
            this.rdoYes.Name = "rdoYes";
            this.rdoYes.Size = new System.Drawing.Size(90, 20);
            this.rdoYes.TabIndex = 0;
            this.rdoYes.TabStop = true;
            this.rdoYes.Text = "Đã đặt lịch";
            this.rdoYes.UseVisualStyleBackColor = true;
            this.rdoYes.CheckedChanged += new System.EventHandler(this.rdoYes_CheckedChanged);
            // 
            // lblAppointment
            // 
            this.lblAppointment.AutoSize = true;
            this.lblAppointment.BackColor = System.Drawing.Color.DodgerBlue;
            this.lblAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppointment.ForeColor = System.Drawing.Color.AliceBlue;
            this.lblAppointment.Location = new System.Drawing.Point(280, 52);
            this.lblAppointment.Name = "lblAppointment";
            this.lblAppointment.Size = new System.Drawing.Size(241, 29);
            this.lblAppointment.TabIndex = 10;
            this.lblAppointment.Text = "KIỂM TRA LỊCH HẸN";
            this.lblAppointment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelClinicManagement
            // 
            this.labelClinicManagement.AutoSize = true;
            this.labelClinicManagement.BackColor = System.Drawing.Color.DodgerBlue;
            this.labelClinicManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClinicManagement.ForeColor = System.Drawing.Color.AliceBlue;
            this.labelClinicManagement.Location = new System.Drawing.Point(171, 20);
            this.labelClinicManagement.Name = "labelClinicManagement";
            this.labelClinicManagement.Size = new System.Drawing.Size(459, 32);
            this.labelClinicManagement.TabIndex = 9;
            this.labelClinicManagement.Text = "CLINIC MANAGEMENT SYSTEM";
            this.labelClinicManagement.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxLogout
            // 
            this.pictureBoxLogout.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogout.Image")));
            this.pictureBoxLogout.Location = new System.Drawing.Point(710, 512);
            this.pictureBoxLogout.Name = "pictureBoxLogout";
            this.pictureBoxLogout.Size = new System.Drawing.Size(78, 50);
            this.pictureBoxLogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogout.TabIndex = 28;
            this.pictureBoxLogout.TabStop = false;
            this.pictureBoxLogout.Click += new System.EventHandler(this.pictureBoxLogout_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Controls.Add(this.lblAppointment);
            this.panel1.Controls.Add(this.labelClinicManagement);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 100);
            this.panel1.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, -490);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 18);
            this.label1.TabIndex = 43;
            this.label1.Text = "Tên bệnh nhân:";
            // 
            // txtPatientName
            // 
            this.txtPatientName.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatientName.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtPatientName.Location = new System.Drawing.Point(148, -504);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(181, 32);
            this.txtPatientName.TabIndex = 42;
            // 
            // btnNewAdmission
            // 
            this.btnNewAdmission.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnNewAdmission.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewAdmission.ForeColor = System.Drawing.Color.White;
            this.btnNewAdmission.Location = new System.Drawing.Point(150, 71);
            this.btnNewAdmission.Name = "btnNewAdmission";
            this.btnNewAdmission.Size = new System.Drawing.Size(131, 40);
            this.btnNewAdmission.TabIndex = 44;
            this.btnNewAdmission.Text = "TIẾP NHẬN MỚI";
            this.btnNewAdmission.UseVisualStyleBackColor = false;
            this.btnNewAdmission.Click += new System.EventHandler(this.btnNewAdmission_Click);
            // 
            // grbSearch
            // 
            this.grbSearch.Controls.Add(this.lblSearch);
            this.grbSearch.Controls.Add(this.txtSearch);
            this.grbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbSearch.Location = new System.Drawing.Point(414, 137);
            this.grbSearch.Name = "grbSearch";
            this.grbSearch.Size = new System.Drawing.Size(361, 117);
            this.grbSearch.TabIndex = 50;
            this.grbSearch.TabStop = false;
            this.grbSearch.Text = "Tìm kiếm";
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
            this.lsvAppointmentList.Location = new System.Drawing.Point(25, 274);
            this.lsvAppointmentList.Name = "lsvAppointmentList";
            this.lsvAppointmentList.Size = new System.Drawing.Size(750, 216);
            this.lsvAppointmentList.TabIndex = 51;
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
            // btnConfirmation
            // 
            this.btnConfirmation.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnConfirmation.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmation.ForeColor = System.Drawing.Color.White;
            this.btnConfirmation.Location = new System.Drawing.Point(25, 496);
            this.btnConfirmation.Name = "btnConfirmation";
            this.btnConfirmation.Size = new System.Drawing.Size(168, 40);
            this.btnConfirmation.TabIndex = 45;
            this.btnConfirmation.Text = "XÁC NHẬN ĐÃ ĐẾN";
            this.btnConfirmation.UseVisualStyleBackColor = false;
            this.btnConfirmation.Click += new System.EventHandler(this.btnConfirmation_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Crimson;
            this.btnCancel.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(199, 496);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(168, 40);
            this.btnCancel.TabIndex = 52;
            this.btnCancel.Text = "HỦY HẸN";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // PatientArrivalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 574);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirmation);
            this.Controls.Add(this.lsvAppointmentList);
            this.Controls.Add(this.grbSearch);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBoxLogout);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PatientArrivalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PatientArrivalForm";
            this.Load += new System.EventHandler(this.PatientArrivalForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogout)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grbSearch.ResumeLayout(false);
            this.grbSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoNo;
        private System.Windows.Forms.RadioButton rdoYes;
        private System.Windows.Forms.Label lblAppointment;
        private System.Windows.Forms.Label labelClinicManagement;
        private System.Windows.Forms.PictureBox pictureBoxLogout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPatientName;
        private System.Windows.Forms.Button btnNewAdmission;
        private System.Windows.Forms.GroupBox grbSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
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
        private System.Windows.Forms.ColumnHeader status;
        private System.Windows.Forms.Button btnConfirmation;
        private System.Windows.Forms.Button btnCancel;
    }
}