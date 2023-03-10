<%@ Page Title="" Language="C#" MasterPageFile="~/Company/Adminmaster.master" AutoEventWireup="true" CodeFile="SalesDetails.aspx.cs" Inherits="Company_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <fieldset><legend class="auto-style9">Sales</legend>
    <table class="auto-style1">
        <tr>
            <td class="auto-style10">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style10">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style10">&nbsp;</td>
            <td>Customer Name</td>
            <td>
                <asp:TextBox ID="txtname" runat="server" OnTextChanged="txtrationcard_TextChanged" Width="250px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtname" ErrorMessage="Enter Name" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style10">&nbsp;</td>
            <td>Contact Number</td>
            <td>
                <asp:TextBox ID="txtcontact" runat="server" Width="250px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtcontact" ErrorMessage="Enter Contact Number" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style10">&nbsp;</td>
            <td>Address</td>
            <td>
                <asp:TextBox ID="txtaddress" runat="server" TextMode="MultiLine" Width="255px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style10">&nbsp;</td>
            <td>Category</td>
            <td>
                <asp:DropDownList ID="ddlcategory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlcategory_SelectedIndexChanged" Width="255px">
                </asp:DropDownList>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="ddlcategory" ErrorMessage="Select category" ForeColor="Red" InitialValue="--Select--"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style10">&nbsp;</td>
            <td>Item</td>
            <td>
                <asp:DropDownList ID="ddlitem" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlitem_SelectedIndexChanged" Width="255px">
                </asp:DropDownList>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="ddlitem" ErrorMessage="Select item" ForeColor="Red" InitialValue="--Select--"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style10">&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="lblstock" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style10">&nbsp;</td>
            <td>Rate</td>
            <td>
                <asp:TextBox ID="txtrate" runat="server" Width="250px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtrate" ErrorMessage="Enter rate" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style10">&nbsp;</td>
            <td>Quantity</td>
            <td>
                <asp:TextBox ID="txtquantity" runat="server" Width="250px" AutoPostBack="True" OnTextChanged="txtquantity_TextChanged"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="txtquantity" ErrorMessage="Enter quantity" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style10">&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="lblcheck" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style10">&nbsp;</td>
            <td>&nbsp;</td>
            <td colspan="2">
                <asp:Button ID="btnaddtocart" runat="server" OnClick="btnaddtocart_Click" Text="Add To Cart" Width="120px" />
                &nbsp;&nbsp;
                <asp:Button ID="btncancel" runat="server" OnClick="btncancel_Click" Text="Cancel" CausesValidation="False" Width="120px" />
            </td>
        </tr>
        <tr>
            <td class="auto-style10">&nbsp;</td>
            <td>&nbsp;</td>
            <td colspan="2">
                <asp:GridView ID="grdsales" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" ForeColor="Black" ShowFooter="True" style="text-align: center" Width="422px" CellSpacing="2">
                    <Columns>
                        <asp:BoundField DataField="category_name" HeaderText="Category" />
                        <asp:BoundField DataField="category_name" HeaderText="Product" />
                        <asp:TemplateField HeaderText="Quantity">
                            <ItemTemplate>
                                <asp:Label ID="lblquantity" runat="server" Text='<%# Eval("Sd_itemqty") %>'></asp:Label>
                                <br />
                                <asp:HiddenField ID="hiddenqty" runat="server" Value='<%# Eval("product_id") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Price">
                            <ItemTemplate>
                                <asp:Label ID="lblprice" runat="server" Text='<%# Eval("Sh_grandtotal") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btndelete" runat="server" CausesValidation="False" CommandName="del" OnClick="btndelete_Click" Width="90" Text="Delete" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <FooterTemplate>
                                <asp:Button ID="btnsave" runat="server" OnClick="btnsave_Click" Text="Save" Width="120" CausesValidation="False" />
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" Wrap="True" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
            </td>
        </tr>
        </table>
        </fieldset>
</asp:Content>

