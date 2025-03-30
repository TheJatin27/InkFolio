using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace mine2.Models
{
    public class database
    {

        SqlConnection connect = new SqlConnection("Data Source=AYUSHI;Initial Catalog=My_Project;Integrated Security=True");


        public int InsertUpdateDelete(string command) {

            SqlCommand cmd = new SqlCommand(command, connect);

            connect.Open();
         int d=  cmd.ExecuteNonQuery();
            connect.Close();

            return d;

        }

        public DataTable SelectStatment(string command)
        {

            SqlDataAdapter adapter = new SqlDataAdapter(command, connect);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;

        }

        

    }
}