<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToTable.aspx.cs" Inherits="数据库操作.ToTable" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnCreateDB" Text="创建测试数据库" runat="server" 
            onclick="btnCreateDB_Click" /><br/>
        <asp:Button ID="btnCreateTable" Text="创建测试表" runat="server" 
            onclick="btnCreateTable_Click" /><br />
        <asp:Button ID="btnAlterTable" Text="修改表" runat="server" 
            onclick="btnAlterTable_Click" />
    </div>
    </form>
</body>
</html>
