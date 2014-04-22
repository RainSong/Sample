<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebSample.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="Scripts/jquery-2.1.0.js"></script>
    <script type="text/javascript">
        alert("page load");
        $(document).ready(function () {
            $("#btn").click(function () {
                jQuery.ajax({
                    url: "WebForm2.aspx/SaveFile",
                    type: "POST",
                    success: function (data) {
                        var msg = $("#txtRemark").val();
                        if (!msg || msg.length == "") {
                            alert("msg is empty<br/>+file" + data);
                        }
                        else {
                            alert(msg + "<br/> file:" + data);
                        }
                    }
                });
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>附件</td>
                    <td>
                        <asp:FileUpload ID="file1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>备注</td>
                    <td>
                        <input type="text" id="txtRemark" /></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <input type="button" value="OK" id="btn" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
