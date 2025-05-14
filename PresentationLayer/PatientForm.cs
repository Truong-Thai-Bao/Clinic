using BusinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataTransferLayer;

namespace PresentationLayer
{
    public partial class PatientForm : Form
    {
        private DataTransferLayer.UserInfo currentUser;
        private DoctorBL doctorBL;
        private SymptomBL  symptomBL;
        private PatientBL patientBL;
        public PatientForm(DataTransferLayer.UserInfo currentUser)
        {
            InitializeComponent();
            symptomBL = new SymptomBL();
            doctorBL = new DoctorBL();
            patientBL = new PatientBL();
            lblPCodeNum.Text = DateTime.Now.ToString("ddMMhhmmss");
            LoadDoctors();
            this.currentUser = currentUser;
        }

        // Dùng để load danh sách bác sĩ
        private void LoadDoctors()
        {
            try
            {
                List<DoctorDTO> doctors = doctorBL.GetAllDoctors();
                cbSelectDoctor.DisplayMember = "DocName";
                cbSelectDoctor.ValueMember = "DoctorId";
                cbSelectDoctor.DataSource = doctors;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Đã xảy ra lỗi!");
            }
        }


        private void pictureBoxLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuForm form = new MenuForm(currentUser);
            form.Show();
        }

        // Set định dạng các ô trong DataGridView
        private void symptomDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (symptomDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && !string.IsNullOrWhiteSpace(symptomDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
            {
                symptomDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = new DataGridViewCellStyle { ForeColor = Color.Black };
            }
            else
            {
                symptomDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = symptomDataGridView.DefaultCellStyle;
            }
        }

        // Dùng để đặt lại các giá trị trong form
        private void Reset()
        {
            txtPatientId.Text = 0.ToString();
            txtPatientName.Text = "";
            cbBlood.Text = "";
            dtpAge.Format = DateTimePickerFormat.Custom;
            dtpAge.CustomFormat = " ";
            cbGender.Text = "";
            txtContact.Text = "";
            txtAddress.Text = "";
            cbSymptom.Text = "";
            cbBlood.Text = "";
            cbGender.Text = "";
            txtOtherSymptom.Text = "";
            symptomDataGridView.Columns.Clear();
        }

        // Dùng để ẩn/hiện txtOtherSymptom nhập liệu
        private void cbSymptom_SelectedValueChanged(object sender, EventArgs e)
        {
            txtOtherSymptom.Text = "";
            txtOtherSymptom.ReadOnly = true;
            txtOtherSymptom.Enabled = false;
            if(cbSymptom.Text == "Khác")
            {
                txtOtherSymptom.ReadOnly = false;
                txtOtherSymptom.Enabled = true;
            }
        }

        // Dùng để thêm triệu chứng vào DataGridView
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(cbSymptom.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn triệu chứng!");
                cbSymptom.Focus();
            }
            else if (cbSymptom.Text == "Khác" && txtOtherSymptom.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập triệu chứng khác!");
                txtOtherSymptom.Focus();
            }
            else
            {
                string name = cbSymptom.Text;
                if(cbSymptom.Text == "Khác")
                {
                    name = txtOtherSymptom.Text;
                }

                int rowIndex = -1;
                var rowCount = symptomDataGridView.Rows.Count;

                if(rowCount > 1)
                {
                    for (int i=0; i < symptomDataGridView.Rows.Count - 1; i++)
                    {
                        if (symptomDataGridView.Rows[i].Cells["Name"].Value.ToString() == name)
                        {
                            rowIndex = symptomDataGridView.Rows[i].Index;
                            break;
                        }
                    }
                }
                if (rowIndex < 0)
                {
                    rowIndex = symptomDataGridView.Rows.Add();
                }
                symptomDataGridView.Rows[rowIndex].Cells["Serial"].Value = symptomDataGridView.Rows.Count - 1;
                symptomDataGridView.Rows[rowIndex].Cells["Name"].Value = name;
            }
        }

