<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Adminmaster.master" AutoEventWireup="true" CodeFile="CompanyDetails.aspx.cs" Inherits="Agency_Employee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style11">Name</td>
            <td class="auto-style12">
                <asp:TextBox ID="txtname" runat="server" Width="245px" BorderColor="Black" BorderWidth="1px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtname" ErrorMessage="*" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtname" ErrorMessage="enter only character" ForeColor="Red" ValidationExpression="[a-zA-Z]+"></asp:RegularExpressionValidator>
            </td>
            <td class="auto-style12"></td>
        </tr>
         <tr>
            <td class="auto-style9">Contact</td>
            <td class="auto-style10">
                <asp:TextBox ID="txtcon" runat="server" Width="245px" BorderColor="Black" BorderWidth="1px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtcon" ErrorMessage="*" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtcon" ErrorMessage="numbers only" ValidationExpression="\d[10]"></asp:RegularExpressionValidator>
            </td>
            <td class="auto-style10"></td>
        </tr>
        <tr>
            <td class="auto-style13">Email</td>
            <td class="auto-style14">
                <asp:TextBox ID="txtemail" runat="server" Width="245px" BorderColor="Black" BorderWidth="1px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtemail" ErrorMessage="*" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtemail" ErrorMessage="Invalid E-mail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
            <td class="auto-style14"></td>
        </tr>
       
        <tr>
            <td class="auto-style15">Address</td>
            <td class="auto-style16">
                <asp:TextBox ID="txtadd" runat="server" Width="245px" BorderColor="Black" BorderWidth="1px" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtadd" ErrorMessage="*" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtadd" ErrorMessage="characters only" ValidationExpression="[a-zA-Z]+"></asp:RegularExpressionValidator>
            </td>
            <td class="auto-style16"></td>
        </tr>
        <tr>
            <td class="auto-style17">Username</td>
            <td class="auto-style18">
                <asp:TextBox ID="txtuser" runat="server" Width="245px" BorderColor="Black" BorderWidth="1px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtuser" ErrorMessage="*" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" BackColor="White" BorderColor="#FF3300" ControlToValidate="txtuser" ErrorMessage="Invalid" ValidationExpression="[a-zA-Z]+"></asp:RegularExpressionValidator>
            </td>
            <td class="auto-style18"></td>
        </tr>
        <tr>
            <td class="auto-style11">Password</td>
            <td class="auto-style12">
                <asp:TextBox ID="txtpas" runat="server" Width="245px" BorderColor="Black" BorderWidth="1px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtpas" ErrorMessage="*" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style12"></td>
        </tr>
        <tr>
            <td class="auto-style3"></td>
            <td class="auto-style4">
                <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" Width="90px" BorderColor="Black" BorderWidth="1px" />
                <asp:Button ID="btn" runat="server" Text="Cancel" OnClick="btn_Click" Width="90px" BorderColor="Black" BorderWidth="1px" CausesValidation="False" />
            </td>
            <td class="auto-style4"></td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td>
                <asp:GridView ID="grdem" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnRowCommand="grdem_RowCommand" >
                    <Columns>
                     
                        <%--<asp:TemplateField HeaderText="Photo">
                            <ItemTemplate>
                                <img src="file/<%#Eval("company_photo")%>" width="60" height="60" />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        
                       
                        <asp:BoundField DataField="company_name" HeaderText="Name" />
                        
                        <asp:BoundField DataField="company_contact" HeaderText="Contact" />
                        <asp:BoundField DataField="company_email" HeaderText="Email" />
                        <asp:BoundField DataField="company_address" HeaderText="Address" />
                        <asp:BoundField DataField="company_username" HeaderText="Username" />
                        <asp:BoundField DataField="company_password" HeaderText="Password" />
                    
                      
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton3" runat="server" CommandArgument='<%# Eval("company_id") %>' CommandName="ed" CausesValidation="False">Edit</asp:LinkButton>
                                <asp:LinkButton ID="LinkButton4" runat="server" CommandArgument='<%# Eval("company_id") %>' CommandName="del" CausesValidation="False">Delete</asp:LinkButton>
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
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7"></td>
            <td class="auto-style8"></td>
            <td class="auto-style8"></td>
        </tr>
    </table>
</asp:Content>

