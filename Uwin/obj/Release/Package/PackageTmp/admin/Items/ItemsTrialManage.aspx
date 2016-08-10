<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemsTrialManage.aspx.cs" Inherits="Uwin.admin.Items.ItemsTrialManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>试用商品管理</title>
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
        <asp:Repeater runat="server" ID="ItemsTrialRepeter">
            <HeaderTemplate>
            <table id="mytable" cellspacing="0" summary="The technical specifications of the Apple PowerMac G5 series">
                <caption></caption>
                
                <tr>
                    <th width="5%"><span class="btn_all" onclick="checkAll(this);">全选</span></th>
                    <th width="5%">ID</th>
                    <th width="30%">商品名称</th>
                    <th width="5%">押金</th>
                    <th width="5%">线上库存</th>
                    <th width="5%">电视库存</th>
                    <th width="5%">申请数</th>
                    <th width="5%">发放数</th>
                     <th width="10%">开始时间</th>
                     <th width="10%">结束时间</th>
                    <th width="5%">状态</th>
                     <th width="10%">操作</th>
                </tr>
                </table>
                </HeaderTemplate>
            <ItemTemplate>
            <table id="mytable" cellspacing="2" summary="The technical specifications of the Apple PowerMac G5 series">
                <tr>
                    <td width="5%"><asp:CheckBox CssClass="checkall" ID="ItemsTrialCheck" runat="server" /></td>
                    <td width="5%"><asp:Label ID="itemsID" runat="server" Text='<%#Eval("itemsID")%>'></asp:Label></td>
                     <td width="30%"><asp:Label ID="itemName" runat="server" Text='<%#Eval("itemName") %>'></asp:Label></td>
                    <td width="5%"><asp:Label ID="itemTriPrice" runat="server" Text='<%#Eval("itemTriPrice") %>'></asp:Label></td>
                    <td width="5"><asp:Label ID="itemTriOnlStock" runat="server" Text='<%#Eval("itemTriOnlStock") %>'></asp:Label></td>
                    <td width="5%"><asp:Label ID="itemTriVideoStock" runat="server" text='<%#Eval("itemTriVideoStock") %>'></asp:Label></td>
                    <td width="5%"><asp:Label ID="itemTriApply" runat="server"  Text='<%#Eval("itemTriApply") %>'></asp:Label></td>
                    <td width="5%"><asp:Label ID="itemTriAgree" runat="server" Text='<%#Eval("itemTriAgree") %>'></asp:Label></td>
                    <td width="10%"><asp:Label ID="itemTriStime" runat="server" Text='<%#Eval("itemTriStime") %>'></asp:Label></td>
                    <td width="10%"><asp:Label ID="itemTriEtime" runat="server" Text='<%#Eval("itemTriEtime") %>'></asp:Label></td>
                    <td width="5%"><asp:Label ID="itemTriState" runat="server" Text='<%# Int32.Parse(Eval("itemTriState").ToString())==1?"进行中":"X 已结束" %>'></asp:Label></td>
                    <td width="10%"><asp:LinkButton Class="spebtn"  CommandName='<%#Eval("itemTriState") %>' CommandArgument='<%#Eval("itemsID")%>' ID="StateBtn" oncommand="StateBtn_Command" runat="server" Text='<%# Int32.Parse(Eval("itemTriState").ToString())==1?"结束试用":"设为试用" %>'></asp:LinkButton>&nbsp;&nbsp;<a href="EditItems.aspx?itemsID=<%#Eval("itemsID") %>">编辑</a></td>
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
