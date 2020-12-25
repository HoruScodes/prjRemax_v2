using prjRemax.Business;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace prjRemax.DataLayer
{
    class clsClientData
    {
        public static DataSet mySet;
        public static SqlConnection myCon;
        public static int currentIndex;
        public static DataTable tabClient;
        public static bool updateMode = false;
        public static SqlDataAdapter myAdp;
        public static string sql;
        public clsClientData()
        {
            if (frmLogin.Usermode == "Admin")
            {
                sql = "SELECT * FROM client";
            }
            else
            {
                sql = "SELECT * FROM client where refType = 'Agent' and refid = "+frmLogin.currentId+"";
            }
            mySet = new DataSet();
            myCon = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=DBRemax;Integrated Security=True");
            myCon.Open();
            SqlCommand myCmd = new SqlCommand(sql, myCon);
            myAdp = new SqlDataAdapter(myCmd);
            myAdp.Fill(mySet, "Client");
            tabClient = mySet.Tables["Client"];
        }

        public static void syncClientDB()
        {
            SqlCommandBuilder myBuilder = new SqlCommandBuilder(myAdp);
            myAdp.Update(mySet, "Client");
            mySet.Tables.Remove("Client");
            myAdp.Fill(mySet, "Client");
            tabClient = mySet.Tables["Client"];
        }


        private static int getIndexByEmail(string email)
        {

            for (int i = 0; i < tabClient.Rows.Count; i++)
            {

                if (tabClient.Rows[i]["email"].ToString() == email)
                {
                    return i;
                }
            }
            return -1;
        }


        public static bool AddClient(clsClient newClientData)
        {
            if (!Exist(newClientData.Email))
            {
                DataRow myRow = tabClient.NewRow();
                myRow["refAgentid"] = newClientData.Name;
                myRow["email"] = newClientData.Email;
                myRow["phone"] = newClientData.Phone;
                myRow["type"] = newClientData.clientType;
                myRow["refType"] = newClientData.ParentType;
                myRow["refName"] = newClientData.ParentName;
                myRow["refid"] = newClientData.ParentId;
                tabClient.Rows.Add(myRow);
                return true;
            }
            return false;
        }

        public static bool removeClient(string email)
        {
            int index = getIndexByEmail(email);
            if (Exist(email) || index != -1)
            {
                tabClient.Rows[index].Delete();
                return true;
            }
            return false;
        }
        public static bool updateClient(clsClient newClientData)
        {
            if (Exist(newClientData.Email))
            {
                int index = getIndexByEmail(newClientData.Email);
                tabClient.Rows[index]["name"] = newClientData.Name;
                tabClient.Rows[index]["email"] = newClientData.Email;
                tabClient.Rows[index]["phone"] = newClientData.Phone;
                tabClient.Rows[index]["type"] = newClientData.clientType;
                tabClient.Rows[index]["refType"] = newClientData.ParentType;
                tabClient.Rows[index]["refName"] = newClientData.ParentName;
                tabClient.Rows[index]["refid"] = newClientData.ParentId;
                return true;
            }
            return false;
        }
        public static bool Exist(string email)
        {
            foreach (DataRow row in tabClient.Rows)
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
            syncClientDB();
            list.Items.Clear();
            foreach (DataRow row in tabClient.Rows)
            {
                list.Items.Add(row["name"]);
            }
            dataGrid.DataSource = tabClient;
        }

        public static void setClientData(ComboBox comboBoxAgent)
        {
            comboBoxAgent.Items.Clear();
            foreach (DataRow row in tabClient.Rows)
            {
                comboBoxAgent.Items.Add(row["refName"]);
            }
        }

        public static string getDatabySellerName(string name)
        {

            foreach (DataRow row in tabClient.Rows)
            {
                if(row["name"].ToString() == name)
                {
                    return row["id"].ToString();
                }
            }

            return null;
        }

        public static void setHouseBuyerData(ComboBox buyers)
        {
            buyers.Items.Clear();

            foreach (DataRow row in tabClient.Rows)
            {
                if (row["type"].ToString() == "Buyer")
                {
                    buyers.Items.Add(row["id"]);
                }
            }

        }
    }
}
