using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using PettyCash_C;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Web.Mail;

namespace PettyCashApp.user
{
    public partial class Template : System.Web.UI.Page
    {
        business_pettycash bus = new business_pettycash();
        ReportDocument rd = new ReportDocument();
        string url = "http://uoa.hummingsoft.com.my:8065/petty_cash/ target=\"_blank\"";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                checklogin();

            }
            else
            {
                DataTable cidno = bus.getidno();
                Session["current_idno"] = cidno.Rows[0][0].ToString();
            }
               
        }

        protected void checklogin()
        {
            if (Session["is_login"] != null)
            {
                if (Session["is_login"].ToString() == "t")
                {
                    check_audit_start();

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

        public void check_audit_start()
        {
            string checker = Session["audit_start"].ToString();
            if (checker == "t") // audit is started
            {
                //aTag.Attributes.Add("disabled", "disabled");
                aTag.Visible = false;

                // fill logs of the month
                filllogs();
            }
            else
            {
                btnfreeze.Visible = false;
                filllogs();
            }
        }

        public void filllogs()
        {
            //bus.cidno = int.Parse(Session["current_idno"].ToString());
            DataTable dt = bus.filllogs_bymonth();
            if (dt.Rows.Count > 0)
            {
                grid_ongoing_details.DataSource = dt;
                grid_ongoing_details.DataBind();
            }
            else
            {
                grid_ongoing_details.DataSource = null;
                grid_ongoing_details.DataBind();
            }
        }

        protected void btnfreeze_Click(object sender, EventArgs e)
        {
            bus.cidno = int.Parse(Session["current_idno"].ToString());
            int f = bus.freeze();
            if(f == 1)
            {
                
                // generate report and send email the report as attachment
                
                bool check = SendWebMail("agaile@hummingsoft.com.my", "Monthly Report Of Petty Cash", "", "", "", "info@hummingsoft.com.my");

                if (check == true)
                {
                    Session["audit_start"] = "f";
                    check_audit_start();
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success_freeze();", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_mail();", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_freeze();", true);
            }
        }

        private bool SendWebMail(string strTo, string subj, string cont, string cc, string bcc, string strfrom)
        {
            // generate reports
            DataTable dre = bus.generatereport();
            rd.Load(Server.MapPath(Request.ApplicationPath) + "/user/MonthlyReport.rpt");
            rd.SetDataSource(dre);

            // location of empty pdf file
            string filename = Server.MapPath("~/pdf/Monthly_Report.pdf");

            // export the report to pdf and write to empty pdf file inside pdf folder
            ExportOptions CrExportOptions;
            DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
            PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
            CrDiskFileDestinationOptions.DiskFileName = filename;
            CrExportOptions = rd.ExportOptions;//Report document  object has to be given here
            CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
            CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
            CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
            CrExportOptions.FormatOptions = CrFormatTypeOptions;
            rd.Export();

            // send email with attachment

            bool flg = false;
            MailMessage msg = new MailMessage();
            msg.Body = "<table  border='1' cellpadding='0' cellspacing='0' style='width: 750px; border-color: black;'><tr><td colspan='9'><br>&nbsp &nbspDear Sir / Madam,<br /><br />&nbsp&nbsp&nbsp&nbsp&nbspPFA Monthly report for the Month of <b>" + dre.Rows[0][5].ToString() + dre.Rows[0][6].ToString() + "</b>. The details are as follows.<br /><br /></td></tr><tr style='font-weight: 700;'></tr><tr><td colspan='9'><br/><p></p><p> &nbsp&nbsp&nbspOpening Date:   " + dre.Rows[0][2].ToString() + "</p><p>&nbsp&nbsp&nbspOpening Balance:   " + dre.Rows[0][7].ToString() + "</p><p>&nbsp&nbsp&nbspOpened By:   " + dre.Rows[0][4].ToString() + " </p><p>&nbsp&nbsp&nbspFreezed Date:   " + dre.Rows[0][3].ToString() + " </p><p>&nbsp&nbsp&nbspclick<a href=" + url + "> here </a>to login into the application</p><br/></td></tr><tr></tr><td colspan='9' style='font-weight: bold' align='right'><br /><br />Regards,<br />Team Petty Cash App</td></tr><tr><td align='center'><p style='color:blue;'> This is a system generated response. Please do not respond to this email id.</p></td></tr></table>"; 
            msg.From = strfrom;
            msg.To = strTo;
            msg.Subject = subj;
            msg.Cc = cc;
            msg.Bcc = bcc;
            //System.Net.Mail.Attachment attach;
            //attach = new System.Net.Mail.Attachment()
            msg.Attachments.Add(new MailAttachment(filename));
            msg.BodyFormat = MailFormat.Html;
            try
            {
                SmtpMail.SmtpServer = "175.143.44.165";
                //SmtpMail.SmtpServer = "192.168.1.4"; // change the ip address to this when hosting in server
                SmtpMail.Send(msg);
                flg = true;
            }
            catch (Exception)
            {
                flg = false;
            }
            return flg;
        }

        protected void grid_ongoing_details_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grid_ongoing_details.PageIndex = e.NewPageIndex;
            filllogs();
        }


    }
}