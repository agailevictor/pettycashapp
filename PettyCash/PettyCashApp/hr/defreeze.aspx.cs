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
    public partial class defreeze : System.Web.UI.Page
    {
        petty_cash_Con bus = new petty_cash_Con();
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
                    grid_defreeze();
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
        
       
        protected void grid_defreeze()
        {
            DataTable dt = bus.grid_defreeze();
            if(dt.Rows.Count>0)
            {
                grid_users_defreeze.DataSource = dt;
                grid_users_defreeze.DataBind();
            }
            else
            {
                grid_users_defreeze.DataSource = null;
                grid_users_defreeze.DataBind();
            }
        }

        protected void lnk_defreeze_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            GridViewRow row = lnk.NamingContainer as GridViewRow;
            bus.pmid = int.Parse(grid_users_defreeze.DataKeys[row.RowIndex].Value.ToString());
            int res = bus.defreeze();
            if(res==1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success_defreeze();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_defreeze();", true);
            }
        }
    }
}