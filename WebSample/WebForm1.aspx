<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebSample.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript" src="Scripts/jquery-2.1.0.js"></script>
    <script type="text/javascript">
        //$(document).ready(function () {
        //    var html = $("#box_hid").html();
        //    $("#box").append(html);
        //});
        function showMsg() {
            alert(<% = FileName %>);
           alert(<% = Msg%>);
        } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button Text="这是一个按钮" runat="server" OnClick="Unnamed1_Click"/>
    <div id="box">
         <asp:FileUpload ID="file1" runat="server" />
            <asp:TextBox ID="txt1" runat="server" />
    </div>
        <div  style="display:none;" id="box_hid">
           
        </div>
    </form>
</body>
</html>
