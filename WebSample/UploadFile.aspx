<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadFile.aspx.cs" Inherits="WebFormSample.UploadFile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript">
        function btnBrowerClick() {
            document.getElementById("fileUpload").click();
        }
        function fileChange(obj) {
            var file = obj.value;
            document.getElementById("txt").value = file;
        }
    </script>
    <style type="text/css">
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <input type="text" id="txt" readonly="readonly"/>
                <input type="button" value="浏览..." onclick="btnBrowerClick();" /><input type="button" value="查看" />
            </div>
            <asp:FileUpload style="display:none;" ID="fileUpload" runat="server" onchange="fileChange(this);"/>
        </div>
    </form>
</body>
</html>
