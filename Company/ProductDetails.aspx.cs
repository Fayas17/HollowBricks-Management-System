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
            
           
           
           
            fillgrid();
        }


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
   
   
  
    

    
    protected void car_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
 
    protected void car_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
        
    }
}