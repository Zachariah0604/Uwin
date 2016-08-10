<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserEdit.aspx.cs" Inherits="Uwin.User.UserEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改密码</title>
    <link href="../css/table.css" type="text/css" rel="stylesheet" />
<link rel="stylesheet" href="../css/add.css" type="text/css" media="screen" />
<link rel="stylesheet" href="../css/bootstrap2.css" type="text/css" media="screen" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="div_from_aoto" style="height:300px;">

        <div class="control-group">
            <label class="laber_from">原密码</label>
            <div class="controls"><asp:TextBox ID="OldPassword" placeholder=" 请输入旧密码" class="input_from" runat="server"></asp:TextBox><p class="help-block"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="旧密码不能为空" ControlToValidate="OldPassword"></asp:RequiredFieldValidator></p></div>
        </div>
       
        <div class="control-group">
            <label class="laber_from">新密码</label>
            <div class="controls"><asp:TextBox ID="userPassword" placeholder=" 请输入新密码" class="input_from" runat="server"></asp:TextBox><p class="help-block"><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="新密码不能为空" ControlToValidate="userPassword"></asp:RequiredFieldValidator></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">确认新密码</label>
            <div class="controls"><asp:TextBox ID="userPasswordConfirm" placeholder=" 确认新密码" class="input_from" runat="server"></asp:TextBox><p class="help-block"> <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="不能为空" ControlToValidate="userPasswordConfirm"></asp:RequiredFieldValidator><asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="两次密码不一致！" ControlToCompare="userPassword" ControlToValidate="userPasswordConfirm"></asp:CompareValidator></p></div>
        </div>
       
     
        <div class="control-group">
            <label class="laber_from"></label>
            <div class="controls">
                <asp:Button ID="EditBtn" runat="server" class="btn btn-success" Text="修改" style="width:120px;" OnClick="EditBtn_Click" /></div>
        </div>
    
</div>
    </form>
</body>
</html>
