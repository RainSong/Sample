<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jqGrid.aspx.cs" Inherits="WebFormSample.jqGrid" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="Content/themes/base/jquery-ui.css" rel="stylesheet" />
    <link href="Content/themes/base/jquery.ui.all.css" rel="stylesheet" />
    <link href="Content/jquery.jqGrid/ui.jqgrid.css" rel="stylesheet" />


    <script src="Scripts/jquery-2.1.1.js"></script>
    <script src="Scripts/jquery-ui-1.10.4.js"></script>
    <script src="Scripts/i18n/grid.locale-cn.js"></script>
    <script src="Scripts/jquery.jqGrid.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <table id="tableGrid">
        </table>
        <input type="button" id="button1" value="" />
    </form>
</body>
<script type="text/javascript">
    var code = "";
    var data = [
        { id: "1001", name: "Student1", sex: "1", brithday: "2014-07-15", gradName: "初中一年级", className: "一（1）班" },
        { id: "1002", name: "Student2", sex: "0", brithday: "2014-07-16", gradName: "初中二年级", className: "二（1）班" },
        { id: "1003", name: "Student3", sex: "1", brithday: "2014-07-17", gradName: "初中三年纪", className: "三（1）班" },
        { id: "1004", name: "Student4", sex: "0", brithday: "2014-07-18", gradName: "高中一年级", className: "一（1）班" },
        { id: "1005", name: "Student5", sex: "1", brithday: "2014-07-19", gradName: "高中二年级", className: "二（1）班" },
        { id: "1006", name: "Student6", sex: "0", brithday: "2014-07-20", gradName: "高中三年级", className: "三（1）班" },
    ];
    function initGrid() {
        $("#tableGrid").jqGrid({
            autoWidth: true,
            dataType: "local",
            colNames: ["编号", "姓名", "性别", "出生日期", "年纪名称", "年纪名称"],
            colModel: [
                    { name: "id", width: 80, sortable: false, align: "center" },
                    { name: "name", width: 120, sortable: false, align: "center" },
                    {
                        name: "sex", width: 80, sortable: false, align: "center", formatter: function (cellValue, options, rowObject) {
                            if (cellValue == 0) return "女"
                            return "男";
                        }
                    },
                    { name: "brithday", width: 150, sortable: true, align: "center" },
                    { name: "gradName", width: 120, sortable: false, align: "center" },
                    { name: "className", width: 120, sortable: false, align: "center" }
            ]
        });
    }
    function loadData() {
        for (var i = 0, j = data.length; i < j; i++) {
            $("#tableGrid").addRowData(i + 1, data[i]);
        }
    }
    $(document).ready(function () {
        initGrid();
        loadData();
        $("#button1").button({ text: "this is a button" });
    });
</script>
</html>
