<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleManage.aspx.cs" Inherits="Uwin.admin.StationManage.RoleManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/table.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../js/jquery.pagination.js"></script>
    <script type="text/javascript" src="../js/jquery-1.6.4.min.js"></script>
    <script type="text/javascript" src="../js/function.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="navi"><span class="option"></span><span class="posi"><b>当前位置：<asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath> </b></span></div>
        <asp:Repeater runat="server" ID="RoleRepeter">
            <HeaderTemplate>
            <table id="mytable" cellspacing="0" summary="The technical specifications of the Apple PowerMac G5 series">
                <caption></caption>
                
                <tr>
                    <th width="30%"><span class="btn_all" onclick="checkAll(this);">全选</span></th>
                    <th width="30%">ID</th>
                    <th width="40%">管理角色</th>
                </tr>
                </table>
                </HeaderTemplate>
            <ItemTemplate>
            <table id="mytable" cellspacing="2" summary="The technical specifications of the Apple PowerMac G5 series">
                <tr>
                    <td width="30%"><asp:CheckBox CssClass="checkall" ID="stationCheck" runat="server" /></td>
                    <td width="30%"><asp:Label ID="staid" runat="server" Text='<%#Eval("rolid")%>'></asp:Label></td>
                     <td width="40%"><asp:Label ID="station" runat="server" Text='<%#Eval("RoleName") %>'></asp:Label></td>
                    
                </tr>
               

            </table>
                </ItemTemplate>
            </asp:Repeater>
        <div class="btnmenu">
               
                 
                 

        </div>
    </div>
    </form>
</body>
</html>
