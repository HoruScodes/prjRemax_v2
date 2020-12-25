using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjRemax.DataLayer
{
    public static class clsGlobal
    {
        // Declare project global variables
        public static DataSet mySet;
        public static SqlConnection myCon;
        public static SqlDataAdapter adpAdmin, adpAgent, adpAgentForUser , adpClient , adpHouse , adpSales;
    }
}
