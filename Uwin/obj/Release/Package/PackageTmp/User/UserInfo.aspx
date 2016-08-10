<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="Uwin.User.UserInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>个人信息</title>
    <link href="../css/table.css" type="text/css" rel="stylesheet" />
<link rel="stylesheet" href="../css/add.css" type="text/css" media="screen" />
<link rel="stylesheet" href="../css/bootstrap2.css" type="text/css" media="screen" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="div_from_aoto" style="height:500px;" >

        <div class="control-group">
            <label class="laber_from">用户名</label>
            <div class="controls"><asp:TextBox ID="userName" class="input_from" runat="server"></asp:TextBox><p class="help-block"></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">性别</label>
            <div class="controls"><asp:TextBox ID="userSex" class="input_from" runat="server"></asp:TextBox><p class="help-block"></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">邮箱</label>
            <div class="controls"><asp:TextBox ID="userEmail" class="input_from" runat="server"></asp:TextBox><p class="help-block"></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">联系电话</label>
            <div class="controls"><asp:TextBox ID="userTele" class="input_from" runat="server"></asp:TextBox><p class="help-block"></p></div>
        </div>
         <div class="control-group">
            <label class="laber_from">用户级别</label>
            <div class="controls"><asp:TextBox ID="userLevel" class="input_from" runat="server"></asp:TextBox><p class="help-block"></p></div>
        </div>
         <div class="control-group">
            <label class="laber_from">vip级别</label>
            <div class="controls"><asp:TextBox ID="userVipLevel" class="input_from" runat="server"></asp:TextBox><p class="help-block"></p></div>
        </div>
         <div class="control-group">
            <label class="laber_from">创建时间</label>
            <div class="controls"><asp:TextBox ID="userCreatime" class="input_from" runat="server"></asp:TextBox><p class="help-block"></p></div>
        </div>
      
    
</div>
    </form>
</body>
</html>
