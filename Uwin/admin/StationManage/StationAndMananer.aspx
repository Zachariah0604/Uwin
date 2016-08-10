<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StationAndMananer.aspx.cs" Inherits="Uwin.admin.StationManage.StationAndMananer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理员列表</title>
    <link href="../css/table.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../js/jquery.pagination.js"></script>
    <script type="text/javascript" src="../js/jquery-1.6.4.min.js"></script>
    <script type="text/javascript" src="../js/function.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="navi"><span class="option"><a href="AddManager.aspx">增加管理员</a></span><span class="posi"><b>当前位置：<asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath> </b></span></div>
        <asp:Repeater runat="server" ID="adminRepeter">
            <HeaderTemplate>
            <table id="mytable" cellspacing="0" summary="The technical specifications of the Apple PowerMac G5 series">
                <caption></caption>
                
                <tr>
                    <th width="10%"><span class="btn_all" onclick="checkAll(this);">全选</span></th>
                    <th width="10%">ID</th>
                    <th width="10%">所属分站</th>
                    <th width="10%">管理帐号</th>
                    <th width="10%">联系方式</th>
                    <th width="10%">电子邮件</th>
                    <th width="10%">管理员角色</th>
                    <th width="20%">创建时间</th>
                    <th width="10%">操作</th>
                </tr>
                </table>
                </HeaderTemplate>
            <ItemTemplate>
            <table id="mytable" cellspacing="2" summary="The technical specifications of the Apple PowerMac G5 series">
                <tr>
                    <td width="10%"><asp:CheckBox CssClass="checkall" ID="adminCheck" runat="server" /></td>
                    <td width="10%"><asp:Label ID="adminID" runat="server" Text='<%#Eval("id")%>'></asp:Label></td>
                     <td width="10%"><asp:Label ID="station" runat="server" Text='<%#Eval("station") %>'></asp:Label></td>
                    <td width="10%"><asp:Label ID="adminName" runat="server" Text='<%#Eval("name") %>'></asp:Label></td>
                    <td width="10%"><asp:Label ID="telephone" runat="server" Text='<%#Eval("telephone") %>'></asp:Label></td>
                    <td width="10%"><asp:Label ID="email" runat="server" Text='<%#Eval("email") %>'></asp:Label></td>
                    <td width="10%"><asp:Label ID="adminRole" runat="server" Text='<%#Eval("RoleName") %>'></asp:Label></td>
                    <td width="20%"><asp:Label ID="creatime" runat="server" text='<%#Eval("creatime") %>'></asp:Label></td>
                    <td width="10%"><a href="EditManager.aspx?id=<%#Eval("id") %>">编辑</a></td>
                </tr>
               

            </table>
                </ItemTemplate>
            </asp:Repeater>
        <div class="btnmenu">
               
                  <asp:LinkButton ID="DelBtn" runat="server" onclick="DelBtn_Click" OnClientClick="return confirm( '确定要删除这些记录吗？ ');">批量删除</asp:LinkButton>
                 

        </div>
    </div>
    </form>
</body>
</html>
