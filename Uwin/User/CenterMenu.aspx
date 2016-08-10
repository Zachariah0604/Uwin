<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CenterMenu.aspx.cs" Inherits="Uwin.User.CenterMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<link href="../css/Style.css" rel="stylesheet" type="text/css" />
<script src="../js/jquery.min.js"></script>
<script src="../js/menu.js"></script>
</head>
<body>
    <div class="menu">
        <ul>
			<li><A class="hover" href="CenterIndex.aspx" target="body">我的主页</A></li>
            <li><A href="UserOrder.aspx" target="body">我的订单</A></li>
			<li><A href="#">我的购物车</A></li>
			<li><A href="UserInfo.aspx" target="body">个人信息</A></li>
            <li><A href="UserEdit.aspx" target="body">修改密码</A></li>
			<li><A href="UserAddressManage.aspx" target="body">我的地址</A></li>
			<li><A href="#">我要反馈</A></li>
			<div id="lanPos"></div>
		</ul>
    </div>
</body>
</html>
