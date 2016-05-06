using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PettyCash_C;
using System.Data;
using System.Net;

namespace PettyCashApp.hr
{
    public partial class Journal : System.Web.UI.Page
    {
        petty_cash_Con bus = new petty_cash_Con();
        WebClient client = new WebClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
                    fill_startdate_ddl();

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

        public void fill_startdate_ddl()
        {
            DataTable dt = bus.fill_startdate_ddl();
            start_date.DataSource = dt;
            start_date.DataBind();
            start_date.Items.Insert(0, new ListItem("-----SELECT-----", ""));
        }

        public void grd_junl()
        {
            Session["pmid_rpt"] = int.Parse(start_date.SelectedItem.Value);            
            bus.pmid = int.Parse(Session["pmid_rpt"].ToString());
            DataTable dt = bus.rpt_htry_Click_hr();
            if (dt.Rows.Count > 0)
            {
                junl_grid.DataSource = dt;
                junl_grid.DataBind();                
            }
            else
            {
                junl_grid.DataSource = null;
                junl_grid.DataBind();                
            }
        }
        
        protected void jnul_hrty_Click(object sender, EventArgs e)
        {
            if (start_date.SelectedIndex != 0)
            {
                grd_junl();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_ddl_empty();", true);
            }
        }

        protected void rpt_grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            junl_grid.PageIndex = e.NewPageIndex;
            grd_junl();
        }

        protected void lnk_bill_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            GridViewRow row = lnk.NamingContainer as GridViewRow;
            bus.id = int.Parse(junl_grid.DataKeys[row.RowIndex].Value.ToString());
            DataTable dt = bus.bill_path();
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
            bus.id = int.Parse(junl_grid.DataKeys[row.RowIndex].Value.ToString());
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
    }
}