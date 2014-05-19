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
    <style type="text/css">
        td div {
            width: 100%;
        }
    </style>
</head>
<body>
    <div id="divGridList1"></div>
    <br />
    <br />
    <div id="divGridList2"></div>
    <br />
    <br />
</body>
<script type="text/javascript">
    $('#divGridList1').datagrid({
        columns: [
                    [
                        { field: "area", title: "地区", rowspan: 2, align: "center" },
                        { field: "cn", title: "生产企业数量（个）", rowspan: 2, align: "center" },
                        { field: "yp", title: "年设计生产能力（万立方米）", rowspan: 2, align: "center" },
                        { field: "sjcl", title: "实际产量（立方米）", colspan: 2, align: "center" },
                        { field: "syszsnl", title: "使用散装水泥量(吨)", colspan: 2, align: "center" },
                        { field: "fqwzhlyl", title: "废弃物综合利用量(吨)", colspan: 2, align: "center" },
                        { field: "remark", title: "备注", rowspan: 2, align: "center" }
                    ],
                    [

                        { field: "by1", title: "本月1", align: "center" },
                        { field: "lj1", title: "累计1", align: "center" },
                        { field: "by2", title: "本月2", colspan: 1, align: "center" },
                        { field: "lj2", title: "累计2", colspan: 1, align: "center" },
                        { field: "by3", title: "本月3", colspan: 1, align: "center" },
                        { field: "lj3", title: "累计3", colspan: 1, align: "center" }
                    ]
        ],
        data: [
            { area: "东北", cn: 85, yp: 5000000, sjcl: 123456789, syszsnl: 123456789, fqwzhlyl: 123456789, remark: "备注备注备注备注", by1: 5000, lj1: 10000, by2: 3000, lj2: 6000, by3: 15000, lj3: 30000 },
            { area: "东北", cn: 85, yp: 5000000, sjcl: 123456789, syszsnl: 123456789, fqwzhlyl: 123456789, remark: "备注备注备注备注", by1: 5000, lj1: 10000, by2: 3000, lj2: 6000, by3: 15000, lj3: 30000 },
            { area: "东北", cn: 85, yp: 5000000, sjcl: 123456789, syszsnl: 123456789, fqwzhlyl: 123456789, remark: "备注备注备注备注", by1: 5000, lj1: 10000, by2: 3000, lj2: 6000, by3: 15000, lj3: 30000 },
        ]
    });
    $('#divGridList2').datagrid({
        title: "预拌砂浆生产及废弃物综合利用情况统计月报表",
        columns: [
                    [
                        { title: "地区", rowspan: 4, align: "center" },
                        { title: "普通干混砂浆", colspan: 3, align: "center" },
                        { title: "实际产量", colspan: 8, align: "center" },
                        { title: "使用散装水泥量", colspan: 2, rowspan: 2, align: "center" },
                        { title: "废弃物利用量", colspan: 2, rowspan: 2, align: "center" },
                        { title: "备注", rowspan: 4, align: "center" }
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
                        { field: "fj", title: "甲", align: "center", width: 150 },
                        { field: "f1", title: "1", align: "center" },
                        { field: "f2", title: "2", align: "center", width: 150 },
                        { field: "f3", title: "3", align: "center", width: 150 },
                        { field: "f4", title: "4", align: "center", width: 150 },
                        { field: "f5", title: "5", align: "center", width: 150 },
                        { field: "f6", title: "6", align: "center", width: 150 },
                        { field: "f7", title: "7", align: "center", width: 150 },
                        { field: "f8", title: "8", align: "center", width: 150 },
                        { field: "f9", title: "9", align: "center", width: 150 },
                        { field: "f10", title: "10", align: "center", width: 150 },
                        { field: "f11", title: "11", align: "center", width: 150 },
                        { field: "f12", title: "12", align: "center", width: 150 },
                        { field: "f13", title: "13", align: "center", width: 150 },
                        { field: "f14", title: "14", align: "center", width: 150 },
                        { field: "f15", title: "15", align: "center", width: 150 },
                        { field: "fy", title: "乙", align: "center", width: 150 }
                    ]
        ],
        data: [
            { fj: "J", f1: 1, f2: 2, f3: 3, f4: 4, f5: 5, f6: 6, f7: 7, f8: 8, f9: 9, f10: 10, f11: 11, f12: 12, f13: 13, f14: 14, f15: 15, fy: "Y" },
            { fj: "J", f1: 1, f2: 2, f3: 3, f4: 4, f5: 5, f6: 6, f7: 7, f8: 8, f9: 9, f10: 10, f11: 11, f12: 12, f13: 13, f14: 14, f15: 15, fy: "Y" },
            { fj: "J", f1: 1, f2: 2, f3: 3, f4: 4, f5: 5, f6: 6, f7: 7, f8: 8, f9: 9, f10: 10, f11: 11, f12: 12, f13: 13, f14: 14, f15: 15, fy: "Y" },
            { fj: "J", f1: 1, f2: 2, f3: 3, f4: 4, f5: 5, f6: 6, f7: 7, f8: 8, f9: 9, f10: 10, f11: 11, f12: 12, f13: 13, f14: 14, f15: 15, fy: "Y" },
            { fj: "J", f1: 1, f2: 2, f3: 3, f4: 4, f5: 5, f6: 6, f7: 7, f8: 8, f9: 9, f10: 10, f11: 11, f12: 12, f13: 13, f14: 14, f15: 15, fy: "Y" }
        ]
    });
    $("td div").css("width", "100%");
</script>
</html>
