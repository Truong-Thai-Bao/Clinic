﻿namespace PresentationLayer
{
    partial class DoctorPrescriptionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoctorPrescriptionForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelClinicManagement = new System.Windows.Forms.Label();
            this.pictureBoxLogout = new System.Windows.Forms.PictureBox();
            this.cbPatientCode = new System.Windows.Forms.ComboBox();
            this.btnViewPrescription = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnViewInvoice = new System.Windows.Forms.Button();
            this.printDocumentPrescription = new System.Drawing.Printing.PrintDocument();
            this.printPreviewPrescription = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocumentInvoice = new System.Drawing.Printing.PrintDocument();
            this.printPreviewInvoice = new System.Windows.Forms.PrintPreviewDialog();
            this.panel1.SuspendLayout();
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
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 100);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DodgerBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.AliceBlue;
            this.label1.Location = new System.Drawing.Point(249, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 29);
            this.label1.TabIndex = 10;
            this.label1.Text = "ĐƠN THUỐC BỆNH NHÂN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.pictureBoxLogout.Location = new System.Drawing.Point(738, 512);
            this.pictureBoxLogout.Name = "pictureBoxLogout";
            this.pictureBoxLogout.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxLogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogout.TabIndex = 14;
            this.pictureBoxLogout.TabStop = false;
            this.pictureBoxLogout.Click += new System.EventHandler(this.pictureBoxLogout_Click);
            // 
            // cbPatientCode
            // 
            this.cbPatientCode.BackColor = System.Drawing.Color.MintCream;
            this.cbPatientCode.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPatientCode.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.cbPatientCode.FormattingEnabled = true;
            this.cbPatientCode.Items.AddRange(new object[] {
            "A+",
            "A-",
            "B+",
            "B-",
            "O+",
            "O-",
            "AB+",
            "AB-"});
            this.cbPatientCode.Location = new System.Drawing.Point(207, 267);
            this.cbPatientCode.Name = "cbPatientCode";
            this.cbPatientCode.Size = new System.Drawing.Size(348, 41);
            this.cbPatientCode.TabIndex = 25;
            // 
            // btnViewPrescription
            // 
            this.btnViewPrescription.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnViewPrescription.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewPrescription.ForeColor = System.Drawing.Color.White;
            this.btnViewPrescription.Location = new System.Drawing.Point(212, 324);
            this.btnViewPrescription.Name = "btnViewPrescription";
            this.btnViewPrescription.Size = new System.Drawing.Size(169, 38);
            this.btnViewPrescription.TabIndex = 33;
            this.btnViewPrescription.Text = "XEM ĐƠN THUỐC";
            this.btnViewPrescription.UseVisualStyleBackColor = false;
            this.btnViewPrescription.Click += new System.EventHandler(this.btnViewPrescription_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.MintCream;
            this.label2.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(207, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 28);
            this.label2.TabIndex = 11;
            this.label2.Text = "MÃ BỆNH NHÂN";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnViewInvoice
            // 
            this.btnViewInvoice.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnViewInvoice.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewInvoice.ForeColor = System.Drawing.Color.White;
            this.btnViewInvoice.Location = new System.Drawing.Point(387, 324);
            this.btnViewInvoice.Name = "btnViewInvoice";
            this.btnViewInvoice.Size = new System.Drawing.Size(168, 38);
            this.btnViewInvoice.TabIndex = 34;
            this.btnViewInvoice.Text = "XEM HÓA ĐƠN";
            this.btnViewInvoice.UseVisualStyleBackColor = false;
            this.btnViewInvoice.Click += new System.EventHandler(this.btnViewInvoice_Click);
            // 
            // printPreviewPrescription
            // 
            this.printPreviewPrescription.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewPrescription.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewPrescription.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewPrescription.Enabled = true;
            this.printPreviewPrescription.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewPrescription.Icon")));
            this.printPreviewPrescription.Name = "printPreviewPrescription";
            this.printPreviewPrescription.Visible = false;
            //this.printPreviewPrescription.Load += new System.EventHandler(this.printPreviewPrescription_Load);//
            // 
            // printDocumentInvoice
            // 
            this.printDocumentInvoice.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocumentInvoice_PrintPage);
            // 
            // printPreviewInvoice
            // 
            this.printPreviewInvoice.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewInvoice.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewInvoice.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewInvoice.Enabled = true;
            this.printPreviewInvoice.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewInvoice.Icon")));
            this.printPreviewInvoice.Name = "printPreviewInvoice";
            this.printPreviewInvoice.Visible = false;
            //this.printPreviewInvoice.Load += new System.EventHandler(this.printPreviewInvoice_Load);//
            // 
            // DoctorPrescriptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(800, 574);
            this.Controls.Add(this.btnViewInvoice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnViewPrescription);
            this.Controls.Add(this.cbPatientCode);
            this.Controls.Add(this.pictureBoxLogout);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.MintCream;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DoctorPrescriptionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DoctorPrescriptionForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelClinicManagement;
        private System.Windows.Forms.PictureBox pictureBoxLogout;
        private System.Windows.Forms.ComboBox cbPatientCode;
        private System.Windows.Forms.Button btnViewPrescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnViewInvoice;
        private System.Drawing.Printing.PrintDocument printDocumentPrescription;
        //private System.Windows.Forms.PrintPreviewDialog printPreviewPrescription;
        private System.Drawing.Printing.PrintDocument printDocumentInvoice;
       // private System.Windows.Forms.PrintPreviewDialog printPreviewInvoice;
    }
}