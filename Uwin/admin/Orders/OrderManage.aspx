<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderManage.aspx.cs" Inherits="Uwin.admin.Orders.OrderManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>订单管理</title>
<link href="../css/table.css" type="text/css" rel="stylesheet" />
    <link href="../../css/PageIndex.css" type="text/css" rel="stylesheet" />
 
    <script type="text/javascript" src="../js/jquery-1.6.4.min.js"></script>
    <script type="text/javascript" src="../js/function.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="100px" align="center">按商户查看：</td>
        <td>
            <asp:DropDownList ID="orderAffilMerchant" runat="server" CssClass="select" 
                onselectedindexchanged="orderAffilMerchant_SelectedIndexChanged" 
                AutoPostBack="True"></asp:DropDownList>&nbsp;
           
        </td>
        <td width="100px" align="center">按订单状态查看：</td>
        <td>
            <asp:DropDownList ID="orderState" runat="server" CssClass="select" 
                onselectedindexchanged="orderState_SelectedIndexChanged" 
                AutoPostBack="True">
                <asp:ListItem Value="1" Text="待支付"></asp:ListItem>
                <asp:ListItem Value="2" Text="已支付"></asp:ListItem>
                <asp:ListItem Value="3" Text="备货中"></asp:ListItem>
                <asp:ListItem Value="4" Text="已发货"></asp:ListItem>
                <asp:ListItem Value="5" Text="已收货"></asp:ListItem>
                <asp:ListItem Value="6" Text="申请退款"></asp:ListItem>
                <asp:ListItem Value="7" Text="退款受理"></asp:ListItem>
                <asp:ListItem Value="8" Text="已退款"></asp:ListItem>
            </asp:DropDownList>&nbsp;
           
        </td>
          
        </tr>
    </table>
    <div>
        <div class="navi"><span class="option"></span><span class="posi"><b>当前位置：<asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath> </b></span></div>
        <asp:Repeater runat="server" ID="OrderRepeter">
            <HeaderTemplate>
            <table id="mytable" cellspacing="0" summary="The technical specifications of the Apple PowerMac G5 series">
                <caption></caption>
                
                <tr>
                    <th width="5%"><span class="btn_all" onclick="checkAll(this);">全选</span></th>
                    <th width="5%">ID</th>
                    <th width="10%">订单号</th>
                    <th width="5%">订单总额</th>
                    <th width="20%">商品名称</th>
                    <th width="15%">所属商户</th>
                    <th width="5%">收货人</th>
                    <th width="10%">收货电话</th>
                     <th width="5%">订单状态</th>
                     <th width="10%">支付时间</th>
                    <th width="10%">操作</th>
                </tr>
                </table>
                </HeaderTemplate>
            <ItemTemplate>
            <table id="mytable" cellspacing="2" summary="The technical specifications of the Apple PowerMac G5 series">
                <tr>
                    <td width="5%"><asp:CheckBox CssClass="checkall" ID="OrderCheck" runat="server" /></td>
                    <td width="5%"><asp:Label ID="orderID" runat="server" Text='<%#Eval("orderID")%>'></asp:Label></td>
                     <td width="10%"><asp:Label ID="orderNum" runat="server" Text='<%#Eval("orderNum") %>'></asp:Label></td>
                    <td width="5%"><asp:Label ID="orderCost" runat="server" Text='<%#Eval("orderCost") %>'></asp:Label></td>
                    <td width="20"><asp:Label ID="orderItemName" runat="server" Text='<%#Eval("orderItemName") %>'></asp:Label></td>
                    <td width="15%"><asp:Label ID="orderAffilMerchant" runat="server" text='<%#SetMerchantName(Eval("orderAffilMerchant").ToString()) %>'></asp:Label></td>
                    <td width="5%"><asp:Label ID="orderReceiver" runat="server"  Text='<%#Eval("orderReceiver") %>'></asp:Label></td>
                    <td width="10%"><asp:Label ID="orderReceiverTele" runat="server" Text='<%#Eval("orderReceiverTele") %>'></asp:Label></td>
                    <td width="5%"><asp:Label ID="orderState" runat="server" Text='<%#SetStateName(Eval("orderState").ToString()) %>'></asp:Label></td>
                    <td width="10%"><asp:Label ID="orderCreatTime" runat="server" Text='<%#Eval("orderCreatTime") %>'></asp:Label></td>
                    <td width="10%"><span><a href="OrdersVerify.aspx?orderID=<%#Eval("orderID") %>">审核</a></span>&nbsp;&nbsp;<span><a href="OrderSend.aspx?orderID=<%#Eval("orderID") %>">发货</a></span>&nbsp;&nbsp;<span><a href="OrderPrint.aspx?orderID=<%#Eval("orderID") %>" target="_blank">打印</a></span></td>
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
