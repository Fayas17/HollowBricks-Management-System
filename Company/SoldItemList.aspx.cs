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
            string s = "select * from Tbl_salesdetails sd inner join tbl_product p on sd.product_id=p.product_id where sd.sh_id='" + Session["id"] + "'";
            obj.FillGridView(s, GridView1);
        }
    }
}