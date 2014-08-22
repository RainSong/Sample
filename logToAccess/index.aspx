<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="logToAccess.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="add" Text="增加一条日志" runat="server" onclick="add_Click" /><br /><br />
        <asp:Button ID="testConnection" Text="测试连接" runat="server" 
            onclick="testConnection_Click" /><br /><br />
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label><br /><br />
    <asp:Button ID="AddTest" Text="测试添加一条数据" runat="server" onclick="AddTest_Click"/><br /><br />
    <asp:Label ID="Label2" runat="server"></asp:Label><br/>
    <asp:Label ID="Label3" runat="server"></asp:Label>
    </div>
    
    </form>
</body>
</html>
