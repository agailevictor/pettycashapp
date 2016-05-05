using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PettyCashApp
{
    public partial class unauthorised : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            clear_session();
        }

        protected void clear_session()
        {
            Session.Clear();
            Session["is_login"] = "f";
        }
    }
}