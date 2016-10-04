<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="SessionInSqlserver.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>SessionKey</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtKey"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>SessionValue</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtValue"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button runat="server" ID="btnAdd" Text="保存Session" OnClick="btnAdd_Click" /></td>
                    <td>
                        <asp:Button runat="server" ID="btnGet" Text="读取Session" OnClick="btnGet_Click" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
