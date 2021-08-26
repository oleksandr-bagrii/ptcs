using Dapper;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTCS
{
    public partial class ReportForm : Form
    {
        protected string connectionString = ConfigurationManager.ConnectionStrings["ConStr"].ToString();
        public ReportForm()
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
           
            try
            {

                fillReport();
            }
            catch (Exception)
            {

                MessageBox.Show(this, "Technical Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            lblCP.Text = "Current Page No.:" + reportViewer1.CurrentPage.ToString();
            lblZM.Text = "Zoom Factor:" + reportViewer1.ZoomPercent.ToString();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void reportViewer1_ZoomChange(object sender, Microsoft.Reporting.WinForms.ZoomChangeEventArgs e)
        {
            lblZM.Text = "Zoom Factor:" + reportViewer1.ZoomPercent.ToString();
        }

        private void reportViewer1_PageNavigation(object sender, Microsoft.Reporting.WinForms.PageNavigationEventArgs e)
        {
            lblCP.Text = "Current Page No.:" + reportViewer1.CurrentPage.ToString();
        }


        internal bool fillReport()
        {
            using (var con = new SqlConnection(connectionString))
            {
                string query;
                DynamicParameters param = new DynamicParameters();


                query = "Select * From PhoneBook";

                List<Contact> list = con.Query<Contact>(query).ToList<Contact>();
                ReportDataSource rs = new ReportDataSource("DSContactList", list);

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rs);
                reportViewer1.RefreshReport();



                if (list.Count > 0)
                {
                    return true;
                }
            }
            return false;
        }

        private void reportViewer1_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {
            lblTP.Text = "Total Pages.:" + reportViewer1.LocalReport.GetTotalPages();
        }

        private void ReportForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Show();
            this.Dispose();
        }

        private void reportViewer1_StatusChanged(object sender, EventArgs e)
        {
            lblZM.Text = "Zoom Factor:" + reportViewer1.ZoomPercent.ToString();
        }

    }
}
