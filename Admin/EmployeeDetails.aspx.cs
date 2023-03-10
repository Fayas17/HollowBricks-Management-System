using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Agency_Employee : System.Web.UI.Page
{
    public static int sid, f;
    static string image;
    cls_MainProject obj = new cls_MainProject();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            obj.FillDrop(ddldes, "company_name", "company_id", "tbl_company");
            
            filldesignation();
        }
    }
    

    public void filldesignation()
    
    {
        string sel = "select * from tbl_employee e,tbl_company d where e.company_id=d.company_id";
        obj.FillGridView(sel, grdem);
    
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        string img = Path.GetFileName(FileUpload1.FileName.ToString());
       
        if (f == 1)
        {
            
              
            if (img != "")
            {
                 FileUpload1.SaveAs(Server.MapPath("file/" + img));
                string strUp = "update tbl_employee set company_id=" + ddldes.SelectedValue + ", emp_name='" + txtname.Text + "',emp_doj='" + txtjoin.Text + "',emp_contact='" + txtcon.Text + "',emp_email='" + txtemail.Text + "',emp_address='" + txtadd + "',emp_photo='" + img + "' where emp_id=" + sid + "";
                obj.ExecuteCommand(strUp);
                // Response.Write("<script>alert('Updated....!!!!')</script>");
                filldesignation();
                f = 0;
            }
            else
            {
                string strUp = "update tbl_employee set company_id=" + ddldes.SelectedValue + ", emp_name='" + txtname.Text + "',emp_doj='" + txtjoin.Text + "',emp_contact='" + txtcon.Text + "',emp_email='" + txtemail.Text + "',emp_address='" + txtadd + "' where emp_id=" + sid + "";
                obj.ExecuteCommand(strUp);
                // Response.Write("<script>alert('Updated....!!!!')</script>");
                filldesignation();
                f = 0;
            }
        }
        else
        {
             FileUpload1.SaveAs(Server.MapPath("file/" + img));
            string strIns = "insert into tbl_employee(company_id,emp_name,emp_doj,emp_contact,emp_email,emp_address,emp_photo)values(" + ddldes.SelectedValue + ",'" + txtname.Text + "','" + txtjoin.Text + "','" + txtcon.Text + "','" + txtemail.Text + "','" + txtadd.Text + "','" + img + "')";
            obj.ExecuteCommand(strIns);
            // Response.Write("<script>alert('Inserted....!!!!')</script>");
            filldesignation();
        }

            clear();
        
    }
   
    protected void grdem_RowCommand(object sender, GridViewCommandEventArgs e)
{
     sid = Convert.ToInt32(e.CommandArgument.ToString());
        if (e.CommandName == "del")
        {
            string strDel = "delete from tbl_employee where emp_id=" +sid + "";
            obj.ExecuteCommand(strDel);
            filldesignation();

        }
        if (e.CommandName == "ed")
        {
            string strSel = "select * from tbl_employee where emp_id=" + sid + "";
            DataTable tb = new DataTable();
            tb = obj.GetDataTable(strSel);
            if (tb.Rows.Count > 0)
            {
                ddldes.SelectedValue = tb.Rows[0]["company_id"].ToString();
                txtname.Text = tb.Rows[0]["emp_name"].ToString();
                txtjoin.Text = tb.Rows[0]["emp_doj"].ToString();
                txtcon.Text = tb.Rows[0]["emp_contact"].ToString();
                txtemail.Text = tb.Rows[0]["emp_email"].ToString();
                txtadd.Text = tb.Rows[0]["emp_address"].ToString();
              
                image=tb.Rows[0]["emp_photo"].ToString();
                f = 1;
            }
        }
    }

protected void btn_Click(object sender, EventArgs e)
{
    clear();

}
      public void clear()
      {
          ddldes.ClearSelection();
          txtname.Text =
          txtjoin.Text = "";
          txtcon.Text = "";
          txtemail.Text = "";
          txtadd.Text = "";
         
}

      
}
