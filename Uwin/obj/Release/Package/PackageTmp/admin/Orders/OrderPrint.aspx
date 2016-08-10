<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderPrint.aspx.cs" Inherits="Uwin.admin.Orders.OrderPrint" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title></title>
<style>
        BODY
        {
            scrollbar-arrow-color: #797979;
            margin: 0px;
            scrollbar-darkshadow-color: #ffffff;
            font-family: "Arial" , "宋体" , "Helvetica" , "sans-serif";
            scrollbar-highlight-color: #f5f9ff;
            scrollbar-shadow-color: #828282;
            font-size: 14px;
            scrollbar-track-color: #ececec;
            scrollbar-3dlight-color: #828282;
        }
        td
        {
            scrollbar-arrow-color: #797979;
            margin: 0px;
            scrollbar-darkshadow-color: #ffffff;
            font-family: "Arial" , "宋体" , "Helvetica" , "sans-serif";
            scrollbar-highlight-color: #f5f9ff;
            scrollbar-shadow-color: #828282;
            font-size: 14px;
            scrollbar-track-color: #ececec;
            scrollbar-3dlight-color: #828282;
        }
        TH
        {
            scrollbar-arrow-color: #797979;
            margin: 0px;
            scrollbar-darkshadow-color: #ffffff;
            font-family: "Arial" , "宋体" , "Helvetica" , "sans-serif";
            scrollbar-highlight-color: #f5f9ff;
            scrollbar-shadow-color: #828282;
            font-size: 14px;
            scrollbar-track-color: #ececec;
            scrollbar-3dlight-color: #828282;
        }
        .printTitle
        {
            font-size: 24px;
            font-weight: bold;
        }
        .printTitle2
        {
            font-size: 18px;
            font-weight: normal;
        }
        .printTitle3
        {
            font-size: 18px;
            font-weight: bold;
        }
        .printTitle4
        {
            font-style: italic;
            font-size: 18px;
            font-weight: bold;
        }
        .printEntrytable
        {
            border-bottom: #000000 1px solid;
            border-left: #000000 1px solid;
            border-collapse: collapse;
            border-top: #000000 1px solid;
            border-right: #000000 1px solid;
        }
        .printEntrytable tr
        {
            height: 20px;
        }
        .printEntrytable TH
        {
            border-bottom: #000000 1px solid;
            border-left: #000000 1px solid;
            border-top: #000000 1px solid;
            font-weight: normal;
            border-right: #000000 1px solid;
        }
        .printEntrytable td
        {
            border-bottom: #000000 1px solid;
            border-left: #000000 1px solid;
            border-top: #000000 1px solid;
            border-right: #000000 1px solid;
        }
        .PageNext
        {
            page-break-after: always;
        }
        .style1
        {
            width: 90px;
        }
        .style2
        {
            width: 105px;
        }
        .style3
        {
            width: 72px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="position: relative" border="0" cellspacing="5px" cellpadding="5px" width="100%">
            <tbody>
                <tr style="background-color: #dcdcdc">
                    <td style="font-size: 14px">
                        <b></b>
                        <input id="hidExportTag" type="hidden">
                    </td>
                    <td id="tdUCToolBar" align="right">
                        <input id="printButton" onclick="javascipt: window.print()" value="打印" type="button">
                        <input id="closButton"  onclick="javascript: window.close();" value="关闭" type="button">
                    </td>
                </tr>
            </tbody>
        </table>
        <table style="width: 730px" border="0" cellspacing="5px" cellpadding="5px" align="center">
            <tbody>
                <tr>
                    <td colspan="2">
                        <table style="width: 100%; table-layout: fixed" border="0">
                            <tbody>
                                <tr>
                                    <td>
                                        <img src="../../FileUpload/Images/logo.png" />
                                    </td>
                                    <td class="printTitle3" colspan="2" style="text-align: center; line-height: 100px;">
                                        <asp:Label ID="station" runat="server" Text=""></asp:Label>悦赢
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        地址：
                                    </td>
                                    <td colspan="3">
                                        <asp:Label ID="MerchantAddress" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td>
                                        电话：
                                    </td>
                                    <td>
                                        <asp:Label ID="MerchantTele" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td style="padding-left: 30px">
                                        传真：
                                    </td>
                                    <td>
                                        <asp:Label ID="MerchantFax" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        网站：
                                    </td>
                                    <td>
                                        http://localhost
                                    </td>
                                    <td style="padding-left: 30px">
                                        E-Mail：
                                    </td>
                                    <td>
                                        <asp:Label ID="MerchantEmial" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center" colspan="2">
                        <table style="width: 100%" class="Title" border="0">
                            <tbody>
                                <tr>
                                    <td style="text-align: center" class="printTitle">
                                        销售订单
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <table width="510" border="0" style="width: 500px">
                            <tbody>
                                <tr>
                                    <td class="style3">
                                        购买用户：
                                    </td>
                                    <td width="440" style="width: 440px">
                                        <asp:Label ID="userName" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3">
                                        注册时间：
                                    </td>
                                    <td style="word-wrap: break-word; word-break: normal">
                                        <asp:Label ID="userCreatime" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3">
                                        性别：
                                    </td>
                                    <td>
                                        <asp:Label ID="userSex" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3">
                                        Email：
                                    </td>
                                    <td>
                                        <asp:Label ID="userEmail" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3">
                                        手机：
                                    </td>
                                    <td>
                                        <asp:Label ID="userTele" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3">
                                        用户级别：
                                    </td>
                                    <td>
                                        <asp:Label ID="userLevel" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3">
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                    <td valign="top">
                        <table style="width: 230px" border="0">
                            <tbody>
                                <tr>
                                    <td class="style1">
                                        订单编号：
                                    </td>
                                    <td>
                                        <asp:Label ID="orderNum" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        订单日期：
                                    </td>
                                    <td>
                                        <asp:Label ID="orderCreatTime" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        销售商户：
                                    </td>
                                    <td>
                                        <asp:Label ID="MerchantName" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        已收款：
                                    </td>
                                    <td>
                                        <asp:Label ID="orderCost" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        订单状态：
                                    </td>
                                    <td>
                                        <asp:Label ID="orderState" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        货运公司：
                                    </td>
                                    <td>
                                        <asp:Label ID="expCompany" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        货运单号：
                                    </td>
                                    <td>
                                        <asp:Label ID="expressNum" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table border="0">
                            <tbody>
                                <tr>
                                    <td>
                                        送货地址：
                                    </td>
                                    <td>
                                        <asp:Label ID="expAdress" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table class="printEntrytable" width="100%">
                            <tbody>
                                <asp:Repeater runat="server" ID="CartRepeter">
                                    <HeaderTemplate>
                                <tr align="center">
                                    <td>
                                        序号
                                    </td>
                                    <td>
                                        商品编号
                                    </td>
                                    <td>
                                        商品名称
                                    </td>
                                    
                                    <td>
                                        单位
                                    </td>
                                    <td>
                                        数量
                                    </td>
                                    <td>
                                        折率
                                    </td>
                                    <td>
                                        单价
                                    </td>
                                    <td>
                                        金额
                                    </td>
                                </tr>
                            </HeaderTemplate>
                                    <ItemTemplate>
                                <tr>
                                    <td>
                                       <asp:Label ID="cartID" runat="server" Text='<%#Eval("cartID") %>'></asp:Label>
                                    </td>
                                   
                                    <td>
                                       <asp:Label ID="cartAffiItem" runat="server" Text='<%#Eval("cartAffiItem") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="cartAffiItemName" runat="server" Text='<%#Eval("cartAffiItemName") %>'></asp:Label>
                                    </td>
                                    <td>
                                       <asp:Label ID="Label3" runat="server" Text="件"></asp:Label>
                                    </td>
                                    <td>
                                     <asp:Label ID="cartItemNum" runat="server" Text='<%#Eval("cartItemNum") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="cartItemDisCount" runat="server" Text='<%#Eval("cartItemDisCount") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="cartItemPrice" runat="server" Text='<%#Eval("cartItemPrice") %>'>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="cartItemPriceSum" runat="server" Text='<%#Eval("cartItemPriceSum") %>'></asp:Label>
                                    </td>
                                </tr>
                               </ItemTemplate>
                                    </asp:Repeater>
                                    
                                <tr>
                                    <td colspan="4" align="right">
                                        合计：
                                    </td>
                                    <td align="right">
                                     <asp:Label ID="orderCountSum" runat="server" Text=""></asp:Label>
                                       
                                    </td>
                                    <td align="right">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="right">
                                      <asp:Label ID="orderSumSum" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                        
                                    
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="right">
                        <table border="0">
                            <tbody>
                                <tr>
                                    <td>
                                        优惠金额：
                                    </td>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td style="padding-left: 30px">
                                        附加金额：
                                    </td>
                                    <td>
                                        <asp:Label ID="attach_pay" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td style="padding-left: 30px">
                                        优惠后金额：
                                    </td>
                                    <td>
                                      <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table border="0">
                            <tbody>
                                <tr>
                                    <td>
                                        大写金额：
                                    </td>
                                    <td>
                                       <asp:Label ID="Upletter" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table border="0">
                            <tbody>
                                <tr>
                                    <td style="white-space: nowrap; vertical-align: top">
                                        相关描述：
                                    </td>
                                    <td style="line-height: 20px">
                                        <asp:Label ID="description" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table border="0">
                            <tbody>
                                <tr>
                                    <td style="vertical-align: bottom">
                                        制单人：
                                    </td>
                                    <td style="border-bottom: #000000 2px solid; width: 90px; height: 30px; vertical-align: bottom">
                                        <asp:Label ID="order_user" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td style="padding-left: 10px; vertical-align: bottom">
                                        审核人：
                                    </td>
                                    <td style="border-bottom: #000000 2px solid; width: 90px; height: 30px; vertical-align: bottom">
                                        <asp:Label ID="auditing_user" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td style="padding-left: 10px; vertical-align: bottom">
                                        供应商签字（盖章）：
                                    </td>
                                    <td style="border-bottom: #000000 2px solid; width: 110px; height: 30px; vertical-align: bottom">
                                        &nbsp;
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    </form>
</body>
</html>
