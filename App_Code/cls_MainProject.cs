using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for cls_MainProject
/// </summary>
public class cls_MainProject
{
    SqlConnection con = new SqlConnection("Data Source=LAPTOP-GJD8631H;Initial Catalog=db_hollowbricks;Integrated Security=True");
    public cls_MainProject()
    {
        con.Open();
    }

    public void executeQuery(string str)
    {
        SqlCommand cmd = new SqlCommand(str, con);
        cmd.ExecuteNonQuery();
    }

    public DataTable selectQuery(string str)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter adp = new SqlDataAdapter(str, con);
        adp.Fill(dt);
        return dt;
    }

    public void fillGrid(GridView grd, string str)
    {
        DataTable dt = new DataTable();
        dt = selectQuery(str);
        grd.DataSource = dt;
        grd.DataBind();
    }
    public void fillDataList(DataList dlst, string str)
    {
        DataTable dt = new DataTable();
        dt = selectQuery(str);
        dlst.DataSource = dt;
        dlst.DataBind();
    }
    public void fillRepeater(Repeater rptr, string str)
    {
        DataTable dt = new DataTable();
        dt = selectQuery(str);
        rptr.DataSource = dt;
        rptr.DataBind();
    }
    public void fillDetailsView(DetailsView dtv, string str)
    {
        DataTable dt = new DataTable();
        dt = selectQuery(str);
        dtv.DataSource = dt;
        dtv.DataBind();
    }
    public void fillDDL(DropDownList ddl, string txtFiled, string valField, string str)
    {
        DataTable dt = new DataTable();
        dt = selectQuery(str);
        ddl.DataSource = dt;
        ddl.DataTextField = txtFiled;
        ddl.DataValueField = valField;
        ddl.DataBind();
        ddl.Items.Insert(0, "--select--");
    }
    public void fillChkList(CheckBoxList chklist, string txtFiled, string valField, string str)
    {
        DataTable dt = new DataTable();
        dt = selectQuery(str);
        chklist.DataSource = dt;
        chklist.DataTextField = txtFiled;
        chklist.DataValueField = valField;
        chklist.DataBind();
    }
    public void ExecuteCommand(string querystr)
    {
        SqlCommand cmd = new SqlCommand(querystr, con);
        cmd.ExecuteNonQuery();
    }
    public DataTable GetDataTable(String querystr)
    {
        SqlDataAdapter ada = new SqlDataAdapter(querystr, con);
        DataTable dt = new DataTable();
        ada.Fill(dt);
        return dt;
    }
    public void FillGridView(string querystr, GridView grid)
    {
        DataTable dt = GetDataTable(querystr);
        grid.DataSource = dt;
        grid.DataBind();
    }
    public void FillDetailsView(string querystr, DetailsView dts)
    {
        DataTable dt = GetDataTable(querystr);
        dts.DataSource = dt;
        dts.DataBind();
    }
    public void FillDataList(string querystr, DataList list)
    {
        DataTable dt = GetDataTable(querystr);
        list.DataSource = dt;
        list.DataBind();
    }
    public void FillDrop(DropDownList drop, string display, string valfield, string tbl)
    {
        string str = "select " + display + "," + valfield + " from " + tbl + "";
        DataTable dt1 = GetDataTable(str);
        drop.DataSource = dt1;
        drop.DataTextField = display;
        drop.DataValueField = valfield;
        drop.DataBind();
        drop.Items.Insert(0, "--select--");
    }
    public void FillDrop(DropDownList dd1, string display, string valfield, string tbl, string condition1)
    {
        string str = "select " + display + "," + valfield + " from " + tbl + " where " + condition1 + "";
        DataTable dt1 = new DataTable();
        dt1 = GetDataTable(str);
        dd1.DataSource = dt1;
        dd1.DataTextField = display;
        dd1.DataValueField = valfield;
        dd1.DataBind();
        dd1.Items.Insert(0, "--select--");
    }
    public void FillCheck(CheckBoxList chk, string display, string valfield, string tbl)
    {
        string str = "select " + display + "," + valfield + " from " + tbl + "";
        DataTable dt1 = GetDataTable(str);
        chk.DataSource = dt1;
        chk.DataTextField = display;
        chk.DataValueField = valfield;
        chk.DataBind();
    }
    public void FillCheck(CheckBoxList chk, string display, string valfield, string tbl, string condition1)
    {
        string str = "select " + display + "," + valfield + " from " + tbl + " where " + condition1 + "";
        DataTable dt1 = GetDataTable(str);
        chk.DataSource = dt1;
        chk.DataTextField = display;
        chk.DataValueField = valfield;
        chk.DataBind();
    }


}