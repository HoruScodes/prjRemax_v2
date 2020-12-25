using prjRemax.Business;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace prjRemax.DataLayer
{

    class clsHouseData
    {
        public static DataSet mySet;
        public static SqlConnection myCon;
        public static DataTable tabHouse , tabHouseSearch;
        public static bool updateMode = false;
        public static SqlDataAdapter myAdp;
        public static string sql;
        public clsHouseData()
        {
            mySet = new DataSet();
            myCon = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=DBRemax;Integrated Security=True");
            myCon.Open();
            SqlCommand myCmd = new SqlCommand("SELECT * FROM house", myCon);
            myAdp = new SqlDataAdapter(myCmd);
            myAdp.Fill(mySet, "House");
            tabHouse = mySet.Tables["House"];


        }

        public static bool AddHouse(clsHouse newHouseData)
        {
            if (!Exist(newHouseData.HouseId))
            {
                DataRow myRow = tabHouse.NewRow();
                myRow["type"] = newHouseData.HouseType;
                myRow["numOfRooms"] = newHouseData.NumOfBedRooms;
                myRow["numOfBathrooms"] = newHouseData.NumbofBathRooms;
                myRow["price"] = newHouseData.Price;
                myRow["city"] = newHouseData.City;
                myRow["postalCode"] = newHouseData.PostalCode;
                myRow["refAgentid"] = newHouseData.AgentID;
                myRow["refAgentName"] = newHouseData.AgentName;
                myRow["refSellerid"] = newHouseData.SellerId;
                myRow["refSellerName"] = newHouseData.SellerName;
                tabHouse.Rows.Add(myRow);
                syncHouseDB();
                return true;
            }
            return false;
        }
        public static bool removeHouse(string houseid)
        {
            int index = getIndexByHouseId(houseid);
            if (Exist(houseid) || index != -1)
            {
                tabHouse.Rows[index].Delete();
                syncHouseDB();
                return true;
            }
            return false;
        }

        public static bool Exist(string houseid)
        {
            foreach (DataRow row in tabHouse.Rows)
            {
                if (row["id"].ToString() == houseid)
                {
                    return true;
                }

            }
            return false;
        }

        private static int getIndexByHouseId(string houseid)
        {

            for (int i = 0; i < tabHouse.Rows.Count; i++)
            {

                if (tabHouse.Rows[i]["id"].ToString() == houseid)
                {
                    return i;
                }
            }
            return -1;
        }

        public static bool updateHouse(clsHouse newHouseData)
        {


            if (Exist(newHouseData.HouseId))
            {
                int index = getIndexByHouseId(newHouseData.HouseId);
                tabHouse.Rows[index]["type"] = newHouseData.HouseType;
                tabHouse.Rows[index]["numOfRooms"] = newHouseData.NumOfBedRooms;
                tabHouse.Rows[index]["numOfBathrooms"] = newHouseData.NumbofBathRooms;
                tabHouse.Rows[index]["price"] = newHouseData.Price;
                tabHouse.Rows[index]["city"] = newHouseData.City;
                tabHouse.Rows[index]["postalCode"] = newHouseData.PostalCode;
                tabHouse.Rows[index]["refAgentid"] = newHouseData.AgentID;
                tabHouse.Rows[index]["refAgentName"] = newHouseData.AgentName;
                tabHouse.Rows[index]["refSellerid"] = newHouseData.SellerId;
                tabHouse.Rows[index]["refSellerName"] = newHouseData.SellerName;
                syncHouseDB();
                return true;
            }
            return false;
        }

        public static void syncHouseDB()
        {
            SqlCommandBuilder myBuilder = new SqlCommandBuilder(myAdp);
            myAdp.Update(mySet, "House");
            mySet.Tables.Remove("House");
            myAdp.Fill(mySet, "House");
            tabHouse = mySet.Tables["House"];
        }

        public static void setData(ListBox list, DataGridView dataGrid)
        {
            list.Items.Clear();
            mySet = new DataSet();
            myCon = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=DBRemax;Integrated Security=True");
            myCon.Open();
            if (frmLogin.Usermode == "Admin")
            {
                sql = "SELECT * FROM house";
            }
            else if (frmLogin.Usermode == "Agent")
            {
                sql = "SELECT * FROM house where refAgentId ="+ frmLogin.currentId;
            }
            SqlCommand myCmd = new SqlCommand(sql, myCon);
            myAdp = new SqlDataAdapter(myCmd);
            myAdp.Fill(mySet, "House");
            tabHouse = mySet.Tables["House"];

            foreach (DataRow row in tabHouse.Rows)
            {
                list.Items.Add(row["id"]);
            }
            dataGrid.DataSource = tabHouse;
        }

        public static void setHouseData(ComboBox houses)
        {
            houses.Items.Clear();
            foreach (DataRow row in tabHouse.Rows)
            {
                houses.Items.Add(row["id"]);
            }
        }

        public static void setHouseSellerData(ComboBox sellers)
        {
            sellers.Items.Clear();
            foreach (DataRow row in tabHouse.Rows)
            {
                sellers.Items.Add(row["refSellerid"]);
            }
        }

        public static void setHouseDataGrid(string selectedHouseId, DataGridView dataGrid)
        {
            if (selectedHouseId == "all")
            {
                dataGrid.DataSource = tabHouse;
            }
            else
            {
                string sql = "SELECT * FROM house where id ='" + selectedHouseId + "'";
                SqlCommand myCmd = new SqlCommand(sql, myCon);
                myAdp = new SqlDataAdapter(myCmd);
                if (mySet.Tables.Contains("HouseSearch") == true)
                {
                    mySet.Tables.Remove("HouseSearch");
                }           
                myAdp.Fill(mySet, "HouseSearch");
                tabHouseSearch = mySet.Tables["HouseSearch"];
                dataGrid.DataSource = tabHouseSearch;
            }

        }
    }
}
