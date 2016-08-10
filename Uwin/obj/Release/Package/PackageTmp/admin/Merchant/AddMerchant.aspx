<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMerchant.aspx.cs" Inherits="Uwin.admin.Merchant.AddMerchant" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加商户</title>
 <link href="../css/table.css" type="text/css" rel="stylesheet" />
<link rel="stylesheet" href="../css/add.css" type="text/css" media="screen">
<link rel="stylesheet" href="../css/bootstrap.css" type="text/css" media="screen">
</head>
<body>
    <form id="form1" runat="server">
    <div class="div_from_aoto">

        <div class="control-group">
            <label class="laber_from">商户名称</label>
            <div class="controls"><asp:TextBox ID="MerchantName" placeholder=" 请输入商户名称" class="input_from" runat="server"></asp:TextBox><p class="help-block"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请输入商户名称" ControlToValidate="MerchantName"></asp:RequiredFieldValidator></p></div>
        </div>
        
        
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
        <div class="control-group">
            <label class="laber_from">所属分站</label>
            <div class="controls">
                
                <asp:DropDownList ID="AffiliStation" runat="server" AutoPostBack="true" ></asp:DropDownList><p class="help-block"></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">商户地址</label>
            <div class="controls"><asp:TextBox ID="MerchantAddress" placeholder=" 商户地址" class="input_from" runat="server"></asp:TextBox><p class="help-block"><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="请输入商户地址" ControlToValidate="MerchantAddress"></asp:RequiredFieldValidator></p></div>
        </div>
                    <div class="control-group">
            <label class="laber_from">联系电话</label>
            <div class="controls"><asp:TextBox ID="MerchantTele" placeholder=" 联系电话" class="input_from" runat="server"></asp:TextBox><p class="help-block"><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="请输入联系电话" ControlToValidate="MerchantTele"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="请输入正确的手机号" Display="Dynamic" ControlToValidate="MerchantTele" ValidationExpression="^[1][358][0-9]{9}$"></asp:RegularExpressionValidator></p></div>
        </div>
                    <div class="control-group">
            <label class="laber_from">传真</label>
            <div class="controls"><asp:TextBox ID="MerchantFax" placeholder=" 传真" class="input_from" runat="server"></asp:TextBox><p class="help-block"></p></div>
        </div>
                    <div class="control-group">
            <label class="laber_from">电子邮件</label>
            <div class="controls"><asp:TextBox ID="MerchantEmial" placeholder=" 电子邮件" class="input_from" runat="server"></asp:TextBox><p class="help-block"><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="请输入邮件地址" ControlToValidate="MerchantEmial"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic" ErrorMessage="请输入正确的邮箱" ControlToValidate="MerchantEmial" ValidationExpression="^[A-Za-zd]+([-_.][A-Za-zd]+)*@([A-Za-zd]+[-.])+[A-Za-zd]{2,5}$ "></asp:RegularExpressionValidator></p></div>
        </div>
                 

                    <div class="control-group">
            <label class="laber_from">商户状态</label>
            <div class="controls">
                
                <asp:DropDownList ID="MerchantState" runat="server" AutoPostBack="true" >
                    <asp:ListItem Value="1" Text="立即启用"></asp:ListItem>
                    <asp:ListItem Value="0" Text="暂时禁用"></asp:ListItem>
                </asp:DropDownList><p class="help-block"></p></div>
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
