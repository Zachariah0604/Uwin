<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MerchantManage.aspx.cs" Inherits="Uwin.admin.Merchant.MerchantManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>商户管理</title>
<link href="../css/table.css" type="text/css" rel="stylesheet" />
    <link href="../../css/PageIndex.css" type="text/css" rel="stylesheet" />
 
    <script type="text/javascript" src="../js/jquery-1.6.4.min.js"></script>
    <script type="text/javascript" src="../js/function.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
       
        <td width="100px" align="center">按商户状态查看：</td>
        <td>
            <asp:DropDownList ID="MerchantState" runat="server" CssClass="select" 
                onselectedindexchanged="MerchantState_SelectedIndexChanged" 
                AutoPostBack="True">
                <asp:ListItem Value="1" Text="使用中"></asp:ListItem>
                <asp:ListItem Value="0" Text="已禁用"></asp:ListItem>
            </asp:DropDownList>&nbsp;
           
        </td>
          
        </tr>
    </table>
    <div>
        <div class="navi"><span class="option"><a href="AddMerchant.aspx">添加商户</a></span><span class="posi"><b>当前位置：<asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath> </b></div>
        <asp:Repeater runat="server" ID="MerchantRepeter">
            <HeaderTemplate>
            <table id="mytable" cellspacing="0" summary="The technical specifications of the Apple PowerMac G5 series">
                <caption></caption>
                
                <tr>
                    <th width="5%"><span class="btn_all" onclick="checkAll(this);">全选</span></th>
                    <th width="5%">ID</th>
                    <th width="15%">商户名称</th>
                    <th width="10%">所属分站</th>
                    <th width="25%">商户地址</th>
                    <th width="10%">联系电话</th>
                    <th width="10%">传真</th>
                    <th width="10%">电子邮件</th>
                    <th width="5%">状态</th>
                    <th width="5%">操作</th>
                   
                </tr>
                </table>
                </HeaderTemplate>
            <ItemTemplate>
            <table id="mytable" cellspacing="2" summary="The technical specifications of the Apple PowerMac G5 series">
                <tr>
                    <td width="5%"><asp:CheckBox CssClass="checkall" ID="MerchantCheck" runat="server" /></td>
                    <td width="5%"><asp:Label ID="MerchantID" runat="server" Text='<%#Eval("MerchantID")%>'></asp:Label></td>
                     <td width="15%"><asp:Label ID="MerchantName" runat="server" Text='<%#Eval("MerchantName") %>'></asp:Label></td>
                    <td width="10%"><asp:Label ID="Affilistation" runat="server" Text='<%#Eval("station") %>'></asp:Label></td>
                   
                    <td width="25%"><asp:Label ID="Label1" runat="server" Text='<%#Eval("MerchantAddress") %>'></asp:Label></td>
                    <td width="10%"><asp:Label ID="Label2" runat="server" Text='<%#Eval("MerchantTele") %>'></asp:Label></td>
                    <td width="10%"><asp:Label ID="Label3" runat="server" Text='<%#Eval("MerchantFax") %>'></asp:Label></td>
                    <td width="10%"><asp:Label ID="Label4" runat="server" Text='<%#Eval("MerchantEmial") %>'></asp:Label></td>

                    <td width="5%"><asp:Label ID="MerchantState" runat="server" Text='<%# Int32.Parse(Eval("MerchantState").ToString())==1?"使用中":"X 已禁用" %>'></asp:Label></td>
                    
                    <td width="5%"><asp:LinkButton Class="spebtn"  CommandName='<%#Eval("MerchantState") %>' CommandArgument='<%#Eval("MerchantID")%>' ID="StateBtn" oncommand="StateBtn_Command" runat="server" Text='<%# Int32.Parse(Eval("MerchantState").ToString())==1?"禁用":"启用" %>'></asp:LinkButton></td>
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


