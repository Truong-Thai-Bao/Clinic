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
    public partial class DiagnosisForm : Form
    {
        SqlConnection sqlCon = new SqlConnection(DBCommon.connString);
        public DiagnosisForm()
        {
            InitializeComponent();
            LoadPatients();
            symptomDataGridView.DefaultCellStyle.ForeColor = Color.Black;
            medicineDataGridView.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void LoadPatients()
        {
            using (SqlConnection conn = new SqlConnection(DBCommon.connString))
            {
                try
                {
                    string query = "SELECT PatientId, [Name] FROM Patient WHERE DoctorId = " + Global.UserInfo.DoctorId +" AND PatientId NOT IN (SELECT PatientId FROM Dianosis WHERE DoctorId = " +Global.UserInfo.DoctorId +")";
                    SqlDataAdapter da = new SqlDataAdapter(query, sqlCon);
                    conn.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Patient");
                    cbPatients.DisplayMember = "Name";
                    cbPatients.ValueMember = "PatientId";
                    cbPatients.DataSource = ds.Tables["Patient"];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void pictureBoxLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuForm form = new MenuForm();
            form.Show();
        }

        private void cbPatients_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadPatientInfos();
        }

        private void LoadPatientInfos()
        {
            int patientId = Convert.ToInt32(cbPatients.SelectedValue);
            if(patientId > 0)
            {
                SqlConnection conn = new SqlConnection(DBCommon.connString);

                #region Load Patients
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Patient WHERE PatientId = @PatientId", conn);
                cmd.Parameters.AddWithValue("@PatientId", patientId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        txtBlood.Text = String.Format("{0}", reader["BloodGroup"]);
                        txtAge.Text = String.Format("{0}", reader["Age"]);
                        txtGender.Text = String.Format("{0}", reader["Gender"]);
                        txtContact.Text = String.Format("{0}", reader["Contact"]);
                        txtPatientCode.Text = String.Format("{0}", reader["PCode"]);
                    }
                }
                conn.Close();
                #endregion

                #region Load Symptoms
                cmd = new SqlCommand("SELECT * FROM Symptom WHERE PatientId = @PatientId", conn);
                sqlCon = BusinessLayer.CmnMethods.OpenConnectionString(sqlCon);
                string query = string.Format(@"SELECT * FROM Symptom WHERE PatientId = {0}", patientId);
                SqlDataAdapter sda = new SqlDataAdapter(query, sqlCon);
                SqlCommandBuilder scb = new SqlCommandBuilder(sda);
                var dataset = new DataSet();
                sda.Fill(dataset);
                symptomDataGridView.DataSource = dataset.Tables[0];
                sqlCon.Close();

                symptomDataGridView.Columns[0].Visible = false;
                symptomDataGridView.Columns[2].Visible = false;
                symptomDataGridView.Columns[3].Visible = false;
                symptomDataGridView.Columns[4].Visible = false;
                symptomDataGridView.Columns[5].Visible = false;
                symptomDataGridView.Columns[6].Visible = false;
                #endregion
            }
        }

        private void medicineDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow item in this.medicineDataGridView.SelectedRows)
            {
                medicineDataGridView.Rows.RemoveAt(item.Index); //Remove Medicine
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtMedicine.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên thuốc!");
                txtMedicine.Focus();
            }
            else
            {
                string name = txtMedicine.Text;

                int rowIndex = -1;
                var rowsCount = medicineDataGridView.Rows.Count;

                if(rowsCount > 1)
                {
                    for (int i = 0; i < medicineDataGridView.Rows.Count -1; i++)
                    {
                        if (medicineDataGridView.Rows[i].Cells["MedicineName"].Value.ToString() == name)
                        {
                            rowIndex = medicineDataGridView.Rows[i].Index;
                            break;
                        }
                    }
                }
                if (rowIndex < 0)
                {
                    rowIndex = medicineDataGridView.Rows.Add();
                }
                medicineDataGridView.Rows[rowIndex].Cells["Serial"].Value = medicineDataGridView.Rows.Count - 1;
                medicineDataGridView.Rows[rowIndex].Cells["MedicineName"].Value = name;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbPatients.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân!");
                return;
            }
            else if (medicineDataGridView.Rows.Count <= 1)
            {
                MessageBox.Show("Vui lòng nhập tên thuốc!");
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(DBCommon.connString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();
                    try
                    {
                        string query = @"INSERT INTO Dianosis (PatientId, DoctorId, AddedDate, AddedBy) VALUES (@PatientId, @DoctorId, @AddedDate, @AddedBy);
                            SELECT SCOPE_IDENTITY();";
                        SqlCommand cmd = new SqlCommand(query, conn, transaction);
                        cmd.Parameters.AddWithValue("@PatientId", cbPatients.SelectedValue);
                        cmd.Parameters.AddWithValue("@DoctorId", Global.UserInfo.DoctorId);
                        cmd.Parameters.AddWithValue("@AddedDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@AddedBy", Global.UserInfo.UserId);
                        int dianosisId = Convert.ToInt32(cmd.ExecuteScalar());

                        if(dianosisId > 0)
                        {
                            for (int i = 0; i < medicineDataGridView.Rows.Count - 1; i++)
                            {
                                string name = medicineDataGridView.Rows[i].Cells["MedicineName"].Value.ToString();

                                query = @"INSERT INTO Medicine (MedicineName, DianosisId, PatientId, AddedDate, AddedBy) VALUES (@MedicineName, @DianosisId, @PatientId, @AddedDate, @AddedBy);";
                                cmd = new SqlCommand(query, conn, transaction);
                                cmd.Parameters.AddWithValue("@MedicineName", name);
                                cmd.Parameters.AddWithValue("@DianosisId", dianosisId);
                                cmd.Parameters.AddWithValue("@PatientId", cbPatients.SelectedValue);
                                cmd.Parameters.AddWithValue("@AddedDate", DateTime.Now);
                                cmd.Parameters.AddWithValue("@AddedBy", Global.UserInfo.UserId);
                                cmd.ExecuteNonQuery();
                            }
                        }    
                        transaction.Commit();
                        MessageBox.Show("Lưu thành công!");
                        LoadPatients();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        private void medicineDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DiagnosisForm_Load(object sender, EventArgs e)
        {

        }

        private void txtGender_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
