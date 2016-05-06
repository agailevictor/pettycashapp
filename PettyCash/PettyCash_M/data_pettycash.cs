using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace PettyCash_M
{
    public class data_pettycash
    {
        SqlCommand cmd = new SqlCommand();
        db_connect db = new db_connect();
        public DataTable fetch_details(int uid)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fetch_details";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uid", uid);
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                cmd.Connection = db.connect_pettycash();
                da.SelectCommand = cmd;
                da.Fill(dt);
                return dt;
            }
            finally
            {
                db.disconnect_pettycash();
            }
        }

        public int check_audit_start()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_check_audit_start";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter outparam = new SqlParameter();
                outparam.ParameterName = "@flag";
                outparam.Direction = ParameterDirection.InputOutput;
                outparam.DbType = DbType.Int32;
                outparam.Value = 0;
                cmd.Parameters.Add(outparam);
                cmd.Connection = db.connect_pettycash();
                cmd.ExecuteNonQuery();
                int res = int.Parse(cmd.Parameters["@flag"].Value.ToString());
                return res;
            }
            finally
            {
                db.disconnect_pettycash();
            }
        }

        public DataTable getidno()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_get_idno";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                cmd.Connection = db.connect_pettycash();
                da.SelectCommand = cmd;
                da.Fill(dt);
                return dt;
            }
            finally
            {
                db.disconnect_pettycash();
            }
        }

        public DataTable filllogs_bymonth()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fill_logs";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                cmd.Connection = db.connect_pettycash();
                da.SelectCommand = cmd;
                da.Fill(dt);
                return dt;
            }
            finally
            {
                db.disconnect_pettycash();
            }
        }

        public int start_journal(int uid, DateTime idate)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_start_audit";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uid", uid);
                cmd.Parameters.AddWithValue("@idate", idate);
                SqlParameter outparam = new SqlParameter();
                outparam.ParameterName = "@flag";
                outparam.Direction = ParameterDirection.InputOutput;
                outparam.DbType = DbType.Int32;
                outparam.Value = 0;
                cmd.Parameters.Add(outparam);
                cmd.Connection = db.connect_pettycash();
                cmd.ExecuteNonQuery();
                int res = int.Parse(cmd.Parameters["@flag"].Value.ToString());
                return res;
            }
            finally
            {
                db.disconnect_pettycash();
            }
        }

        public int freeze(int cidno)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_freeze_audit";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cidno", cidno);
                SqlParameter outparam = new SqlParameter();
                outparam.ParameterName = "@flag";
                outparam.Direction = ParameterDirection.InputOutput;
                outparam.DbType = DbType.Int32;
                outparam.Value = 0;
                cmd.Parameters.Add(outparam);
                cmd.Connection = db.connect_pettycash();
                cmd.ExecuteNonQuery();
                int res = int.Parse(cmd.Parameters["@flag"].Value.ToString());
                return res;
            }
            finally
            {
                db.disconnect_pettycash();
            }
        }

        public int withdraw(int uid, int pmid, DateTime sdate, string rno, string item_name, int qty, double item_amount, string item_description, string bill_upload, string voucher_upload)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_withdraw";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uid", uid);
                cmd.Parameters.AddWithValue("@pmid", pmid);
                cmd.Parameters.AddWithValue("@sdate", sdate);
                cmd.Parameters.AddWithValue("@rno", rno);
                cmd.Parameters.AddWithValue("@item_name", item_name);
                cmd.Parameters.AddWithValue("@qty", qty);
                cmd.Parameters.AddWithValue("@item_amount", item_amount);
                cmd.Parameters.AddWithValue("@item_description", item_description);
                cmd.Parameters.AddWithValue("@bill_upload", bill_upload);
                cmd.Parameters.AddWithValue("@voucher_upload", voucher_upload);
                SqlParameter outparam = new SqlParameter();
                outparam.ParameterName = "@flag";
                outparam.Direction = ParameterDirection.InputOutput;
                outparam.DbType = DbType.Int32;
                outparam.Value = 0;
                cmd.Parameters.Add(outparam);
                cmd.Connection = db.connect_pettycash();
                cmd.ExecuteNonQuery();
                int res = int.Parse(cmd.Parameters["@flag"].Value.ToString());
                return res;
            }
            finally
            {
                db.disconnect_pettycash();
            }
        }

        public DataTable fetchexpenses()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fetchexpenses";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                cmd.Connection = db.connect_pettycash();
                da.SelectCommand = cmd;
                da.Fill(dt);
                return dt;
            }
            finally
            {
                db.disconnect_pettycash();
            }
        }

        public DataTable fetchsdatejornal()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fetchsdatejornal";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                cmd.Connection = db.connect_pettycash();
                da.SelectCommand = cmd;
                da.Fill(dt);
                return dt;
            }
            finally
            {
                db.disconnect_pettycash();
            }
        }

        public DataTable generatereport()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_monthlyreport";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                cmd.Connection = db.connect_pettycash();
                da.SelectCommand = cmd;
                da.Fill(dt);
                return dt;
            }
            finally
            {
                db.disconnect_pettycash();
            }
        }

        public DataTable fill_latest()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fill_latest";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                cmd.Connection = db.connect_pettycash();
                da.SelectCommand = cmd;
                da.Fill(dt);
                return dt;
            }
            finally
            {
                db.disconnect_pettycash();
            }
        }

        public DataTable fill_ongoing(int idno)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_journal_details";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idno", idno);
                SqlParameter outparam = new SqlParameter();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                cmd.Connection = db.connect_pettycash();
                da.SelectCommand = cmd;
                da.Fill(dt);
                return dt;
            }
            finally
            {
                db.disconnect_pettycash();
            }
        }

        public DataTable fetch_mail_details(string role)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fetch_mail_details";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@role", role);
                SqlParameter outparam = new SqlParameter();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                cmd.Connection = db.connect_pettycash();
                da.SelectCommand = cmd;
                da.Fill(dt);
                return dt;
            }
            finally
            {
                db.disconnect_pettycash();
            }
        }

        public DataTable fill_ongoing_excel(int idno)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_journal_details_excel";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idno", idno);
                SqlParameter outparam = new SqlParameter();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                cmd.Connection = db.connect_pettycash();
                da.SelectCommand = cmd;
                da.Fill(dt);
                return dt;
            }
            finally
            {
                db.disconnect_pettycash();
            }
        }

        public DataTable fill_ongoing_excel1(int idno)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_journal_details_excel1";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idno", idno);
                SqlParameter outparam = new SqlParameter();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                cmd.Connection = db.connect_pettycash();
                da.SelectCommand = cmd;
                da.Fill(dt);
                return dt;
            }
            finally
            {
                db.disconnect_pettycash();
            }
        }

        public int check_entry_count()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_check_entry_count";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter outparam = new SqlParameter();
                outparam.ParameterName = "@flag";
                outparam.Direction = ParameterDirection.InputOutput;
                outparam.DbType = DbType.Int32;
                outparam.Value = 0;
                cmd.Parameters.Add(outparam);
                cmd.Connection = db.connect_pettycash();
                cmd.ExecuteNonQuery();
                int res = int.Parse(cmd.Parameters["@flag"].Value.ToString());
                return res;
            }
            finally
            {
                db.disconnect_pettycash();
            }
        }
    }
}
