<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportDemoWithEasyUI.aspx.cs" Inherits="JQueryEasyUI.ReportDemoWithEasyUI" %>

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
    <table id="gridList" style="margin: 5px; width: 100%;"></table>
</body>
<script type="text/javascript">

    $('#gridList').datagrid({
        title: "预拌砂浆生产及废弃物综合利用情况统计月报表",
        //nowrap: true, //单元格是否可以换行
        striped: true, //行条纹
        collapsible: true,
        width: 'auto',
        height: 'auto',
        fit: true,
        fitColumns: true, //是否调整列宽 
        //remoteSort: false,
        idField: "fj",
        singleSelect: true,
        loadMsg: '正在加载数据，请稍等……',
        columns: [
                    [
                        { title: "地区", rowspan: 4, align: "center"},
                        { title: "普通干混砂浆", colspan: 3, align: "center" },
                        { title: "实际产量", colspan: 8, align: "center", width: 400 },
                        { title: "使用散装水泥量", colspan: 2, rowspan: 2, align: "center" },
                        { title: "废弃物利用量", colspan: 2, rowspan: 2, align: "center" },
                        { title: "备注", rowspan: 4, align: "center", width: 400 }
                    ],
                    [
                        { title: "生产企业数量（个）", rowspan: 3, align: "center" },
                        { title: "设计生产能力", colspan: 2, align: "center" },
                        { title: "总量", colspan: 2, align: "center" },
                        { title: "其中：普通干混砂浆", colspan: 4, align: "center" },
                        { title: "其中：湿拌砂浆", colspan: 2, rowspan: 2, align: "center" }
                    ],
                    [
                        { title: "总能力", rowspan: 2, align: "center" },
                        { title: "其中：散装能力", rowspan: 2, align: "center" },
                        { title: "本月", rowspan: 2, align: "center" },
                        { title: "累计", rowspan: 2, align: "center" },
                        { title: "合计", colspan: 2, align: "center" },
                        { title: "其中：散装量", colspan: 2, align: "center" },
                        { title: "本月", rowspan: 2, align: "center" },
                        { title: "累计", rowspan: 2, align: "center" },
                        { title: "本月", rowspan: 2, align: "center" },
                        { title: "累计", rowspan: 2, align: "center" }
                    ],
                    [
                            { title: "本月", align: "center" },
                            { title: "累计", align: "center" },
                            { title: "本月", align: "center" },
                            { title: "累计", align: "center" },
                            { title: "本月", align: "center" },
                            { title: "累计", align: "center" }
                    ],
                    [
                        { field: "fj", title: "甲", align: "center" },
                        { field: "f1", title: "1", align: "center" },
                        { field: "f2", title: "2", align: "center" },
                        { field: "f3", title: "3", align: "center" },
                        { field: "f4", title: "4", align: "center" },
                        { field: "f5", title: "5", align: "center" },
                        { field: "f6", title: "6", align: "center" },
                        { field: "f7", title: "7", align: "center" },
                        { field: "f8", title: "8", align: "center" },
                        { field: "f9", title: "9", align: "center" },
                        { field: "f10", title: "10", align: "center" },
                        { field: "f11", title: "11", align: "center" },
                        { field: "f12", title: "12", align: "center" },
                        { field: "f13", title: "13", align: "center" },
                        { field: "f14", title: "14", align: "center" },
                        { field: "f15", title: "15", align: "center" },
                        { field: "fy", title: "乙", align: "center" }
                    ]
        ]
    });
    var data = [
            { fj: "J1", f1: 1, f2: 2, f3: 3, f4: 4, f5: 5, f6: 6, f7: 7, f8: 8, f9: 9, f10: 10, f11: 11, f12: 12, f13: 13, f14: 14, f15: 15, fy: "Y" },
            { fj: "J2", f1: 1, f2: 2, f3: 3, f4: 4, f5: 5, f6: 6, f7: 7, f8: 8, f9: 9, f10: 10, f11: 11, f12: 12, f13: 13, f14: 14, f15: 15, fy: "Y" },
            { fj: "J3", f1: 1, f2: 2, f3: 3, f4: 4, f5: 5, f6: 6, f7: 7, f8: 8, f9: 9, f10: 10, f11: 11, f12: 12, f13: 13, f14: 14, f15: 15, fy: "Y" },
            { fj: "J4", f1: 1, f2: 2, f3: 3, f4: 4, f5: 5, f6: 6, f7: 7, f8: 8, f9: 9, f10: 10, f11: 11, f12: 12, f13: 13, f14: 14, f15: 15, fy: "Y" },
            { fj: "J5", f1: 1, f2: 2, f3: 3, f4: 4, f5: 5, f6: 6, f7: 7, f8: 8, f9: 9, f10: 10, f11: 11, f12: 12, f13: 13, f14: 14, f15: 15, fy: "Y" }
    ];
    $("#gridList").datagrid("loadData", data);
</script>
</html>
