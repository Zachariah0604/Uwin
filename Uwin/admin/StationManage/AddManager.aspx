<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddManager.aspx.cs" Inherits="Uwin.admin.StationManage.AddManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加管理员</title>
    <link href="../css/table.css" type="text/css" rel="stylesheet" />
<link rel="stylesheet" href="../css/add.css" type="text/css" media="screen">
<link rel="stylesheet" href="../css/bootstrap.css" type="text/css" media="screen">
</head>
<body>
    <form id="form1" runat="server">
        
    <div class="div_from_aoto">

        <div class="control-group">
            <label class="laber_from">用户名</label>
            <div class="controls"><asp:TextBox ID="Name" placeholder=" 请输入用户名" class="input_from" runat="server"></asp:TextBox><p class="help-block"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请输入用户名" ControlToValidate="Name"></asp:RequiredFieldValidator></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">登录密码</label>
            <div class="controls"><asp:TextBox ID="Password" placeholder=" 请输入密码" class="input_from" runat="server" TextMode="Password"></asp:TextBox><p class="help-block"></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">确认密码</label>
            <div class="controls"><asp:TextBox ID="ConfirmPassword" placeholder=" 请再次输入密码" class="input_from" runat="server" TextMode="Password"></asp:TextBox><p class="help-block"> <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="两次密码不一致！" ControlToCompare="Password" ControlToValidate="ConfirmPassword"></asp:CompareValidator></p></div>
        </div>
         <div class="control-group">
            <label class="laber_from">手机</label>
            <div class="controls"><asp:TextBox ID="telephone" placeholder="11位手机号码" class="input_from" runat="server"></asp:TextBox><p class="help-block"><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="请输入手机号码" ControlToValidate="telephone"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="请输入正确的手机号" Display="Dynamic" ControlToValidate="Telephone" ValidationExpression="^[1][358][0-9]{9}$"></asp:RegularExpressionValidator></p></div>
        </div>
         <div class="control-group">
            <label class="laber_from">电子邮件</label>
            <div class="controls"><asp:TextBox ID="email" placeholder=" 请输入电子邮件" class="input_from" runat="server"></asp:TextBox><p class="help-block"><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="请输入邮件地址" ControlToValidate="email"></asp:RequiredFieldValidator></p></div>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
        <div class="control-group">
            <label class="laber_from">管理员身份</label>
            <div class="controls">
                
                <asp:DropDownList ID="AdminRole" runat="server" AutoPostBack="true" OnSelectedIndexChanged="AdminRole_SelectedIndexChanged"></asp:DropDownList><p class="help-block"></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">所属分站</label>
            <div class="controls">
                <asp:DropDownList ID="Station" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Station_SelectedIndexChanged"></asp:DropDownList><p class="help-block"></p></div>
        </div>
        </ContentTemplate></asp:UpdatePanel>
        <div class="control-group">
            <label class="laber_from"></label>
            <div class="controls">
                <asp:Button ID="AddBtn" runat="server" class="btn btn-success" Text="添加" style="width:120px;" OnClick="AddBtn_Click" /></div>
        </div>
    
</div>
    </form>
</body>
</html>
