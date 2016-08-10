<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CenterIndex.aspx.cs" Inherits="Uwin.User.CenterIndex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<link href="../css/Style.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap.css" rel="stylesheet" type="text/css" />
</head>
<body style="background:#f8f8f8">
    <div class="UserIndex">
        <div class="UserWelcome">
            <div class="User">
                <div class="Userimg"><img src="" width="80px" height="80px" /></div>
                <div class="Username">欢迎您：<asp:Label ID="UserName" runat="server" Text=""></asp:Label></div>
                <div class="Userlevel">用户星级：1星级</div>
            </div>
            <div class="UsertextMenu">我的收货地址</div>
            <div class="UsertextMenu">我的优惠信息</div>
        </div>

        <div style="width:100%; margin-top:20px;">
        
				<div class="col-sm-3 ">
					<div class="stats-panel stats-blue clear">
						<div class="left"></div>
						<div class="auto stats-txt">
							<p>待付款</p>
							<p class="stats-num"><a href="#">123</a></p>
						</div>
						<a href="Orders/OrderManage.aspx" target="menuFrame" class="more clear"><span class="left">More</span> <i class="right fa fa-angle-right"></i></a>
					</div>
				</div>
				<div class="col-sm-3 ">
					<div class="stats-panel stats-red clear">
						<div class="left"></div>
						<div class="auto stats-txt">
							<p>待发货</p>
							<p class="stats-num"><a href="#">123</a></p>
						</div>
						<a href="Users/MemberManage.aspx" target="menuFrame" class="more clear"><span class="left">More</span> <i class="right fa fa-angle-right"></i></a>
					</div>
				</div>
				<div class="col-sm-3 ">
					<div class="stats-panel stats-green clear">
						<div class="left"></div>
						<div class="auto stats-txt">
							<p>待收货</p>
							<p class="stats-num"><a href="#">2</a></p>
						</div>
						<a href="Items/ItemsManage.aspx" target="menuFrame" class="more clear"><span class="left">More</span> <i class="right fa fa-angle-right"></i></a>
					</div>
				</div>
				<div class="col-sm-3 ">
					<div class="stats-panel stats-purple clear">
						<div class="left"></div>
						<div class="auto stats-txt">
							<p>待评价</p>
							<p class="stats-num"><a href="#">3</a></p>
						</div>
						<a href="ArticleManage/ActicleList.aspx"  target="menuFrame" class="more clear"><span class="left">More</span> <i class="right fa fa-angle-right"></i></a>
					</div>
				</div>
			</div>



    </div>
</body>
</html>