        // Dùng để kiểm tra DataGridView và lưu triệu chứng vào CSDL
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPatientName.Text) ||
                string.IsNullOrWhiteSpace(cbBlood.Text) ||
                string.IsNullOrWhiteSpace(cbGender.Text) ||
                string.IsNullOrWhiteSpace(txtContact.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (!dtpAge.Checked)
            {
                MessageBox.Show("Vui lòng chọn ngày sinh!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            else if (cbSelectDoctor.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn bác sĩ!");
            }
            else
            {
                if(symptomDataGridView.Rows.Count <= 1)
                {
                    MessageBox.Show("Hãy cho triệu chứng!");
                }
                else
                {
                    var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn lưu thông tin bệnh nhân này?", "Lưu thông tin bệnh nhân", MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        try
                        {
                            //string query = @"INSERT INTO Patient (Name,Address,Contact,DateOfBirth,Gender,BloodGroup,Pcode,DoctorId,AddedDate,AddedBy) VALUES (@Name,@Address,@Contact,@DateOfBirth,@Gender,@BloodGroup,@PCode,@DoctorId,@AddedDate,@AddedBy);
                            //SELECT SCOPE_IDENTITY()";
                            //SqlCommand cmd = new SqlCommand(query, conn, transaction);
                            //cmd.Parameters.AddWithValue("@Name", txtPatientName.Text.Trim());
                            //cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                            //cmd.Parameters.AddWithValue("@Contact", txtContact.Text.Trim());
                            //cmd.Parameters.AddWithValue("@DateOfBirth", dtpAge.Value.Date);
                            //cmd.Parameters.AddWithValue("@BloodGroup", cbBlood.Text.Trim());
                            //cmd.Parameters.AddWithValue("@Gender", cbGender.Text.Trim());
                            //cmd.Parameters.AddWithValue("@PCode", lblPCodeNum.Text.Trim());
                            //cmd.Parameters.AddWithValue("@DoctorId", cbSelectDoctor.SelectedValue);
                            //cmd.Parameters.AddWithValue("@AddedDate", DateTime.Now);
                            //cmd.Parameters.AddWithValue("@AddedBy", currentUser.UserId);
                            int patientId = patientBL.AddPatient(new PatientDTO(
                                PatientName: txtPatientName.Text.Trim(),
                                Address: txtAddress.Text.Trim(),
                                Contact: txtContact.Text.Trim(),
                                DateOfBirth: dtpAge.Value.Date,
                                Gender: cbGender.Text.Trim(),
                                BloodGroup: cbBlood.Text.Trim(),
                                PCode: lblPCode.Text.Trim(),
                                DoctorId: Convert.ToInt32(cbSelectDoctor.SelectedValue),
                                addDate: DateTime.Now,
                                by: currentUser.UserId));

                            if (patientId > 0)
                            {
                                for (int i = 0; i < symptomDataGridView.Rows.Count - 1; i++)
                                {
                                    string name = symptomDataGridView.Rows[i].Cells["Name"].Value.ToString();

                                    //query = @"INSERT INTO Symptom (Name,PatientId,AddedDate,AddedBy) VALUES (@Name,@PatientId,@AddedDate,@AddedBy);";
                                    //cmd = new SqlCommand(query, conn, transaction);
                                    //cmd.Parameters.AddWithValue("@Name", name);
                                    //cmd.Parameters.AddWithValue("@PatientId", patientId);
                                    //cmd.Parameters.AddWithValue("@AddedDate", DateTime.Now);
                                    //cmd.Parameters.AddWithValue("@AddedBy", currentUser.UserId);
                                    //cmd.ExecuteNonQuery();
                                    symptomBL.InsertSymtom(new Symptom(
                                        name: name,
                                        patientId: patientId,
                                        by: currentUser.UserId,
                                        date: DateTime.Now
                                        ));
                                }
                            }
                            //transaction.Commit();
                            MessageBox.Show("Thông tin bệnh nhân đã được lưu thành công!");
                            Reset();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            //transaction.Rollback();
                        }
                        finally
                        {
                            //conn.Close();
                        }
                        //using (SqlConnection conn = new SqlConnection(DBCommon.connString))
                        //{
                        //    conn.Open();
                        //    using (SqlTransaction transaction = conn.BeginTransaction())
                        //    {
                                
                        //    }
                        //}
                    }
                }
            }
        }

        // Dùng để mở form in đơn thuốc
        private void btnGetPrescription_Click(object sender, EventArgs e)
        {
            this.Hide();
            DoctorPrescriptionForm form = new DoctorPrescriptionForm(currentUser);
            form.Show();
        }
    }
}
