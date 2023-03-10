using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

public partial class Company_Default : System.Web.UI.Page
{
    cls_MainProject obj = new cls_MainProject();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string s = "select * from Tbl_salesheader where sh_billdate>='" + txtfrom.Text + "' and sh_billdate<='" + txtto.Text + "' and company_id='" + Session["lgid"] + "'";
        DataTable dt = obj.GetDataTable(s);
        if (dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        else
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "vm")
        {
            Session["id"] = e.CommandArgument.ToString();
            Response.Redirect("SoldItemList.aspx");
        }
    }
}