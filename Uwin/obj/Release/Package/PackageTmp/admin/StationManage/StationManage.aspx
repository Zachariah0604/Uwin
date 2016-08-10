<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StationManage.aspx.cs" Inherits="Uwin.admin.StationManage.StationManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>分站列表</title>
    <link href="../css/table.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../js/jquery.pagination.js"></script>
    <script type="text/javascript" src="../js/jquery-1.6.4.min.js"></script>
    <script type="text/javascript" src="../js/function.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="navi"><span class="option"><a href="AddStation.aspx">增加分站</a></span><span class="posi"><b>当前位置：<asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath> </b></span></div>
        <asp:Repeater runat="server" ID="stationRepeter">
            <HeaderTemplate>
            <table id="mytable" cellspacing="0" summary="The technical specifications of the Apple PowerMac G5 series">
                <caption></caption>
                
                <tr>
                    <th width="20%"><span class="btn_all" onclick="checkAll(this);">全选</span></th>
                    <th width="20%">ID</th>
                    <th width="20%">分站名称</th>
                    <th width="20%">管理角色</th>
                    <th width="20%">操作</th>
                </tr>
                </table>
                </HeaderTemplate>
            <ItemTemplate>
            <table id="mytable" cellspacing="2" summary="The technical specifications of the Apple PowerMac G5 series">
                <tr>
                    <td width="20%"><asp:CheckBox CssClass="checkall" ID="stationCheck" runat="server" /></td>
                    <td width="20%"><asp:Label ID="staid" runat="server" Text='<%#Eval("staid")%>'></asp:Label></td>
                     <td width="20%"><asp:Label ID="station" runat="server" Text='<%#Eval("station") %>'></asp:Label></td>
                    <td width="20%"><asp:Label ID="adminRole" runat="server" Text='<%#Eval("roleId") %>'></asp:Label></td>
                    <td width="20%"><a href="EditStation.aspx?staid=<%#Eval("staid") %>">编辑</a></td>
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
