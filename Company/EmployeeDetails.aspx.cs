using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Agency_Employee : System.Web.UI.Page
{
    public static int sid, f;
    static string image;
    cls_MainProject obj = new cls_MainProject();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
           
            
            filldesignation();
        }
    }
    

    public void filldesignation()
    
    {
        string sel = "select * from tbl_employee e,tbl_company d where e.company_id=d.company_id";
        obj.FillGridView(sel, grdem);
    
    }

    
    protected void grdem_RowCommand(object sender, GridViewCommandEventArgs e)
{
     
    }


     

      
}
