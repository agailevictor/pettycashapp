using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PettyCash_M;

namespace PettyCash_C
{
    public class business_pettycash
    {
        data_pettycash data = new data_pettycash();

        public int uid { get; set; }
        public string idate { get; set; }
        public string rno { get; set; }
        public string item_name { get; set; }
        public double item_amount { get; set; }
        public string item_description { get; set; }
        public int cidno { get; set; }
        public DateTime sdate { get; set; }
        public int pmid { get; set; }
        public string bill_upload { get; set; }
        public string voucher_upload { get; set; }
        public int qty { get; set; }
        public string role { get; set; }
        
        public DataTable fetch_details()
        {
            return data.fetch_details(uid);
        }
        public int check_audit_start()
        {
            return data.check_audit_start();
        }
        public DataTable getidno()
        {
            return data.getidno();
        }
        public DataTable filllogs_bymonth()
        {
            return data.filllogs_bymonth();
        }
        public int start_journal()
        {
            return data.start_journal(uid, sdate);
        }
        public int freeze()
        {
            return data.freeze(cidno);
        }
        public int withdraw()
        {
            return data.withdraw(uid, pmid, sdate, rno, item_name,qty, item_amount, item_description, bill_upload, voucher_upload);
        }

        public DataTable fetchexpenses()
        {
            return data.fetchexpenses();
        }

        public DataTable fetchsdatejornal()
        {
            return data.fetchsdatejornal();
        }
        public DataTable generatereport()
        {
            return data.generatereport();
        }
        public DataTable fill_latest()
        {
            return data.fill_latest();
        }

        public DataTable fill_ongoing()
        {
            return data.fill_ongoing(cidno);
        }

        public DataTable fetch_mail_details()
        {
            return data.fetch_mail_details(role);
        }
        public DataTable fill_ongoing_excel()
        {
            return data.fill_ongoing_excel(cidno);
        }
        public DataTable fill_ongoing_excel1()
        {
            return data.fill_ongoing_excel1(cidno);
        }
    }
}
