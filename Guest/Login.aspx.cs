using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Guest_Default : System.Web.UI.Page
{
    cls_MainProject obj = new cls_MainProject();
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string selAgency = "select * from tbl_company where company_username='" + txtUsername.Text + "' and company_password='" + txtPass.Text + "'";
        DataTable dt = new DataTable();
        dt = obj.GetDataTable(selAgency);

        string selAdmin = "select * from tbl_admin where admin_username='" + txtUsername.Text + "' and admin_password='" + txtPass.Text + "'";
        DataTable dtAdmin = new DataTable();
        dtAdmin = obj.GetDataTable(selAdmin);

        if (dt.Rows.Count > 0)
        {
            Session["lgid"] = dt.Rows[0]["company_id"].ToString();
            Response.Redirect("../Company/Homepage.aspx");
        }
        
        else if (dtAdmin.Rows.Count > 0)
        {

            Response.Redirect("../Admin/Homepage.aspx");
        }
        else
        {
            lblMessage.Text = "Invalid Login!!!";
        }
    }
}