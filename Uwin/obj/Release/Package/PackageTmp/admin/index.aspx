<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Uwin.admin.index" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml"><head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>后台管理</title>

<link rel="stylesheet" href="css/index.css" type="text/css" media="screen" />

<script type="text/javascript" src="js/jquery.js"></script>
<script type="text/javascript" src="js/tendina.js"></script>
<script type="text/javascript" src="js/common.js"></script>

</head>
<body>
  
    <div class="layout_top_header">
            <div style="float: left"><span style="font-size: 16px;line-height: 45px;padding-left: 20px;color: #8d8d8d">管理后台</span></div>
            <div id="ad_setting" class="ad_setting">
                <a class="ad_setting_a" href="javascript:;">
                    <i class="icon-user glyph-icon" style="font-size: 20px"></i>
                    <span>
                        <asp:Label ID="AdminName" runat="server" Text="Label"></asp:Label></span>
                    <i class="icon-chevron-down glyph-icon"></i>
                </a>
                <ul class="dropdown-menu-uu" style="display: none" id="ad_setting_ul">
                    <li class="ad_setting_ul_li"> <a href="StationManage/EditManager.aspx?id=1" target="menuFrame"><i class="icon-user glyph-icon"></i> 修改信息 </a> </li>
                    <li class="ad_setting_ul_li"> <a href="Statistics/SystemInfoSta.aspx" target="menuFrame"><i class="icon-cog glyph-icon"></i> 系统信息 </a> </li>
                    <li class="ad_setting_ul_li"><form id="form1" runat="server"><i class="icon-signout glyph-icon"></i><asp:LinkButton ID="LoginOut" OnClick="LoginOut_Click" runat="server" class="font-bold">退出</asp:LinkButton></form>
                       </li>
                </ul>
            </div>
    </div>
  
    <div class="layout_left_menu">
        <ul class="tendina" id="menu">
             <li class="childUlLi">
               <a href="#" target="menuFrame"><i class="glyph-icon icon-home"></i>页面</a>
                 <ul style="display: none;">
                     <li><a href="MakeHtml.aspx" target="menuFrame"><i class="glyph-icon icon-chevron-right"></i>页面生成</a></li>
                    <li><a href="../index.shtml" target="_blank"><i class="glyph-icon icon-chevron-right"></i>前台首页</a></li>
                    <li><a href="admin.aspx" target="menuFrame"><i class="glyph-icon icon-chevron-right"></i>后台首页</a></li>
               
                </ul>
            </li>
            <li class="childUlLi">
                <a href="#" target="menuFrame"> <i class="glyph-icon icon-reorder"></i>管理员&分站管理</a>
                <ul style="display: none;">

                    
                    <li><a href="StationManage/StationManage.aspx" target="menuFrame"><i class="glyph-icon icon-chevron-right"></i>分站管理</a></li>
                    <li><a href="StationManage/AddStation.aspx" target="menuFrame"><i class="glyph-icon icon-chevron-right"></i>增加分站</a></li>
                    <li><a href="StationManage/StationAndMananer.aspx" target="menuFrame"><i class="glyph-icon icon-chevron-right"></i>管理员列表</a></li>
                    <li><a href="StationManage/AddManager.aspx" target="menuFrame"><i class="glyph-icon icon-chevron-right"></i>添加管理员</a></li>
                    <li><a href="StationManage/RoleManage.aspx" target="menuFrame"><i class="glyph-icon icon-chevron-right"></i>角色管理</a></li>
                    
               
                </ul>
            </li>
             <li class="childUlLi">
                <a href="#" target="menuFrame"> <i class="glyph-icon icon-reorder"></i>文章管理</a>
                <ul style="display: none;">

                    
                    <li><a href="ArticleManage/ActicleList.aspx" target="menuFrame"><i class="glyph-icon icon-chevron-right"></i>文章列表</a></li>
                    <li><a href="ArticleManage/AddArticle.aspx" target="menuFrame"><i class="glyph-icon icon-chevron-right"></i>发布新闻</a></li>
                    <li><a href="ArticleManage/TypeManage.aspx" target="menuFrame"><i class="glyph-icon icon-chevron-right"></i>文章分类管理</a></li>
                    <li><a href="ArticleManage/AddType.aspx" target="menuFrame"><i class="glyph-icon icon-chevron-right"></i>添加文章分类</a></li>
                    
               
                </ul>
            </li>
            <li class="childUlLi">
                <a href="#" target="menuFrame"> <i class="glyph-icon icon-reorder"></i>广告管理</a>
                <ul style="display: none;">
                    <li><a href="Ad/BannerManage.aspx" target="menuFrame"><i class="glyph-icon icon-chevron-right"></i>Banner图</a></li>
                    
                    <li><a href="Ad/WapAD.aspx" target="menuFrame"><i class="glyph-icon icon-chevron-right"></i>wap站第一广告位</a></li>
                    <li><a href="Ad/WapVideo.aspx" target="menuFrame"><i class="glyph-icon icon-chevron-right"></i>视频管理</a></li>
                  
                    
               
                </ul>
            </li>
             <li class="childUlLi">
                <a href="#" target="menuFrame"> <i class="glyph-icon icon-reorder"></i>商品管理</a>
                <ul style="display: none;">
                    <li><a href="Items/AddItem.aspx" target="menuFrame"><i class="glyph-icon icon-chevron-right"></i>添加商品</a></li>
                     <li><a href="Items/ItemsManage.aspx" target="menuFrame"><i class="glyph-icon icon-chevron-right"></i>商品管理</a></li>
                    <li><a href="Items/ItemsTrialManage.aspx" target="menuFrame"><i class="glyph-icon icon-chevron-right"></i>商品试用管理</a></li>
                    <li><a href="Items/ItemsSecManage.aspx" target="menuFrame"><i class="glyph-icon icon-chevron-right"></i>商品秒杀管理</a></li>
                    <li><a href="Items/TypeManage.aspx" target="menuFrame"><i class="glyph-icon icon-chevron-right"></i>商品分类管理</a></li>
                    <li><a href="Items/AddSubType.aspx" target="menuFrame"><i class="glyph-icon icon-chevron-right"></i>添加商品子类</a></li>
                 
                    
               
                </ul>
            </li>
             <li class="childUlLi">
                <a href="Users/MemberManage.aspx" target="menuFrame"> <i class="glyph-icon icon-reorder"></i>用户管理</a>
               
            </li>
           <li class="childUlLi">
                <a href="Merchant/MerchantManage.aspx" target="menuFrame"> <i class="glyph-icon icon-reorder"></i>商户管理</a>
               
            </li>
            <li class="childUlLi">
                <a href="#" target="menuFrame"> <i class="glyph-icon icon-reorder"></i>订单管理</a>
                <ul style="display: none;">
                    <li><a href="Orders/OrderManage.aspx" target="menuFrame"><i class="glyph-icon icon-chevron-right"></i>商品订单管理</a></li>
                     <li><a href="Orders/OrderTriManage.aspx" target="menuFrame"><i class="glyph-icon icon-chevron-right"></i>试用订单管理</a></li>
                    <li><a href="Orders/ToBeRefunded.aspx" target="menuFrame"><i class="glyph-icon icon-chevron-right"></i>待退款订单</a></li>
                    
                 
                    
               
                </ul>
            </li>
            <li class="childUlLi">
                <a href="#" target="menuFrame"> <i class="glyph-icon icon-reorder"></i>资源管理</a>
                <ul style="display: none;">
                    <li><a href="Resorces/BrandManage.aspx" target="menuFrame"><i class="glyph-icon icon-chevron-right"></i>品牌管理</a></li>
                     <li><a href="Resorces/ExpressManage.aspx" target="menuFrame"><i class="glyph-icon icon-chevron-right"></i>快递管理</a></li>
                    
                    <li><a href="Resorces/ActivityManage.aspx" target="menuFrame"><i class="glyph-icon icon-chevron-right"></i>活动管理</a></li>
                   
                    <li><a href="Resorces/QRCodeManage.aspx" target="menuFrame"><i class="glyph-icon icon-chevron-right"></i>二维码管理</a></li>
                    <li><a href="Resorces/CityMange/Province.aspx" target="menuFrame"><i class="glyph-icon icon-chevron-right"></i>城市管理</a></li>
                    
                 </ul>
            </li>
            <li class="childUlLi">
                <a href="#" target="menuFrame"> <i class="glyph-icon icon-reorder"></i>单页管理</a>
                <ul style="display: none;">
                    <li><a href="SinglePage/HelpCenter.aspx" target="menuFrame"><i class="glyph-icon icon-chevron-right"></i>帮助中心</a></li>
                     <li><a href="SinglePage/AboutMarket.aspx" target="menuFrame"><i class="glyph-icon icon-chevron-right"></i>关于市场</a></li>
                    
                    <li><a href="SinglePage/JoinUs.aspx" target="menuFrame"><i class="glyph-icon icon-chevron-right"></i>加入我们</a></li>
                   
                    <li><a href="SinglePage/AboutUs.aspx" target="menuFrame"><i class="glyph-icon icon-chevron-right"></i>关于公司</a></li>
                    
                 </ul>
            </li>
            <li class="childUlLi">
                <a href="#" target="menuFrame"> <i class="glyph-icon icon-reorder"></i>统计报表</a>
                <ul style="display: none;">
                    <li><a href="Statistics/OrderSta.aspx" target="menuFrame"><i class="glyph-icon icon-chevron-right"></i>订单统计报表</a></li>
                    
                    
                    <li><a href="Statistics/UserInfo.aspx" target="menuFrame"><i class="glyph-icon icon-chevron-right"></i>用户信息统计</a></li>
                    <li><a href="Statistics/MerchantInfo.aspx" target="menuFrame"><i class="glyph-icon icon-chevron-right"></i>商户信息统计</a></li>
                    <li><a href="Statistics/ItemsInfo.aspx" target="menuFrame"><i class="glyph-icon icon-chevron-right"></i>商品信息统计</a></li>
                    <li><a href="Statistics/StationInfo.aspx" target="menuFrame"><i class="glyph-icon icon-chevron-right"></i>分站信息统计</a></li>
                    
                    <li><a href="Statistics/SystemInfoSta.aspx" target="menuFrame"><i class="glyph-icon icon-chevron-right"></i>系统信息</a></li>
                    
                 </ul>
            </li>
        </ul>
    </div>
   
    <div id="layout_right_content" class="layout_right_content">
        <div class="route_bg">
            <a href="#">主页</a><i class="glyph-icon icon-chevron-right"></i>
            <a href="#">菜单管理</a>
        </div>
        <div class="mian_content">
            <div id="page_content">
                <iframe id="menuFrame" name="menuFrame" src="admin.aspx" style="overflow:visible;" scrolling="yes" frameborder="no" height="100%" width="100%"></iframe>
            </div>
        </div>
    </div>
    <div class="layout_footer">
        <p></p>
    </div>


</body></html>
