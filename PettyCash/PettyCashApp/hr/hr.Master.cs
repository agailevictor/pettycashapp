using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PettyCashApp.hr
{
    public partial class hr : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbluname.Text = Session["name"].ToString();
                SetCurrentPage();
            }
        }

        private void SetCurrentPage()
        {
            var pageName = GetPageName();

            switch (pageName)
            {
                case "dash.aspx":
                    dash.Attributes["class"] = "active";
                    break;
                case "Journal.aspx":
                    design.Attributes["class"] = "has-submenu active";
                    design1.Attributes["class"] = "active";
                    break;
                case "Assign.aspx":
                    settings.Attributes["class"] = "has-submenu active";
                    settings1.Attributes["class"] = "active";
                    break;
                case "Report1.aspx":
                    report.Attributes["class"] = "has-submenu active";
                    report1.Attributes["class"] = "active";
                    break;
                case "Report2.aspx":
                    report.Attributes["class"] = "has-submenu active";
                    report2.Attributes["class"] = "active";
                    break;
                case "defreeze.aspx":
                    settings.Attributes["class"] = "has-submenu active";
                    settings2.Attributes["class"] = "active";
                    break;
            }
        }

        private string GetPageName()
        {
            return Request.Url.ToString().Split('/').Last();
        }
    }
}