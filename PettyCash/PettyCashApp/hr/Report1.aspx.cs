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
using System.IO;


namespace PettyCashApp.hr
{
    public partial class Report1 : System.Web.UI.Page
    {
        business_pettycash bus = new business_pettycash();
        ReportDocument rd = new ReportDocument();
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
            // get the latest idno
                DataTable cidno = bus.getidno();
                Session["current_idno"] = cidno.Rows[0][0].ToString();
                fill_ongoing();
        }

        public void fill_ongoing()
        {
            bus.cidno = int.Parse(Session["current_idno"].ToString());
            DataTable og = bus.fill_ongoing();
            if (og.Rows.Count > 0)
            {
                grd_ogrpt.DataSource = og;
                grd_ogrpt.DataBind();
            }
            else
            {
                grd_ogrpt.DataSource = new DataTable();
                grd_ogrpt.DataBind();
                btn_exl.Visible = false;
                btn_pdf.Visible = false;
            }
        }

        protected void btn_pdf_Click(object sender, EventArgs e)
        {
            export_pdf();
        }

        protected void btn_exl_Click(object sender, EventArgs e)
        {
            export_excel();
        }

        protected void export_excel()
        {
            bus.cidno = int.Parse(Session["current_idno"].ToString());            
            DataTable dtexl = bus.fill_ongoing_excel();
            DataTable dtexl1 = bus.fill_ongoing_excel1();
            if (dtexl.Rows.Count > 0)
            {
                DataGrid grid = new DataGrid();
                grid.HeaderStyle.Font.Bold = true;
                grid.DataSource = dtexl1;
                grid.DataBind();
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=Ongoing_Report.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                Response.Write("<b>Ongoing Report as on : " + DateTime.Now.ToString("dd/MM/yyyy") + "</b><br>");
                Response.Write("<b>Opening Date : " + dtexl.Rows[0][2].ToString() + "</b><br>");
                Response.Write("<b>Opening Balance : " + dtexl.Rows[0][7].ToString() + "</b><br>");
                Response.Write("<b>Opened By : " + dtexl.Rows[0][4].ToString() + "</b><br>");
                Response.Write("<b>Freezed Date :</b><br><br>");
                StringWriter StringWriter = new System.IO.StringWriter();
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                grid.RenderControl(HtmlTextWriter);
                Response.Write(StringWriter.ToString());
                Response.End();
                dtexl.Dispose();
            }
            else
            {

            }
        }

        protected void export_pdf()
        {
            bus.cidno = int.Parse(Session["current_idno"].ToString());
            DataTable dtpdf = bus.fill_ongoing();
            if (dtpdf.Rows.Count > 0)
            {
                rd.Load(Server.MapPath(Request.ApplicationPath) + "/user/OngoingReport.rpt");
                rd.SetDataSource(dtpdf);
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Onging_Report");
                dtpdf.Dispose();
            }
            else
            {

            }
        }

        protected void grd_ogrpt_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_ogrpt.PageIndex = e.NewPageIndex;
            fill_ongoing();
        }
    }
}