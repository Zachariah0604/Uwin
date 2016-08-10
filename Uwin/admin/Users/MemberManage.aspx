<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberManage.aspx.cs" Inherits="Uwin.admin.Users.MemberManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户列表</title>
<link href="../css/table.css" type="text/css" rel="stylesheet" />
    <link href="../../css/PageIndex.css" type="text/css" rel="stylesheet" />
 
    <script type="text/javascript" src="../js/jquery-1.6.4.min.js"></script>
    <script type="text/javascript" src="../js/function.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
       
        <td width="100px" align="center">按用户状态查看：</td>
        <td>
            <asp:DropDownList ID="userState" runat="server" CssClass="select" 
                onselectedindexchanged="userState_SelectedIndexChanged" 
                AutoPostBack="True">
                <asp:ListItem Value="1" Text="使用中"></asp:ListItem>
                <asp:ListItem Value="0" Text="已禁用"></asp:ListItem>
            </asp:DropDownList>&nbsp;
           
        </td>
          
        </tr>
    </table>
    <div>
        <div class="navi">
            <span class="option"><a href="#">添加用户</a></span>
            <span class="posi"><b>当前位置：<asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath> </b></span>

        </div>
        <asp:Repeater runat="server" ID="UserRepeter">
            <HeaderTemplate>
            <table id="mytable" cellspacing="0" summary="The technical specifications of the Apple PowerMac G5 series">
                <caption></caption>
                
                <tr>
                    <th width="5%"><span class="btn_all" onclick="checkAll(this);">全选</span></th>
                    <th width="5%">ID</th>
                    <th width="15%">用户名</th>
                    <th width="15%">用户昵称</th>
                    <th width="5%">性别</th>
                    <th width="15%">邮箱</th>
                    <th width="10%">手机号</th>
                    <th width="5%">用户级别</th>
                     <th width="5%">会员等级</th>
                     <th width="5%">状态</th>
                     <th width="10%">创建时间</th>
                    <th width="5%">操作</th>
                </tr>
                </table>
                </HeaderTemplate>
            <ItemTemplate>
            <table id="mytable" cellspacing="2" summary="The technical specifications of the Apple PowerMac G5 series">
                <tr>
                    <td width="5%"><asp:CheckBox CssClass="checkall" ID="UserCheck" runat="server" /></td>
                    <td width="5%"><asp:Label ID="userID" runat="server" Text='<%#Eval("userID")%>'></asp:Label></td>
                     <td width="15%"><asp:Label ID="userName" runat="server" Text='<%#Eval("userName") %>'></asp:Label></td>
                    <td width="15%"><asp:Label ID="nickName" runat="server" Text='<%#Eval("nickName") %>'></asp:Label></td>
                    <td width="5"><asp:Label ID="userSex" runat="server" Text='<%#Eval("userSex") %>'></asp:Label></td>
                    <td width="15%"><asp:Label ID="userEmail" runat="server" text='<%#Eval("userEmail") %>'></asp:Label></td>
                    <td width="10%"><asp:Label ID="userTele" runat="server"  Text='<%#Eval("userTele") %>'></asp:Label></td>
                    <td width="5%"><asp:Label ID="userLevel" runat="server" Text='<%#Eval("userLevel") %>'></asp:Label></td>
                    <td width="5%"><asp:Label ID="userVipLevel" runat="server" Text='<%#Eval("userVipLevel") %>'></asp:Label></td>
                    <td width="5%"><asp:Label ID="userState" runat="server" Text='<%# Int32.Parse(Eval("userState").ToString())==1?"使用中":"X 已禁用" %>'></asp:Label></td>
                    <td width="10%"><asp:Label ID="userCreatime" runat="server" Text='<%#Eval("userCreatime") %>'></asp:Label></td>
                    <td width="5%"><asp:LinkButton Class="spebtn"  CommandName='<%#Eval("userState") %>' CommandArgument='<%#Eval("userID")%>' ID="StateBtn" oncommand="StateBtn_Command" runat="server" Text='<%# Int32.Parse(Eval("userState").ToString())==1?"禁用":"启用" %>'></asp:LinkButton></td>
                </tr>
               

            </table>
                </ItemTemplate>
            </asp:Repeater>
        <div class="btnmenu">
               
                  <asp:LinkButton ID="DelBtn" runat="server" onclick="DelBtn_Click" OnClientClick="return confirm( '确定要删除这些记录吗？ ');">批量删除</asp:LinkButton>
                 

        </div>
    </div>
        <div style=" width:95%; float:right; height:30px; margin-right:10px; margin-top:10px; text-align:right;">
                <div id="PageInfo" runat="server" class="anpager"></div>
            </div>
    </form>
</body>
</html>


