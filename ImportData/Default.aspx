<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ImportData._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="Scripts/jquery-2.0.3.js"></script>
    <script type="text/javascript" src="Scripts/jquery-ui-1.10.3.js"></script>
    <script type="text/javascript" src="Scripts/jquery.uploadify.js"></script>
    <link type="text/css" rel="Stylesheet" href="Content/uploadfiy/uploadify.css" />
    <link type="text/css" rel="Stylesheet" href="Content/themes/base/jquery-ui.css" />
    <script type="text/javascript">


        $(function () {
            $("#btnDownload").button();

            $("#btnUpload").uploadify({
                method: 'GET',
                formData: { 'FileOverrideName': 'abc' },
                fileExt: '*.xls',
                swf: '/Content/uploadfiy/uploadify.swf',
                uploader: 'UploadHandler.ashx',
                buttonText: '上传文件',
                queueID: 'fileQueue'
            });
            $("#btnUpload-button").button();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Button runat="server" Text="下载文件" ID="btnDownload" OnClick="btnDownload_Click" /></td>
                    <td>
                        <input type="button" value="上传文件" id="btnUpload" /></td>
                </tr>
            </table>
            <div id="fileQueue"></div>
            <div id="rowSelect" style="display: none;">
            </div>
            <div id="dataContainer" style="display: none;"></div>
        </div>
    </form>
</body>
</html>
