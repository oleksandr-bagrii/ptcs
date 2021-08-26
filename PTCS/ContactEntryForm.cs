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
using System.Configuration;
using Dapper;

namespace PTCS
{
    public partial class ContactEntryForm : Form
    {
        protected string connectionString = ConfigurationManager.ConnectionStrings["ConStr"].ToString();
        public ContactEntryForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Show();
            this.Dispose();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckFields())
            {
                InsertContact(txtFirstName.Text,
                      txtLastName.Text,
                      txtAddress.Text,
                      txtHomePhone.Text,
                      txtWorkPhone.Text,
                      txtCity.Text,
                      txtState.Text,
                      txtZipCode.Text,
                      txtNotes.Text
                      );

                fillDataGrid();
                ClearFields();

            }
            else
            {
                MessageBox.Show(this, "Fill Required Fields", "Info", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        internal bool CheckFields()
        {

            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    TextBox textBox = c as TextBox;
                    if (textBox.Name != "txtID" && textBox.Name != "txtNotes" && textBox.Text == string.Empty)
                    {

                        textBox.Focus();
                        return false;

                    }
                }
            }

            return true;
        }
        internal void ClearFields()
        {

            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    TextBox textBox = c as TextBox;
                    if (textBox.Text != string.Empty)
                    {

                        textBox.Text = "";



                    }
                }
            }


        }
        internal bool fillDataGrid()
        {
            try
            {
                using (var con = new SqlConnection(connectionString))
            {
                string query;
                DynamicParameters param = new DynamicParameters();

                if (txtSrchLN.Text == "")
                {
                    query = "Select * From PhoneBook ";
                }
                else
                {
                    query = "Select * From PhoneBook where LastName = @LN";
                    param.Add("LN", txtSrchLN.Text);
                }
                List<Contact> list = con.Query<Contact>(query, param).ToList<Contact>();
                dgvContactList.DataSource = list;
                if (list.Count > 0)
                {
                    return true;
                }
            }
            
            }
            catch (Exception)
            {
                
               MessageBox.Show(this, "Technical Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        void InsertContact(string FirstName, string LastName, string Address, string HomePhone, string WorkPhone, string City, string State, string ZipCode, string Notes)
        {

            using (var con = new SqlConnection(connectionString))
            {
                if (con.State != ConnectionState.Open)
                {
                    try
                    {
                        con.Open();
                        string query = "Insert into Phonebook (FirstName,LastName,Address,City,State,ZipCode,HomePhone,WorkPhone,Notes) Values(@FN,@LN,@AD,@CT,@ST,@ZC,@HP,@WP,@NTS)";
                        DynamicParameters param = new DynamicParameters();
                        param.Add("@FN", FirstName);
                        param.Add("@LN", LastName);
                        param.Add("@AD", Address);
                        param.Add("@CT", City);
                        param.Add("@ST", State);
                        param.Add("@ZC", ZipCode);
                        param.Add("@HP", HomePhone);
                        param.Add("@WP", WorkPhone);
                        param.Add("@NTS", Notes);

                        con.Execute(query, param, commandType: CommandType.Text);
                        con.Close();
                        MessageBox.Show(this, "Data Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(this, "Technical Error Occured" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }


        void UpdateContact(int ID, string FirstName, string LastName, string Address, string HomePhone, string WorkPhone, string City, string State, string ZipCode, string Notes)
        {

            using (var con = new SqlConnection(connectionString))
            {
                if (con.State != ConnectionState.Open)
                {
                    try
                    {
                        con.Open();
                        string query = "Update  Phonebook SET FirstName = @FN ,LastName = @LN,Address = @AD,City = @CT,State = @ST,ZipCode =@ZC,HomePhone =@HP,WorkPhone = @WP,Notes =@NTS WHERE Person_ID=@ID ";
                        DynamicParameters param = new DynamicParameters();
                        param.Add("@ID", ID);
                        param.Add("@FN", FirstName);
                        param.Add("@LN", LastName);
                        param.Add("@AD", Address);
                        param.Add("@CT", City);
                        param.Add("@ST", State);
                        param.Add("@ZC", ZipCode);
                        param.Add("@HP", HomePhone);
                        param.Add("@WP", WorkPhone);
                        param.Add("@NTS", Notes);

                        con.Execute(query, param, commandType: CommandType.Text);
                        con.Close();
                        MessageBox.Show(this, "Data Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {

                        MessageBox.Show(this, "Technical Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        void DeleteContact(int ID)
        {
            using (var con = new SqlConnection(connectionString))
            {
                if (con.State != ConnectionState.Open)
                {
                    try
                    {
                        con.Open();
                        string query = "Delete from  Phonebook  WHERE Person_ID=@ID ";
                        DynamicParameters param = new DynamicParameters();
                        param.Add("@ID", ID);


                        con.Execute(query, param, commandType: CommandType.Text);
                        con.Close();
                        MessageBox.Show(this, "Delete Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {

                        MessageBox.Show(this, "Technical Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }


        private void btnLN_Click(object sender, EventArgs e)
        {
            bool chk = fillDataGrid();
            if (!chk)
            {
                MessageBox.Show("No Record Found against " + txtSrchLN, "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnBAC_Click(object sender, EventArgs e)
        {
            txtSrchLN.Text = "";
            fillDataGrid();
        }

        private void ContactEntryForm_Load(object sender, EventArgs e)
        {
            fillDataGrid();
        }

        private void ContactEntryForm_Leave(object sender, EventArgs e)
        {

        }

        private void ContactEntryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Show();
        }

        private void dgvContactList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dgvContactList.CurrentRow.Cells[0].Value.ToString();
            txtFirstName.Text = dgvContactList.CurrentRow.Cells[1].Value.ToString();
            txtLastName.Text = dgvContactList.CurrentRow.Cells[2].Value.ToString();
            txtAddress.Text = dgvContactList.CurrentRow.Cells[3].Value.ToString();
            txtCity.Text = dgvContactList.CurrentRow.Cells[4].Value.ToString();
            txtState.Text = dgvContactList.CurrentRow.Cells[5].Value.ToString();
            txtZipCode.Text = dgvContactList.CurrentRow.Cells[6].Value.ToString();
            txtHomePhone.Text = dgvContactList.CurrentRow.Cells[7].Value.ToString();
            txtWorkPhone.Text = dgvContactList.CurrentRow.Cells[8].Value.ToString();
            txtNotes.Text = dgvContactList.CurrentRow.Cells[9].Value.ToString();
            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CheckFields())
            {
                UpdateContact(Convert.ToInt32(txtID.Text),
                    txtFirstName.Text,
                      txtLastName.Text,
                      txtAddress.Text,
                      txtHomePhone.Text,
                      txtWorkPhone.Text,
                      txtCity.Text,
                      txtState.Text,
                      txtZipCode.Text,
                      txtNotes.Text
                      );

                fillDataGrid();
                btnAdd.Enabled = true;
                ClearFields();
                btnUpdate.Enabled = false;
            }
            else
            {
                MessageBox.Show(this, "Fill Required Fields", "Info", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DeleteContact(Convert.ToInt32(txtID.Text));
            fillDataGrid();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Show();
            this.Dispose();
        }

        private void btnBC_Click(object sender, EventArgs e)
        {
            try
            {
                using (var con = new SqlConnection(connectionString))
            {
                string query = "Select * From PhoneBook order by LastName asc ";
                List<Contact> list = con.Query<Contact>(query).ToList<Contact>();
                dgvContactList.DataSource = list;

            }
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Technical Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtFirstName_Enter(object sender, EventArgs e)
        {
            toolStrip1.Show();
        }

    }
}
