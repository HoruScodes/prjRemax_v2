using prjRemax.Business;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace prjRemax.DataLayer
{

    class clsAgentData
    {
        public static DataSet mySet;
        public static SqlConnection myCon;
        public static int currentIndex;
        public static DataTable tabAgent , tabAgentForUser;
        public static bool updateMode = false;
        public static SqlDataAdapter myAdp,myAdp2;
        public clsAgentData()
        {
            mySet = new DataSet();
            myCon = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=DBRemax;Integrated Security=True");
            myCon.Open();
            SqlCommand myCmd = new SqlCommand("SELECT * FROM agent", myCon);
            myAdp = new SqlDataAdapter(myCmd);
            myAdp.Fill(mySet, "Agent");
            tabAgent = mySet.Tables["Agent"];

            //table for users
            myCmd = new SqlCommand("SELECT id,name,email,phone FROM agent", myCon);
            myAdp2 = new SqlDataAdapter(myCmd);
            myAdp2.Fill(mySet, "Agent2");
            tabAgentForUser = mySet.Tables["Agent2"];

        }

        public static void syncAgentDB()
        {
            SqlCommandBuilder myBuilder = new SqlCommandBuilder(myAdp);
            myAdp.Update(mySet, "Agent");
            mySet.Tables.Remove("Agent");
            myAdp.Fill(mySet, "Agent");
            tabAgent = mySet.Tables["Agent"];
        }

        public static string loginAgent(string email, string pwd)
        {
            if (Exist(email))
            {
                foreach (DataRow row in tabAgent.Rows)
                {
                    if (row["email"].ToString() == email && row["password"].ToString() == pwd)
                    {
                        return email;
                    }

                }
                return "pwdErr";
            }
            return "notFoundErr";
        }

        public static bool AddAgent(clsAgent newAgentData)
        {
            if (!Exist(newAgentData.Email))
            {
                DataRow myRow = tabAgent.NewRow();
                myRow["name"] = newAgentData.Name;
                myRow["email"] = newAgentData.Email;
                myRow["phone"] = newAgentData.Phone;
                myRow["password"] = newAgentData.Password;
                myRow["refAdmin"] = newAgentData.AdminId;
                tabAgent.Rows.Add(myRow);
                return true;
            }
            return false;
        }

        private static int getIndexByEmail(string email)
        {

            for (int i = 0; i < tabAgent.Rows.Count; i++)
            {

                if (tabAgent.Rows[i]["email"].ToString() == email)
                {
                    return i;
                }
            }
            return -1;
        }

        public static bool removeAgent(string email)
        {
            int index = getIndexByEmail(email);
            if (Exist(email) || index != -1)
            {
                tabAgent.Rows[index].Delete();
                return true;
            }          
            return false;
        }

        public static bool updateAgent(clsAgent newAgentData)
        {
            if (Exist(newAgentData.Email))
            {
                int index = getIndexByEmail(newAgentData.Email);
                tabAgent.Rows[index]["name"] = newAgentData.Name;
                tabAgent.Rows[index]["email"] = newAgentData.Email;
                tabAgent.Rows[index]["phone"] = newAgentData.Phone;
                tabAgent.Rows[index]["password"] = newAgentData.Password;
                tabAgent.Rows[index]["refAdmin"] = newAgentData.AdminId;
                return true;
            }
            return false;
        }

        public static bool Exist(string email)
        {
            foreach (DataRow row in tabAgent.Rows)
            {
                if (row["email"].ToString() == email)
                {
                    return true;
                }

            }
            return false;
        }

        public static void setData(ListBox list, DataGridView dataGrid)
        {
            syncAgentDB();
            list.Items.Clear();
            foreach (DataRow row in tabAgent.Rows)
            {
                list.Items.Add(row["name"]);
            }
            dataGrid.DataSource = tabAgent;
        }

        public static DataRow getData(string email)
        {
            int index = getIndexByEmail(email);
            if (Exist(email) && index != -1)
            {
                return tabAgent.Rows[index];
            }
            return null;
        }

        public static void setAgentData(ComboBox agents)
        {
            agents.Items.Clear();
            if (frmLogin.Usermode == "Admin")
            {
                foreach (DataRow row in tabAgent.Rows)
                {
                    agents.Items.Add(row["id"]);
                }
            }
        }

        public static void setAgentsData(ComboBox agents)
        {
            agents.Items.Clear();
            foreach (DataRow row in tabAgent.Rows)
            {
                agents.Items.Add(row["email"].ToString());
            }
        }

        public static void setAgentsDataGrid(string selectedAgentID, DataGridView GridAgent)
        {
            if (selectedAgentID == "all")
            {
                string sql = "SELECT id,name,email,phone FROM agent";
                SqlCommand myCmd = new SqlCommand(sql, myCon);
                myAdp = new SqlDataAdapter(myCmd);
                mySet.Tables.Remove("Agent2");
                myAdp.Fill(mySet, "Agent2");
                tabAgentForUser = mySet.Tables["Agent2"];
                GridAgent.DataSource = tabAgentForUser;
            }
            else
            {
                string sql = "SELECT * FROM Student WHERE  email ='" + selectedAgentID + "'";
                SqlCommand myCmd = new SqlCommand(sql, myCon);
                myAdp = new SqlDataAdapter(myCmd);
                mySet.Tables.Remove("Agent2");
                myAdp.Fill(mySet, "Agent2");
                tabAgentForUser = mySet.Tables["Agent2"];
                GridAgent.DataSource = tabAgentForUser;
            }

        }
    }
}
