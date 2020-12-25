using prjRemax.Business;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace prjRemax.DataLayer
{
    class clsSalesData
    {
        public static DataSet mySet;
        public static SqlConnection myCon;
        public static int currentIndex;
        public static DataTable tabSales;
        public static bool updateMode = false;
        public static SqlDataAdapter myAdp;
        public clsSalesData()
        {
            mySet = new DataSet();
            myCon = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=DBRemax;Integrated Security=True");
            myCon.Open();
            SqlCommand myCmd = new SqlCommand("SELECT * FROM sales", myCon);
            myAdp = new SqlDataAdapter(myCmd);
            myAdp.Fill(mySet, "Sales");
            tabSales = mySet.Tables["Sales"];

        }

        public static void syncSalesDB()
        {
            SqlCommandBuilder myBuilder = new SqlCommandBuilder(myAdp);
            myAdp.Update(mySet, "Sales");
            mySet.Tables.Remove("Sales");
            myAdp.Fill(mySet, "Sales");
            tabSales = mySet.Tables["Sales"];
        }

        public static void setData(DataGridView dataGrid)
        {
           dataGrid.DataSource = tabSales;
        }


    
        public static bool addSale(clsSales newSalesData)
        {
                DataRow myRow = tabSales.NewRow();
                myRow["refAgentid"] = newSalesData.AgentId;
                myRow["refHouseId"] = newSalesData.HouseRefId;
                myRow["refBuyerId"] = newSalesData.BuyerID;
                myRow["refSellerId"] = newSalesData.SellerID;
                myRow["refSalesDate"] = newSalesData.SellDate;
                tabSales.Rows.Add(myRow);
            syncSalesDB();
            return clsHouseData.removeHouse(newSalesData.HouseRefId);
        }

   

    }
    }

