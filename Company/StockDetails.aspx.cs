using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Company_Default : System.Web.UI.Page
{
    cls_MainProject obj = new cls_MainProject();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string s = "select * from tbl_stock s inner join tbl_product p on s.product_id=p.product_id where s.company_id='" + Session["lgid"] + "'";
            obj.fillGrid(GridView1, s);
        }
    }
}