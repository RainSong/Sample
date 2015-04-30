<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DatabasesPage.aspx.cs" Inherits="CodeGenerator.DatabasesPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        #tarDBSBox
        {
            float: left;
        }
    </style>
    <script type="text/javascript" language="javascript">
        function showDbs(isShow) {
//            var box = document.getElementById("dbsBox");
//            var link = document.getElementById("recheck");
//            if (isShow) {
//                box.style.display = "block";
//                link.style.display = "none";
//            }
//            else {
//                box.style.display = "none";
//                link.style.display = "block";
//            }
        }
        function checkSelect() {

            var tra = document.getElementsByName("tarDBS");
            var sour = document.getElementsByName("sourDBS");
            var traSelect = false;
            var sourSelect = false;
            for (i = 0; i < tra.length; i++) {
                if (tra[i].checked == true) {
                    traSelect = true;
                 }
            }
            for (i = 0; i < sour.length; i++) {
                if (sour[i].checked == true) {
                    sourSelect = true;
                 }
            }
            if (!traSelect) {
                alert("请在目标服务器中选择要对比的数据库");
                return false;
            }
            else {
                if (!sourSelect) {
                    alert("请在源服务器中选择要对比的数据库");
                    return false;
                }
            }

         }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <a href="index.aspx">重新连接</a>
         <a id="recheck" onclick="showDbs(true);" href="#" style="display: none;">重新选择数据库</a>
        <div id="dbsBox">
            <p>
                选择数据库</p>
            <div id="tarDBSBox">
                目标服务器<br />
                <asp:RadioButtonList ID="tarDBS" runat="server">
                </asp:RadioButtonList>
            </div>
            <div id="sourDBSBox">
                源服务器<br />
                <asp:RadioButtonList ID="sourDBS" runat="server">
                </asp:RadioButtonList>
            </div>
            <p>
                <asp:Button ID="btnComparison" Text="对比" runat="server" 
                OnClientClick="return checkSelect(); " onclick="btnComparison_Click"/>
            </p>
        </div>
    </div>
    </form>
</body>
</html>
