using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using PettyCash_C;
using System.Net;

namespace PettyCashApp.user
{
    public partial class JournalList : System.Web.UI.Page
    {
        petty_cash_Con bus = new petty_cash_Con();
        WebClient client = new WebClient();
        //business_pettycash bus = new business_pettycash();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                checklogin();
            }

        }
        protected void checklogin()
        {
            if (Session["is_login"] != null)
            {
                if (Session["is_login"].ToString() == "t")
                {
                    string checker = Session["audit_start"].ToString();
                    if (checker == "t") // audit is started
                    {
                        journal_list_view();
                    }
                    else
                    {
                        aeTag.Visible = false;
                    }
                }
                else
                {
                    Response.Redirect("~/unauthorised.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        protected Boolean Isenable(string visible)
        {
            if (visible == "No")
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public void journal_list_view()
        {
            DataTable dt = bus.journal_list_view();
            if(dt.Rows.Count > 0)
            {                
                grid_ongoing_details.DataSource = dt;
                grid_ongoing_details.DataBind();
            }
            else
            {
                grid_ongoing_details.DataSource = null;
                grid_ongoing_details.DataBind();
            }
        }

        protected void edit_link_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            GridViewRow row = lnk.NamingContainer as GridViewRow;            
            Session["id"] = int.Parse(grid_ongoing_details.DataKeys[row.RowIndex].Value.ToString());
            Session["ty"] = row.Cells[2].Text.ToString().Trim();
            Session["amt_edit"] = row.Cells[6].Text.ToString().Trim();
            Session["vhr_name"]=row.Cells[8].Text.ToString().Trim();
            Response.Redirect("~/user/edit_journal.aspx");
        }

        protected void delete_link_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            GridViewRow row = lnk.NamingContainer as GridViewRow;
            bus.id = int.Parse(grid_ongoing_details.DataKeys[row.RowIndex].Value.ToString());
            int res=bus.delete_entry();
            if(res==1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success_delete();", true);
                journal_list_view();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "failure_unassign();", true);
                journal_list_view();
            }
        }

        protected void lnk_bill_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            GridViewRow row = lnk.NamingContainer as GridViewRow;
            bus.id = int.Parse(grid_ongoing_details.DataKeys[row.RowIndex].Value.ToString());
            DataTable dt= bus.bill_path();
            string bill_half = dt.Rows[0][0].ToString();
            string bill_path = Server.MapPath(bill_half);
            Byte[] buffer = client.DownloadData(bill_path);
            if (buffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", buffer.Length.ToString());
                Response.BinaryWrite(buffer);
            }
        }

        protected void lnk_vhr_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            GridViewRow row = lnk.NamingContainer as GridViewRow;
            bus.id = int.Parse(grid_ongoing_details.DataKeys[row.RowIndex].Value.ToString());
            DataTable dt = bus.vhr_path();
            string vhr_half = dt.Rows[0][0].ToString();
            string vhr_path = Server.MapPath(vhr_half);
            Byte[] buffer = client.DownloadData(vhr_path);
            if (buffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", buffer.Length.ToString());
                Response.BinaryWrite(buffer);
            }
        }

        protected void grid_ongoing_details_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grid_ongoing_details.PageIndex = e.NewPageIndex;
            journal_list_view();
        }
    }
}