<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="WebFormSample.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="Scripts/jquery-2.1.0.js"></script>
    <script type="text/javascript" src="Scripts/commonCheck.js"></script>
</head>
<body>
    <table>
        <tr>
            <td>长度</td>
            <td>
                <input type="text" id="text1" filed="length" />
            </td>
        </tr>
        <tr>
            <td>不为空</td>
            <td>
                <input type="text" id="text2" filed="notNull" /></td>
        </tr>
        <tr>
            <td>邮箱</td>
            <td>
                <input type="text" id="text3" filed="email" /></td>
        </tr>
        <tr>
            <td>QQ</td>
            <td>
                <input type="text" id="text4" filed="qq" /></td>
        </tr>
        <tr>
            <td>身份证</td>
            <td>
                <input type="text" id="text5" filed="idCard" /></td>
        </tr>
        <tr>
            <td>电话</td>
            <td>
                <input type="text" id="text6" filed="phone" /></td>
        </tr>
        <tr>
            <td>手机</td>
            <td>
                <input type="text" id="text7" filed="mobilePhone" /></td>
        </tr>
    </table>
</body>
</html>
