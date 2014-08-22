<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EasyUIGridEdit.aspx.cs" Inherits="JQueryEasyUI.EasyUIGridEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="Scripts/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="Scripts/jquery.easyui-1.3.6.js"></script>
    <link rel="stylesheet" type="text/css" href="Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="Content/themes/default/datagrid.css" />
</head>
<body>
    <div style="width: 800px; height: 500px;">
        <table id="grid"></table>
    </div>
</body>
<script type="text/javascript">
    function initGrid() {
        var columns = [
            { title: "学号", field: "sid", align: "center", sortable: "false", width: "100" },
            { title: "姓名", field: "name", align: "center", sortable: "false", width: "100" },
            {
                title: "性别", field: "sex", align: "center", sortable: "false", width: "50", formatter: function (value, rowData, index) {
                    if (value == 0) {
                        return "男";
                    }
                    else {
                        return "女";
                    }
                }
            },
            { title: "年级", field: "grade", align: "center", sortable: "false", width: "100" },
            { title: "班级", field: "className", align: "center", sortable: "false", width: "100" },
            {
                title: "生日", field: "brithday", align: "center", sortable: "false", width: "100", formatter: function (value, rowData, index) {
                    //if (value) {
                    //    var date = new Date(Date.parse(value.replace(/-/g, "/")));
                    //    return date.format("yyyy年MM月dd日");
                    //}
                    return value;
                }
            },
            { title: "年龄", field: "age", align: "center", sortable: "false", width: "50" },
            { title: "备注", field: "remark", align: "center", sortable: "false", width: "130" }
        ];
        $("#grid").datagrid({
            striped: true, //行条纹
            collapsible: true,
            width: 'auto',
            height: 'auto',
            fit: true,
            fitColumns: true, //是否调整列宽 
            //remoteSort: false,
            idField: "sid",
            singleSelect: true,
            loadMsg: '正在加载数据，请稍等……',
            columns: [columns]
        });
        $.ajax(
            {
                url: "EasyUIGridEdit.aspx?action=getdata",
                type: "GET",
                dataType: "JSON",
                success: function (data) {
                    var rows = data["rows"];
                    if (!rows) {
                        rows = [];
                    }
                    $("#grid").datagrid("loadData", rows);
                },
                error: function () {
                    $.messager.alert("错误", "读取数据失败！");
                }
            });

    }
    $(document).ready(function () {
        initGrid();
    });
</script>
</html>
