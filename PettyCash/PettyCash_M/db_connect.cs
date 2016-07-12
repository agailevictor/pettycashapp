using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PettyCash_M
{
    public class db_connect
    {
        SqlConnection con = new SqlConnection();
        string constring_pettycash = ConfigurationManager.ConnectionStrings["pettycash"].ToString();

        public SqlConnection connect_pettycash()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.ConnectionString = constring_pettycash;
                    con.Open();
                }

            }
            catch (Exception e)
            {

            }
            return con;
        }

        public SqlConnection disconnect_pettycash()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception e)
            {

            }
            return con;
        }
    }
}
