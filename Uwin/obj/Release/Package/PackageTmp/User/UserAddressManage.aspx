<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserAddressManage.aspx.cs" Inherits="Uwin.User.UserAddressManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>收货地址管理</title>
    <link href="../css/table.css" type="text/css" rel="stylesheet" />
    <link href="../css/PageIndex.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../js/jquery-1.6.4.min.js"></script>
    <script type="text/javascript" src="../js/function.js"></script>
</head>
<body style="background-color:#fff;">
    <iframe src="UserAddressAdd.aspx" width="100%" frameborder="0" height="350px" scrolling="no"></iframe>
        <form id="form1" runat="server">
   <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        
        <td>
           
           
        </td>
        
        </tr>
    </table>
    <div style="background-color:#fff;">
        <div class="navi"><span class="option"><a href="AddActicle.aspx">我的收货地址</a></span></div>
        <asp:Repeater runat="server" ID="UserAddressRepeter">
            <HeaderTemplate>
            <table id="mytable" cellspacing="0" summary="The technical specifications of the Apple PowerMac G5 series">
                <caption></caption>
                
                <tr>
                    <th width="10%"><span class="btn_all" onclick="checkAll(this);">全选</span></th>
                    <th width="15%">收货人</th>
                    <th width="20%">所在地区</th>
                    <th width="30%">详细地址</th>
                    <th width="10%">电话/手机</th>
                    <th width="15%">操作</th>
                </tr>
                </table>
                </HeaderTemplate>
            <ItemTemplate>
            <table id="mytable" cellspacing="2" summary="The technical specifications of the Apple PowerMac G5 series">
                <tr>
                    <td width="10%"><asp:CheckBox CssClass="checkall" ID="UserAddressCheck" runat="server" /><asp:Label ID="id" Visible="false" runat="server" Text='<%#Eval("id")%>'></asp:Label></td>
                     <td width="15%"><asp:Label ID="ReceUser" runat="server" Text='<%#Eval("ReceUser") %>'></asp:Label></td>
                    <td width="20%"><asp:Label ID="ReceArea" runat="server" Text='<%#Eval("ReceArea") %>'></asp:Label></td>
                    <td width="30%"><asp:Label ID="ReceAddress" runat="server" Text='<%#Eval("ReceAddress") %>'></asp:Label></td>
                    <td width="10%"><asp:Label ID="ReceTele" runat="server" text='<%#Eval("ReceTele") %>'></asp:Label></td>
                    <td width="15%"><a href="UserAddressEdit.aspx?id=<%#Eval("id") %>">修改</a></td>
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
