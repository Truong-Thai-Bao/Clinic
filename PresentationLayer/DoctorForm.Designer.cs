namespace PresentationLayer
{
    partial class DoctorForm
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
            this.txtUserLogin = new System.Windows.Forms.TextBox();
            this.txtDocId = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.doctorDataGridView = new System.Windows.Forms.DataGridView();
            this.pictureBoxLogout = new System.Windows.Forms.PictureBox();
            this.chkFiveLoginPermission = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.txtYOE = new System.Windows.Forms.TextBox();
            this.txtDocName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.doctorDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogout)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUserLogin
            // 
            this.txtUserLogin.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserLogin.Location = new System.Drawing.Point(261, 522);
            this.txtUserLogin.Name = "txtUserLogin";
            this.txtUserLogin.Size = new System.Drawing.Size(243, 40);
            this.txtUserLogin.TabIndex = 25;
            this.txtUserLogin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDocId
            // 
            this.txtDocId.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocId.Location = new System.Drawing.Point(12, 522);
            this.txtDocId.Name = "txtDocId";
            this.txtDocId.Size = new System.Drawing.Size(243, 40);
            this.txtDocId.TabIndex = 24;
            this.txtDocId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAge
            // 
            this.txtAge.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAge.Location = new System.Drawing.Point(130, 174);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(125, 40);
            this.txtAge.TabIndex = 10;
            this.txtAge.Text = "AGE";
            this.txtAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAge_KeyPress);
            // 
            // doctorDataGridView
            // 
            this.doctorDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.doctorDataGridView.Location = new System.Drawing.Point(261, 174);
            this.doctorDataGridView.Name = "doctorDataGridView";
            this.doctorDataGridView.RowHeadersWidth = 51;
            this.doctorDataGridView.RowTemplate.Height = 24;
            this.doctorDataGridView.Size = new System.Drawing.Size(527, 332);
            this.doctorDataGridView.TabIndex = 22;
            this.doctorDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.doctorDataGridView_CellDoubleClick);
            this.doctorDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.doctorDataGridView_CellFormatting);
            // 
            // pictureBoxLogout
            // 
            this.pictureBoxLogout.Location = new System.Drawing.Point(738, 512);
            this.pictureBoxLogout.Name = "pictureBoxLogout";
            this.pictureBoxLogout.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxLogout.TabIndex = 21;
            this.pictureBoxLogout.TabStop = false;
            this.pictureBoxLogout.Click += new System.EventHandler(this.pictureBoxLogout_Click);
            // 
            // chkFiveLoginPermission
            // 
            this.chkFiveLoginPermission.AutoSize = true;
            this.chkFiveLoginPermission.BackColor = System.Drawing.Color.MintCream;
            this.chkFiveLoginPermission.ForeColor = System.Drawing.Color.DarkCyan;
            this.chkFiveLoginPermission.Location = new System.Drawing.Point(623, 131);
            this.chkFiveLoginPermission.Name = "chkFiveLoginPermission";
            this.chkFiveLoginPermission.Size = new System.Drawing.Size(170, 20);
            this.chkFiveLoginPermission.TabIndex = 20;
            this.chkFiveLoginPermission.Text = "Give Login Permission?";
            this.chkFiveLoginPermission.UseVisualStyleBackColor = false;
            this.chkFiveLoginPermission.CheckedChanged += new System.EventHandler(this.chkFiveLoginPermission_CheckedChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(442, 122);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(175, 32);
            this.txtPassword.TabIndex = 19;
            this.txtPassword.Text = "Password";
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(261, 122);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(175, 32);
            this.txtUserName.TabIndex = 18;
            this.txtUserName.Text = "Username";
            this.txtUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Crimson;
            this.btnDelete.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(12, 468);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(243, 38);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.DarkCyan;
            this.btnEdit.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(143, 424);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(112, 38);
            this.btnEdit.TabIndex = 16;
            this.btnEdit.Text = "EDIT";
            this.btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkCyan;
            this.btnSave.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(12, 424);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 38);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.MintCream;
            this.txtAddress.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(6, 297);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(243, 121);
            this.txtAddress.TabIndex = 13;
            this.txtAddress.Text = "ADDRESS";
            this.txtAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtContact
            // 
            this.txtContact.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContact.Location = new System.Drawing.Point(12, 237);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(243, 40);
            this.txtContact.TabIndex = 11;
            this.txtContact.Text = "CONTACT";
            this.txtContact.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtYOE
            // 
            this.txtYOE.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYOE.Location = new System.Drawing.Point(12, 174);
            this.txtYOE.Name = "txtYOE";
            this.txtYOE.Size = new System.Drawing.Size(112, 40);
            this.txtYOE.TabIndex = 9;
            this.txtYOE.Text = "YOE";
            this.txtYOE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtYOE.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtYOE_KeyPress);
            // 
            // txtDocName
            // 
            this.txtDocName.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocName.Location = new System.Drawing.Point(12, 122);
            this.txtDocName.Name = "txtDocName";
            this.txtDocName.Size = new System.Drawing.Size(243, 40);
            this.txtDocName.TabIndex = 8;
            this.txtDocName.Text = "DOC NAME";
            this.txtDocName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkCyan;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.AliceBlue;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(800, 100);
            this.label1.TabIndex = 7;
            this.label1.Text = "CLINIC MANAGEMENT SYSTEM\r\nDOCTOR\r\n\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DoctorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(800, 574);
            this.Controls.Add(this.txtUserLogin);
            this.Controls.Add(this.txtDocId);
            this.Controls.Add(this.doctorDataGridView);
            this.Controls.Add(this.pictureBoxLogout);
            this.Controls.Add(this.chkFiveLoginPermission);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.txtYOE);
            this.Controls.Add(this.txtDocName);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.MintCream;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DoctorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DoctorForm";
            this.Load += new System.EventHandler(this.DoctorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.doctorDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUserLogin;
        private System.Windows.Forms.TextBox txtDocId;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.DataGridView doctorDataGridView;
        private System.Windows.Forms.PictureBox pictureBoxLogout;
        private System.Windows.Forms.CheckBox chkFiveLoginPermission;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.TextBox txtYOE;
        private System.Windows.Forms.TextBox txtDocName;
        private System.Windows.Forms.Label label1;
    }
}