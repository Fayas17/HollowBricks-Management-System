using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class ShowRoom_Default : System.Web.UI.Page
{
    cls_MainProject obj = new cls_MainProject();
     static int id, flag = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            
           
            fillcartype();
           
            fillgrid();
        }


    }
    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string pic = Path.GetFileName(filup.PostedFile.FileName.ToString());
        filup.SaveAs(Server.MapPath("ProductImage/" + pic));

        string ins = "insert into tbl_product(product_name,product_image,product_price,category_id)values('" + txtname.Text + "','" + pic + "','" + txtprice.Text + "','" + ddlcartype.SelectedValue + "')";
        obj.ExecuteCommand(ins);
        fillgrid();
        txtname.Text = "";
        txtprice.Text = "";
        ddlcartype.ClearSelection();
        flag = 0;
    }
    public void fillgrid()
    {
        string sel = "select * from tbl_product c inner join tbl_productcategory t on c.category_id=t.category_id";
       
        DataTable dt = new DataTable();
        dt = obj.GetDataTable(sel);
        car.DataSource = dt;
        car.DataBind();
    }

   
    protected void car_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        car.PageIndex = e.NewPageIndex;
        fillgrid();

    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        txtname.Text = "";
        txtprice.Text = "";
        ddlcartype.ClearSelection();
        flag = 0;
    }
   
  
    public void fillcartype()
    {
        obj.FillDrop(ddlcartype, "category_name", "category_id", "tbl_productcategory");
        
    }

    
    protected void car_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
 
    protected void car_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        id = Convert.ToInt32(e.CommandArgument.ToString());
        if (e.CommandName == "del")
        {
            string delete = "delete from tbl_product where product_id ='" + id + "'";
            obj.ExecuteCommand(delete);
            fillgrid();

        }
        //if (e.CommandName == "ed")
        //{
        //    string sel = "select * from tbl_cardetails where car_id='" + id + "'";
        //    SqlDataAdapter adp = new SqlDataAdapter(sel, con);
        //    DataTable dt = new DataTable();
        //    adp.Fill(dt);
        //    txtname.Text = dt.Rows[0]["car_name"].ToString();
        //    txtfeatures.Text = dt.Rows[0]["car_features"].ToString();
        //    txtprice.Text = dt.Rows[0]["car_price"].ToString();
        //    ddlModel.SelectedValue = dt.Rows[0]["model_id"].ToString();
        //    ddlcompany.SelectedValue = dt.Rows[0]["company_id"].ToString();
        //    ddlColor.SelectedValue = dt.Rows[0]["color_id"].ToString();
        //    ddlcartype.SelectedValue = dt.Rows[0]["cartype_id"].ToString();

        //    flag = 1;
        //}
    }
}