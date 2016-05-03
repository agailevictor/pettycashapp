using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PettyCash_C;
using System.Data;

namespace PettyCashApp.hr
{
    public partial class Journal : System.Web.UI.Page
    {
        petty_cash_Con bus = new petty_cash_Con();
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
            int pmid = int.Parse(Session["pmid_rpt"].ToString());
            bus.pmid = pmid;
            DataTable dt = bus.rpt_htry_Click();
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
    }
}