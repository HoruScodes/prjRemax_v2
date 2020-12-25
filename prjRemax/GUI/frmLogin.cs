using prjRemax.DataLayer;
using prjRemax.GUI;
using System;
using System.Data;
using System.Windows.Forms;

namespace prjRemax
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            grpboxLogin.Hide();
            new clsAdminData();
            new clsAgentData();
        }

        public static string usermode = "";
        public static string currentId = "";
        public static string currentName = "";
        public static string Usermode
        {
            get { return usermode; }
            set { usermode = value; }
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            Usermode = "Client";
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            txtEmail.Clear();
            txtPassword.Clear();
            Usermode = "Admin";
            labelLoginFor.Text = "Login For : " + usermode;
            grpboxLogin.Show();
        }

        private void btnAgent_Click(object sender, EventArgs e)
        {
            txtEmail.Clear();
            txtPassword.Clear();
            Usermode = "Agent";
            labelLoginFor.Text = "Login For : " + usermode;
            grpboxLogin.Show();
        }

        private void btnUser_Click_1(object sender, EventArgs e)
        {
            txtEmail.Clear();
            txtPassword.Clear();
            Usermode = "User";
            labelLoginFor.Text = "Login For : " + usermode;
            grpboxLogin.Hide();
            MessageBox.Show("welcome " + Usermode + " !");
            new clsHouseData();
            frmMain fr = new frmMain();
            fr.ShowDialog();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if (usermode == "Admin")
            {
                string status = clsAdminData.loginAdmin(txtEmail.Text, txtPassword.Text);
                if (status == txtEmail.Text)
                {
                    grpboxLogin.Hide();
                    MessageBox.Show("welcome Admin : " + status + " !");
                    DataRow adminData = clsAdminData.getData(txtEmail.Text);
                    currentId  = adminData["id"].ToString();
                    currentName = adminData["name"].ToString();
                    new clsClientData();
                    new clsHouseData();
                    new clsSalesData();
                    frmMain fr = new frmMain();
                    fr.ShowDialog();
                }
                else if (status == "pwdErr")
                {
                    MessageBox.Show("Wrong Password, Try Again!");
                }
                else if (status == "notFoundErr")
                {
                    MessageBox.Show("it appears that this account does not exist in our system!");
                }
            }
            else if (usermode == "Agent")
            {
                string status = clsAgentData.loginAgent(txtEmail.Text, txtPassword.Text);
                if (status == txtEmail.Text)
                {
                    grpboxLogin.Hide();
                    DataRow AgentData = clsAgentData.getData(txtEmail.Text);
                    currentId = AgentData["id"].ToString();
                    currentName = AgentData["name"].ToString();
                    MessageBox.Show("welcome Agent : " + status + " !");
                    new clsClientData();
                    new clsHouseData();
                    new clsSalesData();
                    frmMain fr = new frmMain();
                    fr.ShowDialog();
                }
                else if (status == "pwdErr")
                {
                    MessageBox.Show("Wrong Password, Try Again!");
                }
                else if (status == "notFoundErr")
                {
                    MessageBox.Show("it appears that this account does not exist in our system!");
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
