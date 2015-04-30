<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="CodeGenerator._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>详细信息</title>
    <style type="text/css">
        table tr th
        {
            text-align: center;
        }
        #script
        {
            margin-top:20px;
        }
        #msgBox table, #msgBox tr, #msgBox th, #msgBox td
        {
            border-color: Gray;
            border-style: solid;
            border-width: 1px;
            border-collapse: collapse;
        }
        #treeBox
        {
            float: left;
            height: 100%;
            width: 30%;
        }
        #msgBox
        {
            float: right;
            width: 70%;
        }
        .setMargin
        {
            margin-top: 15px;
        }
        pre
        {
            word-wrap:break-word;
            line-height:1.5;
            font-size:18px;
        }
    </style>
    <script type="text/javascript" src="scripts/shCore.js"></script>
	<script type="text/javascript" src="scripts/shBrushSql.js"></script>
	<link type="text/css" rel="stylesheet" href="styles/shCore.css"/>
	<link type="text/css" rel="stylesheet" href="styles/shThemeDefault.css"/>
	<script type="text/javascript">
	    SyntaxHighlighter.config.clipboardSwf = 'scripts/clipboard.swf';
	    SyntaxHighlighter.all();
	</script>
    
</head>
<body >
    <form id="form1" runat="server">
    <div>
        <div id="treeBox">
            <p><a href="index.aspx">重新连接</a></p>
            <asp:TreeView ID="TreeView1" runat="server" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged"
                OnTreeNodeExpanded="TreeView1_TreeNodeExpanded" ShowLines="True">
            </asp:TreeView>
        </div>
        <div id="msgBox">
            <asp:Label ID="labProperies" runat="server" Font-Bold="true"></asp:Label>
            <asp:Repeater ID="RepeaterProperies" runat="server">
                <HeaderTemplate>
                    <table>
                        <tr>
                            <th>
                                属性
                            </th>
                            <th>
                                值
                            </th>
                        </tr>
                    </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <%#Eval("Property")%>
                        </td>
                        <td>
                            <%#Eval("Value")%>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <asp:Repeater ID="RepeaterColumns" runat="server">
                <HeaderTemplate>
                    <table>
                        <br />
                        <thead>
                            <b>列</b>
                        </thead>
                        <tr>
                            <th>
                                列名
                            </th>
                            <th>
                                数据类型
                            </th>
                            <th>
                                最大长度（字节）
                            </th>
                            <th>
                                是否可空
                            </th>
                            <th>
                                说明
                            </th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <%# Eval("Name")%>
                        </td>
                        <td>
                            <%# Eval("DataType")%>
                        </td>
                        <td>
                            <%# Eval("MaxLength")%>
                        </td>
                        <td>
                            <%# Eval("AllowNull")%>
                        </td>
                        <td>
                            <%# Eval("Des")%>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <asp:Repeater ID="RepeaterIndexes" runat="server">
                <HeaderTemplate>
                    <table>
                        <br />
                        <thead>
                            <b>索引</b>
                        </thead>
                        <tr>
                            <th>
                                名称
                            </th>
                            <th>
                                相关列
                            </th>
                            <th>
                                是否唯一
                            </th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <%#Eval("Name") %>
                        </td>
                        <td>
                            <%#Eval("Columns") %>
                        </td>
                        <td>
                            <%#Eval("Unique") %>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <asp:Repeater ID="RepeaterKeys" runat="server">
                <HeaderTemplate>
                    <table>
                        <br />
                        <thead>
                            <b>外键</b>
                        </thead>
                        <tr>
                            <th>
                                键名称
                            </th>
                            <th>
                                操作
                            </th>
                            <th>
                                相关列
                            </th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <%#Eval("name")%>
                        </td>
                        <td>
                            <%#Eval("execute")%>
                        </td>
                        <td>
                            <%#Eval("pertinentCol")%>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <asp:Repeater ID="RepeaterParameters" runat="server">
                <HeaderTemplate>
                    <table>
                        <br />
                        <thead>
                            <b>参数</b>
                        </thead>
                        <tr>
                            <th>
                                名称
                            </th>
                            <th>
                                数据类型
                            </th>
                            <th>
                                最大长度
                            </th>
                            <th>
                                输入输入
                            </th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <%#Eval("name")%>
                        </td>
                        <td>
                            <%#Eval("dataType")%>
                        </td>
                        <td>
                            <%#Eval("maxLength")%>
                        </td>
                        <td>
                            <%#Eval("inOrOut")%>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <asp:Repeater ID="RepeaterFunPara" runat="server">
                <HeaderTemplate>
                    <table>
                        <br />
                        <thead>
                            <b>参数</b>
                        </thead>
                        <tr>
                            <th>
                                名称
                            </th>
                            <th>
                                数据类型
                            </th>
                            <th>
                                最大长度
                            </th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <%#Eval("name")%>
                        </td>
                        <td>
                            <%#Eval("dataType")%>
                        </td>
                        <td>
                            <%#Eval("maxLength")%>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <div id="script">
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            </div>
            
        </div>
    </div>
    </form>
    
</body>
</html>
