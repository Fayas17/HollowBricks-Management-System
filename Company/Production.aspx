<%@ Page Title="" Language="C#" MasterPageFile="~/Company/Adminmaster.master" AutoEventWireup="true" CodeFile="Production.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style1">
        <tr>
            <td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Production&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">Product</td>
            <td>
                <asp:DropDownList ID="ddlproduct" runat="server">
                    <asp:ListItem>--Select--</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Date</td>
            <td>
                <asp:TextBox ID="txtdate" runat="server" TextMode="Date"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Quantity</td>
            <td>
                <asp:TextBox ID="txtqty" runat="server"></asp:TextBox>
                <asp:Label ID="Label1" runat="server" Text="[in liter]"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2" colspan="2">
                <asp:Button ID="btnsave" runat="server" OnClick="btnsave_Click" Text="Save" />
                <asp:Button ID="btncancel" runat="server" OnClick="btncancel_Click" Text="Cancel" />
            </td>
        </tr>
        <tr>
            <td class="auto-style2" colspan="2">
                <asp:GridView ID="grid" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnRowCommand="grid_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="product_name" HeaderText="PRODUCT" />
                        <asp:BoundField DataField="production_date" HeaderText="DATE" />
                        <asp:BoundField DataField="production_qty" HeaderText="QUANTITY" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btndelete" runat="server" CausesValidation="False" CommandArgument='<%# Eval("production_id") %>' CommandName="del" Text="Delete" />
                                <asp:Button ID="btnedit" runat="server" CausesValidation="False" CommandArgument='<%# Eval("production_id") %>' CommandName="ed" Text="Edit" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" ForeColor="#003399" />
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                    <SortedDescendingHeaderStyle BackColor="#002876" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

