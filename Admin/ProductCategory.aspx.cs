using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;




public partial class Admin_Default : System.Web.UI.Page
{
    cls_MainProject obj = new cls_MainProject();
    public static int id, flag = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            fillgrid();
        }
    }
    public void fillgrid()
    {
        string sel = "select * from tbl_productcategory";
        obj.FillGridView(sel, cartype);
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (flag == 1)
        {
            string UP = "update tbl_productcategory set category_name='" + txtcom.Text + "'  where category_id ='" + id + "'";
            obj.ExecuteCommand(UP);
            fillgrid();
            txtcom.Text = "";


            flag = 0;
        }
        else
        {

            string ins = "insert into tbl_productcategory(category_name)values('" + txtcom.Text + "')";
            obj.ExecuteCommand(ins);
            fillgrid();
            txtcom.Text = "";
        }


    }
    protected void txtcom_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
    }
    protected void txtcom_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void txtcom_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        cartype.PageIndex = e.NewPageIndex;
        fillgrid();

    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        txtcom.Text = "";
        flag = 0;
    }
   
    protected void cartype_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        id = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName == "del")
        {
            string delete = "delete from tbl_productcategory where category_id ='" + id + "'";
            obj.ExecuteCommand(delete);
            fillgrid();

        }
        if (e.CommandName == "ed")
        {
            string sel = "select * from tbl_productcategory where category_id='" + id + "'";
            
            DataTable dt = new DataTable();
            dt = obj.GetDataTable(sel);
            txtcom.Text = dt.Rows[0]["category_name"].ToString();
            flag = 1;
        }
    }
    protected void cartype_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}