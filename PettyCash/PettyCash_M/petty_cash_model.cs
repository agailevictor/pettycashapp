using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace PettyCash_M
{
    public class petty_cash_model
    {
        SqlCommand cmd = new SqlCommand();
        db_connect db = new db_connect();
        public int login(string uname, string pwd)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_check_login";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uname", uname);
                cmd.Parameters.AddWithValue("@pwd", pwd);
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

        public DataTable fetch_userdetails(string uname)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fetch_user_details";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uname", uname);
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

        public int chk_assigne_status(int uid)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_check_assigne_status";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uid", uid);
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

        public DataTable assignee_user()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_get_assign_user";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                cmd.Connection = db.connect_pettycash();
                da.Fill(dt);
                return dt;
            }
            finally
            {
                db.disconnect_pettycash();
            }
        }

        public int insert_assigne(int uid)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_assign_new_user";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uid", uid);
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

        public DataTable grid_assigned_fill(int uid)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_assigned_users";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                cmd.Connection = db.connect_pettycash();
                da.Fill(dt);
                return dt;
            }
            finally
            {
                db.disconnect_pettycash();
            }
        }

        public int remove_assignee(int uid)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_remove_assigne";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uid", uid);
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

        public DataTable journal_list_view()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_journal_list_view";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                cmd.Connection = db.connect_pettycash();
                da.Fill(dt);
                return dt;
            }
            finally
            {
                db.disconnect_pettycash();
            }
        }

        public int deposited(int uid, int pmid, DateTime sdate, string rno, double amt, string bill_upload, string voucher_upload)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_amt_deposit";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uid", uid);
                cmd.Parameters.AddWithValue("@pmid", pmid);
                cmd.Parameters.AddWithValue("@sdate", sdate);
                cmd.Parameters.AddWithValue("@rno", rno);
                cmd.Parameters.AddWithValue("@amt", amt);
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

        public int delete_entry(int id)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_delete_entry";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
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

        public DataTable edit_journal(int id)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_edit_journal";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                cmd.Connection = db.connect_pettycash();
                da.Fill(dt);
                return dt;
            }
            finally
            {
                db.disconnect_pettycash();
            }
        }

        public int update_addentry(int id,string type,DateTime sdate,string rno,string item,double amt,string bill_upload, string voucher_upload,string description)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_update_entry";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@sdate", sdate);
                cmd.Parameters.AddWithValue("@rno", rno);
                cmd.Parameters.AddWithValue("@item", item);
                cmd.Parameters.AddWithValue("@amt", amt);
                cmd.Parameters.AddWithValue("@bill_upload", bill_upload);
                cmd.Parameters.AddWithValue("@voucher_upload", voucher_upload);
                cmd.Parameters.AddWithValue("@description", description);
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

        public DataTable ddl_type()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_dd_type_fill";
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                cmd.Connection = db.connect_pettycash();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            finally
            {
                db.disconnect_pettycash();
            }
        }

        public DataTable bill_path(int id)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_bill_path";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                DataTable dt = new DataTable();
                cmd.Connection = db.connect_pettycash();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            finally
            {
                db.disconnect_pettycash();
            }
        }

        public DataTable vhr_path(int id)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_vhr_path";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                DataTable dt = new DataTable();
                cmd.Connection = db.connect_pettycash();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            finally
            {
                db.disconnect_pettycash();
            }
        }
    }
}
