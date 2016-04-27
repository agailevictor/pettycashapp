using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PettyCashApp
{
    public partial class MainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                check_multiple_login();
            }
        }

        public void check_multiple_login()
        {
            if (Session["is_login"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                if (Session["is_login"].ToString() == "t")
                {
                    if (Session["role"].ToString() == "User")
                    {
                        Response.Redirect("~/user/dash.aspx");
                    }
                    else if (Session["role"].ToString() == "HR")
                    {
                        Response.Redirect("~/hr/dash.aspx");
                    }                    
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }
    }
}