using prjRemax.Business;
using prjRemax.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace prjRemax.GUI
{
    public partial class frmAgent : Form
    {
        private bool updatemode = false;
        public frmAgent()
        {
            InitializeComponent();
        }

        private void frmAgent_Load(object sender, EventArgs e)
        {
            txtAdminId.Enabled = false;
            disableFields(true, true, true, true, true, false, true, true, true, true);
            clsAgentData.setData(listAgent, dataGridViewAgent);
        }

        private void disableFields(bool id, bool name, bool email, bool pass, bool phone, bool addbutton, bool deletebutton, bool updatebutton, bool cancelbutton, bool savebutton)
        {
            txtId.Enabled = !id;
            txtName.Enabled = !name;
            txtEmail.Enabled = !email;
            txtPassword.Enabled = !pass;
            txtPhone.Enabled = !phone;
            btnAdd.Enabled = !addbutton;
            btnCancel.Enabled = !cancelbutton;
            btnDelete.Enabled = !deletebutton;
            btnSave.Enabled = !savebutton;
            btnUpdate.Enabled = !updatebutton;
        }

        private void clearFields()
        {
            txtId.Clear();
            txtName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            txtId.Focus();
        }

        private void listAgent_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedName = listAgent.SelectedItem.ToString();

            foreach (DataRow row in clsAgentData.tabAgent.Rows)
            {
                if (row["name"].ToString() == selectedName)
                {
                    disableFields(true, true, true, true, true, false, false, false, true, true);
                    txtId.Text = row["id"].ToString();
                    txtName.Text = row["name"].ToString();
                    txtEmail.Text = row["email"].ToString();
                    txtPassword.Text = row["password"].ToString();
                    txtPhone.Text = row["phone"].ToString();
                    txtAdminId.Text = row["refAdmin"].ToString();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            updatemode = false;
            clearFields();
            disableFields(true, false, false, false, false, true, true, true, false, false);
            txtAdminId.Text = frmLogin.currentId;
            //txtId.Text = "ag" + (latestAgentId + 1).ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to delete Agent " + txtEmail.Text + " ?", "DELETE", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (clsAgentData.removeAgent(txtEmail.Text))
                {
                    MessageBox.Show("Deleted");
                    ReloadForm();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            updatemode = true;
            disableFields(true, false, false, false, false, true, true, true, false, false);
            txtName.Focus();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ReloadForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateData.isNameValid(txtName) && validateData.isEmailValid(txtEmail) && validateData.isPhoneNumberValid(txtPhone))
            {
                clsAgent newAgent = new clsAgent(txtId.Text, txtName.Text, txtEmail.Text, txtPhone.Text, txtPassword.Text, txtAdminId.Text);
                if (updatemode)
                {
                    if (clsAgentData.updateAgent(newAgent))
                    {
                        MessageBox.Show("successfully updated Agent : " + txtName.Text + " in the system!");
                        ReloadForm();
                    }
                }
                else
                {
                    if (clsAgentData.AddAgent(newAgent))
                    {
                        MessageBox.Show("successfully added Agent : " + txtName.Text + " in the system!");
                        ReloadForm();
                    }
                    else
                    {
                        MessageBox.Show("the Agent with the email: " + txtEmail.Text + " exist in the system!");
                        txtEmail.Focus();
                    }
                }
            }

        }

        private void ReloadForm()
        {
            clearFields();
            disableFields(true, true, true, true, true, false, true, true, true, true);
            clsAgentData.setData(listAgent, dataGridViewAgent);
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true; // blocking the caracter typed by the key
            }
        }
    }
}
