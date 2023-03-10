<%@ Page Title="" Language="C#" MasterPageFile="~/Company/Adminmaster.master" AutoEventWireup="true" CodeFile="ProductDetails.aspx.cs" Inherits="ShowRoom_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style5"></td>
            <td class="auto-style6">
            &nbsp;<asp:GridView ID="car" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnRowCommand="car_RowCommand" >
                    <Columns>
                       
                        <asp:TemplateField HeaderText="Image">
                            <ItemTemplate>
                                <img src="../Admin/ProductImage/<%#Eval("product_image")%>" width="50" height="50" />
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                        <asp:BoundField DataField="product_name" HeaderText="ProductName" />
                         <asp:BoundField DataField="product_price" HeaderText="Price" />
                        <asp:BoundField DataField="category_name" HeaderText="Category" />
                         
                   
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
            </td>
            <td class="auto-style6">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

