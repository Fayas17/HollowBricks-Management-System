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
            obj.FillDrop(ddlcompany, "company_name", "company_id", "tbl_company");
        }
    }
    protected void ddlcompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        string s = "select * from tbl_stock s inner join tbl_product p on s.product_id=p.product_id where s.company_id='" + ddlcompany.SelectedValue + "'";
        obj.fillGrid(GridView1, s);
    }
}