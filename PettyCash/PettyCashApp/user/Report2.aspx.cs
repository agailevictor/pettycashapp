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
            int pmid = int.Parse(Session["pmid_rpt"].ToString());
            bus.pmid = pmid;
            DataTable dtexl = bus.rpt_htry_Click();
            if (dtexl.Rows.Count > 0)
            {
                DataGrid grid = new DataGrid();
                grid.HeaderStyle.Font.Bold = true;
                grid.DataSource = dtexl;
                grid.DataBind();
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=History_Report.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                Response.Write("<b> Report History :" + DateTime.Now.ToString("dd/MM/yyyy") + "</b><br>");
                StringWriter StringWriter = new System.IO.StringWriter();
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                grid.RenderControl(HtmlTextWriter);
                Response.Write(StringWriter.ToString());
                Response.End();
                dtexl.Dispose();
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