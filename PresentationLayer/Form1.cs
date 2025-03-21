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
using BusinessLayer;
namespace PresentationLayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUserName.Text.Trim() ==""|| txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập Username & Password!");
                txtUserName.Focus();
            }
            else
            {
                sqlCon = BusinessLayer.CmnMethods.OpenConnectionString(sqlCon);
                string query = string.Format(@"Select * From View_UserInfo Where Username = '{0}' 
                                                                    and Password ='{1}'", txtUserName.Text.Trim(),txtPassword.Text.Trim());
                SqlDataAdapter sda = new SqlDataAdapter(query, sqlCon);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                    this.Hide();
                    MenuForm form
                }
            }
        }
    }
}
