<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserOrder.aspx.cs" Inherits="Uwin.User.UserOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="../css/PageIndex.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="from1" runat="server">
    <div class="UserOrder">
        <div class="orderMenu">
            <ul>

                <li>
                    <asp:LinkButton ID="orderStateAll" runat="server" OnClick="orderStateAll_Click">所有订单</asp:LinkButton></li>

                <li><asp:LinkButton ID="orderState1" runat="server" OnClick="orderState1_Click">待付款</asp:LinkButton></li>
                <li><asp:LinkButton ID="orderState2" runat="server" OnClick="orderState2_Click">已付款</asp:LinkButton></li>
                <li><asp:LinkButton ID="orderState3" runat="server" OnClick="orderState3_Click">备货中</asp:LinkButton></li>
                <li><asp:LinkButton ID="orderState4" runat="server" OnClick="orderState4_Click">已发货</asp:LinkButton></li>
                <li><asp:LinkButton ID="orderState5" runat="server" OnClick="orderState5_Click">已收货</asp:LinkButton></li>
                <li><asp:LinkButton ID="orderState6" runat="server" OnClick="orderState6_Click">申请退款</asp:LinkButton></li>

                <li><asp:LinkButton ID="orderState8" runat="server" OnClick="orderState8_Click">已退款</asp:LinkButton></li>



            </ul>
        </div>
        <asp:Repeater runat="server" ID="UserOrderRepeter"><ItemTemplate>
        <div class="orderList">
            <div class="ordertile">
                <div class="ordernum"><%#((DateTime)Eval("orderCreatTime")).ToString("yyyy-MM-dd")%>&nbsp;&nbsp;订单号：<%#Eval("orderNum") %></div>
                <div class="ordermer"><%#SetMerchantName(Eval("orderAffilMerchant").ToString())%></div>
                <div class="orderqq"><a href="tencent://Message/?Uin=001001&Site=qq联系代码"><img src="../images/qq.png" height="30px" /></a></div>
                <div class="orderdelete">删除</div>
            </div>
            <div class="orderconntent">
                <div class="items">
                    <div class="itemsimg"><img src='../FileUpload/Images/ItemsThumb/<%#Eval("itemThumbnail") %>' width="100px" /></div>
                    <div class="itemsName"><%#Eval("itemName") %></div>
                    <div class="itemsother"><%#SetSubTypeName(Eval("itemAffiliSubType").ToString()) %></div>
                </div>
                <div class="itemsUnitPrice"><%#Eval("itemSalePrice") %></div>
                <div class="itemscount"><%#Eval("orderCount") %></div>
                <div class="itemsSumPrice"><%#Eval("orderCost") %>(含运费)</div>
                <div class="itemsState"><br /><%#SetStateName(Eval("orderState").ToString()) %><br />订单详情<br />查看物流</div>
                <div class="itemsOperate">评价</div>
            </div>
        </div>
            </ItemTemplate></asp:Repeater>
       
        <div style="width:100%; height:30px;"></div>
         <div style=" width:95%; float:right; height:30px; margin-right:10px; margin-top:10px; text-align:right;">
                <div id="PageInfo" runat="server" class="anpager"></div>
            </div>
   </div>
        </form>
</body>
</html>
