<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ThrowErrorRequest.aspx.cs" Inherits="WebSample.ThrowErrorRequest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="Scripts/jquery-2.1.1.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#btnSub").click(function () {
                $.ajax({
                    url: "",
                    data: { action: 1 },
                    type: "POST",
                    dataType: "JSON",
                    success: function (data) {
                        alert("request success");
                    },
                    error: function (status, message, data) {
                        alert("request failed");
                    }
                });
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="button" id="btnSub" value="发起一个请求" />
        </div>
    </form>
</body>
</html>
