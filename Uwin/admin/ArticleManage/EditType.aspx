<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditType.aspx.cs" Inherits="Uwin.admin.ArticleManage.EditType" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改分类</title>
<link href="../css/table.css" type="text/css" rel="stylesheet" />
<link rel="stylesheet" href="../css/add.css" type="text/css" media="screen">
<link rel="stylesheet" href="../css/bootstrap.css" type="text/css" media="screen">
</head>
<body>
    <form id="form1" runat="server">
    <div class="div_from_aoto">

        <div class="control-group">
            <label class="laber_from">分类名称</label>
            <div class="controls"><asp:TextBox ID="TypeName" placeholder=" 请输入分类名称" class="input_from" runat="server"></asp:TextBox><p class="help-block"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请输入分类名称" ControlToValidate="TypeName"></asp:RequiredFieldValidator></p></div>
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

