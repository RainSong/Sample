<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CodeGenerator.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>连接服务器</title>
    <style type="text/css">
        .setLocation
        {
            margin-top: 200px;
            margin-right: 200px;
            float: right;
        }
        #Comparison
        {
            margin-top: 200px;
            margin-left: 200px;
            float: left;
            display:none;
        }
        #Source
        {
            margin-top: 25px;
        }
    </style>
    <script type="text/javascript" language="javascript">
        function connect() {
            var ser = document.getElementById("txtSerName");
            var uname = document.getElementById("txtUName");
            var upwd = document.getElementById("txtUpwd");
            if (ser.value == "") {
                alert("请输入服务器名称！");
                return false;
            }
            if (uname.value == "") {
                alert("请输入用户名！");
                return false;
            }
            if (upwd.value == "") {
                alert("请输入密码！");
                return false;
            }
        }
        function showBox(isShowLog) {
            var comBox = document.getElementById("Comparison");
            var logIn = document.getElementById("logIn");
            if (isShowLog) {
                comBox.style.display = "none";
                logIn.style.display = "block";
            }
            else {
                comBox.style.display = "block";
                logIn.style.display = "none";
             }
            
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="Height">
        <%--<a href="#" onclick="showBox(false);">对比</a> 
        <a href="#" onclick="showBox(true);">查看详细</a>--%>
    </div>
    <div id="Contianer">
        <div id="Comparison">
            <div id="Target">
                <table>
                    <thead>
                        目标服务器</thead>
                    <tr>
                        <td>
                            服务器
                        </td>
                        <td>
                            <asp:TextBox ID="txtTarServer" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            用户名
                        </td>
                        <td>
                            <asp:TextBox ID="txtTarUid" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            密码
                        </td>
                        <td>
                            <asp:TextBox ID="txtTarPwd" runat="server" TextMode="Password">
                            </asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="Source">
                <table>
                    <thead>
                        源服务器
                        </thead>
                    <tr>
                        <td>
                            服务器
                        </td>
                        <td>
                            <asp:TextBox ID="txgSourName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            用户名
                        </td>
                        <td>
                            <asp:TextBox ID="txtSourUid" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            密码
                        </td>
                        <td>
                            <asp:TextBox ID="txtSourPwd" runat="server" TextMode="Password">
                            </asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <asp:Button ID="btnComparison" Text="对比" runat="server" 
                onclick="btnComparison_Click" />
        </div>
        <div id="logIn" class="setLocation">
            <table>
                <tr>
                    <td>
                        服务器
                    </td>
                    <td>
                        <asp:TextBox ID="txtSerName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        用户名
                    </td>
                    <td>
                        <asp:TextBox ID="txtUName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        密码
                    </td>
                    <td>
                        <asp:TextBox ID="txtUpwd" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnConnect" runat="server" Text="连接" OnClick="btnConnect_Click" OnClientClick="return connect();" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
