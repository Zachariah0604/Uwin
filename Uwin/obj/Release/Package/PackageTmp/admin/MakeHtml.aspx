<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MakeHtml.aspx.cs" Inherits="Uwin.admin.MakeHtml" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="javascript" type="text/javascript">
        function showdiv() {
            document.getElementById("bg").style.display = "block";
            document.getElementById("show").style.display = "block";
        }
        function hidediv() {
            document.getElementById("bg").style.display = 'none';
            document.getElementById("show").style.display = 'none';
        }
</script>
<style type="text/css">
        #bg{ display: none;  position: absolute;  top: 0%;  left: 0%;  width: 100%;  height: 100%;   z-index:1001;  -moz-opacity: 0.7;  opacity:.70;   filter: alpha(opacity=70);}
        #show{display: none;  position: absolute;  top: 25%;  left:40%;  width: 350px;  height: 350px;  padding: 8px;   background-color: white;  z-index:1002; text-align:center;  overflow: auto; color:red; font-size:14px; }
</style>
</head>
<body>
    <form id="form1" runat="server">
             
<div id="bg"></div>
<div id="show">
    <img src="../../images/upload.gif" /><br />
    页面生成中，请不要关闭页面
</div>
    <div>
         <br /><br />
        <asp:Button ID="AllToHtml" runat="server" Text="一键生成所有页面" OnClick="AllToHtml_Click" OnClientClick="showdiv();" /> (此选项会同时删除所有多余文件。当站内信息过多时，此项操作需要消耗一定时间，若不是大的改动，请务操作) <br /><br />
        <asp:Button ID="IndexHtml" runat="server" Text="生成首页" OnClick="IndexHtml_Click" />
        <br /><br />
        <asp:Button ID="HeaderHtml" runat="server" Text="生成网页头部" OnClick="HeaderHtml_Click" />
        <br /><br />
        <asp:Button ID="FooterHtml" runat="server" Text="生成网页底部" OnClick="FooterHtml_Click" />
        <br /><br />
        <asp:Button ID="ArticleListHtml" runat="server" Text="生成文章列表页" OnClick="ArticleListHtml_Click" />
        <br /><br />
        <asp:Button ID="VedioHtml" runat="server" Text="生成视频页面" OnClick="VedioHtml_Click" />

        <br /><br />
        <asp:Button ID="itemsHtml" runat="server" Text="生成商品列表" OnClick="itemsHtml_Click" />
        <br /><br />
        <asp:Button ID="SinglePageHtml" runat="server" Text="生成所有单页" OnClick="SinglePageHtml_Click" />
        <br /><br />
        <br /><br />
        <asp:Button ID="Delete" runat="server" Text="清理文件" OnClick="Delete_Click" />

    </div>
    </form>
</body>
</html>
