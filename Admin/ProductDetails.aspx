<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Adminmaster.master" AutoEventWireup="true" CodeFile="ProductDetails.aspx.cs" Inherits="ShowRoom_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style3">Product Name</td>
            <td class="auto-style4">
                <asp:TextBox ID="txtname" runat="server" Width="220px"></asp:TextBox>
            </td>
            <td class="auto-style4">
                <asp:RequiredFieldValidator ID="Req" runat="server" ControlToValidate="txtname" ErrorMessage="Enter the Name"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Product Type</td>
            <td class="auto-style4">
                <asp:DropDownList ID="ddlcartype" runat="server" Width="225px">
                </asp:DropDownList>
            </td>
            <td class="auto-style4">
                <asp:RequiredFieldValidator ID="req2" runat="server" ControlToValidate="ddlcartype" ErrorMessage="Select Type" InitialValue="---select---"></asp:RequiredFieldValidator>
            </td>
        </tr>
       
        <tr>
            <td class="auto-style2">Price</td>
            <td>
                <asp:TextBox ID="txtprice" runat="server" Width="220px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="req5" runat="server" ControlToValidate="txtprice" ErrorMessage="Enter the price"></asp:RequiredFieldValidator>
            </td>
        </tr>
         <tr>
            <td class="auto-style2">Image</td>
            <td>
                <asp:FileUpload ID="filup" runat="server" Width="225px" />
            </td>
            <td>
                <asp:RequiredFieldValidator ID="req4" runat="server" ControlToValidate="filup" ErrorMessage="Select the image"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style5"></td>
            <td class="auto-style6">
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" Width="90px" />
            &nbsp;<asp:Button ID="btncancel" runat="server" Text="Cancel" Width="90px" OnClick="btncancel_Click" CausesValidation="False" />
                <asp:GridView ID="car" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnRowCommand="car_RowCommand" >
                    <Columns>
                       
                        <asp:TemplateField HeaderText="Image">
                            <ItemTemplate>
                                <img src="ProductImage/<%#Eval("product_image")%>" width="50" height="50" />
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                        <asp:BoundField DataField="product_name" HeaderText="ProductName" />
                         <asp:BoundField DataField="product_price" HeaderText="Price" />
                        <asp:BoundField DataField="category_name" HeaderText="Category" />
                         
                        <asp:TemplateField>
                            <ItemTemplate>
                                <%--<asp:LinkButton ID="txtdelete" runat="server" CausesValidation="False" CommandArgument='<%# Eval("car_id") %>' CommandName="ed" >Edit</asp:LinkButton>--%>
                                <asp:LinkButton ID="txtedit" runat="server" CausesValidation="False" CommandArgument='<%# Eval("product_id") %>' CommandName="del">Delete</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
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

