<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActicleList.aspx.cs" Inherits="Uwin.admin.ArticleManage.ActicleList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>文章管理</title>
 <link href="../css/table.css" type="text/css" rel="stylesheet" />
    <link href="../../css/PageIndex.css" type="text/css" rel="stylesheet" />
 
    <script type="text/javascript" src="../js/jquery-1.6.4.min.js"></script>
    <script type="text/javascript" src="../js/function.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="50" align="center">请选择：</td>
        <td>
            <asp:DropDownList ID="Type" runat="server" CssClass="select" 
                onselectedindexchanged="Type_SelectedIndexChanged" 
                AutoPostBack="True"></asp:DropDownList>&nbsp;
           
        </td>
        
        </tr>
    </table>
    <div>
        <div class="navi"><span class="option"><a href="AddActicle.aspx">发布文章</a></span><span class="posi"><b>当前位置：<asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath> </b></span></div>
        <asp:Repeater runat="server" ID="ArticleRepeter">
            <HeaderTemplate>
            <table id="mytable" cellspacing="0" summary="The technical specifications of the Apple PowerMac G5 series">
                <caption></caption>
                
                <tr>
                    <th width="10%"><span class="btn_all" onclick="checkAll(this);">全选</span></th>
                    <th width="10%">ID</th>
                    <th width="30%">文章标题</th>
                    <th width="10%">所属分类</th>
                    <th width="10%">作者</th>
                    <th width="10%">点击数</th>
                    <th width="10%">创建时间</th>
                    <th width="10%">操作</th>
                </tr>
                </table>
                </HeaderTemplate>
            <ItemTemplate>
            <table id="mytable" cellspacing="2" summary="The technical specifications of the Apple PowerMac G5 series">
                <tr>
                    <td width="10%"><asp:CheckBox CssClass="checkall" ID="ArticleCheck" runat="server" /></td>
                    <td width="10%"><asp:Label ID="NewsId" runat="server" Text='<%#Eval("NewsId")%>'></asp:Label></td>
                     <td width="30%"><asp:Label ID="NewsTitle" runat="server" Text='<%#Eval("Title") %>'></asp:Label></td>
                    <td width="10%"><asp:Label ID="TypeId" runat="server" Text='<%#Eval("TypeName") %>'></asp:Label></td>
                    <td width="10%"><asp:Label ID="Author" runat="server" Text='<%#Eval("Author") %>'></asp:Label></td>
                    <td width="10%"><asp:Label ID="Click" runat="server" text='<%#Eval("Click") %>'></asp:Label></td>
                    <td width="10%"><asp:Label ID="CreateTime" runat="server" Text='<%#Eval("CreateTime") %>'></asp:Label></td>
                    <td width="10%"><a href="EditArticle.aspx?NewsId=<%#Eval("NewsId") %>">编辑</a></td>
                </tr>
               

            </table>
                </ItemTemplate>
            </asp:Repeater>
        <div class="btnmenu">
               
                  <asp:LinkButton ID="DelBtn" runat="server" onclick="DelBtn_Click" OnClientClick="return confirm( '确定要删除这些记录吗？ ');">批量删除</asp:LinkButton>

            &nbsp;&nbsp;&nbsp;<asp:LinkButton ID="ToHtml" runat="server" onclick="ToHtml_Click" >批量生成文章内容页</asp:LinkButton>&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="AllToHtml" runat="server" onclick="AllToHtml_Click" >一键生成所有文章内容页</asp:LinkButton>
                 

        </div>
    </div>
        <div style=" width:95%; float:right; height:30px; margin-right:10px; margin-top:10px; text-align:right;">
                <div id="PageInfo" runat="server" class="anpager"></div>
            </div>
    </form>
</body>
</html>

