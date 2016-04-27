using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PettyCash_C;
using System.Text;
using System.Data;
using System.Security.Cryptography;

namespace PettyCashApp
{
    public partial class Login : System.Web.UI.Page
    {
        petty_cash_Con bus = new petty_cash_Con();
        string hashed;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                inval.Visible = false;
            }
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            if (txtuname.Text != "" && txtpswd.Text != "")
            {
                hashed = MD5Hash(txtpswd.Text.Trim());
                if (hashed != "")
                {
                    bus.uname = txtuname.Text;
                    bus.pwd = hashed;
                    int res = bus.login();
                    if (res == 1)
                    {
                        inval.Visible = false;
                        setsession();
                    }
                    else
                    {
                        txtuname.Text = "";
                        txtpswd.Text = "";
                        inval.Visible = true;
                    }
                }
                else
                {
                    txtuname.Text = "";
                    txtpswd.Text = "";
                    inval.Visible = true;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "empty_uname_pswd();", true);
            }
            
        }

        public void setsession()
        {
            bus.uname = txtuname.Text;
            DataTable dt = bus.fetch_userdetails();
            if (dt.Rows.Count > 0)
            {
                Session["user_id"] = dt.Rows[0][0].ToString();
                Session["name"] = dt.Rows[0][1].ToString();
                Session["gender"] = dt.Rows[0][2].ToString();
                Session["doj"] = dt.Rows[0][3].ToString();
                Session["dep"] = dt.Rows[0][4].ToString();
                Session["des"] = dt.Rows[0][5].ToString();
                Session["role"] = dt.Rows[0][6].ToString();
                Session["region"] = dt.Rows[0][7].ToString();
                Session["is_login"] = "t";
                if (Session["role"].ToString() == "User")
                {
                    bus.uid = int.Parse(Session["user_id"].ToString());
                    int val = bus.chk_assigne_status();
                    if (val == 1)
                    {
                        Response.Redirect("~/user/dash.aspx");
                    }
                }
                else if (Session["role"].ToString() == "HR")
                {
                    Response.Redirect("~/hr/dash.aspx");
                }
                else
                {
                    Response.Redirect("unauthorised.aspx");
                }
            }
        }

        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }    
}