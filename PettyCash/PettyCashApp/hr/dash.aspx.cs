using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using PettyCash_C;
using System.Web.Services;


namespace PettyCashApp.hr
{
    public partial class dash : System.Web.UI.Page
    {
        business_pettycash bus = new business_pettycash();
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
                if (Session["is_login"].ToString() == "f")
                {
                    Response.Redirect("~/unauthorised.aspx");
                }
                else
                {
                    check_audit_start();
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        public void check_audit_start()
        {
            int r = bus.check_audit_start();
            if (r == 1) // audit is started
            {
                // get the latest idno

                DataTable cidno = bus.getidno();
                Session["current_idno"] = cidno.Rows[0][0].ToString();
                Session["audit_start"] = "t";

                // fill latest entry
                fill_latest();
            }
            else
            {
                Session["audit_start"] = "f";
                fill_latest();
            }
        }

        [WebMethod]
        public static List<Expenses> fetchexpenses()
        {
            List<Expenses> expenses = new List<Expenses>();
            business_pettycash bus = new business_pettycash();
            DataTable dt = bus.fetchexpenses();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Expenses _Expenses = new Expenses();
                _Expenses.Type = dt.Rows[i]["typ"].ToString();
                _Expenses.Amount = dt.Rows[i]["amount"].ToString();
                _Expenses.Percent = dt.Rows[i]["per"].ToString();
                expenses.Add(_Expenses);
            }
            return expenses;
        }

        protected void fill_latest()
        {
            DataTable dt = bus.fill_latest();
            if (dt.Rows.Count > 0)
            {
                grd_latest.DataSource = dt;
                grd_latest.DataBind();
            }
            else
            {
                grd_latest.DataSource = null;
                grd_latest.DataBind();
            }
        }

        protected void grd_latest_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_latest.PageIndex = e.NewPageIndex;
            fill_latest();
        }
    }
}