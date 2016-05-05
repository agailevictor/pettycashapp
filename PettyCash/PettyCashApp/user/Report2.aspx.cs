using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PettyCash_C;
using System.Data;
using System.Net;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using System.IO;

namespace PettyCashApp.user
{
    public partial class Report2 : System.Web.UI.Page
    {
        petty_cash_Con bus = new petty_cash_Con();
        business_pettycash bus2 = new business_pettycash();
        ReportDocument rd = new ReportDocument();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fill_startdate_ddl();
                btn_pdf.Visible = false;
                btn_excel.Visible = false;
            }
        }

        //Load Dropdownlist with Date
        public void fill_startdate_ddl()
        {
            DataTable dt = bus.fill_startdate_ddl();
            start_date.DataSource = dt;
            start_date.DataBind();
            start_date.Items.Insert(0, new ListItem("-----SELECT-----", ""));
        }

        //Get Report Button
        protected void rpt_htry_Click(object sender, EventArgs e)
        {
            if (start_date.SelectedIndex != 0)
            {
                rpt_grid_fill();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_ddl_empty();", true);
            }
        }
        //Get Pdf Report
        protected void btn_pdf_Click(object sender, EventArgs e)
        {
            int pmid = int.Parse(Session["pmid_rpt"].ToString());
            bus.pmid = pmid;
            DataTable dtpdf = bus.rpt_htry_Click();
            if (dtpdf.Rows.Count > 0)
            {
                rd.Load(Server.MapPath(Request.ApplicationPath) + "/user/rpt_history.rpt");
                rd.SetDataSource(dtpdf);
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Report_History");
                dtpdf.Dispose();
            }
        }

        //Export to Excel
        protected void btn_excel_Click(object sender, EventArgs e)
        {
            export_excel();            
        }

        protected void export_excel()
        {           
            bus2.cidno = int.Parse(Session["pmid_rpt"].ToString());
            DataTable dtexl = bus2.fill_ongoing_excel();
            DataTable dtexl1 = bus2.fill_ongoing_excel1();
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
                Response.Write("<b>Freezed Date :"+ dtexl.Rows[0][8].ToString() + "</b><br><br>");
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

        //Pagination
        protected void rpt_grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            rpt_grid.PageIndex = e.NewPageIndex;
            rpt_grid_fill();
        }

        public void rpt_grid_fill()
        {
            Session["pmid_rpt"] = int.Parse(start_date.SelectedItem.Value);
            int pmid = int.Parse(Session["pmid_rpt"].ToString());
            bus.pmid = pmid;
            DataTable dt = bus.rpt_htry_Click();
            if (dt.Rows.Count > 0)
            {
                rpt_grid.DataSource = dt;
                rpt_grid.DataBind();
                btn_pdf.Visible = true;
                btn_excel.Visible = true;
                rd.Load(Server.MapPath(Request.ApplicationPath) + "/user/rpt_history.rpt");
                rd.SetDataSource(dt);
            }
            else
            {
                rpt_grid.DataSource = null;
                rpt_grid.DataBind();
                btn_pdf.Visible = false;
                btn_excel.Visible = false;
            }
        }
    }
}