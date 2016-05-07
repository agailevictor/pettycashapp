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
    public partial class Assign : System.Web.UI.Page
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
                    assignee_user();
                    grid_assigned_fill();

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

        public void assignee_user()
        {
            DataTable dt = bus.assignee_user();
            ddl_assign_user.DataSource = dt;
            ddl_assign_user.DataBind();
            ddl_assign_user.Items.Insert(0, new ListItem("-----SELECT-----", ""));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //string val= DropDownList1.SelectedValue;
            if (ddl_assign_user.SelectedIndex != 0)
            {
                bus.uid = int.Parse(ddl_assign_user.SelectedValue);
                int res = bus.insert_assigne();
                if (res == 0)
                {

                    grid_assigned_fill();
                    assignee_user();
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success_assign();", true);
                }
                else
                {

                    grid_assigned_fill();
                    assignee_user();
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_assign();", true);
                }
            }
            else
            {

                grid_assigned_fill();
                assignee_user();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_ddl_empty();", true);                
            }
        }

        public void grid_assigned_fill()
        {
            DataTable gau = bus.grid_assigned_fill();
            if (gau.Rows.Count > 0)
            {
                grid_assigned_user.DataSource = gau;
                grid_assigned_user.DataBind();
                Button1.Attributes.Add("disabled", "disabled");
            }
            else
            {
                grid_assigned_user.DataSource = new DataTable();
                grid_assigned_user.DataBind();
            }
        }        

        protected void lnk_rmv_assign_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            GridViewRow row = lnk.NamingContainer as GridViewRow;
            bus.uid=int.Parse(grid_assigned_user.DataKeys[row.RowIndex].Value.ToString());
            int res = bus.remove_assignee();
            if (res == 1)
            {
                assignee_user();
                grid_assigned_fill();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success_unassign();", true);
            }
            else
            {
                assignee_user();
                grid_assigned_fill();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "failure_unassign();", true);
            }
        }        
    }
}