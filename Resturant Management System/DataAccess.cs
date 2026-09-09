using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using System.Data;

namespace Resturant_Management_System
{
    static class DataAccess
    {
        public static bool ExecuteQuery(String query)
        {
            try
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=PREDATOR-ASIF;Initial Catalog=Resturant Management System;Integrated Security=True;TrustServerCertificate=True";
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("e.meassage");
                return false;
            }
        }
        public static DataTable GetData(String query)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=PREDATOR-ASIF;Initial Catalog=Resturant Management System;Integrated Security=True;TrustServerCertificate=True";
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = query;

                SqlDataAdapter adp = new SqlDataAdapter(cmd);///convertion
                DataSet ds = new DataSet();///sql data set
                adp.Fill(ds);

                DataTable dt = ds.Tables[0];
                con.Close();
                return dt;
            }
            catch (Exception e)
            {
                MessageBox.Show("E.meassage");
                return null;
            }
        }

    }
}