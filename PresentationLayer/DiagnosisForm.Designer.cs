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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelClinicManagement = new System.Windows.Forms.Label();
            this.pictureBoxLogout = new System.Windows.Forms.PictureBox();
            this.cbPatients = new System.Windows.Forms.ComboBox();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.txtPatientCode = new System.Windows.Forms.TextBox();
            this.symptomDataGridView = new System.Windows.Forms.DataGridView();
            this.txtBlood = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.txtGender = new System.Windows.Forms.TextBox();
            this.txtMedicine = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.medicineDataGridView = new System.Windows.Forms.DataGridView();
            this.Serial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MedicineName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPatientId = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.symptomDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medicineDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkCyan;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.labelClinicManagement);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 100);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkCyan;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.AliceBlue;
            this.label1.Location = new System.Drawing.Point(328, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 29);
            this.label1.TabIndex = 10;
            this.label1.Text = "DIAGNOSIS";
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
            // pictureBoxLogout
            // 
            this.pictureBoxLogout.Location = new System.Drawing.Point(738, 512);
            this.pictureBoxLogout.Name = "pictureBoxLogout";
            this.pictureBoxLogout.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxLogout.TabIndex = 23;
            this.pictureBoxLogout.TabStop = false;
            this.pictureBoxLogout.Click += new System.EventHandler(this.pictureBoxLogout_Click);
            // 
            // cbPatients
            // 
            this.cbPatients.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPatients.FormattingEnabled = true;
            this.cbPatients.Items.AddRange(new object[] {
            "A+",
            "A-",
            "B+",
            "B-",
            "O+",
            "O-",
            "AB+",
            "AB-"});
            this.cbPatients.Location = new System.Drawing.Point(12, 125);
            this.cbPatients.Name = "cbPatients";
            this.cbPatients.Size = new System.Drawing.Size(243, 41);
            this.cbPatients.TabIndex = 24;
            this.cbPatients.Text = "PATIENTS";
            this.cbPatients.SelectedValueChanged += new System.EventHandler(this.cbPatients_SelectedValueChanged);
            // 
            // txtContact
            // 
            this.txtContact.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContact.Location = new System.Drawing.Point(12, 172);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(243, 40);
            this.txtContact.TabIndex = 25;
            this.txtContact.Text = "CONTACT";
            this.txtContact.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPatientCode
            // 
            this.txtPatientCode.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatientCode.Location = new System.Drawing.Point(12, 218);
            this.txtPatientCode.Name = "txtPatientCode";
            this.txtPatientCode.Size = new System.Drawing.Size(243, 40);
            this.txtPatientCode.TabIndex = 26;
            this.txtPatientCode.Text = "PATIENT CODE";
            this.txtPatientCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // symptomDataGridView
            // 
            this.symptomDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.symptomDataGridView.Location = new System.Drawing.Point(15, 264);
            this.symptomDataGridView.Name = "symptomDataGridView";
            this.symptomDataGridView.RowHeadersWidth = 51;
            this.symptomDataGridView.RowTemplate.Height = 24;
            this.symptomDataGridView.Size = new System.Drawing.Size(240, 236);
            this.symptomDataGridView.TabIndex = 27;
            // 
            // txtBlood
            // 
            this.txtBlood.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBlood.Location = new System.Drawing.Point(276, 126);
            this.txtBlood.Name = "txtBlood";
            this.txtBlood.Size = new System.Drawing.Size(125, 40);
            this.txtBlood.TabIndex = 28;
            this.txtBlood.Text = "BLOOD";
            this.txtBlood.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAge
            // 
            this.txtAge.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAge.Location = new System.Drawing.Point(407, 126);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(125, 40);
            this.txtAge.TabIndex = 29;
            this.txtAge.Text = "AGE";
            this.txtAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtGender
            // 
            this.txtGender.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGender.Location = new System.Drawing.Point(538, 126);
            this.txtGender.Name = "txtGender";
            this.txtGender.Size = new System.Drawing.Size(226, 40);
            this.txtGender.TabIndex = 30;
            this.txtGender.Text = "GENDER";
            this.txtGender.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMedicine
            // 
            this.txtMedicine.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMedicine.Location = new System.Drawing.Point(276, 172);
            this.txtMedicine.Name = "txtMedicine";
            this.txtMedicine.Size = new System.Drawing.Size(256, 40);
            this.txtMedicine.TabIndex = 31;
            this.txtMedicine.Text = "MEDICINE";
            this.txtMedicine.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.DarkCyan;
            this.btnAdd.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(538, 174);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(113, 38);
            this.btnAdd.TabIndex = 32;
            this.btnAdd.Text = "ADD";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkCyan;
            this.btnSave.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(651, 174);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(113, 38);
            this.btnSave.TabIndex = 33;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // medicineDataGridView
            // 
            this.medicineDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.medicineDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Serial,
            this.MedicineName});
            this.medicineDataGridView.Location = new System.Drawing.Point(276, 218);
            this.medicineDataGridView.Name = "medicineDataGridView";
            this.medicineDataGridView.RowHeadersWidth = 51;
            this.medicineDataGridView.RowTemplate.Height = 24;
            this.medicineDataGridView.Size = new System.Drawing.Size(488, 282);
            this.medicineDataGridView.TabIndex = 34;
            this.medicineDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.medicineDataGridView_CellContentClick);
            this.medicineDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.medicineDataGridView_CellDoubleClick);
            // 
            // Serial
            // 
            this.Serial.HeaderText = "Serial";
            this.Serial.MinimumWidth = 6;
            this.Serial.Name = "Serial";
            this.Serial.Width = 125;
            // 
            // MedicineName
            // 
            this.MedicineName.HeaderText = "Medicine Name";
            this.MedicineName.MinimumWidth = 6;
            this.MedicineName.Name = "MedicineName";
            this.MedicineName.Width = 250;
            // 
            // txtPatientId
            // 
            this.txtPatientId.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatientId.ForeColor = System.Drawing.Color.Teal;
            this.txtPatientId.Location = new System.Drawing.Point(15, 512);
            this.txtPatientId.Name = "txtPatientId";
            this.txtPatientId.ReadOnly = true;
            this.txtPatientId.Size = new System.Drawing.Size(240, 40);
            this.txtPatientId.TabIndex = 35;
            this.txtPatientId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPatientId.Visible = false;
            // 
            // DiagnosisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(800, 574);
            this.Controls.Add(this.txtPatientId);
            this.Controls.Add(this.medicineDataGridView);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtMedicine);
            this.Controls.Add(this.txtGender);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.txtBlood);
            this.Controls.Add(this.symptomDataGridView);
            this.Controls.Add(this.txtPatientCode);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.cbPatients);
            this.Controls.Add(this.pictureBoxLogout);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.MintCream;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DiagnosisForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DiagnosisForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.symptomDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medicineDataGridView)).EndInit();
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
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.TextBox txtGender;
        private System.Windows.Forms.TextBox txtMedicine;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView medicineDataGridView;
        private System.Windows.Forms.TextBox txtPatientId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serial;
        private System.Windows.Forms.DataGridViewTextBoxColumn MedicineName;
    }
}