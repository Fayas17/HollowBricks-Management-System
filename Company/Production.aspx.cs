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
    static int id, flag;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Fillproduct();
            FillGrid();
        }
    }
    protected void Fillproduct()
    {
        obj.FillDrop(ddlproduct, "product_name", "product_id", "tbl_product");
    }
    protected void FillGrid()
    {
        String SelQry = "select * from tbl_production p,tbl_product r  where p.product_id=r.product_id ";
        obj.FillGridView(SelQry, grid);
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (flag == 1)
        {
            String upQry = "update tbl_production set production_date='" + txtdate.Text + "',production_qty='" + txtqty.Text + "',product_id='" + ddlproduct.SelectedValue + "' where production_id=" + id + "";
            obj.ExecuteCommand(upQry);
            flag = 0;
            FillGrid();
        }

        else
        {
            String insQry = "insert into tbl_production(production_date,production_qty,product_id)values(" + txtdate.Text + "," + txtqty.Text + ",'" + ddlproduct.SelectedValue + "')";

            obj.ExecuteCommand(insQry);

        }
        String upQry1 = "update tbl_product set product_qty=product_qty+'" + txtqty.Text + "' where product_id=" + ddlproduct.SelectedValue + "";
        obj.ExecuteCommand(upQry1);
        FillGrid();
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        clear();
    }
    public void clear()
    {
        txtdate.Text = "";
        ddlproduct.ClearSelection();
        txtqty.Text = "";
   }
    protected void grid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
 if (e.CommandName == "del")
        {
            id = Convert.ToInt32(e.CommandArgument.ToString());
            String delQry = "delete from tbl_production where production_id=" + id + "";
            obj.ExecuteCommand(delQry);

            FillGrid();
        }

        if (e.CommandName == "ed")
        {
            id = Convert.ToInt32(e.CommandArgument.ToString());
            String SelQry = "select * from tbl_production where production_id=" + id + "";
            DataTable dt = new DataTable();
            dt = obj.GetDataTable(SelQry);
            txtdate.Text = dt.Rows[0]["production_date"].ToString();
            txtqty.Text = dt.Rows[0]["production_qty"].ToString();
            ddlproduct.SelectedValue = dt.Rows[0]["product_id"].ToString();
           
            flag = 1;
        }
    }
    }
