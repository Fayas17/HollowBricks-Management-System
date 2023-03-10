using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Company_Default : System.Web.UI.Page
{
    cls_MainProject obj = new cls_MainProject();
   
        static int flag = 0, grandtotal = 0, itemprice, maxshid;
        //static DataTable dt8;
        static DataTable dtTemp;
        DataRow dr;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                dtTemp = new DataTable();
                obj.FillDrop(ddlcategory, "category_name", "category_id", "tbl_productcategory");
            }
        }

        protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            obj.FillDrop(ddlitem, "product_name", "product_id", "tbl_product", "category_id=" + ddlcategory.SelectedValue + "");
        }

        protected void ddlitem_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sel = "select * from tbl_product where product_id=" + ddlitem.SelectedValue + "";
            DataTable dt = obj.GetDataTable(sel);
            if (dt.Rows.Count > 0)
            {
                txtrate.Text = dt.Rows[0]["product_price"].ToString();
            }
            string sel1 = "select * from tbl_stock where product_id='" + ddlitem.SelectedValue + "' and company_id='" + Session["lgid"] + "'";
            DataTable dt1 = obj.GetDataTable(sel1);
            if (dt1.Rows.Count > 0)
            {
                lblstock.Text = "Stock Available :: " + dt1.Rows[0]["stock_qty"].ToString();
                Session["avStock"] = dt1.Rows[0]["stock_qty"].ToString();
            }
            else
            {
                lblstock.Text = "Stock Available :: 0";
                Session["avStock"] = "0";
            }
        
        }

        protected void btnaddtocart_Click(object sender, EventArgs e)
        {
            if (flag == 0)
            {

                DataColumn dc = new DataColumn("category_name", typeof(string));
                dtTemp.Columns.Add(dc);
                dc = new DataColumn("product_name", typeof(string));
                dtTemp.Columns.Add(dc);
                dc = new DataColumn("Sd_itemqty", typeof(int));
                dtTemp.Columns.Add(dc);
                dc = new DataColumn("Sh_grandtotal", typeof(int));
                dtTemp.Columns.Add(dc);
                dc = new DataColumn("product_id", typeof(int));
                dtTemp.Columns.Add(dc);
                dtTemp.AcceptChanges();
                flag = 1;
            }
            itemprice = Convert.ToInt32(txtquantity.Text) * Convert.ToInt32(txtrate.Text);
            string sel5 = "select * from tbl_productcategory c,tbl_product i where i.product_id='" + ddlitem.SelectedValue + "' and c.category_id='" + ddlcategory.SelectedValue + "'";
            DataTable dt5 = obj.GetDataTable(sel5);
            if (dt5.Rows.Count > 0)
            {
                dr = dtTemp.NewRow();
                dr["category_name"] = dt5.Rows[0]["category_name"];
                dr["product_name"] = dt5.Rows[0]["product_name"];
                dr["product_id"] = dt5.Rows[0]["product_id"];
                dr["Sd_itemqty"] = txtquantity.Text;
                dr["Sh_grandtotal"] = itemprice;
                dtTemp.Rows.Add(dr);
                dtTemp.AcceptChanges();
            }
            grdsales.DataSource = dtTemp;
            grdsales.DataBind();
            //ddlcategory.ClearSelection();
            //ddlitem.ClearSelection();
            //txtquantity.Text = "";
            //txtrate.Text = "";

            
        }

        protected void txtrationcard_TextChanged(object sender, EventArgs e)
        {
           
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            ddlcategory.ClearSelection();
            ddlitem.ClearSelection();
            txtquantity.Text = "";
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            GridViewRow gr = ((Button)sender).NamingContainer as GridViewRow;
            dtTemp.Rows.RemoveAt(gr.RowIndex);
            grdsales.DataSource = dtTemp;
            grdsales.DataBind();
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            string strSel1 = "select MAX(sh_billno)Bill_no from Tbl_salesheader";
            DataTable dtbill = obj.GetDataTable(strSel1);
            if (dtbill.Rows.Count > 0)
            {
                if (dtbill.Rows[0]["Bill_no"].ToString() == "")
                {
                    int i = 1;
                    string strInsHead = "insert into Tbl_salesheader(sh_custname,sh_custcontact,sh_custaddress,sh_billno,sh_billdate,sh_grandtotal,company_id)values('" + txtname.Text + "','" + txtcontact.Text + "','" + txtaddress.Text + "'," + i + ",'" + DateTime.Now.ToShortDateString() + "'," + 0 + ",'" + Session["lgid"] + "')";
                    obj.ExecuteCommand(strInsHead);
                }
                else
                {
                    int i = Convert.ToInt32(dtbill.Rows[0]["Bill_no"]) + 1;
                    string strInsHead = "insert into Tbl_salesheader(sh_custname,sh_custcontact,sh_custaddress,sh_billno,sh_billdate,sh_grandtotal,company_id)values('" + txtname.Text + "','" + txtcontact.Text + "','" + txtaddress.Text + "'," + i + ",'" + DateTime.Now.ToShortDateString() + "'," + 0 + ",'" + Session["lgid"] + "')";
                    obj.ExecuteCommand(strInsHead);
                }

            }
            string strSelHead = "select MAX(sh_id) as Sh_id from Tbl_salesheader";
            DataTable dt3 = obj.GetDataTable(strSelHead);
            if (dt3.Rows.Count > 0)
            {
                maxshid = Convert.ToInt32(dt3.Rows[0]["Sh_id"]);
            }
            foreach (GridViewRow grdv in grdsales.Rows)
            {
                Label lblQuantity = (Label)grdv.FindControl("lblquantity");
                Label lblPrice = (Label)grdv.FindControl("lblprice");
                HiddenField hf = (HiddenField)grdv.FindControl("hiddenqty");
                string strQuantity = lblQuantity.Text;
                string strPrice = lblPrice.Text;
                string strins = "insert into Tbl_salesdetails(sh_id,product_id,sd_itemqty,sd_itemrate)values(" + maxshid + "," + hf.Value + ",'" + strQuantity + "','" + strPrice + "')";
                obj.ExecuteCommand(strins);
                grandtotal = grandtotal + Convert.ToInt32(lblPrice.Text);

                string selQry = "select * from tbl_stock where product_id='" + hf.Value + "' and company_id='" + Session["lgid"] + "'";
                DataTable dtstock = obj.GetDataTable(selQry);
                if (dtstock.Rows.Count > 0)
                {
                    int qty = Convert.ToInt32(dtstock.Rows[0]["stock_qty"].ToString());
                    int newqty = qty - Convert.ToInt32(strQuantity);

                    string up = "update tbl_stock set stock_qty='" + newqty + "' where product_id='" + hf.Value + "' and company_id='" + Session["lgid"] + "'";
                    obj.ExecuteCommand(up);
                }
            }
            string up1 = "update Tbl_salesheader set sh_grandtotal=" + grandtotal + "";
            obj.ExecuteCommand(up1);
            flag = 0;
            Response.Redirect("SalesReport.aspx");       
        }
        protected void txtquantity_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["avStock"].ToString()) < Convert.ToInt32(txtquantity.Text))
            {
                lblcheck.Text = "Please Check Stock!!!";
                txtquantity.Text = "";
            }
            else
            {
                lblcheck.Text = "Stock Avialbale!!!";
            }
        }
}
