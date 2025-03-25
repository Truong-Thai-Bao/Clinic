﻿namespace PresentationLayer
{
    partial class MenuForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBoxDoctors = new System.Windows.Forms.PictureBox();
            this.pictureBoxPatients = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBoxDiagnosis = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBoxLogout = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelClinicManagement = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDoctors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPatients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDiagnosis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogout)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkCyan;
            this.label1.Location = new System.Drawing.Point(159, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(483, 32);
            this.label1.TabIndex = 6;
            this.label1.Text = "VUI LÒNG CHỌN MỘT TÙY CHỌN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkCyan;
            this.label2.Location = new System.Drawing.Point(102, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "BÁC SĨ";
            // 
            // pictureBoxDoctors
            // 
            this.pictureBoxDoctors.Location = new System.Drawing.Point(44, 226);
            this.pictureBoxDoctors.Name = "pictureBoxDoctors";
            this.pictureBoxDoctors.Size = new System.Drawing.Size(200, 200);
            this.pictureBoxDoctors.TabIndex = 8;
            this.pictureBoxDoctors.TabStop = false;
            this.pictureBoxDoctors.Click += new System.EventHandler(this.pictureBoxDoctors_Click);
            // 
            // pictureBoxPatients
            // 
            this.pictureBoxPatients.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pictureBoxPatients.Location = new System.Drawing.Point(300, 226);
            this.pictureBoxPatients.Name = "pictureBoxPatients";
            this.pictureBoxPatients.Size = new System.Drawing.Size(200, 200);
            this.pictureBoxPatients.TabIndex = 10;
            this.pictureBoxPatients.TabStop = false;
            this.pictureBoxPatients.Click += new System.EventHandler(this.pictureBoxPatients_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkCyan;
            this.label3.Location = new System.Drawing.Point(332, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "BỆNH NHÂN";
            // 
            // pictureBoxDiagnosis
            // 
            this.pictureBoxDiagnosis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxDiagnosis.Location = new System.Drawing.Point(557, 226);
            this.pictureBoxDiagnosis.Name = "pictureBoxDiagnosis";
            this.pictureBoxDiagnosis.Size = new System.Drawing.Size(200, 200);
            this.pictureBoxDiagnosis.TabIndex = 12;
            this.pictureBoxDiagnosis.TabStop = false;
            this.pictureBoxDiagnosis.Click += new System.EventHandler(this.pictureBoxDiagnosis_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkCyan;
            this.label4.Location = new System.Drawing.Point(587, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "CHẨN ĐOÁN";
            // 
            // pictureBoxLogout
            // 
            this.pictureBoxLogout.Location = new System.Drawing.Point(738, 512);
            this.pictureBoxLogout.Name = "pictureBoxLogout";
            this.pictureBoxLogout.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxLogout.TabIndex = 13;
            this.pictureBoxLogout.TabStop = false;
            this.pictureBoxLogout.Click += new System.EventHandler(this.pictureBoxLogout_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkCyan;
            this.panel1.Controls.Add(this.labelClinicManagement);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 100);
            this.panel1.TabIndex = 32;
            // 
            // labelClinicManagement
            // 
            this.labelClinicManagement.AutoSize = true;
            this.labelClinicManagement.BackColor = System.Drawing.Color.DarkCyan;
            this.labelClinicManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClinicManagement.ForeColor = System.Drawing.Color.AliceBlue;
            this.labelClinicManagement.Location = new System.Drawing.Point(171, 34);
            this.labelClinicManagement.Name = "labelClinicManagement";
            this.labelClinicManagement.Size = new System.Drawing.Size(459, 32);
            this.labelClinicManagement.TabIndex = 9;
            this.labelClinicManagement.Text = "CLINIC MANAGEMENT SYSTEM";
            this.labelClinicManagement.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 574);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBoxLogout);
            this.Controls.Add(this.pictureBoxDiagnosis);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBoxPatients);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBoxDoctors);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuForm";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDoctors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPatients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDiagnosis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogout)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBoxDoctors;
        private System.Windows.Forms.PictureBox pictureBoxPatients;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBoxDiagnosis;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBoxLogout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelClinicManagement;
    }
}