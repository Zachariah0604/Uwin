<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Province.aspx.cs" Inherits="Uwin.admin.Resorces.CityMange.Province" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>省份</title>
<link href="../../css/table.css" type="text/css" rel="stylesheet" />
    <link href="../../../css/PageIndex.css" type="text/css" rel="stylesheet" />
 
    <script type="text/javascript" src="../../js/jquery-1.6.4.min.js"></script>
    <script type="text/javascript" src="../../js/function.js"></script>
</head>
<body>
    <form id="form1" runat="server">
       
    <div>
        <div class="navi"><span class="option"><a href="Add.aspx">新增</a></span><span class="posi"><b>当前位置：<asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath> </b></span></div>
        <asp:Repeater runat="server" ID="ProvinceRepeter">
            <HeaderTemplate>
            <table id="mytable" cellspacing="0" summary="The technical specifications of the Apple PowerMac G5 series">
                <caption></caption>
                
                <tr>
                    <th width="20%"><span class="btn_all" onclick="checkAll(this);">全选</span></th>
                    <th width="20%">ID</th>
                    <th width="20%">编码</th>
                    <th width="40%">省份名称</th>
                    
                </tr>
                </table>
                </HeaderTemplate>
            <ItemTemplate>
            <table id="mytable" cellspacing="2" summary="The technical specifications of the Apple PowerMac G5 series">
                <tr>
                    <td width="20%"><asp:CheckBox CssClass="checkall" ID="ProvinceCheck" runat="server" /></td>
                    <td width="20%"><asp:Label ID="id" runat="server" Text='<%#Eval("id")%>'></asp:Label></td>
                     <td width="20%"><asp:Label ID="code" runat="server" Text='<%#Eval("code") %>'></asp:Label></td>
                    <td width="40%"><a href="City.aspx?code=<%#Eval("code") %>"><%#Eval("name") %></a></td>
                   
                    
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