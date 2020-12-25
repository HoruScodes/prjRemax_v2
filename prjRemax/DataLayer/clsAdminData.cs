using prjRemax.Business;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace prjRemax.DataLayer
{

    public class clsAdminData 
    {
        public static DataSet mySet;
        public static SqlConnection myCon;
        public static int currentIndex;
        public static DataTable tabAdmin;
        public static bool updateMode = false;
        public static SqlDataAdapter myAdp;
        public clsAdminData()
        {
            mySet = new DataSet();
            myCon = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=DBRemax;Integrated Security=True");
            myCon.Open();
            SqlCommand myCmd = new SqlCommand("SELECT * FROM admin", myCon);
            myAdp = new SqlDataAdapter(myCmd);
            myAdp.Fill(mySet, "Admin");
            tabAdmin = mySet.Tables["Admin"];


        }


        public static void syncAdminDB()
        {
            SqlCommandBuilder myBuilder = new SqlCommandBuilder(myAdp);
            myAdp.Update(mySet, "Admin");
            mySet.Tables.Remove("Admin");
            myAdp.Fill(mySet, "Admin");
            tabAdmin = mySet.Tables["Admin"];
        }


        public static string loginAdmin(string email, string pwd)
        {
            if (Exist(email))
            {
                foreach (DataRow row in tabAdmin.Rows)
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

        public static bool AddAdmin(clsAdmin newAdminData)
        {
            if (!Exist(newAdminData.Email))
            {
                DataRow myRow = tabAdmin.NewRow();
                myRow["name"] = newAdminData.Name;
                myRow["email"] = newAdminData.Email;
                myRow["phone"] = newAdminData.Phone;
                myRow["password"] = newAdminData.Password;
                tabAdmin.Rows.Add(myRow);
                return true;
            }
            return false;
        }

        public static bool removeAdmin(string id)
        {
            for (int i = 0; i < tabAdmin.Rows.Count; i++)
            {

                if ( tabAdmin.Rows[i]["id"].ToString() == id)
                {
                    tabAdmin.Rows[i].Delete();
                    break;
                }
            }
            return true;
        }


        private static int getIndexByEmail(string email)
        {

            for (int i = 0; i < tabAdmin.Rows.Count; i++)
            {

                if (tabAdmin.Rows[i]["email"].ToString() == email)
                {
                    return i;
                }
            }
            return -1;
        }

        public static bool updateAdmin(clsAdmin newAdminData)
        {
            if (Exist(newAdminData.Email))
            {
                int index = getIndexByEmail(newAdminData.Email);
                tabAdmin.Rows[index]["name"] = newAdminData.Name;
                tabAdmin.Rows[index]["email"] = newAdminData.Email;
                tabAdmin.Rows[index]["phone"] = newAdminData.Phone;
                tabAdmin.Rows[index]["password"] = newAdminData.Password;
                return true;
            }
            return false;
        }
        public static bool Exist(string email)
        {
            foreach (DataRow row in tabAdmin.Rows) 
            {
                if(row["email"].ToString() == email)
                {
                    return true;
                }
              
            }
            return false;
        }

        public static void setData(ListBox list, DataGridView dataGrid)
        {
            syncAdminDB();
            list.Items.Clear();
            foreach (DataRow row in tabAdmin.Rows)
            {
                list.Items.Add(row["name"]);
            }
            dataGrid.DataSource = tabAdmin;
        }

        public static DataRow getData(string email)
        {

            if (Exist(email))
            {
                for (int i=0; i<tabAdmin.Rows.Count; i++)
                {
                    if (tabAdmin.Rows[i]["email"].ToString() == email)
                    {
                        return tabAdmin.Rows[i];
                    }
                }
            }

            return null;
        }
    }
}
