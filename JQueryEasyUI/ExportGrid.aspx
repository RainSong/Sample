<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExportGrid.aspx.cs" Inherits="JQueryEasyUI.ExportGrid" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
<script type="text/javascript" src="Scripts/exprot.js"></script>
<script type="text/javascript">
    var data = [
            { sid: "s001", name: "张三", bir: "2014-1-1", sex: "男" },
            { sid: "s001", name: "李四", bir: "2014-1-1", sex: "女" },
            { sid: "s003", name: "王五", bir: "2014-1-3", sex: "男" },
            { sid: "s004", name: "赵六", bir: "2014-1-5", sex: "女" },
            { sid: "s005", name: "钱七", bir: "2014-1-5", sex: "男" },
            { sid: "s006", name: "孙八", bir: "2014-1-5", sex: "女" },
    ];
    var fields = ["name", "bir", "set"];
    var html = exportHelper.getExportHtml(data, fields);
    console.log(html);
</script>
</html>
