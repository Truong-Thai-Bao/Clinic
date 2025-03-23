using BusinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class PatientForm : Form
    {
        public PatientForm()
        {
            InitializeComponent();
            lblPCodeNum.Text = DateTime.Now.ToString("ddMMhhmmss");
            LoadDoctors();
        }

        private void LoadDoctors()
        {
            using (SqlConnection sqlCon = new SqlConnection(DBCommon.ConString))
            {
                try
                {
                    string query = "SELECT DoctorId, DocName FROM Doctor";
                    SqlDataAdapter da = new SqlDataAdapter(query, sqlCon);
                    sqlCon.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Doctor");
                    cbSelectDoctor.DisplayMember = "DocName";
                    cbSelectDoctor.ValueMember = "DoctorId";
                    cbSelectDoctor.DataSource = ds.Tables["Doctor"];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Đã xảy ra lỗi!");
                }
            }
        }


        private void pictureBoxLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuForm form = new MenuForm();
            form.Show();
        }

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

        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void Reset()
        {
            txtPatientId.Text = 0.ToString();
            txtPatientName.Text = "";
            cbBlood.Text = "";
            txtAge.Text = "";
            cbGender.Text = "";
            txtContact.Text = "";
            txtAddress.Text = "";
            cbSymptom.Text = "";
            cbBlood.Text = "";
            cbGender.Text = "";
            txtOtherSymptom.Text = "";
            symptomDataGridView.Columns.Clear();
        }

        private void cbSymptom_SelectedValueChanged(object sender, EventArgs e)
        {
            txtOtherSymptom.Text = "";
            txtOtherSymptom.ReadOnly = true;
            txtOtherSymptom.Enabled = false;
            if(cbSymptom.Text == "Other")
            {
                txtOtherSymptom.ReadOnly = false;
                txtOtherSymptom.Enabled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(cbSymptom.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn triệu chứng!");
                cbSymptom.Focus();
            }
            else if (cbSymptom.Text== "Other" && txtOtherSymptom.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập triệu chứng khác!");
                txtOtherSymptom.Focus();
            }
            else
            {
                string name = cbSymptom.Text;
                if(cbSymptom.Text == "Other")
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPatientName.Text.Trim() == "" ||
                cbBlood.Text.Trim() == "" ||
                txtAge.Text.Trim() == "" ||
                cbGender.Text.Trim() == "" ||
                txtContact.Text.Trim() == "" ||
                txtAddress.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
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
                    var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn lưu thông tin bệnh nhân này?", "Không thể xóa được", MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        using (SqlConnection conn = new SqlConnection(DBCommon.ConString))
                        {
                            conn.Open();
                            using (SqlTransaction transaction = conn.BeginTransaction())
                            {
                                try
                                {
                                    string query = @"INSERT INTO Patient (Name,Address,Contact,Age,Gender,BloodGroup,Pcode,DoctorId,AddedDate,AddedBy) VALUES (@Name,@Address,@Contact,@Age,@Gender,@BloodGroup,@PCode,@DoctorId,@AddedDate,@AddedBy);
                                    SELECT SCOPE_IDENTITY()";
                                    SqlCommand cmd = new SqlCommand(query, conn, transaction);
                                    cmd.Parameters.AddWithValue("@Name", txtPatientName.Text.Trim());
                                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                                    cmd.Parameters.AddWithValue("@Contact", txtContact.Text.Trim());
                                    cmd.Parameters.AddWithValue("@Age", txtAge.Text.Trim());
                                    cmd.Parameters.AddWithValue("@Gender", cbGender.Text.Trim());
                                    cmd.Parameters.AddWithValue("@BloodGroup", cbBlood.Text.Trim());
                                    cmd.Parameters.AddWithValue("@PCode", lblPCodeNum.Text.Trim());
                                    cmd.Parameters.AddWithValue("@DoctorId", cbSelectDoctor.SelectedValue);
                                    cmd.Parameters.AddWithValue("@AddedDate", DateTime.Now);
                                    cmd.Parameters.AddWithValue("@AddedBy", Global.UserInfo.UserId);
                                    int patientId = Convert.ToInt32(cmd.ExecuteScalar());

                                    if(patientId > 0)
                                    {
                                        for (int i = 0; i < symptomDataGridView.Rows.Count - 1; i++)
                                        {
                                            string name = symptomDataGridView.Rows[i].Cells["Name"].Value.ToString();

                                            query = @"INSERT INTO Symptom (Name,PatientId,AddedDate,AddedBy) VALUES (@Name,@PatientId,@AddedDate,@AddedBy);";
                                            cmd = new SqlCommand(query, conn, transaction);
                                            cmd.Parameters.AddWithValue("@Name", name);
                                            cmd.Parameters.AddWithValue("@PatientId", patientId);
                                            cmd.Parameters.AddWithValue("@AddedDate", DateTime.Now);
                                            cmd.Parameters.AddWithValue("@AddedBy", Global.UserInfo.UserId);
                                            cmd.ExecuteNonQuery();
                                        }
                                    }
                                    transaction.Commit();
                                    MessageBox.Show("Thông tin bệnh nhân đã được lưu thành công!");
                                    Reset();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                    transaction.Rollback();
                                }
                                finally
                                {
                                    conn.Close();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnGetPrescription_Click(object sender, EventArgs e)
        {
            this.Hide();
            DoctorPrescriptionForm form = new DoctorPrescriptionForm();
            form.Show();
        }
    }
}
