<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddSubType.aspx.cs" Inherits="Uwin.admin.Items.AddSubType" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加子类</title>
  <link href="../css/table.css" type="text/css" rel="stylesheet" />
<link rel="stylesheet" href="../css/add.css" type="text/css" media="screen">
<link rel="stylesheet" href="../css/bootstrap.css" type="text/css" media="screen">
</head>
<body>
    <form id="form1" runat="server">
    <div class="div_from_aoto">

        <div class="control-group">
            <label class="laber_from">分类名称</label>
            <div class="controls"><asp:TextBox ID="subTypeName" placeholder=" 请输入分类名称" class="input_from" runat="server"></asp:TextBox><p class="help-block"></p></div>
        </div>
        
        
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
        <div class="control-group">
            <label class="laber_from">所属父类</label>
            <div class="controls">
                
                <asp:DropDownList ID="parTypeID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="parTypeID_SelectedIndexChanged"></asp:DropDownList><p class="help-block"></p></div>
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

