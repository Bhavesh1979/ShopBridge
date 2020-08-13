<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 42px;
        }
        .style3
        {
            width: 129px;
        }
#objTable3 tr:hover {background-color: #ddd; height: 2px;}
#objTable3 td, #objTable th {
    border: 1px solid #ddd;
    padding: 5px;
}

    </style>

</head>
<body>
    <form id="form1" runat="server">
    <asp:scriptmanager ID="Scriptmanager1" runat="server"> 
</asp:scriptmanager>
    <div>
        <asp:Panel ID="Panel3" runat="server">
            <table class="style1">
                <tr>
                    <td align="center" valign="middle">
                        <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Italic="True" 
                            Font-Size="XX-Large" Text="ShopBridge"></asp:Label>
                    </td>
                </tr>
            </table>

        </asp:Panel>
    
        <asp:Panel ID="Panel1" runat="server" GroupingText="Add Items">

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">

                <ContentTemplate>
                    <table id="objTable3" class="style1">
                        <tr>
                            <td>
                                Name</td>
                            <td>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Description</td>
                            <td>
                                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Price</td>
                            <td>
                                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Image (Optional)</td>
                            <td>
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Button ID="Button1" runat="server" Text="Add Item" 
                                    onclick="Button1_Click1" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
                <Triggers> 
            <asp:PostBackTrigger ControlID="Button1" />
            </Triggers>

            </asp:UpdatePanel>
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" GroupingText="View Items">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <table id = "objTable3" class="style1">
                        <tr>
                            <td class="style2" rowspan="6" valign="top">
                                <asp:ListBox ID="ListBox1" runat="server" AutoPostBack="True" Height="354px" 
                                    onselectedindexchanged="ListBox1_SelectedIndexChanged" Width="339px">
                                </asp:ListBox>
                            </td>
                            <td class="style3" valign="top">
                                <asp:Image ID="Image1" runat="server" Height="172px" Width="166px" />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style3">
                                ID</td>
                            <td>
                                <asp:Label ID="Label1" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style3">
                                Description</td>
                            <td>
                                <asp:Label ID="Label3" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style3">
                                Name</td>
                            <td>
                                <asp:Label ID="Label2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style3">
                                Price</td>
                            <td>
                                <asp:Label ID="Label4" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style3">
                                &nbsp;</td>
                            <td>
                                <asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
                                    Text="Delete Item" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
