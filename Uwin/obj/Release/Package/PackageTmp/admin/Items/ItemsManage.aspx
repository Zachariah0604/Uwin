<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemsManage.aspx.cs" Inherits="Uwin.admin.Items.ItemsManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>产品管理</title>
<link href="../css/table.css" type="text/css" rel="stylesheet" />
    <link href="../../css/PageIndex.css" type="text/css" rel="stylesheet" />
 
    <script type="text/javascript" src="../js/jquery-1.6.4.min.js"></script>
    <script type="text/javascript" src="../js/function.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="100px" align="center">按分站查看：</td>
        <td>
            <asp:DropDownList ID="Station" runat="server" CssClass="select" 
                onselectedindexchanged="Station_SelectedIndexChanged" 
                AutoPostBack="True"></asp:DropDownList>&nbsp;
           
        </td>
        <td width="100px" align="center">按商品状态查看：</td>
        <td>
            <asp:DropDownList ID="itemState" runat="server" CssClass="select" 
                onselectedindexchanged="itemState_SelectedIndexChanged" 
                AutoPostBack="True">
                <asp:ListItem Value="1" Text="已上架"></asp:ListItem>
                <asp:ListItem Value="0" Text="已下架"></asp:ListItem>
            </asp:DropDownList>&nbsp;
           
        </td>
          <td width="100px" align="center">按品牌查看：</td>
        <td>
            <asp:DropDownList ID="itemBrand" runat="server" CssClass="select" 
                onselectedindexchanged="itemBrand_SelectedIndexChanged" 
                AutoPostBack="True"></asp:DropDownList>&nbsp;
           
        </td>
        </tr>
    </table>
    <div>
        <div class="navi"><span class="option"><a href="AddItem.aspx">添加商品</a></span><span class="posi"><b>当前位置：<asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath> </b></span></div>
        <asp:Repeater runat="server" ID="ItemsRepeter">
            <HeaderTemplate>
            <table id="mytable" cellspacing="0" summary="The technical specifications of the Apple PowerMac G5 series">
                <caption></caption>
                
                <tr>
                    <th width="5%"><span class="btn_all" onclick="checkAll(this);">全选</span></th>
                    <th width="5%">ID</th>
                    <th width="35%">商品名称</th>
                    <th width="5%">市场价</th>
                    <th width="5%">成本价</th>
                    <th width="5%">销售价</th>
                    <th width="10%">所属分站</th>
                    <th width="5%">库存量</th>
                     <th width="5%">总销量</th>
                     <th width="10%">状态</th>
                     <th width="10%">操作</th>
                </tr>
                </table>
                </HeaderTemplate>
            <ItemTemplate>
            <table id="mytable" cellspacing="2" summary="The technical specifications of the Apple PowerMac G5 series">
                <tr>
                    <td width="5%"><asp:CheckBox CssClass="checkall" ID="ItemsCheck" runat="server" /></td>
                    <td width="5%"><asp:Label ID="itemsID" runat="server" Text='<%#Eval("itemsID")%>'></asp:Label></td>
                     <td width="35%"><asp:Label ID="itemName" runat="server" Text='<%#Eval("itemName") %>'></asp:Label></td>
                    <td width="5%"><asp:Label ID="itemMarketPrice" runat="server" Text='<%#Eval("itemMarketPrice") %>'></asp:Label></td>
                    <td width="5"><asp:Label ID="itemCost" runat="server" Text='<%#Eval("itemCost") %>'></asp:Label></td>
                    <td width="5%"><asp:Label ID="itemSalePrice" runat="server" text='<%#Eval("itemSalePrice") %>'></asp:Label></td>
                    <td width="10%"><asp:Label ID="itemAffiliStation" runat="server"  Text='<%#Eval("itemAffiliStation") %>'></asp:Label></td>
                    <td width="5%"><asp:Label ID="itemStock" runat="server" Text='<%#Eval("itemStock") %>'></asp:Label></td>
                    <td width="5%"><asp:Label ID="itemSaleNum" runat="server" Text='<%#Eval("itemSaleNum") %>'></asp:Label></td>
                    <td width="10%"><asp:Label ID="itemState" runat="server" Text='<%# Int32.Parse(Eval("itemState").ToString())==1?"已上架":"X 已下架" %>'></asp:Label></td>
                    <td width="10%"><asp:LinkButton Class="spebtn"  CommandName='<%#Eval("itemState") %>' CommandArgument='<%#Eval("itemsID")%>' ID="StateBtn" oncommand="StateBtn_Command" runat="server" Text='<%# Int32.Parse(Eval("itemState").ToString())==1?"下架":"上架" %>'></asp:LinkButton>&nbsp;&nbsp;<a href="EditItems.aspx?itemsID=<%#Eval("itemsID") %>">编辑</a></td>
                </tr>
               

            </table>
                </ItemTemplate>
            </asp:Repeater>
        <div class="btnmenu">
               
                  <asp:LinkButton ID="DelBtn" runat="server" onclick="DelBtn_Click" OnClientClick="return confirm( '确定要删除这些记录吗？ ');">批量删除</asp:LinkButton>&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="ToHtml" runat="server" onclick="ToHtml_Click" >批量生成商品详情页</asp:LinkButton>&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="AllToHtml" runat="server" onclick="AllToHtml_Click" >一键生成所有商品详情页</asp:LinkButton>
                 

        </div>
    </div>
        <div style=" width:95%; float:right; height:30px; margin-right:10px; margin-top:10px; text-align:right;">
                <div id="PageInfo" runat="server" class="anpager"></div>
            </div>
    </form>
</body>
</html>

