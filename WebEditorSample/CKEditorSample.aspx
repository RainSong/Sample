<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CKEditorSample.aspx.cs" Inherits="WebEditorSample.CKEditorSample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript" src="Scripts/jquery-2.1.4.js"></script>
    <script type="text/javascript" src="ckeditor_4.5.4/ckeditor.js"></script>
    <script type="text/javascript" src="ckeditor_4.5.4/ckfinder/ckfinder.js"></script>
    
    <script type="text/javascript">
        $(document).ready(function() {
           var editor = CKEDITOR.replace('txt');
            CKEDITOR.config = function(config) {
                //config.language = 'zh-cn';
                //config.filebrowserBrowseUrl = '/ckeditor_4.5.4/ckfinder/ckfinder.html'; //上传文件时浏览服务文件夹
                //config.filebrowserImageBrowseUrl = '/ckeditor_4.5.4/ckfinder/ckfinder.html?Type=Images'; //上传图片时浏览服务文件夹
                //config.filebrowserFlashBrowseUrl = '/ckeditor_4.5.4/ckfinder/ckfinder.html?Type=Flash';  //上传Flash时浏览服务文件夹
                //config.filebrowserUploadUrl = '/ckeditor_4.5.4/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files'; //上传文件按钮(标签) 
                //config.filebrowserImageUploadUrl = '/ckeditor_4.5.4/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images'; //上传图片按钮(标签) 
                //config.filebrowserFlashUploadUrl = '/ckeditor_4.5.4/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash'; //上传Flash按钮(标签)
            }

            CKFinder.setupCKEditor(editor, '/ckeditor_4.5.4/ckfinder/');
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <input type="text" id="txt"/>
    </div>
    </form>
</body>
</html>
