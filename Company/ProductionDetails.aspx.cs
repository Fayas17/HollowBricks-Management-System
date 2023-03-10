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
        if (!IsPostBack)
        {
            obj.FillDrop(ddlProduct, "product_name", "product_id", "tbl_product");
            fillgrid();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string insQry = "insert into tbl_production(product_id,production_qty,production_date,company_id)values('" + ddlProduct.SelectedValue + "','" + txtqty.Text + "','" + txtdate.Text + "','" + Session["lgid"] + "')";
        obj.ExecuteCommand(insQry);
       // txtqty.Text = "";
        string s = "select * from tbl_stock where product_id='" + ddlProduct.SelectedValue + "' and company_id='" + Session["lgid"] + "'";
        DataTable dt = obj.GetDataTable(s);
        if (dt.Rows.Count > 0)
        {
            int qty=Convert.ToInt32(dt.Rows[0]["stock_qty"].ToString());
            int newqty=qty+Convert.ToInt32(txtqty.Text);
            string up = "update tbl_stock set stock_qty='" + newqty + "' where product_id='" + ddlProduct.SelectedValue + "' and company_id='" + Session["lgid"] + "'";
            obj.ExecuteCommand(up);
        }
        else
        {
            string insQry1 = "insert into tbl_stock(product_id,stock_qty,company_id)values('" + ddlProduct.SelectedValue + "','" + txtqty.Text + "','" + Session["lgid"] + "')";
            obj.ExecuteCommand(insQry1);
        }
        fillgrid();

    }
    protected void fillgrid()
    {
        string s = "select * from tbl_production p inner join tbl_product po on p.product_id=po.product_id where p.company_id='" + Session["lgid"] + "'";
        obj.fillGrid(GridView1, s);
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandArgument.ToString());
        if (e.CommandName == "del")
        {
            string s = "select * from tbl_production where production_id='" + id + "'";
            DataTable dt = obj.GetDataTable(s);
            if (dt.Rows.Count > 0)
            {
                Session["cid"] = dt.Rows[0]["company_id"].ToString();
                Session["pid"] = dt.Rows[0]["product_id"].ToString();
                Session["qty"] = dt.Rows[0]["production_qty"].ToString();

                string s1 = "select * from tbl_stock where product_id='" + Session["pid"] + "' and company_id='" + Session["cid"] + "'";
                DataTable dt1 = obj.GetDataTable(s1);
                if (dt1.Rows.Count > 0)
                {
                    int stockqty = Convert.ToInt32(dt1.Rows[0]["stock_qty"].ToString());
                    int upqty = stockqty - Convert.ToInt32(Session["qty"].ToString());

                    string up = "update tbl_stock set stock_qty='" + upqty + "' where product_id='" + Session["pid"] + "' and company_id='" + Session["cid"] + "'";
                    obj.ExecuteCommand(up);

                }

                string delqry = "delete from tbl_production where production_id='" + id + "'";
                obj.ExecuteCommand(delqry);
            }
            fillgrid();
        }
    }
}