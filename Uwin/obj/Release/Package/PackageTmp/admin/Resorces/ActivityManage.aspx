<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActivityManage.aspx.cs" Inherits="Uwin.admin.Resorces.ActivityManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>活动管理</title>
<link href="../css/table.css" type="text/css" rel="stylesheet" />
    <link href="../../css/PageIndex.css" type="text/css" rel="stylesheet" />
 
    <script type="text/javascript" src="../js/jquery-1.6.4.min.js"></script>
    <script type="text/javascript" src="../js/function.js"></script>
</head>
<body>
    <form id="form1" runat="server">
       <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="150" align="center">活动类型：</td>
        <td>
            <asp:DropDownList ID="ActivityAffliType" runat="server" CssClass="select" 
                onselectedindexchanged="ActivityAffliType_SelectedIndexChanged" 
                AutoPostBack="True">

                <asp:ListItem Text="全部" Value="1"></asp:ListItem>
                <asp:ListItem Text="推介" Value="2"></asp:ListItem>
                <asp:ListItem Text="报名" Value="3"></asp:ListItem>
                <asp:ListItem Text="调查" Value="4"></asp:ListItem>
            </asp:DropDownList>&nbsp;
           
        </td>
        <td width="150" align="center">所属分站：</td>
        <td>
            <asp:DropDownList ID="Station" runat="server" CssClass="select" 
                onselectedindexchanged="Station_SelectedIndexChanged" 
                AutoPostBack="True">
            </asp:DropDownList>&nbsp;
           
        </td>
        </tr>
    </table>
    <div>
        <div class="navi"><span class="option"><a href="AddActivity.aspx">添加活动</a></span><span class="posi"><b>当前位置：<asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath> </b></span></div>
        <asp:Repeater runat="server" ID="ActivityRepeter">
            <HeaderTemplate>
            <table id="mytable" cellspacing="0" summary="The technical specifications of the Apple PowerMac G5 series">
                <caption></caption>
                
                <tr>
                    <th width="5%"><span class="btn_all" onclick="checkAll(this);">全选</span></th>
                    <th width="5%">ID</th>
                    <th width="35%">活动名称</th>
                    <th width="5%">活动类型</th>
                    <th width="5%">所属分站</th>
                    <th width="10%">开始时间</th>
                    <th width="10%">结束时间</th>
                    <th width="5%">活动状态</th>
                    <th width="10%">添加时间</th>
                    <th width="10%">操作</th>
                </tr>
                </table>
                </HeaderTemplate>
            <ItemTemplate>
            <table id="mytable" cellspacing="2" summary="The technical specifications of the Apple PowerMac G5 series">
                <tr>
                    <td width="5%"><asp:CheckBox CssClass="checkall" ID="ActivityCheck" runat="server" /></td>
                    <td width="5%"><asp:Label ID="ActivityID" runat="server" Text='<%#Eval("ActivityID")%>'></asp:Label></td>
                     <td width="35%"><asp:Label ID="ActivityName" runat="server" Text='<%#Eval("ActivityName") %>'></asp:Label></td>
                    <td width="5%"><asp:Label ID="ActivityAffliTypeLable" runat="server" Text='<%#Eval("ActivityAffliType") %>'></asp:Label></td>
                    <td width="5%"><asp:Label ID="ActivityAffiStation" runat="server" Text='<%#Eval("station") %>'></asp:Label></td>
                    <td width="10%"><asp:Label ID="ActivityStime" runat="server" text='<%#Eval("ActivityStime") %>'></asp:Label></td>
                    <td width="10%"><asp:Label ID="AcrtivityEtime" runat="server" Text='<%#Eval("AcrtivityEtime") %>'></asp:Label></td>
                    <td width="5%"><asp:Label ID="ActivityState" runat="server" Text='<%# Int32.Parse(Eval("ActivityState").ToString())==1?"进行中":"X 已结束" %>'></asp:Label></td>
                    <td width="10%"><asp:Label ID="ActivityCreatime" runat="server" Text='<%#Eval("ActivityCreatime") %>'></asp:Label></td>
                    <td width="10%"><a href="EditActivity.aspx?ActivityID=<%#Eval("ActivityID") %>">编辑</a></td>
                </tr>
               

            </table>
                </ItemTemplate>
            </asp:Repeater>
        <div class="btnmenu">
               
                  <asp:LinkButton ID="DelBtn" runat="server" onclick="DelBtn_Click" OnClientClick="return confirm( '确定要删除这些记录吗？ ');">批量删除</asp:LinkButton>

            &nbsp;&nbsp;&nbsp;<asp:LinkButton ID="ToHtml" runat="server" onclick="ToHtml_Click" >批量生成文章内容页</asp:LinkButton>
                 

        </div>
    </div>
        <div style=" width:95%; float:right; height:30px; margin-right:10px; margin-top:10px; text-align:right;">
                <div id="PageInfo" runat="server" class="anpager"></div>
            </div>
    </form>
</body>
</html>

