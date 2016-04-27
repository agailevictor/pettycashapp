using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PettyCash_C;
using System.Data;
using System.IO;

namespace PettyCashApp.user
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        petty_cash_Con bus = new petty_cash_Con();
        string ty;
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
                    ty = Session["ty"].ToString();
                    if (ty == "Deposit")
                    {
                        iname.Attributes["class"] = "hidden";
                        price.Attributes["class"] = "hidden";
                        desc.Attributes["class"] = "hidden";

                    }
                    else if (ty == "Withdraw")
                    {
                        amnt.Attributes["class"] = "hidden";
                    }
                    edit_journal();
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

        public void edit_journal()
        {

            bus.id = int.Parse(Session["id"].ToString());
            string type = Session["ty"].ToString();
            DataTable dt = bus.edit_journal();
            if (dt.Rows.Count > 0)
            {
                txtdate.Text = dt.Rows[0][0].ToString();
                txtrcpt.Text = dt.Rows[0][1].ToString();
                type_lbl.Text = dt.Rows[0][2].ToString();
                if (type_lbl.Text == "Deposit")
                {
                    txtamount.Text = dt.Rows[0][4].ToString();
                }
                else if (type_lbl.Text == "Withdraw")
                {
                    item_name1.Text = dt.Rows[0][3].ToString();
                    price1.Text = dt.Rows[0][4].ToString();
                    desc1.Text = dt.Rows[0][5].ToString();
                }
            }
        }

        protected void btnadd_editentry_Click(object sender, EventArgs e)
        {
            int res;
            ty = Session["ty"].ToString();

            if (ty == "Deposit")
            {
                if (txtdate.Text != "" && txtrcpt.Text != "" && txtamount.Text != "")
                {
                    if (bill_new.Checked && vhr_new.Checked)
                    {
                        if (bill_upload.HasFile && vhr_upload.HasFile)
                        {
                            string ext_bill = System.IO.Path.GetExtension(bill_upload.FileName);
                            string ext_vhr = System.IO.Path.GetExtension(vhr_upload.FileName);
                            if (ext_bill == ".pdf" && ext_vhr == ".pdf")
                            {
                                if (bill_upload.PostedFile.ContentLength < 3145728 && vhr_upload.PostedFile.ContentLength < 3145728)
                                {
                                    FileInfo file_bill = new System.IO.FileInfo(bill_upload.PostedFile.FileName);
                                    string fname_bill = file_bill.Name.Remove((file_bill.Name.Length - file_bill.Extension.Length));
                                    fname_bill = fname_bill + "_" + txtrcpt.Text + "_b" + file_bill.Extension; // renaming file uploads
                                    string filename_bill = Path.Combine(HttpContext.Current.Server.MapPath("~/uploads/"), fname_bill);
                                    string filename_vir_bill = Path.Combine("~/uploads/", fname_bill);

                                    FileInfo file_vhr = new System.IO.FileInfo(vhr_upload.PostedFile.FileName);
                                    string fname_vhr = file_vhr.Name.Remove((file_vhr.Name.Length - file_vhr.Extension.Length));
                                    fname_vhr = fname_vhr + "_" + txtrcpt.Text + "_v" + file_vhr.Extension; // renaming file uploads
                                    string filename_vhr = Path.Combine(HttpContext.Current.Server.MapPath("~/uploads/"), fname_vhr);
                                    string filename_vir_vhr = Path.Combine("~/uploads/", fname_vhr);
                                        
                                    bus.id = int.Parse(Session["id"].ToString());
                                    bus.type = ty;
                                    bus.sdate = DateTime.Parse(txtdate.Text);
                                    bus.rno = txtrcpt.Text;
                                    bus.item = "";
                                    bus.amt = double.Parse(txtamount.Text);
                                    bus.bill_upload = filename_vir_bill;
                                    bus.voucher_upload = filename_vir_vhr;
                                    bus.description = "";
                                    res = bus.update_addentry();
                                    if (res == 1) // Success
                                    {
                                        bill_upload.SaveAs(filename_bill);
                                        vhr_upload.SaveAs(filename_vhr);
                                    }
                                    else // Fail
                                    {
                                        chk = 0;
                                    }
                                    if (chk == 1)
                                    {
                                        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success_update();", true);
                                    }
                                    else
                                    {                                        
                                        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_update();", true);
                                        clearfields();
                                    }                                                                                                          
                                }
                                else
                                {
                                    //Error... Size should be less than 3mb
                                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_size();", true);                                
                                }
                            }
                            else
                            {
                                //Error... Extension should be PDF
                                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_ext();", true);                                
                            }
                        }
                        else
                        {
                            //Upload Files Error
                            vhr_new.Checked = false;
                            bill_new.Checked = false; 
                            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_nofile();", true);                           
                        }
                    }
                    else if (bill_new.Checked)
                    {
                        if (bill_upload.HasFile)
                        {
                            string ext_bill = System.IO.Path.GetExtension(bill_upload.FileName);                                
                            if (ext_bill == ".pdf")
                            {
                                if (bill_upload.PostedFile.ContentLength < 3145728)
                                {
                                    FileInfo file_bill = new System.IO.FileInfo(bill_upload.PostedFile.FileName);
                                    string fname_bill = file_bill.Name.Remove((file_bill.Name.Length - file_bill.Extension.Length));
                                    fname_bill = fname_bill + "_" + txtrcpt.Text + "_b" + file_bill.Extension; // renaming file uploads
                                    string filename_bill = Path.Combine(HttpContext.Current.Server.MapPath("~/uploads/"), fname_bill);
                                    string filename_vir_bill = Path.Combine("~/uploads/", fname_bill);

                                    bus.id = int.Parse(Session["id"].ToString());
                                    bus.type = ty;
                                    bus.sdate = DateTime.Parse(txtdate.Text);
                                    bus.rno = txtrcpt.Text;
                                    bus.item = "";
                                    bus.amt = double.Parse(txtamount.Text);
                                    bus.bill_upload = filename_vir_bill;
                                    bus.voucher_upload = "";
                                    bus.description = "";
                                    res = bus.update_addentry();
                                    if (res == 1) // Success
                                    {
                                        bill_upload.SaveAs(filename_bill);                                        
                                    }
                                    else // Fail
                                    {
                                        chk = 0;
                                    }
                                    if (chk == 1)
                                    {
                                        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success_update();", true);                                        
                                    }
                                    else
                                    {
                                        clearfields();
                                        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_update();", true);                                        
                                    }
                                }
                                else
                                {
                                    //Error... Size should be less than 3mb
                                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_size();", true);
                                }
                            }
                            else
                            {
                                //Error... Extension should be PDF
                                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_ext();", true);
                            }                                
                        }
                        else
                        {
                            //No file present
                            vhr_new.Checked = false;
                            bill_new.Checked = false; 
                            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_nofile();", true);
                        }
                    }
                    else if (vhr_new.Checked)
                    {
                        if (vhr_upload.HasFile)
                        {
                            string ext_vhr = System.IO.Path.GetExtension(vhr_upload.FileName);
                            if (ext_vhr == ".pdf")
                            {
                                if (vhr_upload.PostedFile.ContentLength < 3145728)
                                {
                                    FileInfo file_vhr = new System.IO.FileInfo(vhr_upload.PostedFile.FileName);
                                    string fname_vhr = file_vhr.Name.Remove((file_vhr.Name.Length - file_vhr.Extension.Length));
                                    fname_vhr = fname_vhr + "_" + txtrcpt.Text + "_v" + file_vhr.Extension; // renaming file uploads
                                    string filename_vhr = Path.Combine(HttpContext.Current.Server.MapPath("~/uploads/"), fname_vhr);
                                    string filename_vir_vhr = Path.Combine("~/uploads/", fname_vhr);

                                    bus.id = int.Parse(Session["id"].ToString());
                                    bus.type = ty;
                                    bus.sdate = DateTime.Parse(txtdate.Text);
                                    bus.rno = txtrcpt.Text;
                                    bus.item = "";
                                    bus.amt = double.Parse(txtamount.Text);
                                    bus.bill_upload = "";// check here later
                                    bus.voucher_upload = filename_vir_vhr;
                                    bus.description = "";
                                    res = bus.update_addentry();
                                    if (res == 1) // Success
                                    {
                                        vhr_upload.SaveAs(filename_vhr);
                                    }
                                    else // Fail
                                    {
                                        chk = 0;
                                    }
                                    if (chk == 1)
                                    {
                                        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success_update();", true);                                        
                                    }
                                    else
                                    {
                                        clearfields();
                                        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_update();", true);
                                    }
                                }
                                else
                                {
                                    //Error... Size should be less than 3mb
                                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_size();", true);
                                }
                            }
                            else
                            {
                                //Error... Extension should be PDF
                                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_ext();", true);
                            }
                        }
                        else
                        {
                            //No file present
                            vhr_new.Checked = false;
                            bill_new.Checked = false; 
                            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_nofile();", true);
                        }
                    }
                    else
                    {
                        //No bill and Voucher.. 
                        bus.id = int.Parse(Session["id"].ToString());
                        bus.type = ty;
                        bus.sdate = DateTime.Parse(txtdate.Text);
                        bus.rno = txtrcpt.Text;
                        bus.item = "";
                        bus.amt = double.Parse(txtamount.Text);
                        bus.bill_upload = "";
                        bus.voucher_upload = "";
                        bus.description = "";
                        res = bus.update_addentry();
                        if (res == 1) // Success
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success_update();", true);                            
                        }
                        else // Fail
                        {
                            clearfields();
                            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_update();", true);
                        }                        
                    }
                }
                else
                {
                    Response.Redirect("~/unauthorised.aspx");
                }             
            }
            else if (ty == "Withdraw")
            {
                if (txtdate.Text != "" && txtrcpt.Text != "" && item_name1.Text != "" && price1.Text != "")
                {
                    if (bill_new.Checked && vhr_new.Checked)
                    {
                        if (bill_upload.HasFile && vhr_upload.HasFile)
                        {
                            string ext_bill = System.IO.Path.GetExtension(bill_upload.FileName);
                            string ext_vhr = System.IO.Path.GetExtension(vhr_upload.FileName);
                            if (ext_bill == ".pdf" && ext_vhr == ".pdf")
                            {
                                if (bill_upload.PostedFile.ContentLength < 3145728 && vhr_upload.PostedFile.ContentLength < 3145728)
                                {
                                    FileInfo file_bill = new System.IO.FileInfo(bill_upload.PostedFile.FileName);
                                    string fname_bill = file_bill.Name.Remove((file_bill.Name.Length - file_bill.Extension.Length));
                                    fname_bill = fname_bill + "_" + txtrcpt.Text + "_b" + file_bill.Extension; // renaming file uploads
                                    string filename_bill = Path.Combine(HttpContext.Current.Server.MapPath("~/uploads/"), fname_bill);
                                    string filename_vir_bill = Path.Combine("~/uploads/", fname_bill);

                                    FileInfo file_vhr = new System.IO.FileInfo(vhr_upload.PostedFile.FileName);
                                    string fname_vhr = file_vhr.Name.Remove((file_vhr.Name.Length - file_vhr.Extension.Length));
                                    fname_vhr = fname_vhr + "_" + txtrcpt.Text + "_v" + file_vhr.Extension; // renaming file uploads
                                    string filename_vhr = Path.Combine(HttpContext.Current.Server.MapPath("~/uploads/"), fname_vhr);
                                    string filename_vir_vhr = Path.Combine("~/uploads/", fname_vhr);

                                    bus.id = int.Parse(Session["id"].ToString());
                                    bus.type = ty;
                                    bus.sdate = DateTime.Parse(txtdate.Text);
                                    bus.rno = txtrcpt.Text;
                                    bus.item = item_name1.Text;
                                    bus.amt = double.Parse(price1.Text);
                                    bus.bill_upload = filename_vir_bill;
                                    bus.voucher_upload = filename_vir_vhr;
                                    bus.description = desc1.Text;
                                    res = bus.update_addentry();
                                    if (res == 1) // Success
                                    {
                                        bill_upload.SaveAs(filename_bill);
                                        vhr_upload.SaveAs(filename_vhr);
                                    }
                                    else // Fail
                                    {
                                        chk = 0;
                                    }
                                    if (chk == 1)
                                    {
                                        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success_update();", true);                                        
                                    }
                                    else
                                    {
                                        clearfields();
                                        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_update();", true);
                                    }
                                }
                                else
                                {
                                    //Error... Size should be less than 3mb
                                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_size();", true);
                                }
                            }
                            else
                            {
                                //Error... Extension should be PDF
                                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_ext();", true);
                            }
                        }
                        else
                        {
                            //Upload Files Error
                            vhr_new.Checked = false;
                            bill_new.Checked = false;                            
                            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_nofile();", true);
                        }
                    }
                    else if (bill_new.Checked)
                    {
                        if (bill_upload.HasFile)
                        {
                            string ext_bill = System.IO.Path.GetExtension(bill_upload.FileName);
                            if (ext_bill == ".pdf")
                            {
                                if (bill_upload.PostedFile.ContentLength < 3145728)
                                {
                                    FileInfo file_bill = new System.IO.FileInfo(bill_upload.PostedFile.FileName);
                                    string fname_bill = file_bill.Name.Remove((file_bill.Name.Length - file_bill.Extension.Length));
                                    fname_bill = fname_bill + "_" + txtrcpt.Text + "_b" + file_bill.Extension; // renaming file uploads
                                    string filename_bill = Path.Combine(HttpContext.Current.Server.MapPath("~/uploads/"), fname_bill);
                                    string filename_vir_bill = Path.Combine("~/uploads/", fname_bill);

                                    bus.id = int.Parse(Session["id"].ToString());
                                    bus.type = ty;
                                    bus.sdate = DateTime.Parse(txtdate.Text);
                                    bus.rno = txtrcpt.Text;
                                    bus.item = item_name1.Text;
                                    bus.amt = double.Parse(price1.Text);
                                    bus.bill_upload = filename_vir_bill;
                                    bus.voucher_upload = "";
                                    bus.description = desc1.Text;
                                    res = bus.update_addentry();
                                    if (res == 1) // Success
                                    {
                                        bill_upload.SaveAs(filename_bill);
                                    }
                                    else // Fail
                                    {
                                        chk = 0;
                                    }
                                    if (chk == 1)
                                    {
                                        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success_update();", true);
                                    }
                                    else
                                    {
                                        clearfields();
                                        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_update();", true);
                                    }
                                }
                                else
                                {
                                    //Error... Size should be less than 3mb
                                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_size();", true);
                                }
                            }
                            else
                            {
                                //Error... Extension should be PDF
                                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_ext();", true);
                            }
                        }
                        else
                        {
                            //No file present
                            vhr_new.Checked = false;
                            bill_new.Checked = false; 
                            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_nofile();", true);
                        }
                    }
                    else if (vhr_new.Checked)
                    {
                        if (vhr_upload.HasFile)
                        {
                            string ext_vhr = System.IO.Path.GetExtension(vhr_upload.FileName);
                            if (ext_vhr == ".pdf")
                            {
                                if (vhr_upload.PostedFile.ContentLength < 3145728)
                                {
                                    FileInfo file_vhr = new System.IO.FileInfo(vhr_upload.PostedFile.FileName);
                                    string fname_vhr = file_vhr.Name.Remove((file_vhr.Name.Length - file_vhr.Extension.Length));
                                    fname_vhr = fname_vhr + "_" + txtrcpt.Text + "_v" + file_vhr.Extension; // renaming file uploads
                                    string filename_vhr = Path.Combine(HttpContext.Current.Server.MapPath("~/uploads/"), fname_vhr);
                                    string filename_vir_vhr = Path.Combine("~/uploads/", fname_vhr);

                                    bus.id = int.Parse(Session["id"].ToString());
                                    bus.type = ty;
                                    bus.sdate = DateTime.Parse(txtdate.Text);
                                    bus.rno = txtrcpt.Text;
                                    bus.item = item_name1.Text;
                                    bus.amt = double.Parse(price1.Text);
                                    bus.bill_upload = "";
                                    bus.voucher_upload = filename_vir_vhr;
                                    bus.description = desc1.Text;
                                    res = bus.update_addentry();
                                    if (res == 1) // Success
                                    {
                                        vhr_upload.SaveAs(filename_vhr);
                                    }
                                    else // Fail
                                    {
                                        chk = 0;
                                    }
                                    if (chk == 1)
                                    {
                                        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success_update();", true);
                                    }
                                    else
                                    {
                                        clearfields();
                                        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_update();", true);
                                    }
                                }
                                else
                                {
                                    //Error... Size should be less than 3mb
                                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_size();", true);
                                }
                            }
                            else
                            {
                                //Error... Extension should be PDF
                                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_ext();", true);
                            }
                        }
                        else
                        {
                            //No file present                            
                            vhr_new.Checked = false;
                            bill_new.Checked = false; 
                            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_nofile();", true);
                        }
                    }
                    else
                    {
                        //No bill and Voucher.. 
                        bus.id = int.Parse(Session["id"].ToString());
                        bus.type = ty;
                        bus.sdate = DateTime.Parse(txtdate.Text);
                        bus.rno = txtrcpt.Text;
                        bus.item = item_name1.Text;
                        bus.amt = double.Parse(price1.Text);
                        bus.bill_upload = "";
                        bus.voucher_upload = "";
                        bus.description = desc1.Text;
                        res = bus.update_addentry();
                        if(res == 1)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success_update();", true);
                            bill_new.Checked = false;
                            vhr_new.Checked = false;
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_update();", true);
                        }
                    }
                }
            }                        
        }
        public void clearfields()
        {
            txtdate.Text = "";
            txtrcpt.Text = "";
            txtamount.Text = "";
            item_name1.Text = "";
            price1.Text = "";
            desc1.Text = "";
            bill_new.Checked = false;
            vhr_new.Checked = false;
        }

    }
}