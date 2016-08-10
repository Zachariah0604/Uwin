<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddParType.aspx.cs" Inherits="Uwin.admin.Items.AddParType" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加父类</title>
 <link href="../css/table.css" type="text/css" rel="stylesheet" />
<link rel="stylesheet" href="../css/add.css" type="text/css" media="screen">
<link rel="stylesheet" href="../css/bootstrap.css" type="text/css" media="screen">
</head>
<body>
    <form id="form1" runat="server">
    <div class="div_from_aoto" >

        <div class="control-group">
            <label class="laber_from">分类名称</label>
            <div class="controls"><asp:TextBox ID="ParTypeName" placeholder=" 请输入分类名称" class="input_from" runat="server"></asp:TextBox><p class="help-block"></p></div>
        </div>
        <div class="control-group" style="height:100px;">
            <label class="laber_from"  style="margin-top:40px;">分类缩略图（用于首页菜单导航）</label>
            <div class="controls">
                 <asp:FileUpload ID="ItemThumbnail" CssClass="files" runat="server"  style="margin-top:40px;" />
          <asp:Button ID="BtnUpLoad" runat="server" Text="上传" CssClass="submit" 
              onclick="BtnUpLoad_Click"  style="margin-top:40px;" />
                
               <p class="help-block" style="margin-left:50px;">&nbsp;&nbsp;&nbsp;<asp:Image ID="ItemThumbnailShow" runat="server" Width="100px" Height="100px" />

            </div>
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
