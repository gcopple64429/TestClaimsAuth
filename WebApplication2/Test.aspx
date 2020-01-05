<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="TestClaimsAuth.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
<table style="width: 100%;">
    <tr>
        <td>
            <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                <asp:ListItem Value="textbox">Textbox</asp:ListItem>
                <asp:ListItem Value="radio">Radiobutton</asp:ListItem>
                <asp:ListItem Value="check">Checkbox</asp:ListItem>
            </asp:CheckBoxList>
        </td>
        <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
        <td><asp:Button ID="Button1" runat="server" Text="Create" OnClick="Button1_Click" /></td>
        
       
    </tr>
   
</table>
            
            <asp:Panel runat="server" ID="rtsc1">
   
            </asp:Panel>
            <asp:Literal runat="server" ID="ltlTable"></asp:Literal>
           
        </div>

    </form>
</body>
</html>


