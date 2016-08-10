<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExpressManage.aspx.cs" Inherits="Uwin.admin.Resorces.ExpressManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>快递管理</title>
    <link href="../css/table.css" type="text/css" rel="stylesheet" />
    <link href="../../css/PageIndex.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../js/jquery-1.6.4.min.js"></script>
    <script type="text/javascript" src="../js/function.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="navi"><span class="option"><a href="AddExpress.aspx">新增快递</a></span><span class="posi"><b>当前位置：<asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath> </b></span></div>
        <asp:Repeater runat="server" ID="ExpressRepeter">
            <HeaderTemplate>
            <table id="mytable" cellspacing="0" summary="The technical specifications of the Apple PowerMac G5 series">
                <caption></caption>
                
                <tr>
                    <th width="10%"><span class="btn_all" onclick="checkAll(this);">全选</span></th>
                    <th width="10%">ID</th>
                    <th width="10%">名称</th>
                 <th width="30%">地址</th>
                    <th width="10%">联系电话</th>
                    <th width="30%">备注</th>
                </tr>
                </table>
                </HeaderTemplate>
            <ItemTemplate>
            <table id="mytable" cellspacing="2" summary="The technical specifications of the Apple PowerMac G5 series">
                <tr>
                    <td width="10%"><asp:CheckBox CssClass="checkall" ID="ExpressCheck" runat="server" /></td>
                    <td width="10%"><asp:Label ID="ID" runat="server" Text='<%#Eval("ID")%>'></asp:Label></td>
                     <td width="10%"><asp:Label ID="ExpresssName" runat="server" Text='<%#Eval("ExpresssName") %>'></asp:Label></td>
                    <td width="30%"><asp:Label ID="ExpressAddress" runat="server" Text='<%#Eval("ExpressAddress") %>'></asp:Label></td>
                    <td width="10%"><asp:Label ID="ExpresssTele" runat="server" Text='<%#Eval("ExpresssTele") %>'></asp:Label></td>
                    <td width="30%"><asp:Label ID="ExpressRemark" runat="server" Text='<%#Eval("ExpressRemark") %>'></asp:Label></td>
                    
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
