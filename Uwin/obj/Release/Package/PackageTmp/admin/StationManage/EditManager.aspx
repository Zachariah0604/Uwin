<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditManager.aspx.cs" Inherits="Uwin.admin.StationManage.EditManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>编辑管理员</title>
    <link href="../css/table.css" type="text/css" rel="stylesheet" />
<link rel="stylesheet" href="../css/add.css" type="text/css" media="screen">
<link rel="stylesheet" href="../css/bootstrap.css" type="text/css" media="screen">
</head>
<body>
    <form id="form1" runat="server">
    <div class="div_from_aoto">

        <div class="control-group">
            <label class="laber_from">用户名</label>
            <div class="controls"><asp:TextBox ID="Name"  CssClass="input required" placeholder=" 请输入用户名" class="input_from" runat="server"></asp:TextBox><p class="help-block">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请输入用户名" ControlToValidate="Name"></asp:RequiredFieldValidator></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">修改密码</label>
            <div class="controls"><asp:TextBox ID="Password" placeholder=" 请输入密码" class="input_from" runat="server" TextMode="Password"></asp:TextBox><p class="help-block"></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">确认密码</label>
            <div class="controls"><asp:TextBox ID="ConfirmPassword" placeholder=" 请再次输入密码" class="input_from" runat="server" TextMode="Password"></asp:TextBox><p class="help-block">
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="两次密码不一致！" ControlToCompare="Password" ControlToValidate="ConfirmPassword"></asp:CompareValidator>
</p></div>
        </div>
         <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
                     <div class="control-group">
            <label class="laber_from">联系方式</label>
            <div class="controls"><asp:TextBox ID="Telephone"  CssClass="input required" placeholder=" 请输入手机号码" class="input_from" runat="server" CausesValidation="True"></asp:TextBox><p class="help-block">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="请输入正确的手机号" Display="Dynamic" ControlToValidate="Telephone" ValidationExpression="^[1][358][0-9]{9}$"></asp:RegularExpressionValidator></p></div>
        </div>
                     <div class="control-group">
            <label class="laber_from">电子邮件</label>
            <div class="controls"><asp:TextBox ID="email"  CssClass="input required" placeholder=" 请输入电子邮件" class="input_from" runat="server"></asp:TextBox><p class="help-block">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic" ErrorMessage="请输入正确的邮箱" ControlToValidate="email" ValidationExpression="^[A-Za-zd]+([-_.][A-Za-zd]+)*@([A-Za-zd]+[-.])+[A-Za-zd]{2,5}$ "></asp:RegularExpressionValidator></p></div>
        </div>
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
                <asp:Button ID="EditBtn" runat="server" class="btn btn-success" Text="修改" style="width:120px;" OnClick="EditBtn_Click" /></div>
        </div>
    
</div>
    </form>
</body>
</html>
