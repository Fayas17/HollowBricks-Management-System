<%@ Page Title="" Language="C#" MasterPageFile="~/Company/Adminmaster.master" AutoEventWireup="true" CodeFile="EmployeeDetails.aspx.cs" Inherits="Agency_Employee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 112px;
        }
        .auto-style3 {
            width: 112px;
            height: 23px;
        }
        .auto-style4 {
            height: 23px;
        }
        .auto-style7 {
            width: 112px;
            height: 207px;
        }
        .auto-style8 {
            height: 207px;
        }
    .auto-style9 {
        width: 112px;
        height: 27px;
    }
    .auto-style10 {
        height: 27px;
    }
    .auto-style11 {
        width: 112px;
        height: 28px;
    }
    .auto-style12 {
        height: 28px;
    }
    .auto-style13 {
        width: 112px;
        height: 30px;
    }
    .auto-style14 {
        height: 30px;
    }
    .auto-style15 {
        width: 112px;
        height: 32px;
    }
    .auto-style16 {
        height: 32px;
    }
    .auto-style17 {
        width: 112px;
        height: 31px;
    }
    .auto-style18 {
        height: 31px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td>
                <asp:GridView ID="grdem" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnRowCommand="grdem_RowCommand" >
                    <Columns>
                     
                        <asp:TemplateField HeaderText="Photo">
                            <ItemTemplate>
                                <img src="../Admin/file/<%#Eval("emp_photo")%>" width="60" height="60" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:BoundField DataField="company_name" HeaderText="CompanyName" />
                        <asp:BoundField DataField="emp_name" HeaderText="Name" />
                        
                        <asp:BoundField DataField="emp_contact" HeaderText="Contact" />
                        <asp:BoundField DataField="emp_email" HeaderText="Email" />
                         <asp:BoundField DataField="emp_doj" HeaderText="DOJ" />
                         <asp:BoundField DataField="emp_address" HeaderText="Address" />
                    
                      
                        <%--<asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton3" runat="server" CommandArgument='<%# Eval("emp_id") %>' CommandName="ed" CausesValidation="False">Edit</asp:LinkButton>
                                <asp:LinkButton ID="LinkButton4" runat="server" CommandArgument='<%# Eval("emp_id") %>' CommandName="del" CausesValidation="False">Delete</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
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

