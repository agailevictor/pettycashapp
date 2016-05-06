using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using PettyCash_C;
using System.IO;
using System.Web.Services;

namespace PettyCashApp.user
{
    public partial class Journal : System.Web.UI.Page
    {
        business_pettycash bus = new business_pettycash();
        petty_cash_Con bus2 = new petty_cash_Con();
        int chk = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                checklogin();

                txtdate.Attributes.Add("readonly", "readonly");
            }
        }

        protected void checklogin()
        {
            if (Session["is_login"] != null)
            {
                if (Session["is_login"].ToString() == "t")
                {
                    check_audit_start();
                    ddl_type();
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
                // get the latest idno
                DataTable cidno = bus.getidno();
                Session["current_idno"] = cidno.Rows[0][0].ToString();
            }
            else if (checker == "f")
            {
                btnaddentry.Visible = false;
            }
        }


        [WebMethod]
        public static List<Dates> fetchsdatejornal()
        {
            List<Dates> dates = new List<Dates>();
            business_pettycash bus = new business_pettycash();
            DataTable dt = bus.fetchsdatejornal();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Dates _Dates = new Dates();
                _Dates.odate = dt.Rows[i]["odate"].ToString();
                dates.Add(_Dates);
            }
            return dates;
        }

        protected void btnaddentry_Click(object sender, EventArgs e)
        {
            if (txtdate.Text != "" && txtrcpt.Text != "" && ddltype.SelectedIndex != 0 && price1.Text != "")
            {
                if (ddltype.SelectedValue == "1") //withdraw
                {
                    if (fup_new.Checked)
                    {
                        if (bfp.HasFile && vfp.HasFile)
                        {
                            string ext_bill = System.IO.Path.GetExtension(bfp.FileName);
                            string ext_vhr = System.IO.Path.GetExtension(vfp.FileName);
                            if (ext_bill == ".pdf" && ext_vhr == ".pdf")
                            {
                                if (bfp.PostedFile.ContentLength < 3145728 && vfp.PostedFile.ContentLength < 3145728)
                                {
                                    FileInfo file_bill = new System.IO.FileInfo(bfp.PostedFile.FileName);
                                    string fname_bill = file_bill.Name.Remove((file_bill.Name.Length - file_bill.Extension.Length));
                                    fname_bill = fname_bill +"_" +txtrcpt.Text+"_b" + file_bill.Extension; // renaming file uploads
                                    string filename_bill = Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads/Bill_uploads/"), fname_bill);
                                    string filename_vir_bill = Path.Combine("~/Uploads/Bill_uploads/", fname_bill);

                                    FileInfo file_vhr = new System.IO.FileInfo(vfp.PostedFile.FileName);
                                    string fname_vhr = file_vhr.Name.Remove((file_vhr.Name.Length - file_vhr.Extension.Length));
                                    fname_vhr = fname_vhr + "_" + txtrcpt.Text + "_v" + file_vhr.Extension; // renaming file uploads
                                    string filename_vhr = Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads/Voucher_uploads/"), fname_vhr);
                                    string filename_vir_vhr = Path.Combine("~/Uploads/Voucher_uploads/", fname_vhr);

                                    string a = HiddenField1.Value;
                                    int counter = int.Parse(a);
                                    string item = item_name1.Text;
                                    string qty = txtqty.Text;
                                    string price = price1.Text;
                                    string desc = desc1.Text;
                                    string[] split_item = item.Split(',');
                                    string[] split_qty = qty.Split(',');
                                    string[] split_price = price.Split(',');
                                    string[] split_desc = desc.Split(',');
                                    for (int j = 0; j < counter; j++)
                                    {
                                        bus.uid = int.Parse(Session["user_id"].ToString());
                                        bus.pmid = int.Parse(Session["current_idno"].ToString());
                                        bus.sdate = DateTime.Parse(txtdate.Text);
                                        bus.rno = txtrcpt.Text;
                                        bus.item_name = split_item[j];
                                        bus.qty = int.Parse(split_qty[j]);
                                        bus.item_amount = double.Parse(split_price[j]);
                                        bus.item_description = split_desc[j];
                                        bus.bill_upload = filename_vir_bill;
                                        bus.voucher_upload = filename_vir_vhr;
                                        int w = bus.withdraw();
                                        if (w == 1) // Success
                                        {
                                            bfp.SaveAs(filename_bill);
                                            vfp.SaveAs(filename_vhr);                                            
                                        }
                                        else // Fail
                                        {
                                            chk = 0;
                                        }
                                    }
                                    if (chk == 1)
                                    {
                                        clearfields();
                                        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success_entry();", true);
                                    }
                                    else
                                    {
                                        clearfields();
                                        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_entry();", true);
                                    }
                                }
                                else
                                {
                                    //Size Error
                                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_size();", true);
                                }
                            }
                            else
                            {
                                //Extension Error
                                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_ext();", true);
                            }
                        }
                        else
                        {
                            //No File Present Error
                            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_nofile();", true);
                        }
                    }
                    else if (fup_new.Checked==false)    //If checkbox is not checked
                    {
                        if (bfp.HasFile)
                        {
                            string ext_bill = System.IO.Path.GetExtension(bfp.FileName);                            
                            if (ext_bill == ".pdf")
                            {
                                if (bfp.PostedFile.ContentLength < 3145728)
                                {
                                    FileInfo file_bill = new System.IO.FileInfo(bfp.PostedFile.FileName);
                                    string fname_bill = file_bill.Name.Remove((file_bill.Name.Length - file_bill.Extension.Length));
                                    fname_bill = fname_bill + "_" + txtrcpt.Text + "_b" + file_bill.Extension; // renaming file uploads
                                    string filename_bill = Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads/Bill_uploads/"), fname_bill);
                                    string filename_vir_bill = Path.Combine("~/Uploads/Bill_uploads/", fname_bill);

                                    string a = HiddenField1.Value;
                                    int counter = int.Parse(a);
                                    string item = item_name1.Text;
                                    string qty = txtqty.Text;
                                    string price = price1.Text;
                                    string desc = desc1.Text;
                                    string[] split_item = item.Split(',');
                                    string[] split_qty = qty.Split(',');
                                    string[] split_price = price.Split(',');
                                    string[] split_desc = desc.Split(',');
                                    for (int j = 0; j < counter; j++)
                                    {
                                        bus.uid = int.Parse(Session["user_id"].ToString());
                                        bus.pmid = int.Parse(Session["current_idno"].ToString());
                                        bus.sdate = DateTime.Parse(txtdate.Text);
                                        bus.rno = txtrcpt.Text;
                                        bus.item_name = split_item[j];
                                        bus.qty = int.Parse(split_qty[j]);
                                        bus.item_amount = double.Parse(split_price[j]);
                                        bus.item_description = split_desc[j];
                                        bus.bill_upload = filename_vir_bill;
                                        bus.voucher_upload = "";
                                        int w = bus.withdraw();
                                        if (w == 1) // Success
                                        {
                                            bfp.SaveAs(filename_bill);                                            
                                        }
                                        else // Fail
                                        {
                                            chk = 0;
                                        }
                                    }
                                    if (chk == 1)
                                    {
                                        clearfields();
                                        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success_entry();", true);
                                    }
                                    else
                                    {
                                        clearfields();
                                        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_entry();", true);
                                    }
                                }
                                else
                                {
                                    //Size Error
                                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_size();", true);
                                }
                            }
                            else
                            {
                                //Extension Error
                                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_ext();", true);
                            }
                        }
                        else
                        {
                            //No File Present Error
                            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_nofile();", true);
                        }
                    }
                    else
                    {
                        Response.Redirect("sessiontimeout.aspx");
                    }
                }
                else
                {
                    Response.Redirect("sessiontimeout.aspx");
                }
            }
            else if (txtdate.Text != "" && txtrcpt.Text != "" && ddltype.SelectedIndex != 0)
            {
                if (ddltype.SelectedValue == "2")
                {
                    if (fup_new.Checked)
                    {
                        if (bfp.HasFile && vfp.HasFile)
                        {
                            string ext_bill = System.IO.Path.GetExtension(bfp.FileName);
                            string ext_vhr = System.IO.Path.GetExtension(vfp.FileName);
                            if (ext_bill == ".pdf" && ext_vhr == ".pdf")
                            {
                                if (bfp.PostedFile.ContentLength < 3145728 && vfp.PostedFile.ContentLength < 3145728)
                                {
                                    FileInfo file_bill = new System.IO.FileInfo(bfp.PostedFile.FileName);
                                    string fname_bill = file_bill.Name.Remove((file_bill.Name.Length - file_bill.Extension.Length));
                                    fname_bill = fname_bill + "_" + txtrcpt.Text + "_b" + file_bill.Extension; // renaming file uploads
                                    string filename_bill = Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads/Bill_uploads/"), fname_bill);
                                    string filename_vir_bill = Path.Combine("~/Uploads/Bill_uploads/", fname_bill);

                                    FileInfo file_vhr = new System.IO.FileInfo(vfp.PostedFile.FileName);
                                    string fname_vhr = file_vhr.Name.Remove((file_vhr.Name.Length - file_vhr.Extension.Length));
                                    fname_vhr = fname_vhr + "_" + txtrcpt.Text + "_v" + file_vhr.Extension; // renaming file uploads
                                    string filename_vhr = Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads/Voucher_uploads/"), fname_vhr);
                                    string filename_vir_vhr = Path.Combine("~/Uploads/Voucher_uploads/", fname_vhr);

                                    bus2.uid = int.Parse(Session["user_id"].ToString());
                                    bus2.pmid = int.Parse(Session["current_idno"].ToString());
                                    bus2.sdate = DateTime.Parse(txtdate.Text);
                                    bus2.rno = txtrcpt.Text;
                                    bus2.amt = int.Parse(txtamountd.Text);
                                    bus2.bill_upload = filename_vir_bill;
                                    bus2.voucher_upload = filename_vir_vhr;
                                    int res = bus2.deposited();
                                    if (res == 1)
                                    {
                                        bfp.SaveAs(filename_bill);
                                        vfp.SaveAs(filename_vhr);                                        
                                    }
                                    else
                                    {
                                        chk = 0;                                        
                                    }
                                    if(chk==1)
                                    {
                                        clearfields();
                                        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success_deposit();", true);
                                    }
                                    else
                                    {
                                        clearfields();
                                        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_deposit();", true);
                                    }
                                }
                                else
                                {
                                    //Size Error
                                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_size();", true);
                                }
                            }
                            else
                            {
                                //Extension Error
                                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_ext();", true);
                            }
                        }
                        else
                        {
                            //No File error
                            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_nofile();", true);
                        }
                    }
                    else if(fup_new.Checked==false) //Checkbox not checked
                    {
                        if (bfp.HasFile)
                        {
                            string ext_bill = System.IO.Path.GetExtension(bfp.FileName);                            
                            if (ext_bill == ".pdf")
                            {
                                if (bfp.PostedFile.ContentLength < 3145728)
                                {
                                    FileInfo file_bill = new System.IO.FileInfo(bfp.PostedFile.FileName);
                                    string fname_bill = file_bill.Name.Remove((file_bill.Name.Length - file_bill.Extension.Length));
                                    fname_bill = fname_bill + "_" + txtrcpt.Text + "_b" + file_bill.Extension; // renaming file uploads
                                    string filename_bill = Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads/Bill_uploads/"), fname_bill);
                                    string filename_vir_bill = Path.Combine("~/Uploads/Bill_uploads/", fname_bill);

                                    bus2.uid = int.Parse(Session["user_id"].ToString());
                                    bus2.pmid = int.Parse(Session["current_idno"].ToString());
                                    bus2.sdate = DateTime.Parse(txtdate.Text);
                                    bus2.rno = txtrcpt.Text;
                                    bus2.amt = int.Parse(txtamountd.Text);
                                    bus2.bill_upload = filename_vir_bill;
                                    bus2.voucher_upload = "";
                                    int res = bus2.deposited();
                                    if (res == 1)
                                    {
                                        bfp.SaveAs(filename_bill);                                        
                                    }
                                    else
                                    {
                                        chk = 0;
                                    }
                                    if (chk == 1)
                                    {
                                        clearfields();
                                        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success_deposit();", true);
                                    }
                                    else
                                    {
                                        clearfields();
                                        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_deposit();", true);
                                    }
                                }
                                else
                                {
                                    //Size Error
                                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_size();", true);
                                }
                            }
                            else
                            {
                                //Extension Error
                                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_ext();", true);
                            }
                        }
                        else
                        {
                            //No File error
                            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_nofile();", true);
                        }
                    }
                    else
                    {
                        Response.Redirect("sessiontimeout.aspx");
                    }
                }
                else
                {
                    Response.Redirect("sessiontimeout.aspx");
                }
            }
        }

        public void clearfields()
        {
            txtdate.Text = "";
            txtrcpt.Text = "";
            txtamountd.Text = "";
            item_name1.Text = "";
            price1.Text = "";
            desc1.Text = "";
        }

        public void ddl_type()
        {
            DataTable dt = bus2.ddl_type();
            ddltype.DataSource = dt;
            ddltype.DataBind();
            ddltype.Items.Insert(0, new ListItem("-----SELECT-----", ""));
        }
    }
}