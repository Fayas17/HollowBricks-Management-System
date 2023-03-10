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
         
            
            filldetails();
        }
    }


    public void filldetails()
    
    {
        string sel = "select * from tbl_company";
        obj.FillGridView(sel, grdem);
    
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
       
       
        if (f == 1)
        {
            
              
            
                string strUp = "update tbl_company set  company_name='" + txtname.Text + "',company_contact='" + txtcon.Text + "',company_email='" + txtemail.Text + "',company_address='" + txtadd + "',company_username='" + txtuser.Text + "',company_password='" + txtpas.Text + "' where company_id=" + sid + "";
                obj.ExecuteCommand(strUp);
                
                filldetails();
                f = 0;
            
        }
        else
        {
           
            string strIns = "insert into tbl_company(company_name,company_contact,company_email,company_address,company_username,company_password)values('" + txtname.Text + "','" + txtcon.Text + "','" + txtemail.Text + "','" + txtadd.Text + "','" + txtuser.Text + "','" + txtpas.Text + "')";
            obj.ExecuteCommand(strIns);

            filldetails();
        }

            clear();
        
    }
   
    protected void grdem_RowCommand(object sender, GridViewCommandEventArgs e)
{
     sid = Convert.ToInt32(e.CommandArgument.ToString());
        if (e.CommandName == "del")
        {
            string strDel = "delete from tbl_company where company_id=" +sid + "";
            obj.ExecuteCommand(strDel);
            filldetails();

        }
        if (e.CommandName == "ed")
        {
            string strSel = "select * from tbl_company where company_id=" + sid + "";
            DataTable tb = new DataTable();
            tb = obj.GetDataTable(strSel);
            if (tb.Rows.Count > 0)
            {
               
                txtname.Text = tb.Rows[0]["company_name"].ToString();
               
                txtcon.Text = tb.Rows[0]["company_contact"].ToString();
                txtemail.Text = tb.Rows[0]["company_email"].ToString();
                txtadd.Text = tb.Rows[0]["company_address"].ToString();
                txtuser.Text = tb.Rows[0]["company_username"].ToString();
                txtpas.Text = tb.Rows[0]["company_password"].ToString();
               
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
          
          txtname.Text =
         
          txtcon.Text = "";
          txtemail.Text = "";
          txtadd.Text = "";
          txtuser.Text = "";
          txtpas.Text = "";
}

      
}
