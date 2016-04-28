using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PettyCash_M;
using System.Data;

namespace PettyCash_C
{
    
    public class petty_cash_Con
    {
        petty_cash_model data = new petty_cash_model();
        public string uname { get; set; }
        public string pwd { get; set; }
        public int uid { get; set; }
        public string item { get; set; }
        public double amt { get; set; }
        public string description { get; set; }
        public DateTime sdate { get; set; }
        public string rno { get; set; }
        public int pmid { get; set; }
        public int id { get; set; }
        public string type { get; set; }
        public string bill_upload { get; set; }
        public string voucher_upload { get; set; }
        public double amt_edit { get; set; }
        
        public int login()
        {
            return data.login(uname,pwd);
        }

        public DataTable fetch_userdetails()
        {
            return data.fetch_userdetails(uname);
        }

        public int chk_assigne_status()
        {
            return data.chk_assigne_status(uid);
        }

        public DataTable assignee_user()
        {
            return data.assignee_user();
        }

        public int insert_assigne()
        {
            return data.insert_assigne(uid);
        }

        public DataTable grid_assigned_fill()
        {
            return data.grid_assigned_fill(uid);
        }

        public int remove_assignee()
        {
            return data.remove_assignee(uid);
        }
        public DataTable journal_list_view()
        {
            return data.journal_list_view();
        }
        public int deposited()
        {
            return data.deposited(uid, pmid, sdate, rno, amt, bill_upload, voucher_upload);
        }
        public int delete_entry()
        {
            return data.delete_entry(id);
        }
        public DataTable edit_journal()
        {
            return data.edit_journal(id);
        }

        public int update_addentry()
        {
            return data.update_addentry(id, type, sdate, rno, item, amt,amt_edit,bill_upload, voucher_upload, description);
        }

        public DataTable ddl_type()
        {
            return data.ddl_type();
        }

        public DataTable bill_path()
        {
            return data.bill_path(id);
        }

        public DataTable vhr_path()
        {
            return data.vhr_path(id);
        }

        public DataTable fill_startdate_ddl()
        {
            return data.fill_startdate_ddl();
        }

        public DataTable rpt_htry_Click()
        {
            return data.rpt_htry_Click(pmid);
        }
    }
}
