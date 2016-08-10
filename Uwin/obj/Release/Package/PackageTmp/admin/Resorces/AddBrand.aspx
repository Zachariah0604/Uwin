<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddBrand.aspx.cs" Inherits="Uwin.admin.Resorces.AddBrand" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加品牌</title>
<link href="../css/table.css" type="text/css" rel="stylesheet" />
<link rel="stylesheet" href="../css/add.css" type="text/css" media="screen">
<link rel="stylesheet" href="../css/bootstrap.css" type="text/css" media="screen">
</head>
<body>
    <form id="form1" runat="server">
    <div class="div_from_aoto">

        <div class="control-group">
            <label class="laber_from">品牌名称</label>
            <div class="controls"><asp:TextBox ID="BrandName" placeholder=" 请输入品牌名称" class="input_from" runat="server"></asp:TextBox><p class="help-block"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="品牌名称不能为空" ControlToValidate="BrandName"></asp:RequiredFieldValidator></p></div>
        </div>
        
        <div class="control-group">
            <label class="laber_from">品牌logo（100*50）</label>
            <div class="controls"><asp:FileUpload ID="BrandLogo" runat="server"  CssClass="input w250"/><p class="help-block"></p></div>
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
