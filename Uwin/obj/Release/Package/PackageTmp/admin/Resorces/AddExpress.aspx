<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddExpress.aspx.cs" Inherits="Uwin.admin.Resorces.AddExpress" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/table.css" type="text/css" rel="stylesheet" />
<link rel="stylesheet" href="../css/add.css" type="text/css" media="screen">
<link rel="stylesheet" href="../css/bootstrap.css" type="text/css" media="screen">
</head>
<body>
    <form id="form1" runat="server">
  <div class="div_from_aoto">

        <div class="control-group">
            <label class="laber_from">快递名称</label>
            <div class="controls"><asp:TextBox ID="ExpresssName" placeholder=" 请输入快递名称" class="input_from" runat="server"></asp:TextBox><p class="help-block"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="快递名称不能为空" ControlToValidate="ExpresssName"></asp:RequiredFieldValidator></p></div>
        </div>
      <div class="control-group">
            <label class="laber_from">地址</label>
            <div class="controls"><asp:TextBox ID="ExpressAddress" placeholder=" 请输入地址" class="input_from" runat="server"></asp:TextBox><p class="help-block"><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="地址不能为空" ControlToValidate="ExpressAddress"></asp:RequiredFieldValidator></p></div>
        </div>
      <div class="control-group">
            <label class="laber_from">联系电话</label>
            <div class="controls"><asp:TextBox ID="ExpresssTele" placeholder=" 请输入联系电话" class="input_from" runat="server"></asp:TextBox><p class="help-block"><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="联系电话不能为空" ControlToValidate="ExpresssTele"></asp:RequiredFieldValidator></p></div>
        </div>
      <div class="control-group">
            <label class="laber_from">备注</label>
            <div class="controls"><asp:TextBox ID="ExpressRemark" placeholder=" 请输入备注" class="input_from" runat="server"></asp:TextBox><p class="help-block"><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="备注不能为空" ControlToValidate="ExpressRemark"></asp:RequiredFieldValidator></p></div>
        </div>
        
        
        <div class="control-group">
            <label class="laber_from"></label>
            <div class="controls">
                <asp:Button ID="AddBtn" runat="server" class="btn btn-success" Text="添加" style="width:120px;" OnClick="AddBtn_Click" /></div>
        </div>
    
</div>
    </form>
</body>
</html>
