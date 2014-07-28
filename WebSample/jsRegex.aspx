<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jsRegex.aspx.cs" Inherits="WebSample.jsRegex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="Scripts/jquery-2.1.1.js"></script>
    <script type="text/javascript">
        function foo1(html) {

            //#region 移除无用属性
            html = html.replace(/ field=\"\w+\"/g, "");

            html = html.replace(/ id=\"datagrid(\-\w*\d*)+\"/g, "");

            html = html.replace(/ datagrid-row-index=\"\d+\"/g, "");
            //#endregioin
            //#region 移除无用的样式引用

            html = html.replace(/datagrid-row-alt/g, "");
            html = html.replace(/datagrid-cell-c\d+-(\w*\d*)/g, "");
            html = html.replace(/datagrid-td-merged/g, "");
            html = html.replace(/datagrid-row/g, "");
            html = html.replace(/datagrid-cell/g, "");

            html = html.replace(/height:( )*auto;/g, "");
            html = html.replace(/ class=\"( )*\"/g, "");
            //#endregioin

            //#region 移除不显示的标签
            html = html.replace(/\Wtd style="display: none;"\W+div style=\"text-align:( )*center;\"\W+\w*\d*\W+div\W+td\W/g, "");
            html = html.replace(/\Wtd style="display: none;"\W+div style=\"text-align:( )*center;\"\W+\d+.\d+\W+div\W+td\W/g, "");
            html = html.replace(/\Wtd style="display: none;"\W+div style=\"text-align:( )*center;\"\W\d{2,4}(-|\/|年)\d{1,2}(-|\/|月)\d{1,2}( |日)*(\d{1,2}(\:|\/|\-|时)\d{1,2}(\:|\/|\-|分)\d{1,2}(\:|\/|\-|秒)*(\.\d{1,10})*)*\W+div\W+td\W/g, "");

            html = html.replace(/\Wtd style="display: none;"\W+div style=\"text-align:( )*center;\"\W+\w*\d*\W+div\W+td\W/g, "");
            html = html.replace(/\Wtd style="display: none;"\W+div style=\"text-align:( )*center;\"\W+\d+.\d+\W+div\W+td\W/g, "");
            html = html.replace(/\Wtd style="display: none;"\W+div style=\"text-align:( )*center;\"\W\d{2,4}(-|\/|年)\d{1,2}(-|\/|月)\d{1,2}( |日)*(\d{1,2}(\:|\/|\-|时)\d{1,2}(\:|\/|\-|分)\d{1,2}(\:|\/|\-|秒)*(\.\d{1,10})*)*\W+div\W+td\W/g, "");
            //#endregion

            html = html.replace(/<td/g, "<td style=\"border: 1px solid gray;\" ");
            //console.log(html);
        }
        function foo2(html) {
            var trs = $("tr", html);
            
            trs.removeAttr("id");
            trs.removeAttr("field");
            trs.removeAttr("datagrid-row-index");

            
            trs.remove(":hidden");
            trs.css("width", "").css("height","");
            $(trs).find("td").css("width","").css("height","");

            var table = $("<table></table>").append(trs);

            html = table.html();
            console.log(html);
        }
        $(document).ready(function () {
            var html = $("#table1").html();
            html = foo1(html);
            foo2(html);
            $("#table2").append(html);
            
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table id="table1">
            <tr id="datagrid-row-r1-2-0" datagrid-row-index="0" class="datagrid-row">
                <td field="NO">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-NO">1</div>
                </td>
                <td field="MaterialName">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-MaterialName">柴油</div>
                </td>
                <td field="MateriaKind">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-MateriaKind"></div>
                </td>
                <td field="MateriaType">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-MateriaType"></div>
                </td>
                <td field="Cube">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-Cube">50000</div>
                </td>
                <td field="SubTotal">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-SubTotal">50000</div>
                </td>
                <td field="UnitName">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-UnitName"></div>
                </td>
                <td field="Time" rowspan="2" colspan="1" class="datagrid-td-merged">
                    <div style="text-align: center; height: auto; width: 177px;" class="datagrid-cell datagrid-cell-c1-Time">2014-07-25</div>
                </td>
            </tr>
            <tr id="datagrid-row-r1-2-1" datagrid-row-index="1" class="datagrid-row datagrid-row-alt">
                <td field="NO" rowspan="1" colspan="5" class="datagrid-td-merged">
                    <div style="text-align: right; height: auto; width: 806px;" class="datagrid-cell datagrid-cell-c1-NO">合计：</div>
                </td>
                <td field="MaterialName" style="display: none;">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-MaterialName"></div>
                </td>
                <td field="MateriaKind" style="display: none;">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-MateriaKind"></div>
                </td>
                <td field="MateriaType" style="display: none;">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-MateriaType"></div>
                </td>
                <td field="Cube" style="display: none;">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-Cube"></div>
                </td>
                <td field="SubTotal">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-SubTotal">50000</div>
                </td>
                <td field="UnitName">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-UnitName"></div>
                </td>
                <td field="Time" style="display: none;">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-Time">2014-07-25</div>
                </td>
            </tr>
            <tr id="datagrid-row-r1-2-2" datagrid-row-index="2" class="datagrid-row">
                <td field="NO">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-NO">2</div>
                </td>
                <td field="MaterialName">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-MaterialName">循环水</div>
                </td>
                <td field="MateriaKind">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-MateriaKind"></div>
                </td>
                <td field="MateriaType">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-MateriaType"></div>
                </td>
                <td field="Cube">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-Cube">10000</div>
                </td>
                <td field="SubTotal">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-SubTotal">10000</div>
                </td>
                <td field="UnitName">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-UnitName"></div>
                </td>
                <td field="Time" rowspan="2" colspan="1" class="datagrid-td-merged">
                    <div style="text-align: center; height: auto; width: 177px;" class="datagrid-cell datagrid-cell-c1-Time">2014-07-17</div>
                </td>
            </tr>
            <tr id="datagrid-row-r1-2-3" datagrid-row-index="3" class="datagrid-row datagrid-row-alt">
                <td field="NO" rowspan="1" colspan="5" class="datagrid-td-merged">
                    <div style="text-align: right; height: auto; width: 806px;" class="datagrid-cell datagrid-cell-c1-NO">合计：</div>
                </td>
                <td field="MaterialName" style="display: none;">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-MaterialName"></div>
                </td>
                <td field="MateriaKind" style="display: none;">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-MateriaKind"></div>
                </td>
                <td field="MateriaType" style="display: none;">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-MateriaType"></div>
                </td>
                <td field="Cube" style="display: none;">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-Cube"></div>
                </td>
                <td field="SubTotal">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-SubTotal">10000</div>
                </td>
                <td field="UnitName">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-UnitName"></div>
                </td>
                <td field="Time" style="display: none;">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-Time">2014-07-17</div>
                </td>
            </tr>
            <tr id="datagrid-row-r1-2-4" datagrid-row-index="4" class="datagrid-row">
                <td field="NO">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-NO">3</div>
                </td>
                <td field="MaterialName">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-MaterialName"></div>
                </td>
                <td field="MateriaKind">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-MateriaKind"></div>
                </td>
                <td field="MateriaType">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-MateriaType"></div>
                </td>
                <td field="Cube">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-Cube">0</div>
                </td>
                <td field="SubTotal">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-SubTotal">0</div>
                </td>
                <td field="UnitName">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-UnitName"></div>
                </td>
                <td field="Time" rowspan="4" colspan="1" class="datagrid-td-merged">
                    <div style="text-align: center; height: auto; width: 177px;" class="datagrid-cell datagrid-cell-c1-Time">2014-07-16</div>
                </td>
            </tr>
            <tr id="datagrid-row-r1-2-5" datagrid-row-index="5" class="datagrid-row datagrid-row-alt">
                <td field="NO" rowspan="1" colspan="5" class="datagrid-td-merged">
                    <div style="text-align: right; height: auto; width: 806px;" class="datagrid-cell datagrid-cell-c1-NO">合计：</div>
                </td>
                <td field="MaterialName" style="display: none;">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-MaterialName"></div>
                </td>
                <td field="MateriaKind" style="display: none;">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-MateriaKind"></div>
                </td>
                <td field="MateriaType" style="display: none;">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-MateriaType"></div>
                </td>
                <td field="Cube" style="display: none;">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-Cube"></div>
                </td>
                <td field="SubTotal">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-SubTotal">0</div>
                </td>
                <td field="UnitName">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-UnitName"></div>
                </td>
                <td field="Time" style="display: none;">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-Time">2014-07-16</div>
                </td>
            </tr>
            <tr id="datagrid-row-r1-2-6" datagrid-row-index="6" class="datagrid-row">
                <td field="NO">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-NO">4</div>
                </td>
                <td field="MaterialName">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-MaterialName">循环水</div>
                </td>
                <td field="MateriaKind">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-MateriaKind"></div>
                </td>
                <td field="MateriaType">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-MateriaType"></div>
                </td>
                <td field="Cube">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-Cube">15000</div>
                </td>
                <td field="SubTotal">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-SubTotal">15000</div>
                </td>
                <td field="UnitName">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-UnitName"></div>
                </td>
                <td field="Time" style="display: none;">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-Time">2014-07-16</div>
                </td>
            </tr>
            <tr id="datagrid-row-r1-2-7" datagrid-row-index="7" class="datagrid-row datagrid-row-alt">
                <td field="NO" rowspan="1" colspan="5" class="datagrid-td-merged">
                    <div style="text-align: right; height: auto; width: 806px;" class="datagrid-cell datagrid-cell-c1-NO">合计：</div>
                </td>
                <td field="MaterialName" style="display: none;">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-MaterialName"></div>
                </td>
                <td field="MateriaKind" style="display: none;">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-MateriaKind"></div>
                </td>
                <td field="MateriaType" style="display: none;">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-MateriaType"></div>
                </td>
                <td field="Cube" style="display: none;">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-Cube"></div>
                </td>
                <td field="SubTotal">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-SubTotal">15000</div>
                </td>
                <td field="UnitName">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-UnitName"></div>
                </td>
                <td field="Time" style="display: none;">
                    <div style="text-align: center; height: auto;" class="datagrid-cell datagrid-cell-c1-Time">2014-07-16</div>
                </td>
            </tr>
        </table>
        <table id="table2"></table>
    </form>
</body>

</html>
