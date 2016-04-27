using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using PettyCash_C;

namespace PettyCashApp.user
{
    public partial class start_journal : System.Web.UI.Page
    {
        business_pettycash bus = new business_pettycash();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                checklogin();

                txtsjdate.Attributes.Add("readonly", "readonly");
            }
        }
        protected void checklogin()
        {
            if (Session["is_login"] != null)
            {
                if (Session["is_login"].ToString() == "t")
                {
                    fetch_details();

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

        protected void fetch_details()
        {
            bus.uid = int.Parse(Session["user_id"].ToString());
            DataTable dt = bus.fetch_details();
            if(dt.Rows.Count > 0)
            {
                lbluser.Text = dt.Rows[0][0].ToString();
                lblregion.Text = dt.Rows[0][1].ToString();
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            if(lbluser.Text !="" && lblregion.Text !="" && txtsjdate.Text !="")
            {
                bus.uid = int.Parse(Session["user_id"].ToString());
                bus.sdate = DateTime.Parse(txtsjdate.Text);
                int r = bus.start_journal();
                if(r==1)
                {
                    Session["audit_start"] = "t";
                    clearfields();
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success_jstart();", true);
                }
                else
                {
                    Session["audit_start"] = "f";
                    clearfields();
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_jstart();", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "empty_fields();", true);
            }
        }

        protected void clearfields()
        {
            txtsjdate.Text = "";
        }
    }
}