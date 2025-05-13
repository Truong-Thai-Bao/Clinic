using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using DataTransferLayer;

namespace PresentationLayer
{
    public partial class RevenueStatistics : Form
    {
        private DataTransferLayer.UserInfo currentUser;
        private BusinessLayer.RevenueStatisticsBUS revenueStatisticsBUS = new BusinessLayer.RevenueStatisticsBUS();
        public RevenueStatistics(DataTransferLayer.UserInfo currentUser)
        {
            InitializeComponent();
            this.currentUser = currentUser;
        }

        private void btnViewRevenue_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = revenueStatisticsBUS.GetRevenueStatistics();
                dgvRevenue.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message);
            }
        }

        private void RevenueStatistics_Load(object sender, EventArgs e)
        {
            dgvRevenue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void pictureBoxLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuForm menuForm = new MenuForm(currentUser);
            menuForm.Show();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (dgvRevenue.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExcelPackage.License.SetNonCommercialOrganization("My Noncommercial organization");
                    using (ExcelPackage package = new ExcelPackage())
                    {
                        ExcelWorksheet ws = package.Workbook.Worksheets.Add("Revenue");

                        // Tiêu đề cột
                        for (int i = 0; i < dgvRevenue.Columns.Count; i++)
                        {
                            ws.Cells[1, i + 1].Value = dgvRevenue.Columns[i].HeaderText;
                            ws.Cells[1, i + 1].Style.Font.Bold = true;
                        }

                        // Dữ liệu
                        for (int i = 0; i < dgvRevenue.Rows.Count; i++)
                        {
                            for (int j = 0; j < dgvRevenue.Columns.Count; j++)
                            {
                                ws.Cells[i + 2, j + 1].Value = dgvRevenue.Rows[i].Cells[j].Value;
                            }
                        }

                        // Auto-fit
                        ws.Cells[ws.Dimension.Address].AutoFitColumns();

                        // Ghi file
                        File.WriteAllBytes(sfd.FileName, package.GetAsByteArray());
                        MessageBox.Show("Xuất file Excel thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

    }
}
