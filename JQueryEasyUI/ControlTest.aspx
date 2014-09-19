<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ControlTest.aspx.cs" Inherits="JQueryEasyUI.ControlTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="Scripts/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="Scripts/jquery.easyui-1.3.6.js"></script>
    <script type="text/javascript" src="Scripts/common.js"></script>
    <link rel="stylesheet" type="text/css" href="Content/themes/default/easyui.css" />
</head>
<body>
    <label for="text1">多选下拉框</label><input type="text" id="text1" />
    <label for="text2">下拉树</label><input type="text" id="text2" />
</body>
<script type="text/javascript">
    function initMultiableSelectCombobox() {
        var options = {
            valueField: 'id',
            textField: 'name',
            editable: false,
            multiple: true,
            width: 150,
            panelHeight: 100,
            data: [{ id: 0, name: 'item1' }, { id: 1, name: 'item2' }, { id: 2, name: 'item3' }],
            onHidePanel: function () {
                var text = $('#text1').combobox('getText');
                if (!text || text.length == 0) text = 'do not select any one';
                $.messager.alert('Message', text);
            }
        };
        $('#text1').combobox(options);
    }
    function initComboboxTree() { }
    $(document).ready(function () {
        initMultiableSelectCombobox();
        initComboboxTree();
    });
</script>
</html>
